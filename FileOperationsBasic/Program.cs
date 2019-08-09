using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileOperationsBasic
{
    class Program
    {
        static void WriteFile(string Filename)
        {
            //File.Create(Filename);
            
            FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            if (fs.CanWrite)
            {
                byte[] bytes=Encoding.Default.GetBytes("Hello World!");
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
                fs.Close();
            }           
        }

        static void ReadFile(string Filename)
        {
            FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read);
            if (fs.CanRead)
            {
                byte[] bytes=new byte[1024];
                int bytesread = fs.Read(bytes, 0, bytes.Length);
                Console.WriteLine(Encoding.ASCII.GetString(bytes,0,bytes.Length));
                Console.WriteLine(fs.Length);
                fs.Flush();
                fs.Close();
            }
            //Console.WriteLine(File.ReadAllText(Filename));
        }

        static void Main(string[] args)
        {
            //int x = 256;
            string Filename = @"H:\FileOperationsExampleFiles\Example.txt";
            
            
            try
            {
                WriteFile(Filename);
                ReadFile(Filename);

                //byte b = Convert.ToByte("");
                //Console.WriteLine(b.ToString());
            }
            catch (Exception ex)
            {
                //if (x > 255)
                //{
                //    Console.WriteLine("Xception Captured");
                //    Console.WriteLine("Please enter value less than 255");
                //}
            }
            finally
            {
               
            }
        }
    }
}
