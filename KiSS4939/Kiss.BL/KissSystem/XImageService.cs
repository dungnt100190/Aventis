using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using log4net;

namespace Kiss.BL.KissSystem
{
    public class XImageService : ServiceBase
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly IDictionary<string, ImageSource> _images = new Dictionary<string, ImageSource>();

        #endregion

        #endregion

        #region Constructors

        protected XImageService()
        {
            SetUpImages();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void AddImage(string name, string localPath)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Images";

            // wenn direkt auf die harddisk zugegrifffen werden soll
            var uri = new Uri(path + @"\" + localPath, UriKind.Absolute);

            try
            {
                ImageSource source = BitmapFrame.Create(uri);
                _images.Add(name, source);
            }
            catch (Exception)
            {
                _logger.ErrorFormat("Fehler beim Laden des Bildes. {0} ({1})", name, path);
                throw;
            }
        }

        public ImageSource GetEmptyImage()
        {
            return GetImage("Empty");
        }

        public ImageSource GetHatBemerkungImage()
        {
            return GetImage("HatBemerkung");
        }

        public ImageSource GetImage(string name)
        {
            if (_images != null && _images.ContainsKey(name))
            {
                return _images[name];
            }

            _logger.WarnFormat("Bild {0} nicht gefunden.", name);
            return null;
        }

        #endregion

        #region Private Methods

        private void SetUpImages()
        {
            // System images
            AddImage("HatBemerkung", "Kiss_System_HatBemerkung.png");
            AddImage("Empty", "Kiss_System_Empty.png");
        }

        #endregion

        #endregion
    }
}