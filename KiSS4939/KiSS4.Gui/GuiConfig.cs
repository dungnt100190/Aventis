using System;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// KiSS graphical user interface configurations
    /// </summary>
    /// <remarks>TODO: take this info from a configuration file or make it fully skinnable.</remarks>
    public class GuiConfig
    {
        #region Fields

        #region Public Static Fields

        #region Before PanelColor

        /// <summary>
        /// Color for matching amount difference (green=no difference)
        /// </summary>
        public static Color AmountDifferenceCorrect = Color.DarkSeaGreen;

        /// <summary>
        /// Color for non-matching amount difference (red=having difference)
        /// </summary>
        public static Color AmountDifferenceIncorrect = Color.Salmon;

        /// <summary>
        /// Bold label font style.
        /// </summary>
        public static float BLabelFontSize = 13F;

        /// <summary>
        /// Bold label font style.
        /// </summary>
        public static FontStyle BLabelFontStyle = FontStyle.Bold;

        /// <summary>
        /// Backcolor for button (disabled).
        /// </summary>
        public static Color ButtonBackColorDisabled = Color.Transparent;

        /// <summary>
        /// Backcolor for button (enabled).
        /// </summary>
        public static Color ButtonBackColorEnabled = Color.Bisque;

        /// <summary>
        /// Graphics unit for Button font.
        /// </summary>
        public static GraphicsUnit ButtonFontGraphicUnit = GraphicsUnit.Pixel;

        /// <summary>
        /// Button font.
        /// </summary>
        public static string ButtonFontName = "Arial";

        /// <summary>
        /// Font size for button text.
        /// </summary>
        public static float ButtonFontSize = 12F;

        /// <summary>
        /// Font style for button text.
        /// </summary>
        public static FontStyle ButtonFontStyle = FontStyle.Regular;

        /// <summary>
        /// Forecolor for button text (disabled).
        /// </summary>
        public static Color ButtonForeColorDisabled = Color.DarkGray;

        /// <summary>
        /// Forecolor for Button text (enabled).
        /// </summary>
        public static Color ButtonForeColorEnabled = Color.Black;

        /// <summary>
        /// Color for border of controls (dark brown)
        /// </summary>
        public static Color ControlBorder = Color.FromArgb(223, 159, 96);

        /// <summary>
        /// The border color.
        /// </summary>
        public static Color EditBorderColor = Color.Linen;

        /// <summary>
        /// The border style.
        /// </summary>
        public static BorderStyles EditBorderStyle = BorderStyles.HotFlat;

        /// <summary>
        /// The Button border style.
        /// </summary>
        public static BorderStyles EditButtonBorderStyle = BorderStyles.UltraFlat;

        /// <summary>
        /// The button color.
        /// </summary>
        public static Color EditButtonColor = Color.Bisque;

        /// <summary>
        /// TODO: add proper XML comment.
        /// </summary>
        public static Color EditColorBfsCan = Color.LightCyan;

        /// <summary>
        /// TODO: add proper XML comment.
        /// </summary>
        public static Color EditColorBfsMust = Color.MistyRose;

        /// <summary>
        /// Normal color.
        /// </summary>
        public static Color EditColorNormal = Color.AliceBlue;

        /// <summary>
        /// Optional color
        /// </summary>
        public static Color EditColorOptional = Color.FromArgb(220, 240, 255);

        /// <summary>
        /// Readonly color.
        /// </summary>
        public static Color EditColorReadOnly = Color.FromArgb(247, 239, 231); // hellbeige

        /// <summary>
        /// Required color.
        /// </summary>
        public static Color EditColorRequired = Color.FromArgb(253, 253, 200); // gelb

        /// <summary>
        /// The graphics unit.
        /// </summary>
        public static GraphicsUnit EditFontGraphicUnit = GraphicsUnit.Pixel;

        /// <summary>
        /// The edit font.
        /// </summary>
        public static string EditFontName = "Arial";

        /// <summary>
        /// The edit font size.
        /// </summary>
        public static float EditFontSize = 13F;

        /// <summary>
        /// The edit font style.
        /// </summary>
        public static FontStyle EditFontStyle = FontStyle.Bold;

        /// <summary>
        /// Color in grid if editable content
        /// </summary>
        public static Color GridEditable = Color.AliceBlue;

        /// <summary>
        /// Focused Selection color in GridView.
        /// </summary>
        public static Color GridFocusedSelectionBackColor = SystemColors.Highlight;

        /// <summary>
        /// Color in grid if readonly content
        /// </summary>
        public static Color GridReadOnly = Color.BlanchedAlmond;

        /// <summary>
        /// Back color for rows in GridView.
        /// </summary>
        public static Color GridRowEnabledBackColor = Color.BlanchedAlmond;

        /// <summary>
        /// Font color for rows in GridView.
        /// </summary>
        public static Color GridRowEnabledForeColor = Color.Black;

        /// <summary>
        /// Color of the gridrow if highlighted in red color (e.g. marking important or closed entry)
        /// </summary>
        public static Color GridRowHighlightedRed = Color.LightSalmon;

        /// <summary>
        /// Back color for logical deleted rows in GridView.
        /// </summary>
        public static Color GridRowLogischGeloeschtBackColor = Color.LightSalmon;

        /// <summary>
        /// Font color for logical deleted rows in GridView
        /// </summary>
        public static Color GridRowLogischGeloeschtForeColor = Color.Black;

        /// <summary>
        /// Color of the gridrow if readonly
        /// </summary>
        public static Color GridRowReadOnly = Color.Bisque;

        /// <summary>
        /// Unfocused Selection color in GridView.
        /// </summary>
        public static Color GridUnfocusedSelectionBackColor = Color.PowderBlue;

        /// <summary>
        /// Color of the background of the NavBar
        /// </summary>
        public static Color NavBarBackground = Color.DarkSlateBlue;

        /// <summary>
        /// Backcolor of the navbar group
        /// </summary>
        public static Color NavBarGroupBackColor = Color.AliceBlue;

        /// <summary>
        /// Backcolor of the navbar group header
        /// </summary>
        public static Color NavBarGroupHeaderBackColor = Color.AliceBlue;

        #endregion

        #region PanelColor

        /// <summary>
        /// Color of the panel.
        /// </summary>
        public static Color PanelColor = Color.FromArgb(247, 239, 231); // hellbeige;

        #endregion

        #region After PanelColor

        /// <summary>
        /// The backcolor to use for KiSS GroupBoxes
        /// </summary>
        public static Color GroupBoxBackColor = PanelColor;

        /// <summary>
        /// The 3D bordercolor to use for KiSS GroupBoxes
        /// </summary>
        public static Color GroupBoxBorder3DColor = Color.White;

        /// <summary>
        /// The bordercolor to use for KiSS GroupBoxes
        /// </summary>
        public static Color GroupBoxBorderColor = Color.FromArgb(207, 159, 112);

        /// <summary>
        /// The font to use for KiSS GroupBoxes
        /// </summary>
        /// <remarks>One pixel bigger than default label</remarks>
        public static Font GroupBoxFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// The text forecolor to use for KiSS GroupBoxes
        /// </summary>
        public static Color GroupBoxTextForeColor = Color.Black;

        /// <summary>
        /// Invalid color.
        /// </summary>
        public static Color InvalidColor = Color.Red;

        /// <summary>
        /// Label color.
        /// </summary>
        public static Color LabelColor = Color.Black;

        /// <summary>
        /// Graphics unit for label font.
        /// </summary>
        public static GraphicsUnit LabelFontGraphicUnit = GraphicsUnit.Pixel;

        /// <summary>
        /// Label font.
        /// </summary>
        public static string LabelFontName = "Arial";

        /// <summary>
        /// Label font size.
        /// </summary>
        public static float LabelFontSize = 11F;

        /// <summary>
        /// Label font style.
        /// </summary>
        public static FontStyle LabelFontStyle = FontStyle.Regular;

        /// <summary>
        /// Graphics unit for the KiSS memo font.
        /// </summary>
        public static GraphicsUnit MemoNonPropFontGraphicUnit = GraphicsUnit.Pixel;

        /// <summary>
        /// KiSS memo font.
        /// </summary>
        public static string MemoNonPropFontName = "Courier New";

        /// <summary>
        /// Size of the KiSS memo font.
        /// </summary>
        public static float MemoNonPropFontSize = 13F;

        /// <summary>
        /// Style of the KiSS memo font.
        /// </summary>
        public static FontStyle MemoNonPropFontStyle = FontStyle.Regular;

        /// <summary>
        /// Graphics unit for RTF font.
        /// </summary>
        public static GraphicsUnit RTFDefaultFontGraphicUnit = GraphicsUnit.Point;

        /// <summary>
        /// RTF font.
        /// </summary>
        public static string RTFDefaultFontName = "Arial";

        /// <summary>
        /// RTF font size.
        /// </summary>
        public static float RTFDefaultFontSize = 10F;

        /// <summary>
        /// RTF font sytle.
        /// </summary>
        public static FontStyle RTFDefaultFontStyle = FontStyle.Regular;

        /// <summary>
        /// Graphics unit for tab controls.
        /// </summary>
        public static GraphicsUnit TabFontGraphicUnit = GraphicsUnit.Pixel;

        /// <summary>
        /// Font for tab controls.
        /// </summary>
        public static string TabFontName = "Arial";

        /// <summary>
        /// Font size for tab controls.
        /// </summary>
        public static float TabFontSize = 12F;

        /// <summary>
        /// Font style for tab controls.
        /// </summary>
        public static FontStyle TabFontStyle = FontStyle.Regular;

        /// <summary>
        /// Title label font size.
        /// </summary>
        public static float TLabelFontSize = 14F;

        /// <summary>
        /// Title label font style.
        /// </summary>
        public static FontStyle TLabelFontStyle = FontStyle.Bold;

        #endregion

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        public static Color colBack00 = Color.Gray;

        public static Color colBack01 = System.Drawing.Color.AliceBlue;

        public static Color colBack02 = Color.FromArgb(230, 216, 174);

        //Color.FromArgb(236, 227, 215);
        public static Color colBack03 = Color.FromArgb(236, 227, 215);

        public static Color colBack04 = Color.BlanchedAlmond;

        public static Color colBack05 = Color.PeachPuff;

        public static Color colBack06 = Color.Tan;

        public static Color colBack07 = Color.Gray;

        public static Color colBack08 = Color.Gray;

        public static Color colBack09 = Color.Gray;

        public static Color colBack10 = Color.Gray;

        private static KissTheme _Theme = KissTheme.None;

        public enum KissTheme
        {
            None,
            KissBlue,
            KissGrey,
            KissBlack
        }

        public static KissTheme Theme
        {
            get
            {
                return _Theme;
            }
            set
            {
                SetKissTheme(value);
            }
        }

        /// <summary>
        /// Sets the edit mode.
        /// </summary>
        /// <param name="editControl">The edit control.</param>
        /// <param name="mode">The mode.</param>
        public static void SetEditMode(DevExpress.XtraEditors.BaseEdit editControl, EditModeType mode)
        {
            // HACK
            if (editControl.GetType().ToString() == "KiSS4.Dokument.XDokument")
            {
                editControl.Properties.ReadOnly = true; // Text (DateLasteSave) cann never be modified by user
            }
            else
            {
                editControl.Properties.ReadOnly = (mode == EditModeType.ReadOnly);
            }

            if (editControl is KissCheckEdit)
            {
                editControl.BackColor = PanelColor;

                switch (mode)
                {
                    case EditModeType.Normal:
                        ((KissCheckEdit)editControl).CenterSquareColor = EditColorNormal;
                        break;

                    case EditModeType.ReadOnly:
                        ((KissCheckEdit)editControl).CenterSquareColor = EditColorReadOnly;
                        break;

                    case EditModeType.Required:
                        ((KissCheckEdit)editControl).CenterSquareColor = EditColorRequired;
                        editControl.BackColor = EditColorRequired;
                        break;

                    case EditModeType.Optional:
                        ((KissCheckEdit)editControl).CenterSquareColor = EditColorOptional;
                        editControl.BackColor = EditColorOptional;
                        break;

                    case EditModeType.BfsCan:
                        ((KissCheckEdit)editControl).CenterSquareColor = EditColorBfsCan;
                        break;

                    case EditModeType.BfsMust:
                        ((KissCheckEdit)editControl).CenterSquareColor = EditColorBfsMust;
                        break;
                }

                editControl.Refresh();
            }
            else if (editControl is KissRadioGroup)
            {
                editControl.BorderStyle = BorderStyles.NoBorder;
                switch (mode)
                {
                    case EditModeType.Required:
                        editControl.BackColor = EditColorRequired;
                        break;

                    case EditModeType.Optional:
                        editControl.BackColor = EditColorOptional;
                        break;

                    default:
                        editControl.BackColor = PanelColor;
                        break;
                }
            }
            else
            {
                if (editControl is KissMemoEdit && !((KissMemoEdit)editControl).ProportionalFont)
                {
                    editControl.Properties.Style.Font = new Font(MemoNonPropFontName, MemoNonPropFontSize, MemoNonPropFontStyle, MemoNonPropFontGraphicUnit);
                }
                else
                {
                    editControl.Properties.Style.Font = new Font(EditFontName, EditFontSize, EditFontStyle, EditFontGraphicUnit);
                }

                editControl.Properties.BorderStyle = EditBorderStyle;
                editControl.Properties.StyleBorder.BackColor = EditBorderColor;

                switch (mode)
                {
                    case EditModeType.Normal:
                        editControl.Properties.Style.BackColor = EditColorNormal;
                        break;

                    case EditModeType.ReadOnly:
                        editControl.Properties.Style.BackColor = EditColorReadOnly;
                        break;

                    case EditModeType.Required:
                        editControl.Properties.Style.BackColor = EditColorRequired;
                        break;

                    case EditModeType.Optional:
                        editControl.Properties.Style.BackColor = EditColorOptional;
                        break;

                    case EditModeType.BfsCan:
                        editControl.Properties.Style.BackColor = EditColorBfsCan;
                        break;

                    case EditModeType.BfsMust:
                        editControl.Properties.Style.BackColor = EditColorBfsMust;
                        break;
                }

                // handle document control with background color (due to assembly-references, we need to use type as String, unfortunately!)
                if (mode == EditModeType.Normal && editControl.GetType().ToString() == "KiSS4.Dokument.XDokument")
                {
                    try
                    {
                        // refresh display in order to have proper color depending on state of document
                        AssemblyLoader.InvokeMethode(editControl, "RefreshDisplay");
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.Warn("Error refreshing display of XDockument control", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the edit mode.
        /// </summary>
        /// <param name="editControl">The edit control.</param>
        /// <param name="mode">The mode.</param>
        public static void SetEditMode(KissCheckedLookupEdit editControl, EditModeType mode)
        {
            switch (mode)
            {
                case EditModeType.Normal:
                    editControl.Appearance.BackColor = EditColorNormal;
                    editControl.Enabled = true;
                    break;

                case EditModeType.ReadOnly:
                    editControl.Appearance.BackColor = EditColorReadOnly;
                    editControl.Enabled = false;
                    break;

                case EditModeType.Required:
                    editControl.Appearance.BackColor = EditColorRequired;
                    editControl.Enabled = true;
                    break;

                case EditModeType.Optional:
                    editControl.Appearance.BackColor = EditColorOptional;
                    editControl.Enabled = true;
                    break;

                case EditModeType.BfsCan:
                    editControl.Appearance.BackColor = EditColorBfsCan;
                    editControl.Enabled = true;
                    break;

                case EditModeType.BfsMust:
                    editControl.Appearance.BackColor = EditColorBfsMust;
                    editControl.Enabled = true;
                    break;
            }
        }

        public static void SetKissTheme(KissTheme NewTheme)
        {
            switch (NewTheme)
            {
                case KissTheme.KissBlue:
                    colBack00 = Color.FromArgb(255, 255, 255);
                    colBack01 = Color.FromArgb(246, 248, 250);
                    colBack02 = Color.FromArgb(238, 242, 245);
                    colBack03 = Color.FromArgb(229, 235, 240);
                    colBack04 = Color.FromArgb(212, 222, 231);
                    colBack05 = Color.FromArgb(195, 208, 221);
                    colBack06 = Color.FromArgb(170, 188, 206);
                    colBack07 = Color.FromArgb(144, 168, 192);
                    colBack08 = Color.FromArgb(110, 141, 172);
                    colBack09 = Color.FromArgb(076, 114, 152);
                    colBack10 = Color.FromArgb(034, 081, 128);

                    GuiConfig.GridUnfocusedSelectionBackColor = colBack07;

                    break;

                case KissTheme.KissGrey:
                    colBack00 = Color.FromArgb(255, 255, 255);
                    colBack01 = Color.FromArgb(245, 245, 245);
                    colBack02 = Color.FromArgb(235, 235, 235);
                    colBack03 = Color.FromArgb(226, 226, 226);
                    colBack04 = Color.FromArgb(206, 206, 206);
                    colBack05 = Color.FromArgb(186, 186, 186);
                    colBack06 = Color.FromArgb(157, 157, 157);
                    colBack07 = Color.FromArgb(128, 128, 128);
                    colBack08 = Color.FromArgb(088, 088, 088);
                    colBack09 = Color.FromArgb(049, 049, 049);
                    colBack10 = Color.FromArgb(000, 000, 000);

                    break;
            }

            GuiConfig.PanelColor = colBack03;

            GuiConfig.ButtonBackColorEnabled = colBack06;
            GuiConfig.EditBorderColor = colBack02; // colBack05; too dark becuase of the shadow effect
            GuiConfig.EditColorNormal = colBack01;
            GuiConfig.EditButtonColor = colBack01;
            GuiConfig.ControlBorder = colBack05;
            GuiConfig.GridReadOnly = colBack03;
            GuiConfig.GridRowEnabledBackColor = colBack04;
            GuiConfig.GridRowReadOnly = colBack04;
            GuiConfig.GroupBoxBorderColor = colBack03;
            GuiConfig.GroupBoxBackColor = colBack03;
            GuiConfig.EditColorReadOnly = colBack03;

            _Theme = NewTheme;

            DBUtil.DefaultMessageDialogBackColor = colBack05;
        }

        #endregion

        #endregion
    }
}