using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework3
{
    interface Shape
    {
        double Area { get; }
        string Info { get; }
        bool IsValid();
    }
    class Rectangle:Shape
    {
        private double width;
        private double length;

        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }
        public double Length { get; set; }
        public double Width { get; set; }
        public string Info => $"矩形:length={Length},width={Width}.";

        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                return Length * Width;
            }
        }
        public bool IsValid()
        {
            return Length > 0 && Width > 0;
        }
    }
    class Square:Shape
    {
        private double side;

        public Square(double side)
        {
            Side = side;
        }
        public double Side { get; set; }
        public string Info => $"正方形:side={Side}.";

        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                return Side * Side;
            }
        }
        public bool IsValid()
        {
            return Side > 0;
        }
    }
    class Triangle:Shape
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            double[] newEdges = new double[3] { a, b, c };
            this.Edges = newEdges;
        }
        public double[] Edges { get; set; } = new double[3];
        public string Info
        {
            get => $"三角形:a={Edges[0]},b={Edges[1]},c={Edges[2]}.";
        }
        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                double p = (Edges[0] + Edges[1] + Edges[2]) / 2;
                return Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
            }
        }
        public bool IsValid()
        {
            double a = Edges[0], b = Edges[1], c = Edges[2];
            return (a > 0 && b > 0 && c > 0 &&
                    a + b > c && b + c > a && a + c > b);

        }
    }
    class ShapeFactory
    {

        static Random random = new Random();

        //根据类型和参数创建形状
        public static Shape CreateShape(string type, params double[] edges)
        {
            Shape result = null;
            switch (type)
            {
                case "squre":
                    result = new Square(edges[0]);
                    break;
                case "rectangle":
                    result = new Rectangle(edges[0], edges[1]);
                    break;
                case "triangle":
                    result = new Triangle(edges[0], edges[1], edges[2]);
                    break;
                default: throw new InvalidOperationException("Invalid shape type:" + type);
            }
            return result;
        }

        //随机创建形状
        public static Shape CreateRandomShape()
        {
            int type = random.Next(0, 3);
            Shape result = null;
            while (result == null)
            {
                try
                {
                    switch (type)
                    {
                        case 0:
                            result = CreateShape("squre", random.Next(200));
                            break;
                        case 1:
                            result = CreateShape("rectangle", random.Next(200), random.Next(200));
                            break;
                        case 2:
                            result = CreateShape("triangle", random.Next(200), random.Next(200), random.Next(200));
                            break;
                    }
                }
                catch
                {
                    //忽略异常
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Shape> shapes = new List<Shape>();
                for (int i = 0; i < 10; i++)
                {
                    shapes.Add(ShapeFactory.CreateRandomShape());
                }

                shapes.ForEach(s =>
                  Console.WriteLine($"{s.Info}, area={s.Area}"));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
