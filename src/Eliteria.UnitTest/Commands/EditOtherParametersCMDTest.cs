using Eliteria.Command;
using NUnit.Framework;

namespace Eliteria.UnitTest
{
    class EditOtherParametersCMDTest
    {
        [TestCase(0.0, 0.0, false)]
        [TestCase(1, 0.0, false)]
        [TestCase(1, 1, true)]
        public void IsFilledOut_ReturnTrueForValidInfo(decimal MinInitDeposit, decimal MinDepositAmount, bool expected)
        {
            // Act
            bool result = EditOtherParametersCMD.IsFilledOut(MinInitDeposit, MinDepositAmount);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
