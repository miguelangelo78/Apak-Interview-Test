using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApakQuestion2InfixToPostFix
{
    class Program
    {
        static void Main(string[] args)
        {
            showCalculation("1+1");
            showCalculation("3+2-1");

            Console.ReadKey();
        }

        public static void showCalculation(string calculation)
        {
            string postFix = convertToPostFix(calculation);
            int result = calculatePostFix(postFix);

            Console.WriteLine("(Infix) " + calculation + " => (Postfix) " + postFix + "\n");
            Console.WriteLine("Result: " + calculation + "=" + result + "\n\n");
        }

        private static string convertToPostFix(string infixInput)
        {
            Stack<char> stack = new Stack<char>();
            string postFix = "";
            
            foreach(char c in infixInput)
            {
                if(c == ' ')
                {
                    continue;
                }
                else if(c == '+' || c == '-')
                {
                    if(stack.Count == 0)
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        while(stack.Count > 0)
                        {
                            postFix += stack.Pop();
                        }

                        stack.Push(c);
                    }
                }
                else
                {
                    postFix += c;
                }
            }

            while (stack.Count > 0)
            {
                postFix += stack.Pop();
            }

            return postFix;
        }

        private static int calculatePostFix(string postFixInput)
        {
            Stack<int> calcStack = new Stack<int>();

            foreach(var c in postFixInput)
            {
                if(c == '+' || c == '-')
                {
                    int num2 = calcStack.Pop();
                    int num1 = calcStack.Pop();

                    if(c == '+')
                    {
                        calcStack.Push(num1 + num2);
                    }
                    else
                    {
                        calcStack.Push(num1 - num2);
                    }
                }
                else
                {
                    calcStack.Push(int.Parse(c + ""));
                }
            }

            return calcStack.Peek();
        }
    }
}
