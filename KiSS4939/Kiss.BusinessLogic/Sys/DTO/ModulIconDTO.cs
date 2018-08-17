using Kiss.DbContext.Enums.Sys;

namespace Kiss.BusinessLogic.Sys.DTO
{
    public class ModulIconDTO
    {
        public byte[] Icon { get; set; }

        public int IconId { get; set; }

        public bool IsDummyIcon { get; set; }

        public bool IsEmptyIcon { get { return Status == XIconStatus.Leer; } }

        public int ModulID { get; set; }

        public int OrderId { get; set; }

        public string ShortName { get; set; }

        public int? SortKey { get; set; }

        public XIconStatus Status { get; set; }
    }
}