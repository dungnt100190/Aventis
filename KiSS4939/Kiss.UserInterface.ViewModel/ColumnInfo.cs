using System.Windows.Data;

namespace Kiss.UserInterface.ViewModel
{
    public class ColumnInfo
    {
        public ColumnInfo()
        {
            GroupIndex = -1;
            FieldName = "";
        }

        public BindingBase DisplayMemberBinding { get; set; }

        public string FieldName { get; set; }

        public int GroupIndex { get; set; }

        public string Header { get; set; }

        public int VisibleIndex { get; set; }
    }
}