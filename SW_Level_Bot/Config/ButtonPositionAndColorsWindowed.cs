using System;
using System.Drawing;
using SW_Level_Bot.ExtensionMethods;

namespace SW_Level_Bot.Config
{
    internal class ButtonPositionAndColorsWindowed : IButtonPositionsAndColors
    {
        private static readonly Random Random = new Random();
        public Color CheckEnergyEmpty1Col { get; } = Color.FromArgb(222, 195, 124);
        public Point CheckEnergyEmpty1Pos { get; } = new Point(564, 195);
        public Color CheckEnergyEmpty2Col { get; } = Color.FromArgb(172, 150, 100);
        public Point CheckEnergyEmpty2Pos { get; } = new Point(723, 218);
        public Color CheckLegendCol { get; } = Color.FromArgb(116, 32, 4);
        public Point CheckLegendPos { get; } = new Point(636, 191);
        public Color CheckRuneDropCol { get; } = Color.FromArgb(243, 224, 161);
        public Point CheckRuneDropPos { get; } = new Point(428, 388);
        public Color CheckSixStarRuneCol { get; } = Color.FromArgb(240, 241, 239);
        public Point CheckSixStarRunePos { get; } = new Point(401, 184);

        public Point CloseCashShopWindowButtonPos =>
            new Point(Random.FromInterval(495, 40), Random.FromInterval(415, 10));

        public Point ConfirmSellRuneButtonPos => new Point(Random.FromInterval(425, 40), Random.FromInterval(305, 15));

        public Point DoubleClickPos => new Point(Random.FromInterval(500, 200), Random.FromInterval(260, 100));

        public Point Energy4CrystalsButtonPos => new Point(Random.FromInterval(330, 60), Random.FromInterval(260, 40));

        public Point Energy4CrystalsConfirmButtonPos =>
            new Point(Random.FromInterval(425, 40), Random.FromInterval(310, 10));

        public Point GetMiscButtonPos => new Point(Random.FromInterval(495, 40), Random.FromInterval(387, 3));

        public Point GetRuneButtonPos => new Point(Random.FromInterval(565, 40), Random.FromInterval(395, 15));

        public Color LoseCondition1Col { get; } = Color.FromArgb(237, 46, 98);
        public Point LoseCondition1Pos { get; } = new Point(333, 326);
        public Color LoseCondition2Col { get; } = Color.FromArgb(250, 251, 251);
        public Point LoseCondition2Pos { get; } = new Point(556, 254);
        public Color NetworkProblems1Col { get; } = Color.FromArgb(224, 192, 125);
        public Point NetworkProblems1Pos { get; } = new Point(658, 199);
        public Color NetworkProblems2Col { get; } = Color.FromArgb(244, 229, 169);
        public Point NetworkProblems2Pos { get; } = new Point(415, 305);

        public Point NoContinueButtonPos => new Point(Random.FromInterval(610, 70), Random.FromInterval(325, 20));

        public Point RefreshedEnergyConfirmButtonPos =>
            new Point(Random.FromInterval(495, 40), Random.FromInterval(305, 15));

        public Point RefreshEnergyButtonPos => new Point(Random.FromInterval(425, 40), Random.FromInterval(305, 15));

        public Point ReplayButtonPos => new Point(Random.FromInterval(350, 100), Random.FromInterval(275, 15));

        public Point ResendWinButtonPos => new Point(Random.FromInterval(425, 40), Random.FromInterval(330, 15));

        public Point SellRuneButtonPos => new Point(Random.FromInterval(430, 40), Random.FromInterval(395, 15));

        public Point SendDataAgainButtonPos => new Point(Random.FromInterval(425, 40), Random.FromInterval(305, 15));

        public Point StartBattleButtonPos => new Point(Random.FromInterval(745, 45), Random.FromInterval(350, 20));

        public Color UnstableConnection1Col { get; } = Color.FromArgb(220, 193, 124);
        public Point UnstableConnection1Pos { get; } = new Point(666, 204);
        public Color UnstableConnection2Col { get; } = Color.FromArgb(218, 190, 135);
        public Point UnstableConnection2Pos { get; } = new Point(616, 231);
        public Color WinCondition1Col { get; } = Color.FromArgb(252, 189, 6);

        public Point WinCondition1Pos { get; } = new Point(387, 117);
        public Color WinCondition2Col { get; } = Color.FromArgb(254, 248, 194);
        public Point WinCondition2Pos { get; } = new Point(532, 106);
    }
}