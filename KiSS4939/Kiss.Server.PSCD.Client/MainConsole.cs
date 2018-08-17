using System;
using System.Runtime.InteropServices;

using Kiss.Infrastructure;

namespace Kiss.Server.PSCD.Client
{
    public class MainConsole
    {
        #region DllImport

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool FreeConsole();

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ArgumentDictionary _arguments;

        private const string ARG_CALL = "call";
        private const string ARG_DBNAME = "db";
        private const string ARG_HELP1 = "h";
        private const string ARG_HELP2 = "?";
        private const string ARG_TIMESTAMP = "ts";
        private const string CALL_ZAHLUNGSEINGAENGE_ABHOLEN_INT = "1";
        private const string CALL_ZAHLUNGSEINGAENGE_ABHOLEN_STR = "ZAHLUNGSEINGAENGEABHOLEN";
        private const int RET_ERROR = 0xF;
        private const int RET_NO_ARGUMENT = 1;
        private const int RET_NO_CALL = -1;

        #endregion

        #endregion

        #region Constructors

        public MainConsole(string[] args)
        {
            _arguments = new ArgumentDictionary('/', args);
        }

        #endregion

        #region Methods

        #region Public Methods

        public int Run()
        {
            // Register for console output
            AttachConsole(-1);

            WriteConsole("Running in console mode");

            int exitValue = 0;

            // Validate arguments
            if (_arguments.Count == 0)
            {
                WriteConsole("Invalid number of arguments");
                return RET_NO_ARGUMENT;
            }

            if (_arguments.ContainsKey(ARG_HELP1) || _arguments.ContainsKey(ARG_HELP2))
            {
                PrintHelp();
            }
            else
            {
                // Parse call argument
                if (!_arguments.ContainsKey(ARG_CALL))
                {
                    WriteConsole("Use /{0} for help.", ARG_HELP1);
                    exitValue = RET_NO_CALL;
                }
                else
                {
                    var call = _arguments[ARG_CALL];

                    if (call == CALL_ZAHLUNGSEINGAENGE_ABHOLEN_STR || call == CALL_ZAHLUNGSEINGAENGE_ABHOLEN_INT)
                    {
                        string dbName, timestamp;
                        _arguments.TryGetValue(ARG_DBNAME, out dbName);
                        _arguments.TryGetValue(ARG_TIMESTAMP, out timestamp);

                        var result = WebServiceProxy.SstZahlungseingaengeAbholen(null, dbName, timestamp);
                        WriteConsole("Result: {0}", result);

                        exitValue = result ? 0 : RET_ERROR;
                    }
                }
            }

            // Cleanup
            FreeConsole();
            return exitValue;
        }

        #endregion

        #region Private Methods

        private void PrintHelp()
        {
            Console.WriteLine("Hilfe:");
            Console.WriteLine("Parameter:");
            Console.WriteLine(" /{0} <Call>", ARG_CALL);
            Console.WriteLine(" /{0} <DBName>", ARG_DBNAME);
            Console.WriteLine(" /{0} <Timestamp>", ARG_TIMESTAMP);
            Console.WriteLine(" /{0} oder /{1} - Hilfe", ARG_HELP1, ARG_HELP2);
            Console.WriteLine("Verfügbare Werte für <Call>:");
            Console.WriteLine("Zahlungseingänge abholen:");
            Console.WriteLine("{0} / {1}{2}", CALL_ZAHLUNGSEINGAENGE_ABHOLEN_INT, CALL_ZAHLUNGSEINGAENGE_ABHOLEN_STR, Environment.NewLine);
        }

        private void WriteConsole(string message, params object[] args)
        {
            Console.WriteLine(DateTime.Now + ": " + message, args);
        }

        #endregion

        #endregion
    }
}