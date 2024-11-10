using System;
using System.Text;

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
        public static int Multiply(int a,int b)
        {
            return a * b;
        }

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
                            Console.WriteLine(Action.Multiply(a, b));
                        }
                        catch (OverflowException ex)
                        {
                            overflow.Append(i + ".txt\n");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    catch(Exception ex)
                    {
                        badData.Append(i + ".txt\n");
                        Console.WriteLine(ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    noFile.Append(i + ".txt\n");
                    Console.WriteLine(ex.Message);
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
        }
    }
}