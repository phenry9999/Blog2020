using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzTdd
{
	public class ItemCount
	{

		public int Item
		{
			get; set;
		}
		public int Count
		{
			get; set;
		}

		public ItemCount(int item, int count)
		{
			this.Item = item;
			this.Count = count;
		}
	}

	public class Result
	{
		/*
		 * Complete the 'itemsSort' function below.
		 *
		 * The function is expected to return an INTEGER_ARRAY.
		 * The function accepts INTEGER_ARRAY items as parameter.
		 */

		public static List<int> itemsSort(List<int> items)
		{
			List<ItemCount> countedItems = new List<ItemCount>();
			CountItemValues(items, countedItems);
			List<int> sortedResults = SortCountedItems(countedItems);
			return sortedResults;
		}

		public static void CountItemValues(List<int> items, List<ItemCount> countedItems)
		{
			foreach (int item in items.Distinct())
			{
				int itemCount = items.Where(x => x == item).Count();
				countedItems.Add(new ItemCount(item, itemCount));
			}
		}

		public static List<int> SortCountedItems(List<ItemCount> countedItems)
		{
			List<ItemCount> newlySortedResults = new List<ItemCount>();
			newlySortedResults = countedItems.OrderBy(x => x.Count).ToList<ItemCount>();

			List<int> sortedItems = new List<int>();

			foreach (ItemCount item in newlySortedResults)
			{
				for (int i = 0; i < item.Count; i++)
				{
					sortedItems.Add(item.Item);
				}
			}

			return sortedItems;
		}
	}
}