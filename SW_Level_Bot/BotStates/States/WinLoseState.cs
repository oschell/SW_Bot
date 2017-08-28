using SW_Level_Bot.Config;
using SW_Level_Bot.ExtensionMethods;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal abstract class WinLoseState : IState
    {
        public abstract IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats);

        protected bool CheckEnergyEmpty(IButtonPositionsAndColors posColorManager, bool refreshEnergy)
        {
            var energyEmpty = refreshEnergy &&
                              posColorManager.CheckEnergyEmpty1Col.Matches(
                                  Screen.GetPixel(posColorManager.CheckEnergyEmpty1Pos)) &&
                              posColorManager.CheckEnergyEmpty2Col.Matches(
                                  Screen.GetPixel(posColorManager.CheckEnergyEmpty2Pos));

            if (energyEmpty)
            {
                PerformEnergyRefilling(posColorManager);
            }

            return energyEmpty;
        }

        protected void RefillEnergy(IButtonPositionsAndColors posColorManager)
        {
            Mouse.LeftClick(posColorManager.RefreshEnergyButtonPos);
            ExecutionDelay.DelayFor(1500, 300);
            Mouse.LeftClick(posColorManager.Energy4CrystalsButtonPos);
            ExecutionDelay.DelayFor(1500, 300);
            Mouse.LeftClick(posColorManager.Energy4CrystalsConfirmButtonPos);
            ExecutionDelay.DelayFor(4000, 300);
            Mouse.LeftClick(posColorManager.RefreshedEnergyConfirmButtonPos);
            ExecutionDelay.DelayFor(1500, 300);
            Mouse.LeftClick(posColorManager.CloseCashShopWindowButtonPos);
            ExecutionDelay.DelayFor(1500, 300);
        }

        protected int StartNewRound(IButtonPositionsAndColors posColorManager, bool refreshEnergy)
        {
            //Start a new round
            Mouse.LeftClick(posColorManager.ReplayButtonPos);
            ExecutionDelay.DelayFor(2300, 300);

            var refreshedEnergy = CheckEnergyEmpty(posColorManager, refreshEnergy) ? 1 : 0;

            Mouse.LeftClick(posColorManager.StartBattleButtonPos);
            ExecutionDelay.DelayFor(1000, 300);

            return refreshedEnergy;
        }

        private void PerformEnergyRefilling(IButtonPositionsAndColors posColorManager)
        {
            RefillEnergy(posColorManager);
            ExecutionDelay.DelayFor(2000, 300);
            Mouse.LeftClick(posColorManager.ReplayButtonPos);
            ExecutionDelay.DelayFor(2500, 300);
        }
    }
}