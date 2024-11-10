using System;
using System.Text;

namespace Lab
{
    class Action
    {
        public static string[] Read(string name)
        {
            string[] res = File.ReadAllLines(name);
            return res;
        }

        public static int Multiply(int a,int b)
        {
            return a * b;
        }

        public static void NoFileWrite(StringBuilder sb)
        {
            try
            {
                using (TextWriter sw = new StreamWriter("no_file.txt"))
                {
                    sw.WriteLine(sb);
                }
            }
            catch
            {
                File.Create("no_file.txt").Close();
                using (TextWriter sw = new StreamWriter("no_file.txt"))
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
            for(int i = 10; i < 30; i++)
            {
                try
                {
                    string[] inp = Action.Read($"{i}.txt");
                    try
                    {
                        int mul = Action.Multiply(int.Parse(inp[0]), int.Parse(inp[1]));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    noFile.Append(i + ".txt\n");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}