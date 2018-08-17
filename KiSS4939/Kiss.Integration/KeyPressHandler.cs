using System.Windows.Forms;

using KiSS4.Gui;

namespace Kiss.Integration
{
    public class KeyPressHandler
    {
        private readonly Belegleser _belegleser;

        public KeyPressHandler(Control activeControl)
        {
            _belegleser = new Belegleser(activeControl);
        }

        public void OnKeyDown(Control activeControl, Control parent, KeyEventArgs e)
        {
            KeyDownHandler.OnKeyDown(activeControl, parent, e);

            if (_belegleser != null)
            {
                _belegleser.OnKeyDown(activeControl, e);
            }
        }

        public void OnKeyPress(Control activeControl, KeyPressEventArgs e)
        {
            if (_belegleser != null)
            {
                _belegleser.OnKeyPress(activeControl, e);
            }
        }
    }
}