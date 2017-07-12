using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SW_Level_Bot
{
    interface ButtonPositionsAndColors
    {
        Point WinCondition1Pos { get; }
        Color WinCondition1Col { get; }
        Point WinCondition2Pos { get; }
        Color WinCondition2Col { get; }
        Point DoubleClickPos { get; }
        Point CheckRuneDropPos { get; }
        Color CheckRuneDropCol { get; }
        Point CheckSixStarRunePos { get; }
        Color CheckSixStarRuneCol { get; }
        Color CheckLegendCol { get; }
        Point CheckLegendPos { get; }
        Point GetRuneButtonPos { get; }
        Point SellRuneButtonPos { get; }
        Point ConfirmSellRuneButtonPos { get; }
        Point GetMiscButtonPos { get; }
        Point ReplayButtonPos { get; }
        Point StartBattleButtonPos { get; }
        Point LoseCondition1Pos { get; }
        Color LoseCondition1Col { get; }
        Point LoseCondition2Pos { get; }
        Color LoseCondition2Col { get; }
        Point NoContinueButtonPos { get; }
        Point NetworkProblems1Pos { get; }
        Color NetworkProblems1Col { get; }
        Point NetworkProblems2Pos { get; }
        Color NetworkProblems2Col { get; }
        Point SendDataAgainButtonPos { get; }
        Point UnstableConnection1Pos { get; }
        Color UnstableConnection1Col { get; }
        Point UnstableConnection2Pos { get; }
        Color UnstableConnection2Col { get; }
        Point ResendWinButtonPos { get; }
        Point CheckEnergyEmpty1Pos { get; }
        Color CheckEnergyEmpty1Col { get; }
        Point CheckEnergyEmpty2Pos { get; }
        Color CheckEnergyEmpty2Col { get; }
        Point RefreshEnergyButtonPos { get; }
        Point Energy4CrystalsButtonPos { get; }
        Point Energy4CrystalsConfirmButtonPos { get; }
        Point RefreshedEnergyConfirmButtonPos { get; }
        Point CloseCashShopWindowButtonPos { get; }

    }
}
