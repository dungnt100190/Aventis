using Kiss.DbContext.Constant;
using Kiss.DbContext.Enums.Vm;

namespace Kiss.DbContext
{
    partial class VmPositionsart
    {
        public LOVsGenerated.VmPositionsartTyp VmPositionsartTypEnum
        {
            get { return (LOVsGenerated.VmPositionsartTyp)(VmPositionsartTypCode ?? 0); }
        }

        public VmKategorie VmKategorie
        {
            get { return (VmKategorie)VmKategorieCode; }
            set { VmKategorieCode = (int)value; }
        }

        public VmPositionsartTyp VmPositionsartTyp
        {
            get { return VmPositionsartTypCode.HasValue ? (VmPositionsartTyp)VmPositionsartTypCode : VmPositionsartTyp.Empty; }
            set { VmPositionsartTypCode = value == VmPositionsartTyp.Empty ? null : (int?)value; }
        }
    }
}
