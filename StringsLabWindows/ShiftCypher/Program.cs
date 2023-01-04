using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is problems 5 and 6 from the lab 
            Console.WriteLine("Please enter a word or phrase you would like to encode: ");
            string input = Console.ReadLine();

            RightShiftCypher(input);
            Console.WriteLine();

            LeftShiftCypher(input);
            Console.WriteLine();

            string shift3 = RandomShift(input);
            Console.WriteLine("The random shift is: " + shift3);

            Console.ReadLine();
        }

        //shifts the cypher to the right
        static void RightShiftCypher(string input)
        {
            Console.Write("The right shift is: ");
            //splits the input string up into chars
            char[] charArray = input.ToCharArray();
            foreach(char ch in charArray)
            {
                int asciiofCh = (int)ch;
                //checks for letter z and makes sure it swaps with a 
                if (asciiofCh >= 122)
                {
                    asciiofCh = asciiofCh - 26;
                }
                //this does the shift to the right
                char chPlus1 = (char)(asciiofCh + 1);
           
                Console.Write(chPlus1);
            }
            
        }

        // shifts the cypher to the left
        static void LeftShiftCypher(string input)
        {
            Console.Write("The left shift is: ");
            char[] charArray = input.ToCharArray();
            foreach (char ch in charArray)
            {
                int asciiofCh = (int)ch;
                //checks for letter a and makes sure it waps with z
                if (asciiofCh <= 97)
                {
                    asciiofCh = asciiofCh + 26;
                }
                //this does the shift to the left
                char chMin1 = (char)(asciiofCh - 1);

                Console.Write(chMin1);
            }

        }

        static string RandomShift(string input)
        {

            string shiftStr = null;
            Random gen = new Random();
            int shiftVal = gen.Next(-11, 11);
           
            

            string[] words = input.Split(' ');

            foreach(var word in words)
            {
                char[] chars = word.ToCharArray();
                foreach (char ch in chars)
                {
                    int asciiOfCh = (int)ch;
                    if( asciiOfCh >= 122)
                    {
                        asciiOfCh = asciiOfCh - 26;                        
                    }
                    else if(asciiOfCh <= 97)
                    {
                        asciiOfCh = asciiOfCh + 26;
                    }
                    char chShift = (char)(asciiOfCh + shiftVal);
                    shiftStr = chShift.ToString();
                    String.Join(" ", shiftStr);
                }
                
            }
            return shiftStr;
        }
    }
}
