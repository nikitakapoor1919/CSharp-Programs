using System;
using System.Collections.Generic;

namespace IP1
{
    class Employee
    {
        public int ID{ get; set;}
        public String Name{get; set;}
        public String Address{get; set;}
        public float Salary{get; set;}
        public override string ToString(){
            return "ID: "+ID+"  Name: "+Name+"  Address: "+Address+"  Salary: "+Salary;
        }
        public void Enter(){
            Console.Write("Enter ID: ");
            ID=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            Name=Console.ReadLine();
            Console.Write("Enter Address: ");
            Address=Console.ReadLine();
            Console.Write("Enter Salary: ");
            Salary=float.Parse(Console.ReadLine());
        }
    }
    class Student
    {
        public int Roll{get; set;}
        public String Name{get; set;}
        public String Course{get; set;}
        public float fee{get; set;}
        public override string ToString(){
            return "Roll: "+Roll+"  Name: "+Name+"  Course: "+Course+"  Fees: "+fee;
        }
        public void Enter(){
            Console.Write("Enter Roll: ");
            Roll=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            Name=Console.ReadLine();
            Console.Write("Enter Course: ");
            Course=Console.ReadLine();
            Console.Write("Enter Fees: ");
            fee=float.Parse(Console.ReadLine());
        }
    }
    class MyList<T>:List<T>
    {
        public new void Add (T item)
        {
            base.Add(item);
        }
        public new T Find (Predicate<T> match)
        {
            return base.Find(match);
        }
        public new List<T> FindAll (Predicate<T> match)
        {
            return base.FindAll(match);    
        }
        public new int FindIndex (Predicate<T> match)
        {
            return base.FindIndex(match);
        }
        public new int IndexOf (T item)
        {
            return base.IndexOf(item);
        }
        public new int LastIndexOf (T item)
        {
            return base.LastIndexOf(item);
        }
        public new bool Remove (T item)
        {
            return base.Remove(item);
        }
        public new int RemoveAll (Predicate<T> match)
        {
            return base.RemoveAll(match);
        }
    }
    class Program
    {
        static void Query_Find(MyList<Employee> empList){
            Console.Write("\nEnter ID of Employee Whose Result You Want To Find : ");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Find: Employee Details where ID is {0}:\nDetails: {1}",id,
            empList.Find(x => x.ID.Equals(id)));
        }
        static void Query_Find(MyList<Student> stuList){
            Console.Write("\nEnter Roll of Student Whose Result You Want To Find : ");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Find: Student Details where ID is {0}:\nDetails: {1}",id,
            stuList.Find(x => x.Roll.Equals(id)));
        }
        static void Query_FindAll(MyList<Student> stuList){
            Console.Write("\nEnter Fees of Student Whose Result You Want To Find : ");
            float Fee=float.Parse(Console.ReadLine());
            Console.WriteLine("FindAll: Students where fees greater than {0}:\n*****Result*****\n",Fee);
            List<Student> stuList1=stuList.FindAll(x=> x.fee>Fee);
            stuList1.ForEach(x=>Console.WriteLine(x));
        }
         static void Query_FindAll(MyList<Employee> empList){
            Console.Write("\nEnter Sal of Employee Whose Result You Want To Find : ");
            float Sal=float.Parse(Console.ReadLine());
            Console.WriteLine("FindAll: Employee where Salary greater than {0}:\n*****Result*****\n",Sal);
            List<Employee> empList1=empList.FindAll(x=> x.Salary>Sal);
            empList1.ForEach(x=>Console.WriteLine(x));
        }
        static void Query_FindIndex(MyList<Student> stuList){
            Console.Write("\n\nEnter Name of Student whose index you want to find: ");
            string name=Console.ReadLine();
            var index=stuList.FindIndex(x=> x.Name.Equals(name));
            if(index==-1){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.WriteLine("FindIndex: Student Name is {0} present at index {1}",name,index);
        }
        static void Query_FindIndex(MyList<Employee> empList){
            Console.Write("\n\nEnter Name of Employee whose index you want to find: ");
            string name=Console.ReadLine();
            var index=empList.FindIndex(x=> x.Name.Equals(name));
            if(index==-1){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.WriteLine("FindIndex: Employee Name is {0} present at index {1}",name,index);
        }
        static void Query_IndexOf(MyList<Employee> empList){
            Employee e1=new Employee();
            Console.Write("\nEnter ID of Employee whose Index You Want To Find: ");
            int id=Convert.ToInt32(Console.ReadLine());
            e1=empList.Find(x => x.ID.Equals(id));
            int index=empList.IndexOf(e1);
            if(index==-1){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.Write("IndexOf: Record:[ {0} ] is {1}",e1,index);
        }
        static void Query_IndexOf(MyList<Student> stuList){
            Student e1=new Student();
            Console.Write("\nEnter Roll of Student whose Index You Want To Find: ");
            int id=Convert.ToInt32(Console.ReadLine());
            e1=stuList.Find(x => x.Roll.Equals(id));
            int index=stuList.IndexOf(e1);
            if(index==-1){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.Write("IndexOf: Record:[ {0} ] is {1}",e1,index);
        }
        static void Query_LastIndexOf(MyList<Employee> empList){
            Employee e1=new Employee();
           Console.Write("\n\nEnter ID of Employee whose Last Index You Want To Find: ");
            int id=Convert.ToInt32(Console.ReadLine());
            e1=empList.Find(x => x.ID.Equals(id));
            int index=empList.LastIndexOf(e1);
            if(index==-1){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.Write("LastIndexOf: Record:[ {0} ] is {1}",e1,index);
        } 
         static void Query_LastIndexOf(MyList<Student> stuList){
            Student e1=new Student();
            Console.Write("\n\nEnter Roll of Student whose Last Index You Want To Find: ");
            int id=Convert.ToInt32(Console.ReadLine());
            e1=stuList.Find(x => x.Roll.Equals(id));
            int index=stuList.LastIndexOf(e1);
            if(index==-1){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.Write("LastIndexOf: Record:[ {0} ] is {1}",e1,index);
        }        
        static void Query_Remove(MyList<Student> stuList){
            Student s1=new Student();
            Console.Write("\nEnter Roll No. of Student whose Details You Want To Remove: ");
            int roll=Convert.ToInt32(Console.ReadLine());
            s1=stuList.Find(x => x.Roll.Equals(roll));
            Console.WriteLine("Remove:[ {0} ] ",s1);
            bool result=stuList.Remove(s1);
            if(result==false){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.WriteLine("After Removing...");
            stuList.ForEach(x=>Console.WriteLine(x));
        }
        static void Query_Remove(MyList<Employee> empList){
            Employee s1=new Employee();
            Console.Write("\nEnter ID of Employee whose Details You Want To Remove: ");
            int id=Convert.ToInt32(Console.ReadLine());
            s1=empList.Find(x => x.ID.Equals(id));
            Console.WriteLine("Remove:[ {0} ] ",s1);
            bool result=empList.Remove(s1);
            if(result==false){
                Console.WriteLine("Result Not Found");
                return;
            }
            Console.WriteLine("After Removing...");
            empList.ForEach(x=>Console.WriteLine(x));
        }
        static void Query_RemoveAll(MyList<Student> stuList){
            Console.Write("\nEnter Course of Student whose Records You want to Remove : ");
            string course=Console.ReadLine();
            int result=stuList.RemoveAll(x => x.Course.Equals(course));
            if(result==0){
                Console.WriteLine("Not Found");
                return;
            }
            Console.WriteLine("Remove All: Students where course is {0} : {1} Records contain {0} ",course,
            result);
            Console.WriteLine("Student List After Removing {0}",course);
            stuList.ForEach(x=>Console.WriteLine(x));
        }
        static void Query_RemoveAll(MyList<Employee> empList){
            Console.Write("\nEnter Address(City Name) of Employee whose Records You want to Remove : ");
            string addr=Console.ReadLine();
            int result=empList.RemoveAll(x => x.Address.Equals(addr));
            if(result==0){
                Console.WriteLine("Not Found");
                return;
            }
            Console.WriteLine("Remove All: Address where city is {0} : {1} Records contain {0} ",addr,
            result);
            Console.WriteLine("Employee List After Removing {0}",addr);
            empList.ForEach(x=>Console.WriteLine(x));
        }
        static void Main(string[] args)
        {
            Employee empObj=new Employee();
            Student stuObj=new Student();
            MyList<Employee> empList = new MyList<Employee>();
            MyList<Student> stuList = new MyList<Student>();
            Employee e1=new Employee(){ID=4,Name="Lambda",Address="Delhi",
            Salary=67400};
            empList.Add(new Employee(){ID=1,Name="Alpha",Address="Delhi"
            ,Salary=20000});
            empList.Add(new Employee(){ID=4,Name="Lambda",Address="Pune",
            Salary=67400});
            empList.Add(new Employee(){ID=2,Name="Delta",Address="UP",Salary=25000});
            empList.Add(new Employee(){ID=3,Name="Gamma",Address="UP",
            Salary=89800});

            stuList.Add(new Student(){Roll=1,Name="Nikita",Course="MCA",fee=200000});
            stuList.Add(new Student(){Roll=2,Name="Shalvi",Course="MCA",fee=250000});
            stuList.Add(new Student(){Roll=3,Name="Mohit",Course="Btect",fee=89000});
            int ch,ch2;
            do{
                Console.WriteLine("\n1.Employee");
                Console.WriteLine("2.Student");
                Console.WriteLine("3.Exit");
                ch=Convert.ToInt32(Console.ReadLine());
                if(ch==1)
                {
                    do{
                    Console.WriteLine("\n1.Add Employee");
                    Console.WriteLine("2.Find by ID");
                    Console.WriteLine("3.FindAll Query");
                    Console.WriteLine("4.FindIndex Query");
                    Console.WriteLine("5.IndexOf Query");
                    Console.WriteLine("6.LastIndexOf Query");
                    Console.WriteLine("7.Remove by ID");
                    Console.WriteLine("8.Remove All by Address");
                    Console.WriteLine("9.Exit");
                    ch2=Convert.ToInt32(Console.ReadLine());
                    switch(ch2)
                    {
                        case 1:empObj.Enter(); 
                               empList.Add(empObj); 
                               break;
                        case 2:Query_Find(empList); break;
                        case 3:Query_FindAll(empList); break;
                        case 4:Query_FindIndex(empList); break;
                        case 5:Query_IndexOf(empList); break;
                        case 6:Query_LastIndexOf(empList); break;
                        case 7:Query_Remove(empList); break;
                        case 8:Query_RemoveAll(empList); break;
                    }
                    }while(ch2!=9);
                }
                else if(ch==2)
                {
                    do{
                    Console.WriteLine("\n1.Add Student");
                    Console.WriteLine("2.Find by Roll");
                    Console.WriteLine("3.FindAll Query");
                    Console.WriteLine("4.FindIndex Query");
                    Console.WriteLine("5.IndexOf Query");
                    Console.WriteLine("6.LastIndexOf Query");
                    Console.WriteLine("7.Remove by Roll");
                    Console.WriteLine("8.Remove All by Course");
                    Console.WriteLine("9.Exit");
                    ch2=Convert.ToInt32(Console.ReadLine());
                    switch(ch2)
                    {
                        case 1:stuObj.Enter(); 
                               stuList.Add(stuObj); 
                               break;
                        case 2:Query_Find(stuList); break;
                        case 3:Query_FindAll(stuList); break;
                        case 4:Query_FindIndex(stuList); break;
                        case 5:Query_IndexOf(stuList); break;
                        case 6:Query_LastIndexOf(stuList); break;
                        case 7:Query_Remove(stuList); break;
                        case 8:Query_RemoveAll(stuList); break;
                    }
                    }while(ch2!=9);

                }

            }while(ch!=3);
        }
    }
}





// using System;
// using System.Collections;
// using System.Collections.Generic;
// namespace As10
// {
// public class Student{
// public int rollno;
// public String course;
// public String name;
// public int fees;
// public Student(){
// Console.Write("Enter the Rollno: ");
// rollno=Convert.ToInt32(Console.ReadLine());
// Console.Write("Enter the Course: ");
// course=Console.ReadLine();
// Console.Write("Enter the name: ");
// name=Console.ReadLine();
// Console.Write("Enter the fees: ");
// fees=Convert.ToInt32(Console.ReadLine());
// }
// public void getData(){
// Console.WriteLine("RollNo: "+rollno);
// Console.WriteLine("Course: "+course);
// Console.WriteLine("Name: "+name);
// Console.WriteLine("Fees: "+fees);
// }
// }
// class MyList<T>
// {
// static ArrayList record=new ArrayList();
// int index=0;
// public delegate void Find(String name);
// public delegate void FindAll(String name);
// public delegate void FindIndex(int rollno);
// public Student findObject(string name){
// foreach(T i in record){
// Student obj=(Student)(object)(i);
// if(obj.name==name){
// return obj;
// }
// }
// Console.WriteLine("NAME NOT PRESENT");
// return null;
// }
// public void Add(T obj){
// if(typeof(T).Equals(typeof(Student))){
// record.Add((Student)(object)obj);
// }
// else{
// Console.WriteLine("Can't be found");
// }
// }
// public Find find=delegate(string name){
// foreach(Student i in record){
// if(i.name==name){
// i.getData();
// return;
// }
// }
// return;
// };
// public FindAll findAll=delegate(String name){
// foreach(Student i in record){
// if(i.name==name){
// i.getData();
// }
// }
// };
// public FindIndex findIndex=delegate(int rollno){
// int index=0;
// foreach(Student i in record){
// if(i.rollno==rollno){
// Console.WriteLine("Index of student is : "+index);
// return;
// }
// index++;
// }
// };
// public void IndexOf(T obj){
// if(typeof(T).Equals(typeof(Student))){
// Student student=(Student)(object)obj;
// int index=0;
// foreach(T i in record){
// Student check=(Student)(object)(i);
// if(check.rollno==student.rollno){
// Console.WriteLine("Student index value is: "+index);
// }
// index++;
// }
// }
// else{
// Console.WriteLine("not found");
// }
// }
// public void LastIndexOf(T obj){
// if(typeof(T).Equals(typeof(Student))){
// Student check=(Student)(object)(obj);
// Console.WriteLine("Student index value is: "+record.LastIndexOf(check));
// }
// else{
// Console.WriteLine("not found");
// }
// }
// public void Remove(T obj){
// if(typeof(T).Equals(typeof(Student))){
// record.Remove(obj);
// Console.WriteLine("RECORD REMOVED");
// }
// else{
// Console.WriteLine("not found");
// }
// }
// public void RemoveAll(T obj){
// if(typeof(T).Equals(typeof(Student))){
// Student std=(Student)(object)(obj);
// // int index=0;
// Console.WriteLine("RECORDS REMOVED");
// }
// else{
// Console.WriteLine("not found");
// }
// }
// }
// class Program
// {
// static void Main(string[] args)
// {
// MyList<Student> list=new MyList<Student>();
// while(true){
// Console.WriteLine("1.Add Student Details");
// Console.WriteLine("2.Find Student with name");
// Console.WriteLine("3.Find all Student with same name");
// Console.WriteLine("4.Find Student index with rollno");
// Console.WriteLine("5.Find Student index with name");
// Console.WriteLine("6.Find Student last index with name");
// Console.WriteLine("7.Remove Student with name");
// Console.WriteLine("8.Remove all Student with same name");
// Console.Write("Enter your choice: ");
// int choice=Convert.ToInt32(Console.ReadLine());
// switch(choice){
// case 1: Student obj=new Student();
// list.Add(obj);
// break;
// case 2: Console.Write("Enter Student name: ");
// string name=Console.ReadLine();
// list.find(name);
// break;
// case 3: Console.Write("Enter Student name: ");
// name=Console.ReadLine();
// list.findAll(name);
// break;
// case 4: Console.Write("Enter Student rollno: ");
// int rollno=Convert.ToInt32(Console.ReadLine());
// list.findIndex(rollno);
// break;
// case 5: Console.Write("Enter Student name: ");
// name=Console.ReadLine();
// Student std=list.findObject(name);
// list.IndexOf(std);
// break;
// case 6: Console.Write("Enter Student name: ");
// name=Console.ReadLine();
// std=list.findObject(name);
// list.LastIndexOf(std);
// break;
// case 7: Console.Write("Enter Student name: ");
// name=Console.ReadLine();
// std=list.findObject(name);
// list.Remove(std);
// break;
// case 8: Console.Write("Enter Student name: ");
// name=Console.ReadLine();
// std=list.findObject(name);
// list.RemoveAll(std);
// break;
// default:
// break;
// }
// }
// }
// }
// }