using System;
using System.ComponentModel;
using System.Diagnostics;

using KiSS4.DB;

using KiSS.DBScheme;

using DevExpress.XtraBars;

namespace KiSS4.Gui
{
    /// <summary>
    /// A <see cref="BarButtonItem"/> that acts as a hyperlink.
    /// </summary>
    [ToolboxItem(true)]
    public partial class KissHyperlinkBarButtonItem : BarButtonItem
    {
        #region Constructors

        public KissHyperlinkBarButtonItem(BarSubItem parent, string caption, string configKey = "")
            : this(parent)
        {
            base.Caption = caption;

            ConfigKey = configKey;

            UpdateProperties();
        }

        public KissHyperlinkBarButtonItem(BarSubItem parent, int xHyperlinkId)
            : this(parent)
        {
            if (xHyperlinkId <= 0)
            {
                throw new ArgumentOutOfRangeException("xHyperlinkId", xHyperlinkId, "The ID must be positive.");
            }

            XHyperlinkId = xHyperlinkId;

            UpdateProperties();
        }

        public KissHyperlinkBarButtonItem()
        {
            InitializeComponent();
        }

        private KissHyperlinkBarButtonItem(BarSubItem parent)
            : this()
        {
            parent.ItemLinks.Add(this);

            parent.Popup += parent_Popup;

            //UseOwnFont = true;
            //OwnFont = new Font(OwnFont, FontStyle.Underline);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the key of a config value to use as URL.
        /// </summary>
        [DefaultValue("")]
        public string ConfigKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the hyperlink associated with this button.
        /// </summary>
        [DefaultValue("")]
        public string URL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ID of the XHyperlink item.
        /// </summary>
        [DefaultValue(0)]
        public int XHyperlinkId
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void parent_Popup(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnClick(BarItemLink link)
        {
            UpdateProperties();

            if (!string.IsNullOrEmpty(URL))
            {
                try
                {
                    var startInfo = new ProcessStartInfo(URL)
                    {
                        Verb = "Open",
                        UseShellExecute = true
                    };

                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(
                        typeof(KissHyperlinkBarButtonItem).Name,
                        "FehlerLinkOeffnen",
                        "Fehler beim Öffnen des Links.",
                        string.Format("XHyperlinkID: '{0}', Hyperlink: '{1}'", XHyperlinkId, URL),
                        ex);
                }
            }

            base.OnClick(link);
        }

        #endregion

        #region Private Methods

        private void UpdateProperties()
        {
            if (XHyperlinkId != 0)
            {
                qryXHyperlink.Fill(XHyperlinkId);

                Caption = (string)qryXHyperlink[DBO.XHyperlink.Name];
                URL = (string)qryXHyperlink[DBO.XHyperlink.Hyperlink];
            }
            else if (!string.IsNullOrEmpty(ConfigKey))
            {
                URL = DBUtil.GetConfigString(ConfigKey, URL);
            }
            else
            {
                Caption = string.Empty;
                URL = string.Empty;
            }
        }

        #endregion

        #endregion
    }
}