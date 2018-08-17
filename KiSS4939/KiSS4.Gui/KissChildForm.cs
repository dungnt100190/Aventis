using System.Collections.Specialized;
using Kiss.Interfaces.UI;

namespace KiSS4.Gui
{
    /// <summary>
    /// Base class for any child for in KiSS4.
    /// </summary>
    public class KissChildForm : KissForm, IViewMessaging
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KissChildForm"/> class.
        /// </summary>
        public KissChildForm()
        {
            InitializeComponent();

            new Belegleser(this);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KissChildForm));
            //
            // KissChildForm
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = GuiConfig.PanelColor;
            this.ClientSize = new System.Drawing.Size(563, 455);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "KissChildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

        #endregion

        #region IViewMessaging Members

        public virtual bool ReceiveMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "JumpToPath":
                    if (DetailControl != null)
                        return FormController.SendMessage(DetailControl, parameters);
                    else if (ActiveSQLQuery != null && parameters.Contains("ActiveSQLQuery.Find"))
                        return ActiveSQLQuery.Count > 0 && ActiveSQLQuery.Find((string)parameters["ActiveSQLQuery.Find"]);
                    return true;

                default:
                    return false;
            }
        }

        public virtual object ReturnMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "GetJumpToPath":
                    HybridDictionary dic = null;

                    if (DetailControl != null)
                        dic = FormController.GetMessage(DetailControl, parameters) as HybridDictionary;
                    else if (ActiveSQLQuery != null)
                    {
                        dic = new HybridDictionary();

                        string searchExpression = ActiveSQLQuery.GetSearchExpression();
                        if (searchExpression != null)
                            dic["ActiveSQLQuery.Find"] = searchExpression;
                    }

                    if (dic == null) dic = new HybridDictionary();
                    dic["ClassName"] = this.GetType().Name;
                    return dic;

                default:
                    return null;
            }
        }

        #endregion
    }
}