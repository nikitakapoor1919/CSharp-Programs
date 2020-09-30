using System;
using System.IO;

namespace EP4
{
    class Program
    {
        static bool FileEquals(string path1, string path2)
        {
             try 
            {
                byte[] file1 = File.ReadAllBytes(path1);
                byte[] file2 = File.ReadAllBytes(path2);
                if (file1.Length == file2.Length)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        if (file1[i] != file2[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }catch (FileNotFoundException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine("File Not Found Exception: "+e.Message);
            }
            catch (IOException e){
                Console.WriteLine("IO Exception: "+e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("Exception: "+e.Message);
            }
            return false;
        }
        static void copyBytes(string sourcePath,string destPath){
            try
            {
                using (FileStream fsSource = new FileStream(sourcePath,FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                        if (n == 0)
                            break;
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;
                    // Write the byte array to the other FileStream.
                    using (FileStream fsNew = new FileStream(destPath,FileMode.Create, FileAccess.Write))
                    {
                        fsNew.Write(bytes, 0, numBytesToRead);
                    }
                    Console.WriteLine("File Copied!!");
                }
            }
            catch (IOException e){
                Console.WriteLine("IO Exception: "+e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("Exception: "+e.Message);
            }
        }
        static void Main(string[] args)
        {
            var sourcePath = "source.txt";
            var destPath = "destination.txt";

            try {
                if (!File.Exists(sourcePath)){
                    using (BinaryWriter binWriter =  new BinaryWriter(File.Open(sourcePath, FileMode.Create)))  
                    {    
                        binWriter.Write("This is EP4 of C# Assignment.\nThis is my content.");    
                    } 
                    Console.WriteLine("Binary File Created!!");
                }
            } catch (IOException e){
                Console.WriteLine("IO Exception: "+e.Message);
            }
            copyBytes(sourcePath,destPath);
            bool a = FileEquals(sourcePath, destPath);
            Console.WriteLine("Both Files Equal: "+a);   
        }
    }
}
