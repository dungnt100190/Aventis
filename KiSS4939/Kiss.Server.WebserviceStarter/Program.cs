using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Kiss.Server.WebserviceStarter.Properties;
using log4net;
using log4net.Config;

namespace Kiss.Server.WebserviceStarter
{
    internal class Program
    {
        private static readonly ILog _log;

        static Program()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(typeof(Program));
        }

        private static int Main(string[] args)
        {
            var arguments = new ArgumentDictionary(new[] { '-', '/' }, args);
            var serviceStarters = new ServiceStarter[]
            {
                new EinwohnerregisterServiceStarter(arguments),
                new IbanServiceStarter(arguments),
                new WorkerProcessStarter(arguments)
            };

            if (arguments.ContainsKey("?") ||
                arguments.ContainsKey("h") ||
                arguments.ContainsKey("help"))
            {
                ShowHelp(serviceStarters);
                return 0;
            }

            var serviceName = arguments[ParameterNames.ServiceName] ?? Settings.Default.ServiceName;
            _log.DebugFormat("Start execution - Service name: {0}", serviceName);

            int result;

            var serviceStarter = serviceStarters.FirstOrDefault(s => s.ServiceName.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));

            if (serviceStarter != null)
            {
                result = serviceStarter.Start();
            }
            else
            {
                _log.DebugFormat("Service {0} existiert nicht.", serviceName);
                var emailNotificationService = new EmailNotificationService(arguments);
                result = emailNotificationService.NotifyFailure(serviceName, "Dieser Service existiert nicht.") ? -1 : -2;
            }

            _log.DebugFormat("Finished execution - Return code {0}", result);

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }

            return result;
        }

        private static void ShowHelp(ServiceStarter[] serviceStarters)
        {
            var assemblyVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            WriteLine(ConsoleColor.Yellow, "Kiss.Server.WebServiceStarter {0} Hilfe", assemblyVersion.FileVersion);

            WriteLine(ConsoleColor.Green, "Parameter:");
            var parameterNamesType = typeof(ParameterNames);
            var namesProperties = parameterNamesType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var namesProperty in namesProperties)
            {
                var descriptionAttribute = namesProperty.GetCustomAttribute<DescriptionAttribute>();
                WriteLine(ConsoleColor.Yellow, "{0,4}/{1}:", "", namesProperty.Name);
                WriteLine(ConsoleColor.White, "{0,4}{1}", "", descriptionAttribute != null ? descriptionAttribute.Description : null);
            }
            Console.WriteLine();

            WriteLine(ConsoleColor.Green, "Services (/{0}):", ParameterNames.ServiceName);
            foreach (var serviceStarter in serviceStarters)
            {
                WriteLine(ConsoleColor.Yellow, "{0,4}{1}", "", serviceStarter.ServiceName);
                WriteLine(ConsoleColor.Yellow, "{0,6}Methoden (/{1}):", "", ParameterNames.MethodName);
                foreach (var methodName in serviceStarter.AvailableMethods)
                {
                    WriteLine(ConsoleColor.White, "{0,8}{1}", "", methodName);
                }
                Console.WriteLine();
            }

            //Beispiel
            var programName = Assembly.GetExecutingAssembly().ManifestModule.Name;
            WriteLine(ConsoleColor.Green, "Aufruf:");
            WriteLine(ConsoleColor.White, "{0} /ParameterName ParameterWert", programName);
            Console.WriteLine();

            var beispielServiceStarter = serviceStarters.FirstOrDefault();
            if (beispielServiceStarter != null)
            {
                var beispielServiceMethode = beispielServiceStarter.AvailableMethods.FirstOrDefault();
                if (beispielServiceMethode != null)
                {
                    WriteLine(ConsoleColor.Yellow, "Beispiel:");
                    WriteLine(ConsoleColor.White, "{0} /{1} {2} /{3} {4}",
                        programName,
                        ParameterNames.ServiceName, beispielServiceStarter.ServiceName,
                        ParameterNames.MethodName, beispielServiceMethode);
                }
            }

            Console.ReadLine();
        }

        private static void WriteLine(ConsoleColor color, string format, params object[] arg)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg);
            Console.ForegroundColor = originalColor;
        }
    }
}