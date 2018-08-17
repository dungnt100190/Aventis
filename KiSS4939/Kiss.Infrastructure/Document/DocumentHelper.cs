using System;
using System.Diagnostics;
using System.IO;

using Kiss.Interfaces.BL;

namespace Kiss.Infrastructure.Document
{
    public class DocumentHelper
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IServiceResult PrintDocument(FileInfo fileInfo, string printerName = null)
        {
            _logger.InfoFormat("Document '{0}' printed on '{1}'", fileInfo.FullName, string.IsNullOrEmpty(printerName) ? "Default printer" : printerName);

            var result = KissServiceResult.Ok();

            var p = new Process();
            if (!string.IsNullOrEmpty(printerName))
            {
                p.StartInfo.Verb = "printto";
                p.StartInfo.Arguments = string.Format("\"{0}\"", printerName);
            }
            else
            {
                p.StartInfo.Verb = "print";
            }

            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = fileInfo.FullName;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            try
            {
                p.Start();
            }
            catch (Exception ex)
            {
                // TODO Mehrsprachigkeit
                result += new Exception(string.Format("Dateityp {0} ist nicht bekannt.", fileInfo.Extension), ex);
            }

            return result;
        }
    }
}