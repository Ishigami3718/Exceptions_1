using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;

namespace Lab
{
    class Action
    {
        public static string[] Read(string name)
        {
            string[] res = File.ReadAllLines(@$"data\{name}");
            return res;
        }

        public static int TryParse(string inp)
        {
            return int.Parse(inp);
        }
        /*public static int TryMultiply(int a,int b)
        {
            return a * b;
        }*/

        public static void NoFileWrite(StringBuilder sb,string file)
        {
            try
            {
                using (TextWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(sb);
                }
            }
            catch
            {
                File.Create(file).Close();
                using (TextWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(sb);
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder noFile = new StringBuilder();
            StringBuilder badData = new StringBuilder();
            StringBuilder overflow = new StringBuilder();
            int res = 0;
            int count = 0;
            for(int i = 10; i < 30; i++)
            {
                try
                {
                    string[] inp = Action.Read($"{i}.txt");
                    try
                    {
                        int a = Action.TryParse(inp[0]);
                        int b = Action.TryParse(inp[1]);
                        try
                        {
                            checked 
                            {
                                res+=a*b;
                            }
                            count++;
                        }
                        catch(OverflowException ox)
                        {
                            Console.Write($"File {i}: ");
                            overflow.Append(i + ".txt\n");
                            Console.WriteLine(ox.Message);
                        }
                    }
                    catch
                    {
                        Console.Write($"File {i}: ");
                        badData.Append(i + ".txt\n");
                        Console.WriteLine(new Exception($"Data in file {i}.txt isnt normal").Message);
                    }
                }
                catch
                {
                    Console.Write($"File {i}: ");
                    noFile.Append(i + ".txt\n");
                    Console.WriteLine(new Exception($"File {i}.txt doesnt excist").Message);
                }
            }
            try
            {
                Action.NoFileWrite(noFile, @"exceptionData\no_file.txt");
                Action.NoFileWrite(badData, @"exceptionData\bad_data.txt");
                Action.NoFileWrite(overflow, @"exceptionData\overflow.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine((double)res/count);
        }
    }
}