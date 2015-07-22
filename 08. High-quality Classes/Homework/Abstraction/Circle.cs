namespace Abstraction
{
    using System;

    internal class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Radius must be a positive number</exception>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius " + "must be a positive number");
                }

                this.radius = value;
            }
        }

        internal override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        internal override double CalcSurface()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }
}
