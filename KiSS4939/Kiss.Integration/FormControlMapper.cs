using KiSS4.DB;

namespace Kiss.Integration
{
    public class FormControlMapper
    {
        public static string GetControlFromForm(string className)
        {
            try
            {
                return DBUtil.ExecuteScalarSQL(@"
                SELECT ControlName
                FROM dbo.MigXClassFrmToCtl WITH (READUNCOMMITTED)
                WHERE FormName = {0};", className) as string;
            }
            catch
            {
                return className;
            }
        }
    }
}