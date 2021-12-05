using Eliteria.DataAccess;
using Eliteria.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Configuration;

namespace Eliteria.UnitTest
{
    class DALoginTest
    {
        [Test]
        public void Login_WithCorrectPasswordForExistingUsername_ReturnAccountForCorrectUsername()
        {
            // Arrange
            string username = "1";
            string password = "1";

            Account acc = new Account { Address = "Địa chỉ 1", Birthdate = new DateTime(1980, 2, 11), Email = "khachhang1@gmail.com", ID= "202234046", Password="1", PhoneNum = "0902030422", Position = 2, Sex = true, StaffID = 1, StaffName = "Nhân viên 1" };
            // Act
            Account result = DALogin.Execute(username, password).Result;
            // Assert
            var accJson = JsonConvert.SerializeObject(acc);
            var resultJson = JsonConvert.SerializeObject(result);

            Assert.AreEqual(accJson, resultJson);
        }

        [Test]
        public void Login_WithWrongPasswordForExistingUsername_ReturnAccountForCorrectUsername()
        {
            // Arrange
            string username = "1";
            string password = "3";

            Account acc = null;
            // Act
            Account result = DALogin.Execute(username, password).Result;
            // Assert
            var accJson = JsonConvert.SerializeObject(acc);
            var resultJson = JsonConvert.SerializeObject(result);

            Assert.AreEqual(accJson, resultJson);
        }
    }
}
