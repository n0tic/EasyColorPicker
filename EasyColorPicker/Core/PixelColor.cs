using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace EasyColorPicker
{
    public static class PixelColor
    {
        /// <summary>
        /// Get cursor position on screen
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        /// <summary>
        /// Return cursor pixel color object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Color GetCursorPixelColor(object sender, EventArgs e)
        {
            Point cursor = new Point();
            GetCursorPos(ref cursor);

            return GetColorAt(cursor);
        }

        /// <summary>
        /// Screen pixel
        /// </summary>
        private static Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        /// <summary>
        /// Get Color at point location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }
    }
}