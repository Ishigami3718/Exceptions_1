using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;

namespace Lab
{
    class Program
    {
        public static void NoFileWrite(StringBuilder sb, string file)
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
                    string[] inp = File.ReadAllLines(@$"data\{i}.txt");
                        int a = int.Parse(inp[0]);
                        int b = int.Parse(inp[1]);
                            checked 
                            {
                                res+=a*b;
                            }
                            count++;
                }
                catch(FileNotFoundException)
                {
                    noFile.Append(i + ".txt\n");
                    Console.WriteLine(new Exception($"File {i}.txt doesnt excist").Message);
                }
                catch(FormatException)
                {
                    badData.Append(i + ".txt\n");
                    Console.WriteLine(new Exception($"Data in file {i}.txt isnt normal").Message);
                }
                catch (IndexOutOfRangeException)
                {
                    badData.Append(i + ".txt\n");
                    Console.WriteLine(new Exception($"Data in file {i}.txt isnt normal").Message);
                }
                catch (OverflowException)
                {
                    Console.Write($"File {i}: ");
                    overflow.Append(i + ".txt\n");
                    Console.WriteLine(new Exception("int type overflow(after multiply)").Message);
                }
            }
            try
            {
                NoFileWrite(noFile, @"exceptionData\no_file.txt");
                NoFileWrite(badData, @"exceptionData\bad_data.txt");
                NoFileWrite(overflow, @"exceptionData\overflow.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine((double)res/count);
        }
    }
}