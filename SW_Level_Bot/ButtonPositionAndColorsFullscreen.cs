using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Level_Bot
{
    class ButtonPositionAndColorsFullscreen : ButtonPositionsAndColors
    {
        public Point WinCondition1Pos { get; } = new Point(890, 390);
        public Color WinCondition1Col { get; } = Color.FromArgb(241, 238, 207);
        public Point WinCondition2Pos { get; } = new Point(830, 540);
        public Color WinCondition2Col { get; } = Color.FromArgb(44, 30, 9);
        public Point DoubleClickPos { get; } = new Point(Randomize(150, 920), Randomize(100, 500));
        public Point CheckRuneDropPos { get; } = new Point(766, 850);
        public Color CheckRuneDropCol { get; } = Color.FromArgb(244, 229, 169);
        public Point CheckSixStarRunePos { get; } = new Point(673, 367);
        public Color CheckSixStarRuneCol { get; } = Color.FromArgb(220, 227, 225);
        public Color CheckLegendCol { get; } = Color.FromArgb(229, 164, 83);
        public Point CheckLegendPos { get; } = new Point(0, 0);
        public Point GetRuneButtonPos { get; } = new Point(Randomize(100, 1060), Randomize(35, 875));
        public Point SellRuneButtonPos { get; } = new Point(Randomize(35, 766), Randomize(30, 850));
        public Point ConfirmSellRuneButtonPos { get; } = new Point(Randomize(100, 731), Randomize(35, 654));
        public Point GetMiscButtonPos { get; } = new Point(Randomize(90, 890), Randomize(2, 900));
        public Point ReplayButtonPos { get; } = new Point(Randomize(200, 560), Randomize(50, 600));
        public Point StartBattleButtonPos { get; } = new Point(Randomize(150, 1500), Randomize(50, 750));
        public Point LoseCondition1Pos { get; } = new Point(502, 702);
        public Color LoseCondition1Col { get; } = Color.FromArgb(235, 40, 90);
        public Point LoseCondition2Pos { get; } = new Point(925, 529);
        public Color LoseCondition2Col { get; } = Color.FromArgb(250, 250, 250);
        public Point NoContinueButtonPos { get; } = new Point(Randomize(150, 1170), Randomize(50, 700));
        public Point NetworkProblems1Pos { get; } = new Point(702, 720);
        public Color NetworkProblems1Col { get; } = Color.FromArgb(245, 229, 172);
        public Point NetworkProblems2Pos { get; } = new Point(1061, 726);
        public Color NetworkProblems2Col { get; } = Color.FromArgb(244, 229, 170);
        public Point SendDataAgainButtonPos { get; } = new Point(Randomize(100, 730), Randomize(50, 720));
        public Point UnstableConnection1Pos { get; } = new Point(621, 669);
        public Color UnstableConnection1Col { get; } = Color.FromArgb(195, 144, 54);
        public Point UnstableConnection2Pos { get; } = new Point(1150, 679);
        public Color UnstableConnection2Col { get; } = Color.FromArgb(195, 149, 59);
        public Point ResendWinButtonPos { get; } = new Point(Randomize(100, 730), Randomize(40, 650));
        public Point CheckEnergyEmpty1Pos { get; } = new Point(729, 657);
        public Color CheckEnergyEmpty1Col { get; } = Color.FromArgb(244, 229, 167);
        public Point CheckEnergyEmpty2Pos { get; } = new Point(1060, 663);
        public Color CheckEnergyEmpty2Col { get; } = Color.FromArgb(246, 231, 168);
        public Point RefreshEnergyButtonPos { get; } = new Point(Randomize(80, 730), Randomize(35, 657));
        public Point Energy4CrystalsButtonPos { get; } = new Point(Randomize(120, 482), Randomize(80, 559));
        public Point Energy4CrystalsConfirmButtonPos { get; } = new Point(Randomize(100, 730), Randomize(20, 640));
        public Point RefreshedEnergyConfirmButtonPos { get; } = new Point(Randomize(80, 900), Randomize(35, 657));
        public Point CloseCashShopWindowButtonPos { get; } = new Point(Randomize(80, 900), Randomize(35, 930));

        static int Randomize(int interval, int value)
        {
            Random rad = new Random();
            return rad.Next(value - interval, value + interval);
        }
    }
}
