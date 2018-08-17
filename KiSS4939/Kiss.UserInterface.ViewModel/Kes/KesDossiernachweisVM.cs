using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.LocalResources.Kes;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesDossiernachweisVM : ViewModelSearchList<KesDossiernachweisDTO, KesDossiernachweisSearchParamDTO>
    {
        private readonly KesDossiernachweisService _service;
        private IEnumerable<XLOVCode> _gemeindeSozialdienstList;

        /// <summary>
        /// Initializes a new instance of the <see cref="KesDossiernachweisVM"/> class.
        /// </summary>
        public KesDossiernachweisVM()
        {
            _service = Container.Resolve<KesDossiernachweisService>();
            Columns = new ObservableCollection<ColumnInfo>();
        }

        public ObservableCollection<ColumnInfo> Columns
        {
            get;
            private set;
        }

        public IEnumerable<XLOVCode> GemeindeSozialdienstList
        {
            get { return _gemeindeSozialdienstList; }
            set { SetProperty(ref _gemeindeSozialdienstList, value, () => GemeindeSozialdienstList); }
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            var xLovService = Container.Resolve<XLovService>();
            GemeindeSozialdienstList = xLovService.GetLovCodesByLovName("GemeindeSozialdienst", true);
            ResetSearchParameters(null);
        }

        protected override void ResetSearchParameters(object parameter)
        {
            base.ResetSearchParameters(parameter);
            SearchParameters = new KesDossiernachweisSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year, 12, 31),
            };
        }

        protected override IServiceResult<IEnumerable<KesDossiernachweisDTO>> SearchInBackground(KesDossiernachweisSearchParamDTO searchParameters, CancellationToken cancellationToken)
        {
            // Obwohl in InitAsync der Code auf null gesetzt wird, ist nach dem Laden der Maske der Wert 0..?
            if (searchParameters.GemeindeSozialdienstCode == 0)
            {
                searchParameters.GemeindeSozialdienstCode = null;
            }

            var result = _service.GetDossiernachweisList(searchParameters);
            if (result.IsOk)
            {
                Invoke(() => GenerateColumnInfos(result.Result));
            }
            return result;
        }

        private void GenerateColumnInfos(IEnumerable<KesDossiernachweisDTO> kesDossiernachweisDtoList)
        {
            Columns.Clear();

            if (kesDossiernachweisDtoList != null)
            {
                Columns.Add(new ColumnInfo
                {
                    Header = KesDossiernachweisVMRes.Kapitel,
                    FieldName = "Kapitel",
                    GroupIndex = 0,
                    VisibleIndex = 0
                });
                Columns.Add(new ColumnInfo
                {
                    Header = KesDossiernachweisVMRes.Text,
                    FieldName = "Text",
                    VisibleIndex = 1
                });

                var index = 2;

                // Spalten für jede Gemeinde im Resultat
                var gemeindeCodes = kesDossiernachweisDtoList.Select(x => x.DossiernachweisGemeindeDTOs.Select(y => y.Key));
                var gemeinden = GemeindeSozialdienstList.Where(x => gemeindeCodes.Any(y => y.Contains(x.Code))).OrderBy(x => x.SortKey);
                foreach (var dto in gemeinden)
                {
                    Columns.Add(new ColumnInfo
                    {
                        Header = dto.Text,
                        DisplayMemberBinding = new Binding(string.Format("RowData.Row.DossiernachweisGemeindeDTOs[{0}].Anzahl", dto.Code)),
                        VisibleIndex = index
                    });

                    index++;
                }

                Columns.Add(new ColumnInfo
                {
                    Header = KesDossiernachweisVMRes.Total,
                    FieldName = "Total",
                    VisibleIndex = index
                });
            }
        }
    }
}