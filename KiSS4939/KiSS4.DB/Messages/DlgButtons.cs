using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Messages
{
    /// <summary>
    /// Summary description for DlgButtonPositionModes.
    /// </summary>
    public enum DlgButtonPositionModes
    {
        /// <summary>
        /// von links nach rechts und oben nach unten.
        /// </summary>
        dpmAutomatic,

        /// <summary>
        /// von links nach rechts.
        /// </summary>
        dpmHorizontal,

        /// <summary>
        /// von oben nach unten.
        /// </summary>
        dpmVertical
    }

    public partial class DlgButtons : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DlgButtons"/> class.
        /// </summary>
        private DlgButtons()
        {
            InitializeComponent();
            BackColor = DBUtil.DefaultMessageDialogBackColor;
            txtQuestion.BackColor = DBUtil.DefaultMessageDialogBackColor;
        }

        public static IMessagePresenter MessagePresenter
        {
            get;
            set;
        }

        /// <summary>
        /// Displays a question-dialog to the user and returns the id of the button that was clicked (null if no button was clicked). The dialog is centered to the screen.
        /// </summary>
        /// <param name="message">the question text</param>
        /// <param name="buttonTextList">A list of  button texts. This is the text, which will be shown on the buttons. An &amp; will underline the following character.</param>
        /// <param name="focusedButtonIndex">Index in ButtonTextList of the button to be focused. (-1 not focussing will occur).</param>
        public static int ShowButtonDlg(string message, string[] buttonTextList, int focusedButtonIndex)
        {
            // show dialog without using any help feature
            return ShowButtonDlg(message, buttonTextList, DlgButtonPositionModes.dpmAutomatic, focusedButtonIndex, -1, -1);
        }

        /// <summary>
        /// Displays a question-dialog to the user and returns the id of the button that was clicked (null if no button was clicked)
        /// </summary>
        /// <param name="message">the question text</param>
        /// <param name="buttonTextList">A list of  button texts. This is the text, which will be shown on the buttons. An &amp; will underline the following character.</param>
        /// <param name="positionMode">The position where the dialog has to be centered to</param>
        /// <param name="focusedButtonIndex">Index in ButtonTextList of the button to be focused. (-1 not focussing will occur).</param>
        public static int ShowButtonDlg(string message, string[] buttonTextList, DlgButtonPositionModes positionMode, int focusedButtonIndex)
        {
            // show dialog without using any help feature
            return ShowButtonDlg(message, buttonTextList, positionMode, focusedButtonIndex, -1, -1);
        }

        /// <summary>
        /// Displays a question-dialog to the user and returns the id of the button that was clicked (-1 if no button was clicked)
        /// </summary>
        /// <param name="message">the question text</param>
        /// <param name="buttonTextList">A list of  button texts. This is the text, which will be shown on the buttons. An &amp; will underline the following character.</param>
        /// <param name="positionMode">The position where the dialog has to be centered to</param>
        /// <param name="focusedButtonIndex">Index in ButtonTextList of the button to be focused. (-1 not focussing will occur).</param>
        /// <param name="helpButtonIndex">Index in ButtonTextList of the button to show the online help.</param>
        /// <param name="helpIndex">Helpindex to be called.</param>
        public static int ShowButtonDlg(string message,
            string[] buttonTextList,
            DlgButtonPositionModes positionMode,
            int focusedButtonIndex,
            int helpButtonIndex,
            int helpIndex)
        {
            // In KiSS 5 kein Dialog öffnen.
            // Falls die Meldung von einem Dialog kommt kann im KiSS5 kein ValidationSummary angezeigt werden und
            // muss wie im KiSS4 mit dem DlgInfo angezeigt werden.
            // KissForm implementiert IKissDataNavigator (gelegentlich gibt es eine OpenForm für DevExpress-Tooltips..)
            if (MessagePresenter != null && !Application.OpenForms.OfType<Form>().OfType<IKissDataNavigator>().Any())
            {
                return MessagePresenter.ShowButtonDialog(message, buttonTextList, focusedButtonIndex);
            }

            // create new dialog
            DlgButtons dlg = new DlgButtons();

            // set flag for default return value
            dlg.Tag = -1;

            // init other fields
            dlg.txtQuestion.Text = message;
            dlg.btnDefaultButton = null;

            // setup size depending on message to display
            Size aTextSize = TextRenderer.MeasureText(message, dlg.txtQuestion.Font);

            dlg.txtQuestion.Width = aTextSize.Width + 10;
            dlg.txtQuestion.Height = aTextSize.Height + 10;

            // Grösste Text-Weite des Dialogtextes bestimmen:
            int maxWidthLabels = aTextSize.Width;

            // Grösste Text-Weite der Buttons bestimmen:
            int maxWidthButton = 0;

            for (int i = 0; i < buttonTextList.Length; i++)
            {
                Size aTextSizeBtn = TextRenderer.MeasureText(buttonTextList[i], dlg.Font);

                if (maxWidthButton < aTextSizeBtn.Width)
                {
                    maxWidthButton = aTextSizeBtn.Width;
                }
            }

            if (maxWidthButton < 70)
            {
                maxWidthButton = 80;
            }
            else
            {
                maxWidthButton += 16;
            }

            // Anzahl der Spalte für Buttons berechnen:
            int buttonColumnsCount = maxWidthLabels / (maxWidthButton + 16);

            if (buttonColumnsCount == 0)
            {
                buttonColumnsCount = 1;
            }

            // Oberste Position der Buttons aus Texthöhe setzen:
            int topPos = dlg.txtQuestion.Top + aTextSize.Height + 30;

            // Buttons erstellen und positionieren:
            int buttonColumnIndex = 1;

            for (int i = 0; i < buttonTextList.Length; i++)
            {
                Button tmpBtn = new Button();

                tmpBtn.Name = "Btn" + i.ToString();
                tmpBtn.Tag = i;
                tmpBtn.TabIndex = i;
                tmpBtn.Width = maxWidthButton;
                tmpBtn.Height = 23;
                tmpBtn.BackColor = Color.LemonChiffon;
                tmpBtn.FlatStyle = FlatStyle.Flat;
                tmpBtn.UseMnemonic = true;
                tmpBtn.Text = buttonTextList[i];
                tmpBtn.Left = dlg.txtQuestion.Left + ((buttonColumnIndex - 1) * (maxWidthButton + 16));
                tmpBtn.Top = topPos;

                // spezielle Eigenschaften, fokussieren wenn DefaultButton::
                if (i == focusedButtonIndex)
                {
                    dlg.btnDefaultButton = tmpBtn;
                }

                if (i == helpButtonIndex)
                {
                    tmpBtn.Click += dlg.HelpButton_Click;
                }
                else
                {
                    tmpBtn.Click += dlg.AllButtons_Click;
                }

                // Button der Form hinzufügen,
                dlg.Controls.Add(tmpBtn);

                if (positionMode.Equals(DlgButtonPositionModes.dpmAutomatic))
                {
                    // Automatisch anordnen:
                    // Kontrollieren, ob eine neue Spalte begonnen werden muss:
                    buttonColumnIndex += 1;

                    if ((buttonColumnIndex > buttonColumnsCount) && (i < buttonTextList.Length - 1))
                    {
                        buttonColumnIndex = 1;
                        topPos += 30;
                    }
                }
                else if (positionMode.Equals(DlgButtonPositionModes.dpmHorizontal))
                {
                    // nur Horizontal anordnen:
                    buttonColumnIndex += 1;
                }
                else
                {
                    // nur Vertical anordnen:
                    topPos += 30;
                }
            }

            // Maximale Breite für die Schalter ermittlen:
            int maxWidthAllButtons;

            if (positionMode.Equals(DlgButtonPositionModes.dpmAutomatic))
            {
                maxWidthAllButtons = maxWidthButton + dlg.txtQuestion.Left + (buttonColumnsCount * 16);
            }
            else if (positionMode.Equals(DlgButtonPositionModes.dpmHorizontal))
            {
                maxWidthAllButtons = dlg.txtQuestion.Left + (buttonTextList.Length * maxWidthButton) + ((buttonTextList.Length - 1) * 16);
            }
            else
            {
                maxWidthAllButtons = dlg.txtQuestion.Left + maxWidthButton;
            }

            // Fenstergrösse anpassen. Rechter Rand berücksichtigen
            dlg.Height = topPos + 90;
            maxWidthAllButtons += 32;
            maxWidthLabels += dlg.txtQuestion.Left + 24;

            if (dlg.Width < maxWidthLabels)
            {
                dlg.Width = maxWidthLabels;
            }

            if (dlg.Width < maxWidthAllButtons)
            {
                dlg.Width = maxWidthAllButtons;
            }

            // show dialog
            dlg.ShowDialog(KissMsg.GetMainWindow());

            // return id of pressed button
            return Convert.ToInt32(dlg.Tag);
        }

        /// <summary>
        /// Handles the Click event of the AllButtons control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AllButtons_Click(object sender, EventArgs e)
        {
            // Als Resultat wird der Index der Buttonliste zurückgegeben
            Tag = ((Button)sender).Tag;
            Close();
        }

        /// <summary>
        /// Handles the KeyPress event of the DlgButtons control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void DlgButtons_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Mit Escape soll man immer rauskommen:
            if (e.KeyChar.Equals((char)Keys.Escape))
            {
                Close();
            }
        }

        /// <summary>
        /// Handles the Load event of the DlgButtons control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DlgButtons_Load(object sender, EventArgs e)
        {
            // show dialog and main form
            KissMsg.BringKiSSAndDialogToFront(this);

            // focus default button if any
            if (btnDefaultButton != null)
            {
                btnDefaultButton.Select();
            }
        }

        /// <summary>
        /// Handles the Click event of the HelpButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            // TODO:
            // Hier kann Hilfe aufgerufen werden:
        }
    }
}