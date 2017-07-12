using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Level_Bot
{
    public class InputOutput
    {
        public int selectMode()
        {
            string mode_str;

            do
            {
                Console.WriteLine("Mode 1: General farming (Runes, Essences, HOH)");
                Console.WriteLine("Mode 2: TOA");
                Console.WriteLine("Mode 3: Fooder farming (Dimensional Rift excluded)");
                Console.WriteLine("Mode 4: Beast Rifts");
                Console.WriteLine("Exit with 9 \n");
                Console.WriteLine("Please insert the desired mode number:");
                mode_str = Console.ReadLine();

                switch (mode_str)
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    case "3":
                        return 3;
                    case "4":
                        return 4;
                    case "8":
                        return 8;
                    case "9":
                        return 9;
                    default:
                        Console.Clear();
                        Console.WriteLine("An unknown mode number was inserted.");
                        Console.WriteLine("Please insert a correct mode number!\n");
                        break;
                } 
            } while (true);

        }

        public bool refreshEnergyDecision()
        {
            string energy_refresh_str;

            do
            {
                Console.WriteLine("Should the energy be refreshed with crystals? (Y/N)");
                energy_refresh_str = Console.ReadLine();
                switch (energy_refresh_str)
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
            } while (true);

        }

        public bool automaticMonsterChangeDecision()
        {
            do
            {
                Console.WriteLine("Enable auotmatic monster change (else you have to switch manually maxed monsters)? (Y/N)");
                string automatic_monster_replace_str = Console.ReadLine();
                switch (automatic_monster_replace_str)
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
            } while (true);
        }

        public int farmerPositionDecision(ref bool[] farmer_pos)
        {
            int farmer_levels_pos = -1;
            bool incorrect_choice = true;

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

                Console.WriteLine("Please select the position of your farmer monster, if your farmer levels add x after number (e.g 1x) for notification of reaching max!");
                
                switch (Console.ReadLine())
                {
                    case "1x":
                        farmer_levels_pos = 0;
                        goto case "1";
                    case "1":
                        farmer_pos[0] = true;
                        incorrect_choice = false;
                        break;
                    case "2x":
                        farmer_levels_pos = 1;
                        goto case "2";
                    case "2":
                        farmer_pos[1] = true;
                        incorrect_choice = false;
                        break;
                    case "3x":
                        farmer_levels_pos = 2;
                        goto case "3";
                    case "3":
                        farmer_pos[2] = true;
                        incorrect_choice = false;
                        break;
                    case "4x":
                        farmer_levels_pos = 3;
                        goto case "4";
                    case "4":
                        farmer_pos[3] = true;
                        incorrect_choice = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect input, please select a correct position! \n");
                        break;
                }
            } while (incorrect_choice);

            return farmer_levels_pos;
        }

        public void print_statistic(DateTime started_date, int runs, int successful_runs, int loss_count, int good_rune_count, int bad_rune_count, int misc_drops, int refills)
        {
            Console.Clear();
            Console.WriteLine("Started to farm: \t" + started_date.ToShortTimeString());
            Console.WriteLine("Runs made: \t \t" + runs);
            Console.WriteLine("--------------------------");
            Console.WriteLine("Successful runs: \t" + successful_runs);
            Console.WriteLine("Failed runs: \t \t" + loss_count);
            Console.WriteLine("Good drops: \t \t" + good_rune_count);
            Console.WriteLine("Bad drops: \t \t" + bad_rune_count);
            Console.WriteLine("Misc drops: \t \t" + misc_drops);
            Console.WriteLine("Refills made: \t \t" + refills);
            Console.WriteLine("Success rate: \t \t" + successful_runs * 100.0 / (runs = runs == 0 ? 1 : runs) + "%");
        }

        public void print_statistic(DateTime started_date, int runs, int successful_runs, int loss_count, int refills, int maxed_monsters)
        {
            Console.Clear();
            Console.WriteLine("Started to farm: \t" + started_date.ToShortTimeString());
            Console.WriteLine("Runs made: \t \t" + runs);
            Console.WriteLine("--------------------------");
            Console.WriteLine("Successful runs: \t" + successful_runs);
            Console.WriteLine("Failed runs: \t \t" + loss_count);
            Console.WriteLine("Maxed monster: \t \t" + maxed_monsters);
            Console.WriteLine("Refills made: \t \t" + refills);
            Console.WriteLine("Success rate: \t \t" + successful_runs * 100.0 / (runs = runs == 0 ? 1 : runs) + "%");
        }

        public void print_statistic(DateTime started_date, int runs, int successful_runs, int loss_count, int refills)
        {
            Console.Clear();
            Console.WriteLine("Started to farm: \t" + started_date.ToShortTimeString());
            Console.WriteLine("Runs made: \t \t" + runs);
            Console.WriteLine("--------------------------");
            Console.WriteLine("Successful runs: \t" + successful_runs);
            Console.WriteLine("Failed runs: \t \t" + loss_count);
            Console.WriteLine("Refills made: \t \t" + refills);
            Console.WriteLine("Success rate: \t \t" + successful_runs * 100.0 / (runs = runs == 0 ? 1 : runs) + "%");
        }

        public void print_statistic(DateTime started_date, int runs, int refills)
        {
            Console.Clear();
            Console.WriteLine("Started to farm: \t" + started_date.ToShortTimeString());
            Console.WriteLine("Runs made: \t \t" + runs);
            Console.WriteLine("Refills made: \t \t" + refills);
        }


        public int toaFailsDecision()
        {
            int j;
            string fails = "";
            do
            {
                Console.WriteLine("Please insert after how many consecutive fails the bot should stop:");
                fails = Console.ReadLine();
                if(Int32.TryParse(fails, out j))
                    if (j < 0)
                        Console.WriteLine("\n The number can't be negative!");
                    else
                        return j;
                else
                    Console.WriteLine("\n The input was not a number!");
            } while (true);
        }

    }
}
