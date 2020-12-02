using System;

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

		static int TotalFeeCost(DateTime[] d)
		{
			int fee = 0;
			DateTime si = d[0]; //Starting interval
			foreach (var d2 in d)
			{
				long diffInMinutes = (d2 - si).Minutes;
				if (diffInMinutes > 60)
				{
					fee += TollFeePass(d2);
					si = d2;
				}
				else
				{
					fee += Math.Max(TollFeePass(d2), TollFeePass(si));
				}
			}
			return Math.Max(fee, 60);
		}

		static int TollFeePass(DateTime d)
		{
			if (free(d)) return 0;
			int hour = d.Hour;
			int minute = d.Minute;
			if (hour == 6 && minute >= 0 && minute <= 29) return 8;
			else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
			else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
			else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
			else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
			else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
			else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
			else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
			else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
			else return 0;
		}
		//Gets free dates
		static bool free(DateTime day)
		{
			return (int)day.DayOfWeek == 5 || (int)day.DayOfWeek == 6 || day.Month == 7;
		}
	}
}
