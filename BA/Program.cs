using System;

namespace BA
{
class Employee{ 

        public int id; 
        public string name; 
        public int salary; 
        public int contri; 
        public int growthRate=2; 
        public int age;
        public void setDetails(){
            Console.WriteLine("Enter Id");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            name=Console.ReadLine();
            Console.WriteLine("Enter Age");
            age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Salary");
            salary=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contribution %");
            contri=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Growth Rate %");
            growthRate=Convert.ToInt32(Console.ReadLine());
        }
         public void getDetails(){
            Console.WriteLine("Id"+id);
            Console.WriteLine("Name"+name);
             Console.WriteLine("Age"+age);
            Console.WriteLine("Salary"+salary);
            Console.WriteLine("Contribution %"+contri);
            Console.WriteLine("Growth Rate %"+growthRate);
        }
        public int getAge(){
            return age;
        }
        public double fundCalc(int currage,int retirementAge) 
        { 
            double F=0; 
            int diff=retirementAge-currage; 
            for (int i=0; i<diff; i++) 
            { 
                F+=(F*growthRate*0.01)+((salary)*(contri+contri+5)*0.01); 
            } 
            return F; 
        } 
    } 
    class Deptt{ 
        public Employee e; 
        public int retirementAge; 
           public void setRetirementAge(){
            Console.WriteLine("Enter Retirement Age");
            retirementAge=Convert.ToInt32(Console.ReadLine());
        }
         public int getRetirementAge(){
           return retirementAge;
        }
    } 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            Employee employee=new Employee(); 
            employee.setDetails();
            Deptt deptt=new Deptt(); 
            deptt.e=employee; 
            deptt.setRetirementAge();
            Console.Write("Retirement Fund:"+Math.Round(deptt.e.fundCalc(employee.getAge(),deptt.getRetirementAge()),2)+" Rs"); 
        } 
    } 
}
