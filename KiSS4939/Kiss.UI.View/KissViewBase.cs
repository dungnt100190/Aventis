sing System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kiss.UI.Interfaces;
using Kiss.UI.ViewModel;

namespace Kiss.UI.View
{
    public partial class KissViewBase<T> : UserControl, IKissView, IKissDataNavigator
        where T : KissViewModelBase
    {
        public T ViewModel { get; set; }

        public KissViewBase()
        {
            InitializeComponent();
        }

        #region IKissView

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Control
        {
            get { return this; }
        }

        public bool HideView()
        {
            return true;
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control ParentControl
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value;
            }
        }

        public void ShowView()
        {
    
        }

        public bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            return true;
        }

        public object ReturnMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            return null;
        }

        #endregion

        #region IKissDataNavigator
        public virtual bool AddData()
        {
            if (ViewModel != null) return ViewModel.AddData();

            return false;
        }

        public virtual bool DeleteData()
        {
            if (ViewModel != null) return ViewModel.DeleteData();

            return false;
        }

        public virtual bool SaveData()
        {
            if (ViewModel != null) return ViewModel.SaveData();

            return false;
        }

        public virtual void Search()
        {
            if (ViewModel != null) ViewModel.Search();
        }

        public virtual void UndoDataChanges()
        {
            if (ViewModel != null) ViewModel.UndoDataChanges();
        }

        public virtual void MoveFirst()
        {
            // TODO
        }

        public virtual void MoveLast()
        {
            // TODO
        }

        public virtual void MoveNext()
        {
            // TODO
        }

        public virtual void MovePrevious()
        {
            // TODO
        }

        public virtual void RefreshData()
        {
            // TODO
        }

        public virtual bool RestoreData()
        {
            // TODO
            return false;
        }

        #endregion
    }
}
