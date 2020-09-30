using System;

namespace EP1
{
    class Program
    {
        class NegativeNumberNotAllowed: Exception
        {
        public NegativeNumberNotAllowed(string message): base(message){}
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number:");
            int num =Convert.ToInt32(Console.ReadLine());
            try
            {
                if(num >0)
                    Console.WriteLine("Square Root:"+Math.Sqrt(num)); 
                else
                    throw new NegativeNumberNotAllowed("Invalid Number");

            }
            catch (NegativeNumberNotAllowed e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }
    }
}
