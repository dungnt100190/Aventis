using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

using DevExpress.Xpf.Themes.Kiss;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.UI;

using IWin32Window = System.Windows.Forms.IWin32Window;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// The WPF implementation of WinForms KissDialog and some parts of KissForm
    /// </summary>
    public class KissDialog : Window, IKissDataNavigator
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissDialog"/> class.
        /// </summary>
        public KissDialog()
        {
            KissTheme.Enable(this);
            Icon = Helper.IconHelper.IconImageSmall(Helper.IconHelper.Icons.App).Source;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a new data entity
        /// </summary>
        /// <returns><c>True</c> on success, otherwiese <c>False</c></returns>
        public bool AddData()
        {
            // default: true
            return !IsContentIKissDataNavigator() || ContentAsIKissDataNavigator().AddData();
        }

        /// <summary>
        /// Deletes the current selected data entity
        /// </summary>
        /// <returns><c>True</c> on success, otherwiese <c>False</c></returns>
        public bool DeleteData()
        {
            // default: true
            return !IsContentIKissDataNavigator() || ContentAsIKissDataNavigator().DeleteData();
        }

        public bool KeyDownKiss(System.Windows.Forms.KeyEventArgs keyEvent)
        {
            // default: false
            return IsContentIKissDataNavigator() && ContentAsIKissDataNavigator().KeyDownKiss(keyEvent);
        }

        public void MoveFirst()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().MoveFirst();
        }

        public void MoveLast()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().MoveLast();
        }

        public void MoveNext()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().MoveNext();
        }

        public void MovePrevious()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().MovePrevious();
        }

        public void RefreshData()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().RefreshData();
        }

        public bool RestoreData()
        {
            // default: false
            return IsContentIKissDataNavigator() && ContentAsIKissDataNavigator().RestoreData();
        }

        /// <summary>
        /// Saves the current selected data entity
        /// </summary>
        /// <returns><c>True</c> on success, otherwiese <c>False</c></returns>
        public bool SaveData()
        {
            // default: true
            return !IsContentIKissDataNavigator() || ContentAsIKissDataNavigator().SaveData();
        }

        public void Search()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().Search();
        }

        public void UndoDataChanges()
        {
            if (!IsContentIKissDataNavigator())
            {
                return;
            }

            ContentAsIKissDataNavigator().UndoDataChanges();
        }

        #endregion

        #region Protected Methods

        protected override void OnInitialized(EventArgs e)
        {
            if (Owner == null)
            {
                var mainForm = Container.TryResolve<IWin32Window>();
                if (mainForm != null)
                {
                    var helper = new WindowInteropHelper(this);
                    helper.Owner = mainForm.Handle;
                }
            }
            base.OnInitialized(e);
        }

        /// <summary>
        /// Handle the OnKeyDown events and link some logic for KiSS specific keys
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }

            // Restore logical deleted row. This is done by pressing Ctrl and F8.
            if (Helper.KeyboardUtil.IsAnyControlKeyPressed() && e.Key == Key.F8)
            {
                RestoreData();
                e.Handled = true;
            }

            #region Simulate Toolbar of KissMainForm --> see KissForm.cs:OnKeyDown(...)

            if (Helper.KeyboardUtil.IsAnyControlKeyPressed())
            {
                switch (e.Key)
                {
                    case Key.Home:
                        MoveFirst();
                        break;

                    case Key.Up:
                        MovePrevious();
                        break;

                    case Key.Down:
                        MoveNext();
                        break;

                    case Key.End:
                        MoveLast();
                        break;
                }
            }
            else if (!Helper.KeyboardUtil.IsModifierKeyPressed())
            {
                switch (e.Key)
                {
                    case Key.F5:
                        AddData();
                        break;

                    case Key.F2:
                        SaveData();
                        break;

                    case Key.F6:
                        UndoDataChanges();
                        break;

                    case Key.F8:
                        DeleteData();
                        break;

                    case Key.F7:
                        RefreshData();
                        break;

                    case Key.F3:
                        Search();
                        break;

                    /* TODO: handle Print()...
                    case Key.F9:
                        Print();
                        break;
                    */
                }
            }

            #endregion

            KeyDownKiss(Helper.UIUtilities.ConvertToFormsKeyEventArgs(e));

            base.OnKeyDown(e);
        }

        #endregion

        #region Private Methods

        private IKissDataNavigator ContentAsIKissDataNavigator()
        {
            return (IKissDataNavigator)Content;
        }

        private bool IsContentIKissDataNavigator()
        {
            return Content != null && (Content is IKissDataNavigator);
        }

        #endregion

        #endregion
    }
}