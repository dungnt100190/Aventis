#region Header

/*-------------------------------------------------------------------------
Copyright:	Born Informatik AG
            Morgenstrasse 129
            CH - 3018 Bern
            www.born.ch

----------------------------------------------------------------------------
file:			WsDelegator.cs
creation:		28.11.2007
author:			Daniel Minder (daniel.minder@born.ch)
description:	Interface used by the web service of the Kiss-Alpi Module.
modifications:
       - 06.12.2007 daniel minder aenderungen signaturen fuer
                    kostenstellen eintrag und klassierung im abacus

---------------------------------------------------------------------------
-------------------------------------------------------------------------*/

#endregion

using System;
using System.Data;

namespace KiSS4.Schnittstellen.Abacus.KACon
{
    /// <summary>
    /// Signature of methods called by the web service of the Kiss-Alpi Module
    /// </summary>
    public interface AbaDelegator
    {
        #region Methods

        /// <summary>
        /// Returns a data set corresponding to the sqlString.
        /// Throws exception or child of it in case of error.
        /// </summary>
        /// <param name="techUser">Abacus user which is ODBC allowed</param>
        /// <param name="techPw">Pw of the techUser</param>
        /// <param name="techMandant">Mandant-> lohnmandant (technisch user)</param>
        /// <param name="oleUser">OLE user name</param>
        /// <param name="olePw">OLE user password</param>
        /// <param name="oleMandant">OLE MandantNr</param>
        /// <param name="sqlString">Select statement what we want the data from</param>
        /// <param name="abaPath">Folder of abacus data (eg: "C:\\abac")</param>
        /// <returns>Returns a data set corresponding to the sqlString</returns>
        DataSet GetCoworkersWithSql(String techUser, String techPw, Int32 techMandant, String oleUser, String olePw, Int32 oleMandant, String sqlString, String abaPath);

        #endregion
    }
}