using Microsoft.VisualStudio.TestTools.UnitTesting;
using TollFeeCalculator;
namespace TollFeeCalculatorUnitTest
{
	[TestClass]
	public class UnitTest
	{
		//13: string indata = System.IO.File.ReadAllText(inputFile); // felhantering
		[TestMethod]
		public void ReadFromDirectoryTest()
		{
			//Arrange
			
			string wrongDirectory = "";
			//Act

			//Assert
			Assert.ThrowsException(Program.run(wrongDirectory));
		}
		
		//DateTime[] dates = new DateTime[dateStrings.Length - 1]; // tar bort sista datumet
		[TestMethod]
		public void TestMethod2()
		{
			//Arrange

			//Act

			//Assert
		}

		//dates[i] = DateTime.Parse(dateStrings[i]); // felhantering
		[TestMethod]
		public void TestMethod3()
		{
			//Arrange

			//Act

			//Assert
		}

		//Console.Write("The total fee for the inputfile is" + TotalFeeCost(dates)); // sakna mellanslag
		[TestMethod]
		public void TestMethod4()
		{
			//Arrange

			//Act

			//Assert
		}

		//long diffInMinutes = (d2 - si).Minutes; // r�knar bara minuter inte timmar returnar alltid -59 - 59 s� aldrig �ver 60 TotalMinutes
		[TestMethod]
		public void TestMethod5()
		{
			//Arrange

			//Act

			//Assert
		}

		//fee += Math.Max(TollFeePass(d2), TollFeePass(si)); // l�gga till skillande inte b�da v�rdena
		[TestMethod]
		public void TestMethod6()
		{
			//Arrange

			//Act

			//Assert
		}

		//return Math.Max(fee, 60); // retunerar alltid 60 borde vara Min ist�llet+
		[TestMethod]
		public void TestMethod7()
		{
			//Arrange

			//Act

			//Assert
		}

		//else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8; // andra delen av statmentet �r fel
		//else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18; // skall vara f�r 1530 inte 1500 fel grejer som �r fuckade
		[TestMethod]
		public void TestMethod8()
		{
			//Arrange

			//Act

			//Assert
		}

		//return (int)day.DayOfWeek == 5 || (int)day.DayOfWeek == 6 || day.Month == 7; // s�ndag �r 0 och l�rdag �r 6
		[TestMethod]
		public void TestMethod9()
		{
			//Arrange

			//Act

			//Assert
		}
	}
}
