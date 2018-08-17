using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraNavBar;

namespace KiSS4.Common
{
    /// <summary>
    /// Single item in navigation list
    /// </summary>
    public class KissNavBarItem : DevExpress.XtraNavBar.NavBarItem
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly object[] parameters = null;
        private readonly System.Type type = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create new instance of class
        /// </summary>
        /// <param name="caption">The caption of the item</param>
        /// <param name="imageIndex">The image index of the icon to display</param>
        /// <param name="typeName">The type of the control to load</param>
        /// <param name="parameters">Additional parameters used for call of control</param>
        public KissNavBarItem(string caption, int imageIndex, string typeName, object[] parameters)
            : this(caption, imageIndex, AssemblyLoader.GetType(typeName), parameters)
        {
        }

        /// <summary>
        /// Constructor, used to create new instance of class
        /// </summary>
        /// <param name="caption">The caption of the item</param>
        /// <param name="imageIndex">The image index of the icon to display</param>
        /// <param name="type">The type of the control to load</param>
        /// <param name="parameters">Additional parameters used for call of control</param>
        public KissNavBarItem(string caption, int imageIndex, Type type, object[] parameters)
            : base(caption)
        {
            base.SmallImageIndex = imageIndex;

            this.type = type;
            this.parameters = parameters;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the type of the control to load with item
        /// </summary>
        public Type Type
        {
            get { return this.type; }
        }

        public int? XClassID { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Create new instance of control that is assigned with item
        /// </summary>
        /// <returns>The created <see cref="KissUserControl"/> instance</returns>
        public KissUserControl CreateInstance()
        {
            try
            {
                // check if we have a type
                if (type == null)
                {
                    throw new KissErrorException("Type is empty, cannot create an instance without a given type. Please check if the dynamic created link has a valid class defined.");
                }

                Type[] types = new Type[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    types[i] = parameters[i].GetType();
                }

                System.Reflection.ConstructorInfo constructorInfo = type.GetConstructor(types);

                if (constructorInfo == null)
                {
                    throw new KissErrorException("Could not get constructor information from given types, cannot proceed loading control.");
                }

                object control = constructorInfo.Invoke(parameters);

                // validate
                if (control is KissUserControl)
                {
                    return (KissUserControl)control;
                }
                else
                {
                    throw new KissErrorException(string.Format("The desired control to load has an invalid type ('{0}'). Can only show controls of type KissUserControl.", control.GetType().FullName));
                }
            }
            catch (Exception ex)
            {
                // init exception
                Exception showException = ex;

                // check if we have an inner exception
                if (ex.InnerException != null)
                {
                    // show inner exception as it contains more information than surrounding exception
                    showException = ex.InnerException;
                }

                // show message
                KissMsg.ShowError("KissNavBarForm", "ErrorLoadingControl_v01", "Es ist ein Fehler beim Laden des gewünschten Steuerelements aufgetreten.", showException);

                // cannot return instance
                return null;
            }
        }

        /// <summary>
        /// Get the medium image of current small image (size 24x24 pixels)
        /// </summary>
        public Image GetMediumImage()
        {
            // convert image-index to iconID and return large image for current iconID
            return KissImageList.GetMediumImage(KissImageList.GetXIconID(base.SmallImageIndex));
        }

        #endregion

        #endregion
    }
}