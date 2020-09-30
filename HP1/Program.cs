using System;

namespace HP
{
    delegate int IndexDisplay(int[] a,int x);
    class Program
    {
        public static int FindIndex(int[] arr,int x) {
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]==x)
                    return i;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] a=new int[10];
            Console.WriteLine("Enter size of Array:");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Elements:",n);
            for(int i=0;i<n;i++)
                a[i]=Convert.ToInt32(Console.ReadLine());        
            IndexDisplay index = new IndexDisplay(FindIndex);
            Console.WriteLine("Enter Element to be Searched:");
            int x=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(index(a,x)==-1?
            "Element Not Found":"Element Present at Index: "+index(a,x));
        }
    }
}

