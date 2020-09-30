using System;

namespace HP3
{
    delegate int DelegateArray(int[] a);
    class Program
    {
        public static int FindIndex(int[] arr) {
            Console.WriteLine("\nEnter Element to be Searched:");
            int x=Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]==x)
                    return i;
            }
            return -1;
        }

        public static int PrintArray(int[] a) {
            Console.WriteLine("Elements: "); 
            foreach(int i in a)
                Console.Write(i+" ");
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of Array:");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Elements:",n);
            int[] a=new int[n];
            for(int i=0;i<n;i++)
                a[i]=Convert.ToInt32(Console.ReadLine());       
            // DelegateArray arr = new DelegateArray(PrintArray);
            // arr+=FindIndex;
            DelegateArray delPrint,delFindIndex,delResult;
            delPrint=PrintArray;
            delFindIndex=FindIndex;
            delResult=delPrint+delFindIndex;
            int index=delResult(a);
            //int index=arr(a);
            Console.WriteLine(index==-1?
            "Element Not Found":"Element Present at Index: "+index);
        }
    }
}
