using System;

namespace Library1;

public class SimpleMath
{
    public static string Welcome()
    {
        return "Welcome to the SimpleMath class";
    }

    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static int Subtract(int x, int y)
    {
        return x - y;
    }

    public static int Multiply(int x, int y)
    {
        return x * y;
    }

    public static int Divide(int x, int y)
    {
        return x / y;
    }

    public readonly struct Fraction
    {
        private readonly int num;
        private readonly int den;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
                
            num = numerator;
            den = denominator;
        }
            
        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.num * b.num, a.den * b.den);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }

        public override string ToString() => $"{num} / {den}";
    }
}

public class ShijomoTranslation : ShijomoRules 
{
    public static string test(string input)
    {
        string output = "";
        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            
            output += input.Length > 2 && 
            input.Substring(input.Length - 3).Contains("ing") 
            ? input.Substring(0, input.Length - 3) + ing : input;
        }
        

        return output;
    }
}

public class ShijomoRules : Words
{
    // Making something past tense
    public static string pastTense = "ka";

    // Making something future tense
    public static string futureTense = "xu";

    // Making something plural
    public static string plural = "sa";

    // Act of doing something -ing
    public static string ing = "re";

    // Adds possesion
    public static string possess = "lo";

    // -ly word
    public static string ly = "ro";

    // verbs into nouns
    public static string VTN = "ru";

    // counting to place
    public static string CTP = "ko";



    public static string a = "hi";
}

public class Words : Trie
{

}

public class Numbers
{
    public static string zero = "para";
    public static string one = "shi";
    public static string two = "te";
    public static string three = "woo";
    public static string four = "limo";
    public static string five = "konu";
    public static string six = "chima";
    public static string seven = "raya";
    public static string eight = "juho";
    public static string nine = "furi";
    public static string ten = "rupa";

    public static string hundred = "hano";
    public static string thousand = "hashu";
    public static string million = "mathi";

    public static string pos = "chenu";
    public static string neg = "funa";

    public static string th = "ko";
    
    public static string NumsConverter(string input)
    {
        string temp = input;
        string output = "";

        if (temp[0] == '-')
        {
            output += neg + ' ';
            temp = temp.Substring(1);
        }

        if (input.Length > 1 && input.Substring(input.Length - 2).Contains("th"))
            temp = temp.Substring(0, input.Length - 2);

        int maxSize = temp.Length - 1;
        int index = temp.Length - 1;

        if (input == "0")
            return zero;

        foreach (char i in temp)
        {
            switch(index)
            {
                case 0: // ones place
                    output += NumFind(i);
                break;

                case 1: // tens place
                    if (i != '0')
                        output += NumFind(i) + "-rupa-";
                break;

                case 2: // hundreds place
                    if (i != '0')
                        output += NumFind(i) + "-hano-";
                break;

                case 3: // thousands place
                    if (i != '0')
                        output += NumFind(i) + "-tashu-";
                break;

                case 4: // tens thousands place
                    if (i != '0')
                        output += NumFind(i) + "-rupa-tashu-";
                break;

                case 5: // hundred thousands place
                    if (i != '0')
                        output += NumFind(i) + "-hano-tashu-";
                break;

                case 6: // millions place
                    if (i != '0')
                        output += NumFind(i) + "-mathi-";
                break;

                case 7: // ten millions place
                    if (i != '0')
                        output += NumFind(i) + "-rupa-mathi-";
                break;

                case 8: // hundred millions place
                    if (i != '0')
                        output += NumFind(i) + "-hano-mathi-";
                break;

                case 9: // billions place
                    if (i != '0')
                        output += NumFind(i) + "-tashu-mathi-";
                break;

                default:
                    output += "";
                break;
            }

            index--;
        }
        
        if (output[output.Length - 1] == '-')
            output = output.Substring(0, output.Length - 1);

        if (input.Length > 1 && input.Substring(input.Length - 2).Contains("th"))
            output += "-" + th;
            
        return output;
    }

    public static string NumFind(char input)
    {
        switch (input)
        {
            case '1':
                return one;

            case '2':
                return two;

            case '3':
                return three;

            case '4':
                return four;

            case '5':
                return five;

            case '6':
                return six;

            case '7':
                return seven;
            
            case '8':
                return eight;
            
            case '9':
                return nine;

            case '0':
                return "";

            default:
                return "ERROR";
        }
    }
}

public class Trie
{
   public class TrieNode
   {
       public Dictionary<char, TrieNode> children;
       public bool isWord;

       public TrieNode()
       {
           children = new Dictionary<char, TrieNode>();
           isWord = false;
       }
   }

   private readonly TrieNode root;

   public Trie()
   {
       root = new TrieNode();
   }

   public void Put(string word)
   {
       TrieNode current = root;
       foreach(char child in word)
       {  
           if (!current.children.ContainsKey(child))
           {
               TrieNode tmp = new TrieNode();
               current.children.Add(child, tmp);
               
           }
           current = current.children[child];
       }
       current.isWord = true;
   }

   public bool Contains(string word)
   {
       TrieNode current = root;
       foreach(char child in word)
       {
           if (current.children.ContainsKey(child))
           {
               current = current.children[child];
           }
           else
           {
               return false;
           }
       }
       return current.isWord;
   }

   public void Remove(string word)
   {
       Remove(root, word, 0);
   }

   private bool Remove(TrieNode current, string word, int depth)
   {
       if(depth == word.Length)
       {
           current.isWord = false;
       }
       else
       {
           char child = word[depth];
           if (current.children.ContainsKey(child))
           {
               if(Remove(current.children[child], word, depth + 1) == false)
               {
                   current.children.Remove(child);
               }
           }
       }

       if(current.children.Count > 0)
       {
           return true;
       }
       return false;
   }

   public List<string> StartsWith(string prefix)
   {
       List<string> res = new List<string>();

       TrieNode current = root;
       foreach(char child in prefix)
       {
           // If exists: iterate down.
           if (current.children.ContainsKey(child))
           {
               current = current.children[child];
           }
           // Else, return empty list.
           else
           {
               return res;
           }
       }
       // Now at prefix, go down the sub-trees and return.
       StartsWith(current, prefix, res);
       return res;
   }

   private void StartsWith(TrieNode current, string prefix, List<string> words)
   {
       if (current.isWord)
       {
           words.Add(prefix);
       }

       // Iterate the keys
       foreach(char key in current.children.Keys)
       {
           StartsWith(current.children[key], prefix + key, words);
       }
   }
}
