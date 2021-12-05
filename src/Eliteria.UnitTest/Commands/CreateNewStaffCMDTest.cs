using Eliteria.Command;
using NUnit.Framework;

namespace Eliteria.UnitTest
{
    class CreateNewStaffCMDTest
    {
        [TestCase(null, "123456789", "123456789", "0123456789", "TP.HCM", false)]
        [TestCase("LE THANH DAN", "", "123456789", "0123456789", "TP.HCM", false)]
        [TestCase("LE THANH DAN", "123456789", null, "0123456789", "TP.HCM", false)]
        [TestCase("LE THANH DAN", "123456789", "123456789", null, "TP.HCM", false)]
        [TestCase("LE THANH DAN", "123456789", "123456789", "23232323", "TP.HCM", false)]
        [TestCase("LE THANH DAN", "123456789", "123456789", "0123456789", "", false)]
        [TestCase("LE THANH DAN", "123456789", "123456789", "0123456789", "TP.HCM", true)]
        public void Validation_ReturnTrueForValidInfo(string name, string iden, string pass, string phone, string addr, bool expected)
        {
            // Act
            bool result = CreateNewStaffCMD.Validation(name, iden, pass, phone, addr);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
