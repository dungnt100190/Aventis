using System.ComponentModel.DataAnnotations;

namespace Kiss4Web.Test.Model.Pendenzen
{
    public class NavbarItem
    {
        [Display(Name = "1_1")]
        public int ItmMeineFaellig { get; set; }

        [Display(Name = "1_2")]
        public int ItmMeineOffen { get; set; }

        [Display(Name = "1_3")]
        public int ItmMeineInBearbeitung { get; set; }

        [Display(Name = "1_4")]
        public int ItmMeineErstellt { get; set; }

        [Display(Name = "1_5")]
        public int ItmMeineErhalten { get; set; }

        [Display(Name = "1_6")]
        public int ItmMeineZuVisieren { get; set; }

        [Display(Name = "2_1")]
        public int ItmVersandteFaellig { get; set; }

        [Display(Name = "2_2")]
        public int ItmVersandteOffen { get; set; }

        [Display(Name = "2_3")]
        public int ItmVersandteAllgemein { get; set; }

        [Display(Name = "2_4")]
        public int ItmVersandteZuVisieren { get; set; }
    }
}
