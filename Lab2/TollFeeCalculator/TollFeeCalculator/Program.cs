using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculator
{
	public class Program
	{
		static void Main()
		{
			var calculator = new Calculator();
			var printer = new ConsolePrinter();
			var totalFeeToPay = calculator.CalculateTollFee(Environment.CurrentDirectory + "../../../../testData.txt");
			printer.PrintTollCost(totalFeeToPay);
			Console.ReadKey();
		}
	}
}
