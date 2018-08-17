using System;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kiss.UI.Controls.Helper
{
    public class IconHelper
    {
        #region Enumerations

        /// <summary>
        /// The available icons
        /// </summary>
        public enum Icons
        {
            /// <summary>
            /// An icon for KiSS application
            /// </summary>
            App,

            /// <summary>
            /// An icon for indicating the Word application
            /// </summary>
            Word,

            /// <summary>
            /// An icon for indicating the Excel application
            /// </summary>
            Excel,

            /// <summary>
            /// An icon for indicating any print action
            /// </summary>
            Print
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets an image of the desired icon (e.g. used to set to MenuItem as icon)
        /// </summary>
        /// <param name="icon">The desired icon to get as image</param>
        /// <param name="size">The size of the icon-frame to take if available and the size of the image to return</param>
        /// <returns>An image as bitmap of the desired icon</returns>
        public static System.Windows.Controls.Image IconImage(Icons icon, Size size)
        {
            var stream = GetResourceStream(icon);

            // this is mainly used to prevent error in designer
            if (stream == null)
            {
                return new System.Windows.Controls.Image
                {
                    Height = size.Height,
                    Width = size.Width
                };
            }
            return new System.Windows.Controls.Image
            {
                Source = GetBestBitmapFrame(stream, size),
                Height = size.Height,
                Width = size.Width,
                Stretch = Stretch.Uniform
            };
        }

        /// <summary>
        /// Gets an image of the desired icon in 32x32 pixels
        /// </summary>
        /// <param name="icon">The desired icon to get as image</param>
        /// <returns>An image as bitmap of the desired icon</returns>
        public static System.Windows.Controls.Image IconImageLarge(Icons icon)
        {
            return IconImage(icon, new Size(32, 32));
        }

        /// <summary>
        /// Gets an image of the desired icon in 16x16 pixels
        /// </summary>
        /// <param name="icon">The desired icon to get as image</param>
        /// <returns>An image as bitmap of the desired icon</returns>
        public static System.Windows.Controls.Image IconImageSmall(Icons icon)
        {
            return IconImage(icon, new Size(16, 16));
        }

        /// <summary>
        /// Gets the desired icon in 32x32 pixels
        /// </summary>
        /// <param name="icon">The desired icon to get</param>
        /// <returns>The desired icon or null</returns>
        public static Icon IconLarge(Icons icon)
        {
            return Icon(icon, new Size(32, 32));
        }

        /// <summary>
        /// Gets the desired icon in 16x16 pixels
        /// </summary>
        /// <param name="icon">The desired icon to get</param>
        /// <returns>The desired icon or null</returns>
        public static Icon IconSmall(Icons icon)
        {
            return Icon(icon, new Size(16, 16));
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Gets the full namespace path including the icon name as used e.g. for GetManifestResourceStream(...)
        /// </summary>
        /// <param name="icon">The icon of which to get the filename</param>
        /// <returns>The full namespace path and filename to the icon</returns>
        private static string FullIconNamespacePath(Icons icon)
        {
            return "Kiss.UI.Controls.Icons." + IconFile(icon);
        }

        private static Type GetAssemblyType()
        {
            return typeof(IconHelper);
        }

        private static BitmapFrame GetBestBitmapFrame(Stream stream, Size size)
        {
            var decoder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapFrame usingFrame = null;
            var biggestFrame = decoder.Frames[0];

            // take the best matching frame of the icon or the biggest (better for resize)
            foreach (var frame in decoder.Frames)
            {
                if (frame.Height == size.Height)
                {
                    usingFrame = frame;
                    break;
                }

                if (frame.Height > biggestFrame.Height)
                {
                    biggestFrame = frame;
                }
            }

            return usingFrame ?? biggestFrame;
        }

        private static Stream GetResourceStream(Icons icon)
        {
            return GetAssemblyType().Assembly.GetManifestResourceStream(FullIconNamespacePath(icon));
        }

        /// <summary>
        /// Gets an icon of the desired type (e.g. used to set to MenuItem as icon)
        /// </summary>
        /// <param name="icon">The desired icon to get</param>
        /// <param name="size">The size of the icon-frame to take if available and the size of the image to return</param>
        /// <returns>The desired icon or null</returns>
        private static Icon Icon(Icons icon, Size size)
        {
            var stream = GetResourceStream(icon);
            return stream == null ? null : new Icon(stream, size);
        }

        /// <summary>
        /// Gets the filename of the icon
        /// </summary>
        /// <param name="icon">The icon of which to get the filename</param>
        /// <returns>The filename of the icon</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if an iconfile is not handled properly</exception>
        private static string IconFile(Icons icon)
        {
            switch (icon)
            {
                case Icons.App:
                    return "App.ico";

                case Icons.Word:
                    return "Word.ico";

                case Icons.Excel:
                    return "Excel.ico";

                case Icons.Print:
                    return "Print.ico";

                default:
                    throw new ArgumentOutOfRangeException("The desired icon needs to be implemented first.");
            }
        }

        #endregion

        #endregion
    }
}