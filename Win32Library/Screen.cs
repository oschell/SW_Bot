using System.Drawing;
using System.Windows.Forms;

namespace Win32Library
{
    public static class Screen
    {
        public static Color GetPixel(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }

                return bitmap.GetPixel(0, 0);
            }
        }

        public static void TakeScreenshot(string path, int nr)
        {
            using (var bitmap = new Bitmap(SystemInformation.VirtualScreen.Width,
                SystemInformation.VirtualScreen.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                }

                bitmap.Save($"{path}{nr}.gif");
            }
        }
    }
}