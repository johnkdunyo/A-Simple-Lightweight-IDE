using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group10_IDE
{
    class Class1
    {
        public static int posChecker(string inputString)
        {
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
              };
            Stack<char> bracketStack = new Stack<char>();   //initialises new stack
            int pos = 0;
            char ww;

            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];
                if (bracketPairs.Keys.Contains(c))
                {
                    ww = c;
                    bracketStack.Push(c); //pushes c unto the stack
                    i++;
                    pos = i;
                }
                else
                        // check if the character is one of the 'closing' brackets
                        if (bracketPairs.Values.Contains(c))
                {
                   
                }


            }
            return pos;
        }
        
    }
}