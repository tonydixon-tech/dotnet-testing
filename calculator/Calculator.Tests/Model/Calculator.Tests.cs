using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MoneyExchangeRatePkg;


namespace CalculatorPkg.Tests
{
    [TestFixture]
    public class Calculator_Tests
    {

        private IUSD_CLP_ExchangeRateFeed prvGetMockExchangeRateFeed()
        {
            Mock<IUSD_CLP_ExchangeRateFeed> mockObject = new Mock<IUSD_CLP_ExchangeRateFeed>();
            mockObject.Setup(m => m.getActualUSDValue()).Returns(500);
            return mockObject.Object;
        }

        // Step 7. Add the test methods for each test case
        [Test(Description = "Divide 9 by 3. Expected result is 3.")]
        public void TC1_Divide9By3()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 3);
            int expectedResult = 3;

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test(Description = "Divide any number by zero. Should throw an System.DivideByZeroException exception.")]
        public void TC2_DivideByZero()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            // Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(9, 0));
        }

        [Test(Description = "Convert 1 USD to CLP. Expected result is 500.")]
        public void TC3_ConvertUSDtoCLPTest()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.ConvertUSDtoCLP(1);
            int expectedResult = 500;

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [TestCase(100, 75, 175, Description = "Add two numbers: 100 and 75, expect 175")]
        [TestCase(100, -75, 25, Description = "Add two numbers: 100 and -75, expect 25")]
        [TestCase(-100, 75, -25, Description = "Add two numbers: -100 and 75, expect -25")]
        [TestCase(-100, -100, -200, Description = "Add two numbers: -100 and -100, expect -200")]
        public void TC4_AddTwoNumbers(int param1, int param2, int expected)
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Add(param1, param2);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase(100, 75, 7500, Description = "Multiply two numbers: 100 and 75, expect 7500")]
        [TestCase(100, -75, -7500, Description = "Multiply two numbers: 100 and -75, expect -7500")]
        [TestCase(-100, 75, -7500, Description = "Multiply two numbers: -100 and 75, expect -7500")]
        [TestCase(-100, -100, 10000, Description = "Multiply two numbers: -100 and -100, expect -10000")]
        public void TC5_MultiplyTwoNumbers(int param1, int param2, int expected)
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Multiply(param1, param2);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase(5, 5, 0, Description = "Subtract 5 from 5, expect 0")]
        [TestCase(25, 5, 20, Description = "Subtract 5 from 25, expect 20")]
        [TestCase(5, 25, -20, Description = "Subtract 25 from 5, expect -20")]
        public void TC6_SubtractTwoNumbers(int param1, int param2, int expected)
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Subtract(param1, param2);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expected));
        }
    }
}