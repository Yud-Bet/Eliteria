using Eliteria.Command;
using NUnit.Framework;

namespace Eliteria.UnitTest
{
    class ModifyStaffInfoCMDTest
    {
        [TestCase(null, null, null, false)]
        [TestCase("1", null, null, false)]
        [TestCase("1", "1", null, false)]
        [TestCase("1", "1", "1", false)]
        [TestCase("1", "0836253546", "1", true)]
        public void Validation_ReturnTrueForValidInfo(string name, string phoneNum, string addr, bool expected)
        {
            // Act
            bool result = ModifyStaffInfoCMD.Validation(name, phoneNum, addr);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
