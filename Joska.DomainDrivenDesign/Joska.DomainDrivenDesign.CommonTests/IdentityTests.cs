using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joska.DomainDrivenDesign.Common.Tests
{
    [TestClass]
    public class IdentityTests
    {

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void TestUnableToReset()
        {
            var id = new Identity<int>();
            id.Set(1);
            id.Set(2);
        }

        [TestMethod]
        public void TestEqualsNegative()
        {
            var id = new Identity<int>();
            id.Set(127);
            var id2 = new Identity<int>();
            id2.Set(255);
            Assert.AreNotEqual(id, id2);
        }

        [TestMethod]
        public void TestEqualsPositive()
        {
            var id = new Identity<int>();
            id.Set(127);
            var id2 = new Identity<int>();
            id2.Set(127);
            Assert.AreEqual(id, id2);
        }

        [TestMethod]
        public void TestEqualsPositiveOperator()
        {
            var id = new Identity<int>();
            id.Set(127);
            var id2 = new Identity<int>();
            id2.Set(127);
            Assert.IsTrue(id == id2);
        }

    }
}