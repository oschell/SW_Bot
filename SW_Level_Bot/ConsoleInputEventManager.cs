using System;
using System.Threading.Tasks;

namespace SW_Level_Bot
{
    internal class ConsoleInputEventManager
    {
        public event EventHandler<ConsoleKey> ConsoleKeyDown;

        public bool IsActive { get; private set; }

        public void StartListen()
        {
            if (IsActive) { return; }

            IsActive = true;
            Task.Run(() =>
            {
                while (IsActive)
                {
                    ConsoleKeyDown?.Invoke(this, Console.ReadKey(true).Key);
                }
            });
        }

        public void StopListen()
        {
            IsActive = false;
        }
    }
}