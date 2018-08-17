using System.Windows.Data;
using System.Windows.Markup;

using Kiss.UI.Controls.Converter;

namespace Kiss.UI.Controls.Bindings
{
    /// <summary>
    /// Spezielles Binding für Bool-Werte. Bsp:
    /// ..xmlns:Bindings="clr-namespace:Kiss.UI.Controls.Bindings;assembly=Kiss.UI.Controls"..
    /// &lt;DataGridColumn Binding="{Bindings:SwitchBinding ValueIfTrue=1, ValueIfFalse=0}" /&gt;
    /// </summary>
    public class SwitchBindingExtension : Binding
    {
        #region Constructors

        public SwitchBindingExtension()
        {
            Initialize();
        }

        public SwitchBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        public SwitchBindingExtension(string path, object valueIfTrue, object valueIfFalse)
            : base(path)
        {
            Initialize();
            ValueIfTrue = valueIfTrue;
            ValueIfFalse = valueIfFalse;
        }

        #endregion

        #region Properties

        [ConstructorArgument("valueIfFalse")]
        public object ValueIfFalse
        {
            get;
            set;
        }

        [ConstructorArgument("valueIfTrue")]
        public object ValueIfTrue
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void Initialize()
        {
            ValueIfTrue = DoNothing;
            ValueIfFalse = DoNothing;
            Converter = new SwitchConverter(this);
        }

        #endregion

        #endregion
    }
}