using System;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Enumeration;

namespace Kiss.Model
{
    public partial class WshPosition
    {
        public WshPosition()
        {
            //IstEinnahme
            AddPropertyMapping(PropertyName.GetPropertyName(() => WshKategorieID),
                                PropertyName.GetPropertyName(() => IstEinnahme));

            //BetragAusgabe
            AddPropertyMapping(PropertyName.GetPropertyName(() => IstEinnahme),
                                PropertyName.GetPropertyName(() => BetragAusgabe));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Betrag),
                                PropertyName.GetPropertyName(() => BetragAusgabe));

            //BetragEinnahme
            AddPropertyMapping(PropertyName.GetPropertyName(() => IstEinnahme),
                                PropertyName.GetPropertyName(() => BetragEinnahme));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Betrag),
                                PropertyName.GetPropertyName(() => BetragEinnahme));

            //Gruppierung
            AddPropertyMapping(PropertyName.GetPropertyName(() => IstEinnahme),
                                PropertyName.GetPropertyName(() => Gruppierung));

            //IsGrundbudgetPosition
            AddPropertyMapping(PropertyName.GetPropertyName(() => WshGrundbudgetPositionID),
                                PropertyName.GetPropertyName(() => IsGrundbudgetPosition));

            //IsGrundbudgetPositionText
            AddPropertyMapping(PropertyName.GetPropertyName(() => IsGrundbudgetPosition),
                                PropertyName.GetPropertyName(() => IsGrundbudgetPositionText));

            //BudgetMonatJahr
            AddPropertyMapping(PropertyName.GetPropertyName(() => MonatVon),
                                PropertyName.GetPropertyName(() => BudgetMonatJahr));           

            //PositionsStatus
            AddPropertyMapping(PropertyName.GetPropertyName(() => WshKategorieID),
                                PropertyName.GetPropertyName(() => PositionsStatus));
            AddPropertyMapping(PropertyName.GetPropertyName(() => VerwaltungSD),
                                PropertyName.GetPropertyName(() => PositionsStatus));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Betrag),
                                PropertyName.GetPropertyName(() => PositionsStatus));
        }

        #region Properties

        public bool IstEinnahme
        {
            get
            {
                if (WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme
                    || WshKategorieID == (int) LOVsGenerated.WshKategorie.Sanktion
                    || WshKategorieID == (int)LOVsGenerated.WshKategorie.Rueckerstattung
                    || WshKategorieID == (int)LOVsGenerated.WshKategorie.Verrechnung)
                {
                    return true;
                }
                
                return false;
            }
        }

        /// <summary>
        /// Gibt den Betrag zurück, wenn die Position eine Ausgabe ist.
        /// </summary>
        public decimal? BetragAusgabe
        {
            get { return !IstEinnahme ? (decimal?)Betrag : null; }
        }

        /// <summary>
        /// Gibt den Betrag zurück, wenn die Position eine Einnahme ist.
        /// </summary>
        public decimal? BetragEinnahme
        {
            get { return IstEinnahme ? (decimal?)Betrag : null; }
        }

        /// <summary>
        /// Zusätzliche Spalte für das Gruppieren.
        /// </summary>
        public string Gruppierung
        {
            get { return IstEinnahme ? "Einnahmen" : "Ausgaben"; }
        }

        /// <summary>
        /// Gibt an, ob die Position auf einer Grundbudgetposition basiert.
        /// </summary>
        public bool IsGrundbudgetPosition
        {
            get { return WshGrundbudgetPositionID.HasValue; }
        }

        public string IsGrundbudgetPositionText
        {
            get
            {
                if (IsGrundbudgetPosition)
                {
                    return "GB";
                }
                return "";
            }
        }

        public MonthYear BudgetMonatJahr
        {
            get { return new MonthYear(MonatVon.Year, MonatVon.Month); }
            set
            {
                DateTime m = new DateTime(value.Year, value.Month, 1);
                if(m == MonatVon)
                {
                    return;
                }
                MonatVon = m;
                OnPropertyChanged(PropertyName.GetPropertyName(() => BudgetMonatJahr));
            }
        }

        /// <summary>
        /// Summe der Beträge Netto der Belegpositionen mit Status Freigegeben (grün).
        /// </summary>
        public decimal SummeBelegPositionBetragFreigegeben { get; set; }

        /// <summary>
        /// Summe der Beträge Netto der Belegpositionen mit Status Verbucht (gelb).
        /// </summary>
        public decimal SummeBelegPositionBetragVerbucht { get; set; }

        public WshPositionsstatus PositionsStatus
        {
            get
            {
                WshPositionsstatus result = WshPositionsstatus.None;

                //Kommt Sprint 7.
                if (WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme &&
                   VerwaltungSD == true)
                {
                    return result;
                }


                //Der gesamte Betrag ist in Belegpositionen mit Status Freigegeben.
                if (SummeBelegPositionBetragFreigegeben >= Betrag)
                {
                    result |= WshPositionsstatus.Freigegeben;
                }

                //Nur ein Teil wurde freigegeben.
                if (SummeBelegPositionBetragFreigegeben < Betrag && SummeBelegPositionBetragFreigegeben > 0)
                {
                    result |= WshPositionsstatus.TeilweiseFreigegeben;
                }

                //Der gesamte Betrag wurde verbucht.
                if (SummeBelegPositionBetragVerbucht >= Betrag)
                {
                    result |= WshPositionsstatus.Ausgeglichen;
                }

                //Nur ein Teil wurde verbucht.
                if (SummeBelegPositionBetragVerbucht <= Betrag && SummeBelegPositionBetragVerbucht > 0)
                {
                    result |= WshPositionsstatus.TeilweiseAusgeglichen;
                }

                //Vorbereitet
                if (SummeBelegPositionBetragFreigegeben == 0 && SummeBelegPositionBetragVerbucht == 0)
                {
                    result = WshPositionsstatus.Vorbereitet;
                }

                //Es hat noch was übrig :)
                else if (Betrag - SummeBelegPositionBetragFreigegeben - SummeBelegPositionBetragVerbucht > 0)
                {
                    result |= WshPositionsstatus.TeilweiseVorbereitet;
                }

                return result;
            }
        }

        #endregion
    }
}
