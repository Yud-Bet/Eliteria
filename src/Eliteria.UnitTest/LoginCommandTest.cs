using NUnit.Framework;
using Eliteria.Command;

namespace Eliteria.UnitTest
{
    public class LoginCommandTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2", "2", true)]
        public void FillValidation_ReturnTrueForValidInfo(string usr, string pas, bool expected)
        {
            //Arrange
            string username = usr;
            string password = pas;
            //Act
            bool result = LoginCommand.IsFilledOut(username, password);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}