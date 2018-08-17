using System;
using System.Collections.Generic;
using System.IO;

using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.DbContext.DTO.KissSystem;
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
    /// The ViewModel of the BaGemeinde entity.
    /// </summary>
    public class BaGemeindeVM : ViewModelSearchListCRUD<BaGemeinde, BaGemeinde, object, int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaGemeindeVM"/> class.
        /// </summary>
        public BaGemeindeVM()
            : base(Container.Resolve<BaGemeindeService>())
        {
            ImportGemeindenCommand = new DelegateCommand(par => ImportGemeinden());
            RefreshAfterSave = true;
        }

        #endregion

        #region Properties

        public DelegateCommand ImportGemeindenCommand { get; private set; }

        private BaGemeindeService Service
        {
            get { return (BaGemeindeService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        protected override async System.Threading.Tasks.Task InitAsync(InitParameters? initParameters = null)
        {
            SearchTask.StartCommand.Execute();
        }

        protected override IServiceResult<IEnumerable<BaGemeinde>> SearchInBackground(object searchParameters, System.Threading.CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<BaGemeinde>>(Service.GetAllEntities());
        }

        ///// <summary>
        ///// Update der Gemeinden nach Auswahl der Datei von Filesystem
        ///// </summary>
        ///// <param name="contentStream">Inhalt der Txt Datei mit den Gemeinden</param>
        //public void UpdateBaGemeinde(Stream contentStream = null)
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        ValidationResult = Service.UpdateBaGemeinde(contentStream);
        //    }
        //    finally
        //    {
        //        if (ValidationResult.IsOk)
        //        {
        //            RefreshData();
        //        }
        //        IsBusy = false;
        //    }
        //}

        #endregion

        #region Private Methods

        protected override MaskenRechtDTO OverrideMaskenrecht(MaskenRechtDTO maskenRecht)
        {
            maskenRecht.CanDelete = false;
            maskenRecht.CanInsert = false;
            return maskenRecht;
        }

        private Stream GetFileSelectedByUser()
        {
            var openFileService = Container.Resolve<IOpenFileService>();
            var fileName = openFileService.OpenFileDialog(@"Zip|*.zip");
            if (fileName != null)
            {
                var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var zip = new Zip(stream);
                try
                {
                    return zip.GetStreamEndsWith(".xml");
                }
                catch (Exception)
                {
                    ValidationResult = new ServiceResult(ServiceResultType.Error, "Dies ist nicht die erwartete Gemeinden-Datei. Bitte versuchen Sie es nochmals mit der richtigen Gemeinden-Datei.");
                }
            }

            return null;
        }

        private async void ImportGemeinden()
        {
            ValidationResult = await RunAsCompletelyBusy(Service.UpdateBaGemeinde);

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

                    var fs = filestream;
                    ValidationResult = await RunAsCompletelyBusy(() => Service.UpdateBaGemeinde(fs));
                }
            }

            if (ValidationResult.IsOk())
            {
                RefreshData();
            }
        }

        #endregion

        #endregion
    }
}