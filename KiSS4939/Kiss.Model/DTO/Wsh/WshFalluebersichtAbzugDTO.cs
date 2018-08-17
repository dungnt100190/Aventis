using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure.Constant;

namespace Kiss.Model.DTO.Wsh
{
    public class WshFalluebersichtAbzugDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private DateTime? _abschlussDatum;
        private decimal _betragMonatlich;
        private string _betrifft;
        private ObjectChangeTracker _changeTracker;
        private DateTime? _datumBis;
        private DateTime _datumVon;
        private int _faLeistungID;
        private int _fallBaPersonID;
        private LOVsGenerated.WshKategorie _kategorie;
        private string _kategorieText;
        private string _koa;
        private string _leistungDisplayText;
        private decimal? _percentageGBL;
        private decimal _saldo;
        private string _text;
        private int? _wshAbzugAbschlussAktionCode;
        private int _wshAbzugID;

        #endregion

        #endregion

        #region Properties

        public DateTime? AbschlussDatum
        {
            get { return _abschlussDatum; }
            set { _abschlussDatum = value; }
        }

        public decimal BetragMonatlich
        {
            get { return _betragMonatlich; }
            set { _betragMonatlich = value; }
        }

        public string Betrifft
        {
            get { return _betrifft; }
            set { _betrifft = value; }
        }

        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ChangeTrackingEnabled = true;
                    _changeTracker.State = ObjectState.Unchanged;
                }
                return _changeTracker;
            }
        }

        public DateTime? DatumBis
        {
            get { return _datumBis; }
            set { _datumBis = value; }
        }

        public DateTime DatumVon
        {
            get { return _datumVon; }
            set { _datumVon = value; }
        }

        public int FaLeistungID
        {
            get { return _faLeistungID; }
            set { _faLeistungID = value; }
        }

        public int FallBaPersonID
        {
            get { return _fallBaPersonID; }
            set { _fallBaPersonID = value; }
        }

        public LOVsGenerated.WshKategorie Kategorie
        {
            get { return _kategorie; }
            set { _kategorie = value; }
        }

        public string KategorieText
        {
            get { return _kategorieText; }
            set { _kategorieText = value; }
        }

        public string Koa
        {
            get { return _koa; }
            set { _koa = value; }
        }

        public string LeistungDisplayText
        {
            get { return _leistungDisplayText; }
            set { _leistungDisplayText = value; }
        }

        public decimal? PercentageGBL
        {
            get { return _percentageGBL; }
            set { _percentageGBL = value; }
        }

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public int? WshAbzugAbschlussAktionCode
        {
            get { return _wshAbzugAbschlussAktionCode; }
            set { _wshAbzugAbschlussAktionCode = value; }
        }

        public int WshAbzugID
        {
            get { return _wshAbzugID; }
            set { _wshAbzugID = value; }
        }

        #endregion
    }
}