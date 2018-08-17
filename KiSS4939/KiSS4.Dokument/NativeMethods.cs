using System;
using System.Runtime.InteropServices;
using System.Text;

namespace KiSS4.Dokument
{
	/// <summary>
	/// 
	/// </summary>
	internal static class NativeMethods
	{
		/// <summary>
		/// Brings the window to top.
		/// </summary>
		/// <param name="hwnd">Handle to the window or control.</param>
		/// <returns></returns>
		[DllImport("user32")]
		public static extern int BringWindowToTop(int hwnd);

		/// <summary>
		/// The GetWindowText function copies the text of the specified window's
		/// title bar (if it has one) into a buffer. If the specified window is 
		/// a control, the text of the control is copied. However, GetWindowText
		/// cannot retrieve the text of a control in another application.
		/// </summary>
		/// <param name="h">[in] Handle to the window or control containing the text. </param>
		/// <param name="s">[out] Buffer that will receive the text. If the string is as 
		/// long or longer than the buffer, the string is truncated and terminated 
		/// with a NULL character.</param>
		/// <param name="nMaxCount">[in] Specifies the maximum number of characters
		/// to copy to the buffer, including the NULL character. If the text 
		/// exceeds this limit, it is truncated. </param>
		[DllImport("User32.Dll")]
		public static extern void GetWindowText(IntPtr h, StringBuilder s, int nMaxCount);
	}
}
