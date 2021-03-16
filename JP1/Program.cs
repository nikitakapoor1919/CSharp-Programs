using System;
using System.Linq;
using System.Collections.Generic;
namespace JP1
{
    class Faculty
    {
        public int ID{ get; set;}
        public String Name{get; set;}
        public String City{get; set;}
        public float Salary{get; set;}
        public override string ToString(){
            return "ID: "+ID+"  Name: "+Name+"  City: "+City+"  Salary: "+Salary;
        }
    }
        class Student
    {
        public int Roll{get; set;}
        public String StuName{get; set;}
        public String City{get; set;}
        public List<int> Scores;
        public override string ToString(){
            return "Roll: "+Roll+"  Name: "+StuName+"  City: "+City+"   Score: "+Scores.Average();
        }
        //" Score: "+Scores.ForEach(x=>Console.Write(" "+x));
    }
   class LINQQueryExpressions
    {
        static void Query1(List<Faculty> lstFac){
            IEnumerable<Faculty> lstFacSal =from f in lstFac 
                                where f.Salary > 5000 
                                select f;
            Console.WriteLine("\nDisplay the all Faculties details whose salary "+
                                "is greater than 5000 from a List< Faculty > ");
            foreach(Faculty f in lstFacSal) 
                Console.WriteLine(f); 
        }
        static void Query2(List<Faculty> lstFac,List<Student> lstStu,String City){
            var Result =    (from f in lstFac where f.City == City select f.Name)
                            .Concat(from s in lstStu where s.City == City select s.StuName);
            Console.WriteLine("\nDisplay the all Faculties’ and Students’ name who"+
                                "lived in same City using LINQ Concat method.");
            foreach(var r in Result) 
                Console.Write(r+" , "); 
            Console.Write(" Lives in {0}\n",City);
        }
        static void Query3(List<Faculty> lstFac,List<Student> lstStu){
            var innerJoinQuery =    from faculty in lstFac
                                    join stu in lstStu on faculty.City equals stu.City
                                    select new { faculty.Name,stu.StuName,stu.City};
            Console.WriteLine("\nDisplay the all Faculties and Students details who "+
                            "lived in same City using LINQ join.");
            foreach(var f in innerJoinQuery) 
                Console.WriteLine(f); 
            //Console.WriteLine("InnerJoin: {0} items in 1 group.", innerJoinQuery.Count());
        }
        static void Query4(List<Student> lstStu){
            List<Student> list=new List<Student>();
            var lstStuGroup =  from student in lstStu
                               group student by student.Scores.Average();
            Console.WriteLine("\nDisplay the List of all students in group "+
                                "as per their score using LINQ.");
            foreach(var StuGroup in lstStuGroup){
                foreach (var student in StuGroup)
                {
                    list.Add(student);
                }
            }
            list.ForEach(student=>Console.WriteLine(student));

        }
        static void Main()
        {
             Faculty e1=new Faculty(){ID=1,Name="Prof. Lambda",City="New Delhi",Salary=67400};
             Faculty e2=new Faculty(){ID=2,Name="Prof. Alpha",City="UP",Salary=67400};
             Faculty e3=new Faculty(){ID=3,Name="Prof. Epsilon",City="Pune",Salary=7800};
             Student s1=new Student(){Roll=1,StuName="Ajay",City="New Delhi",Scores= new List<int> {97, 72, 81, 60}};
             Student s2=new Student(){Roll=2,StuName="Nikita",City="New Delhi",Scores= new List<int> {57, 32, 81, 60}};
             Student s3=new Student(){Roll=3,StuName="Kanishka",City="UP",Scores= new List<int> {57, 32, 41, 60}};
              Student s4=new Student(){Roll=4,StuName="Mohit",City="Pune",Scores= new List<int> {97, 72, 81, 60}};

            // Create two lists.
            List<Faculty> lstFac = new List<Faculty>{e1,e2,e3};
            List<Student> lstStu = new List<Student>{s1,s2,s3,s4};

            Query1(lstFac);
            Query2(lstFac,lstStu,"Pune");
            Query3(lstFac,lstStu);
            Query4(lstStu);
        }
    }

}
