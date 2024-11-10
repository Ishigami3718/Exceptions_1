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
            Action.NoFileWrite("10.txt");
            Action.NoFileWrite("11.txt");
        }
    }
}