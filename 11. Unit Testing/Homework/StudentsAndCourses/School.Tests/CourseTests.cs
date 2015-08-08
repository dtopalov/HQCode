namespace School.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        private const int MaximumNumberOfStudentsInACourse = 29;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowAnArgumentExceptionIfTitleIsNull()
        {
            Course testCourse = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowAnArgumentExceptionIfTitleIsEmpty()
        {
            Course testCourse = new Course(string.Empty);
        }

        [TestMethod]
        public void CourseListOfStudentsAndStudentListOfCoursesShouldBeUpdatedProperlyWhenANewStudentIsAdded()
        {
            Course testCourse = new Course("TestCourse");
            Student testStudent = new Student("First", "Last");
            testCourse.AddStudent(testStudent);

            Assert.IsTrue(testCourse.StudentsList.Contains(testStudent), "List of students should contain the added student");
            Assert.IsTrue(testStudent.Courses.Contains(testCourse), "List of courses should contain the added course");
        }

        [TestMethod]
        public void CourseListOfStudentsAndStudentListOfCoursesShouldBeUpdatedProperlyWhenAStudentIsRemoved()
        {
            Course testCourse = new Course("TestCourse");
            Student testStudent = new Student("First", "Last");
            testCourse.AddStudent(testStudent);
            testCourse.RemoveStudent(testStudent);

            Assert.IsFalse(testCourse.StudentsList.Contains(testStudent), "The removed student should not be in the list");
            Assert.IsFalse(testStudent.Courses.Contains(testCourse), "The course should not be in the list");
        }

        [TestMethod]
        public void CourseTitleShouldBeSetCorrectlyWhenValidArgumentIsPassed()
        {
            Course testCourse = new Course("Valid Title");
            Assert.AreEqual("Valid Title", testCourse.Title, "Valid title should be set correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CourseShouldThrowAnApplicationExceptionWhenNumberOfSignedStudentsExceedsTheLimit()
        {
            Course testCourse = new Course("Test");
            for (int i = 0; i <= MaximumNumberOfStudentsInACourse; i++)
            {
                Student testStudent = new Student("valid", "valid");
                testCourse.AddStudent(testStudent);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CourseShouldThrowAnApplicationExceptionWhenTheSameStudentIsAddedMoreThanOnce()
        {
            Course testCourse = new Course("Test");
            Student testStudent = new Student("a", "b");
            testCourse.AddStudent(testStudent);
            testCourse.AddStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToAddStudentMethod()
        {
            Course testCourse = new Course("Test");
            testCourse.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToRemoveStudentMethod()
        {
            Course testCourse = new Course("Test");
            testCourse.RemoveStudent(null);
        }
    }
}
