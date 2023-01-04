using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //prompts user for input word
            Console.WriteLine("Please enter a word or phrase.  Press the ENTER key when you're done.");
            string s = Console.ReadLine();

            
            //calls IndexOfFirstVowel and prints it 
            int vIndex = IndexOfFirstVowel(s);
            Console.WriteLine("The index of the first vowel is: " + vIndex);
            Console.WriteLine();

          

            //calls PigLatin
            string pig1 = PigLatin1(s);
            Console.WriteLine("The word {0} in pig latin is: {1}", s, pig1);
            Console.WriteLine(); 
            

            //calls SplitTranslate to translate a sentence
            string pig2 = SplitTranslate(s);
            Console.WriteLine("The sentance {0} in pig latin is: {1}", s, pig2);

            

            Console.ReadLine();
        }

        //finds the index of the first vowel in the string s
        static int IndexOfFirstVowel(string s)
        {
            int vIndex = -1;
            for (int i = 0; i < s.Length && vIndex == -1; i++)
            {
                char c = s[i];
                if (IsVowel(c))
                    vIndex = i;
            }
            
            return vIndex;
        }

        //converts the vowel to lower case
        static bool IsVowel(char c)
        {
            c = Char.ToLower(c);
            string vowels = "aeiou";
            return vowels.Contains(c.ToString());

        }

        //Condensed the 3 pig latin methods into one to keep things cleaner, also fixed a previous issue with problem 01
        static string PigLatin1(string s)
        {
            //here are my local variables
            string pig;
                //this one here specifically calls IndexOfFirestVowel and assigns it as the value of vIndex
            int vIndex = IndexOfFirstVowel(s);
            bool uCase = char.IsUpper(s[0]);
            //variable for the final index in s
            int last = s.Length - 1;
            char plHolder = ' ';
            bool pun = char.IsPunctuation(s[last]);

            if (uCase == true)
                s = char.ToLower(s[0]) + s.Substring(1);

            if (pun == true)
            {
                plHolder = s[last];
                s = s.Remove(last);
            }

            
            if (IsVowel(s[0]))
                pig = s + "way";
            else if (vIndex > 1)
                pig = s.Substring(vIndex) + s.Substring(0, vIndex) + "ay";

            else
                pig = s.Substring(1) + s[0] + "ay";

          
            if (uCase == true)
                pig = char.ToUpper(pig[0]) + pig.Substring(1);

           
            if (pun == true)
                pig = pig + plHolder;

            return pig;
        }

        static string SplitTranslate(string s)
        {
            string pig = ("");
           
          
            //creates the string words out of our string s
            string[] words = s.Split();
            //runs through each word in the sentance, translating it
            foreach (string word in words)
            {
                pig += PigLatin1(word) + " ";
                String.Join(" ", pig);
                
            }
            

            return pig;
        }
            
        
    }
}
