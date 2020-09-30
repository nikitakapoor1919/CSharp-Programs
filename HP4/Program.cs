using System;

namespace HP
{
    delegate void DelegateArray(int[] a);
    delegate int[] DelegateSortArray(int[] a);
    class Program
    {
        public static void PrintArray(int[] a) {
            foreach(int i in a)
                Console.Write(i+" ");
        }
        public static void SortArray(int[] a) {
            int[] b=new int[a.Length];
            Console.WriteLine("\nElements After Sorting: "); 
            DelegateSortArray sort= delegate(int[] a) { 
                    for(int i=0;i<a.Length-1;i++){
                    for(int j=0;j<a.Length-1-i;j++){
                        if(a[j]>a[j+1]){
                            int temp=a[j];
                            a[j]=a[j+1];
                            a[j+1]=temp;
                        }
                    }
                }
                return a;    
            };
            b=sort(a);
            foreach(int i in b)
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
            DelegateArray arr = new DelegateArray(PrintArray);
            Console.WriteLine("Elements Before Sorting: "); 
            arr(a);
            arr= SortArray;
            arr(a);            
        }
    }
}
