using System.Collections.Specialized;
using System.Windows.Input;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS4.Common;
using KiSS4.Gui;

namespace Kiss.UI.Container.Fa
{
    /// <summary>
    /// Control für die Zeitachse.
    /// Achtung: beim Umbenennen CltFall.CLASS_NAME_ZEITACHSE auch anpassen!
    /// </summary>
    public partial class CtlFaZeitachse : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int? _currentBaPersonID;
        private string _frmText;
        private bool _showOldVersion;

        #endregion

        #endregion

        #region Constructors

        public CtlFaZeitachse()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            if (parameters.Contains("BaPersonID"))
            {
                var baPersonID = parameters["BaPersonID"] as int?;

                var showOldVersion = Keyboard.Modifiers.HasFlag(System.Windows.Input.ModifierKeys.Control);
                if (_currentBaPersonID != baPersonID ||
                    _showOldVersion != showOldVersion)
                {
                    IKissView view;
                    if (showOldVersion)
                    {
                        view = CtlWpfMask.CreateWpfView("Kiss.UI.View.Fa.FaZeitachseContainerView",
                                                           new InitParameters { BaPersonID = baPersonID });
                    }
                    else
                    {
                        var xclassIDZeitachse = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID("Kiss.UserInterface.View.Fa.Timeline.FaTimelineContainerView,Kiss.UserInterface.View");
                        view = new CtlWpfHost(xclassIDZeitachse.Value, new InitParameters { BaPersonID = baPersonID });
                    }
                    ActivateUserControl(view, this, true);

                    if (baPersonID != null)
                    {
                        var personText = PersonInfoTitel.GetPersonInfoTitelText(baPersonID.Value);
                        Text = string.Format("{0} - {1}", _frmText, personText);
                    }

                    _currentBaPersonID = baPersonID;
                    _showOldVersion = showOldVersion;
                }

                return true;
            }

            return false;
        }

        public override void Translate()
        {
            // save the title after translation
            base.Translate();
            if (string.IsNullOrEmpty(_frmText))
            {
                _frmText = Text;
            }
        }

        #endregion

        #endregion
    }
}