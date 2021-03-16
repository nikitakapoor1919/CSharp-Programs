using System;
using System.Collections.Generic;

namespace A1
{
    public class Class
    {
        private List<Students> students;
        private List<Teachers> teachers;
        private string classID;
        public Class(List<Students> Students, List<Teachers> Teachers, string classID)
        {
            this.students = Students;
            this.teachers = Teachers;
            this.classID = classID;
        }
 
        // Properties
       public List<Students> Students
        {
            get { return this.students; }
            set { this.students = value; } 
        }
 
        public List<Teachers> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; } 
        }
 
        public string ClassID 
        {
            get { return this.classID; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Class ID cannot be null!");
                }
                else
                {
                    this.classID = value;
                }
            }
        }
        public new string ToString()
        {
            // Print information about students
            Console.WriteLine("******Students******");
            foreach (var stu in Students)
            {
                Console.WriteLine("Full Name: {0}, Class: {1}, ClassID: {2}", stu.FirstName + " " + stu.LastName, stu.RollNo, ClassID);
            }
            Console.WriteLine();
 
            // Print information about teachers
            Console.WriteLine("******Teachers******");
            foreach (var teacher in Teachers)
            {
                Console.WriteLine("Full name: {0} \n\nCourses: ", teacher.FirstName + " " + teacher.LastName);
 
                foreach (var item in teacher.Courses)
                {
                    Console.WriteLine("Course name: " + item.CourseName);
                    Console.WriteLine("Number of lectures: " + item.NumberOfLectures);
                    Console.WriteLine("Number of exercises: " + item.NumberOfExercises);
                    Console.WriteLine();
                }
            }
            return null;
        }
    }
    public class Person
    {
         // Fields
        private string firstName;
        private string lastName;
 
        // Constructor
        public Person(string firstName, string lastName)
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
                {
                    throw new ArgumentNullException("First name cannot be null!");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }
 
        public string LastName 
        {
            get { return this.lastName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name cannot be null!");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }
        
    }
    public class Students:Person
    {
        private int rollNo;
 
        // Constructor
        public Students(string firstName, string lastName, int rollNo)
            : base(firstName, lastName)
        {
            this.rollNo = rollNo;
        }
 
        // Properties
        public int RollNo
        {
            get { return this.rollNo; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Student class number cannot be negative or zero!");
                }
                else
                {
                    this.rollNo = value;
                }
            }
        }
    }
    public class Teachers:Person
    {
        private List<Course> courses;
 
        // Constructor
        public Teachers(string firstName, string lastName, List<Course> courses)
            : base(firstName, lastName)
        {
            this.courses = courses;
        }
 
        // Properties
        public List<Course> Courses
        {
            get { return this.courses; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course cannot be null!");
                }
                else
                {
                    this.courses = value;
                }
            }
        }
    }
    public class Course
    {
        private string courseName;
        private int numberOfLectures;
        private int numberOfExercises;
 
        // Constructor
        public Course(string courseName, int numberOfLectures, int numberOfExercises)
        {
            this.courseName = courseName;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
        }
 
        // Properties
        public string CourseName 
        {
            get { return this.courseName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course name cannot be null!");
                }
                else
                {
                    this.courseName = value;
                }
            }
        }
 
        public int NumberOfLectures 
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }
 
        public int NumberOfExercises 
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
        }
    }
    public class School
    {
        // Fields
        private string schoolName;
        private List<Class> classes;
 
        //Constructor
        public School(List<Class> classes, string schoolName)
        {
            this.classes = classes;
            this.schoolName = schoolName;
        }
 
        // Properties
        public string SchoolName 
        {
            get{return this.schoolName;}
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("School name cannot be null!");
                }
                else
                {
                    this.schoolName = value;
                }
            }
        }
        public List<Class> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }
 
        // Methods
        public void PrintSchoolName()
        {
            Console.WriteLine("School Name: {0}\n", SchoolName);
        }
        public new string ToString()
        {
            PrintSchoolName();
            foreach(var x in Classes)
            {
                Console.WriteLine("**********Class Information**********\n");
                Console.WriteLine(x.ToString());
            }
            return null;
        }
 
    }
    class MainProgram
    {
        static void Main(string[] args)
        {
            List<Students> stuList1=new List<Students>(){new Students("Nikita","Kapoor",1),
            new Students("Shalvi","Gupta",1),new Students("Swati","Vats",3)};
            List<Students> stuList2=new List<Students>(){new Students("Arti","Yadav",1),
            new Students("Simran","Kaur",1),new Students("Shubham","Sethi",3)};

            List<Course> courseList1=new List<Course>(){new Course("DM",3,10),
            new Course("OS",5,6)};
            List<Course> courseList2=new List<Course>(){new Course("PPM",5,10),
            new Course("SE",5,6)};
            List<Course> courseList3=new List<Course>(){new Course("Java",3,2),
            new Course("DS",8,10)};

            List<Teachers> teacherList1=new List<Teachers>(){new Teachers("Reema","Thakur",courseList1),
            new Teachers("Arti","Bhaskar",courseList2),new Teachers("Jaya","Sood",courseList3)};
            List<Teachers> teacherList2=new List<Teachers>(){new Teachers("Pratibha","Yadav",courseList1),
            new Teachers("Seema","Gupta",courseList3)};

            List<Class> classList=new List<Class>(){new Class(stuList1,teacherList1,"C-1"),
            new Class(stuList2,teacherList2,"C-2")};
            School school=new School(classList,"BVICAM");
            Console.WriteLine(school.ToString());
        }
    }
}
