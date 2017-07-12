using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SW_Level_Bot
{
    class Program
    {

        const string ROOTPATH = "C:\\Users\\Oleg\\Desktop\\TodaysRunes\\Rune";
        const string SUBPATH = "C:\\Users\\Oleg\\Desktop\\TodaysRunes\\Sold5Stars\\Rune";

        //##########################################################################################################
        //###################################        GLOBAL VARIABLES         ######################################
        //##########################################################################################################

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //##########################################################################################################
        //##################################        MOUSE FUNCTIONS         ########################################
        //##########################################################################################################

        static void sendMouseRightclick(Point p)
        {
            System.Windows.Forms.Cursor.Position = p;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);
        }

        static void sendMouseLeftclick(Point p)
        {
            System.Windows.Forms.Cursor.Position = p;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);
        }

        static void sendMouseDoubleClick(Point p)
        {
            System.Windows.Forms.Cursor.Position = p;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);

            Thread.Sleep(Randomize(250, 750));

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);
        }

        static void sendMouseRightDoubleClick(Point p)
        {
            System.Windows.Forms.Cursor.Position = p;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);

            Thread.Sleep(150);

            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);
        }

        static void sendMouseDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 50, 50, 0, (UIntPtr)0);
        }

        static void sendMouseUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 50, 50, 0, (UIntPtr)0);
        }


        //##########################################################################################################
        //####################################         FUNCTIONS         ###########################################
        //##########################################################################################################

        static Color GetPixel(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }

        static bool MatchedColor(Color expectedColor, Color isColor)
        {
            return isColor.R >= expectedColor.R - 20 && isColor.R <= expectedColor.R + 20 
                && isColor.G >= expectedColor.G - 20 && isColor.G <= expectedColor.G + 20 
                && isColor.B >= expectedColor.B - 20 && isColor.B <= expectedColor.B + 20;
        }

        static int Randomize(int interval, int value)
        {
            Random rad = new Random();
            return rad.Next(value - interval, value + interval);
        }

        static bool CheckRuneName(Color color)
        {
            bool matched = false;
            for (int i = 0; i < 200; i = i + 2)
            {
                if (MatchedColor(color, GetPixel(new Point(800 + i, 300))))
                {
                    matched = true;
                    break;
                }
            }
            return matched;
        }

        static bool CheckEnergyEmpty(bool refresh_energy, ButtonPositionsAndColors PosColorManager)
        {
            if (refresh_energy && MatchedColor(PosColorManager.CheckEnergyEmpty1Col, GetPixel(PosColorManager.CheckEnergyEmpty1Pos)) && 
                MatchedColor(PosColorManager.CheckEnergyEmpty2Col, GetPixel(PosColorManager.CheckEnergyEmpty2Pos)))
            {
                RefillEnergy(PosColorManager);
                Thread.Sleep(Randomize(300, 2000));
                sendMouseLeftclick(PosColorManager.ReplayButtonPos);
                Thread.Sleep(Randomize(300, 2500));
                return true;
            }
            return false;
        }

        static void TakeScreenshot(string path, int nr)
        {
            Bitmap b = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(0, 0, 0, 0, b.Size);
            g.Dispose();
            b.Save(path + nr + ".gif");
        }

        static void RefillEnergy(ButtonPositionsAndColors PosColorManager)
        {
            sendMouseLeftclick(PosColorManager.RefreshEnergyButtonPos);
            Thread.Sleep(Randomize(300, 1500));
            sendMouseLeftclick(PosColorManager.Energy4CrystalsButtonPos);
            Thread.Sleep(Randomize(300, 1500));
            sendMouseLeftclick(PosColorManager.Energy4CrystalsConfirmButtonPos);
            Thread.Sleep(Randomize(300, 4000));
            sendMouseLeftclick(PosColorManager.RefreshedEnergyConfirmButtonPos);
            Thread.Sleep(Randomize(300, 1500));
            sendMouseLeftclick(PosColorManager.CloseCashShopWindowButtonPos);
            Thread.Sleep(Randomize(300, 1500));
        }

        static int StartNewRound(ButtonPositionsAndColors PosColorManager, bool refresh_energy)
        {
            int refreshedEnergy = 0;
            //Start a new round
            sendMouseLeftclick(PosColorManager.ReplayButtonPos);
            Thread.Sleep(Randomize(300, 2300));

            //Check whether energy is empty
            if (CheckEnergyEmpty(refresh_energy, PosColorManager))
                refreshedEnergy++;

            sendMouseLeftclick(PosColorManager.StartBattleButtonPos);
            Thread.Sleep(Randomize(300, 1000));

            return refreshedEnergy;
        }

        //static void SlideMonsterList(Point p, int distance)
        //{
        //    bool end_reached = false;
        //    int speed_factor = 2;

        //    do
        //    {
        //        System.Windows.Forms.Cursor.Position = p;
        //        mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);

        //        for (int i = 0; i < 800 / speed_factor; i++)
        //        {
        //            System.Windows.Forms.Cursor.Position = new Point(System.Windows.Forms.Cursor.Position.X - speed_factor, System.Windows.Forms.Cursor.Position.Y);
        //            Thread.Sleep(1);
        //        }

        //        Thread.Sleep(100);
        //        if (MatchedColor(40, 26, 13, GetPixel(new Point(1190, 750))) && MatchedColor(40, 26, 13, GetPixel(new Point(1222, 750))) && MatchedColor(40, 26, 13, GetPixel(new Point(1210, 780))))
        //            end_reached = true;

        //        mouse_event(MOUSEEVENTF_LEFTUP, (uint)p.X, (uint)p.Y, 0, (UIntPtr)0);
        //        Thread.Sleep(Randomize(100, 500));
        //    } while (!end_reached);
            
        //}

        //static int ChangeMonster(bool[] farmer_pos, bool[] monster_maxed)
        //{
        //    int changed_monster = 0;
        //    Point[] monster_positions_lineup = { new Point(Randomize(50, 450), Randomize(50, 300)), new Point(Randomize(50, 250), Randomize(50, 400)), new Point(Randomize(50, 650), Randomize(50, 400)), new Point(Randomize(50, 450), Randomize(50, 500))};
        //    Point[] monster_positions_slide = { new Point(Randomize(25, 1100), Randomize(25, 745)), new Point(Randomize(25, 950), Randomize(25, 745)), new Point(Randomize(25, 780), Randomize(25, 745))};

        //    //Remove maxed monsters from team 
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (monster_maxed[i] && !farmer_pos[i])
        //        {
        //            sendMouseLeftclick(monster_positions_lineup[i]);
        //            changed_monster++;
        //            Thread.Sleep(500);
        //        }
        //    }

        //    //Slide and select new monsters
        //    SlideMonsterList(new Point(Randomize(5, 1100), Randomize(5, 750)), 400);
        //    sendMouseLeftclick(new Point(Randomize(5, 900), Randomize(5, 500)));
        //    Thread.Sleep(Randomize(150, 1000));
        //    for (int i = 0; i < changed_monster; i++)
        //    {
        //        sendMouseLeftclick(monster_positions_slide[i]);
        //        Thread.Sleep(Randomize(100, 500));
        //    }

        //    return changed_monster;
        //} 

        static void ListerKeyBoardEvent(Thread main_thread)
        {
            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }
                Thread.Sleep(100);
            } while (true);
        }


        //##########################################################################################################
        //######################################         MODES         #############################################
        //##########################################################################################################

        static void farm_runes(bool refresh_energy, InputOutput InOutManager, ButtonPositionsAndColors PosColorManager)
        {
            //Statistic variables
            int runs = 0;
            int successful_runs = 0;
            int good_rune_count = 0;
            int bad_rune_count = 0;
            int loss_count = 0;
            int misc_drops = 0;
            int refills = 0;

            DateTime started_date = DateTime.Now;

            InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, good_rune_count, bad_rune_count, misc_drops, refills);

            for (;;)
            {
                //Win condition - Check reward color and a pixel in the middle
                if (MatchedColor(PosColorManager.WinCondition1Col, GetPixel(PosColorManager.WinCondition1Pos)) && 
                    MatchedColor(PosColorManager.WinCondition2Col, GetPixel(PosColorManager.WinCondition2Pos)))
                {
                    //Perform a double click
                    sendMouseDoubleClick(PosColorManager.DoubleClickPos);
                    Thread.Sleep(Randomize(300, 2000));

                    //Check whether it is a rune drop or not
                    if (MatchedColor(PosColorManager.CheckRuneDropCol, GetPixel(PosColorManager.CheckRuneDropPos)))
                    {
                        //Rune drop
                        //Check whether it is a good rune (6* || legend)
                        if (MatchedColor(PosColorManager.CheckSixStarRuneCol, GetPixel(PosColorManager.CheckSixStarRunePos)) || MatchedColor(PosColorManager.CheckLegendCol, GetPixel(PosColorManager.CheckLegendPos)))
                        {
                            //Good rune
                            good_rune_count++;
                            TakeScreenshot(ROOTPATH, good_rune_count);
                            Thread.Sleep(Randomize(300, 1200));
                            sendMouseLeftclick(PosColorManager.GetRuneButtonPos);
                            Thread.Sleep(Randomize(300, 1200));
                        }
                        else
                        {
                            //Bad rune
                            bad_rune_count++;
                            //Purple 5* rune: take screenshot in order to check the sell heuristic quality
                            //if ((checkRuneName(230, 130, 237) && MatchedColor(221, 228, 226, GetPixel(new Point(657, 366)))))
                            //    take_screenshot(SUBPATH, bad_rune_count);
                            sendMouseLeftclick(PosColorManager.SellRuneButtonPos);
                            Thread.Sleep(Randomize(300, 1200));
                            //Is it a 5* or violet rune? Confirm sell button
                            sendMouseLeftclick(PosColorManager.ConfirmSellRuneButtonPos);
                            Thread.Sleep(Randomize(300, 3500));
                        }
                    }
                    else
                    {
                        //Unknown scroll, rainbowmon, mystical scroll, ...
                        //sendMouseLeftclick(new Point(Randomize(90, 890), Randomize(15, 860)));
                        sendMouseLeftclick(PosColorManager.GetMiscButtonPos);
                        Thread.Sleep(Randomize(300, 1500));
                        misc_drops++;

                    }
                    refills += StartNewRound(PosColorManager, refresh_energy);
                    successful_runs++;
                    runs++;
                    InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, good_rune_count, bad_rune_count, misc_drops, refills);
                }
                //Lose condition
                else if (MatchedColor(PosColorManager.LoseCondition1Col, GetPixel(PosColorManager.LoseCondition1Pos)) && 
                         MatchedColor(PosColorManager.LoseCondition2Col, GetPixel(PosColorManager.LoseCondition2Pos)))
                {
                    sendMouseLeftclick(PosColorManager.NoContinueButtonPos);
                    Thread.Sleep(Randomize(300, 3500));
                    sendMouseLeftclick(PosColorManager.ReplayButtonPos);
                    Thread.Sleep(Randomize(300, 1500));

                    refills += StartNewRound(PosColorManager, refresh_energy);

                    loss_count++;
                    runs++;
                    InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, good_rune_count, bad_rune_count, misc_drops, refills);
                }
                //Network problems - send data again
                else if (MatchedColor(PosColorManager.NetworkProblems1Col, GetPixel(PosColorManager.NetworkProblems1Pos)) && 
                         MatchedColor(PosColorManager.NetworkProblems2Col, GetPixel(PosColorManager.NetworkProblems2Pos)))
                {
                    sendMouseLeftclick(PosColorManager.SendDataAgainButtonPos);
                }
                //Unstable network connection
                else if (MatchedColor(PosColorManager.UnstableConnection1Col, GetPixel(PosColorManager.UnstableConnection1Pos)) && 
                         MatchedColor(PosColorManager.UnstableConnection2Col, GetPixel(PosColorManager.UnstableConnection2Pos)))
                {
                    sendMouseLeftclick(PosColorManager.ResendWinButtonPos);
                }
                Thread.Sleep(1500);
            }
        }

        //static void farm_fooder(bool refresh_energy, bool[] farmer_pos, int farmer_levels_pos, bool automatic_monster_replace, InputOutput InOutManager)
        //{
        //     //Statistic variables
        //    int runs = 0;
        //    int successful_runs = 0;
        //    int loss_count = 0;
        //    int refills = 0;
        //    int maxed_monsters = 0;

        //    bool won_run = false;
        //    bool failed_run = false;

        //    bool[] monster_maxed = { false, false, false, false };

        //    DateTime started_date = DateTime.Now;
            
        //    //Print statistic
        //    InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, refills, maxed_monsters);

        //    for (;;)
        //    {
        //        won_run = MatchedColor(241, 238, 207, GetPixel(new Point(890, 390))) && MatchedColor(44, 30, 9, GetPixel(new Point(830, 540)));
        //        failed_run = MatchedColor(235, 40, 90, GetPixel(new Point(502, 702))) && MatchedColor(250, 250, 250, GetPixel(new Point(925, 529)));
        //        //Win condition - Check reward color and a pixel in the middle
        //        if (won_run || failed_run)
        //        {
        //            Thread.Sleep(Randomize(300, 1000));

        //            if (won_run)
        //            {
        //                //Check whether a monster is fully leveled
        //                monster_maxed[0] = !MatchedColor(252, 241, 197, GetPixel(new Point(670, 700)));
        //                monster_maxed[1] = !MatchedColor(252, 241, 197, GetPixel(new Point(1060, 700)));
        //                monster_maxed[2] = !MatchedColor(252, 241, 197, GetPixel(new Point(1450, 700)));
        //                monster_maxed[3] = !MatchedColor(233, 213, 178, GetPixel(new Point(668, 825)));

        //                //Move mouse to position and perform a double click
        //                sendMouseDoubleClick(new Point(Randomize(150, 920), Randomize(100, 500)));
        //                Thread.Sleep(Randomize(300, 2000));

        //                //Check whether it's a rune drop or an unknown scroll and go to monster select screen
        //                //Rune drop detected
        //                if (MatchedColor(244, 229, 169, GetPixel(new Point(766, 850))))
        //                {
        //                    sendMouseLeftclick(new Point(Randomize(35, 766), Randomize(30, 850)));
        //                    Thread.Sleep(Randomize(300, 2200));
        //                }
        //                //Misc drop detected
        //                else
        //                    sendMouseLeftclick(new Point(Randomize(90, 890), Randomize(15, 860)));
        //                Thread.Sleep(Randomize(250, 1550));
        //                sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //                Thread.Sleep(Randomize(300, 2000));

        //                successful_runs++;
        //            }
        //            else
        //            {
        //                sendMouseLeftclick(new Point(Randomize(150, 1170), Randomize(50, 700)));
        //                Thread.Sleep(Randomize(300, 1500));

        //                //Check whether a monster is fully leveled
        //                monster_maxed[0] = !MatchedColor(252, 241, 197, GetPixel(new Point(670, 700)));
        //                monster_maxed[1] = !MatchedColor(252, 241, 197, GetPixel(new Point(1060, 700)));
        //                monster_maxed[2] = !MatchedColor(252, 241, 197, GetPixel(new Point(1450, 700)));
        //                monster_maxed[3] = !MatchedColor(233, 213, 178, GetPixel(new Point(668, 825)));

        //                sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //                Thread.Sleep(Randomize(300, 1000));
        //                sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //                Thread.Sleep(Randomize(300, 2000));

        //                loss_count++;
        //            }

        //            //Check whether a monster is maxed and change or signal it
        //            if ((monster_maxed[0] && !farmer_pos[0]) || (monster_maxed[1] && !farmer_pos[1]) || (monster_maxed[2] && !farmer_pos[2]) || (monster_maxed[3] && !farmer_pos[3]))
        //            {
        //                //Either manually monster change was chosen or the farmer reached max level
        //                if (!automatic_monster_replace || (farmer_levels_pos > -1 && monster_maxed[farmer_levels_pos]))
        //                {
        //                    int f = 3;
        //                    Console.Beep(660, f * 1000);
        //                    while (MatchedColor(253, 253, 253, GetPixel(new Point(1545, 730))))
        //                    {
        //                        Thread.Sleep(1000);
        //                    }
        //                }
        //                //Change maxed monster automatically
        //                else if (automatic_monster_replace)
        //                {
        //                    //Check whether energy is empty
        //                    if (checkEnergyEmpty(refresh_energy))
        //                        refills++;

        //                    maxed_monsters += change_monster(farmer_pos, monster_maxed);
        //                    sendMouseLeftclick(new Point(Randomize(150, 1500), Randomize(50, 750)));
        //                    Thread.Sleep(Randomize(300, 1000));
        //                }

        //            }
        //            //No monstar maxed start new round
        //            else
        //            {
        //                //Check whether energy is empty
        //                if (checkEnergyEmpty(refresh_energy))
        //                    refills++;

        //                sendMouseLeftclick(new Point(Randomize(150, 1500), Randomize(50, 750)));
        //                Thread.Sleep(Randomize(300, 1000));
        //            }

        //            runs++;
        //            InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, refills, maxed_monsters);
        //        }
        //        //Network problems - send data again
        //        else if (MatchedColor(245, 229, 172, GetPixel(new Point(702, 720))) && MatchedColor(244, 229, 170, GetPixel(new Point(1061, 726))))
        //        {
        //            sendMouseLeftclick(new Point(Randomize(100, 730), Randomize(50, 720)));
        //        }
        //        Thread.Sleep(1000);
        //    }
        //}

        //static void farm_toa(bool refresh_energy, int fails, InputOutput InOutManager)
        //{
        //    //Statistic variables
        //    int runs = 0;
        //    int successful_runs = 0;
        //    int loss_count = 0;
        //    int refills = 0;

        //    int consecutive_fails = 0;
        //    DateTime started_date = DateTime.Now;

        //    InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, refills);

        //    for (; consecutive_fails != fails || fails == 0;)
        //    {
        //        //Win condition - Check reward color and a pixel in the middle
        //        if (MatchedColor(241, 238, 207, GetPixel(new Point(890, 390))) && MatchedColor(44, 30, 9, GetPixel(new Point(830, 540))))
        //        {
        //            //Perform a double click
        //            sendMouseDoubleClick(new Point(Randomize(150, 920), Randomize(100, 500)));
        //            Thread.Sleep(Randomize(300, 2000));
                    
        //            //Take reward
        //            sendMouseLeftclick(new Point(Randomize(90, 890), Randomize(15, 860)));
        //            Thread.Sleep(Randomize(300, 1200));
                    
        //            //Start a new round
        //            sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //            Thread.Sleep(Randomize(300, 2000));

        //            //Check whether energy is empty
        //            if (checkEnergyEmpty(refresh_energy))
        //                refills++;

        //            sendMouseLeftclick(new Point(Randomize(150, 1500), Randomize(50, 750)));
        //            Thread.Sleep(Randomize(300, 1000));
        //            successful_runs++;
        //            runs++;
        //            InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, refills);
        //            consecutive_fails = 0;
        //        }
        //        //Lose condition
        //        else if (MatchedColor(237, 242, 50, GetPixel(new Point(576, 162))) && MatchedColor(143, 175, 50, GetPixel(new Point(1162, 203))))
        //        {
        //            sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //            Thread.Sleep(Randomize(300, 2000));

        //            //Start a new round
        //            sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //            Thread.Sleep(Randomize(300, 2500));

        //            //Check whether energy is empty
        //            if (checkEnergyEmpty(refresh_energy))
        //                refills++;

        //            sendMouseLeftclick(new Point(Randomize(150, 1500), Randomize(50, 750)));
        //            Thread.Sleep(Randomize(300, 1000));
        //            loss_count++;
        //            runs++;
        //            InOutManager.print_statistic(started_date, runs, successful_runs, loss_count, refills);
        //            consecutive_fails++;
        //        }
        //        //Network problems - send data again
        //        else if (MatchedColor(245, 229, 172, GetPixel(new Point(702, 720))) && MatchedColor(244, 229, 170, GetPixel(new Point(1061, 726))))
        //        {
        //            sendMouseLeftclick(new Point(Randomize(100, 730), Randomize(50, 720)));
        //        }
        //        Thread.Sleep(1500);
        //    }
        //}

        //static void farm_beasts(bool refresh_energy, InputOutput InOutManager)
        //{
        //    //Statistic variables
        //    int runs = 0;
        //    int refills = 0;

        //    DateTime started_date = DateTime.Now;

        //    InOutManager.print_statistic(started_date, runs, refills);

        //    for (;;)
        //    {
        //        //Win condition
        //        if (MatchedColor(255, 175, 0, GetPixel(new Point(748, 194))) && MatchedColor(251, 252, 44, GetPixel(new Point(1060, 148))))
        //        {
        //            Thread.Sleep(Randomize(150, 4000));
        //            //Perform a click
        //            sendMouseLeftclick(new Point(Randomize(150, 920), Randomize(100, 500)));
        //            Thread.Sleep(Randomize(150, 1500));

        //            //Start a new round
        //            sendMouseLeftclick(new Point(Randomize(200, 560), Randomize(50, 600)));
        //            Thread.Sleep(Randomize(300, 1500));

        //            //Check whether energy is empty
        //            if (checkEnergyEmpty(refresh_energy))
        //                refills++;

        //            sendMouseLeftclick(new Point(Randomize(150, 1500), Randomize(50, 750)));
        //            Thread.Sleep(Randomize(300, 1000));
        //            runs++;
        //            InOutManager.print_statistic(started_date, runs, refills);
        //        }
        //        //Network problems - send data again
        //        else if (MatchedColor(245, 229, 172, GetPixel(new Point(702, 720))) && MatchedColor(244, 229, 170, GetPixel(new Point(1061, 726))))
        //        {
        //            sendMouseLeftclick(new Point(Randomize(100, 730), Randomize(50, 720)));
        //        }
        //        Thread.Sleep(1500);
        //    }
        //}

        static void debug()
        {
            for (;;)
            {
                Console.WriteLine("Position X is:" + System.Windows.Forms.Cursor.Position.X + " Position Y is:" + System.Windows.Forms.Cursor.Position.Y
                                   + "\n R: " + GetPixel(new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y)).R.ToString()
                                   + "\n G: " + GetPixel(new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y)).G.ToString()
                                   + "\n B: " + GetPixel(new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y)).B.ToString() + "\n");
                Thread.Sleep(1500);
            }
        }

        //##########################################################################################################
        //######################################          MAIN         #############################################
        //##########################################################################################################

        static void Main(string[] args)
        {
            int mode;
            bool refresh_energy;

            InputOutput InOutManager = new InputOutput();
            ButtonPositionAndColorsWindowed PosColorManager = new ButtonPositionAndColorsWindowed();

            Thread functionThread;
            Thread keyEventThread;

            var hWnd = FindWindow(null, "Mobizen Mirroring");
            Form ParentForm = (Form)Control.FromHandle(hWnd);

            MoveWindow(hWnd, 0, 0, 1027, 516, true);

            RECT rct;

            if (!GetWindowRect(hWnd, out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }

            float width = rct.Right - rct.Left + 1;
            float height = rct.Bottom - rct.Top + 1;

            do
            {
                Console.Clear();
                Console.WriteLine("The mobizen window resolution should be: 1211 x 607");
                Console.WriteLine("The current window resolution denotes: " + width + " x " + height);
                mode = InOutManager.selectMode();

                switch (mode)
                {
                    case 1:
                        refresh_energy = InOutManager.refreshEnergyDecision();
                        functionThread = new Thread(() => farm_runes(refresh_energy, InOutManager, PosColorManager));
                        keyEventThread = new Thread(() => ListerKeyBoardEvent(Thread.CurrentThread));
                        functionThread.Start();
                        keyEventThread.Start();
                        keyEventThread.Join();
                        functionThread.Abort();
                        break;
                    case 2:
                        refresh_energy = InOutManager.refreshEnergyDecision();
                        int fails = InOutManager.toaFailsDecision();
                        //farm_toa(refresh_energy, fails, InOutManager);
                        break;
                    case 3:
                        refresh_energy = InOutManager.refreshEnergyDecision();
                        bool[] farmer_pos = { false, false, false, false };

                        //Decide where the farming monster is positioned in the line-up and whether it also levels
                        int farmer_levels_pos = InOutManager.farmerPositionDecision(ref farmer_pos);
                        //Decide whether monster should be exchanged automatically
                        bool automatic_monster_replace = InOutManager.automaticMonsterChangeDecision();

                        //functionThread = new Thread(() => farm_fooder(refresh_energy, farmer_pos, farmer_levels_pos, automatic_monster_replace, InOutManager));
                        keyEventThread = new Thread(() => ListerKeyBoardEvent(Thread.CurrentThread));
                        //functionThread.Start();
                        keyEventThread.Start();
                        keyEventThread.Join();
                        //functionThread.Abort();
                        break;
                    case 4:
                        refresh_energy = InOutManager.refreshEnergyDecision();
                        //functionThread = new Thread(() => farm_beasts(refresh_energy, InOutManager));
                        keyEventThread = new Thread(() => ListerKeyBoardEvent(Thread.CurrentThread));
                        //functionThread.Start();
                        keyEventThread.Start();
                        keyEventThread.Join();
                        //functionThread.Abort();
                        break;
                    case 8:
                        debug();
                        break;
                    case 9:
                        return;
                }
            } while (true);
        }
    }
}