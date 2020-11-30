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

		//long diffInMinutes = (d2 - si).Minutes; // räknar bara minuter inte timmar returnar alltid -59 - 59 så aldrig över 60 TotalMinutes
		[TestMethod]
		public void TestMethod5()
		{
			//Arrange

			//Act

			//Assert
		}

		//fee += Math.Max(TollFeePass(d2), TollFeePass(si)); // lägga till skillande inte båda värdena
		[TestMethod]
		public void TestMethod6()
		{
			//Arrange

			//Act

			//Assert
		}

		//return Math.Max(fee, 60); // retunerar alltid 60 borde vara Min istället+
		[TestMethod]
		public void TestMethod7()
		{
			//Arrange

			//Act

			//Assert
		}

		//else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8; // andra delen av statmentet är fel
		//else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18; // skall vara får 1530 inte 1500 fel grejer som är fuckade
		[TestMethod]
		public void TestMethod8()
		{
			//Arrange

			//Act

			//Assert
		}

		//return (int)day.DayOfWeek == 5 || (int)day.DayOfWeek == 6 || day.Month == 7; // söndag är 0 och lördag är 6
		[TestMethod]
		public void TestMethod9()
		{
			//Arrange

			//Act

			//Assert
		}
	}
}
