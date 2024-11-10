using System;
namespace Lab
{
    class MyExceptions
    {
        private Exception ex1 = new Exception("Such file doesnt exist");
        private Exception ex2 = new OverflowException();
        private Exception ex3 = new Exception("digits arent int");
        public void TryRead(string name)
        {
            try
            {
                IDK.Read(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class IDK
    {
        static public void Read(string name)
        {
            StreamReader sr = new StreamReader(name);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}