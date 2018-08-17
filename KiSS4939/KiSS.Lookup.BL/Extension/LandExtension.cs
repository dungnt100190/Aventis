using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS.Lookup.BL.DTO;
using KiSS.Lookup.DA;

namespace KiSS.Lookup.BL.Extension
{
    /// <summary>
    /// Extension to the <see cref="Land"/> class
    /// </summary>
    static class LandExtension
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Set the value of a <see cref="Land"/> with the ones from a <see cref="BaLand"/>
        /// </summary>
        /// <param name="land">The Entity to set</param>
        /// <param name="dbLand">The transfer object to get the value from</param>
        public static void Set(this Land land, BaLand dbLand)
        {
            land.BFSCode = dbLand.BFSCode;
            land.BaLandID = dbLand.BaLandID;
            land.Iso3Code = dbLand.Iso3Code;
            land.Name = dbLand.Text;
            land.Iso2Code = dbLand.Iso2Code;
        }

        /// <summary>
        /// Converts a <see cref="BaLand"/> to a <see cref="Land"/>
        /// </summary>
        /// <param name="dbLand"></param>
        /// <returns></returns>
        public static Land ToLand(this BaLand dbLand)
        {
            Land land = new Land();
            land.Set(dbLand);
            return land;
        }

        /// <summary>
        /// Get the result from <see cref="IQueryable<XLOVCode>"/> as a <see cref="List<Land>"/>
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Land> ToLandList(this IQueryable<BaLand> query)
        {
            List<Land> lst = new List<Land>();

            foreach (var result in query)
            {
                lst.Add(result.ToLand());
            }

            return lst;
        }

        #endregion

        #endregion
    }
}