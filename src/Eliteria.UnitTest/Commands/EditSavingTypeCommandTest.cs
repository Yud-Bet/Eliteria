using Eliteria.Command;
using NUnit.Framework;

namespace Eliteria.UnitTest
{
    class EditSavingTypeCommandTest
    {
        [TestCase("0", "0.55", 90, 0.55f, false)]
        [TestCase("", "0.55", 90, 0.55f, false)]
        [TestCase("90", "0", 90, 0.55f, false)]
        [TestCase("90", "", 90, 0.55f, false)]
        [TestCase("90", "0.55", 90, 0.55f, false)]
        [TestCase("90", "0.55", 60, 0.2f, true)]
        [TestCase("90", "0.55", 90, 0.2f, true)]
        public void IsFilledOutValidInfo(string minDays2Widthdraw, string interestRate, int oldMinDays2Widthdraw, float oldInterestRate, bool expected)
        {
            // Act
            bool result = EditSavingTypeCommand.IsFilledOutValidInfo(minDays2Widthdraw, interestRate, oldMinDays2Widthdraw, oldInterestRate);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
