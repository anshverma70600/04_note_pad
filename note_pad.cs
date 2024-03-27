using static System.Console;
using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Note_pad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file name : ");
            string name = Console.ReadLine();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, $"{name}.txt");
            bool fileExists = System.IO.File.Exists(filePath);

            if (fileExists)
            {
                Console.WriteLine("File exists !! ");
                WriteLine();
                Console.WriteLine("Press 1 - for (View content)");
                Console.WriteLine("Press 2 - for (Add content)");
                Console.WriteLine("Press 3 - for (delete file)");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        WriteLine("Opening file......  ");
                        Thread.Sleep(1000);
                        WriteLine();
                        StreamReader sread = File.OpenText(filePath);
                        WriteLine(sread.ReadToEnd());
                        WriteLine();
                        sread.Close();
                        break;
                    case 2:
                        WriteLine("type..... ");
                        Thread.Sleep(1000);
                        WriteLine();
                        string input = Console.ReadLine();
                        File.AppendAllText(filePath, input);
                        break;
                    case 3:
                        WriteLine("Deleting file.... !!");
                        Thread.Sleep(1000);
                        WriteLine();
                        File.Delete(filePath);
                        WriteLine("File Deleted Successfully");
                        break;
                    default:
                        WriteLine("Invalid Input..!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Creating new file....");
                
                WriteLine();
                File.Create(filePath).Dispose();                            //dispose use for object clean-up
                WriteLine("Type..");
                WriteLine();
                StreamWriter swrite = File.AppendText(filePath);
                string input = String.Empty;
                do
                {
                    input = Console.ReadLine();
                    if (input != null)
                    {
                        swrite.WriteLine(input);
                    }
                } while (input != "");
                swrite.Close();
                Console.WriteLine("file created successfully.");
                WriteLine();
            }
        }
    }
}
