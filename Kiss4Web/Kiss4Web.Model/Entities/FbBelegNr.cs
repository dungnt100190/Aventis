using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class FbBelegNr : IEntity
    {
        public int FbBelegNrId { get; set; }
        public int BelegNrCode { get; set; }
        public int? UserId { get; set; }
        public int? BaPersonId { get; set; }
        public int NaechsteBelegNr { get; set; }
        public int BelegNrVon { get; set; }
        public int BelegNrBis { get; set; }
        public string Praefix { get; set; }
        public byte[] FbBelegNrTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public XUser User { get; set; }
        public int Id => FbBelegNrId;
        public byte[] RowVersion => FbBelegNrTs;
    }
}