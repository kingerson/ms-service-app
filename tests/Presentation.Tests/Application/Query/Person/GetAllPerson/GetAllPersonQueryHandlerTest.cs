using AutoMapper;
using FluentAssertions;
using Moq;
using MsServiceApp;
using MsServiceApp.Infraestructure;
using System.Linq.Expressions;

namespace Presentation.Tests.Application.Query
{
    public class GetAllPersonQueryHandlerTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapper;
        private readonly GetAllPersonQueryHandler _getAllPersonQueryHandler;
        public GetAllPersonQueryHandlerTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _getAllPersonQueryHandler = new GetAllPersonQueryHandler(_unitOfWorkMock.Object, _mapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldPassThrough_Query()
        {
            // Arrange
            var query = new GetAllPersonQuery();
            var person = new Person();
            person.Register("Gerson", "Navarro", "g.navarrope@gmail.com");

            var response = new List<Person>
            {
                person
            };

            var responseViewModel = new List<PersonViewModel>
            {
                new PersonViewModel{ Name = "Gerson", LastName = "Navarro", Email = "g.navarrope@gmail.com" }
            };

            _unitOfWorkMock.Setup(m => m.Repository<Person>().GetAsync(It.IsAny<Expression<Func<Person, bool>>>(),It.IsAny<List<Expression<Func<Person, object>>>>(),true)).ReturnsAsync(response);

            _mapper.Setup(m => m.Map<IEnumerable<PersonViewModel>>(response)).Returns(responseViewModel);

            // Act
            var result = await _getAllPersonQueryHandler.Handle(query, new CancellationToken());

            // Assert

            result.Should().NotBeEmpty();
        }
    }
}
