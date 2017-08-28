using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;

namespace SW_Level_Bot.BotStates.States
{
    internal interface IState
    {
        IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats);
    }
}