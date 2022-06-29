using System.Collections.Generic;
using System.Linq;

namespace Class
{
    public class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }
        public Rectangle(double sideA)
        {
            this.sideA = sideA;
            this.sideB = 5;
        }
        public Rectangle()
        {
            this.sideA = 4;
            this.sideB = 3;
        }

        public double GetSideA()
        {
            return this.sideA;
        }
        public double GetSideB()
        {
            return this.sideB;
        }
        public double Area()
        {
            return this.sideA * this.sideB;
        }
        public double Perimeter()
        {
            return 2 * this.sideA + 2 * this.sideB;
        }
        public bool IsSquare()
        {
            if (this.sideA == this.sideB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ReplaceSides()
        {
            double temp = this.sideA;
            this.sideA = this.sideB;
            this.sideB = temp;
        }


    }
    public class ArrayRectangles
    {
        private Rectangle[] rectangle_array;
        public ArrayRectangles(int n)
        {
            rectangle_array = new Rectangle[n];
        }
        public ArrayRectangles(Rectangle[] rectangle_array)
        {
            this.rectangle_array = rectangle_array;
        }
        public ArrayRectangles(IEnumerable<Rectangle> rectangles)
        {
            this.rectangle_array = rectangles.ToArray();
        }
        public bool AddRectangle(Rectangle rectangle)
        {
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] == null)
                {
                    rectangle_array[i] = rectangle;
                    return true;
                }
            }
            return false;
        }
        public double NumberMaxArea()
        {
            double[] area = new double[rectangle_array.Length];

            for (int i = 0; i < rectangle_array.Length; i++)
            {
                area[i] = rectangle_array[i].Area();
            }
            return area.Max();
        }
        public double NumberMinPerimeter()
        {
            double[] area = new double[rectangle_array.Length];

            for (int i = 0; i < rectangle_array.Length; i++)
            {
                area[i] = rectangle_array[i].Perimeter();
            }
            return area.Min();
        }
        public int NumberSquare()
        {
            int k = 0;
            foreach (Rectangle rectangle in rectangle_array)
            {
                if (rectangle.IsSquare() == true)
                {
                    k++;
                }
            }
            return k;
        }
    }

}
