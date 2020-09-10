using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAsyncTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			AsnycTester test = new AsnycTester();
			test.Run();
			Console.ReadLine();
		}
	}
}
