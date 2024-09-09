using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Logs
    {
        private static List<string> logs = new List<string>();
        public static void DisplayAllLogs()
        {
            foreach (string log in logs)
            {
                Console.WriteLine(log);
            }
        }
        public static void GatherLogs(string attemptSeconds, int input, string message, int operationResult)
        {
            string log = "";
            if (input == operationResult)
                log = ($"\n{message}\n{input}\n{Game.winMessage}\nYou answered in {attemptSeconds} seconds.");
            else
                log = ($"\n{message}\n{input}\n{Game.loseMessage}\nYou answered in {attemptSeconds} seconds.\nThe correct answer was: {operationResult}");
            logs.Add(log);
        }
    }
}
