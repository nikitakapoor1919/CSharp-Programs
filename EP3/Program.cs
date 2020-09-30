using System;
using System.IO;

namespace EP3
{
    class Program
    {
       public static void ReadFile(string file){
            try {
            using (StreamReader sr = new StreamReader(file)) {
               string line;

               // Read and display lines from the file until 
               // the end of the file is reached. 
               while ((line = sr.ReadLine()) != null) {
                  Console.WriteLine(line);
               }
            }
         } catch (FileNotFoundException e) {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
         }
       }
       static void Main(string[] args) {
        ReadFile("file.txt");
      }
    }
}
