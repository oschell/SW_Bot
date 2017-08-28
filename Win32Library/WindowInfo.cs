namespace Win32Library
{
    public struct WindowInfo
    {
        public WindowInfo(int left, int right, int top, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public int Bottom { get; set; }
        public int Height => Bottom - Top + 1;
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Width => Right - Left + 1;
    }
}