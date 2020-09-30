using System;

namespace BP
{
    class Mobile{
        public string model;
        public string manufacturer;
        public double price;
        public string owner;
        public Mobile(){
            model=null;
            price=0;
            manufacturer=null;
            owner=null;
        }
        public Mobile(string model,string manufacturer,double price ,string owner){
            this.model=model;
            this.manufacturer=manufacturer;
            this.price=price;
            this.owner=owner;
        }
        public static string[] NokiaN95={"Nokia","N95","12000","BL-5F","4","6","1","40 x 53 mm","white"}; 
        public void StoreGeneralInformation(){
                    Console.WriteLine("Enter Model:");
                    model=Console.ReadLine();
                    Console.WriteLine("Enter Manufacturer:");
                    manufacturer=Console.ReadLine();
                    Console.WriteLine("Enter Price:") ;
                    price=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Owner Name:");
                    owner=Console.ReadLine();
        }
        public void StoreOwnerInfo(){
           Console.WriteLine("Enter Owner Name");
           owner=Console.ReadLine();
        }
        public string MobileInfo(){
             return ("Manufacturer:"+manufacturer+"\nModel:"+model+"\nPrice:"+price+"\nOwner:"+owner);
        }
         public void NokiaInfo(){
            manufacturer=NokiaN95[0];
            model=NokiaN95[1];
            price=Convert.ToInt32(NokiaN95[2]);
        }  
    }
    class GSM:Mobile{
        string connection_Provider;         //BSNL, AIRTEL, IDEA, JIO
        string connection_type;             //PREPAID, POSTPAID        

        public  Battery battery;
        public Screen screen;
        static int counter=0;
        public Call[] call=new Call[500];
        public void TotCost(double price){
            double sum=0;
             for(int i=0;i<counter;i++){
                sum+=(Convert.ToInt32(call[i].CallHistory[2])*price);
            }
            Console.WriteLine("Total Price: "+sum+" Rs");
        }
        public void AddCalls(){
            Console.WriteLine("Enter Date:(eg.21-08-2020)");
            string date=Console.ReadLine();
            Console.WriteLine("Enter StartTime:(eg:14:05)");
            string startTime=Console.ReadLine();
            Console.WriteLine("Enter Duration: (seconds)");
            string duration=Console.ReadLine();
            if(Call.totCalls<500){
                call[counter]=new Call();
                call[counter].CallHistory[0]=date;    //CallHistory is property
                call[counter].CallHistory[1]=startTime;
                call[counter].CallHistory[2]=duration;
                Call.totCalls++;
                counter++;
                Console.WriteLine("Call Record Added"); 
            }
            else
                Console.WriteLine("Call Record Full"); 
        }
         public void showCalls(){
            for(int i=0;i<counter;i++){
                for(int j=0;j<3;j++){
                    Console.WriteLine(call[i].CallHistory[j]);
                }
            }
        }
        public void DeleteAllCalls(){
            for(int i=0;i<counter;i++){
                  for(int j=0;j<3;j++){
                   call[i].CallHistory[j]=null; // delete all calls
                }
            }
              Console.WriteLine("All Call Records Deleted");
        }
         public void DeleteCalls(string date,string time){
             int flag=0;
              for(int i=0;i<counter;i++){
                   if( call[i].CallHistory[0].Equals(date)&&  call[i].CallHistory[1].Equals(time)){
                       flag=1;
                       for(int j=0;j<3;j++){
                            call[i].CallHistory[j]=null; // delete particular calls
                        }
                   }
                }
                Console.WriteLine((flag==0) ? "Call Record Not Found" : "Call Record Deleted");
        }
        public void StoreGSMInformation(){
                    Console.WriteLine("Enter Connection Provider:");
                    connection_Provider=Console.ReadLine();
                    Console.WriteLine("Enter Connnection Type:");
                    connection_type=Console.ReadLine();
        }
        public string NokiaDisplayInfo(){
            NokiaInfo();
            battery=new Battery(NokiaN95[3],Convert.ToInt32(NokiaN95[4]),Convert.ToInt32(NokiaN95[5]));
            screen=new Screen(NokiaN95[7],NokiaN95[8]);
            StoreOwnerInfo();
            StoreGSMInformation();
            Console.WriteLine("\n**INFORMATION**");
            string infoAboutPhone = MobileInfo()+"\n"+"\nConnection Provider: "+connection_Provider+
            "\nConnection Type: "+connection_type+"\n\n"+battery.GetInformationBattery() +
            "\nBatteryType: "+battery.GetBatteryType()+ "\n\n"+
            screen.GetInformationScreen() ;
            return infoAboutPhone;
        }   
    }
    class Battery{
        public string batteryModel;
        public int idle_time;
        public int hours_talk;

        public enum BatteryType{LiIon=1,NiMH,NiCd};
        public BatteryType batteryType=(BatteryType)1;
        public Battery(){
            batteryModel=null;
            idle_time=0;
            hours_talk=0;
        }

        public Battery(string batteryModel,int idle_time, int hours_talk){
            this.batteryModel=batteryModel;
            this.idle_time=idle_time;
            this.hours_talk=hours_talk;
        }
        public void StoreInformationBattery(){
                    Console.WriteLine("Enter Battery Model:");
                    batteryModel=Console.ReadLine();
                    Console.WriteLine("Enter Idle Time:") ;
                    idle_time=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Hours Talk:") ;
                    hours_talk=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Choice for Battery Type:") ;
                     Console.WriteLine("1.Li-Ion\n2.NiMH\n3.Nicd") ;
                    batteryType=(BatteryType)Convert.ToInt32(Console.ReadLine());
        }
        public string GetInformationBattery(){
                    return("BatteryModel: "+batteryModel+"\nIdleTime: "+idle_time+"\nHoursTalk: "+hours_talk);
        }
        public string GetBatteryType()
        {
            switch (batteryType)
            {
                case BatteryType.LiIon:
                    return "Li-Ion";
                case BatteryType.NiMH:
                    return "NiMH";
                case BatteryType.NiCd:
                    return "NiCd";
                default:
                    return ("Unsupported battery type: " + batteryType);
            }
        }
    }
    class Screen{
       public string size;
       public string color;
       public Screen(){
           size=null;
           color=null;
       }
       public Screen(string size,string color){
           this.size=size;
           this.color=color;
       }
       public void StoreInformationScreen(){
                    Console.WriteLine("Enter Size:");
                    size=Console.ReadLine();
                    Console.WriteLine("Enter Color:") ;
                    color=Console.ReadLine();
        }
         public string GetInformationScreen(){
                    return("Size: "+size+"\nColor: "+color);
        }
    }
    class Call
    {
        string date;
        string startTime;
        int duration;
        public static int totCalls=0;
        string[] callHistory=new string[3];
        public Call(){}
        public Call(string date,string startTime,int duration){
            this.date=date;
            this.startTime=startTime;
            this.duration=duration;
        }
        public  string[] CallHistory{ 
                get
                {
                    return callHistory;
                }
                set
                {
                    callHistory=value;
                }
        }
         public string GetInformationCall(){
                return("Date: "+date+"\nStartTime: "+startTime+"\nDuration: "+duration);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int ch;
            GSM gsm=new GSM();
            do{
                Console.WriteLine("1.Add Call");
                Console.WriteLine("2.Delete Call");
                Console.WriteLine("3.Delete all Calls");
                Console.WriteLine("4.Total Price");
                Console.WriteLine("5.Exit");
                ch=Convert.ToInt32(Console.ReadLine());
                switch(ch){
                    case 1: gsm.AddCalls(); break;
                    case 2: Console.WriteLine("Enter Date:(eg:21-08-2020)");
                            string date=Console.ReadLine();
                            Console.WriteLine("Enter StartTime:(eg:17:08)");
                            string time=Console.ReadLine();
                            gsm.DeleteCalls(date,time);
                            break;
                    case 3: gsm.DeleteAllCalls(); break;
                    case 4: Console.WriteLine("Enter price per second:");
                            double price=Convert.ToDouble(Console.ReadLine());
                            gsm.TotCost(price);
                            break;
                }
            }
            while(ch!=5);
        }
    }
}
