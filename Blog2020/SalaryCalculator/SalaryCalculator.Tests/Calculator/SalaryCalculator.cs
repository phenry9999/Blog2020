using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class SalaryCalculator
	{
		private const int hoursInYear = 52 * (5 * 8);       //2080 = weeks in a year * days a week * hours a day

		/// <summary>
		/// To get annual, multiply hourly by 2080
		/// </summary>
		/// <param name="hourlyWage"></param>
		/// <returns></returns>
		public decimal GetAnnualSalary(decimal hourlyWage)
		{
			decimal annualSalary = hoursInYear * hourlyWage;
			return annualSalary;
		}

		/// <summary>
		/// To get hourly, divide annual salary by 2080
		/// </summary>
		/// <param name="annualSalary"></param>
		/// <returns></returns>
		public decimal GetHourlyWage(decimal annualSalary) => annualSalary / hoursInYear;
	}
}
