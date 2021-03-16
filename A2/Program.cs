using System;
using System.Collections.Generic;
namespace A2
{
    public abstract class Human
    {
        // Fields
        private string firstName;
        private string lastName;
 
        // Constructor
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
 
        // Properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("First name cannot be null!");
                else
                    this.firstName = value;
            }
        }
 
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Last name cannot be null!");
                else
                    this.lastName = value;
            }
        }
    }
    public class Student : Human
    {
        // Fields
        private int mark;
 
        // Constructor
        public Student(string firstName, string lastName, int mark)
            : base (firstName, lastName)
        {
            this.mark = mark;
        }
 
        // Properties
        public int Mark 
        {
            get { return this.mark; }
            set
            {
                if (value < 1 || value > 100)
                    throw new ArgumentException("Marks should be within range 1-100!");
                else
                    this.mark = value;
            }
        }
        public new string ToString()
        {
            return "FullName: "+FirstName+" "+LastName+", Marks: "+Mark;
        }
    }
    public class Worker : Human
    {
        // Fields
        private double wage;
        private int hourWorked;
 
        // Constructor
        public Worker(string firstName, string lastName, double wage, int hourWorked)
            : base(firstName, lastName)
        {
            this.wage = wage;
            this.hourWorked = hourWorked;
        }
 
        // Properties
        public double Wage 
        {
            get { return this.wage; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Week salary cannot be negative or zero!");
                else
                    this.wage = value;
            }
        }
 
        public int HourWorked 
        {
            get { return this.hourWorked; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Work hours per day cannot be negative or zero!");
                else
                    this.hourWorked = value;
            }
        }
 
        // Methods
        public double Calculate_Hourly_Wage()
        {
            return wage*hourWorked;
        }
        public new string ToString()
        {
            return "FullName: "+FirstName+" "+LastName+", Salary: "+Calculate_Hourly_Wage();
        }
    }
    class MainProgram
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>()
            {
                new Student("Nikita", "Kapoor", 72),
                new Student("Shalvi", "Gupta", 76),
                new Student("Arti", "Wadhwa", 67),
                new Student("Swati", "Vats", 56),
                new Student("Drishti", "Kapur", 90),
            };

            List<Worker> workersList = new List<Worker>()
            {
                new Worker("Reemn", "Thakur", 555, 4),
                new Worker("Anil", "Yadav", 900, 12),
                new Worker("Vikas", "Vats", 100, 40),
                new Worker("Riya", "Ahuja", 1021, 50),
            };
            Console.WriteLine("******Students******");
            foreach(var stu in studentsList)
            {
                Console.WriteLine(stu.ToString());
            }
            Console.WriteLine("******Workers******");
            foreach(var worker in workersList)
            {
               Console.WriteLine(worker.ToString());
            }
        }
    }
}
