using System;
using System.Security.Policy;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTests
{
	[TestClass]
	public class CalculatorTests
	{
		static SalaryCalculator sc = null;
		decimal decimalHourlyWageValue = 48.08M;
		decimal decimalAnnualSalaryValue = 100006.40M;

		[ClassInitialize]
		public static void TestFixtureSetup(TestContext testContext)
		{
			sc = new SalaryCalculator();
		}

		[ClassCleanup]
		public static void TestFixtureCleanup()
		{
			sc = null;
		}


		[TestMethod]
		public void AnnualSalaryCalculation_GivenRoundConsultingRate_ThenRoundSalaryValue()
		{
			//arrange

			//act
			decimal annualSalary = sc.GetAnnualSalary(50);

			//assert
			Assert.AreEqual(104000, annualSalary, "You didn't get the right value for the annual salary calculation");
		}

		[TestMethod]
		public void AnnualSalaryCalculation_GivenDecimalValuedConsultingRate_ThenDecimalSalaryValue()
		{
			//arrange

			//act
			decimal annualSalary = sc.GetAnnualSalary(decimalHourlyWageValue);

			//assert
			Assert.AreEqual(decimalAnnualSalaryValue, annualSalary, "You didn't get the right value for the annual salary calculation");
		}

		[TestMethod]
		public void HourlySalaryCalculation_GivenRoundAnnualRate_ThenRoundHourlyValue()
		{
			//arr

			//act
			decimal hourlyWage = sc.GetHourlyWage(104000);

			//ass
			Assert.AreEqual(50, hourlyWage);
		}

		[TestMethod]
		public void HourlySalaryCalculation_GivenDecimalAnnualRate_ThenDecimalHourlyValue()
		{
			//arr

			//act
			decimal hourlyWage = sc.GetHourlyWage(decimalAnnualSalaryValue);

			//ass
			Assert.AreEqual(decimalHourlyWageValue, hourlyWage);
		}
	}
}
