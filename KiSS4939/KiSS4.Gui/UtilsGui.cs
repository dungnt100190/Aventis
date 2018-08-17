using DevExpress.XtraEditors.Repository;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// Class contains common used helper methods for graphical user interface handling
    /// </summary>
    public class UtilsGui
    {
        /// <summary>
        /// Activates the user control.
        /// </summary>
        /// <param name="newSubMask">The new sub mask.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="forceDispose">if set to <c>true</c> [force dispose].</param>
        /// <param name="showDetail">UtilsShowDetail from KissForm or KissUserControl</param>
        /// <returns></returns>
        public static bool ActivateUserControl(IKissView newSubMask, Control parent, bool forceDispose, ref UtilShowDetail showDetail)
        {
            if (showDetail == null)
            {
                showDetail = new UtilShowDetail(parent);
            }

            return showDetail.ShowDetail(newSubMask, forceDispose);
        }

        /// <summary>
        /// Get all controls including controls of child-controls (recursive)
        /// </summary>
        /// <param name="ParentControl">The control to get child-controls from</param>
        /// <param name="allControls">Add Child of KissComplexControl to</param>
        /// <returns>All controls found within the ParentControl</returns>
        public static ArrayList AllControls(Control ParentControl, bool allControls)
        {
            ArrayList arr = new ArrayList();

            foreach (Control ctl in ParentControl.Controls)
            {
                arr.Add(ctl);

                if (allControls || !(ctl is KissComplexControl))
                {
                    AddControls(arr, ctl, allControls);
                }
            }

            return arr;
        }

        /// <summary>
        /// Get all controls including controls of child-controls (recursive)
        /// </summary>
        /// <param name="ParentControl">The control to get child-controls from</param>
        /// <returns>All controls found within the ParentControl</returns>
        public static ArrayList AllControls(Control ParentControl)
        {
            return AllControls(ParentControl, true);
        }

        /// <summary>
        /// Disable closing of form. Remember to call EnableCloseForm after finished work.
        /// </summary>
        /// <param name="frm">The form to handle</param>
        /// <returns><c>True</c> if closing was disabled, otherwise false</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter form is null</exception>
        public static bool DisableCloseForm(Form frm)
        {
            // validate
            if (frm == null)
            {
                throw new ArgumentNullException("frm", "No instance of the form, cannot disable closing.");
            }

            // validate form
            if (!(frm is KissForm) || (frm is KissMainForm))
            {
                // closing cannot be disabled
                return false;
            }

            // disable closing
            ((KissForm)frm).LockCloseForm();

            // button was disabled
            return true;
        }

        /// <summary>
        /// Enable closing of form
        /// </summary>
        /// <param name="frm">The form to handle</param>
        /// <param name="wasDisabled">Flag if closing was disabled</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter form is null</exception>
        public static void EnableCloseFrom(Form frm, bool wasDisabled)
        {
            // validate
            if (frm == null)
            {
                throw new ArgumentNullException("frm", "No instance of the form, cannot enable closing.");
            }

            // validate form
            if (!(frm is KissForm))
            {
                // button cannot be enabled
                return;
            }

            // check if button was disabled
            if (wasDisabled)
            {
                // enable closing again
                ((KissForm)frm).UnlockCloseForm();
            }
        }

        /// <summary>
        /// Finds the files matching the given pattern(s). Leave filePattern empty to list all files.
        /// </summary>
        /// <param name="startDirectory">The start directory</param>
        /// <param name="filePattern">The file pattern (e.g. "*.exe;*.dll")</param>
        /// <param name="recursive">if set to <c>true</c> [recursive], if set to <c>false</c> only startDirectory will be handled</param>
        /// <returns>A <see cref="ReadOnlyCollection&lt;FileInfoT&gt;"/> of files found matching given parameters</returns>
        public static ReadOnlyCollection<FileInfo> FindFiles(String startDirectory, String filePattern, Boolean recursive)
        {
            // create new filelist
            List<FileInfo> fileList = new List<FileInfo>();

            // find all files and add them to given filelist
            UtilsGui.FindFiles(new DirectoryInfo(startDirectory), filePattern, recursive, fileList);

            // return filelist
            return new ReadOnlyCollection<FileInfo>(fileList);
        }

        /// <summary>
        /// Erstellt einen String anhand der angewählten Items in einem
        /// KissCheckedLookupEdit.
        /// Beispiel (Die items "BigMac" und "Shake" sind angewählt, dann ergibt diese Fuktion
        /// "BitMac, Shake".
        /// </summary>
        /// <param name="control">Das Control</param>
        /// <returns>Zusammengesetzter String von den angewählten Items.</returns>
        public static string GetKissCheckedLookupEditGridString(KissCheckedLookupEdit control)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < control.Items.Count; i++)
            {
                if (control.Items[i].CheckState == CheckState.Checked)
                {
                    sb.Append(control.Items[i].ToString());
                    sb.Append(", ");
                }
            }
            if (sb.Length > 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if the spezified MethodName is part of the current CallStack.
        /// This is particularly usefull when a class does not know how it's going to be used, but still needs to act depending on the usage.
        /// </summary>
        /// <param name="methodName">Name of the calling Method (without brackets or parameters), e.g. "InitializeComponent"</param>
        /// <returns></returns>
        public static bool IsCalledFromAnyMethod(string methodName)
        {
            StackTrace stack = new StackTrace();

            foreach (StackFrame frame in stack.GetFrames())
            {
                if (frame.GetMethod().Name == methodName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verify if CTRL or CTRL+SHIFT is pressed within modifier of KeyEventArgs.
        /// </summary>
        /// <param name="e">The KeyEventArgs to evaluate</param>
        /// <returns>True if CTRL or CTRL+SHIFT is pressed, otherwise false</returns>
        public static Boolean IsControlModifier(System.Windows.Forms.KeyEventArgs e)
        {
            // validate
            if (e == null)
            {
                // invalid KeyEvent
                return false;
            }

            // HACK: Due to DevExpress bug, e.g. CTRL+C will be modified to CTRL+SHIFT+C, so we have to validate e.Modifier for
            //       1. CTLR pressed or
            //       2. CTRL+SHIFT pressed
            return ((e.Modifiers == Keys.Control) || (e.Modifiers == (Keys.Control | Keys.Shift)));
        }

        /// <summary>
        /// Sets a specific EditMode of a control if user can update.
        /// </summary>
        /// <param name="edit">The edit field</param>
        /// <param name="canUpdate">User has right to update</param>
        /// <param name="mode">EditMode to be attributed</param>
        public static void SetModeIfUserHasRight(IKissEditable edit, bool canUpdate, EditModeType mode)
        {
            edit.EditMode = canUpdate ? mode : EditModeType.ReadOnly;
        }

        public static void SetRequiredIfCanUpdate(KissTextEdit edit)
        {
            SetModeIfUserHasRight(edit, edit.DataSource.CanUpdate, EditModeType.Required);
        }

        public static void SetRequiredIfCanUpdate(KissLookUpEdit edit)
        {
            SetModeIfUserHasRight(edit, edit.DataSource.CanUpdate, EditModeType.Required);
        }

        public static void SetRequiredIfCanUpdate(KissButtonEdit edit)
        {
            SetModeIfUserHasRight(edit, edit.DataSource.CanUpdate, EditModeType.Required);
        }

        public static void SetRequiredIfCanUpdate(KissMemoEdit edit)
        {
            SetModeIfUserHasRight(edit, edit.DataSource.CanUpdate, EditModeType.Required);
        }

        /// <summary>
        /// Sets the EditMode of a control to Required if it is not ReadOnly.
        /// </summary>
        /// <param name="edit">The KissControl on which the EditMode is set.</param>
        public static void SetRequiredIfNotReadOnly(IKissEditable edit)
        {
            edit.EditMode = edit.EditMode == EditModeType.ReadOnly ? EditModeType.ReadOnly : EditModeType.Required;
        }

        public static void ToggleManuelleAnredeTextFields(bool isManuelleAnrede, KissTextEdit anrede, KissTextEdit briefanrede, int? alter, int? geschlechtCode)
        {
            if (isManuelleAnrede)
            {
                anrede.EditMode = EditModeType.Required;
                briefanrede.EditMode = EditModeType.Required;
            }
            else
            {
                anrede.EditMode = EditModeType.ReadOnly;
                anrede.EditValue = DBUtil.GetAutomaticAnredeText(alter, geschlechtCode);
                briefanrede.EditMode = EditModeType.ReadOnly;
                briefanrede.EditValue = DBUtil.GetAutomaticBriefanredeText(alter, geschlechtCode);
            }
        }

        /// <summary>
        /// Used in different places. Switch between "Postfach mit Nr" (TextEdit editable) and
        /// "Postfach ohne Nr" (TextEdit Readonly).
        /// </summary>
        /// <param name="checkBox">Checkbox which initiates the switch</param>
        /// <param name="textEdit">Postfach TextEdit</param>
        /// <param name="canUpdate">Can user update.</param>
        public static void TogglePostfachOhneNrEdit(KissCheckEdit checkBox, KissTextEdit textEdit, bool canUpdate)
        {
            if (checkBox.Checked)
            {
                textEdit.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                SetModeIfUserHasRight(textEdit, canUpdate, EditModeType.Normal);

                if (textEdit.EditMode == EditModeType.Normal)
                {
                    textEdit.SelectAll();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        /// <returns></returns>
        internal static RepositoryItemLookUpEdit GetLOVLookUpEdit(SqlQuery qry, string valueMember, string displayMember)
        {
            RepositoryItemLookUpEdit LOVLookUpEdit = null;

            LOVLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            LOVLookUpEdit.AutoHeight = false;
            LOVLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                                                                                                      new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember)});

            LOVLookUpEdit.AppearanceDropDown.BackColor = GuiConfig.GridReadOnly;
            LOVLookUpEdit.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            LOVLookUpEdit.AppearanceDropDown.Options.UseBackColor = true;
            LOVLookUpEdit.AppearanceDropDown.Options.UseFont = true;

            LOVLookUpEdit.NullText = "";
            LOVLookUpEdit.ShowHeader = false;
            LOVLookUpEdit.ShowFooter = false;

            LOVLookUpEdit.DisplayMember = displayMember;
            LOVLookUpEdit.ValueMember = valueMember;
            LOVLookUpEdit.DropDownRows = qry == null ? 7 : Math.Min(qry.Count, 7);
            LOVLookUpEdit.DataSource = qry;

            return LOVLookUpEdit;
        }

        /// <summary>
        /// Recursive loop used to get all child-controls of parent-control
        /// </summary>
        /// <param name="arr">The arraylist to add controls to</param>
        /// <param name="ParentControl">The control to get child-controls from</param>
        /// <param name="allControls">Add Child of KissComplexControl to</param>
        private static void AddControls(ArrayList arr, Control ParentControl, bool allControls)
        {
            foreach (Control ctl in ParentControl.Controls)
            {
                arr.Add(ctl);
                if (allControls || !(ctl is KissComplexControl))
                    AddControls(arr, ctl, allControls);
            }
        }

        /// <summary>
        /// Finds the files matching the given pattern(s). Leave filePattern
        /// empty to list all files.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="filePattern">The file pattern.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="fileList">The file list.</param>
        private static void FindFiles(DirectoryInfo directory, String filePattern, Boolean recursive, List<FileInfo> fileList)
        {
            // handle file pattern
            if (!String.IsNullOrEmpty(filePattern))
            {
                // file pattern is defined, try to split if multiple patterns are given
                String[] filePatterns = filePattern.Split(';');

                // loop foreach single search pattern
                foreach (String searchPattern in filePatterns)
                {
                    // add all files in current directory using current search pattern
                    foreach (FileInfo fileInfo in directory.GetFiles(searchPattern.Trim()))
                    {
                        // add file matching current search pattern
                        fileList.Add(fileInfo);
                    }
                }
            }
            else
            {
                // no search pattern, add all files in current directory
                fileList.AddRange(directory.GetFiles());
            }

            // check if we have a recursive call and have to handle subfolders, too
            if (recursive)
            {
                // add all subfolders using recursive call
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    // add all files to filelist
                    UtilsGui.FindFiles(subDirectory, filePattern, recursive, fileList);
                }
            }
        }
    }
}