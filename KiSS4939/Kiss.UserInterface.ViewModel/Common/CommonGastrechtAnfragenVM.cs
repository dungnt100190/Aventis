using System;
using System.Threading.Tasks;

using Kiss.BusinessLogic.Common;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.LocalResources.Common;

namespace Kiss.UserInterface.ViewModel.Common
{
    public class CommonGastrechtAnfragenVM : ViewModelCRUD<XTask, int>
    {
        private string _befristetAufConfigWertMonate;
        private string _bemerkungen;
        private bool _buttonAnfragenIsEnabled;
        private int _faLeistungID;
        private BaseCommand _gastrechtAnfragenCommand;
        private string _infoMeldung;
        private bool _isUnbefristet;
        private string _moechtenSieGastRechtAnfragen;
        private bool _radioButtonFristIsEnabled;
        private string _titleName;

        public CommonGastrechtAnfragenVM()
            : base(Container.Resolve<CommonGastrechtAnfragenService>())
        {
            RequiredParameters = InitParameterValue.FaLeistungID;
        }

        public string BefristetAufConfigWertMonate
        {
            get { return _befristetAufConfigWertMonate; }
            private set
            {
                SetProperty(ref _befristetAufConfigWertMonate, value, () => BefristetAufConfigWertMonate);
            }
        }

        public string Bemerkungen
        {
            get { return _bemerkungen; }
            set
            {
                SetProperty(ref _bemerkungen, value, () => Bemerkungen);
            }
        }

        public bool ButtonAnfragenIsEnabled
        {
            get { return _buttonAnfragenIsEnabled; }
            private set
            {
                SetProperty(ref _buttonAnfragenIsEnabled, value, () => ButtonAnfragenIsEnabled);
            }
        }

        public BaseCommand GastrechtAnfragenCommand
        {
            get { return _gastrechtAnfragenCommand ?? (_gastrechtAnfragenCommand = new BaseCommand(x => AnfragenCommand(), o => ButtonAnfragenIsEnabled)); }
        }

        public string InfoMeldung
        {
            get { return _infoMeldung; }
            private set
            {
                SetProperty(ref _infoMeldung, value, () => InfoMeldung);
            }
        }

        public bool IsUnbefristet
        {
            get { return _isUnbefristet; }
            set
            {
                SetProperty(ref _isUnbefristet, value, () => IsUnbefristet);
            }
        }

        public string MoechtenSieGastRechtAnfragen
        {
            get { return _moechtenSieGastRechtAnfragen; }
            private set
            {
                SetProperty(ref _moechtenSieGastRechtAnfragen, value, () => MoechtenSieGastRechtAnfragen);
            }
        }

        public bool RadioButtonFristIsEnabled
        {
            get { return _radioButtonFristIsEnabled; }
            private set
            {
                SetProperty(ref _radioButtonFristIsEnabled, value, () => RadioButtonFristIsEnabled);
            }
        }

        public string TitleName
        {
            get { return _titleName; }
            private set
            {
                SetProperty(ref _titleName, value, () => TitleName);
            }
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungID = (int)(initParameters.Value.FaLeistungID.HasValue ? initParameters.Value.FaLeistungID : int.MinValue);

            var xUserService = Container.Resolve<XUserService>();

            TitleName = initParameters.Value.Title; //Title kann leer sein

            XUser xUser = xUserService.SearchUser(_faLeistungID);
            MoechtenSieGastRechtAnfragen = string.Format(
                CommonGastrechtAnfragenVMRes.MochtenSieGastrechtAnfragen,
                xUser.LastName,
                xUser.FirstName,
                xUser.LogonName);

            var configService = Container.Resolve<XConfigService>();
            int gastrechtAnzahlMonate = configService.GetConfigValue(ConfigNodes.System_Allgemein_GastrechtAnzahlMonate);
            BefristetAufConfigWertMonate = string.Format(CommonGastrechtAnfragenVMRes.BefristetAufConfigWertMonate, Convert.ToString(gastrechtAnzahlMonate));

            var xTaskService = Container.Resolve<XTaskService>();
            var sessionService = Container.Resolve<ISessionService>();
            var letzteAnfrage = xTaskService.GetLetztePendenteGastrechtAnfrage(_faLeistungID, sessionService.AuthenticatedUser.UserID,
                xUser.UserID);

            if (letzteAnfrage != null)
            {
                SendenSetToDisabled();
                InfoMeldung = string.Format(CommonGastrechtAnfragenVMRes.GastrechtAnfragenPendent,
                    letzteAnfrage.ExpirationDate.Value.ToShortDateString());
            }
            else
            {
                SendenSetToEnabled();
            }
        }

        private IServiceResult AnfragenCommand()
        {
            var sessionService = Container.Resolve<ISessionService>();
            var taskAutoGeneratedService = Container.Resolve<XTaskAutoGeneratedService>();
            var result = taskAutoGeneratedService.GastrechtAnfragenErstellenPendenz(_isUnbefristet, _faLeistungID, sessionService.AuthenticatedUser.UserID, _bemerkungen);

            if (result.IsOk)
            {
                InfoMeldung = CommonGastrechtAnfragenVMRes.GastrechtAnfrageMitErfolgGesendet;
                SendenSetToDisabled();
            }

            return result;
        }

        private void SendenSetToDisabled()
        {
            ButtonAnfragenIsEnabled = false;
            RadioButtonFristIsEnabled = false;
        }

        private void SendenSetToEnabled()
        {
            ButtonAnfragenIsEnabled = true;
            RadioButtonFristIsEnabled = true;
        }
    }
}