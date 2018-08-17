using System;
using System.ComponentModel;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissComplexControl.
    /// </summary>
    public class KissComplexControl : UserControl, IKissTranslation, IKissTranslatable
    {
        #region Fields

        #region Private Fields

        private KissTranslation _translation;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissComplexControl"/> class.
        /// </summary>
        public KissComplexControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.BackColor = GuiConfig.PanelColor;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the active SQL query.
        /// </summary>
        /// <value>The active SQL query.</value>
        [DefaultValue(null)]
        public virtual SqlQuery ActiveSQLQuery { get; set; }

        /// <summary>
        /// Gets a value that indicates whether the System.ComponentModel.Component is currently in design mode.
        /// </summary>
        /// <Returns>
        /// true if the System.ComponentModel.Component is in design mode; otherwise, false.
        /// </Returns>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DesignerMode
        {
            get { return base.DesignMode; }
        }

        /// <summary>
        /// Gets the translation.
        /// </summary>
        /// <value>The translation.</value>
        [Browsable(false)]
        public KissTranslation Translation
        {
            get
            {
                if (_translation == null && !(this is KissContainerControl || DesignMode || Session.User == null))
                {
                    _translation = new KissTranslation(this);
                }

                return _translation;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the kiss main form.
        /// </summary>
        /// <returns></returns>
        public KissMainForm GetKissMainForm()
        {
            return KissForm.GetKissMainForm();
        }

        /// <summary>
        /// Translates this instance.
        /// </summary>
        public virtual void Translate()
        {
            if (Translation != null)
            {
                Translation.Translate(Session.User.LanguageCode);
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets the parent control.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        protected ContainerControl GetParentControl(Type type)
        {
            return GetParentControl(this, type);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                this.BackColor = GuiConfig.PanelColor;
            }
            base.OnLoad(e);
            Translate();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Gets the parent control.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static ContainerControl GetParentControl(Control child, Type type)
        {
            if (type.IsAssignableFrom(child.GetType()))
                return (ContainerControl)child;

            if (child.Parent != null)
                return GetParentControl(child.Parent, type);

            return null;
        }

        #endregion

        #endregion
    }
}