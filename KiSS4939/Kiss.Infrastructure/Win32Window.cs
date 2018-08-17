using System;
using System.Windows;
using System.Windows.Interop;

using IWin32Window = System.Windows.Forms.IWin32Window;

namespace Kiss.Infrastructure
{
    public class Win32Window : IWin32Window
    {
        public Win32Window(Window window)
        {
            Handle = new WindowInteropHelper(window).Handle;
        }

        public IntPtr Handle
        {
            get;
            private set;
        }
    }
}