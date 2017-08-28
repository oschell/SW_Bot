using System.Runtime.InteropServices;

namespace Win32Library
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rectangle
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}