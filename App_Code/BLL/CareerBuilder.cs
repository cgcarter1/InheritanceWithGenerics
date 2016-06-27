using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChadCarter.CodeSample.BLL
{
    /// <summary>
    /// Summary description for CareerBuilder
    /// </summary>
    public class CareerBuilder
    {
        public CareerBuilder() { }

        // Given a string, write a function or method that takes in that string, and returns the same string in reverse order.
        // Example: Given the string “Hello”, your program would return “olleH”
        //  Do not assume that “Hello” is the only string it will handle
        public string ReverseOrder(string InputString)
        {
            if (String.IsNullOrEmpty(InputString))
            {
                return "Unable to determine reverse string.";
            }
            else
            {
                char[] CharArray = InputString.ToCharArray();
                Array.Reverse(CharArray);
                string reversed = new string(CharArray);
                return reversed;
            }
        }
        // Given a string, return the character count for each distinct character in the string.
        // Example: "abacca" -> a: 3, b: 1, c: 2
        // Once again, do not assume that “abacca” is the only string it will handle
        public string CountCharacterOccurenceOrdinally(string InputString)
        {
            if (String.IsNullOrEmpty(InputString))
            {
                return "Unable to determine character count.";
            }
            else
            {
                char[] CharArray = InputString.ToCharArray();
                char previous = char.MinValue;
                bool initial = true;
                System.Text.StringBuilder newString = new System.Text.StringBuilder();
                int count = 1;
                for (int i = 0; i <= CharArray.Length - 1; i++)
                {
                    if (initial == true)
                    {
                        previous = CharArray[i];
                        initial = false;
                    } 
                    else
                    {
                        if (previous == CharArray[i])
                        {
                            count++;
                        }
                        else
                        {
                            if (newString.Length == 0)
                            {
                                newString.Append(previous.ToString() + ": " + count.ToString());
                            }
                            else
                            {
                                newString.Append("," + previous.ToString() + ": " + count.ToString());
                            }                            
                            count = 1;
                            previous = CharArray[i];
                        }
                    }
                }
                return newString.ToString();
            }
        }
    }
}