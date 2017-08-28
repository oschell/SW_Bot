using System;
using System.Drawing;
using System.Windows.Forms;
using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;
using Screen = Win32Library.Screen;

namespace SW_Level_Bot.BotStates.States
{
    internal class DebugState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            Console.WriteLine($"Position X is: {Cursor.Position.X} Position Y is: {Cursor.Position.Y}"
                              + "\n R:" + Screen.GetPixel(new Point(Cursor.Position.X, Cursor.Position.Y)).R
                              + "\n G: " + Screen.GetPixel(new Point(Cursor.Position.X, Cursor.Position.Y)).G
                              + "\n B: " + Screen.GetPixel(new Point(Cursor.Position.X, Cursor.Position.Y)).B +
                              "\n");
            ExecutionDelay.DelayFor(1500);

            return StateManager.Instance[StateKind.Debug];
        }
    }
}