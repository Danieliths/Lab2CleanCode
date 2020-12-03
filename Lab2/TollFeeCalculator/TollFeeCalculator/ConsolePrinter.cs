using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
	public class ConsolePrinter
	{
		public void PrintTollCost(int total)
		{
			Console.Write("The total fee for the inputfile is " + total);
		}
	}
}
