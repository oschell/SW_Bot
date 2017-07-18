using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Win32Library
{
    public class Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static Form FindByName(string name)
        {
            var windowHandle = FindWindow(null, name);
            return windowHandle != IntPtr.Zero ? FindByHandle(windowHandle) : null;
        }

        public static Form FindByHandle(IntPtr handle)
        {
            return (Form)Control.FromHandle(handle);
        }

        public static bool Move(string name, Point position, int width, int height)
        {
            var windowHandle = FindWindow(null, name);
            return windowHandle != IntPtr.Zero ? MoveWindow(windowHandle, position.X, position.Y, width, height, true) : false;
        }

        public static bool GetRectangle(IntPtr handle, out Rectangle rectangle)
        {
            return GetWindowRect(handle, out rectangle);
        }

        public static IntPtr GetHandle(string name)
        {
            return FindWindow(null, name);
        }
    }
}
