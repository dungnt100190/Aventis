using System;
using System.Text;

namespace Kiss.Model.DTO.BA
{
    #region Enumerations

    public enum KreditorType
    {
        Person = 1,
        Institution = 2
    }

    #endregion

    /// <summary>
    /// DTO Objekt für einen Kreditor.
    /// </summary>
    public class BaZahlungswegDTO
    {
        #region Properties

        public string Adresse
        {
            get {

                StringBuilder sb = new StringBuilder();

                bool first = false;
                if(!string.IsNullOrEmpty(Strasse))
                {
                    sb.Append(Strasse);
                    first = true;
                }

                if(!string.IsNullOrEmpty(HausNr))
                {
                    if(first)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(HausNr);
                    first = true;
                }

                if (!string.IsNullOrEmpty(PLZ))
                {
                    if (first)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(PLZ);
                    first = true;
                }

                if (!string.IsNullOrEmpty(Ort))
                {
                    if (first)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(Ort);
                }
              

                return sb.ToString();
            }
        }

        public string StrasseUndHausnummer
        {
            get
            {

                StringBuilder sb = new StringBuilder();

                bool first = false;
                if (!string.IsNullOrEmpty(Strasse))
                {
                    sb.Append(Strasse);
                    first = true;
                }

                if (!string.IsNullOrEmpty(HausNr))
                {
                    if (first)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(HausNr);
                }

           
                return sb.ToString();
            }
        }


        public string RefNR
        {
            get; 
            set;
        }

        public int? BaInstitutionId
        {
            get;
            set;
        }

        public int? BaPersonId
        {
            get;
            set;
        }

        public int BaZahlungswegID
        {
            get;
            set;
        }

        public string BankKontoNummer
        {
            get; set;
        }

        public string BankName
        {
            get; set;
        }

        public string BankPCKontoNr
        {
            get; set;
        }

        public int? BgEinzahlungsscheinCode
        {
            get; set;
        }

        public string BgEinzahlungsscheinCodeShortText
        {
            get; set;
        }

        public DateTime? DatumBis
        {
            get;
            set;
        }

        public DateTime DatumVon
        {
            get;
            set;
        }

        public string HausNr
        {
            get; set;
        }

        public string IBANNummer
        {
            get;
            set;
        }

        public string Nachname
        {
            get; set;
        }

        public string Name
        {
            get
            {
                //BaPerson
                if(Type == KreditorType.Person)
                {
                    string vn = Vorname ?? "";
                    string nn = Nachname ?? "";
                    return nn + ", " + vn;
                }

                //BaInstitution
                return NameInstitution;
            }
        }

        public string NameInstitution
        {
            get; set;
        }

        public string Ort
        {
            get;
            set;
        }

        public string PLZ
        {
            get;
            set;
        }

        public string PLZundOrt
        {
            get {
                string plz = PLZ ?? "";
                string ort = Ort ?? "";
                return plz + " " + ort;
            }
        }

        public string PostKontoNummer
        {
            get;
            set;
        }

        public string Strasse
        {
            get; set;
        }

        public KreditorType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> property as integer.
        /// http://social.msdn.microsoft.com/Forums/en/adonetefx/thread/9a5d5a64-4de8-4685-8896-c5e8f66fda65
        /// </summary>
        public int TypeInt
        {
            get { return (int)Type; }
            set { Type = (KreditorType)value; }
        }

        public string Vorname
        {
            get; set;
        }

        /// <summary>
        ///        Zahlungsweg      = EIZ.ShortText +
        ///                           ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),'') +
        ///                           ISNULL(', ' + BNK.Name, '') +
        ///                           ISNULL(', ' + ZAH.BankKontoNummer, '') +
        ///                           ISNULL(', ' + ZAH.IBANNummer,''),
        /// </summary>
        public string Zahlungsweg
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                //ShortText vom Code
                sb.Append(BgEinzahlungsscheinCodeShortText);

                //PostkontoNummer vom Klient
                if (!string.IsNullOrEmpty(PostKontoNummer))
                {
                    sb.Append(", ");
                    sb.Append(PostKontoNummer);
                }

                //Kontonummer von der Bank
                if (!string.IsNullOrEmpty(BankPCKontoNr))
                {
                    sb.Append(", ");
                    sb.Append(BankPCKontoNr);
                }

                //Name der Bank
                if(!string.IsNullOrEmpty(BankName))
                {
                    sb.Append(", ");
                    sb.Append(BankName);
                }

                //BankKontonummer vom Klient
                if (!string.IsNullOrEmpty(BankKontoNummer))
                {
                    sb.Append(", ");
                    sb.Append(BankKontoNummer);
                }

                //IBAN Nummer
                if (!string.IsNullOrEmpty(IBANNummer))
                {
                    sb.Append(", ");
                    sb.Append(IBANNummer);
                }

                return sb.ToString();
            }
        }

        #endregion
    }
}