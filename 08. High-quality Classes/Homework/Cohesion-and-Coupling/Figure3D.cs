namespace CohesionAndCoupling
{
    using System;

    internal class Figure3D : IDiagonalsCalculator2D, IDiagonalsCalculator3D
    {
        private double width;

        private double height;

        private double depth;

        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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
                if (!this.ValidateSide(value))
                {
                    throw new ArgumentOutOfRangeException("Width must be a " + "positive number");
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
                if (!this.ValidateSide(value))
                {
                    throw new ArgumentOutOfRangeException("Height must be a " + "positive number");
                }

                this.height = value;
            }
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Depth must be a positive number</exception>
        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (!this.ValidateSide(value))
                {
                    throw new ArgumentOutOfRangeException("Depth must be a " + "positive number");
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXyz()
        {
            double distance = CalcDistanceUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXy()
        {
            double distance = CalcDistanceUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXz()
        {
            double distance = CalcDistanceUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYz()
        {
            double distance = CalcDistanceUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }

        private bool ValidateSide(double number)
        {
            return number > 0;
        }
    }
}
