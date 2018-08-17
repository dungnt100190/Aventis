using Kiss.DbContext.Enums.Vm;

namespace Kiss.DbContext
{
    partial class VmKlientenbudget
    {
        public VmKlientenbudgetStatus VmKlientenbudgetStatus
        {
            get { return (VmKlientenbudgetStatus)VmKlientenbudgetStatusCode; }
            set { VmKlientenbudgetStatusCode = (int)value; }
        }
    }
}
