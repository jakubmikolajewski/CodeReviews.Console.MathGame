using MathGame;

internal class MathGameMain
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the MathGame!");
        bool playAgain = true;
        while (playAgain)
        {
            ShowMenu();
            //Get and validate user's menu choice
            int input = Validator.ValidateIntInput(); 
            ChooseMenuOption(Validator.ValidateChoice(input, 1, 6));

            playAgain = Options.ChoosePlayAgain();
            Console.Clear();
        }
    }   
    private static void ShowMenu()
    {
        Console.WriteLine("Please choose a mode from the menu:\n" +
                "1. Division\n" +
                "2. Multiplication\n" +
                "3. Addition\n" +
                "4. Subtraction\n" +
                "5. Random Game\n" +
                "6. Show previous results\n" +
                "\nEnter a corresponding value (1-6) to choose: ");
    }
    private static void ChooseMenuOption(int input)
    {
        switch (input)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                Game.InitializeGame(input);
                break;
            case 5:
                (int input, int maxRange) randomProperties = Options.GameRandomizer();
                Game.InitializeGame(randomProperties.input, randomProperties.maxRange);
                break;
            case 6:
                Logs.DisplayAllLogs();
                break;
        }
    }
}