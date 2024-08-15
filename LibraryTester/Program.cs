using Library1;
using static Library1.SimpleMath;
using static Library1.ShijomoTranslation;

namespace testingSite
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Waiting on intput");
                string? input;
                input = Console.ReadLine();
                //Console.WriteLine(test(input));
                Console.WriteLine(Numbers.NumsConverter(input));
            }
        }
    }
}