using System.Windows.Forms;

namespace Kiss.Interfaces.UI
{
    public interface IKissView
    {
        /// <summary>
        /// Returns the actual control as a System.Windows.Forms.Control
        /// In case of a WPF-View this will return an ElementHost-Instance holding the WPF-View
        /// </summary>
        Control Control { get; }

        /// <summary>
        /// Sets or gets the Views's Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Sets or Get the ParentControl.
        /// </summary>
        Control ParentControl { get; set; }

        /// <summary>
        /// Returns the ParentForm to which this Control is assigned (E.g. if this is a ContainerControl)
        /// This is only used for UtilsGui.EnablCloseForm / UtilsGui.DisableCloseForm
        /// </summary>
        Form ParentForm { get; }

        /// <summary>
        /// Sets or gets if this View is visible or not
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Executes Tasks before the view can be closed
        /// </summary>
        /// <returns><c>true</c> if the View can be closed</returns>
        bool BeforeCloseView();

        /// <summary>
        /// Disposes the View and all it's dependend resources
        /// </summary>
        void Dispose();

        /// <summary>
        /// Sets the Focus to this View
        /// </summary>
        bool Focus();

        /// <summary>
        /// Hides the View.
        /// The View has the option to cancel this operation e.g. because some validation failed
        /// </summary>
        /// <returns>false if the view does not allow hiding the view in it's current state, e.g. because some validation failed</returns>
        bool HideView();

        /// <summary>
        /// Activates and shows the view
        /// </summary>
        void ShowView();
    }
}