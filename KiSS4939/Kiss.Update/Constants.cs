namespace Kiss.Update
{
    public class Constants
    {
        #region Fields

        #region Public Static Fields

        public static readonly string[] FilesToKeep = 
            {
                "KiSS4.exe.config"
            };

        public static readonly string[] UpdateFiles =
            {
                "Kiss.Update.exe",
                "Kiss.Update.exe.config",
                "C1.C1Zip.dll",
                "log4net.dll"
            };

        #endregion

        #region Public Constant/Read-Only Fields

        public const string ARG_NO_UPDATE = "noupdate";
        public const string BACKUP_FOLDER_NAME = "_backup";
        public const string KISS_MAIN_FILE_NAME = "KiSS4.exe";
        public const string LOCAL_TS_FILE_NAME = "Kiss.Update.ts";
        public const string UPDATE_APPLICATION = "Kiss.Update.exe";

        #endregion

        #endregion
    }
}