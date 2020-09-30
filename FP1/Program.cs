using System;

namespace FP
{
 class MyException: Exception
    {
        public MyException(string message): base(message){}
    }
 interface SalaryCalculate{
     double calsal();
 }

 class Employee:SalaryCalculate
    {
        public string name;
        public double basic;
        public int id;
        public int age;
        public double Basic{
            get{ return basic;}
            set
            {
                try{
                     if(value>=4000)
                        basic=value;
                    else
                        throw new Exception("It can't be less than 4000");
                    
               }
                catch (Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter Basic Pay:");
                    Basic=Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public int Age{
            get{return age;}
            set
            {
               try{
                    if((value>=18) && (value<=60))
                        age=value;
                    else
                        throw new MyException("Age could not be less than 18 years and not exceeds than 60 years");
                    
               }
                catch (MyException e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter Age:");
                    Age=Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public double calsal(){
            return basic*2+basic*0.30; //basic+DA(100%)+HRA(30%)
        }
    }

    class Hourly:Employee
    {
        int num_hrs;
        double rate_hrs;
        double ot_charges;
         public double Rate_Hrs{
            get
            {
                return rate_hrs;
            }
            set
            {
                 try{
                   if(value>=200 && value<=400)
                        rate_hrs=value;
                    else
                        throw new MyException("Minimum and maximum payment is Rs. 200 and 400 per hour respectively. ");
                    
               }
                catch (MyException e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter Rate per Hour:");
                    rate_hrs=Convert.ToDouble(Console.ReadLine());
                }
            }
        }
        public int Num_Hrs{
            get
            {
                return num_hrs;
            }
            set
            {

                try
                {
                if((value>=30) && (value<=50)){
                    if(rate_hrs>=200 && rate_hrs<=400)
                        num_hrs=value;
                }
                    else
                        throw new MyException("Employee cannot work less than 30 hrs. in a week and not more than 50 hrs. in a week.");  
               }
                catch (MyException e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter Number of Hours:");
                    num_hrs=Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void setDetails(){
            Console.WriteLine("Enter Name:");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id:");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Age:");
            Age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rate per Hour:");
            Rate_Hrs=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Number of Hours per week:");
            Num_Hrs=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter OT charges:");
            ot_charges=Convert.ToDouble(Console.ReadLine());
        }
        public new double calsal()
        {
            double sal;
            if(num_hrs>40)
            {
                sal=(40*rate_hrs)+(num_hrs-40)*(rate_hrs*ot_charges);
            }
            else
                sal=num_hrs*rate_hrs;
            if(sal<=25000)
                return sal;
            else throw new MyException("Salary can't exceed Rs. 25000 per week.Try Again");
        }
    }

    class Salaried:Employee{
        int year;
         public void setDetails(){
            Console.WriteLine("Enter Name:");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id:");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Age:");
            Age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Basic Pay per week:");
            Basic=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter No. of Year Employee has worked (Press 0 if employee worked less than 12 months):");
            year=Convert.ToInt32(Console.ReadLine());
        }
        public new double calsal()
        {
            double sal=basic+basic*1.0+basic*0.30;
            double increment=year*sal*0.1;
            if(sal>=4000 && sal<=20000 && sal<=25000)
                return sal+increment;
            else if(sal<4000 || (sal>20000 && sal<=25000))
                throw new MyException("Salary of a salaried employee won’t be exceeded Rs. 20000 per week and not less than Rs.4000 per week.");
            else throw new MyException("Salary can't exceed Rs. 25000 per week.Try Again");
        }
    }

    class Commission:Employee
    {
        int articles;
        double comm_rate=10; //commission on per article sale is 10% is fixed. 
        double unit_price;
        public void setDetails(){
            Console.WriteLine("Enter Name:");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id:");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Age:");
            Age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Articles:");
            articles=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Unit Price:");
            unit_price=Convert.ToDouble(Console.ReadLine());
        }
        public new double calsal(){
            double sal=(articles*unit_price)*(comm_rate/100);// commission calculate per week
            if(sal<=20000 && sal<=25000) 
                return sal;
            else
                throw new MyException("Commission cannot exceed Rs. 20000 in a week");
        }
    }

    class Sal_Commission:Salaried{
        int articles;
        double comm_rate=10; //commission on per article sale is 10% is fixed. 
        double unit_price;
        public new void setDetails(){
            Console.WriteLine("Enter Name:");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id:");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Age:");
            Age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Basic Pay:");
            Basic=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Articles:");
            articles=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Commision Rate %:");
            comm_rate=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Unit Price:");
            unit_price=Convert.ToDouble(Console.ReadLine());
        }
        public new double calsal(){
            double comm=(articles*unit_price)*(comm_rate/100);// commission calculate per week
            double sal=basic+basic*1.0+basic*0.30;
            if(comm<=20000) 
                sal=comm+(sal+(sal*0.1));
            else 
                throw new MyException("Commission cannot exceed Rs. 20000 in a week.");
            if(sal>25000)
                throw new MyException("Salary can't exceed Rs. 25000 per week.Try Again");
            else return sal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Salaried salaried=new Salaried();
            Sal_Commission sal_Commission=new Sal_Commission();
            Commission commission=new Commission();
            Hourly hourly=new Hourly();

            try{
                do{
                Console.WriteLine("Enter choice:");
                Console.WriteLine("1.Salaried Employee");
                Console.WriteLine("2.Hourly Employee");
                Console.WriteLine("3.Commission Employee");
                Console.WriteLine("4.Salaried Commission Employee");
                Console.WriteLine("5.Exit");
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    case 1:salaried.setDetails();
                            Console.WriteLine("Salary Per Week: "+salaried.calsal().ToString());
                            break;
                    case 2: hourly.setDetails();
                            Console.WriteLine("Salary: "+hourly.calsal().ToString());
                            break;
                    case 3: commission.setDetails();
                            Console.WriteLine("Salary Per Week: "+commission.calsal().ToString());
                            break;
                    case 4:sal_Commission.setDetails();
                            Console.WriteLine("Salary Per Week: "+sal_Commission.calsal().ToString());
                            break;
                }

            }while(choice!=5);
            }
            catch(MyException e){
                Console.WriteLine(e.Message);
            }
            catch(FormatException e){
                Console.WriteLine(e.Message);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
