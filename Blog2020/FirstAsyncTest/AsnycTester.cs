using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FirstAsyncTest
{
	public class AsnycTester
	{
		List<WebsiteData> websites = new List<WebsiteData>();
		public AsnycTester()
		{
			SetupWebsites();
		}

		private void SetupWebsites()
		{
			websites.Add(new WebsiteData("www.google.com"));
			websites.Add(new WebsiteData("www.Microsoft.com"));
			websites.Add(new WebsiteData("www.Amazon.com"));
			websites.Add(new WebsiteData("www.Microsoft.com"));
			websites.Add(new WebsiteData("www.Yahoo.com"));
			websites.Add(new WebsiteData("www.cnn.com"));
			websites.Add(new WebsiteData("www.CodeProject.com"));
			websites.Add(new WebsiteData("www.StackOverflow.com"));
			websites.Add(new WebsiteData("www.Zeerka.com"));
			websites.Add(new WebsiteData("www.Slack.com"));
		}

		public async Task Run()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			List<Task> tasks = new List<Task>();

			foreach (var website in websites)
			{
				tasks.Add(Task.Run(() => DownloadWebsiteAsync(website)));
			}

			await Task.WhenAll(tasks);

			foreach (var website in websites)
			{
				ReportWebsiteResults(website);
			}

			stopwatch.Stop();
			Console.Write(Environment.NewLine);
			Console.WriteLine($"Total Loading Times = {stopwatch.ElapsedMilliseconds}ms");
		}

		private async Task DownloadWebsite(WebsiteData website)
		{
			WebClient client = new WebClient();

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string websiteBody = await Task.Run(() => client.DownloadString(website.SiteUrl));
			website.PageContents = websiteBody;
			stopwatch.Stop();

			website.LoadTime = stopwatch.ElapsedMilliseconds;
		}

		private async Task DownloadWebsiteAsync(WebsiteData website)
		{
			WebClient client = new WebClient();

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string websiteBody = await Task.Run(() => client.DownloadStringTaskAsync(website.SiteUrl));
			website.PageContents = websiteBody;
			stopwatch.Stop();

			website.LoadTime = stopwatch.ElapsedMilliseconds;
		}

		private void ReportWebsiteResults(WebsiteData website)
		{
			Console.WriteLine($"{website.SiteUrl.AbsoluteUri} ({website.PageContentsSize}KB) = {website.LoadTime}ms");
		}
	}
}