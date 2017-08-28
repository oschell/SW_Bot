using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Win32Library
{
    public static class Mouse
    {
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
            RightClick(position);
        }

        public static void LeftClick(Point position)
        {
            Click(position, MouseEvent.LeftDown, MouseEvent.LeftUp);
        }

        public static void LeftDown(Point position)
        {
            Click(position, MouseEvent.LeftDown, MouseEvent.None);
        }

        public static void LeftUp(Point position)
        {
            Click(position, MouseEvent.None, MouseEvent.LeftUp);
        }

        public static void RightClick(Point position)
        {
            Click(position, MouseEvent.RightDown, MouseEvent.RightUp);
        }

        private static void Click(Point position, MouseEvent down, MouseEvent up)
        {
            Cursor.Position = position;
            SendMouseEvent((uint)(down | up), (uint)position.X, (uint)position.Y, 0, UIntPtr.Zero);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            EntryPoint = "mouse_event")]
        private static extern void SendMouseEvent(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
    }
}