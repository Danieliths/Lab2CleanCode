using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculator
{
	public class Program
	{
		static void Main()
		{
			//TODO FIXA EN PRINT CLASS SOM PRINTAR RESULTATET, SKA EJ RETURNERA EN STRING
			var calculator = new Calculator();
			var result = calculator.CalculateTollFee(Environment.CurrentDirectory + "../../../../testData.txt");
			Console.WriteLine(result);		
			Console.ReadKey();
		}
	}
}
