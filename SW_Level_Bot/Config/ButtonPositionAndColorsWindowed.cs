using System;
using System.Drawing;
using SW_Level_Bot.ExtensionMethods;

namespace SW_Level_Bot.Config
{
    internal class ButtonPositionAndColorsWindowed : IButtonPositionsAndColors
    {
        private static readonly Random Random = new Random();

        public Color CheckEnergyEmpty1Col { get; } = Color.FromArgb(223, 194, 126);
        public Point CheckEnergyEmpty1Pos { get; } = new Point(618, 227);
        public Color CheckEnergyEmpty2Col { get; } = Color.FromArgb(178, 156, 109);
        public Point CheckEnergyEmpty2Pos { get; } = new Point(839, 244);
        public Color CheckLegendCol { get; } = Color.FromArgb(116, 32, 4);
        public Point CheckLegendPos { get; } = new Point(738, 221);
        public Color CheckRuneDropCol { get; } = Color.FromArgb(226, 206, 151);
        public Point CheckRuneDropPos { get; } = new Point(482, 462);
        public Color CheckSixStarRuneCol { get; } = Color.FromArgb(223, 229, 229);
        public Point CheckSixStarRunePos { get; } = new Point(449, 215);

        public Point CloseCashShopWindowButtonPos { get; } =
            new Point(Random.FromInterval(560, 40), Random.FromInterval(500, 15));

        public Point ConfirmSellRuneButtonPos { get; } =
            new Point(Random.FromInterval(480, 40), Random.FromInterval(360, 15));

        public Point DoubleClickPos { get; } =
            new Point(Random.FromInterval(570, 200), Random.FromInterval(300, 100));

        public Point Energy4CrystalsButtonPos { get; } =
            new Point(Random.FromInterval(355, 60), Random.FromInterval(310, 50));

        public Point Energy4CrystalsConfirmButtonPos { get; } =
            new Point(Random.FromInterval(480, 60), Random.FromInterval(360, 10));

        public Point GetMiscButtonPos { get; } = new Point(Random.FromInterval(560, 40), Random.FromInterval(465, 5));

        public Point GetRuneButtonPos { get; } =
            new Point(Random.FromInterval(650, 40), Random.FromInterval(470, 15));

        public Color LoseCondition1Col { get; } = Color.FromArgb(240, 62, 112);
        public Point LoseCondition1Pos { get; } = new Point(366, 388);
        public Color LoseCondition2Col { get; } = Color.FromArgb(242, 244, 246);
        public Point LoseCondition2Pos { get; } = new Point(711, 300);
        public Color NetworkProblems1Col { get; } = Color.FromArgb(245, 229, 169);
        public Point NetworkProblems1Pos { get; } = new Point(646, 398);
        public Color NetworkProblems2Col { get; } = Color.FromArgb(221, 193, 128);
        public Point NetworkProblems2Pos { get; } = new Point(663, 276);

        public Point NoContinueButtonPos { get; } =
            new Point(Random.FromInterval(700, 80), Random.FromInterval(390, 30));

        public Point RefreshedEnergyConfirmButtonPos { get; } =
            new Point(Random.FromInterval(560, 50), Random.FromInterval(360, 20));

        public Point RefreshEnergyButtonPos { get; } =
            new Point(Random.FromInterval(480, 40), Random.FromInterval(360, 20));

        public Point ReplayButtonPos { get; } =
            new Point(Random.FromInterval(390, 120), Random.FromInterval(325, 20));

        public Point ResendWinButtonPos { get; } =
            new Point(Random.FromInterval(480, 60), Random.FromInterval(360, 20));

        public Point SellRuneButtonPos { get; } =
            new Point(Random.FromInterval(480, 40), Random.FromInterval(470, 15));

        public Point SendDataAgainButtonPos { get; } =
            new Point(Random.FromInterval(480, 60), Random.FromInterval(395, 20));

        public Point StartBattleButtonPos { get; } =
            new Point(Random.FromInterval(870, 70), Random.FromInterval(410, 20));

        public Color UnstableConnection1Col { get; } = Color.FromArgb(245, 229, 170);
        public Point UnstableConnection1Pos { get; } = new Point(645, 365);
        public Color UnstableConnection2Col { get; } = Color.FromArgb(188, 162, 99);
        public Point UnstableConnection2Pos { get; } = new Point(729, 230);
        public Color WinCondition1Col { get; } = Color.FromArgb(248, 251, 53);

        public Point WinCondition1Pos { get; } = new Point(547, 108);
        public Color WinCondition2Col { get; } = Color.FromArgb(42, 30, 7);
        public Point WinCondition2Pos { get; } = new Point(692, 304);
    }
}