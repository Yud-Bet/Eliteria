using Eliteria.Command;
using NUnit.Framework;
using System;

namespace Eliteria.UnitTest
{
    class AddNewSavingTypeCommandTest
    {
        [TestCase(null, 1, 0.5f, 100, "12/1/2021", "<=", false)]
        [TestCase("LE THANH DAN", 0, 0.5f, 100, "12/1/2021", "<=", false)]
        [TestCase("LE THANH DAN", 1, 0.0f, 100, "12/1/2021", "<=", false)]
        [TestCase("LE THANH DAN", 1, 0.5f, 0, "12/1/2021", "<=", false)]
        [TestCase("LE THANH DAN", 1, 0.5f, 100, null, "<=", false)]
        [TestCase("LE THANH DAN", 1, 0.5f, 100, "12/1/2021", null, false)]
        [TestCase("LE THANH DAN", 1, 0.5f, 100, "12/1/2021", "<=", true)]
        public void IsFilledOut_ReturnTrueForValidInfo(string name, int period, float interestRate, int minDays2Widthdraw, string effectiveDate, string widthdrawRules, bool expected)
        {
            // Arrange
            bool result = false;
            if (effectiveDate != null)
            {
                DateTime effDate = DateTime.Parse(effectiveDate);

                // Act
                result = AddNewSavingTypeCommand.IsFilledOut(name, period, interestRate, minDays2Widthdraw, effDate, widthdrawRules);
            }

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
