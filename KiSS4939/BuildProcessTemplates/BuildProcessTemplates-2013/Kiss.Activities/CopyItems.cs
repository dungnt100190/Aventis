using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow.Activities;
using Microsoft.TeamFoundation.Build.Workflow.Tracking;

namespace Kiss.Activities
{
    [ActivityTracking(ActivityTrackingOption.None)]
    [BuildActivity(HostEnvironmentOption.All)]
    [Description("Copies items based on regular expressions.")]
    public class CopyItems : CodeActivity
    {
        #region Properties

        [RequiredArgument]
        public InArgument<string> Destination
        {
            get;
            set;
        }

        [RequiredArgument]
        public InArgument<IEnumerable<string>> ItemsToCopy
        {
            get;
            set;
        }

        [RequiredArgument]
        public InArgument<string> Source
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Internal Static Methods

        internal static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            if (!Directory.Exists(target.FullName))
            {
                Directory.CreateDirectory(target.FullName);
            }

            foreach (var fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }

        internal static void CopyItem(FileSystemInfo item, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            item.Attributes = FileAttributes.Normal;
            var destinationName = Path.Combine(destination.FullName, item.Name);

            if (item is FileInfo)
            {
                ((FileInfo)item).CopyTo(destinationName, true);
            }
            else if (item is DirectoryInfo)
            {
                CopyDirectory((DirectoryInfo)item, new DirectoryInfo(destinationName));
            }
        }

        internal static void CopyItemsInternal(CodeActivityContext context, List<Regex> regexes, DirectoryInfo source, DirectoryInfo destination)
        {
            var fileSystemInfos = source.GetFileSystemInfos("*", SearchOption.TopDirectoryOnly);

            foreach (var item in fileSystemInfos)
            {
                if (regexes.Any(x => x.IsMatch(item.Name)))
                {
                    var message = string.Format("Copying file '{0}' to '{1}'", item.FullName, destination.FullName);
                    if (context != null)
                    {
                        context.TrackBuildMessage(message, BuildMessageImportance.High);
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }

                    CopyItem(item, destination);
                }
                else if (item is DirectoryInfo)
                {
                    CopyItemsInternal(context, regexes, (DirectoryInfo)item, new DirectoryInfo(Path.Combine(destination.FullName, item.Name)));
                }
            }
        }

        #endregion

        #region Protected Methods

        protected override void Execute(CodeActivityContext context)
        {
            var source = new DirectoryInfo(Source.Get(context));
            var destination = new DirectoryInfo(Destination.Get(context));
            var itemsToCopy = ItemsToCopy.Get(context);

            var regexList = new List<Regex>();

            foreach (var regexString in itemsToCopy)
            {
                regexList.Add(new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase));
            }

            CopyItemsInternal(context, regexList, source, destination);
        }

        #endregion

        #endregion
    }
}