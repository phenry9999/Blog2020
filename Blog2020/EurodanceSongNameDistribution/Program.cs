using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurodanceSongNameDistribution
{
	public class Program
	{
		static string OtherNodeName = "OTHER";
		static string euroDancePath = @"D:\Music\EuroDance";
		static string outputFile = @"c:\temp\EuroDanceSongNameDistribution.txt";

		public static void Main(string[] args)
		{
			var songList = Directory.EnumerateFiles(euroDancePath).Where(x => x.Contains(".mp3") || x.Contains(".wma"));
			Dictionary<string, int> songTitleCounts = new Dictionary<string, int>();

			SetupCountingBuckets(songTitleCounts);
			CountSongs(songList, songTitleCounts);
			DisplaySongResults(songTitleCounts);
		}

		private static void DisplaySongResults(Dictionary<string, int> songTitleCounts)
		{
			StringBuilder sb = new StringBuilder();

			foreach (KeyValuePair<string, int> song in songTitleCounts)
			{
				sb.Append($"{song.Key} = {song.Value}{"\t"}{song.Key}{"\t"}{song.Value}" + Environment.NewLine);
			}

			sb.Append($"Total songs counted = {songTitleCounts.Sum(x => x.Value)}");

			Console.WriteLine(sb.ToString());
			WriteResultsToFile(outputFile, sb.ToString());
		}

		private static void WriteResultsToFile(string outputFile, string contents)
		{
			File.WriteAllText(outputFile, contents);
		}

		private static void CountSongs(IEnumerable<string> songList, Dictionary<string, int> songTitleCounts)
		{
			var otherSong = songTitleCounts.Where(x => x.Key == OtherNodeName).FirstOrDefault();

			foreach (string song in songList)
			{
				FileInfo songFile = new FileInfo(song);
				string songFileName = songFile.Name;

				string firstSongLetter = songFileName.First().ToString().ToUpper();
				if (songTitleCounts.ContainsKey(firstSongLetter))
				{
					songTitleCounts[firstSongLetter] += 1;
				}
				else
				{
					songTitleCounts[OtherNodeName] += 1;
				}
			}
		}

		private static void SetupCountingBuckets(Dictionary<string, int> songTitleCounts)
		{
			for (int i = 0; i < 10; i++)
			{
				songTitleCounts.Add(i.ToString(), 0);
			}

			for (char c = 'A'; c <= 'Z'; c++)
			{
				songTitleCounts.Add(c.ToString(), 0);
			}

			songTitleCounts.Add(OtherNodeName, 0);
		}
	}
}
