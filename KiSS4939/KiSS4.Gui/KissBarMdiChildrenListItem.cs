using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using DevExpress.Utils.Serializing;
using DevExpress.XtraBars;

namespace KiSS4.Gui
{
    /// <summary>
    /// Class, used for special handling mdi children switching
    /// </summary>
    /// <remarks>Code taken from source [Developer Express .NET 2005 v6.2\Sources\DevExpress.XtraBars\DevExpress.XtraBars\Items\BarSubItem.cs]</remarks>
    public class KissBarMdiChildrenListItem : DevExpress.XtraBars.BarMdiChildrenListItem
    {
        #region Properties

        /// <summary>
        /// Set and get item index (special handling to prevent flickering in mdi when setting new index)
        /// </summary>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int ItemIndex
        {
            get
            {
                // let base do stuff
                return base.ItemIndex;
            }
            set
            {
                // init flag
                bool onlyBaseHandling = false;

                if (value < 0)
                {
                    value = -1;
                }

                if (ItemIndex == value || Form == null || MdiChildren == null || MdiChildren.Length <= value)
                {
                    // let only base handle
                    onlyBaseHandling = true;
                }

                if (!onlyBaseHandling && value != -1)
                {
                    // get form to activate
                    Form frm = MdiChildren[value];

                    // check if form to activate is KissForm
                    if (frm != null && frm is KissForm)
                    {
                        ((KissForm)frm).Activate();
                    }
                }

                // let base do stuff
                base.ItemIndex = value;
            }
        }

        private Form[] MdiChildren
        {
            get
            {
                Form[] mdiChildren = Form == null ? null : Form.MdiChildren;

                if (mdiChildren == null)
                {
                    return null;
                }

                if (Form == null || Form.MdiChildren == null)
                {
                    return null;
                }

                ArrayList list = new ArrayList();

                for (int n = 0; n < mdiChildren.Length; n++)
                {
                    Form frm = mdiChildren[n];

                    if (frm.Visible)
                    {
                        list.Add(frm);
                    }
                }

                if (list.Count == mdiChildren.Length)
                {
                    return mdiChildren;
                }

                return list.ToArray(typeof(Form)) as Form[];
            }
        }

        #endregion
    }
}