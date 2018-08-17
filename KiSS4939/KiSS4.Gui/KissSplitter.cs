using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissSplitter.
    /// </summary>
    public class KissSplitter : Splitter
    {
        private int defaultPosition = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="KissSplitter"/> class.
        /// </summary>
        public KissSplitter()
        {
            base.Width = 3;
            base.Height = 3;
            if (GuiConfig.Theme == GuiConfig.KissTheme.None)
            {
                base.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(231)), ((System.Byte)(219)),
                                                               ((System.Byte)(173)));
            }
            else
            {
                base.BackColor = GuiConfig.colBack04;
            }
        }

        #region Public properties

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value></value>
        /// <returns>The height of the control in pixels.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [DefaultValue(3)]
        public new int Height
        {
            set { base.Height = value; }
            get { return base.Height; }
        }

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value></value>
        /// <returns>The width of the control in pixels.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [DefaultValue(3)]
        public new int Width
        {
            set { base.Width = value; }
            get { return base.Width; }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"></see> property.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [DefaultValue(typeof(Color), "231, 219, 173")]
        public new Color BackColor
        {
            set { base.BackColor = value; }
            get { return base.BackColor; }
        }

        #endregion

        #region Events

        /// <summary>
        /// The SplitterMoving event, used to move the splitter using drag and drop
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnSplitterMoving(System.Windows.Forms.SplitterEventArgs e)
        {
            if (this.defaultPosition < 0)
            {
                // save its default position
                this.defaultPosition = base.SplitPosition;
            }

            base.OnSplitterMoving(e);
        }

        /// <summary>
        /// The DoubleClick event, used to reset the splitter position to inital value
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnDoubleClick(System.EventArgs e)
        {
            base.OnDoubleClick(e);
            this.ResetSplitterPosition();
        }

        /// <summary>
        /// The MouseUp event, used to reset splitter
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Right)
            {
                this.ResetSplitterPosition();
            }
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Reset splitter position to its initial default value
        /// </summary>
        private void ResetSplitterPosition()
        {
            if (this.defaultPosition > -1)
            {
                // restore default position
                base.SplitPosition = this.defaultPosition;
            }
        }

        #endregion
    }
}