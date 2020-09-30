using System;

namespace LAB2_24_7
{
    class Student
    {
        public string full_name;
        public string course;
        public string subject;
        public string university;
        public string email;
        public long? phone_number;
        public Student(){}
        public Student(string full_name,string course,string university,string subject,string email,int phone_number){
            this.full_name=full_name;
            this.university=university;
            this.course=course;
            this.subject=subject;
            this.email=email;
            this.phone_number=phone_number;
        }
        public Student(string full_name,string course,string university){
                this.full_name=full_name;
                this.course=course;
                this.university=university;
                phone_number=null;
                email=null;
                subject=null;
        }
         public Student(string full_name,string course,string university,string subject,string email){
            this.full_name=full_name;
            this.university=university;
            this.course=course;
            this.subject=subject;
            this.email=email;
        }
        public void getDetails(){
            Console.WriteLine("**********************");
            Console.WriteLine("Student Details");
            Console.WriteLine("Name :"+full_name);
            Console.WriteLine("Course :"+course);
            Console.WriteLine("Subject :"+subject);
            Console.WriteLine("University :"+university);
            Console.WriteLine("Email :"+email);
            if(phone_number!=null)
                Console.WriteLine("Phone Number :"+phone_number);
        }
        public void setDetails(){
            Console.WriteLine("Enter Name");
            full_name = Console.ReadLine();
            Console.WriteLine("Enter Course");
            course = Console.ReadLine();
            Console.WriteLine("Enter Subject");
            subject = Console.ReadLine();
            Console.WriteLine("Enter University");
            university = Console.ReadLine();
            Console.WriteLine("Enter Email");
            email = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            phone_number = Convert.ToInt64(Console.ReadLine());

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s=new Student("Nikita","MCA","C#","IPU","nikita@gmail.com");
            //s.setDetails();
            s.getDetails();

        }
    }
}
