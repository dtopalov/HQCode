using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RotatingWalkInMatrix.Tests
{
    [TestClass]
    public class CellTests
    {
        private Cell firstCell = new Cell(1, 2);
        private Cell secondCell = new Cell(2, 1);

        [TestMethod]
        public void AddingTwoCellsShouldReturnANewCellWithProperValuesForXAndY()
        {
            Cell resultingCell = firstCell + secondCell;

            Assert.AreEqual(3, resultingCell.X, "resultingCell.X should be equal to firstCell.X + secondCell.X");
            Assert.AreEqual(3, resultingCell.Y, "resultingCell.Y should be equal to firstCell.Y + secondCell.Y");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingTwoCellsShouldThrowAnArgumentNullExceptionWhenEitherOfTheOperandsIsNull()
        {
            Cell test = this.firstCell + null;
        }
    }
}
