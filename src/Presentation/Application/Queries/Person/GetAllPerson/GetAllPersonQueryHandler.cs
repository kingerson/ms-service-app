using AutoMapper;
using MediatR;
using MsServiceApp.Infraestructure;

namespace MsServiceApp
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllPersonQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PersonViewModel>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<Person>().GetAsync();
            var personViewModels = _mapper.Map<IEnumerable<PersonViewModel>>(person);
            return personViewModels;
        }
    }
}