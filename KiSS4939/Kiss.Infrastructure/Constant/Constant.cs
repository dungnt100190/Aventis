using System;
using System.Data.SqlTypes;

namespace Kiss.Infrastructure.Constant
{
    public class Constant
    {
        #region Fields

        #region Public Static Fields

        public static readonly DateTime SqlDateTimeMax = SqlDateTime.MaxValue.Value;
        public static readonly DateTime SqlDateTimeMin = SqlDateTime.MinValue.Value;

        #endregion

        #region Public Constant/Read-Only Fields

        public const string CREATED = "Created";
        public const string CREATOR = "Creator";
        public const string DATETIME_FORMAT_DDMMYYYY = "dd.MM.yyyy";
        public const string KBUBELEGPOSITION_HABEN = "H";
        public const string KBUBELEGPOSITION_SOLL = "S";
        public const string MODIFIED = "Modified";
        public const string MODIFIER = "Modifier";
        public const int MODULEID_W = 3;

        #endregion

        #endregion
    }
}