using System;

namespace A_2_1
{
    delegate double CalculateSurfaceDel();
    public  abstract class Shape
    {
        private double width;
        private double height;
        public double Width
        {
            get{return width;}
            set{width=value;}
        }
        public double Height
        {
            get{return height;}
            set{height=value;}
        }
        public Shape(double width,double height)
        {
            this.width=width;
            this.height=height;
        }
        public abstract double CalculateSurface();
    }
    public class Triangle:Shape
    {
        public Triangle(double width,double height):base(width,height){}
        public override double CalculateSurface()
        {
            return 0.5*Width*Height;
        }
    }
    public class Rectangle:Shape
    {
        public Rectangle(double width,double height):base(width,height){}

        public override double CalculateSurface()
        {
            return Width*Height;
        }
        
    }
    public class Circle:Shape
    {
        public Circle(double radius):base(radius,radius){}

        public override double CalculateSurface()
        {
            return 3.14*Width*Height;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[]
            {
                new Triangle(4, 5),
                new Rectangle(20, 11),
                new Circle(3),
                new Triangle(2.1, 5.2),
                new Rectangle(21, 11),
                new Circle(3),
            };
            
            CalculateSurfaceDel[] cal=new CalculateSurfaceDel[6];
            cal[0]=shapes[0].CalculateSurface;
            cal[1]=shapes[1].CalculateSurface;
            cal[2]=shapes[2].CalculateSurface;
            cal[3]=shapes[3].CalculateSurface;
            cal[4]=shapes[4].CalculateSurface;
            cal[5]=shapes[5].CalculateSurface;

            int i=0;
            foreach (Shape element in shapes)
            {
                Console.WriteLine("{0}= {1}", element.GetType().Name,cal[i++]());
            }

        }
    }
}
