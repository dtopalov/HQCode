namespace DecreasingAbsoluteDifference
{
    using System;
    using System.Linq;

    internal class DecreasingAbsoluteDifferenceSolution
    {
        private static void Main()
        {
            int numberOfInputLines;
            bool isNumberOfInputLinesValid = int.TryParse(Console.ReadLine(), out numberOfInputLines);
            if (!isNumberOfInputLinesValid)
            {
                throw new ArgumentException("Invalid number");
            }

            if (numberOfInputLines < 4 || numberOfInputLines > 10)
            {
                throw new ArgumentOutOfRangeException("Number of lines must be between" + " 4 and 10 inclusive");
            }

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string inputLine = Console.ReadLine();
                int[] processedInputLine = ProcessInput(inputLine);
                bool result = CheckForDecreasingSequence(processedInputLine);

                Console.WriteLine(result);
            }
        }

        private static int[] ProcessInput(string input)
        {
            int[] processedInput =
                input.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return processedInput;
        }

        private static bool CheckForDecreasingSequence(int[] inputLine)
        {
            int[] absDiff = new int[inputLine.Length - 1];

            for (int i = 0; i < absDiff.Length; i++)
            {
                absDiff[i] = Math.Abs(inputLine[i] - inputLine[i + 1]);
                if (i >= 1)
                {
                    if (absDiff[i] > absDiff[i - 1] || Math.Abs(absDiff[i - 1] - absDiff[i]) > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
