using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RotatingWalkInMatrix.Tests
{
    using System.IO;
    using System.Text;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatrixShouldThrowAnArgumentOutOfRangeExceptionIfSizeIsNotGreaterThanZero()
        {
            Matrix testMatrix = new Matrix(0);
        }

        [TestMethod]
        public void MatrixShouldConsistOfOneCellWithValueOf1WhenSizeIs1()
        {
            Matrix testMatrix = new Matrix(1);
            Assert.AreEqual(1, testMatrix.Field[testMatrix.Field.GetLength(0) - 1, testMatrix.Field.GetLength(1) - 1]);
        }

        [TestMethod]
        public void MatrixToStringShouldProduceExpectedOutputForAValidMatrix()
        {
            Matrix testMatrix = new Matrix(5);
            StringBuilder expected = new StringBuilder();
            for (int i = 0; i < testMatrix.Field.GetLength(0); i++)
            {
                for (int j = 0; j < testMatrix.Field.GetLength(0); j++)
                {
                    expected.AppendFormat("{0,3}", testMatrix.Field[i, j]);
                }

                expected.Append(Environment.NewLine);
            }

            Assert.AreEqual(testMatrix.ToString(), expected.ToString());
        }
    }
}
