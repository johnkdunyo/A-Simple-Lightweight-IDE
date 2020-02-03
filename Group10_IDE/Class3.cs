using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group10_IDE
{
    class Class3
    {
        public static int positionUnbalanced(string inputString)
        {
            Stack<char> stack = new Stack<char>();
            int pos = -1;

            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];

                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        pos = i;
                        break;
                    }
                }
            }

            return pos;
        }
    }
}
