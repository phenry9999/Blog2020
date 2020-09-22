using System;
using System.Collections.Generic;

using System.Runtime.CompilerServices;


namespace CovidDataExtract
{
	public class Program
	{
		static void Main(string[] args)
		{
			QuebecPublicHealthCovidCasesWebPage covidData = new QuebecPublicHealthCovidCasesWebPage();
			covidData.DownloadDataFile();
		}
	}
}

