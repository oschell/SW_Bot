using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SW_Level_Bot.Randomizer;

namespace SW_Level_Bot
{
    class ButtonPositionAndColorsWindowed : IButtonPositionsAndColors
    {
        public Point WinCondition1Pos { get; } = new Point(547, 108);
        public Color WinCondition1Col { get; } = Color.FromArgb(248, 251, 53);
        public Point WinCondition2Pos { get; } = new Point(692, 304);
        public Color WinCondition2Col { get; } = Color.FromArgb(42, 30, 7);
        public Point CheckRuneDropPos { get; } = new Point(482, 462);
        public Color CheckRuneDropCol { get; } = Color.FromArgb(226, 206, 151);
        public Point CheckSixStarRunePos { get; } = new Point(449, 215);
        public Color CheckSixStarRuneCol { get; } = Color.FromArgb(223, 229, 229);
        public Color CheckLegendCol { get; } = Color.FromArgb(116, 32, 4);
        public Point CheckLegendPos { get; } = new Point(738, 221);
        public Point LoseCondition1Pos { get; } = new Point(366, 388);
        public Color LoseCondition1Col { get; } = Color.FromArgb(240, 62, 112);
        public Point LoseCondition2Pos { get; } = new Point(711, 300);
        public Color LoseCondition2Col { get; } = Color.FromArgb(242, 244, 246);
        public Point NetworkProblems1Pos { get; } = new Point(646, 398);
        public Color NetworkProblems1Col { get; } = Color.FromArgb(245, 229, 169);
        public Point NetworkProblems2Pos { get; } = new Point(663, 276);
        public Color NetworkProblems2Col { get; } = Color.FromArgb(221, 193, 128);
        public Point UnstableConnection1Pos { get; } = new Point(645, 365);
        public Color UnstableConnection1Col { get; } = Color.FromArgb(245, 229, 170);
        public Point UnstableConnection2Pos { get; } = new Point(729, 230);
        public Color UnstableConnection2Col { get; } = Color.FromArgb(188, 162, 99);
        public Point CheckEnergyEmpty1Pos { get; } = new Point(618, 227);
        public Color CheckEnergyEmpty1Col { get; } = Color.FromArgb(223, 194, 126);
        public Point CheckEnergyEmpty2Pos { get; } = new Point(839, 244);
        public Color CheckEnergyEmpty2Col { get; } = Color.FromArgb(178, 156, 109);
        public Point DoubleClickPos
        {
            get
            {
                return new Point(Randomize(200, 570), Randomize(100, 300));
            }
        }

        public Point GetRuneButtonPos
        {
            get
            {
                return new Point(Randomize(40, 650), Randomize(15, 470));
            }
        }
        public Point SellRuneButtonPos
        {
            get
            {
                return new Point(Randomize(40, 480), Randomize(15, 470));
            }
        }
        public Point ConfirmSellRuneButtonPos
        {
            get
            {
                return new Point(Randomize(40, 480), Randomize(15, 360));
            }
        }
        public Point GetMiscButtonPos
        {
            get
            {
                return new Point(Randomize(40, 560), Randomize(5, 465));
            }
        }
        public Point ReplayButtonPos
        {
            get
            {
                return new Point(Randomize(120, 390), Randomize(20, 325));
            }
        }
        public Point StartBattleButtonPos
        {
            get
            {
                return new Point(Randomize(70, 870), Randomize(20, 410));
            }
        }
        public Point NoContinueButtonPos
        {
            get
            {
                return new Point(Randomize(80, 700), Randomize(30, 390));
            }
        }
        public Point SendDataAgainButtonPos
        {
            get
            {
                return new Point(Randomize(60, 480), Randomize(20, 395));
            }
        }
        public Point ResendWinButtonPos
        {
            get
            {
                return new Point(Randomize(60, 480), Randomize(20, 360));
            }
        }
        public Point RefreshEnergyButtonPos
        {
            get
            {
                return new Point(Randomize(40, 480), Randomize(20, 360));
            }
        }
        public Point Energy4CrystalsButtonPos
        {
            get
            {
                return new Point(Randomize(60, 355), Randomize(50, 310));
            }
        }
        public Point Energy4CrystalsConfirmButtonPos
        {
            get
            {
                return new Point(Randomize(60, 480), Randomize(10, 360));
            }
        }
        public Point RefreshedEnergyConfirmButtonPos
        {
            get
            {
                return new Point(Randomize(50, 560), Randomize(20, 360));
            }
        }
        public Point CloseCashShopWindowButtonPos
        {
            get
            {
                return new Point(Randomize(40, 560), Randomize(15, 500));
            }
        }
    }
}
