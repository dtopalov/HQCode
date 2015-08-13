namespace RotatingWalkInMatrix
{
    using System;

    public class Cell
    {
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public static Cell operator +(Cell firstCell, Cell secondCell)
        {
            if (firstCell == null || secondCell == null)
            {
                throw new ArgumentNullException("Neither " + "operand cannot be null.");
            }

            return new Cell(firstCell.X + secondCell.X, firstCell.Y + secondCell.Y);
        }
    }
}
