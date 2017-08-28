using System;

namespace Win32Library
{
    [Flags]
    internal enum MouseEvent
    {
        None = 0x00,
        LeftDown = 0x02,
        LeftUp = 0x04,
        RightDown = 0x08,
        RightUp = 0x10
    }
}