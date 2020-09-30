using System;

namespace EP2
{
    class Program
    {
        class NotInRange: Exception
        {
        public NotInRange(string message): base(message){}
        }

        public static void ReadNumber(int start, int end)
        {
            int[] arr=new int[10];
            Console.WriteLine("Enter 10 Integers:");
            for(int i=0;i<10;i++)
            {
                arr[i]=Convert.ToInt32(Console.ReadLine());
                if(arr[i]>=start && arr[i]<=end)
                {
                    if((i!=0) && (arr[i] <arr[i-1]))
                        throw new NotInRange("Invalid!!");
                }
                else
                    throw new NotInRange("Invalid!!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Start Range:");
            int start=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter End Range:");
            int end=Convert.ToInt32(Console.ReadLine());
            try
            {
                Program.ReadNumber(start,end);

            }catch(NotInRange e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Exceptiom: "+e.Message);
            }
        }
    }
}
