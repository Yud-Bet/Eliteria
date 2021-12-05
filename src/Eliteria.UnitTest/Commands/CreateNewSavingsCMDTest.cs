using Eliteria.Command;
using Eliteria.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Eliteria.UnitTest
{
    class CreateNewSavingsCMDTest
    {
        public void NewCustomerValidation_ReturnTrueForValidInfo(List<string> idList, string id, string name, string birthDay, string gender, string addr, string email, string phoneNum, string savingsType, string balance, decimal minInitAmount, bool expected)
        {
            // Act
            bool result = CreateNewSavingsCMD.NewCustomerValidation(idList, id, name, DateTime.Parse(birthDay), gender, addr, email, phoneNum, savingsType, balance, minInitAmount);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("Không thời hạn", "1000000", "10000", false)]
        public void OldCustomerValidation_WithNullSelectedAcc_ReturnTrueForValidInfo(string selectedSavingType, string balance, decimal minInitAmount, bool expected)
        {
            // Arrange
            SavingsAccount selectedAcc = null;

            // Act
            bool result = CreateNewSavingsCMD.OldCustomerValidation(selectedAcc, selectedSavingType, balance, minInitAmount);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("Không thời hạn", "1000000", "10000", true)]
        [TestCase(null, "1000000", "10000", false)]
        [TestCase("Không thời hạn", "", "10000", false)]
        [TestCase("Không thời hạn", "1000000", "20000000", false)]
        [TestCase("Không thời hạn", "100000000000000000000000000000", "10000", false)]
        public void OldCustomerValidation_WithNotNullSelectedAcc_ReturnTrueForValidInfo(string selectedSavingType, string balance, decimal minInitAmount, bool expected)
        {
            // Arrange
            SavingsAccount selectedAcc = new SavingsAccount { IdentificationNumber = "187889829"};

            // Act
            bool result = CreateNewSavingsCMD.OldCustomerValidation(selectedAcc, selectedSavingType, balance, minInitAmount);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("Không thời hạn", "1000000", "10000", false)]
        public void OldCustomerValidation_WithNullId_ReturnTrueForValidInfo(string selectedSavingType, string balance, decimal minInitAmount, bool expected)
        {
            // Arrange
            SavingsAccount selectedAcc = new SavingsAccount { IdentificationNumber = null };

            // Act
            bool result = CreateNewSavingsCMD.OldCustomerValidation(selectedAcc, selectedSavingType, balance, minInitAmount);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
