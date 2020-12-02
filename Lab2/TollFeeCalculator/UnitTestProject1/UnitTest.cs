using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TollFeeCalculator;

namespace TollFeeCalculatorTest
{
    [TestClass]
    public class UnitTest
    {

        //1
        [TestMethod]
        public void ReadFromDirectoryTest()
        {
            //Arrange
            string emptyString = "";
            var program = new Program();

            //Act
            string expected = "2020-06-30 00:05";

            var actual = program.ReadFromFile(Environment.CurrentDirectory + "../../../../testDataTestFile.txt");
            var secondActual = program.ReadFromFile(emptyString);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Could not read file.", secondActual);
        }

        //2
        [TestMethod]
        public void DateTimeParseExceptionTest()
        {
            //Arrange
            Program program = new Program();
            var testString = "2020-06-30 j05, 20206-30 06:34, 2020-08-30 0989:39";
            var expected = new DateTime[] { DateTime.MinValue, DateTime.MinValue, DateTime.MinValue };

            //Act
            var actual = program.GetDatesFromFile(testString);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        //3
        [TestMethod]
        public void DateTimeCorrectArrayParseTest()
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

        //4
        [TestMethod]
        public void CreateOutputStringTest()
        {
            //Arrange
            var program = new Program();
            var excpected = "The total fee for the inputfile is 108";

            //Act
            var actual = program.CreateOutputString(108);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        //5
        [TestMethod]
        public void DifferenceInMinutesTest()
        {
            //Arrange
            var dates = new DateTime[]
            {
                DateTime.Parse("2020-09-30 07:00"),
                DateTime.Parse("2020-09-30 09:00")
            };
            var expected = 120;
            var program = new Program();

            //Act
            var actual = program.DifferenceInMinutes(dates[0], dates[1]);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //6
        [TestMethod]
        public void AddDifferenceBetweenTollsTest()
        {
            //Arrange
            var program = new Program();
            var excpected = 4;

            //Act
            var acutal = program.AddDifferenceBetweenTolls(4, 8);

            //Assert
            Assert.AreEqual(excpected, acutal);
        }

        //7
        [TestMethod]
        public void TotalFeeCostTest()
        {
            //Arrange
            var program = new Program();
            var dates = new DateTime[]
            {
                DateTime.Parse("2020-09-30 06:25"),
                DateTime.Parse("2020-09-30 06:55"),
                DateTime.Parse("2020-09-30 07:05")
            };
            var excpected = 18;

            //Act
            var acutal = Program.TotalFeeCost(dates);

            //Assert
            Assert.AreEqual(excpected, acutal);
        }

        //8
        [TestMethod]
        public void IncreaseMaxFeePerDayTest()
        {
            //Arrange
            var program = new Program();
            var dates = new DateTime[]
            {
                DateTime.Parse("2020-09-28 06:25"),
                DateTime.Parse("2020-09-28 06:55"),
                DateTime.Parse("2020-09-28 07:05"),
                DateTime.Parse("2020-09-28 15:30"),
                DateTime.Parse("2020-09-29 06:25"),
                DateTime.Parse("2020-09-29 06:55"),
                DateTime.Parse("2020-09-29 07:05"),
                DateTime.Parse("2020-09-29 15:30"),
                DateTime.Parse("2020-09-30 06:25"),
                DateTime.Parse("2020-09-30 06:55"),
                DateTime.Parse("2020-09-30 07:05"),
                DateTime.Parse("2020-09-30 15:30")
            };
            var excpected = 108;

            //Act
            var acutal = Program.TotalFeeCost(dates);

            //Assert
            Assert.AreEqual(excpected, acutal);
        }

        //9
        [TestMethod]
        public void TollFeeTest()
        {
            //Arrange
            var dates = new Dictionary<DateTime, int>()
            {
                { DateTime.Parse("2020-09-28 05:00"), 0 },
                { DateTime.Parse("2020-09-28 06:25"), 8  },
                { DateTime.Parse("2020-09-28 06:55"), 13  },
                { DateTime.Parse("2020-09-28 07:05"), 18  },
                { DateTime.Parse("2020-09-28 08:24"), 13  },
                { DateTime.Parse("2020-09-29 09:22"), 8  },
                { DateTime.Parse("2020-09-29 15:12"), 13  },
                { DateTime.Parse("2020-09-29 16:05"), 18  },
                { DateTime.Parse("2020-09-29 17:30"), 13  },
                { DateTime.Parse("2020-09-30 18:04"), 8 },
                { DateTime.Parse("2020-09-30 18:36"), 0 }
            };

            //Assert
            foreach (var date in dates)
            {
                Assert.AreEqual(date.Value, Program.TollFeePass(date.Key));
            }
        }

        //10
        [TestMethod]
        public void FreeDayTest()
        {
            //Arrange
            var dates = new Dictionary<DateTime, bool>()
            {
                { DateTime.Parse("2020-11-30 05:00"), false },
                { DateTime.Parse("2020-12-01 06:25"), false  },
                { DateTime.Parse("2020-12-02 06:55"), false  },
                { DateTime.Parse("2020-12-03 07:05"), false  },
                { DateTime.Parse("2020-12-04 08:24"), false  },
                { DateTime.Parse("2020-12-05 09:22"), true  },
                { DateTime.Parse("2020-12-06 15:12"), true  },
                { DateTime.Parse("2020-07-01 16:05"), true  },
                { DateTime.Parse("2020-01-01 16:05"), false  },
                { DateTime.Parse("2020-02-04 16:05"), false  },
                { DateTime.Parse("2020-03-03 16:05"), false  },
                { DateTime.Parse("2020-04-01 16:05"), false  },
                { DateTime.Parse("2020-05-01 16:05"), false },
                { DateTime.Parse("2020-06-01 16:05"), false  },
                { DateTime.Parse("2020-08-04 16:05"), false  },
                { DateTime.Parse("2020-09-01 16:05"), false  },
                { DateTime.Parse("2020-10-01 16:05"), false  },
            };

            //Assert
            foreach (var date in dates)
            {
                Assert.AreEqual(date.Value, Program.free(date.Key));
            }
        }
    }
}
