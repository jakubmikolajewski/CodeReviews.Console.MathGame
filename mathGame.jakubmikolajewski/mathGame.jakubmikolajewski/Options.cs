using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class Options
    {
        public static bool ChoosePlayAgain()
        {
            Console.WriteLine("\nDo you want to play again (Y/N)?");
            return Validator.ValidateYesOrNoInput();
        }
        public static int ChooseDifficulty()//Return upper range of y depending on difficulty choice
        {           
            ShowDifficultyMenu();
            //Get and validate user's difficulty choice
            int input = Validator.ValidateIntInput();
            return SwitchDifficultyChoice(Validator.ValidateChoice(input, 1, 3));
        }
        public static (int, int) GameRandomizer() //Return random choices for the game instead of user input
        {
            Random random = new Random();
            int[] maxRange = {10, 100, 1000};
            return ((random.Next(1, 5)),maxRange[(random.Next(0, maxRange.Length))]);
        }
        private static void ShowDifficultyMenu()
        {
            Console.WriteLine("Choose the difficulty of your task: \n" +
                "1. Easy\n" +
                "2. Medium\n" +
                "3. Hard\n" +
                "\nEnter a corresponding value (1-3) to choose: \n");
        }
        private static int SwitchDifficultyChoice(int input)
        {
            int maxRange = 0;
            switch (input)
            {
                case 1:
                    maxRange = 10;
                    break;
                case 2:
                    maxRange = 100;
                    break;
                case 3:
                    maxRange = 1000;
                    break;
            }
            return (maxRange);
        }
    }
}
