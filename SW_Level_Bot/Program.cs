using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Win32Library;

using static SW_Level_Bot.Randomizer;
using Screen = Win32Library.Screen;

namespace SW_Level_Bot
{
    class Program
    {
        static readonly string ROOTPATH = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "TodaysRunes\\Rune";
        static readonly string SUBPATH = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "TodaysRunes\\Sold5Stars\\Rune";

        static bool CheckEnergyEmpty(bool refreshEnergy, IButtonPositionsAndColors posColorManager)
        {
            bool energyEmpty = refreshEnergy && posColorManager.CheckEnergyEmpty1Col.Matches(Screen.GetPixel(posColorManager.CheckEnergyEmpty1Pos))
                && posColorManager.CheckEnergyEmpty2Col.Matches(Screen.GetPixel(posColorManager.CheckEnergyEmpty2Pos));

            if (energyEmpty)
            {
                RefillEnergy(posColorManager);
                Thread.Sleep(Randomize(300, 2000));
                Mouse.LeftClick(posColorManager.ReplayButtonPos);
                Thread.Sleep(Randomize(300, 2500));
            }

            return energyEmpty;
        }

        static void RefillEnergy(IButtonPositionsAndColors posColorManager)
        {
            Mouse.LeftClick(posColorManager.RefreshEnergyButtonPos);
            Thread.Sleep(Randomize(300, 1500));
            Mouse.LeftClick(posColorManager.Energy4CrystalsButtonPos);
            Thread.Sleep(Randomize(300, 1500));
            Mouse.LeftClick(posColorManager.Energy4CrystalsConfirmButtonPos);
            Thread.Sleep(Randomize(300, 4000));
            Mouse.LeftClick(posColorManager.RefreshedEnergyConfirmButtonPos);
            Thread.Sleep(Randomize(300, 1500));
            Mouse.LeftClick(posColorManager.CloseCashShopWindowButtonPos);
            Thread.Sleep(Randomize(300, 1500));

            //new List<Point>
            //{
            //    posColorManager.RefreshEnergyButtonPos,
            //    posColorManager.Energy4CrystalsButtonPos,
            //    posColorManager.Energy4CrystalsConfirmButtonPos,
            //    posColorManager.RefreshedEnergyConfirmButtonPos,
            //    posColorManager.CloseCashShopWindowButtonPos,
            //}.ForEach(p => { Mouse.LeftClick(p); Thread.Sleep(Randomize(300, 1500)); });
        }

        static int StartNewRound(IButtonPositionsAndColors posColorManager, bool refreshEnergy)
        {
            //Start a new round
            Mouse.LeftClick(posColorManager.ReplayButtonPos);
            Thread.Sleep(Randomize(300, 2300));
            int refreshedEnergy = 0;

            //Check whether energy is empty
            if (CheckEnergyEmpty(refreshEnergy, posColorManager))
            {
                refreshedEnergy++;
            }

            Mouse.LeftClick(posColorManager.StartBattleButtonPos);
            Thread.Sleep(Randomize(300, 1000));

            return refreshedEnergy;
        }

        static void SlideMonsterList(Point p, int distance)
        {
            const int speedFactor = 2;
            bool endReached = false;

            while (!endReached)
            {
                Mouse.LeftDown(p);

                for (int i = 0; i < 800 / speedFactor; i++)
                {
                    Cursor.Position = new Point(Cursor.Position.X - speedFactor, Cursor.Position.Y);
                    Thread.Sleep(1);
                }

                Thread.Sleep(100);

                endReached = new List<Point>
                {
                    new Point(1190, 750),
                    new Point(1222, 750),
                    new Point(1210, 780),
                }.TrueForAll(x => Screen.GetPixel(x).Matches(Color.FromArgb(40, 26, 13)));

                Mouse.LeftUp(p);
                Thread.Sleep(Randomize(100, 500));
            }
        }

        static void ListerKeyBoardEvent(Thread mainThread)
        {
            for (;;)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }
                Thread.Sleep(100);
            }
        }

        //##########################################################################################################
        //######################################         MODES         #############################################
        //##########################################################################################################

        static void FarmRunes(bool refreshEnergy, InputOutput inOutManager, IButtonPositionsAndColors posColorManager)
        {
            //Statistic variables
            int runs = 0;
            int successfulRuns = 0;
            int goodRuneCount = 0;
            int badRuneCount = 0;
            int lossCount = 0;
            int miscDrops = 0;
            int refills = 0;

            DateTime startedData = DateTime.Now;
            inOutManager.PrintStatistics(startedData, runs, successfulRuns, lossCount, goodRuneCount, badRuneCount, miscDrops, refills);

            for (;;)
            {
                //Win condition - Check reward color and a pixel in the middle
                if (posColorManager.WinCondition1Col.Matches(Screen.GetPixel(posColorManager.WinCondition1Pos)) &&
                    posColorManager.WinCondition2Col.Matches(Screen.GetPixel(posColorManager.WinCondition2Pos)))
                {
                    //Perform a double click
                    Mouse.DoubleLeftClick(posColorManager.DoubleClickPos);
                    Thread.Sleep(Randomize(300, 2000));

                    //Check whether it is a rune drop or not
                    if (posColorManager.CheckRuneDropCol.Matches(Screen.GetPixel(posColorManager.CheckRuneDropPos)))
                    {
                        //Rune drop
                        //Check whether it is a good rune (6* || legend)
                        if (posColorManager.CheckSixStarRuneCol.Matches(Screen.GetPixel(posColorManager.CheckSixStarRunePos))
                            || posColorManager.CheckLegendCol.Matches(Screen.GetPixel(posColorManager.CheckLegendPos)))
                        {
                            //Good rune
                            goodRuneCount++;
                            Screen.TakeScreenshot(ROOTPATH, goodRuneCount);
                            Thread.Sleep(Randomize(300, 1200));
                            Mouse.LeftClick(posColorManager.GetRuneButtonPos);
                            Thread.Sleep(Randomize(300, 1200));
                        }
                        else
                        {
                            //Bad rune
                            badRuneCount++;
                            //Purple 5* rune: take screenshot in order to check the sell heuristic quality
                            //if ((checkRuneName(230, 130, 237) && MatchedColor(221, 228, 226, GetPixel(new Point(657, 366)))))
                            //    take_screenshot(SUBPATH, bad_rune_count);
                            Mouse.LeftClick(posColorManager.SellRuneButtonPos);
                            Thread.Sleep(Randomize(300, 1200));
                            //Is it a 5* or violet rune? Confirm sell button
                            Mouse.LeftClick(posColorManager.ConfirmSellRuneButtonPos);
                            Thread.Sleep(Randomize(300, 3500));
                        }
                    }
                    else
                    {
                        //Unknown scroll, rainbowmon, mystical scroll, ...
                        //sendMouseLeftclick(new Point(Randomize(90, 890), Randomize(15, 860)));
                        Mouse.LeftClick(posColorManager.GetMiscButtonPos);
                        Thread.Sleep(Randomize(300, 1500));
                        miscDrops++;
                    }
                    refills += StartNewRound(posColorManager, refreshEnergy);
                    successfulRuns++;
                    runs++;
                    inOutManager.PrintStatistics(startedData, runs, successfulRuns, lossCount, goodRuneCount, badRuneCount, miscDrops, refills);
                }
                //Lose condition
                else if (posColorManager.LoseCondition1Col.Matches(Screen.GetPixel(posColorManager.LoseCondition1Pos)) &&
                         posColorManager.LoseCondition2Col.Matches(Screen.GetPixel(posColorManager.LoseCondition2Pos)))
                {
                    Mouse.LeftClick(posColorManager.NoContinueButtonPos);
                    Thread.Sleep(Randomize(300, 3500));
                    Mouse.LeftClick(posColorManager.ReplayButtonPos);
                    Thread.Sleep(Randomize(300, 1500));

                    refills += StartNewRound(posColorManager, refreshEnergy);

                    lossCount++;
                    runs++;
                    inOutManager.PrintStatistics(startedData, runs, successfulRuns, lossCount, goodRuneCount, badRuneCount, miscDrops, refills);
                }
                //Network problems - send data again
                else if (posColorManager.NetworkProblems1Col.Matches(Screen.GetPixel(posColorManager.NetworkProblems1Pos)) &&
                         posColorManager.NetworkProblems2Col.Matches(Screen.GetPixel(posColorManager.NetworkProblems2Pos)))
                {
                    Mouse.LeftClick(posColorManager.SendDataAgainButtonPos);
                }
                //Unstable network connection
                else if (posColorManager.UnstableConnection1Col.Matches(Screen.GetPixel(posColorManager.UnstableConnection1Pos)) &&
                         posColorManager.UnstableConnection1Col.Matches(Screen.GetPixel(posColorManager.UnstableConnection2Pos)))
                {
                    Mouse.LeftClick(posColorManager.ResendWinButtonPos);
                }
                Thread.Sleep(1500);
            }
        }

        static bool MatchesColor((byte r, byte g, byte b) color, int x, int y)
        {
            return Color.FromArgb(color.r, color.g, color.b).Matches(Screen.GetPixel(new Point(x, y)));
        }

        #region Unused
        static bool CheckRuneName(Color color)
        {
            bool matched = false;
            for (int i = 0; i < 200; i = i + 2)
            {
                if (color.Matches(Screen.GetPixel(new Point(800 + i, 300))))
                {
                    matched = true;
                    break;
                }
            }
            return matched;
        }

        static int ChangeMonster(bool[] farmerPos, bool[] monsterMaxed)
        {
            int changedMonster = 0;
            Point[] monsterPositionsLineup = { new Point(Randomize(50, 450), Randomize(50, 300)), new Point(Randomize(50, 250), Randomize(50, 400)),
                new Point(Randomize(50, 650), Randomize(50, 400)), new Point(Randomize(50, 450), Randomize(50, 500)) };
            Point[] monsterPositionsSlide = { new Point(Randomize(25, 1100), Randomize(25, 745)), new Point(Randomize(25, 950), Randomize(25, 745)),
                new Point(Randomize(25, 780), Randomize(25, 745)) };

            System.Diagnostics.Debug.Assert(monsterPositionsLineup.Length == monsterPositionsSlide.Length);

            //Remove maxed monsters from team 
            for (int i = 0; i < monsterPositionsLineup.Length; i++)
            {
                if (monsterMaxed[i] && !farmerPos[i])
                {
                    Mouse.LeftClick(monsterPositionsLineup[i]);
                    changedMonster++;
                    Thread.Sleep(500);
                }
            }

            //Slide and select new monsters
            SlideMonsterList(new Point(Randomize(5, 1100), Randomize(5, 750)), 400);
            Mouse.LeftClick(new Point(Randomize(5, 900), Randomize(5, 500)));
            Thread.Sleep(Randomize(150, 1000));

            for (int i = 0; i < changedMonster; i++)
            {
                Mouse.LeftClick(monsterPositionsSlide[i]);
                Thread.Sleep(Randomize(100, 500));
            }

            return changedMonster;
        }

        static void FarmFooder(bool refreshEnergy, bool[] farmerPos, int farmerLevelsPos, bool automaticMonsterReplace, InputOutput inOutManager, IButtonPositionsAndColors posColorManager)
        {
            //Statistic variables
            int runs = 0;
            int successfulRuns = 0;
            int lossCount = 0;
            int refills = 0;
            int maxedMonsters = 0;

            bool wonRun = false;
            bool failedRun = false;

            bool[] monsterMaxed = new bool[4];
            DateTime startedDate = DateTime.Now;

            //Print statistic
            inOutManager.PrintStatistics(startedDate, runs, successfulRuns, lossCount, refills: refills, maxedMonsters: maxedMonsters);

            for (;;)
            {
                wonRun = MatchesColor((241, 238, 207), 890, 390) && MatchesColor((44, 30, 9), 830, 540);
                failedRun = MatchesColor((235, 40, 90), 502, 702) && MatchesColor((250, 250, 250), 925, 529);

                //Win condition - Check reward color and a pixel in the middle
                if (wonRun || failedRun)
                {
                    Thread.Sleep(Randomize(300, 1000));

                    if (wonRun)
                    {
                        //Check whether a monster is fully leveled                        
                        monsterMaxed[0] = !MatchesColor((252, 241, 197), 670, 700);
                        monsterMaxed[1] = !MatchesColor((252, 241, 197), 1060, 700);
                        monsterMaxed[2] = !MatchesColor((252, 241, 197), 1450, 700);
                        monsterMaxed[3] = !MatchesColor((233, 213, 178), 668, 825);

                        //Move mouse to position and perform a double click
                        Mouse.DoubleLeftClick(new Point(Randomize(150, 920), Randomize(100, 500)));
                        Thread.Sleep(Randomize(300, 2000));

                        //Check whether it's a rune drop or an unknown scroll and go to monster select screen
                        //Rune drop detected
                        if (MatchesColor((244, 229, 169), 766, 850))
                        {
                            Mouse.LeftClick(new Point(Randomize(35, 766), Randomize(30, 850)));
                            Thread.Sleep(Randomize(300, 2200));
                        }
                        //Misc drop detected
                        else
                        {
                            Mouse.LeftClick(new Point(Randomize(90, 890), Randomize(15, 860)));
                        }

                        Thread.Sleep(Randomize(250, 1550));
                        Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                        Thread.Sleep(Randomize(300, 2000));

                        successfulRuns++;
                    }
                    else
                    {
                        Mouse.LeftClick(new Point(Randomize(150, 1170), Randomize(50, 700)));
                        Thread.Sleep(Randomize(300, 1500));

                        //Check whether a monster is fully leveled
                        monsterMaxed[0] = !MatchesColor((252, 241, 197), 670, 700);
                        monsterMaxed[1] = !MatchesColor((252, 241, 197), 1060, 700);
                        monsterMaxed[2] = !MatchesColor((252, 241, 197), 1450, 700);
                        monsterMaxed[3] = !MatchesColor((233, 213, 178), 668, 825);

                        Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                        Thread.Sleep(Randomize(300, 1000));
                        Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                        Thread.Sleep(Randomize(300, 2000));

                        lossCount++;
                    }

                    //Check whether a monster is maxed and change or signal it
                    if ((monsterMaxed[0] && !farmerPos[0]) || (monsterMaxed[1] && !farmerPos[1]) || (monsterMaxed[2] && !farmerPos[2]) || (monsterMaxed[3] && !farmerPos[3]))
                    {
                        //Either manually monster change was chosen or the farmer reached max level
                        if (!automaticMonsterReplace || (farmerLevelsPos > -1 && monsterMaxed[farmerLevelsPos]))
                        {
                            const int f = 3;
                            Console.Beep(660, f * 1000);

                            while (MatchesColor((253, 253, 253), 1545, 730))
                            {
                                Thread.Sleep(1000);
                            }
                        }
                        //Change maxed monster automatically
                        else if (automaticMonsterReplace)
                        {
                            //Check whether energy is empty
                            if (CheckEnergyEmpty(refreshEnergy, posColorManager))
                            {
                                refills++;
                            }

                            //maxedMonsters += change_monster(farmerPos, monsterMaxed);
                            Mouse.LeftClick(new Point(Randomize(150, 1500), Randomize(50, 750)));
                            Thread.Sleep(Randomize(300, 1000));
                        }
                    }
                    //No monstar maxed start new round
                    else
                    {
                        //Check whether energy is empty
                        if (CheckEnergyEmpty(refreshEnergy, posColorManager))
                        {
                            refills++;
                        }

                        Mouse.LeftClick(new Point(Randomize(150, 1500), Randomize(50, 750)));
                        Thread.Sleep(Randomize(300, 1000));
                    }

                    runs++;
                    inOutManager.PrintStatistics(startedDate, runs, successfulRuns, lossCount, refills: refills, maxedMonsters: maxedMonsters);
                }
                //Network problems - send data again
                else if (MatchesColor((245, 229, 172), 702, 720) && MatchesColor((244, 229, 170), 1061, 726))
                {
                    Mouse.LeftClick(new Point(Randomize(100, 730), Randomize(50, 720)));
                }

                Thread.Sleep(1000);
            }
        }

        static void FarmToa(bool refreshEnergy, int fails, InputOutput inOutManager)
        {
            //Statistic variables
            int runs = 0;
            int successfulRuns = 0;
            int lossCount = 0;
            int refills = 0;

            int consecutiveFails = 0;
            DateTime startedDate = DateTime.Now;

            inOutManager.PrintStatistics(startedDate, runs, successfulRuns, lossCount, refills: refills);

            while (consecutiveFails != fails || fails == 0)
            {
                //Win condition - Check reward color and a pixel in the middle
                if (MatchesColor((241, 238, 207), 890, 390) && MatchesColor((44, 30, 9), 830, 540))
                {
                    //Perform a double click
                    Mouse.DoubleLeftClick(new Point(Randomize(150, 920), Randomize(100, 500)));
                    Thread.Sleep(Randomize(300, 2000));

                    //Take reward
                    Mouse.LeftClick(new Point(Randomize(90, 890), Randomize(15, 860)));
                    Thread.Sleep(Randomize(300, 1200));

                    //Start a new round
                    Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                    Thread.Sleep(Randomize(300, 2000));

                    //Check whether energy is empty
                    //if (checkEnergyEmpty(refreshEnergy))
                    //    refills++;

                    Mouse.LeftClick(new Point(Randomize(150, 1500), Randomize(50, 750)));
                    Thread.Sleep(Randomize(300, 1000));
                    successfulRuns++;
                    runs++;
                    inOutManager.PrintStatistics(startedDate, runs, successfulRuns, lossCount, refills: refills);
                    consecutiveFails = 0;
                }
                //Lose condition
                else if (MatchesColor((237, 242, 50), 576, 162) && MatchesColor((143, 175, 50), 1162, 203))
                {
                    Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                    Thread.Sleep(Randomize(300, 2000));

                    //Start a new round
                    Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                    Thread.Sleep(Randomize(300, 2500));

                    //Check whether energy is empty
                    //if (checkEnergyEmpty(refreshEnergy))
                    //    refills++;

                    Mouse.LeftClick(new Point(Randomize(150, 1500), Randomize(50, 750)));
                    Thread.Sleep(Randomize(300, 1000));
                    lossCount++;
                    runs++;
                    inOutManager.PrintStatistics(startedDate, runs, successfulRuns, lossCount, refills: refills);
                    consecutiveFails++;
                }
                //Network problems - send data again
                else if (MatchesColor((245, 229, 172), 702, 720) && MatchesColor((244, 229, 170), 1061, 726))
                {
                    Mouse.LeftClick(new Point(Randomize(100, 730), Randomize(50, 720)));
                }

                Thread.Sleep(1500);
            }
        }

        static void FarmBeasts(bool refreshEnergy, InputOutput inOutManager)
        {
            //Statistic variables
            int runs = 0;
            int refills = 0;

            DateTime startedDate = DateTime.Now;

            inOutManager.PrintStatistics(startedDate, runs, refills: refills);

            for (;;)
            {
                //Win condition
                if (MatchesColor((255, 175, 0), 748, 194) && MatchesColor((251, 252, 44), 1060, 148))
                {
                    Thread.Sleep(Randomize(150, 4000));
                    //Perform a click
                    Mouse.LeftClick(new Point(Randomize(150, 920), Randomize(100, 500)));
                    Thread.Sleep(Randomize(150, 1500));

                    //Start a new round
                    Mouse.LeftClick(new Point(Randomize(200, 560), Randomize(50, 600)));
                    Thread.Sleep(Randomize(300, 1500));

                    //Check whether energy is empty
                    //if (checkEnergyEmpty(refresh_energy))
                    //    refills++;

                    Mouse.LeftClick(new Point(Randomize(150, 1500), Randomize(50, 750)));
                    Thread.Sleep(Randomize(300, 1000));
                    runs++;
                    inOutManager.PrintStatistics(startedDate, runs, refills: refills);
                }
                //Network problems - send data again
                else if (MatchesColor((245, 229, 172), 702, 720) && MatchesColor((244, 229, 170), 1061, 726))
                {
                    Mouse.LeftClick(new Point(Randomize(100, 730), Randomize(50, 720)));
                }

                Thread.Sleep(1500);
            }
        }
        #endregion

        static void Debug()
        {
            for (;;)
            {
                Console.WriteLine($"Position X is: {Cursor.Position.X} Position Y is: {Cursor.Position.Y}"
                                   + "\n R:" + Screen.GetPixel(new Point(Cursor.Position.X, Cursor.Position.Y)).R.ToString()
                                   + "\n G: " + Screen.GetPixel(new Point(Cursor.Position.X, Cursor.Position.Y)).G.ToString()
                                   + "\n B: " + Screen.GetPixel(new Point(Cursor.Position.X, Cursor.Position.Y)).B.ToString() + "\n");
                Thread.Sleep(1500);
            }
        }

        //##########################################################################################################
        //######################################          MAIN         #############################################
        //##########################################################################################################

        static void Main(string[] args)
        {
            bool refreshEnergy;

            var inOutManager = new InputOutput();
            var posColorManager = new ButtonPositionAndColorsWindowed();

            string windowName = "Mobizen Mirroring";
            Window.Move(windowName, new Point(0, 0), 1027, 516);

            if (!Window.GetRectangle(Window.GetHandle(windowName), out var rct))
            {
                MessageBox.Show($"{windowName} was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float width = rct.Right - rct.Left + 1;
            float height = rct.Bottom - rct.Top + 1;

            for (;;)
            {
                Console.Clear();
                Console.WriteLine($"{windowName} resolution should be: 1211 x 607");
                Console.WriteLine($"The current window resolution denotes: {width}x{height}");

                switch (inOutManager.SelectMode())
                {
                    case Mode.GeneralFarming:
                        refreshEnergy = inOutManager.RefreshEnergyDecision();
                        var functionThread = new Thread(() => FarmRunes(refreshEnergy, inOutManager, posColorManager));
                        var keyEventThread = new Thread(() => ListerKeyBoardEvent(Thread.CurrentThread));
                        functionThread.Start();
                        keyEventThread.Start();
                        keyEventThread.Join();
                        functionThread.Abort();
                        break;
                    case Mode.Toa:
                        refreshEnergy = inOutManager.RefreshEnergyDecision();
                        int fails = inOutManager.ToaFailsDecision();
                        //farm_toa(refresh_energy, fails, InOutManager);
                        break;
                    case Mode.FooderFarming:
                        refreshEnergy = inOutManager.RefreshEnergyDecision();
                        bool[] farmerPos = { false, false, false, false };

                        //Decide where the farming monster is positioned in the line-up and whether it also levels
                        int farmerLevelPos = inOutManager.FarmerPositionDecision(ref farmerPos);
                        //Decide whether monster should be exchanged automatically
                        bool automaticMonsterReplace = inOutManager.AutomaticMonsterChangeDecision();

                        //functionThread = new Thread(() => farm_fooder(refresh_energy, farmer_pos, farmer_levels_pos, automatic_monster_replace, InOutManager));
                        keyEventThread = new Thread(() => ListerKeyBoardEvent(Thread.CurrentThread));
                        //functionThread.Start();
                        keyEventThread.Start();
                        keyEventThread.Join();
                        //functionThread.Abort();
                        break;
                    case Mode.BeastRifts:
                        refreshEnergy = inOutManager.RefreshEnergyDecision();
                        //functionThread = new Thread(() => farm_beasts(refresh_energy, InOutManager));
                        keyEventThread = new Thread(() => ListerKeyBoardEvent(Thread.CurrentThread));
                        //functionThread.Start();
                        keyEventThread.Start();
                        keyEventThread.Join();
                        //functionThread.Abort();
                        break;
                    case Mode.Debug:
                        Debug();
                        break;
                    case Mode.Exit:
                        return;
                }
            }
        }
    }
}