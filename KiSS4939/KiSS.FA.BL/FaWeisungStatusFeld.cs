using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure.Constant;

namespace KiSS.FA.BL
{
    /// <summary>
    /// Klasse um einen Feldname an einem Weisungstatus anzubinden.
    /// </summary>
    public class FaWeisungStatusFeld
    {
        #region Fields

        #region Private Fields

        private string _feldname;
        private bool _mussFeld;
        private LOVsGenerated.FaWeisungStatus _status;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Konstruktor um ein <see cref="FaWeisungStatusFeld"/> Objekt zu erstellen.
        /// </summary>
        /// <param name="status">Ein Weisungstatus (<see cref="FaWeisung.Status"/>)</param>
        /// <param name="feldname">Feldname auf der Maske</param>
        /// <param name="mussFeld">Das Feld ist ein Muss oder nicht</param>
        public FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus status, string feldname, bool mussFeld)
        {
            _status = status;
            _feldname = feldname;
            _mussFeld = mussFeld;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Feldname auf der Maske
        /// </summary>
        public string Feldname
        {
            get { return _feldname; }
        }

        /// <summary>
        /// Um zu wissen ob es ein Mussfeld ist.
        /// </summary>
        public bool MussFeld
        {
            get { return _mussFeld; }
        }

        /// <summary>
        /// Weisungstatus
        /// </summary>
        public LOVsGenerated.FaWeisungStatus Status
        {
            get { return _status; }
        }

        #endregion
    }
}