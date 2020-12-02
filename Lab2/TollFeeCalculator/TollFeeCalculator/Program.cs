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
			// vi testar inte heller så att man inte kan få en kostnad över 60kr på en dag
			var calculator = new Calculator();
			var result = calculator.CalculateTollFee(Environment.CurrentDirectory + "../../../../testData.txt");
			Console.WriteLine(result);		// skriver just nu ut bara talet
			Console.ReadKey();
		}
	}
}
