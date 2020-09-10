using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberCheck
{
	public class Program
	{
		static void Main(string[] args)
		{
			//FindPrimes();
			//ReverseString();

			Console.ReadLine();
		}


		private static void ReverseString()
		{
			Console.WriteLine("Enter string to reverse = ");
			//string inputToReverse = Console.ReadLine();
			string inputToReverse = "Testing this string out to see what happens when it's reversed.";
			char[] reverseArray = inputToReverse.ToCharArray();

			StringBuilder reversedString = new StringBuilder();

			//first way
			for (int i = inputToReverse.Length - 1; i >= 0; i--)
			{
				reversedString.Append(reverseArray[i]);
			}

			Console.WriteLine("1 => " + reversedString.ToString());

			//second way
			reverseArray = inputToReverse.Reverse().ToArray();
			Console.WriteLine("2 => " + reversedString.ToString());

			Console.ReadLine();
		}

		private static void FindPrimes()
		{
			Console.WriteLine("Enter max number to check for primes = ");
			int maxNumber = Convert.ToInt32(Console.ReadLine());
			StringBuilder listOfPrimes = new StringBuilder();

			listOfPrimes.Append($"Primes between 2 and {maxNumber} are = ");
			bool isPrime = false;

			for (int i = 2; i <= maxNumber; i++)
			{
				for (int j = 2; j <= maxNumber; j++)
				{
					if (i != j && i % j == 0)
					{
						isPrime = false;
						break;
					}
				}

				if (isPrime)
				{
					listOfPrimes.Append($" {i}");
				}

				isPrime = true;
			}

			Console.WriteLine(listOfPrimes.ToString());

		}
	}
}
