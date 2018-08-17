using System;
using System.Activities;
using System.ComponentModel;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow.Tracking;

namespace Kiss.Activities
{
    [ActivityTracking(ActivityTrackingOption.None)]
    [BuildActivity(HostEnvironmentOption.All)]
    [Description("Adds a hyperlink to the Build Detail.")]
    public class AddLinkToBuildDetail : CodeActivity
    {
        #region Properties

        [RequiredArgument]
        public InArgument<IBuildDetail> BuildDetail
        {
            get;
            set;
        }

        [RequiredArgument]
        public InArgument<string> DisplayText
        {
            get;
            set;
        }

        [RequiredArgument]
        public InArgument<string> Url
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Execute(CodeActivityContext context)
        {
            var buildDetail = context.GetValue(BuildDetail);
            var displayText = context.GetValue(DisplayText);
            var url = context.GetValue(Url);

            buildDetail.Information.AddExternalLink(displayText, new Uri(url));
            buildDetail.Information.Save();
        }

        #endregion

        #endregion
    }
}