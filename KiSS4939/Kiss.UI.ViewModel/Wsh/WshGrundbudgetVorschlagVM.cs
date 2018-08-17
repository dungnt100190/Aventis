using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Kiss.BL.Wsh;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Interfaces.ViewModel;
using Kiss.Model.DTO.Wsh;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshGrundbudgetVorschlagVM : ViewModelBase
    {
        #region Fields

        #region Public Static Fields

        public static RoutedCommand OkCommand = new RoutedCommand();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Fields

        private KissServiceResult _validationResult;
        private WshGrundbudgetVorschlagService _wshGrundbudgetVorschlagService;

        #endregion

        #endregion

        #region Properties

        public int FaLeistungID
        {
            get; private set;
        }

        /// <summary>
        /// Gets the validation result of the DTO
        /// </summary>
        public KissServiceResult ValidationResult
        {
            get { return _validationResult; }
            protected set
            {
                _validationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ValidationResult);
            }
        }

        public ObservableCollection<WshGrundbudgetVorschlagDTO> Vorschlag
        {
            get; set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool AllesSpeichern()
        {
            ValidationResult = Container.Resolve<WshGrundbudgetVorschlagDTOService>().SaveBerechnetePositionen(
                null, Vorschlag, FaLeistungID, _questionsAndAnswers);
            return ValidationResult.IsOk;
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int faLeistungID)
        {
            FaLeistungID = faLeistungID;

            _wshGrundbudgetVorschlagService = Container.Resolve<WshGrundbudgetVorschlagService>();
            GetVorschlag();
        }

        #endregion

        #region Private Methods

        private void GetVorschlag()
        {
            IList<WshGrundbudgetVorschlagDTO> vorschlaege = _wshGrundbudgetVorschlagService.GetGrundbudgetVorschlag(null, FaLeistungID);
            Vorschlag = new ObservableCollection<WshGrundbudgetVorschlagDTO>(vorschlaege);
        }

        #endregion

        #endregion
    }
}