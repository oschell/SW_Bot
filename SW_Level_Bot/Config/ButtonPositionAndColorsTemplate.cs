using System.Drawing;

namespace SW_Level_Bot.Config
{
    internal class ButtonPositionAndColorsTemplate : IButtonPositionsAndColors
    {
        public ButtonPositionAndColorsTemplate(Color checkEnergyEmpty1Col, Point checkEnergyEmpty1Pos,
            Color checkEnergyEmpty2Col,
            Point checkEnergyEmpty2Pos, Color checkLegendCol, Point checkLegendPos, Color checkRuneDropCol,
            Point checkRuneDropPos, Color checkSixStarRuneCol, Point checkSixStarRunePos,
            Point closeCashShopWindowButtonPos, Point confirmSellRuneButtonPos, Point doubleClickPos,
            Point energy4CrystalsButtonPos, Point energy4CrystalsConfirmButtonPos, Point getMiscButtonPos,
            Point getRuneButtonPos, Color loseCondition1Col, Point loseCondition1Pos, Color loseCondition2Col,
            Point loseCondition2Pos, Color networkProblems1Col, Point networkProblems1Pos, Color networkProblems2Col,
            Point networkProblems2Pos, Point noContinueButtonPos, Point refreshedEnergyConfirmButtonPos,
            Point refreshEnergyButtonPos, Point replayButtonPos, Point resendWinButtonPos, Point sellRuneButtonPos,
            Point sendDataAgainButtonPos, Point startBattleButtonPos, Color unstableConnection1Col,
            Point unstableConnection1Pos, Color unstableConnection2Col, Point unstableConnection2Pos,
            Color winCondition1Col, Point winCondition1Pos, Color winCondition2Col, Point winCondition2Pos)
        {
            CheckEnergyEmpty1Col = checkEnergyEmpty1Col;
            CheckEnergyEmpty1Pos = checkEnergyEmpty1Pos;
            CheckEnergyEmpty2Col = checkEnergyEmpty2Col;
            CheckEnergyEmpty2Pos = checkEnergyEmpty2Pos;
            CheckLegendCol = checkLegendCol;
            CheckLegendPos = checkLegendPos;
            CheckRuneDropCol = checkRuneDropCol;
            CheckRuneDropPos = checkRuneDropPos;
            CheckSixStarRuneCol = checkSixStarRuneCol;
            CheckSixStarRunePos = checkSixStarRunePos;
            CloseCashShopWindowButtonPos = closeCashShopWindowButtonPos;
            ConfirmSellRuneButtonPos = confirmSellRuneButtonPos;
            DoubleClickPos = doubleClickPos;
            Energy4CrystalsButtonPos = energy4CrystalsButtonPos;
            Energy4CrystalsConfirmButtonPos = energy4CrystalsConfirmButtonPos;
            GetMiscButtonPos = getMiscButtonPos;
            GetRuneButtonPos = getRuneButtonPos;
            LoseCondition1Col = loseCondition1Col;
            LoseCondition1Pos = loseCondition1Pos;
            LoseCondition2Col = loseCondition2Col;
            LoseCondition2Pos = loseCondition2Pos;
            NetworkProblems1Col = networkProblems1Col;
            NetworkProblems1Pos = networkProblems1Pos;
            NetworkProblems2Col = networkProblems2Col;
            NetworkProblems2Pos = networkProblems2Pos;
            NoContinueButtonPos = noContinueButtonPos;
            RefreshedEnergyConfirmButtonPos = refreshedEnergyConfirmButtonPos;
            RefreshEnergyButtonPos = refreshEnergyButtonPos;
            ReplayButtonPos = replayButtonPos;
            ResendWinButtonPos = resendWinButtonPos;
            SellRuneButtonPos = sellRuneButtonPos;
            SendDataAgainButtonPos = sendDataAgainButtonPos;
            StartBattleButtonPos = startBattleButtonPos;
            UnstableConnection1Col = unstableConnection1Col;
            UnstableConnection1Pos = unstableConnection1Pos;
            UnstableConnection2Col = unstableConnection2Col;
            UnstableConnection2Pos = unstableConnection2Pos;
            WinCondition1Col = winCondition1Col;
            WinCondition1Pos = winCondition1Pos;
            WinCondition2Col = winCondition2Col;
            WinCondition2Pos = winCondition2Pos;
        }

        public Color CheckEnergyEmpty1Col { get; }
        public Point CheckEnergyEmpty1Pos { get; }
        public Color CheckEnergyEmpty2Col { get; }
        public Point CheckEnergyEmpty2Pos { get; }
        public Color CheckLegendCol { get; }
        public Point CheckLegendPos { get; }
        public Color CheckRuneDropCol { get; }
        public Point CheckRuneDropPos { get; }
        public Color CheckSixStarRuneCol { get; }
        public Point CheckSixStarRunePos { get; }
        public Point CloseCashShopWindowButtonPos { get; }
        public Point ConfirmSellRuneButtonPos { get; }
        public Point DoubleClickPos { get; }
        public Point Energy4CrystalsButtonPos { get; }
        public Point Energy4CrystalsConfirmButtonPos { get; }
        public Point GetMiscButtonPos { get; }
        public Point GetRuneButtonPos { get; }
        public Color LoseCondition1Col { get; }
        public Point LoseCondition1Pos { get; }
        public Color LoseCondition2Col { get; }
        public Point LoseCondition2Pos { get; }
        public Color NetworkProblems1Col { get; }
        public Point NetworkProblems1Pos { get; }
        public Color NetworkProblems2Col { get; }
        public Point NetworkProblems2Pos { get; }
        public Point NoContinueButtonPos { get; }
        public Point RefreshedEnergyConfirmButtonPos { get; }
        public Point RefreshEnergyButtonPos { get; }
        public Point ReplayButtonPos { get; }
        public Point ResendWinButtonPos { get; }
        public Point SellRuneButtonPos { get; }
        public Point SendDataAgainButtonPos { get; }
        public Point StartBattleButtonPos { get; }
        public Color UnstableConnection1Col { get; }
        public Point UnstableConnection1Pos { get; }
        public Color UnstableConnection2Col { get; }
        public Point UnstableConnection2Pos { get; }
        public Color WinCondition1Col { get; }
        public Point WinCondition1Pos { get; }
        public Color WinCondition2Col { get; }
        public Point WinCondition2Pos { get; }
    }
}