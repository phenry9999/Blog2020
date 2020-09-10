using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
	public class Program
	{
		private const int fizzBuzzMax = 50;

		static void Main(string[] args)
		{
			//FizzBuzzFirst();
			//FizzBuzzSecond();
			FizzBuzzThird();
			Console.ReadLine();
		}
		private static void FizzBuzzThird()
		{
			Dictionary<int, string> fizzBuzzValues = new Dictionary<int, string>();
			fizzBuzzValues.Add(3, "Fizz");
			fizzBuzzValues.Add(5, "Buzz");
			fizzBuzzValues.Add(7, "Sleeps");
			fizzBuzzValues.Add(9, "Niners");


			Console.WriteLine("FizzBuzz Coding Challenge");
			StringBuilder sb = new StringBuilder();

			for (int i = 1; i <= fizzBuzzMax; i++)
			{
				string currItem = string.Empty;

				foreach (var currFizzBuzz in fizzBuzzValues)
				{
					if (i % currFizzBuzz.Key == 0)
						currItem += currFizzBuzz.Value;
				}

				if (string.IsNullOrEmpty(currItem))
					currItem = i.ToString();

				sb.Append(currItem + Environment.NewLine);
			}

			Console.WriteLine(sb.ToString());
		}

		private static void FizzBuzzSecond()
		{
			int fizzValue = 3;
			int buzzValue = 5;

			Console.WriteLine("FizzBuzz Coding Challenge");
			StringBuilder sb = new StringBuilder();

			for (int i = 1; i <= fizzBuzzMax; i++)
			{
				string currItem = string.Empty;

				if (i % fizzValue == 0)
					currItem += "Fizz";

				if (i % buzzValue == 0)
					currItem += "Buzz";

				if (string.IsNullOrEmpty(currItem))
					currItem = i.ToString();

				sb.Append(currItem + Environment.NewLine);
			}

			Console.WriteLine(sb.ToString());
		}

		private static void FizzBuzzFirst()
		{
			Console.WriteLine("FizzBuzz Coding Challenge");
			StringBuilder sb = new StringBuilder();

			for (int i = 1; i <= fizzBuzzMax; i++)
			{
				if ((i % 3 == 0) && (i % 5 != 0))
					sb.Append("Fizz");

				if ((i % 3 != 0) && (i % 5 == 0))
					sb.Append("Buzz");

				if ((i % 3 == 0) && (i % 5 == 0))
					sb.Append("FizzBuzz");

				if ((i % 3 != 0) && (i % 5 != 0))
					sb.Append(i);

				sb.Append(Environment.NewLine);
			}

			Console.WriteLine(sb.ToString());
			Console.ReadLine();
		}

	}
}
