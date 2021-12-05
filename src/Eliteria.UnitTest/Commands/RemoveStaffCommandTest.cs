using Eliteria.Command;
using NUnit.Framework;

namespace Eliteria.UnitTest
{
    class RemoveStaffCommandTest
    {
        [TestCase(1, 1, true)]
        [TestCase(1, 2, false)]
        public void IsSelfDelete_ReturnTrueIfIsSelfDelete(int curId, int delId, bool expected)
        {
            // Act
            bool result = RemoveStaffCommand.IsSelfDelete(curId, delId);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
