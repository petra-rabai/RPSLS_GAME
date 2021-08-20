using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS_GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInitialize();
        }

        private static void GameInitialize()
        {
            GameDataCreation();
            GameUICreation();
        }

        private static void GameDataCreation()
        {
            //
        }

        private static void GameUICreation()
        {
            Console.Clear();
            Console.Title = "RPSLS GAME";
            Console.WriteLine("Welcome to the RPSLS Game\n" + "Rock, Paper, Scissor, Lizard, Spock\n" 
                + "If you need to read the game rules hit the H key\n" 
                + "Hit the E key to start the game or hit the Q key to quit the game\n"
                + "If you want to go back to the main screen hit the B key\n");
            KeyCheck();
        }

        private static void KeyCheck()
        {
            WaitForUser();
            char UserPressedKey = StoreUserInput();

            switch (UserPressedKey)
            {
                case 'H':
                    GameRulesHelper();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'B':
                    GameUICreation();
                    break;
                case 'E':
                    GameTable();
                    break;
                default:
                    break;
            }
        }

        private static char StoreUserInput()
        {
            ConsoleKeyInfo Hitkey = Console.ReadKey();
            char UserPressedKey = Char.Parse(Hitkey.Key.ToString());
            return UserPressedKey;
        }

        private static void WaitForUser()
        {
            Console.WriteLine("Wait for user input: ");
            Console.Beep();
        }

        private static void GameRulesHelper()
        {
            Console.Clear();
            Console.WriteLine("The Game rules: ");
            Console.WriteLine("Scissors cuts Paper\n" + "Paper covers Rock\n" + "Rock crushes Lizard\n" + "Lizard poisons Spock\n"
                + "Spock smashes Scissors\n" + "Scissors decapitates Lizard\n" + "Lizard eats Paper\n" + "Paper disproves Spock\n"
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n");
            KeyCheck();
        }

        private static void GameTable()
        {
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n" 
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
            char UserPressedKey = StoreUserInput();
            char MachinePressedKey = MachineChoose();
        }

        private static char MachineChoose()
        {
            char[] items = {'P','S','R','L','V'};
            char MachineChoosedItem;
            Random choose = new Random();
            MachineChoosedItem = Char.Parse(choose.Next(items.Length).ToString());
            return MachineChoosedItem;
        }

    }
}
