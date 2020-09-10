using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FirstAsyncTest
{
	public class WebsiteData
	{
		readonly string httpPrefix = Uri.UriSchemeHttp + "://";

		public WebsiteData(string initialUrl)
		{
			if (!string.IsNullOrEmpty(initialUrl))
			{
				if (!initialUrl.ToLower().StartsWith(httpPrefix))
				{
					initialUrl = httpPrefix + initialUrl;
				}

				SiteUrl = new Uri(initialUrl);
			}
		}

		public Uri SiteUrl { get; set; }
		public string PageContents { get; set; }

		public long LoadTime { get; set; }

		public int PageContentsSize
		{
			get
			{
				int contentsSize = 0;

				if (!string.IsNullOrEmpty(PageContents))
				{
					contentsSize = PageContents.Length;
				}

				return contentsSize;
			}
		}
	}
}