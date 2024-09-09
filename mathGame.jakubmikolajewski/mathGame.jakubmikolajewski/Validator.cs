using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class Validator
    {
        public static int ValidateIntInput() //Return only int values provided by user
        {
            string? readResult;
            bool validInput = false;
            int input = 0;
            do
            {
                readResult = Console.ReadLine();
                if (readResult is not null)
                {
                    validInput = (int.TryParse(readResult, out input));
                    if (validInput)
                    {
                        break;
                    }
                    else
                        Console.WriteLine($"Please input a valid number. Your input was {readResult}.");
                }
                else
                    Console.WriteLine($"Please input a valid number. Your input was null.");
            } while (!validInput);
            return input;
        }
        public static bool ValidateYesOrNoInput() //Return true/false only if input is Y/N
        {
            bool yesOrNo = false;
            string? readResult;
            string input = "";
            do
            {
                readResult = Console.ReadLine();
                if (readResult is not null)
                {
                    input = readResult.ToUpper().Trim();
                    if (input.Equals("Y"))
                    {
                        yesOrNo = true;
                        break;
                    }
                    else if (input.Equals("N"))
                    {
                        yesOrNo = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Please input (Y/N) to choose if you want to play again. Your input was {readResult}.");
                    } 
                }
                else
                    Console.WriteLine($"Please input (Y/N). Your input was null.");
            } while (input != "Y" && input != "N");
            return yesOrNo;
        }
        public static (int, int) ValidateDivision(int maxRange) //Randomize x and y until the division's result is an int (and divisor not 1 or x)
        {
            Random random = new Random();
            int x = 0;
            int y = 0;
            bool validDivision = false;

            while (!validDivision)
            {
                x = random.Next(1, maxRange);
                y = random.Next(2, maxRange);
                validDivision = (x % y == 0) ? true : false;
                if (validDivision && (x / y != 1))
                    validDivision = true;
                else
                    validDivision = false;
            }
            return (x, y);
        }
        public static int ValidateChoice(int input, int lowerRange, int upperRange)//Return choice only if input is a valid menu choice
        {
            while (input < lowerRange || upperRange < input)
            {
                Console.WriteLine($"Please choose a valid option ({lowerRange}-{upperRange}): ");
                input = Validator.ValidateIntInput();
            }
            return input;
        }
    }
}
