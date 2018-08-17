using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Kiss.UI.Controls.Helper
{
    public class PopupHelper
    {
        public static Rect GetWindowRect(Visual visual)
        {
            var hwnd = PresentationSource.FromVisual(visual) as HwndSource;
            if (hwnd == null)
            {
                return Rect.Empty;
            }
            RECT rect;
            GetWindowRect(hwnd.Handle, out rect);
            return new Rect(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left; // X coordinate of topleft point
            public int Top; // Y coordinate of topleft point
            public int Right; // X coordinate of bottomright point
            public int Bottom; // Y coordinate of bottomright point
        }
    }
}
