using System;

namespace BP_2
{ class GSM {

        String dataService;
        String type;
        String size;
        String color;

        public void service(String dataService,String type,String size, String color) {
            this.dataService = dataService;
            this.type = type;
            this.size = size;
            this.color = color;
        }

        public void serve() {
            Console.WriteLine("--Feature Of Screen--");
            Console.WriteLine("dataService ="+ dataService);
            Console.WriteLine("Type =" + type);
            Console.WriteLine("Size =" + size);
            Console.WriteLine("color =" + color);
        }
    }
    
    
    
    class Battery {

        enum BatteryType { LiIon , NiMH , NiCd  };
        int Start = (int)BatteryType.LiIon;
        int medium = (int)BatteryType.NiMH;
         int End = (int)BatteryType.NiCd;

         public void show()
         {
             Console.WriteLine("--Feature Of battery--");
             Console.WriteLine("LiTon:{0} ", Start);
             Console.WriteLine("NiCd:{0} ", medium);
             Console.WriteLine("NiMH:{0} ", End);
         }
    }
    
    class Display
    {
       static String model;
        String manufacturer;
        int price;
        String owner;

        public static void show() {
            model = "Nokia N95";
            Console.WriteLine("model number ="+ model);
        }

        Display(String manufacturer , int price, String owner) {
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }

        public void showing() {
            Console.WriteLine("Manufacturer="+ manufacturer );
            Console.WriteLine("Price=" + price);
            Console.WriteLine("Owner=" + owner);
        }

        static void Main(string[] args)
        {
            Display.show();
            Display d1 =new Display("ABC",2800,"PQR");
            d1.showing();
            GSM g1 = new GSM();
            g1.service("4G", "mobile", "13*7", "WHITE");
            g1.serve();

            Battery b1 = new Battery();
            b1.show();
            Console.ReadLine();
        }
    }
}
