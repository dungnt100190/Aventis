using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Properties;

namespace Kiss.UserInterface.ViewModel.Ba
{
    /// <summary>
    /// The ViewModel of the BaPLZ entity.
    /// </summary>
    public class BaPlzVM : ViewModelSearchListCRUD<BaPLZ, BaPLZ, object, int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaPlzVM"/> class.
        /// </summary>
        public BaPlzVM()
            : base(Container.Resolve<BaPlzService>())
        {
            ImportPlzCommand = new DelegateCommand(par => ImportPlz());
            RefreshAfterSave = true;
        }

        public DelegateCommand ImportPlzCommand { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        protected override async System.Threading.Tasks.Task InitAsync(InitParameters? initParameters = null)
        {
            SearchParametersVisible = true;
            SearchTask.StartCommand.Execute();
        }

        protected override IServiceResult<IEnumerable<BaPLZ>> SearchInBackground(object searchParameters, System.Threading.CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<BaPLZ>>(BaPlzService.GetAllEntities());
        }

        //private void btnUpdateBaPlz_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.UpdateBaPlz(null);
        //    if (!ViewModel.ValidationResult.IsOk)
        //    {
        //        // Download fehlgeschlagen, User muss Datei vom Filesystem auswählen
        //        // Message ausgeben
        //        ViewModel.RaiseMessage("Bei der automatischen Aktualisierung der Postleitzahlen ist ein Fehler aufgetreten. Bitte laden Sie die Aktualisierung manuell herunter und wählen Sie die ZIP-Datei im nächsten Dialog aus.", ViewModel.ValidationResult);

        //        using (var fileDialog = new OpenFileDialog())
        //        {
        //            fileDialog.Filter = @"Zip|*.zip";
        //            if (fileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                Stream stream = new FileStream(fileDialog.FileName, FileMode.Open);
        //                Zip zip = new Zip(stream);
        //                try
        //                {
        //                    StreamReader contentReader = new StreamReader(zip.GetStreamEndsWith(".txt"), Encoding.GetEncoding(1252)  /*ANSI-Encoding*/);
        //                    string content = contentReader.ReadToEnd();
        //                    contentReader.Close();
        //                    ViewModel.UpdateBaPlz(null, content);
        //                }
        //                catch (Exception)
        //                {
        //                    throw new Exception("Dies ist nicht die erwartete PLZ-Datei. Bitte versuchen Sie es nochmals mit der richtigen PLZ-Datei.");
        //                }
        //                finally
        //                {
        //                    stream.Close();
        //                }

        //            }
        //        }
        //    }
        //}
        private async void ImportPlz()
        {
            ValidationResult = await RunAsCompletelyBusy(BaPlzService.UpdateBaPlz);

            if (!ValidationResult.IsOk())
            {
                // Download fehlgeschlagen, User muss Datei vom Filesystem auswählen
                // Message ausgeben
                RaiseMessage(Resources.BaGemeindePlzAktualisierenError, ValidationResult);
                using (var filestream = GetFileSelectedByUser())
                {
                    if (filestream == null)
                    {
                        return;
                    }
                    ValidationResult = await RunAsCompletelyBusy(() => BaPlzService.UpdateBaPlz(filestream));
                }
            }
            if (ValidationResult.IsOk())
            {
                RefreshData();
            }
        }

        #endregion

        #region Private Methods

        protected override DbContext.DTO.KissSystem.MaskenRechtDTO OverrideMaskenrecht(DbContext.DTO.KissSystem.MaskenRechtDTO maskenRecht)
        {
            maskenRecht.CanInsert = false;
            maskenRecht.CanDelete = false;
            return maskenRecht;
        }

        private StreamReader GetFileSelectedByUser()
        {
            var openFileService = Container.Resolve<IOpenFileService>();
            var fileName = openFileService.OpenFileDialog(@"Zip|*.zip");
            if (fileName != null)
            {
                var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var zip = new Zip(stream);
                try
                {
                    return new StreamReader(zip.GetStreamEndsWith(".csv"), Encoding.GetEncoding(1252) /*ANSI-Encoding*/);
                }
                catch (Exception)
                {
                    ValidationResult = new ServiceResult(ServiceResultType.Error, Resources.BaPlzWrongPLZFileError);
                }
            }
            return null;
        }

        #endregion

        private BaPlzService BaPlzService
        {
            get { return (BaPlzService)ServiceCRUD; }
        }

        #endregion
    }
}