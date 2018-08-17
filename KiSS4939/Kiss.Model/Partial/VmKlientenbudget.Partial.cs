using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;

namespace Kiss.Model
{
    public partial class VmKlientenbudget
    {
        #region Constructors

        public VmKlientenbudget()
        {
            SubscribePropertyName(PropertyName.GetPropertyName(() => GueltigAb));
            SubscribePropertyName(PropertyName.GetPropertyName(() => VmKlientenbudgetStatusCode));
            SubscribePropertyName(PropertyName.GetPropertyName(() => VmKlientenbudgetTS));
        }

        #endregion

        /// <summary>
        /// Gets the VmPositionsartTypCode as Enum <see cref="LOVsGenerated.VmKlientenbudgetStatus"/>
        /// </summary>
        public LOVsGenerated.VmKlientenbudgetStatus VmKlientenbudgetStatusEnum
        {
            get { return (LOVsGenerated.VmKlientenbudgetStatus)(VmKlientenbudgetStatusCode); }
        }

    }
}