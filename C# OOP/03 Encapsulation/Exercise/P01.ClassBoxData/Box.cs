using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBoxData
{
    public class Box
    {
        private const int SIDE_MIN_VALUE = 0;
        private const string SIDE_ERROR_MESSAGE = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.ValidateSide(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                this.ValidateSide(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.ValidateSide(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            var surfaceArea = (2 * this.Length * this.Width) +
                              (2 * this.Length * this.Height) +
                              (2 * this.Width * this.Height);
            return surfaceArea;
        }

        public double CalculateLateralSurfaceArea()
        {
            var lateraSurfaceArea = (2 * this.Length * this.Height) +
                                    (2 * this.Width * this.Height);

            return lateraSurfaceArea;
        }

        public double CalculateVolume()
        {
            var volume = this.Length * this.Width * this.Height;

            return volume;
        }
        private void ValidateSide(double value, string sideName)
        {
            if (value <= SIDE_MIN_VALUE)
            {
                throw new ArgumentException(String.Format(SIDE_ERROR_MESSAGE, sideName));
            }
        }
    }
}
