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
					int diffInMinutes = DifferenceInMinutes(firstPassageThisHour, tollPassage);
					if (diffInMinutes > 60)
					{
						feePaidThisHour = TollFeePass(tollPassage);
						dailyFee += TollFeePass(tollPassage);
						firstPassageThisHour = tollPassage;
					}
					else
					{
						var feeToAdd = AddDifferenceBetweenTolls(TollFeePass(tollPassage), feePaidThisHour);
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

		public string CreateOutputString(int total)
		{
			return "The total fee for the inputfile is " + total;
		}

		public int TollFeePass(DateTime date)
		{
			if (free(date)) 
				return 0;
			//TODO om time är innan Parsen så retunera
			// dock vet jag inte om detta är snyggare än det andra krokbot men blir ganska överskådligt iaf
			var timeOfPassage = DateTime.Parse(date.ToString("HH:mm"));
			if (DateTime.Compare(timeOfPassage, DateTime.Parse("06:00")) < 0)
				return  0;
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

			//int hour = date.Hour;
			//int minute = date.Minute;
			//if (hour == 6 && minute >= 0 && minute <= 29) return 8;
			//else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
			//else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
			//else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
			//else if (hour >= 8 && hour <= 14 && minute >= 00 && minute <= 59) return 8;
			//else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
			//else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
			//else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
			//else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
			//else return 0;
		}

		public bool free(DateTime day)
		{
			return (int)day.DayOfWeek == 0 || (int)day.DayOfWeek == 6 || day.Month == 7;
		}
	}
}
