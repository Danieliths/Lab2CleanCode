using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public class Calculator
    {
		public int CalculateTollFee(string path)
		{
			var fileReader = new FileReader();
			var file = fileReader.Read(path);
			var parser = new DateTimeParser();

			var dates = parser.ParseDatesFromString(file);
			var sortedDates = parser.SortDatesPerDay(dates);

			return TotalFeeCost(sortedDates);
		}

		public int TotalFeeCost(List<List<DateTime>> d)
		{
			int dailyFee = 0;
			int feePaidThisHour = 0;
			int totalFee = 0;

			var program = new Program();
			DateTime si = d[0][0]; //Starting interval

			foreach (var date in d)
			{
				foreach (var d2 in date)
				{
					long diffInMinutes = DifferenceInMinutes(si, d2);
					if (diffInMinutes > 60)
					{
						feePaidThisHour = TollFeePass(d2);
						dailyFee += TollFeePass(d2);
						si = d2;
					}
					else
					{
						var feeToAdd = AddDifferenceBetweenTolls(TollFeePass(d2), feePaidThisHour);
						feePaidThisHour += feeToAdd;
						dailyFee += feeToAdd;
					}
				}
				totalFee += Math.Min(dailyFee, 60);
				dailyFee = 0;
			}

			return totalFee;
		}
		public int DifferenceInMinutes(DateTime firstDate, DateTime secondDate)
		{
			return (int)(secondDate - firstDate).TotalMinutes;
		}

		public int AddDifferenceBetweenTolls(int firstFee, int secondFee)
		{
			return (Math.Max(firstFee, secondFee) - Math.Min(firstFee, secondFee));
		}

		public string CreateOutputString(int total)
		{
			return "The total fee for the inputfile is " + total;
		}

		public int TollFeePass(DateTime d)
		{
			if (free(d)) return 0;
			int hour = d.Hour;
			int minute = d.Minute;
			if (hour == 6 && minute >= 0 && minute <= 29) return 8;
			else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
			else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
			else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
			else if (hour >= 8 && hour <= 14 && minute >= 00 && minute <= 59) return 8;
			else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
			else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
			else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
			else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
			else return 0;
		}

		//Gets free dates
		public bool free(DateTime day)
		{
			return (int)day.DayOfWeek == 0 || (int)day.DayOfWeek == 6 || day.Month == 7;
		}
	}
}
