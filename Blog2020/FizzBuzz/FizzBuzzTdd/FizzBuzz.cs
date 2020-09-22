using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTdd
{
	public class FizzBuzz
	{
		private const int fizzValue = 3;
		private const int buzzValue = 5;

		public string Generate(int maxCounter)
		{
			StringBuilder sb = new StringBuilder();

			if (maxCounter % fizzValue == 0)
			{
				sb.Append("Fizz");
			}

			if (maxCounter % buzzValue == 0)
			{
				sb.Append("Buzz");
			}

			if (string.IsNullOrEmpty(sb.ToString()))
			{
				sb.Append(maxCounter.ToString());
			}

			return sb.ToString();
		}
	}
}
