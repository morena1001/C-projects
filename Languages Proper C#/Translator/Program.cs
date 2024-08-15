using TranslatorLogic;
using static TranslatorLogic.RachzboTisgeo;

namespace Translator
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                string? input;
                input = Console.ReadLine();
                Console.WriteLine(RachzboTisgeoTranslator(input));
            }
        }
    }
}