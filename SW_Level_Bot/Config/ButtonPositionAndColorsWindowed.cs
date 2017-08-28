using System;
using System.Drawing;
using SW_Level_Bot.ExtensionMethods;

namespace SW_Level_Bot.Config
{
    internal class ButtonPositionAndColorsWindowed : IButtonPositionsAndColors
    {
        private static readonly Random Random = new Random();

        public Point WinCondition1Pos { get; } = new Point(387, 117);
        public Color WinCondition1Col { get; } = Color.FromArgb(252, 189, 6);
        public Point WinCondition2Pos { get; } = new Point(532, 106);
        public Color WinCondition2Col { get; } = Color.FromArgb(254, 248, 194);
        public Point CheckRuneDropPos { get; } = new Point(428, 388);
        public Color CheckRuneDropCol { get; } = Color.FromArgb(243, 224, 161);
        public Point CheckSixStarRunePos { get; } = new Point(401, 184);
        public Color CheckSixStarRuneCol { get; } = Color.FromArgb(240, 241, 239);
        public Color CheckLegendCol { get; } = Color.FromArgb(116, 32, 4);
        public Point CheckLegendPos { get; } = new Point(636, 191);
        public Point LoseCondition1Pos { get; } = new Point(333, 326);
        public Color LoseCondition1Col { get; } = Color.FromArgb(237, 46, 98);
        public Point LoseCondition2Pos { get; } = new Point(556, 254);
        public Color LoseCondition2Col { get; } = Color.FromArgb(250, 251, 251);
        public Point NetworkProblems1Pos { get; } = new Point(658, 199);
        public Color NetworkProblems1Col { get; } = Color.FromArgb(224, 192, 125);
        public Point NetworkProblems2Pos { get; } = new Point(415, 305);
        public Color NetworkProblems2Col { get; } = Color.FromArgb(244, 229, 169);
        public Point UnstableConnection1Pos { get; } = new Point(666, 204);
        public Color UnstableConnection1Col { get; } = Color.FromArgb(220, 193, 124);
        public Point UnstableConnection2Pos { get; } = new Point(616, 231);
        public Color UnstableConnection2Col { get; } = Color.FromArgb(218, 190, 135);
        public Point CheckEnergyEmpty1Pos { get; } = new Point(564, 195);
        public Color CheckEnergyEmpty1Col { get; } = Color.FromArgb(222, 195, 124);
        public Point CheckEnergyEmpty2Pos { get; } = new Point(723, 218);
        public Color CheckEnergyEmpty2Col { get; } = Color.FromArgb(172, 150, 100);
        public Point DoubleClickPos
        {
            get
            {
                return new Point(Random.FromInterval(200, 500), Random.FromInterval(100, 260));
            }
        }

        public Point GetRuneButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 565), Random.FromInterval(15, 395));
            }
        }
        public Point SellRuneButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 430), Random.FromInterval(15, 395));
            }
        }
        public Point ConfirmSellRuneButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 425), Random.FromInterval(15, 305));
            }
        }
        public Point GetMiscButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 495), Random.FromInterval(3, 387));
            }
        }
        public Point ReplayButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(100, 350), Random.FromInterval(15, 275));
            }
        }
        public Point StartBattleButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(45, 745), Random.FromInterval(20, 350));
            }
        }
        public Point NoContinueButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(70, 610), Random.FromInterval(20, 325));
            }
        }
        public Point SendDataAgainButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 425), Random.FromInterval(15, 305));
            }
        }
        public Point ResendWinButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 425), Random.FromInterval(15, 330));
            }
        }
        public Point RefreshEnergyButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 425), Random.FromInterval(15, 305));
            }
        }
        public Point Energy4CrystalsButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(60, 330), Random.FromInterval(40, 260));
            }
        }
        public Point Energy4CrystalsConfirmButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 425), Random.FromInterval(10, 310));
            }
        }
        public Point RefreshedEnergyConfirmButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 495), Random.FromInterval(15, 305));
            }
        }
        public Point CloseCashShopWindowButtonPos
        {
            get
            {
                return new Point(Random.FromInterval(40, 495), Random.FromInterval(10, 415));
            }
        }
    }
}