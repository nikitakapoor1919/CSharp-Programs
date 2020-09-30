using System;

namespace Lab1
{
    public class Session{
        public string[] key=new string[10];
        //public string[] val=new string[10];
        //public string[] s={"username","password"};
        // public string this [string index]{
        //     get{
        //        for(int i=0;i<s.Length;i++){
        //             if(s[i]==index){
        //              return val[i];
        //         }
        //       }
        //       return null;
        //     }
        //     set{
        //       for(int i=0;i<s.Length;i++){
        //             if(s[i]==index){
        //               val[i]=value;
        //         }
        //       }
        //     }
        // }
        public string[] values=new string[10];
        public string this[string index]{
          get
          {
            int i=0;
            foreach(string item in key)
            {
              if(item==index)
                return values[i];
              i++;
            }
              return null;
          }
          set{
            int i=0;
            foreach(string item in key)
            {
              if(item==index && item!=null)
              {
              values[i]=value;
              i++;
              }
              else if(item==null)
              {
                  key[i]=index;
                  values[i]=value;
              }
              else
                i++;
            }
          }
        }
        static void Main(string[] args)
        {
        Session s=new Session();
        s["username"]="Nikita";
        s["password"]="123";
        s["email"]="nikita@gmail.com";
        s["email"]="n@gmail.com";
        s["username"]="NK";
        s["password"]="123456";
        Console.WriteLine("User Logged In");
        Console.WriteLine("Username:"+s["username"]+"\t\tPassword:"+s["password"]+"\t\tEmail:"+s["email"]);    
        }

    }
}
