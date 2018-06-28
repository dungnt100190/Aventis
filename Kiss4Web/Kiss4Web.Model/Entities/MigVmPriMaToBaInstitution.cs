using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class MigVmPriMaToBaInstitution
    {
        public int Id { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? VmPriMaId { get; set; }
        public DateTime Created { get; set; }
    }
}
