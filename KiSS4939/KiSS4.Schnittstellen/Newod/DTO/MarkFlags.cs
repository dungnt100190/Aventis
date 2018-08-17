using System;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class Markflags
    {
        bool _as;
        bool _chs;
        bool _chv;
        bool _kiss;

        /// <summary>
        /// Nation <> Schweiz und mind. 1 aktive Sozialhilfe
        /// </summary>
        public bool AS { get { return _as; } set { _as = value; } }

        /// <summary>
        /// Nation = Schweiz und mind. 1 aktive Sozialhilfe
        /// </summary>
        public bool CHS { get { return _chs; } set { _chs = value; } }

        /// <summary>
        /// nur Aktive Vormundschaftliche Massnahme
        /// </summary>
        public bool CHV { get { return _chv; } set { _chv = value; } }

        /// <summary>
        /// KiSS relevant
        /// </summary>
        public bool KISS { get { return _kiss; } set { _kiss = value; } }

        /// <summary>
        /// Returns the values for diagnostics
        /// </summary>
        /// <returns>the set flags as a string</returns>
        public override string ToString()
        {
            string s = "Flags:";

            if (AS)
                s += " AS";
            if (CHS)
                s += " CHS";
            if (CHV)
                s += " CHV";
            if (KISS)
                s += " KISS";

            return s;
        }
    }
}