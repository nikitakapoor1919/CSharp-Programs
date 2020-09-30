using System;

namespace HP
{
    delegate bool IndexDisplay(int[] a,int x);
    delegate void DelegateArray(int[] a,int x);
    class Array{
        public static void FindElement(int[] arr,int x) {
            
            IndexDisplay index=(arr,x) =>
            {
                for(int i=0;i<arr.Length;i++)
                {
                    if(arr[i]==x)
                        return true;
                }
                return false;
            };
        Console.WriteLine(index(arr,x)==false ?"Element Not Found":"Element Found");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a=new int[10];
            Console.WriteLine("Enter size of Array:");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Elements:",n);
            for(int i=0;i<n;i++)
                a[i]=Convert.ToInt32(Console.ReadLine());        
            Console.WriteLine("Enter Element to be Searched:");
            int x=Convert.ToInt32(Console.ReadLine());
            DelegateArray delegateArray=new DelegateArray(Array.FindElement);
            delegateArray(a,x);
        }
    }
}
