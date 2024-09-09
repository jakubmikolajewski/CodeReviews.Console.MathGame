using System;
using System.Diagnostics;

namespace MathGame
{
    public class Game
    {
        public static string winMessage = "Correct! You win :)!";
        public static string loseMessage = "Incorrect. You lose :(.";
        public static void InitializeGame(int choice, int maxRange = 0)
        {
            /*Check if maxRange was specified through GameRandomizer (option 5 was chosen),
            otherwise let user choose difficulty*/
            if (maxRange != 10 && maxRange != 100 && maxRange != 1000) 
                maxRange = Options.ChooseDifficulty(); 
            
            (string message, int operationResult) chosenOperation = SwitchChoice(choice, maxRange);
            //Display challenge to user
            Console.WriteLine(chosenOperation.message); 

            (string attemptSeconds, int input) measuredAttempt = MeasureAttempt();

            WinOrLose(measuredAttempt.input, chosenOperation.operationResult);

            Logs.GatherLogs(measuredAttempt.attemptSeconds, measuredAttempt.input,
                chosenOperation.message, chosenOperation.operationResult); 
        }
        public static (string, int) SwitchChoice(int choice, int maxRange) //Return appropriate message and result of the operation depending on choice
        {
            (string message, int operationResult) chosenOperation = ("", 0);
            (int x, int y) operationXY = (GenerateXY(maxRange));
            switch (choice)
            {
                case 1:
                    //Randomize x and y until the division's result is an int
                    (int x, int y) divisionXY = Validator.ValidateDivision(maxRange); 
                    chosenOperation = ($"Please solve the following division: {divisionXY.x} : {divisionXY.y} = ?", (divisionXY.x / divisionXY.y));
                    break;
                case 2:
                    chosenOperation = ($"Please solve the following multiplication: {operationXY.x} * {operationXY.y} = ?", (operationXY.x * operationXY.y));
                    break;
                case 3:
                    chosenOperation = ($"Please solve the following addition: {operationXY.x} + {operationXY.y} = ?", (operationXY.x + operationXY.y));
                    break;
                case 4:
                    chosenOperation = ($"Please solve the following subtraction: {operationXY.x} - {operationXY.y} = ?", (operationXY.x - operationXY.y));
                    break;
            }
            return chosenOperation;
        }
        private static (int, int) GenerateXY(int maxRange)
        {
            Random random = new Random();
            int x = random.Next(1, maxRange);
            int y = random.Next(2, maxRange);
            return (x, y);
        }
        private static (string, int) MeasureAttempt() //Return elapsed time and user's answer
        {
            Stopwatch measureAttempt = Stopwatch.StartNew();
            //Get and validate user's answer
            int input = Validator.ValidateIntInput(); 

            measureAttempt.Stop();
            TimeSpan attempt = measureAttempt.Elapsed;
            string attemptSeconds = String.Format("{0:00}.{1:00}", attempt.Seconds, attempt.Milliseconds / 10);
            Console.WriteLine($"\nYou answered in {attemptSeconds} seconds.\n");
            return (attemptSeconds, input);
        }
        private static void WinOrLose(int input, int operationResult)
        {
            if (input == operationResult)
                Console.WriteLine(winMessage);
            else
                Console.WriteLine(loseMessage + $"\nThe correct answer was: {operationResult}");
        }
    }

}