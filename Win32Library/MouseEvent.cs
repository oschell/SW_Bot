using System;

namespace Win32Library
{
    [Flags]
    enum MouseEvent
    {
        NONE = 0x00,
        MOUSEEVENTF_LEFTDOWN = 0x02,
        MOUSEEVENTF_LEFTUP = 0x04,
        MOUSEEVENTF_RIGHTDOWN = 0x08,
        MOUSEEVENTF_RIGHTUP = 0x10,
    }
}
