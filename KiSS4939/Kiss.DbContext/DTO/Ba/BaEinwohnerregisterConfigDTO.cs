namespace Kiss.DbContext.DTO.Ba
{
    public class BaEinwohnerregisterConfigDTO
    {
        public string AdresseHistWebserviceUrl { get; set; }

        public string AnfrageWebserviceUrl { get; set; }

        public bool DeleteEventFiles { get; set; }

        public string DeRegistWebserviceUrl { get; set; }

        public string EinwohnerregisterWebservicesPassword { get; set; }

        public string EinwohnerregisterWebservicesProxy { get; set; }

        public string EinwohnerregisterWebservicesUsername { get; set; }

        public string FtpPassword { get; set; }

        public string FtpUrl { get; set; }

        public string FtpUser { get; set; }

        public string KissWebserviceProxy { get; set; }

        public string KissWebserviceUrl { get; set; }

        public string RegistWebserviceUrl { get; set; }

        public string SucheWebserviceUrl { get; set; }

        public bool ValidateCertificate { get; set; }
    }
}