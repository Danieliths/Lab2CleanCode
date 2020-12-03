using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
	public class DateTimeParser
	{
		public List<DateTime> ParseDatesFromString(string input)
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
			return dates.ToList();
		}

		public List<List<DateTime>> SortDatesPerDay(List<DateTime> inputDates)
		{
			var dates = new List<List<DateTime>>();
			inputDates.Sort((x, y) => x.CompareTo(y));
			dates = inputDates.GroupBy(a => a.Date).Select(a => a.ToList()).ToList();
			return dates;
		}
	}
}
