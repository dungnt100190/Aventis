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
    [Description("Deletes files based on a list of regular expressions.")]
    public sealed class DeleteItems : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Directory
        {
            get;
            set;
        }

        [RequiredArgument]
        public InArgument<IEnumerable<string>> ItemsToDelete
        {
            get;
            set;
        }

        public InArgument<IEnumerable<string>> ItemsToKeep
        {
            get;
            set;
        }

        internal void DeleteItemsInternal(CodeActivityContext context, DirectoryInfo directory, List<Regex> itemsToDelete, List<Regex> itemsToKeep)
        {
            var fileSystemInfos = directory.GetFileSystemInfos("*", SearchOption.TopDirectoryOnly);

            foreach (var fileSystemInfo in fileSystemInfos)
            {
                if (!itemsToKeep.Any(x => x.IsMatch(fileSystemInfo.Name)))
                {
                    if (itemsToDelete.Any(x => x.IsMatch(fileSystemInfo.Name)))
                    {
                        DeleteItem(fileSystemInfo);

                        if (context != null)
                        {
                            context.TrackBuildMessage(string.Format("Deleted item: '{0}'.", fileSystemInfo.FullName), BuildMessageImportance.High);
                        }
                    }
                    else if (fileSystemInfo is DirectoryInfo)
                    {
                        DeleteItemsInternal(context, (DirectoryInfo)fileSystemInfo, itemsToDelete, itemsToKeep);
                    }
                }
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            var directory = context.GetValue(Directory);
            var itemsToDelete = context.GetValue(ItemsToDelete);
            var itemsToKeep = context.GetValue(ItemsToKeep);

            context.TrackBuildMessage(string.Format("Deleting files in '{0}'.", directory));

            // create regular expressions for item name checking
            var itemsToDeleteRegex = new List<Regex>();
            var itemsToKeepRegex = new List<Regex>();

            foreach (var item in itemsToDelete)
            {
                try
                {
                    itemsToDeleteRegex.Add(new Regex(item, RegexOptions.Compiled | RegexOptions.IgnoreCase));
                }
                catch (Exception ex)
                {
                    context.TrackBuildWarning(ex.ToString());
                }
            }

            foreach (var item in itemsToKeep)
            {
                try
                {
                    itemsToKeepRegex.Add(new Regex(item, RegexOptions.Compiled | RegexOptions.IgnoreCase));
                }
                catch (Exception ex)
                {
                    context.TrackBuildWarning(ex.ToString());
                }
            }

            // perform recursive item deletion
            DeleteItemsInternal(context, new DirectoryInfo(directory), itemsToDeleteRegex, itemsToKeepRegex);
        }

        private static void ResetAttributes(DirectoryInfo baseDirectory)
        {
            foreach (var directory in baseDirectory.GetDirectories())
            {
                ResetAttributes(directory);
            }

            foreach (var fileInfo in baseDirectory.GetFiles())
            {
                fileInfo.Attributes = FileAttributes.Normal;
            }
        }

        private void DeleteItem(FileSystemInfo fileSystemInfo)
        {
            // delete item
            var directoryInfo = fileSystemInfo as DirectoryInfo;

            if (directoryInfo != null)
            {
                ResetAttributes(directoryInfo);
                directoryInfo.Delete(true);
            }
            else
            {
                fileSystemInfo.Attributes = FileAttributes.Normal;
                fileSystemInfo.Delete();
            }
        }
    }
}