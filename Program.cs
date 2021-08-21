using System;
using System.Collections.Generic;
using System.IO;
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
            GameUICreation();
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
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n" 
                + "If you want to quit the game hit the Q key\n");
            KeyCheck();
        }

        private static void GameTable()
        {
            Console.Clear();
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n"
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
            char UserPressedKey = StoreUserInput();
            char MachinePressedKey = MachineChoose();
            CheckChoosedOption(ref UserPressedKey, ref MachinePressedKey);
            Console.WriteLine("If you want a new game hit the E key \n" + "If you save your result hit the M key\n" + "If you want to quit hit the Q key\n");
            KeyCheck();
            SaveGameData(UserPressedKey, MachinePressedKey);

        }

        public static void SaveGameData(char UserPressedKey, char MachinePressedKey)
        {
            Console.WriteLine("Add your name: ");
            string Username = Console.ReadLine();
            string Userchoosedoption = "";
            string Machinechoosedoption = "";

            switch (UserPressedKey)
            {
                case 'P':
                    Userchoosedoption = "Paper";
                    break;
                case 'S':
                    Userchoosedoption = "Scissor";
                    break;
                case 'R':
                    Userchoosedoption = "Rock";
                    break;
                case 'L':
                    Userchoosedoption = "Lizard";
                    break;
                case 'V':
                    Userchoosedoption = "Spock";
                    break;
                default:
                    break;
            }

            switch (MachinePressedKey)
            {
                case 'P':
                    Machinechoosedoption = "Paper";
                    break;
                case 'S':
                    Machinechoosedoption = "Scissor";
                    break;
                case 'R':
                    Machinechoosedoption = "Rock";
                    break;
                case 'L':
                    Machinechoosedoption = "Lizard";
                    break;
                case 'V':
                    Machinechoosedoption = "Spock";
                    break;
                default:
                    break;
            }
            TextWriter saveddata = new StreamWriter("GameResult.txt");
            saveddata.WriteLine("User name: ", Username);
            saveddata.WriteLine("Choosed item by the User: ", Userchoosedoption);
            saveddata.WriteLine("Choosed item by the Machine: ", Machinechoosedoption);
        }

        private static void CheckChoosedOption(ref char UserPressedKey, ref char MachinePressedKey)
        {
            int UserPoint, MachinePoint;
            CheckPressedKey(ref UserPressedKey, ref MachinePressedKey, out UserPoint, out MachinePoint);
            PrintResult(UserPoint, MachinePoint);
        }

        private static void CheckPressedKey(ref char UserPressedKey, ref char MachinePressedKey, out int UserPoint, out int MachinePoint)
        {
            UserPoint = 0;
            MachinePoint = 0;
            if (UserPressedKey == MachinePressedKey)
            {
                UserPressedKey = StoreUserInput();
                MachinePressedKey = MachineChoose();
            }
            else
            {
                RulesCheck(UserPressedKey, MachinePressedKey, ref UserPoint, ref MachinePoint);
            }
        }

        private static void RulesCheck(char UserPressedKey, char MachinePressedKey, ref int UserPoint, ref int MachinePoint)
        {
            if ((UserPressedKey == 'S' && MachinePressedKey == 'P') || (UserPressedKey == 'L' && MachinePressedKey == 'P')
                || (UserPressedKey == 'P' && MachinePressedKey == 'R') || (UserPressedKey == 'V' && MachinePressedKey == 'R')
                || (UserPressedKey == 'R' && MachinePressedKey == 'L') || (UserPressedKey == 'S' && MachinePressedKey == 'L')
                || (UserPressedKey == 'L' && MachinePressedKey == 'V') || (UserPressedKey == 'P' && MachinePressedKey == 'V')
                || (UserPressedKey == 'V' && MachinePressedKey == 'S') || (UserPressedKey == 'R' && MachinePressedKey == 'S'))
            {
                UserPoint++;
            }
            else
            {
                MachinePoint++;
            }
        }

        private static void PrintResult(int UserPoint, int MachinePoint)
        {
            if (UserPoint > MachinePoint)
            {
                Console.WriteLine("You are WIN! :)");
            }
            else
            {
                Console.WriteLine("You are LOSE! :(");
            }
        }

        private static char MachineChoose()
        {
            char[] items = {'P','S','R','L','V'};
            char MachineChoosedItem;
            Random choose = new Random();
            int choose_helper = choose.Next(items.Length);
            MachineChoosedItem = items[choose_helper];
            return MachineChoosedItem;
        }


    }
}
