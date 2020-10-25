using System;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{

    /// <summary>
    /// Inputs                     | Outputs
    /// "13 0123456789abcdef 01"   | 10011
    /// "9 0123456789 oF8"         | Foo
    /// "Foo oF8 0123456789"       | 9
    /// For first input
    /// 13 is encoded alphanumeric
    /// 0123456789abcdef is source language
    /// 01 is target language
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var incomingMessage = Console.ReadLine();

            if (!string.IsNullOrEmpty(incomingMessage))
            {
                string[] incomingMessageParts = incomingMessage.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (incomingMessageParts.Length == 3)
                {
                    var encodedAlphaNumCode = incomingMessageParts[0];
                    var sourceLang = incomingMessageParts[1].ToList();
                    var targetLang = incomingMessageParts[2].ToList();

                    //convert input to decimal
                    int baseSystem = sourceLang.Count();
                    int inputDecimalNumber = 0;
                    for (int index = 0; index < encodedAlphaNumCode.Length; index++)
                    {
                        var decimalValueInMsg = sourceLang.IndexOf(encodedAlphaNumCode[index]);

                        inputDecimalNumber = inputDecimalNumber + (decimalValueInMsg * (int)Math.Pow(baseSystem, (encodedAlphaNumCode.Length - (index + 1))));
                    }

                    //convert the newly found decimal value to format as per expected output
                    int newBaseSystem = targetLang.Count();

                    int quotient = inputDecimalNumber / newBaseSystem;
                    int remainder = inputDecimalNumber % newBaseSystem;
                    StringBuilder stringBuilder = new StringBuilder(remainder.ToString());

                    while (quotient > 0)
                    {
                        stringBuilder.Append(quotient % newBaseSystem);
                        quotient = quotient / newBaseSystem;
                    }

                    var valueToSend = stringBuilder.ToString().Reverse().ToArray();

                    Console.WriteLine(new string(valueToSend));

                }
                else
                {
                    throw new Exception("Invalid input");
                }
            }
            else
            {
                throw new Exception("Invalid input");
            }


        }
    }
}
