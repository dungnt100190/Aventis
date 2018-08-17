using System;
using DevExpress.XtraPrinting;

namespace KiSS4.Gui
{
    /*
    /// <summary>
    /// Definiert eine Methode um den EditMode zu setzen.
    /// </summary>
    public interface IKissEditable
    {
        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        EditModeType EditMode { get; set;}
    }
    
    /// <summary>
    /// Edit Mode Type
    /// </summary>
    public enum EditModeType
    {
        /// <summary>
        /// Normal Edit Field
        /// </summary>
        Normal,

        /// <summary>
        /// Read Only Field
        /// </summary>
        ReadOnly,

        /// <summary>
        /// BFS voluntary Field
        /// </summary>
        BfsCan,

        /// <summary>
        /// BFS mandantory Field
        /// </summary>
        BfsMust,

        /// <summary>
        /// Required Field
        /// </summary>
        Required
    }
    */

    /// <summary>
    /// Label Style Type
    /// </summary>
    public enum LabelStyleType
    {
        /// <summary>
        /// Custom
        /// </summary>
        Custom,

        /// <summary>
        /// Label in front of an Edit Field
        /// </summary>
        EditFieldLabel,

        /// <summary>
        /// Label to show readonly date from database
        /// </summary>
        DataView,

        /// <summary>
        /// Label in front of an DataView Label
        /// </summary>
        DataViewLabel,

        /// <summary>
        /// Label to use as title of a KissUserControl
        /// </summary>
        TitleLabel
    }

    /// <summary>
    /// Button Style Type
    /// </summary>
    public enum ButtonStyleType
    {
        /// <summary>
        /// Custom
        /// </summary>
        Custom,

        /// <summary>
        /// Standard: fixed Height, Font, Fore/Backgroundcolor
        /// </summary>
        Standard
    }

    /// <summary>
    /// TabControl Style Type
    /// </summary>
    public enum TabControlStyleType
    {
        /// <summary>
        /// Custom
        /// </summary>
        Custom,

        /// <summary>
        /// Buttons as used in FrmFallBearbeitung
        /// </summary>
        Buttons,

        /// <summary>
        /// Tabs as used in modul trees
        /// </summary>
        ModulTree,

        /// <summary>
        /// Standard: fixed TabFont, automatic ActiveSqlQuery.Post() on SelectedIndexChanging
        /// </summary>
        Standard
    }

    /// <summary>
    /// Grid Style
    /// </summary>
    public enum GridStyleType
    {
        /// <summary>
        /// Default DevExpress Style
        /// </summary>
        Default,

        /// <summary>
        /// Kiss Read Only Style
        /// </summary>
        ReadOnly,

        /// <summary>
        /// Kiss Editable Style
        /// </summary>
        Editable
    }

    /// <summary>
    /// Xtra Print event arguments.
    /// </summary>
    public class XtraPrintEventArgs : EventArgs
    {
        PrintableComponentLink printableComponentLink;

        /// <summary>
        /// Initializes a new instance of the <see cref="XtraPrintEventArgs"/> class.
        /// </summary>
        /// <param name="PLink">The printable component.</param>
        public XtraPrintEventArgs(PrintableComponentLink PLink)
        {
            this.printableComponentLink = PLink;
        }

        /// <summary>
        /// Gets the link of the printable component.
        /// </summary>
        /// <value>The printable link.</value>
        public PrintableComponentLink PLink
        {
            get { return printableComponentLink; }
        }
    }

    /// <summary>
    /// Handles Xtra prnt events.
    /// </summary>
    public delegate void XtraPrintEventHandler(object sender, XtraPrintEventArgs e);
}