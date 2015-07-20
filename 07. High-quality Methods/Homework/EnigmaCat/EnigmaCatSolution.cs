namespace EnigmaCat
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class EnigmaCatSolution
    {
        private static void Main()
        {           
            string input = Console.ReadLine();
            string[] processedInput = ProcessInput(input);

            char[] alphabet = CreateAlphabet(26);

            List<string> finalOutput = new List<string>();

            for (int i = 0; i < processedInput.Length; i++)
            {
                string curWord = processedInput[i];
                StringBuilder reversedItem = ReverseWord(curWord);
                string convertedItem = ConvertItem(reversedItem, 17, alphabet);
                finalOutput.Add(convertedItem);
            }

            Console.WriteLine(string.Join(" ", finalOutput));
        }

        private static string[] ProcessInput(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input cannot" + " be null");
            }

            string[] processedInput = input.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return processedInput;
        }

        private static char[] CreateAlphabet(int numberOfLetters)
        {
            char[] alphabet = new char[numberOfLetters];

            for (int i = 0; i < numberOfLetters; i++)
            {
                alphabet[i] = (char)('a' + i);
            }

            return alphabet;
        }

        private static StringBuilder ReverseWord(string word)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                result.Insert(0, word[i]);
            }

            return result;
        }

        private static string ConvertItem(StringBuilder item, int target, char[] alphabet)
        {
            ulong decimalResult = 0;
            StringBuilder convertedItemBuilder = new StringBuilder();

            for (int i = 0; i < item.Length; i++)
            {
                ulong product = 1;
                for (int j = 0; j < i; j++)
                {
                    product *= (ulong)target;
                }

                decimalResult += (ulong)Array.IndexOf(alphabet, item[i]) * product;
            }

            if (decimalResult == 0)
            {
                convertedItemBuilder.Append('a');
            }
            else
            {
                while (decimalResult > 0)
                {
                    convertedItemBuilder.Insert(0, alphabet[decimalResult % 26]);
                    decimalResult /= 26;
                }
            }

            return convertedItemBuilder.ToString();
        }
    }
}
