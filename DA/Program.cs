using System;

namespace DA
{
    class Stock{
        double [] price=new double[10];
        public double this[int index]{
            get{return price[index];}
            set{price[index]=value;}
        } 
        public double MethodMomentum(int days){
            double M=(price[0]/price[days])*100;
            return M;
        }
    }
    class Exchange{
        double [] price=new double[10];
        public double this[int index]{
            get{return price[index];}
            set{price[index]=value;}
        }  
        public double MethodMomentum(int days){
            double M=(price[0]/price[days])*100;
            return M;
        }
    }
    class Program
    {
         public static double mean(Stock a,int n){
            double sum_x=0;
            for(int i=0;i<n;i++)
                sum_x+=a[i];
            //MEAN
           return sum_x/n;  
        }
        public static double mean(Exchange a,int n){
            double sum_x=0;
            for(int i=0;i<n;i++)
                sum_x+=a[i];
            //MEAN
           return sum_x/n;  
        }
        public static double StandardDeviation(Stock a,int n){
            double[] a_new=new double[10];
            double aa_sum=0;
             for(int i=0;i<n;i++)
                a_new[i]=Math.Pow((a[i]-mean(a,n)),2);  
             for(int i=0;i<n;i++)
                aa_sum+=a_new[i];
            return Math.Sqrt((aa_sum)/(n-1));
        }
        public static double StandardDeviation(Exchange a,int n){
            double[] a_new=new double[10];
            double aa_sum=0;
             for(int i=0;i<n;i++)
                a_new[i]=Math.Pow((a[i]-mean(a,n)),2);  
             for(int i=0;i<n;i++)
                aa_sum+=a_new[i];
            return Math.Sqrt((aa_sum)/(n-1));
        }
         public static double Covariance(Stock a,Exchange b,int n){
            //FORMULA (ai-amean)*(bi=bmean)
            int i;
            double[] a_new=new double[10];
            double[] b_new=new double[10];
            double[] ab_new=new double[10];
            double ab_sum=0;
             for(i=0;i<n;i++){
                a_new[i]=a[i]-mean(a,n);
                b_new[i]=b[i]-mean(b,n);
                ab_new[i]=a_new[i]*b_new[i];
             }

             for(i=0;i<n;i++)
                ab_sum+= ab_new[i];               
            return ab_sum/(n-1);
        }
        public static double Corelation(Stock a,Exchange b,int n){       
            return Covariance(a,b,n)/(StandardDeviation(a,n)*StandardDeviation(b,n));
        }
        static void Main(string[] args)
        {
            int n=10;
            Stock MRF=new Stock();
            MRF[0]=16980;
            MRF[1]=16960;
            MRF[2]=16970;
            MRF[3]=16975;
            MRF[4]=16972;
            MRF[5]=16970;
            MRF[6]=16950;
            MRF[7]=16945;
            MRF[8]=16950;
            MRF[9]=16930;
            Exchange NSE=new Exchange();
            NSE[0]=20180;
            NSE[1]=20175;
            NSE[2]=20160;
            NSE[3]=20155;
            NSE[4]=20165;
            NSE[5]=20145;
            NSE[6]=20130;
            NSE[7]=20120;
            NSE[8]=20130;
            NSE[9]=20125;
            Console.WriteLine("\n*****Method Momentum*****");
            Console.WriteLine("How may Days ago you want to Check?");
            int day=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Method Momentum(MRF)="+Math.Round(MRF.MethodMomentum(day),2));
            Console.WriteLine("Method Momentum(NSE)= "+Math.Round(NSE.MethodMomentum(day),2));
            Console.WriteLine("\n*****Method Mean Reversion*****");
            Console.WriteLine("Corelation(MRF,NSE)= "+Math.Round(Corelation(MRF,NSE,n),2));
        }
    }
}
