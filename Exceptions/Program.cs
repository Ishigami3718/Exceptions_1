﻿using System;
namespace Lab
{
    class MyExceptions
    {
       static private Exception ex1 = new Exception("Such file doesnt exist");
       static private Exception ex2 = new OverflowException();
       static private Exception ex3 = new Exception("digits arent int");
       static public void TryRead(string name)
        {
            try
            {
                IDK.Read(name);
            }
            catch
            {
                IDK.WriteNonExistentFiles(name);
                Console.WriteLine(ex1.Message);
            }
        }
    }

    class IDK
    {
        static public void Read(string name)
        {
            StreamReader sr = new StreamReader(name);
        }

        static public void WriteNonExistentFiles(string name)
        {
            StreamWriter sw1 = new StreamWriter("no_file.txt");
            sw1.WriteLine(name);
            sw1.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            File.Create("no_file.txt").Close();
            MyExceptions.TryRead("10.txt");
            MyExceptions.TryRead("11.txt");
            MyExceptions.TryRead("11.txt");
        }
    }
}