using System.Drawing;

namespace SW_Level_Bot.Config
{
    internal interface IButtonPositionsAndColors
    {
        Color CheckEnergyEmpty1Col { get; }
        Point CheckEnergyEmpty1Pos { get; }
        Color CheckEnergyEmpty2Col { get; }
        Point CheckEnergyEmpty2Pos { get; }
        Color CheckLegendCol { get; }
        Point CheckLegendPos { get; }
        Color CheckRuneDropCol { get; }
        Point CheckRuneDropPos { get; }
        Color CheckSixStarRuneCol { get; }
        Point CheckSixStarRunePos { get; }
        Point CloseCashShopWindowButtonPos { get; }
        Point ConfirmSellRuneButtonPos { get; }
        Point DoubleClickPos { get; }
        Point Energy4CrystalsButtonPos { get; }
        Point Energy4CrystalsConfirmButtonPos { get; }
        Point GetMiscButtonPos { get; }
        Point GetRuneButtonPos { get; }
        Color LoseCondition1Col { get; }
        Point LoseCondition1Pos { get; }
        Color LoseCondition2Col { get; }
        Point LoseCondition2Pos { get; }
        Color NetworkProblems1Col { get; }
        Point NetworkProblems1Pos { get; }
        Color NetworkProblems2Col { get; }
        Point NetworkProblems2Pos { get; }
        Point NoContinueButtonPos { get; }
        Point RefreshedEnergyConfirmButtonPos { get; }
        Point RefreshEnergyButtonPos { get; }
        Point ReplayButtonPos { get; }
        Point ResendWinButtonPos { get; }
        Point SellRuneButtonPos { get; }
        Point SendDataAgainButtonPos { get; }
        Point StartBattleButtonPos { get; }
        Color UnstableConnection1Col { get; }
        Point UnstableConnection1Pos { get; }
        Color UnstableConnection2Col { get; }
        Point UnstableConnection2Pos { get; }
        Color WinCondition1Col { get; }
        Point WinCondition1Pos { get; }
        Color WinCondition2Col { get; }
        Point WinCondition2Pos { get; }
    }
}