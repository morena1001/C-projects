using System;

namespace TranslatorLogic;

public class RachzboTisgeo
{
    static bool bracketCounter = false;
    
    public static string RachzboTisgeoTranslator(string input)
    {
        bracketCounter = false;
        string output = "";

        for (int i = 0; i < input.Length; ++i)
        {
            char letter = input[i];

            if (letter == '[')
                bracketCounter = true;
            else if (letter == ']')
                bracketCounter = false;
            else
            {
                if (bracketCounter)
                    output += letter;
                else
                {
                    switch (letter)
                    {
                        case 'a':
                            output += "u";
                            break;
                        case 'A':
                            output += "U";
                            break;


                        case 'b':
                            output += "ñ";
                            break;
                        case 'B':
                            output += "Ñ";
                            break;


                        case 'c':
                            output += "z";
                            break;
                        case 'C':
                            output += "Z";
                            break;


                        case 'd':
                            output += "m";
                            break;
                        case 'D':
                            output += "M";
                            break;


                        case 'e':
                            output += "o";
                            break;
                        case 'E':
                            output += "O";
                            break;


                        case 'f':
                            output += "k";
                            break;
                        case 'F':
                            output += "K";
                            break;


                        case 'g':
                            output += "g";
                            break;
                        case 'G':
                            output += "G";
                            break;


                        case 'h':
                            output += "h";
                            break;
                        case 'H':
                            output += "H";
                            break;


                        case 'i':
                            output += "a";
                            break;
                        case 'I':
                            output += "A";
                            break;


                        case 'j':
                            output += "v";
                            break;
                        case 'J':
                            output += "V";
                            break;


                        case 'k':
                            output += "j";
                            break;
                        case 'K':
                            output += "J";
                            break;


                        case 'l':
                            output += "b";
                            break;
                        case 'L':
                            output += "B";
                            break;


                        case 'm':
                            output += "ch";
                            break;
                        case 'M':
                            output += "Ch";
                            break;


                        case 'n':
                            output += "s";
                            break;
                        case 'N':
                            output += "S";
                            break;


                        case 'o':
                            output += "i";
                            break;
                        case 'O':
                            output += "I";
                            break;


                        case 'p':
                            output += "l";
                            break;
                        case 'P':
                            output += "L";
                            break;


                        case 'q':
                            output += "n";
                            break;
                        case 'Q':
                            output += "N";
                            break;


                        case 'r':
                            output += "d";
                            break;
                        case 'R':
                            output += "D";
                            break;


                        case 's':
                            output += "r";
                            break;
                        case 'S':
                            output += "R";
                            break;


                        case 't':
                            output += "t";
                            break;
                        case 'T':
                            output += "T";
                            break;


                        case 'u':
                            output += "e";
                            break;
                        case 'U':
                            output += "E";
                            break;


                        case 'v':
                            output += "w";
                            break;
                        case 'V':
                            output += "W";
                            break;


                        case 'w':
                            output += "f";
                            break;
                        case 'W':
                            output += "F";
                            break;


                        case 'x':
                            output += "sh";
                            break;
                        case 'X':
                            output += "Sh";
                            break;


                        case 'y':
                            output += "y";
                            break;
                        case 'Y':
                            output += "Y";
                            break;


                        case 'z':
                            output += "p";
                            break;
                        case 'Z':
                            output += "P";
                            break;


                        case '0':
                            output += "podi";
                            break;


                        case '1':
                            output += "iso";
                            break;


                        case '2':
                            output += "tfi";
                            break;


                        case '3':
                            output += "thdoo";
                            break;


                        case '4':
                            output += "kied";
                            break;


                        case '5':
                            output += "kawo";
                            break;


                        case '6':
                            output += "rash";
                            break;


                        case '7':
                            output += "rowos";
                            break;


                        case '8':
                            output += "oaght";
                            break;


                        case '9':
                            output += "saso";
                            break;


                        default:
                            output += letter;
                            break;
                    }
                }
            }
        }

        return output;
    }
}
