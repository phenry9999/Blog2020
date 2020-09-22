using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzTdd;
using System.Collections.Generic;

namespace FizzBuzzTddTests
{
	[TestClass]
	public class TestKinaxisSort
	{

		[TestMethod]
		public void SortTest()
		{
			//Arrange
			List<int> unsorted = new List<int> { 8, 5, 5, 5, 5, 1, 1, 1, 4, 4 };
			List<int> expectedSorted = new List<int> { 8, 4, 4, 1, 1, 1, 5, 5, 5, 5 };

			//Act
			List<int> actualSorted = Result.itemsSort(unsorted);

			//Assert
			for (int i = 0; i < actualSorted.Count; i++)
			{
				Assert.AreEqual(expectedSorted[i], actualSorted[i]);
			}

			CollectionAssert.AreEqual(expectedSorted, actualSorted);
		}

	}
}






