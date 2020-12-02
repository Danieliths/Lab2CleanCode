using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TollFeeCalculator;

namespace TollFeeCalculatorTest
{
	[TestClass]
	public class UnitTest
	{

		//13: string indata = System.IO.File.ReadAllText(inputFile); // felhantering
		[TestMethod]
		public void ReadFromDirectoryTest()
		{
			//Arrange
			string wrongDirectory = "adfasfasfaf.txt";
			string emptyString = "";
			//Act
			//Assert
			Assert.ThrowsException<FileNotFoundException>(() => Program.run(wrongDirectory));
			Assert.ThrowsException<ArgumentException>(() => Program.run(emptyString));
		}

		//DateTime[] dates = new DateTime[dateStrings.Length - 1]; // tar bort sista datumet
		[TestMethod]
		public void DateTimeParseExceptionTest()
		{
			//Arrange
			Program program = new Program();
			var expected = ""; //TODO
			var testString = "2020-06-30 00:05, 2020-06-30 06:34";
			var wrongTextToDateTimeParse = "sdfgsgs";
			//Act
			var actual = program.GetDatesFromFile(testString);
			//Assert
			Assert.ThrowsException<FormatException>(() => program.GetDatesFromFile(wrongTextToDateTimeParse));
			Assert.ThrowsException<NullReferenceException>(() => program.GetDatesFromFile(null));
		}

		[TestMethod]
		public void DateTimeParseTest()
		{
			//Arrange
			Program program = new Program();
			var testString = "2020-06-30 00:05, 2020-06-30 06:34";
			var expected = new DateTime[] {
				DateTime.Parse("2020-06-30 00:05"),
				DateTime.Parse("2020-06-30 06:34")
			};
			//Act
			var actual = program.GetDatesFromFile(testString);
			//Assert
			CollectionAssert.AreEqual(expected, actual);
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
