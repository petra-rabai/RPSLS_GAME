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
            UISetup();
        }

        private static void UISetup()
        {
            Console.Clear();
            Console.Title = "RPSLS GAME";
            Console.WriteLine("Welcome to the RPSLS Game\n" + "Rock, Paper, Scissor, Lizard, Spock\n"
                + "If you need to read the game rules hit the H key\n"
                + "Hit the E key to start the game or hit the Q key to quit the game\n"
                + "If you want to go back to the main screen hit the B key\n");
            UserAction();
        }

        private static void UserAction()
        {
            char UserPressedKey;
            WaitForUser();
            UserPressedKey = StoreUserInput();
            UserPressedKey = PressedKeyValidation(UserPressedKey);
            ChoosedOptionValidation(UserPressedKey);
        }

        private static void ChoosedOptionValidation(char UserPressedKey)
        {
            switch (UserPressedKey)
            {
                case 'H':
                    GameRulesHelper();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'B':
                    UISetup();
                    break;
                case 'E':
                    GameTable();
                    break;
                default:
                    break;
            }
        }

        private static char PressedKeyValidation(char UserPressedKey)
        {
            while ((UserPressedKey != 'H') && (UserPressedKey != 'Q') && (UserPressedKey != 'B') && (UserPressedKey != 'E'))
            {
                Console.Clear();
                Console.WriteLine("Please hit a valid key: \n" + "Valid keys are: \n" + "H - Help\n" + "E - Start the Game \n" +
                    "Q - Quit the Game\n" + "B - Back to the Main screen\n");
                WaitForUser();
                UserPressedKey = StoreUserInput();
            }

            return UserPressedKey;
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
            HelperUI();
            UserAction();
        }

        private static void HelperUI()
        {
            Console.WriteLine("The Game rules: ");
            Console.WriteLine("Scissors cuts Paper\n" + "Paper covers Rock\n" + "Rock crushes Lizard\n" + "Lizard poisons Spock\n"
                + "Spock smashes Scissors\n" + "Scissors decapitates Lizard\n" + "Lizard eats Paper\n" + "Paper disproves Spock\n"
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n"
                + "If you want to quit the game hit the Q key\n");
        }

        private static void GameTable()
        {
            char UserPressedKey, MachinePressedKey;
            GameStart();
            GameLogic(out UserPressedKey, out MachinePressedKey);
            SaveGameData(UserPressedKey, MachinePressedKey);
            GameFinalize();
        }

        private static void GameLogic(out char UserPressedKey, out char MachinePressedKey)
        {
            UserPressedKey = StoreUserInput();
            MachinePressedKey = MachineChoose();
            UserPressedKey = ChoosedKeyValidation(UserPressedKey);
            CheckChoosedOption(ref UserPressedKey, ref MachinePressedKey);
        }

        private static char ChoosedKeyValidation(char UserPressedKey)
        {
            while ((UserPressedKey != 'P') && (UserPressedKey != 'S') && (UserPressedKey != 'R') && (UserPressedKey != 'L') && (UserPressedKey != 'V'))
            {
                Console.Clear();
                Console.WriteLine("Please hit a valid key: \n" + "Valid keys are: \n" + "Paper - P\n" + "Scissor - S \n" +
                    "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
                WaitForUser();
                UserPressedKey = StoreUserInput();
            }

            return UserPressedKey;
        }

        private static void GameStart()
        {
            Console.Clear();
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n"
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
        }

        private static void GameFinalize()
        {
            Console.WriteLine("\n"+"If you want a new game hit the E key \n" + "If you want to quit hit the Q key\n");
            UserAction();
        }

        public static void SaveGameData(char UserPressedKey, char MachinePressedKey)
        {
            Console.WriteLine("Add your name: ");
            string Username = Console.ReadLine();
            string Userchoosedoption = "";
            string Machinechoosedoption = "";
            Userchoosedoption = DefineUserChoosedOption(UserPressedKey, Userchoosedoption);
            Machinechoosedoption = DefineMachineChoosedOption(MachinePressedKey, Machinechoosedoption);
            string timestamp = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            string savedresult;
            string Gameresult = "\n" + "Username: " + Username + " \n" + "Choosed option by the User: " + Userchoosedoption + "\n"
                + "Choosed option by the Machine: " + Machinechoosedoption + "\n";
            savedresult = "\n" + timestamp + Gameresult;
            File.AppendAllText("GameResult.txt", savedresult);
        }

        private static string DefineMachineChoosedOption(char MachinePressedKey, string Machinechoosedoption)
        {
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

            return Machinechoosedoption;
        }

        private static string DefineUserChoosedOption(char UserPressedKey, string Userchoosedoption)
        {
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

            return Userchoosedoption;
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
            Console.Clear();
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
