using System;
using System.Collections;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for UtilShowDetail.
    /// </summary>
    public class UtilShowDetail : IDisposable
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _forceDispose;
        private IKissView detailControl;
        private Hashtable htDetailControl = new Hashtable();
        private Control panDetail;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create new instance of <see cref="UtilShowDetail" />
        /// </summary>
        /// <param name="target">Control to show <see cref="IKissView" /> into</param>
        public UtilShowDetail(Control target)
        {
            this.panDetail = target;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Dispose all <see cref="IKissView" />
        /// </summary>
        public void Dispose()
        {
            foreach (IKissView ctl in htDetailControl.Values)
                try { ctl.Dispose(); }
                catch { }
        }

        #endregion

        #region Events

        /// <summary>
        /// Current <see cref="IKissView" /> has been changed
        /// </summary>
        public event EventHandler DetailChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Current <see cref="IKissView" />
        /// </summary>
        public IKissView DetailControl
        {
            get { return this.detailControl; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Current <see cref="IKissView" />
        /// </summary>
        /// <returns><see cref="IKissView" /></returns>
        public IKissView GetDetailControl()
        {
            return detailControl;
        }

        /// <summary>
        /// Return <see cref="IKissView" /> of <paramref name="type"/>. Create new Instance if not in Cache.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="createInstance"></param>
        /// <returns><see cref="IKissView" /></returns>
        public IKissView GetDetailControl(Type type, bool createInstance)
        {
            if (type == null)
            {
                return null;
            }

            IKissView ctl = htDetailControl[type] as IKissView;
            if (ctl == null && createInstance)
                ctl = (IKissView)type.GetConstructor(new Type[] { }).Invoke(new object[] { });    // Use default c'tor without parameters
            return ctl;
        }

        /// <summary>
        /// Return <see cref="IKissView" /> of <paramref name="type"/>. Only if existing in Cache.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IKissView GetDetailControl(Type type)
        {
            return GetDetailControl(type, false);
        }

        /// <summary>
        /// Show current <see cref="IKissView" />
        /// </summary>
        public void ShowDetail()
        {
            this.ShowDetail(this.detailControl);
        }

        /// <summary>
        /// Show <paramref name="newDetailControl"/>
        /// </summary>
        /// <param name="newDetailControl"></param>
        /// <param name="forceDispose">Dispose after unload</param>
        /// <returns>succeeded</returns>
        public bool ShowDetail(IKissView newDetailControl, bool forceDispose)
        {
            if (this.detailControl != newDetailControl)
            {
                if (this.ShowDetail(newDetailControl))
                {
                    if (!forceDispose && newDetailControl != null)
                    {
                        Type type = newDetailControl.GetType();

                        if (htDetailControl.Contains(type))
                            htDetailControl[type] = newDetailControl;
                        else
                            htDetailControl.Add(type, newDetailControl);
                    }
                    this._forceDispose = forceDispose;
                    return true;
                }
                else
                    return false;
            }
            else
                return this.ShowDetail(newDetailControl);
        }

        #endregion

        #region Private Methods

        private bool ShowDetail(IKissView newDetailControl)
        {
            IKissView oldDetail = null;
            bool sameUserControl = false;

            if (panDetail.Controls.Count > 0)
            {
                if (!(panDetail.Controls[0] is IKissView))
                {
                    // cannot show other than IKissView (TODO: true??)
                    throw new InvalidCastException("Invalid type of control to show, valid are only type of IKissView");
                }

                oldDetail = (IKissView)panDetail.Controls[0];

                sameUserControl = (oldDetail == newDetailControl);

                if (!sameUserControl)
                {
                    // Save Data
                    if (!oldDetail.BeforeCloseView() || !oldDetail.HideView())
                    {
                        // View does not allow hiding the view in it's current state, e.g. because some validation failed
                        return false;
                    }

                    // Remove old IKissView
                    try
                    {
                        panDetail.Controls.Clear();
                        oldDetail.ParentControl = null;
                    }
                    catch { }
                }
            }

            // Dispose old IKissView
            if (this.detailControl != null && this._forceDispose && this.detailControl != newDetailControl)
            {
                this._forceDispose = false;
                this.detailControl.Dispose();
            }

            this.detailControl = newDetailControl;

            // Display IKissView
            if (this.detailControl != null)
            {
                // init flag
                bool wasFormClosingDisabled = false;
                Form formClosingDisabled = null;        // #6463: Store the form which gets locked, as detailControl.ParentForm might might become null in case the user closes the form while it is created

                try
                {
                    if (!sameUserControl)
                    {
                        this.detailControl.Visible = false;
                    }

                    detailControl.ShowView();

                    // Append IKissView to the Panel
                    if (!sameUserControl)
                    {
                        // add control to panel
                        panDetail.Controls.Add(this.detailControl.Control);

                        // lock closing of parent form
                        if (detailControl.ParentForm != null)
                        {
                            formClosingDisabled = detailControl.ParentForm; // Store the form to unlock in the finally block
                            wasFormClosingDisabled = UtilsGui.DisableCloseForm(detailControl.ParentForm);
                        }

                        // setup control
                        this.detailControl.ParentControl = this.panDetail;

                        this.detailControl.Visible = true;
                    }

                    this.detailControl.Focus();
                }
                catch (Exception ex)
                {
                    // logging
                    logger.Warn("Error loading control.", ex);

                    // show message
                    KissMsg.ShowError("UtilShowDetail", "FehlerLaden_v01", "Es ist ein Fehler beim Laden der Maske aufgetreten.", ex);
                }
                finally
                {
                    // enable closing again
                    if (wasFormClosingDisabled && formClosingDisabled != null)
                    {
                        UtilsGui.EnableCloseFrom(formClosingDisabled, wasFormClosingDisabled);
                    }
                }

                if (DetailChanged != null)
                {
                    DetailChanged(this, EventArgs.Empty);
                }
            }

            return true;
        }

        #endregion

        #endregion
    }
}