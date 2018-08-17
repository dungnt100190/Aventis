using Kiss.Infrastructure;
using Kiss.Infrastructure.Enumeration;

namespace Kiss.Model.DTO.Wsh
{
    public class WshBudgetmonatDTO : DTO
    {
        #region Properties

        public MonthYear MonatJahr
        {
            get; set;
        }

        public WshBudgetmonatStatus Status
        {
            get; set;
        }

        #endregion
    }
}