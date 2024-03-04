using MediatR;

namespace MsServiceApp
{
    public class RotateMatrixCommand : IRequest<int[][]>
    {
        public int[][] Body { get; set; }
    }
}