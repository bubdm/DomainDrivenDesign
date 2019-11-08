using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joska.DomainDrivenDesign.Common.Tests
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void EqualsPositiveTest()
        {
            var a = new TestValueObject(1, 2, "test");
            var b = new TestValueObject(1, 2, "test");
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void EqualsNegativeTest()
        {
            var a = new TestValueObject(1, 2, "test");
            var b = new TestValueObject(500, 100, "test");
            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            var a = new TestValueObject(1, 2, "test");
            var b = new TestValueObject(1, 2, "test");
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}