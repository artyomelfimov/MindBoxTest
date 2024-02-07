namespace ShapeLibrary
{
    interface IShape
    {
        double GetArea();
    }
    public class Shape
    {
        private IShape Figure { get; set; }
        public Shape(params int[] values)
        {
            switch (values.Length)
            {
                case 0:
                    throw new ArgumentOutOfRangeException("Ничего не передано!");
                case 1:
                    Figure = new Circle(values[0]);
                    break;
                case 3:
                    Figure = new Triangle(values[0], values[1], values[2]);
                    break;
                default: throw new ArgumentOutOfRangeException("Такой фигуры нет!");

            }
        }
        public double GetArea() => Figure.GetArea();
        public bool IsRectangular()
        {
            if (Figure is Triangle fig)
            {
                return fig.IsRectangular();
            }
            else
            {
                throw new InvalidOperationException("Фигура не является треугольником!");
            };
        }


    }
    public class Circle : IShape
    {
        private int radius;

        public Circle(int radius)
        {
            if (radius <= 0) throw new ArgumentException("Радиус должен быть положительным");
            this.radius = radius;
        }

        public double GetArea()
        {
            return radius * radius * Math.PI;
        }
    }
    public class Triangle : IShape
    {
        private int[] Sides { get; set; }
        public Triangle(int firstSide, int secondSide, int thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0) throw new ArgumentException("Стороны треугольника должны быть положительными");

            Sides = [firstSide, secondSide, thirdSide];
            if (Sides.Max() >= Sides.Sum() - Sides.Max()) throw new ArgumentException("Сторона треугольника не может быть больше суммы двух других сторон");
        }
        public double GetArea()
        {
            var p = (Sides.Sum()) / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }
        public bool IsRectangular()
        {
            return Sides.Where(x => x == Sides.Max()).Select(x => x * x).Sum() == Sides.Where(x => x != Sides.Max()).Select(x => x * x).Sum();
        }
    }
}


