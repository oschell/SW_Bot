using System;
using SW_Level_Bot.Modes;

namespace SW_Level_Bot.IO
{
    internal class InputOutput
    {
        public bool AutomaticMonsterChangeDecision()
        {
            for (;;)
            {
                Console.WriteLine(
                    "Enable auotmatic monster change (else you have to switch manually maxed monsters)? (Y/N)");
                var automaticMonsterReplaceStr = Console.ReadLine();
                switch (automaticMonsterReplaceStr)
                {
                    case "y":
                    case "Y":
                        return true;
                    case "n":
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("An unknwon decision was recognized.");
                        Console.WriteLine("Please insert (Y)es or (N)o!\n");
                        break;
                }
            }
        }

        public int FarmerPositionDecision(ref bool[] farmerPos)
        {
            var farmerLevelPos = -1;
            var incorrectChoice = true;

            Console.Clear();

            do
            {
                Console.WriteLine("       *****       ");
                Console.WriteLine("       * 1 *       ");
                Console.WriteLine("*****  *****  *****");
                Console.WriteLine("* 2 *         * 3 *");
                Console.WriteLine("*****  *****  *****");
                Console.WriteLine("       * 4 *       ");
                Console.WriteLine("       *****       \n");

                Console.WriteLine(
                    "Please select the position of your farmer monster, if your farmer levels add x after number (e.g 1x) for notification of reaching max!");

                switch (Console.ReadLine())
                {
                    case "1x":
                        farmerLevelPos = 0;
                        goto case "1";
                    case "1":
                        farmerPos[0] = true;
                        incorrectChoice = false;
                        break;
                    case "2x":
                        farmerLevelPos = 1;
                        goto case "2";
                    case "2":
                        farmerPos[1] = true;
                        incorrectChoice = false;
                        break;
                    case "3x":
                        farmerLevelPos = 2;
                        goto case "3";
                    case "3":
                        farmerPos[2] = true;
                        incorrectChoice = false;
                        break;
                    case "4x":
                        farmerLevelPos = 3;
                        goto case "4";
                    case "4":
                        farmerPos[3] = true;
                        incorrectChoice = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect input, please select a correct position! \n");
                        break;
                }
            } while (incorrectChoice);

            return farmerLevelPos;
        }

        public bool RefreshEnergyDecision()
        {
            for (;;)
            {
                Console.WriteLine("Should the energy be refreshed with crystals? (Y/N)");
                switch (Console.ReadLine())
                {
                    case "y":
                    case "Y":
                        return true;
                    case "n":
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("An unknwon decision was recognized.");
                        Console.WriteLine("Please insert (Y)es or (N)o!\n");
                        break;
                }
            }
        }

        public Mode SelectMode()
        {
            for (;;)
            {
                Console.WriteLine("Mode 1: General farming (Runes, Essences, HOH)");
                Console.WriteLine("Mode 2: TOA");
                Console.WriteLine("Mode 3: Fooder farming (Dimensional Rift excluded)");
                Console.WriteLine("Mode 4: Beast Rifts");
                Console.WriteLine("Exit with 9 \n");
                Console.WriteLine("Please insert the desired mode number:");

                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out var mode) &&
                    Enum.IsDefined(typeof(Mode), mode))
                {
                    return (Mode)mode;
                }

                Console.Clear();
                Console.WriteLine("An unknown mode number was inserted.");
                Console.WriteLine("Please insert a correct mode number!\n");
            }
        }

        public int ToaFailsDecision()
        {
            for (;;)
            {
                Console.WriteLine("Please insert after how many consecutive fails the bot should stop:");
                if (int.TryParse(Console.ReadLine(), out var j))
                {
                    if (j < 0)
                    {
                        Console.WriteLine("\n The number can't be negative!");
                    }
                    else
                    {
                        return j;
                    }
                }
                else
                {
                    Console.WriteLine("\n The input was not a number!");
                }
            }
        }
    }
}