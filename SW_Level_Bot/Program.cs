using System;
using System.Drawing;
using System.Windows.Forms;
using SW_Level_Bot.Config;
using SW_Level_Bot.IO;
using SW_Level_Bot.Modes;
using SW_Level_Bot.Properties;
using Win32Library;

namespace SW_Level_Bot
{
    internal class Program
    {
        private static ConsoleInputEventManager GetConsoleManager(BotMode mode)
        {
            var inputEventManager = new ConsoleInputEventManager();
            inputEventManager.ConsoleKeyDown += (_, key) =>
            {
                if (key == ConsoleKey.Escape)
                {
                    mode.Stop();
                }
            };

            return inputEventManager;
        }

        private static void Main(string[] args)
        {
            var windowName = Settings.Default.WindowName;

            if (!Window.GetWindowInfo(Window.GetHandle(windowName), out var windowInfo))
            {
                MessageBox.Show($"{windowName} was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Window.Move(windowName, new Point(0, 0), 1027, 516);

            var modeFactory = new ModeFactory();
            var inOutManager = new InputOutput();
            //var posColorManager = new ConfigConverter().Deserialize();
            var posColorManager = new ButtonPositionAndColorsWindowed();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{windowName} resolution should be: 1211 x 607");
                Console.WriteLine($"The current window resolution denotes: {windowInfo.Width}x{windowInfo.Height}");

                var selectedMode = inOutManager.SelectMode();
                var mode = modeFactory.Create(selectedMode);
                GetConsoleManager(mode).StartListen();

                switch (selectedMode)
                {
                    case Mode.GeneralFarming:
                        var refreshEnergy = inOutManager.RefreshEnergyDecision();
                        mode.Start(posColorManager, new ModeConfig { RefreshEnergy = refreshEnergy });
                        break;
                    case Mode.Debug:
                        mode.Start();
                        break;
                    case Mode.Exit:
                        return;
                    default:
                        throw new ArgumentException("Mode is not implemented");
                }
            }
        }
    }
}