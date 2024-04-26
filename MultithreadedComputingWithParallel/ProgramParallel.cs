using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MultithreadedComputingWithParallel
{
    internal class ProgramParallel
    {
        public static void MultiplyMatrices(int[,] a, int[,] b, int[,] result, int numThreads)
        {
            int rows = a.GetLength(0);
            int cols = b.GetLength(1);
            int common = a.GetLength(1);

            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = numThreads };

            Parallel.For(0, rows, options, i =>
            {
                for (int j = 0; j < cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < common; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            });
        }

        public static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j < cols; j++)
                {
                    matrix[i, j] = random.Next(1, 100);
                }
            }

            return matrix;
        }

        public static void DisplayMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0;i < rows; i++)
            {
                for (int j = 0;j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of threads:");
            int numThreads;
            while (!int.TryParse(Console.ReadLine(), out numThreads) || numThreads <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of threads.");
            }

            Console.WriteLine("Enter size of matrix:");
            int matrixSize;
            while (!int.TryParse(Console.ReadLine(), out matrixSize) || matrixSize <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the matrix size.");
            }

            int[,] matrixA = GenerateRandomMatrix(matrixSize, matrixSize); ;
            int[,] matrixB = GenerateRandomMatrix(matrixSize, matrixSize);
            int[,] resultMatrix = new int[matrixSize, matrixSize];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MultiplyMatrices(matrixA, matrixB, resultMatrix, numThreads);

            stopwatch.Stop();
            Console.WriteLine($"Execute time: {stopwatch.ElapsedMilliseconds} ms");

            /*Console.WriteLine("\nMatrix A:");
            DisplayMatrix(matrixA);

            Console.WriteLine("\nMatrix B:");
            DisplayMatrix(matrixB);

            Console.WriteLine("\nResult:");
            DisplayMatrix(resultMatrix);*/
        }
    }
}
