namespace BooleanToStringConverter
{
    using System;

    public class BooleanToStringConverter
	{
		public static void CreateConverter()
		{
			var converter = new Converter();
			converter.ConvertBooleanToString(true);
		}

		private class Converter
		{
			public void ConvertBooleanToString(bool inputToConvert)
			{
				string booleanAsString = inputToConvert.ToString();
				Console.WriteLine(booleanAsString);
			}
		}
	}
}
