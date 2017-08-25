using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                Console.WriteLine("{0} Enter command.", timestamp);
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "csv":
                    case "csvtool":
                        {
                            CSVtool.Menu();
                            break;
                        }
                    case "exit":
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
    class CSVtool
    {
        public static void Menu()
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string docsPath = System.IO.Path.Combine(myDocs, "testFiles");
            //Console.WriteLine("My Documents: {0}", docsPath);

            #region Abandoning because of URI bullshit
            //string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            ////string pathExtension = "\\files"; //double backslash needed to prevent \f
            //string folderName = "files";
            //var directory = System.IO.Path.GetDirectoryName(path);

            //string pathString = System.IO.Path.Combine(directory, folderName); //add "files" to file path

            //Console.WriteLine(path);
            ////Console.WriteLine(directory + pathExtension);
            //Console.WriteLine(pathString);
            #endregion

            Console.WriteLine("\n{0} CSVtool started. Enter command.", timestamp);
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "create":
                    {
                        CSVtool.Create(docsPath);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        static void Create(string directory)
        {
            Console.WriteLine("Current directory: {0}", directory);
            Console.WriteLine("Enter to continue.");
            Console.ReadLine();

            //Create directory if it doesn't already exist
            if (!System.IO.Directory.Exists(directory))
            {
                Console.WriteLine("Directory not found -- creating {0}", directory);
                System.IO.Directory.CreateDirectory(directory);
            }
            else
            {
                Console.WriteLine("Directory found: {0}", directory);
            }

            //dummy CSV setup
            Console.WriteLine("Input csv name (including .csv):");
            //can obviously add failsafes to input in a hypothetical larger version (with a while loop), 
            //  eg, making sure .csv exists and adding if it doesn't, checking for troublesome characters,
            //  checking if file already exists
            string fileName = Console.ReadLine();

            string filePath = System.IO.Path.Combine(directory, fileName);
            string delim = ",";
            
            string[][] arr = new string[][]
            {
                new string[] {"i1j1", "i1j2", "i1j3"},
                new string[] {"i2j1", "i2j2", "i2j3"}
            };

            int arrLength = arr.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrLength; i++)
            {
                sb.AppendLine(string.Join(delim, arr[i]));
            }

            File.WriteAllText(filePath, sb.ToString());

            Console.WriteLine("Dummy matrix saved at {0}", filePath);
        }

        static void Read()
        {
            //
            //To be continued
            //
        }
    }
}
