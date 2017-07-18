using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using static Win32Library.MouseEvent;

namespace Win32Library
{
    public static class Mouse
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, EntryPoint = "mouse_event")]
        private static extern void MouseEvent(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);

        private static void Click(Point position, MouseEvent down, MouseEvent up)
        {
            Cursor.Position = position;
            MouseEvent((uint)(down | up), (uint)position.X, (uint)position.Y, 0, UIntPtr.Zero);
        }

        public static void LeftClick(Point position)
        {
            Click(position, MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
        }

        public static void RightClick(Point position)
        {
            Click(position, MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP);
        }

        public static void DoubleLeftClick(Point position)
        {
            LeftClick(position);
            Thread.Sleep(new Random().Next(250, 750));
            LeftClick(position);
        }

        public static void DoubleRightClick(Point position)
        {
            RightClick(position);
            Thread.Sleep(new Random().Next(250, 750));
            LeftClick(position);
        }

        public static void LeftDown(Point position)
        {
            Click(position, MOUSEEVENTF_LEFTDOWN, NONE);
        }

        public static void LeftUp(Point position)
        {
            Click(position, NONE, MOUSEEVENTF_LEFTUP);
        }
    }
}
