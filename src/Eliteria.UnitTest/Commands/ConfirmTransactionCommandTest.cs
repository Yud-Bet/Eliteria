using Eliteria.Command;
using Eliteria.Models;
using NUnit.Framework;

namespace Eliteria.UnitTest
{
    class ConfirmTransactionCommandTest
    {
        [Test]
        public void IsFilledOut_WithNullSelectedSavingsNTransMoneyIs1000000_ReturnTrueForValidInfo()
        {
            // Arange
            SavingsAccount selectedSavings = null;
            decimal transactionMoney = 1000000;

            bool expected = false;

            // Act
            bool result = ConfirmTransactionCommand.IsFilledOut(selectedSavings, transactionMoney.ToString());

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsFilledOut_WithNotNullSelectedSavingsNTransMoneyIsEmpty_ReturnTrueForValidInfo()
        {
            // Arange
            SavingsAccount selectedSavings = new SavingsAccount();
            string transactionMoney = "";

            bool expected = false;

            // Act
            bool result = ConfirmTransactionCommand.IsFilledOut(selectedSavings, transactionMoney);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsFilledOut_WithNotNullSelectedSavingsNTransMoneyIs1000000_ReturnTrueForValidInfo()
        {
            // Arange
            SavingsAccount selectedSavings = new SavingsAccount();
            string transactionMoney = "1000000";

            bool expected = true;

            // Act
            bool result = ConfirmTransactionCommand.IsFilledOut(selectedSavings, transactionMoney);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsFilledOut_WithNotNullSelectedSavingsNLargeTransMoney_ReturnTrueForValidInfo()
        {
            // Arange
            SavingsAccount selectedSavings = new SavingsAccount();
            string transactionMoney = "1000000000000000000000000000000000";

            bool expected = true;

            // Act
            bool result = ConfirmTransactionCommand.IsFilledOut(selectedSavings, transactionMoney);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
