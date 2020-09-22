using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzTdd;

namespace FizzBuzzTddTests
{
	[TestClass]
	public class FizzBuzzTests
	{
		public static FizzBuzz fb = new FizzBuzz();

		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext)
		{
			fb = new FizzBuzz();
		}

		[TestMethod]
		public void CanCallFizzBuzz()
		{
			//Arrange

			string expected = "1";

			//Act
			string actual = fb.Generate(1);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given1Get1()
		{
			string expected = 1.ToString();

			string actual = fb.Generate(1);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given2Get2()
		{
			string expected = 2.ToString();

			string actual = fb.Generate(2);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given3GetFizz()
		{
			string expected = "Fizz";

			string actual = fb.Generate(3);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given4GetFizz()
		{
			string expected = "4";

			string actual = fb.Generate(4);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given5GetBuzz()
		{
			string expected = "Buzz";

			string actual = fb.Generate(5);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given6GetFizz()
		{
			string expected = "Fizz";

			string actual = fb.Generate(6);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Given15GetFizzBuzz()
		{
			string expected = "FizzBuzz";

			string actual = fb.Generate(15);

			Assert.AreEqual(expected, actual);
		}

	}
}






