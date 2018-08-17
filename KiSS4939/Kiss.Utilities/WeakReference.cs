namespace Kiss.Utilities
{
    using System;

    /// <summary>
    ///   WeakReference with typed target
    /// </summary>
    /// <typeparam name = "T">The type of the target</typeparam>
    public class WeakReference<T> : WeakReference
        where T : class
    {
        /// <summary>
        ///   Initializes a new instance of the WeakReference<T> class, referencing the specified object
        /// </summary>
        /// <param name = "target">The object to track or null</param>
        public WeakReference(T target)
            : base(target)
        {
        }

        /// <summary>
        ///   Gets or sets the object (the target) referenced by the current System.WeakReference object
        /// </summary>
        /// <returns>
        ///   null if the object referenced by the current System.WeakReference object 
        ///   has been garbage collected; otherwise, a reference to the object referenced by the 
        ///   current System.WeakReference object
        /// </returns>
        /// <exception cref = "System.InvalidOperationException">
        ///   The reference to the target object is invalid. This exception can be thrown while setting this 
        ///   property if the value is a null reference or if the object has been finalized during the set 
        ///   operation
        /// </exception>
        public new T Target
        {
            get
            {
                return base.Target as T;
            }
            set
            {
                base.Target = value;
            }
        }
    }
}