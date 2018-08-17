using System;
using System.Reflection;
using log4net;
using System.Text;

namespace KiSSSvc.Logging
{
	/// <summary>
	/// A helper class to simplify the logging.
	/// The logger contains the name of the class. 
	/// </summary>
	/// <remarks>
	/// Logging is done by Log4Net
	/// </remarks>
	public class Log
	{
 		#region Public Static Methods

		/// <summary>
		/// Initialize the logger 
		/// </summary>
		/// <remarks>
		/// usually called in Application_Start
		/// </remarks>
		public static void Init()
		{			
            log4net.Config.XmlConfigurator.Configure();
		}

		/// <summary>
		/// Writes a debug message to the Logger
		/// </summary>
		/// <param name="t">The type of class which writes the message</param>
		/// <param name="msg">The message to be written</param>
		static public void Debug(Type t, string msg)
		{
			//System.Diagnostics.Debug.WriteLine("DEBUG: ", msg);            
			GetLogger(t).Debug(msg);
		}

		/// <summary>
		/// Writes an information message to the Logger
		/// </summary>
		/// <param name="t">The type of class which writes the message</param>
		/// <param name="msg">The message to be written</param>
		static public void Info(Type t, string msg)
		{
			System.Diagnostics.Debug.WriteLine("INFO: ", msg);
			GetLogger(t).Info(msg);
		}

		/// <summary>
		/// Writes a warning message to the Logger
		/// </summary>
		/// <param name="t">The type of class which writes the message</param>
		/// <param name="msg">The message to be written</param>
		static public void Warn(Type t, string msg)
		{
			System.Diagnostics.Debug.WriteLine("WARN: ", msg);
			GetLogger(t).Warn(msg);
		}

		/// <summary>
		/// Writes an error message to the Logger
		/// </summary>
		/// <param name="t">The type of class which writes the error</param>
		/// <param name="msg">The message to be written</param>
		static public void Error(Type t, string msg)
		{
			System.Diagnostics.Debug.WriteLine("ERROR: ", msg);
			GetLogger(t).Error(msg);
		}

		/// <summary>
		/// Writes an error message to the Logger
		/// </summary>
		/// <param name="t">The type of class which writes the error</param>
		/// <param name="msg">The message to be written</param>
		/// <param name="ex">The exception to be written</param>
		static public void Error(Type t, String msg, Exception ex)
		{
			System.Diagnostics.Debug.WriteLine("ERROR: ", msg);
            GetLogger(t).Error(msg, ex);
		}

		/// <summary>
		/// Writes an error message to the Logger
		/// </summary>
		/// <remarks>
		/// use <see>System.Reflection.MethodBase.GetCurrentMethod()</see> to get the Method/Propery call
		/// </remarks>
		/// <param name="mb">Current Method</param>
		/// <param name="ex">The exception to be written</param>
		static public void Error(MethodBase mb, Exception ex)
		{
			Error(mb.ReflectedType, "Error in " + mb.Name, ex);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mb"></param>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        static public void Error(MethodBase mb, string msg, Exception ex)
        {
            Error(mb.ReflectedType, "Error in " + mb.Name + Environment.NewLine + msg, ex);
        }

		#endregion

		#region Private methods

		private ILog GetLogger()
		{
			return GetLogger(this.GetType());
		}
		static private ILog GetLogger(Type t)
		{
			return LogManager.GetLogger(t);
		}

        private static string DisplayException(Exception e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Outer Exception.");
            sb.Append("ExceptionType: " + e.GetType().Name.ToString());
            sb.Append("HelpLine: " + e.HelpLink);
            sb.Append("Message: " + e.Message);
            sb.Append("Source: " + e.Source);
            sb.Append("StackTrace: " + e.StackTrace);
            sb.Append("TargetSite: " + e.TargetSite);

            string indent = "\t";
            Exception ie = e;

            while (ie.InnerException != null)
            {
                ie = ie.InnerException;

                sb.Append("Inner Exception.");
                sb.Append(indent + "ExceptionType: " + ie.GetType().Name.ToString());
                sb.Append(indent + "HelpLink: " + ie.HelpLink);
                sb.Append(indent + "Message: " + ie.Message);
                sb.Append(indent + "Source: " + ie.Source);
                sb.Append(indent + "StackTrace: " + ie.StackTrace);
                sb.Append(indent + "TargetSite: " + ie.TargetSite);

                indent += "\t";
            }

            return sb.ToString();
        }

		#endregion
	}
}
