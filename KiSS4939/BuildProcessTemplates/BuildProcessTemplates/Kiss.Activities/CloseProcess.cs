using System.Activities;
using System.ComponentModel;
using System.Diagnostics;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow.Activities;
using Microsoft.TeamFoundation.Build.Workflow.Tracking;

namespace Kiss.Activities
{
    [ActivityTracking(ActivityTrackingOption.None)]
    [BuildActivity(HostEnvironmentOption.All)]
    [Description("Closes a specific process if it is running.")]
    public class CloseProcess : CodeActivity
    {
        #region Properties

        [RequiredArgument]
        public InArgument<string> ProcessName
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Execute(CodeActivityContext context)
        {
            var processName = ProcessName.Get(context);
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                foreach (var process in processes)
                {
                    try
                    {
                        if (process.CloseMainWindow())
                        {
                            context.TrackBuildMessage(string.Format("Closed process '{0}' with ID '{1}'.", process.ProcessName, process.Id));
                        }
                        else
                        {
                            process.Kill();
                            context.TrackBuildMessage(string.Format("Killed process '{0}' with ID '{1}'.", process.ProcessName, process.Id));
                        }
                    }
                    catch
                    {
                        context.TrackBuildError(string.Format("Could not close the process '{0}' with ID '{1}'.", process.ProcessName, process.Id));
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}