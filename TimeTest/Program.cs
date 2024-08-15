using System;
using Microsoft.VisualBasic;

namespace TimeTest
{
    class Program
    {
        static string path = @"C:\Users\josue\C# Projects\TimeTest\TimeSave.txt";

        static void Main()
        {
            string previousTime = File.ReadAllText(path);
            string CurrentTime = DateTime.Now.ToString();

            var date1 = DateTime.Parse(previousTime);
            var date2 = DateTime.Parse(CurrentTime);

            TimeSpan elapsedTime = date2 - date1;
            Console.WriteLine(elapsedTime.ToString());
            Console.WriteLine(elapsedTime.TotalMilliseconds);

            File.WriteAllText(path, DateTime.Now.ToString());
        }
    }
}