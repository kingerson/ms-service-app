using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MsServiceApp;
using MsServiceApp.Domain;
using System.Net;

namespace Presentation.Tests.Controllers
{
    public class MatrixControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly MatrixController _matrixController;

        public MatrixControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _matrixController = new MatrixController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Rotate_ShouldReturn_Ok()
        {
            // Arrange
            var matrix = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            var matrixResult = new int[][]
            {
                new int[] { 3, 6, 9 },
                new int[] { 2, 5, 8 },
                new int[] { 1, 4, 7 }
            };

            var command = new RotateMatrixCommand
            {
               Body = matrix
            };

            var cancelationToken = new CancellationToken();

            _mediatorMock.Setup(x => x.Send(command, cancelationToken)).ReturnsAsync(matrixResult);

            // Act
            var result = await _matrixController.Rotate(command);

            // Assert

            ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)result).Value.Should().BeEquivalentTo(matrixResult);
        }

        [Fact]
        public async Task Rotate_ShouldReturn_BadRequest()
        {
            // Arrange
            var matrix = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            var matrixResult = new int[][]
            {
                new int[] { 3, 6, 9 },
                new int[] { 2, 5, 8 },
                new int[] { 1, 4, 7 }
            };

            var command = new RotateMatrixCommand
            {
                Body = matrix
            };

            var cancelationToken = new CancellationToken();

            _mediatorMock.Setup(x => x.Send(command, cancelationToken)).ThrowsAsync(new MsServiceException("Error in matrix"));

            // Act

            var result = async () => await _matrixController.Rotate(command);

            // Assert

            await result.Should().ThrowAsync<MsServiceException>();
        }
    }
}
