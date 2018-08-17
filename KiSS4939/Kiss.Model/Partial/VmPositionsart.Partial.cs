using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;

namespace Kiss.Model
{
    public partial class VmPositionsart
    {

        public VmPositionsart()
        {
            // VmPositionsartTypEnum
            AddPropertyMapping(PropertyName.GetPropertyName(() => VmPositionsartTypCode),
                               PropertyName.GetPropertyName(() => VmPositionsartTypEnum));

            // VmKategorieEnum
            AddPropertyMapping(PropertyName.GetPropertyName(() => VmKategorieCode),
                               PropertyName.GetPropertyName(() => VmKategorieEnum));
        }

        /// <summary>
        /// Gets the VmPositionsartTypCode as Enum <see cref="LOVsGenerated.VmPositionsartTyp"/>
        /// </summary>
        public LOVsGenerated.VmPositionsartTyp VmPositionsartTypEnum
        {
            get { return (LOVsGenerated.VmPositionsartTyp)(VmPositionsartTypCode ?? 0); }
        }

        /// <summary>
        /// Gets the VmKategorieCode as Enum <see cref="LOVsGenerated.VmKategorie"/>
        /// </summary>
        public LOVsGenerated.VmKategorie VmKategorieEnum
        {
            get { return (LOVsGenerated.VmKategorie)VmKategorieCode; }
        }
    }
}
