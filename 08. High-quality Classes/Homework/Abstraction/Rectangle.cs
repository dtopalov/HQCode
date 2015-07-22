namespace Abstraction
{
    using System;

    internal class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Width must be a positive number</exception>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width " + "must be a positive number");
                }

                this.width = value;
            }
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Height must be a positive number</exception>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height " + "must be a positive number");
                }

                this.height = value;
            }
        }

        internal override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        internal override double CalcSurface()
        {
            double area = this.Width * this.Height;
            return area;
        }
    }
}
