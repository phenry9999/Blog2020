using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace CovidDataExtract
{
	public class QuebecPublicHealthCovidCasesWebPage
	{
		public static string WebPageUrl = "https://www.inspq.qc.ca/covid-19/donnees";

		public static string ConfirmedCasesGraphId = "evolutionHospitalisations";
		public static string ConfirmedCasesGraphEllipseLocator = @$"//div[@id='{ConfirmedCasesGraphId}']//*[contains(@class,'highcharts-exporting-group')]";
		public static string DownloadCsvDataFile = "//*[text()='Télécharger les données en format CSV']";
		public static string DownloadedCsvDataFilename = "chart.csv";

		//not used at this time, should delete these if still unused later
		public static string HospitalizationsSectionLocator = "//span[text()='3 - Hospitalisations']";
		public static string EndOfPageId = "footer";


		public void DownloadDataFile()
		{
			//easy to find Windows Documents path, a bit more work for Downloads (you'd think it would be easy eh?)
			//just find Documents, then replace with Downloads and concatenate csv filename
			string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("Documents", "Downloads");
			string covidDataFilePath = Path.Combine(downloadsPath, QuebecPublicHealthCovidCasesWebPage.DownloadedCsvDataFilename);
			string renamedCovidDataFilename = Path.Combine(downloadsPath, "CovidDataFile." + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".csv");

			var chromeOptions = new ChromeOptions();
			chromeOptions.AddArguments(new List<string>() { "headless" });
			chromeOptions.AddArguments("--window-size=1024,1080");

			//these are required to download files when using headless, this will behave more like a function call
			//if you want to see what the browser\Selenium is doing, you can comment the headless option part above
			chromeOptions.AddArguments(new List<string>() { "download.default_directory", downloadsPath });
			chromeOptions.AddArguments("--disable-web-security");
			chromeOptions.AddArguments("--allow-running-insecure-content");

			//using this causes a problem with downloading the file, I'm not sure where it goes when Selenium is headless, 
			//you might be able to explicitly set the download folder in ChromeOptions and then pick it up down below in the same path, 
			//but I don't know where you will run this from, so I can't do this right now
			ChromeDriver driver = new ChromeDriver(chromeOptions);

			var settingForHeadlessDownloads = new Dictionary<string, object>
			{
				{ "behavior", "allow" },
				{ "downloadPath",downloadsPath }
			};
			driver.ExecuteChromeCommand("Page.setDownloadBehavior", settingForHeadlessDownloads);

			try
			{
				//goto the main page
				driver.Navigate().GoToUrl(QuebecPublicHealthCovidCasesWebPage.WebPageUrl);

				//scroll to the confirmed cases chart
				var confirmedCasesGraphElement = driver.FindElement(By.Id(QuebecPublicHealthCovidCasesWebPage.ConfirmedCasesGraphId));
				((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", confirmedCasesGraphElement);


				//finding out when the data is finished dynamically loading
				new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='evolutionHospitalisations']//*[name()='svg']")));

				//click on the ellipsed to see the download csv option and click it
				IWebElement confirmedCasesGraphEllipse = driver.FindElement(By.XPath(QuebecPublicHealthCovidCasesWebPage.ConfirmedCasesGraphEllipseLocator));
				confirmedCasesGraphEllipse.Click();

				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath(QuebecPublicHealthCovidCasesWebPage.DownloadCsvDataFile)));
				//IWebElement downloadCsvFile = WebDriverExtensions.FindElement(driver, By.XPath(QuebecPublicHealthCovidCasesWebPage.DownloadCsvDataFile), 30);
				IWebElement downloadCsvFile = wait.FindElement(By.XPath(QuebecPublicHealthCovidCasesWebPage.DownloadCsvDataFile));
				downloadCsvFile.Click();

				//before closing down the browser, lets give the file a bit of time to complete
				bool fileFound = DownloadDataFile(covidDataFilePath);

				ReportDataDownladStatus(covidDataFilePath, renamedCovidDataFilename, fileFound);
			}
			finally
			{
				Console.WriteLine("Just a sec...closing Selenium Chrome web driver is slow, but it should close everything");
				driver.Close();
				driver.Dispose();
				driver.Quit();
			}
		}

		private static void ReportDataDownladStatus(string covidDataFilePath, string renamedCovidDataFilename, bool fileFound)
		{
			if (fileFound)
			{
				FileInfo covidDataFileInfo = new FileInfo(covidDataFilePath);
				string covidDataFileDirectory = Path.GetDirectoryName(covidDataFilePath);
				if (File.Exists(renamedCovidDataFilename))
				{
					File.Delete(renamedCovidDataFilename);
				}

				File.Move(covidDataFilePath, renamedCovidDataFilename);
				Console.WriteLine($"Covid data file ready for use = {renamedCovidDataFilename}");
			}
			else
			{
				Console.WriteLine("COVID data file NOT found");
			}
		}

		private static bool DownloadDataFile(string covidDataFilePath)
		{
			bool fileFound = false;

			int timeoutCount = 0;
			int maxTimeoutCount = 40;
			while (!fileFound && timeoutCount < maxTimeoutCount)
			{
				if (!File.Exists(covidDataFilePath))
				{
					timeoutCount++;
					Thread.Sleep(250);  //let's give the browser time to download the file before we give up on it
				}
				else
				{
					fileFound = true;
					break;
				}
			}

			return fileFound;
		}
	}
}
