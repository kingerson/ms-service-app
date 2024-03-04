using AutoMapper;
using MediatR;
using MsServiceApp.Domain;
using MsServiceApp.Infraestructure;

namespace MsServiceApp
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPersonByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonViewModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<Person>().GetById(request.Id);

            if (person is null)
                throw new MsServiceException($"Person with id : {request.Id} not found");

            return _mapper.Map<PersonViewModel>(person);
        }
    }
}