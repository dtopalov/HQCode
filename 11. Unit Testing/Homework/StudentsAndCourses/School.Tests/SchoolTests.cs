namespace School.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowAnArgumentOutOfRangeExceptionIfUniqueStudentNumberIsLessThan10000() => School.UniqueNumber = 9999;

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowAnArgumentOutOfRangeExceptionIfUniqueStudentNumberIsGreaterThan99999() => School.UniqueNumber = 100000;

        [TestMethod]
        public void SchoolShouldReturnCorrectUniqueIdWhenItIsSetCorrectly()
        {
            School.UniqueNumber = 10000;
            Assert.AreEqual(10000, School.UniqueNumber, "Unique number should be set correctly when valid");
        }
    }
}
