using System;
using System.ComponentModel;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui.Designer;

namespace KiSS4.Gui
{
    /// <summary>
    /// Implementiert einen KiSS Hyperlink Button.
    /// </summary>
    [ToolboxItem(true)]
    public sealed partial class KissHyperlinkButton : KissButton
    {
        #region Fields

        #region Private Fields

        private string _context;
        private string _url;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissHyperlinkButton"/> class
        /// </summary>
        public KissHyperlinkButton()
        {
            InitializeComponent();
            Click += kissHyperlinkButton_Click;
            Font tempFont = new Font(Font, FontStyle.Underline);
            ButtonStyle = ButtonStyleType.Custom;
            Font = tempFont;
            ForeColor = Color.Blue;
            FlatAppearance.BorderColor = Color.Black;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The context in which the user can choose a link
        /// </summary>
        [TypeConverter(typeof(HyperlinkContextConverter))]
        [Description("The context in which the user can choose a link")]
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// The URL to open
        /// </summary>
        [Description("The URL to open")]
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Eventhandler: the user has clicked the button
        /// opens the url or the selected link
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void kissHyperlinkButton_Click(object sender, EventArgs e)
        {
            string link = _url;

            if (!string.IsNullOrEmpty(_context))
            {
                var dlg = new DlgSelectHyperlink();

                if (dlg.SelectHyperlink(this, _context))
                {
                    link = dlg["Hyperlink"] as string;
                }
                else if (dlg.UserCancel)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(link))
            {
                try
                {
                    System.Diagnostics.Process.Start(link);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("KissHyperlinkButton", "InvalidLink", "Der Link '{0}' ist ungültig", ex.Message, ex, 0, 0, link);
                }
            }
        }

        #endregion
    }
}