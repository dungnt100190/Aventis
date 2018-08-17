using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    public class KesDossiernachweisSearchParamDTO : DateRangeSearchParamDTO
    {
        private string _gemeinde;
        private int? _gemeindeSozialdienstCode;

        [SearchField("Gemeinde")]
        public string Gemeinde
        {
            get { return _gemeinde; }
            set { SetProperty(ref _gemeinde, value, () => Gemeinde); }
        }

        public int? GemeindeSozialdienstCode
        {
            get { return _gemeindeSozialdienstCode; }
            set { SetProperty(ref _gemeindeSozialdienstCode, value, () => GemeindeSozialdienstCode); }
        }
    }
}