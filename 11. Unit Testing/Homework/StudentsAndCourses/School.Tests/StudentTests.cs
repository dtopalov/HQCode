namespace School.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        private Student validTestStudent = new Student("Ivan", "Ivanov");

        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException))]
        public void ArgumentExceptionShouldBeThrownIfFirstNameIsNull()
        {
            Student testStudent = new Student(null, "Ivanov");
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException))]
        public void ArgumentExceptionShouldBeThrownIfFirstNameIsEmpty()
        {
            Student testStudent = new Student(string.Empty, "Ivanov");
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException))]
        public void ArgumentExceptionShouldBeThrownIfLastNameIsNull()
        {
            Student testStudent = new Student("Ivan", null);
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException))]
        public void ArgumentExceptionShouldBeThrownIfLastNameIsEmpty()
        {
            Student testStudent = new Student("Ivan", string.Empty);
        }

        [TestMethod]
        public void StudentNameShouldBeCorrectWhenValidArgumentsArePassed()
        {
            Student testStudent = this.validTestStudent;
            Assert.AreEqual("Ivan Ivanov", testStudent.Name, "Name should be composed of first name, space, and last name");
        }

        [TestMethod]
        public void StudentShouldBeCreatedWithExpectedPropertiesWhenValidArgumentsArePassed()
        {
            Student testStudent = validTestStudent;
            Assert.AreEqual("Ivan", testStudent.FirstName);
            Assert.AreEqual("Ivanov", testStudent.LastName);
            Assert.AreEqual(0, testStudent.Courses.Count, "Initially courses is an empty list");
            Assert.IsTrue(10000 <= testStudent.UniqueNumber && testStudent.UniqueNumber <= 99999, "Unique number must be in the range [10000, 99999]");
        }

        [TestMethod]
        public void StudentUniqueNumberMustBeDifferentForAllDifferentInstances()
        {
            int testStudentsCount = 1000;
            int[] uniqueStudentNumbers = new int[testStudentsCount];
            for (int i = 0; i < testStudentsCount; i++)
            {
                Student testStudent = new Student("Ivan", "Ivanov");
                uniqueStudentNumbers[i] = testStudent.UniqueNumber;
            }
            Array.Sort(uniqueStudentNumbers);
            for (int i = 1; i < uniqueStudentNumbers.Length; i++)
            {
                Assert.AreNotEqual(
                    uniqueStudentNumbers[i],
                    uniqueStudentNumbers[i - 1],
                    "Student numbers should be unique");
            }
        }

        [TestMethod]
        public void WhenStudentSignsACourseTheCourseShouldAppearInCoursesListAndStudentInCoursesStudentList()
        {
            Student testStudent = this.validTestStudent;
            Course testCourse = new Course("TestCourse");
            testStudent.SignCourse(testCourse);
            Assert.IsTrue(testStudent.Courses.Contains(testCourse), "Signed course should be added to the list of courses");
            Assert.IsTrue(testCourse.StudentsList.Contains(testStudent), "Signed student should be added to the list of students");
        }

        [TestMethod]
        public void WhenStudentUnsignsACourseTheCourseShouldBeRemovedFromTheCoursesListAndTheStudentFromTheCourseStudentList()
        {
            Student testStudent = this.validTestStudent;
            Course testCourse = new Course("TestCourse");
            testStudent.SignCourse(testCourse);
            Assert.IsTrue(testStudent.Courses.Contains(testCourse), "Signed course should be added to the list of courses");
            testStudent.UnsignCourse(testCourse);
            Assert.IsFalse(testStudent.Courses.Contains(testCourse), "Unsigned course should be removed from the list of courses");
            Assert.IsFalse(testCourse.StudentsList.Contains(testStudent), "Unsigned student should be removed from the list of students");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToTheSignCourseMethod()
        {
            Student testStudent = validTestStudent;
            testStudent.SignCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToTheUnsignCourseMethod()
        {
            Student testStudent = validTestStudent;
            testStudent.UnsignCourse(null);
        }
    }
}
