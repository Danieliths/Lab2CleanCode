using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculator
{
	public class Program
	{
		static void Main()
		{
			run(Environment.CurrentDirectory + "../../../../testData.txt");
		}

		public static void run(String inputFile)
		{
			string indata;
			
			Program program = new Program();
			var dates = program.GetDatesFromFile(inputFile);
			Console.Write("The total fee for the inputfile is" + TotalFeeCost(dates));
		}

		public string ReadFromFile(string path)
        {
			string indata;
			try
			{
				indata = System.IO.File.ReadAllText(path);
				return indata;
			}
			catch (Exception)
			{
				return "Could not read file.";
			}
		}

		public DateTime[] GetDatesFromFile(string input)
		{
			String[] dateStrings = input.Split(", ");
			DateTime[] dates = new DateTime[dateStrings.Length];
			for (int i = 0; i < dates.Length; i++)
			{
                try
                {
					dates[i] = DateTime.ParseExact(dateStrings[i], "yyyy-MM-dd HH:mm", null);          
                }
                catch (Exception)
                {
					dates[i] = DateTime.MinValue;
                }
			}
			return dates;
		}

		public static int TotalFeeCost(DateTime[] d)
		{
			int dailyFee = 0;
			int feePaidThisHour = 0;
			int totalFee = 0;

			DateTime si = d[0]; //Starting interval
			var program = new Program();
			var datesPerDay = SortDatesPerDay(d.ToList());

            foreach (var date in datesPerDay)
            {				
				foreach (var d2 in date)
				{
					long diffInMinutes = program.DifferenceInMinutes(si, d2);
					if (diffInMinutes > 60)
					{
						feePaidThisHour = TollFeePass(d2);
						dailyFee += TollFeePass(d2);
						si = d2;
					}
					else
					{
						var feeToAdd = program.AddDifferenceBetweenTolls(TollFeePass(d2), feePaidThisHour);
						feePaidThisHour += feeToAdd;
						dailyFee += feeToAdd;
					}
				}
				totalFee += Math.Min(dailyFee, 60);
				dailyFee = 0;
			}

			return totalFee;
		}

        private static List<List<DateTime>> SortDatesPerDay(List<DateTime> inputDates)
        {
			var dates = new List<List<DateTime>>();
			inputDates.Sort();
			dates = inputDates.GroupBy(x => x.Day).Select(a => a.ToList()).ToList();
			return dates;
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

		public static int TollFeePass(DateTime d)
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
		public static bool free(DateTime day)
		{
			return (int)day.DayOfWeek == 0 || (int)day.DayOfWeek == 6 || day.Month == 7;
		}
	}
}
