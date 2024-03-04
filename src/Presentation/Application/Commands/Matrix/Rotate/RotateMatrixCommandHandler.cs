using MediatR;
using MsServiceApp.Domain;

namespace MsServiceApp
{
    public class RotateMatrixCommandHandler : IRequestHandler<RotateMatrixCommand, int[][]>
    {
        public RotateMatrixCommandHandler()
        {
        }

        public async Task<int[][]> Handle(RotateMatrixCommand request, CancellationToken cancellationToken)
        {
            var length = request.Body.Length;

            foreach (var item in request.Body)
            {
                if (item == null || item.Length != length)
                    throw new MsServiceException("Error in matrix");
            }

            var result = RotateMatrix(request.Body);
            return await Task.FromResult(result);
        }

        public int[][] RotateMatrix(int[][] matrix)
        {
            int n = matrix.Length;
            int[][] rotated = new int[n][];

            for (int i = 0; i < n; i++)
            {
                rotated[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    rotated[i][j] = matrix[j][n - i - 1];
                }
            }

            return rotated;
        }
    }
}