using System.ComponentModel.Design;
//------------------------------------------------------------------------------
/// <copyright from='1997' to='2002' company='Microsoft Corporation'>
///    Copyright (c) Microsoft Corporation. All Rights Reserved.
///
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>
//------------------------------------------------------------------------------
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace KiSS4.DesignerHost
{
	/// This filter is used to catch keyboard input that is meant for the designer.
	/// It does not prevent the message from continuing, but instead merely
	/// deciphers the keystroke and performs the appropriate MenuCommand.
	public class KeystrokeMessageFilter : System.Windows.Forms.IMessageFilter
	{
        const uint WM_KEYDOWN = 0x100;
        const uint WM_KEYUP = 0x101;

		private MyDesignSurface designSurfase;

        public KeystrokeMessageFilter(MyDesignSurface designSurfase)
		{
            this.designSurfase = designSurfase;
		}
		#region Implementation of IMessageFilter

        private IMenuCommandService mcs
        {
            get { return (IMenuCommandService)designSurfase.GetService(typeof(IMenuCommandService)); }
        }

		public bool PreFilterMessage(ref Message m)
		{
            // HACK DevExpress Barmanager catch the WM_KEYDOWN + C/V/X Message in a MessageFilter
            if (m.Msg == WM_KEYUP)
            {
                if (((Control)designSurfase.View).Focused)
                {
                    // WM_KEYCHAR only tells us the last key pressed. Thus we check
                    // Control for modifier keys (Control, Shift, etc.)
                    switch (((int)m.WParam) | ((int)Control.ModifierKeys))
                    {
                        case (int)(Keys.Control | Keys.C): mcs.GlobalInvoke(MenuCommands.Copy);
                            break;
                        case (int)(Keys.Control | Keys.X): mcs.GlobalInvoke(MenuCommands.Cut);
                            break;
                        case (int)(Keys.Control | Keys.V): mcs.GlobalInvoke(MenuCommands.Paste);
                            break;

                    }
                }
            }
            if (m.Msg == WM_KEYDOWN)
			{
                if ( ((Control)designSurfase.View).Focused )
				{
					// WM_KEYCHAR only tells us the last key pressed. Thus we check
					// Control for modifier keys (Control, Shift, etc.)
					switch (((int)m.WParam) | ((int)Control.ModifierKeys))
					{
						case (int)Keys.Up: mcs.GlobalInvoke(MenuCommands.KeyMoveUp);
							break;
						case (int)Keys.Down: mcs.GlobalInvoke(MenuCommands.KeyMoveDown);
							break;
						case (int)Keys.Right: mcs.GlobalInvoke(MenuCommands.KeyMoveRight);
							break;
						case (int)Keys.Left: mcs.GlobalInvoke(MenuCommands.KeyMoveLeft);
							break;
						case (int)(Keys.Control | Keys.Up): mcs.GlobalInvoke(MenuCommands.KeyNudgeUp);
							break;
						case (int)(Keys.Control | Keys.Down): mcs.GlobalInvoke(MenuCommands.KeyNudgeDown);
							break;
						case (int)(Keys.Control | Keys.Right): mcs.GlobalInvoke(MenuCommands.KeyNudgeRight);
							break;
						case (int)(Keys.Control | Keys.Left): mcs.GlobalInvoke(MenuCommands.KeyNudgeLeft);
							break;
						case (int)(Keys.Shift | Keys.Up): mcs.GlobalInvoke(MenuCommands.KeySizeHeightDecrease);
							break;
						case (int)(Keys.Shift | Keys.Down): mcs.GlobalInvoke(MenuCommands.KeySizeHeightIncrease);
							break;
						case (int)(Keys.Shift | Keys.Right): mcs.GlobalInvoke(MenuCommands.KeySizeWidthIncrease);
							break;
						case (int)(Keys.Shift | Keys.Left): mcs.GlobalInvoke(MenuCommands.KeySizeWidthDecrease);
							break;
						case (int)(Keys.Control | Keys.Shift | Keys.Up): mcs.GlobalInvoke(MenuCommands.KeyNudgeHeightDecrease);
							break;
						case (int)(Keys.Control | Keys.Shift | Keys.Down): mcs.GlobalInvoke(MenuCommands.KeyNudgeHeightIncrease);
							break;
						case (int)(Keys.Control | Keys.Shift | Keys.Right): mcs.GlobalInvoke(MenuCommands.KeyNudgeWidthIncrease);
							break;
						case (int)(Keys.Control | Keys.Shift | Keys.Left): mcs.GlobalInvoke(MenuCommands.KeyNudgeWidthDecrease);
							break;
						case (int)(Keys.Escape): mcs.GlobalInvoke(MenuCommands.KeyCancel);
							break;
						case (int)(Keys.Shift | Keys.Escape): mcs.GlobalInvoke(MenuCommands.KeyReverseCancel);
							break;
						case (int)(Keys.Delete): mcs.GlobalInvoke(StandardCommands.Delete);
							break;
					}
				}

				// If the user selected a control in the toolbox, then moved with the cursor over the designed control (without drag and drop),
				// he can cancel the operation by pressing 'Esc'. This is required because the focus is on the toolbox, not on the designed control
				ToolboxPane toolbox = designSurfase.GetService(typeof(ToolboxPane)) as ToolboxPane;
				if (toolbox != null && toolbox.ContainsFocus)
				{
					switch (((int)m.WParam) | ((int)Control.ModifierKeys))
					{
						case (int)(Keys.Escape): mcs.GlobalInvoke(MenuCommands.KeyCancel);
							break;
					}
				}
			}

			// Never filter the message
			return false;
		}

		#endregion
	}
}
