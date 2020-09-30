using System;

namespace AA1
{
 class Employee
    {
        public string name;
        public double basic;
        public int id;
        public double calsal(){

            return basic*2+basic*0.30; //basic+DA(100%)+HRA(30%)
        }
    }

    class Hourly:Employee
    {
        int num_hrs;
        double rate_hrs;
        double ot_charges;
        public void setDetails(){
            Console.WriteLine("Enter Name");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number of Hours");
            num_hrs=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rate per Hour");
            rate_hrs=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter OT charges");
            ot_charges=Convert.ToDouble(Console.ReadLine());
        }
        public double calsal()
        {
            if(num_hrs>40)
            {
                return (40*rate_hrs)+(num_hrs-40)*(rate_hrs*ot_charges);
            }
                return num_hrs*rate_hrs;
        }
    }

    class Salaried:Employee{
         public void setDetails(){
            Console.WriteLine("Enter Name");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Basic Pay");
            basic=Convert.ToInt32(Console.ReadLine());
        }
        public double calsal()
        {
            return basic+basic*1.0+basic*0.30;
        }
    }

    class Commission:Employee
    {
        int articles;
        double comm_rate; 
        double unit_price;
           public void setDetails(){
            Console.WriteLine("Enter Name");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Articles");
            articles=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Commision Rate %");
            comm_rate=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Unit Price");
            unit_price=Convert.ToDouble(Console.ReadLine());
        }
        public double calsal(){
            return (articles*unit_price)*(comm_rate)/100;
        }
    }

    class Sal_Commission:Salaried{
        int articles;
        double comm_rate; //10
        double unit_price;
        public void setDetails(){
            Console.WriteLine("Enter Name");
            name=(Console.ReadLine());
            Console.WriteLine("Enter Id");
            id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Basic Pay");
            basic=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Articles");
            articles=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Commision Rate %");
            comm_rate=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Unit Price");
            unit_price=Convert.ToDouble(Console.ReadLine());
        }
        public double calsal(){
            return ((articles*unit_price)*(comm_rate)/100)+(basic+basic*1.0+basic*0.30);
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
                            Console.WriteLine("Salary:"+salaried.calsal().ToString());
                            break;
                    case 2: hourly.setDetails();
                            Console.WriteLine("Salary:"+hourly.calsal().ToString());
                            break;
                    case 3: commission.setDetails();
                            Console.WriteLine("Salary:"+commission.calsal().ToString());
                            break;
                    case 4:sal_Commission.setDetails();
                            Console.WriteLine("Salary:"+sal_Commission.calsal().ToString());
                            break;
                }

            }while(choice!=5);
        }
    }
}
