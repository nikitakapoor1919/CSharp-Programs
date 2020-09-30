using System;

namespace HP
{
    delegate void DisplayArray(int[] a);
    class Program
    {
        public static void PrintArray(int[] a) {
            Console.WriteLine("Elements: "); 
            foreach(int i in a)
                Console.Write(i+" ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of Array:");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Elements:",n);
            int[] a=new int[n];
            for(int i=0;i<n;i++)
                a[i]=Convert.ToInt32(Console.ReadLine());       
            DisplayArray arr = new DisplayArray(PrintArray);
            arr(a);
        }
    }
}
