namespace LoverOf2
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class LoverOf2Solution
    {
        private static void Main()
        {
            string rowsInput = Console.ReadLine();
            string colsInput = Console.ReadLine();
            string numberOfMoves = Console.ReadLine();

            int rows = ValidateInputNumber(rowsInput, 1, 100);
            int cols = ValidateInputNumber(colsInput, 1, 75);
            int numberOfDirectionsAndMoves = ValidateInputNumber(numberOfMoves, 1, 1000);

            string codesInput = Console.ReadLine();
            if (codesInput == null)
            {
                throw new ArgumentNullException("Codes cannot be" + " null");
            }

            int[] codes =
                codesInput
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            BigInteger[,] field = new BigInteger[rows, cols];
            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = (BigInteger)Math.Pow(2, rows - row - 1 + col);
                }
            }

            int currentRow = rows - 1;
            int currentCol = 0;
            BigInteger sum = 0;

            for (int i = 0; i < numberOfDirectionsAndMoves; i++)
            {
                int targetRow = codes[i] / Math.Max(rows, cols);
                int targetCol = codes[i] % Math.Max(rows, cols);
                int startingRow = currentRow;
                int startingCol = currentCol;

                sum = MoveVertically(startingRow, targetRow, ref sum, field, ref currentRow, currentCol);
                sum = MoveHorizontally(startingCol, targetCol, ref sum, field, currentRow, ref currentCol);
            }

            Console.WriteLine(sum);
        }

        private static int ValidateInputNumber(string input, int minValue, int maxValue)
        {
            int number;
            bool validNumber = int.TryParse(input, out number);
            if (!validNumber || number < minValue || number > maxValue)
            {
                throw new ArgumentException(
                    string.Format("Number must be a valid integer in the range [{0}, {1}]", minValue, maxValue));
            }

            return number;
        }

        private static BigInteger MoveVertically(int start, int end, ref BigInteger sum, BigInteger[,] field, ref int currentRow, int currentCol)
        {
            for (int j = 0; j < Math.Abs(end - start); j++)
            {
                sum += field[currentRow, currentCol];
                field[currentRow, currentCol] = 0;
                if (currentRow > end)
                {
                    currentRow--;
                }
                else if (currentRow < end)
                {
                    currentRow++;
                }

                sum += field[currentRow, currentCol];
                field[currentRow, currentCol] = 0;
            }

            return sum;
        }

        private static BigInteger MoveHorizontally(int start, int end, ref BigInteger sum, BigInteger[,] field, int currentRow, ref int currentCol)
        {
            for (int j = 0; j < Math.Abs(end - start); j++)
            {
                sum += field[currentRow, currentCol];
                field[currentRow, currentCol] = 0;
                if (currentCol > end)
                {
                    currentCol--;
                }
                else if (currentCol < end)
                {
                    currentCol++;
                }

                sum += field[currentRow, currentCol];
                field[currentRow, currentCol] = 0;
            }

            return sum;
        }
    }
}
