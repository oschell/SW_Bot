namespace SW_Level_Bot.BotStates
{
    internal enum StateKind
    {
        None,
        InitialRuneFamring,
        LastRuneFarming,
        Win,
        Lose,
        NetworkProblem,
        UnstableNetwork,
        RuneDrop,
        NoRuneDrop,
        GoodRuneDrop,
        BadRuneDrop,
        AfterWin,
        Debug,
    }
}