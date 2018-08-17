using System;
using System.Windows;
using System.Windows.Controls;

namespace Kiss.UI.Controls
{
    public class KissComplexControl : Control
    {
        /// <summary>
        /// Allow a subclass to perform some operations prior to the execution of the SaveCommand
        /// </summary>
        public virtual void EndCurrentEdit()
        {
        }

        protected T EnforceInstance<T>(string partName)
            where T : FrameworkElement
        {
            T element = GetTemplateChild(partName) as T;

            if (element == null)
            {
                throw new InvalidOperationException(
                    string.Format("Invalid template: the part {0} of type {1} could not be found.", partName, typeof(T)));
            }

            return element;
        }
    }
}