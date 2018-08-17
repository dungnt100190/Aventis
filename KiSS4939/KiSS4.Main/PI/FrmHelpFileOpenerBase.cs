using System;
using System.IO;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Main.PI
{
    public class FrmHelpFileOpenerBase : KiSS4.Gui.KissChildForm
    {
        #region Constructors

        public FrmHelpFileOpenerBase()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // FrmHelpFileOpenerBase
            //
            this.ClientSize = new System.Drawing.Size(144, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(-100, -100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHelpFileOpenerBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Helpfile Opener";
            this.ResumeLayout(false);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Combine folder with folder or folder with file as [folder\item]
        /// </summary>
        /// <param name="pstrFolder">Folder we want to use</param>
        /// <param name="pstrFile">Item (folder or file) we want to append to folder</param>
        /// <returns>Folder and item combined as [folder\item]</returns>
        public static string CombineFolderWithItem(string pstrFolder, string pstrFile)
        {
            try
            {
                //validate first
                pstrFolder = pstrFolder.Trim();
                pstrFile = pstrFile.Trim();

                if (DBUtil.IsEmpty(pstrFolder) && DBUtil.IsEmpty(pstrFile))
                {
                    //return nothing
                    return "";
                }
                if (DBUtil.IsEmpty(pstrFolder))
                {
                    return pstrFile;
                }
                else if (DBUtil.IsEmpty(pstrFile))
                {
                    return pstrFolder;
                }

                //check if folder ends with "\"
                if (pstrFolder.EndsWith(@"\") || pstrFile.StartsWith(@"\"))
                {
                    //just append item
                    return pstrFolder + pstrFile;
                }
                else
                {
                    //append "\" and item
                    return string.Format(@"{0}\{1}", pstrFolder, pstrFile);
                }
            }
            catch (Exception ex)
            {
                // throw exception further on due to unknown state
                throw ex;
            }
        }

        /// <summary>
        /// Check if a specific file does exist
        /// </summary>
        /// <param name="pstrFilePathName">The filename including path to check if existing</param>
        /// <returns>True if file exists, false if file does not exist</returns>
        public static bool FileExists(string pstrFilePathName)
        {
            try
            {
                // validate first
                pstrFilePathName = pstrFilePathName.Trim();

                if (DBUtil.IsEmpty(pstrFilePathName))
                {
                    return false;
                }

                // check if file exists
                return File.Exists(pstrFilePathName);
            }
            catch (Exception ex)
            {
                // throw exception further on due to unknown state
                throw ex;
            }
        }

        public void HandleOpenHelpFile(String helpFile, Boolean doAppendLocalPath)
        {
            try
            {
                // set cursor
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // check if need to append path
                if (doAppendLocalPath)
                {
                    // apply setup path
                    helpFile = CombineFolderWithItem(Session.ApplicationStartupPath, helpFile);
                }

                // check if file exists
                if (!FileExists(helpFile))
                {
                    // file not found
                    if (doAppendLocalPath)
                    {
                        // not found in kiss directory
                        throw new Exception(string.Format("The desired file '{0}' was not found in KiSS root directory.", helpFile));
                    }
                    else
                    {
                        // not found in given directory
                        throw new Exception(string.Format("The desired file '{0}' was not found.", helpFile));
                    }
                }

                // show file
                System.Diagnostics.Process.Start(helpFile);
            }
            catch (Exception ex)
            {
                // throw exception further on
                throw ex;
            }
            finally
            {
                // reset cursor
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion
    }
}