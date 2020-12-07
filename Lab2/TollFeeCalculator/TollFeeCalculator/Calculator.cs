using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
	public class Calculator
	{
		private readonly DateTimeParser _dateTimeParser;
		private readonly FileReader _fileReader;

		public Calculator()
		{
			_dateTimeParser = new DateTimeParser();
			_fileReader = new FileReader();
		}

		public int CalculateTollFee(string path)
		{
			var file = _fileReader.Read(path);
			var dates = _dateTimeParser.ParseDatesFromString(file);
			var sortedDates = _dateTimeParser.SortDatesPerDay(dates);
			return TotalFeeCost(sortedDates);
		}

		public int TotalFeeCost(List<List<DateTime>> dates)
		{
			int dailyFee = 0;
			int feePaidThisHour = 0;
			int totalFee = 0;
			DateTime firstPassageThisHour = dates[0][0];
			foreach (var date in dates)
			{
				foreach (var tollPassage in date)
				{
					int differenceInMinutes = DifferenceInMinutes(firstPassageThisHour, tollPassage);
					if (differenceInMinutes > 60)
					{
						var costOfPassage = CostOfPassage(tollPassage);
						feePaidThisHour = costOfPassage;
						dailyFee += costOfPassage;
						firstPassageThisHour = tollPassage;
					}
					else
					{
						var feeToAdd = AddDifferenceBetweenTolls(CostOfPassage(tollPassage), feePaidThisHour);
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
			return Math.Max(firstFee, secondFee) - Math.Min(firstFee, secondFee);
		}

		public int CostOfPassage(DateTime date)
		{
			var timeOfPassage = DateTime.Parse(date.ToString("HH:mm"));
			if (IsDayFree(date))
				return 0;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("06:00")) < 0)
				return 0;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("06:30")) < 0)
				return 8;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("07:00")) < 0)
				return 13;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("08:00")) < 0)
				return 18;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("08:30")) < 0)
				return 13;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("15:00")) < 0)
				return 8;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("15:30")) < 0)
				return 13;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("17:00")) < 0)
				return 18;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("18:00")) < 0)
				return 13;
			else if (DateTime.Compare(timeOfPassage, DateTime.Parse("18:30")) < 0)
				return 8;
			else
				return 0;
		}
		bool IsDayFree(DateTime day)
		{
			return (int)day.DayOfWeek == 0 || (int)day.DayOfWeek == 6 || day.Month == 7;
		}
	}
}
