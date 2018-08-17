using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissImageList.
    /// </summary>
    public class KissImageList
    {
        #region Enumerations

        /// <summary>
        /// Define different types of images
        /// </summary>
        public enum ImageType
        {
            /// <summary>
            /// Icon image
            /// </summary>
            Icon,

            /// <summary>
            /// Bitmap image
            /// </summary>
            Bitmap,

            /// <summary>
            /// JPG image
            /// </summary>
            Jpg,

            /// <summary>
            /// GIF image
            /// </summary>
            Gif,

            /// <summary>
            /// PNG image
            /// </summary>
            Png,

            /// <summary>
            /// TIF image
            /// </summary>
            Tif,

            /// <summary>
            /// Other type (unknown)
            /// </summary>
            Unknown
        }

        #endregion

        #region Fields

        #region Internal Static Fields

        internal static SqlQuery qryXIcon;

        #endregion

        #region Private Static Fields

        private static System.Windows.Forms.ImageList imageListLarge;
        private static System.Windows.Forms.ImageList imageListMedium;
        private static System.Windows.Forms.ImageList imageListSmall;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Get imagelist with large icons 32x32 containing icons and empty icons as used in column XIconID.
        /// </summary>
        public static System.Windows.Forms.ImageList LargeImageList
        {
            get
            {
                if (imageListLarge == null)
                {
                    LoadImages();
                }

                return imageListLarge;
            }
        }

        /// <summary>
        /// Get imagelist with large icons 24x24 containing icons and empty icons as used in column XIconID.
        /// </summary>
        public static System.Windows.Forms.ImageList MediumImageList
        {
            get
            {
                if (imageListMedium == null)
                {
                    LoadImages();
                }

                return imageListMedium;
            }
        }

        /// <summary>
        /// Get imagelist with small icons 16x16 containing icons and empty icons as used in column XIconID.
        /// </summary>
        public static System.Windows.Forms.ImageList SmallImageList
        {
            get
            {
                if (imageListSmall == null)
                {
                    LoadImages();
                }

                return imageListSmall;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get the image index..
        /// </summary>
        /// <param name="xIconID">The x icon ID.</param>
        /// <returns></returns>
        [Obsolete("Use GetImageIndex(int xIconID)")]
        public static int ConvertXIconID(int xIconID)
        {
            return GetImageIndex(xIconID);
        }

        /// <summary>
        /// Converts the name of the icon.
        /// </summary>
        /// <param name="xIconName">Name of the x icon.</param>
        /// <returns></returns>
        [Obsolete("Use GetImageIndex(string xIconName)")]
        public static int ConvertXIconName(string xIconName)
        {
            return GetImageIndex(xIconName);
        }

        /// <summary>
        /// Fills all icons defined in the table XIcon into a KissImageComboBoxEdit
        /// Item.Description is the name of the icon (XIcon.Name)
        /// Item.Value is the id of the icon (XIcon.XIconID)
        /// </summary>
        /// <param name="edtCombo">KissImageComboBoxEdit to clear and fill with icons</param>
        public static void FillIconsIntoComboBox(KiSS4.Gui.KissImageComboBoxEdit edtCombo)
        {
            FillIconsIntoComboBox(edtCombo, true);
        }

        /// <summary>
        /// Fills all icons defined in the table XIcon into a KissImageComboBoxEdit
        /// Also applies small images to combobox.
        /// Item.Description is the name of the icon (XIcon.Name)
        /// Item.Value is the id of the icon (XIcon.XIconID)
        /// </summary>
        /// <param name="edtCombo">KissImageComboBoxEdit to fill with icons</param>
        /// <param name="clearFirst">Clear KissImageComboBoxEdit first, before adding new items</param>
        public static void FillIconsIntoComboBox(KiSS4.Gui.KissImageComboBoxEdit edtCombo, bool clearFirst)
        {
            // validate
            if (edtCombo == null)
            {
                throw new ArgumentNullException("edtCombo");
            }

            // check if need to clear first
            if (clearFirst)
            {
                edtCombo.Properties.Items.Clear();
            }

            // apply small images
            edtCombo.Properties.SmallImages = KissImageList.SmallImageList;

            // loop icons and apply to repository item
            foreach (DataRow row in qryXIcon.DataTable.Rows)
            {
                // create new item
                DevExpress.XtraEditors.Controls.ImageComboBoxItem item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();

                // setup item
                item.ImageIndex = Convert.ToInt32(row["ImageIndex"]);
                item.Description = string.Format("{0}: {1}", row["XIconID"], row["Name"]);
                item.Value = Convert.ToInt32(row["XIconID"]);

                // add item
                edtCombo.Properties.Items.Add(item);
            }
        }

        /// <summary>
        /// Fill repositoryitem image combobox with KiSS image items with proper imageindex, description and value.
        /// Also applies small images to repositoryitem.
        /// Item.Description is the name of the icon (XIcon.Name)
        /// Item.Value is the id of the icon (XIcon.XIconID)
        /// </summary>
        /// <param name="repCombo">The repository item to fill</param>
        /// <param name="clearFirst"><c>True</c> if image combobox has to be cleared before filling with entries</param>
        public static void FillIconsIntoComboBox(DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repCombo, bool clearFirst)
        {
            // call main method with default settings
            FillIconsIntoComboBox(repCombo, clearFirst, true);
        }

        /// <summary>
        /// Fill repositoryitem image combobox with KiSS image items with proper imageindex, description and value.
        /// Also applies small images to repositoryitem.
        /// Item.Description is the name of the icon (XIcon.Name)
        /// Item.Value is the id of the icon (XIcon.XIconID)
        /// </summary>
        /// <param name="repCombo">The repository item to fill</param>
        /// <param name="clearFirst"><c>True</c> if image combobox has to be cleared before filling with entries</param>
        /// <param name="setDescription"><c>True</c> if description has to be appended, otherwise description is empty</param>
        public static void FillIconsIntoComboBox(DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repCombo, bool clearFirst, bool setDescription)
        {
            // validate
            if (repCombo == null)
            {
                throw new ArgumentNullException("repCombo");
            }

            // check if need to clear first
            if (clearFirst)
            {
                repCombo.Items.Clear();
            }

            // apply small images
            repCombo.SmallImages = KissImageList.SmallImageList;

            // loop icons and apply to repository item
            foreach (DataRow row in qryXIcon.DataTable.Rows)
            {
                // create new item
                DevExpress.XtraEditors.Controls.ImageComboBoxItem item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();

                // setup item
                item.ImageIndex = Convert.ToInt32(row["ImageIndex"]);
                item.Value = Convert.ToInt32(row["XIconID"]);

                // check if needed to append description
                if (setDescription)
                {
                    item.Description = string.Format("{0}: {1}", row["XIconID"], row["Name"]);
                }

                // add item
                repCombo.Items.Add(item);
            }
        }

        /// <summary>
        /// Convert XIconID to id used in imagelist containing no empty icons
        /// </summary>
        /// <param name="xIconID">Current icon-index used column XIconID</param>
        /// <returns>Imagelist imageListSmallOnlyIcons index</returns>
        public static int GetImageIndex(int xIconID)
        {
            if (xIconID == -1 || qryXIcon == null)
            {
                return xIconID;
            }

            DataRow[] rows = qryXIcon.DataTable.Select(string.Format("XIconID = {0}", xIconID));

            if (rows.Length == 1)
            {
                return Convert.ToInt32(rows[0]["ImageIndex"]);
            }

            return 0;
        }

        /// <summary>
        /// Convert Name to id used in imagelist containing no empty icons
        /// </summary>
        /// <param name="xIconName">Current icon-name used column XIcon.Name</param>
        /// <returns>Imagelist imageListSmallOnlyIcons index</returns>
        public static int GetImageIndex(string xIconName)
        {
            if (DBUtil.IsEmpty(xIconName) || qryXIcon == null)
            {
                return 0;
            }

            DataRow[] rows = qryXIcon.DataTable.Select(string.Format("Name = '{0}'", xIconName));

            if (rows.Length == 1)
            {
                return Convert.ToInt32(rows[0]["ImageIndex"]);
            }

            return 0;
        }

        /// <summary>
        /// Get image type depending on given file header
        /// </summary>
        /// <param name="header">The header to parse (required at least 4 Bytes!)</param>
        /// <returns>The image type depending on the values given within the header</returns>
        public static ImageType GetImageType(byte[] header)
        {
            // validate first
            if (header == null || header.Length < 4)
            {
                // invalid header, do not continue
                return ImageType.Unknown;
            }

            // LINK: http://www.techpathways.com/uploads/headersig.txt

            // ICO: check if header contains Icon-Bytes (Hex: "00 00 01 00"; Dec: "00 00 01 00")
            if (header[0] == 0 && header[1] == 0 && header[2] == 1 && header[3] == 0)
            {
                // header belongs to an icon image
                return ImageType.Icon;
            }

            // BMP: check if header contains Bitmap-Bytes (Hex: "42 4D"; Dec: "66 77")
            if (header[0] == 66 && header[1] == 77)
            {
                // header belongs to a bitmap image
                return ImageType.Bitmap;
            }

            // JPG: check if header contains JPG-Bytes (Hex: "FF D8"; Dec: "255 216")
            if (header[0] == 255 && header[1] == 216)
            {
                // header belongs to a jpg image
                return ImageType.Jpg;
            }

            // GIF: check if header contains GIF-Bytes (Hex: "47 49 46"; Dec: "71 73 70")
            if (header[0] == 71 && header[1] == 73 && header[2] == 70)
            {
                // header belongs to a gif image
                return ImageType.Gif;
            }

            // PNG: check if header contains PNG-Bytes (Hex: "50 4E 47"; Dec: "137 80 78")
            if (header[0] == 137 && header[1] == 80 && header[2] == 78)
            {
                // header belongs to a png image
                return ImageType.Png;
            }

            // TIF: check if header contains TIF-Bytes (Hex: "49 49 2A" (intel) or "4D 4D 2A" (motorola); Dec: "73 73 42" or "77 77 42")
            if ((header[0] == 73 && header[1] == 73 && header[2] == 42) ||
                (header[0] == 77 && header[1] == 77 && header[2] == 42))
            {
                // header belongs to a tif image
                return ImageType.Tif;
            }

            // unknown type
            return ImageType.Unknown;
        }

        /// <summary>
        /// Get image type depending on header within memory stream
        /// </summary>
        /// <param name="ms">The memory stream to use to get type</param>
        /// <returns>The image type depending on the header of the given memory stream</returns>
        public static ImageType GetImageTypeFromMemoryStream(MemoryStream ms)
        {
            // validate
            if (ms == null)
            {
                return ImageType.Unknown;
            }

            // try to get type of image
            try
            {
                // define header from memory stream
                Byte[] header = new Byte[4];

                // get header from memory stream
                ms.Read(header, 0, 4);

                // reset position within memory stream
                ms.Position = 0;

                // get image type from header
                return GetImageType(header);
            }
            catch
            {
                // error getting header information
                return ImageType.Unknown;
            }
        }

        /// <summary>
        /// Return large icon 32x32
        /// </summary>
        /// <param name="XIconID">XIconID of Image</param>
        /// <returns>Image</returns>
        public static Image GetLargeImage(int XIconID)
        {
            return KissImageList.LargeImageList.Images[KissImageList.GetImageIndex(XIconID)];
        }

        /// <summary>
        /// Return large icon 32x32
        /// </summary>
        /// <param name="xIconName">Name of Image</param>
        /// <returns>Image</returns>
        public static Image GetLargeImage(string xIconName)
        {
            return KissImageList.LargeImageList.Images[KissImageList.GetImageIndex(xIconName)];
        }

        /// <summary>
        /// Return large icon 24x24
        /// </summary>
        /// <param name="XIconID">XIconID of Image</param>
        /// <returns>Image</returns>
        public static Image GetMediumImage(int XIconID)
        {
            return KissImageList.MediumImageList.Images[KissImageList.GetImageIndex(XIconID)];
        }

        /// <summary>
        /// Return large icon 24x24
        /// </summary>
        /// <param name="xIconName">Name of Image</param>
        /// <returns>Image</returns>
        public static Image GetMediumImage(string xIconName)
        {
            return KissImageList.MediumImageList.Images[KissImageList.GetImageIndex(xIconName)];
        }

        /// <summary>
        /// Return small icon 16x16
        /// </summary>
        /// <param name="XIconID">XIconID of Image</param>
        /// <returns>Image</returns>
        public static Image GetSmallImage(int XIconID)
        {
            return KissImageList.SmallImageList.Images[KissImageList.GetImageIndex(XIconID)];
        }

        /// <summary>
        /// Return small icon 16x16
        /// </summary>
        /// <param name="xIconName">Name of Image</param>
        /// <returns>Image</returns>
        public static Image GetSmallImage(string xIconName)
        {
            return KissImageList.SmallImageList.Images[KissImageList.GetImageIndex(xIconName)];
        }

        /// <summary>
        /// Get the XIconID of the icon
        /// </summary>
        /// <param name="imageIndex">Current Index Position in Imagelist</param>
        /// <returns>The name of the icon defined in database or null if nothing was found</returns>
        public static int GetXIconID(int imageIndex)
        {
            if (imageIndex == -1 || qryXIcon == null)
            {
                return imageIndex;
            }

            DataRow[] rows = qryXIcon.DataTable.Select(string.Format("ImageIndex = {0}", imageIndex));

            if (rows.Length == 1)
            {
                return Convert.ToInt32(rows[0]["XIconID"]);
            }

            return 0;
        }

        /// <summary>
        /// Get the name of the icon defined in XIcon.Name
        /// </summary>
        /// <param name="xIconID">Current icon-index used column XIconID</param>
        /// <returns>The name of the icon defined in database or null if nothing was found</returns>
        public static string GetXIconName(int xIconID)
        {
            if (xIconID == -1 || qryXIcon == null)
            {
                return null;
            }

            DataRow[] rows = qryXIcon.DataTable.Select(string.Format("XIconID = {0}", xIconID));

            if (rows.Length == 1)
            {
                return rows[0]["Name"] as string;
            }

            return null;
        }

        /// <summary>
        /// Fill iconlists with icons from database
        /// </summary>
        public static void LoadImages()
        {
            LoadImages(false);
        }

        /// <summary>
        /// Resize bitmap to specified width and height
        /// </summary>
        /// <param name="bmp">Bitmap to resize</param>
        /// <param name="width">New icon width</param>
        /// <param name="height">New icon height</param>
        /// <returns>Resized icon as Bitmap</returns>
        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            if (bmp.Width == width && bmp.Height == height)
            {
                return bmp;
            }

            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        /// <summary>
        /// Resize icon to specified width and height
        /// </summary>
        /// <param name="ico">Icon to resize</param>
        /// <param name="width">New icon width</param>
        /// <param name="height">New icon height</param>
        /// <returns>Resized icon as Bitmap</returns>
        public static Bitmap ResizeIcon(Icon ico, int width, int height)
        {
            return ResizeBitmap(new Icon(ico, width, height).ToBitmap(), width, height);
        }

        /// <summary>
        /// Save content of imagelists to resources
        /// </summary>
        /// <param name="fileName">Resourcefile to write</param>
        public static void SaveResources(string fileName)
        {
            LoadImages(true);

            System.Resources.ResXResourceWriter resxWriter = new System.Resources.ResXResourceWriter(fileName);

            using (MemoryStream stream = new MemoryStream())
            {
                qryXIcon.DataSet.WriteXml(stream, XmlWriteMode.WriteSchema);
                resxWriter.AddResource("qryXIcon.DataSet", Encoding.UTF8.GetString(stream.ToArray(), 0, (int)stream.Length));
            }

            resxWriter.AddResource("imageListSmall.ImageStream", imageListSmall.ImageStream);
            resxWriter.AddResource("imageListMedium.ImageStream", imageListMedium.ImageStream);
            resxWriter.AddResource("imageListLarge.ImageStream", imageListLarge.ImageStream);

            resxWriter.Generate();
            resxWriter.Close();

            LoadImages();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Add a specific image to the image list
        /// </summary>
        /// <param name="list">The instance of the list to add image into</param>
        /// <param name="ico">The icon image</param>
        /// <param name="bmp">The bitmap image</param>
        /// <param name="blankImg">The blank image</param>
        /// <param name="size">The desired size as defined for image list</param>
        /// <param name="sizeMode">The size name of the image list</param>
        /// <param name="xIconID">The id of the icon within the database</param>
        private static void LoadImage(ImageList list, Icon ico, Bitmap bmp, Image blankImg, int size, string sizeMode, int xIconID)
        {
            try
            {
                if (ico != null)
                {
                    list.Images.Add(ResizeIcon(ico, size, size));
                }
                else
                {
                    list.Images.Add(ResizeBitmap(bmp, size, size));
                }
            }
            catch (Exception ex)
            {
                // add a blank image for failure due to internal id
                list.Images.Add(blankImg);
                Trace.Write(string.Format("{0} XIconID='{1}', error='{2}'", sizeMode, xIconID, ex));
            }
        }

        /// <summary>
        /// Fill iconlists with icons from database
        /// </summary>
        /// <param name="systemOnly">Load only system icons</param>
        private static void LoadImages(bool systemOnly)
        {
            // init imagelists
            imageListSmall = new System.Windows.Forms.ImageList();
            imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            imageListSmall.TransparentColor = System.Drawing.Color.Transparent;

            imageListMedium = new System.Windows.Forms.ImageList();
            imageListMedium.ImageSize = new System.Drawing.Size(24, 24);
            imageListMedium.TransparentColor = System.Drawing.Color.Transparent;

            imageListLarge = new System.Windows.Forms.ImageList();
            imageListLarge.ImageSize = new System.Drawing.Size(32, 32);
            imageListLarge.TransparentColor = System.Drawing.Color.Transparent;

            if (!DB.Session.Active && !systemOnly)
            {
                System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KissImageList));

                DataSet ds = new DataSet();

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(resources.GetString("qryXIcon.DataSet"))))
                {
                    ds.ReadXml(stream);
                }

                qryXIcon = new SqlQuery();
                qryXIcon.DataTable.Merge(ds.Tables[0]);

                imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
                imageListMedium.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMedium.ImageStream")));
                imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            }
            else
            {
                lock (DB.Session.Connection)
                {
                    qryXIcon = systemOnly ?
                        DBUtil.OpenSQL("SELECT XIconID, Name, Icon FROM XIcon WHERE Icon IS NOT NULL AND XIconID BETWEEN 0 AND 999 ORDER BY 1") :
                        DBUtil.OpenSQL("SELECT XIconID, Name, Icon FROM XIcon WHERE Icon IS NOT NULL AND XIconID >= 0              ORDER BY 1");

                    qryXIcon.DataTable.PrimaryKey = new DataColumn[] { qryXIcon.DataTable.Columns["XIconID"] };
                    qryXIcon.DataTable.Columns.Add("ImageIndex", typeof(int));

                    System.Drawing.Image blankImageSmall = new System.Drawing.Bitmap(16, 16);
                    System.Drawing.Image blankImageMedium = new System.Drawing.Bitmap(24, 24);
                    System.Drawing.Image blankImageLarge = new System.Drawing.Bitmap(32, 32);

                    imageListSmall.Images.Add(blankImageSmall);
                    imageListMedium.Images.Add(blankImageMedium);
                    imageListLarge.Images.Add(blankImageLarge);

                    // define other vars
                    Icon ico = null;
                    Bitmap bmp = null;

                    // loop rows of images found on database
                    foreach (DataRow row in qryXIcon.DataTable.Rows)
                    {
                        if (systemOnly)
                        {
                            while (imageListSmall.Images.Count < Convert.ToInt32(row["XIconID"]))
                            {
                                imageListSmall.Images.Add(blankImageSmall);
                            }

                            if (Convert.ToInt32(row["XIconID"]) < 100)
                            {
                                while (imageListMedium.Images.Count < Convert.ToInt32(row["XIconID"]))
                                {
                                    imageListMedium.Images.Add(blankImageMedium);
                                }

                                while (imageListLarge.Images.Count < Convert.ToInt32(row["XIconID"]))
                                {
                                    imageListLarge.Images.Add(blankImageLarge);
                                }
                            }
                        }

                        try
                        {
                            // get memory stream
                            using (MemoryStream ms = new System.IO.MemoryStream((byte[])row["Icon"], false))
                            {
                                // reset vars
                                ico = null;
                                bmp = null;

                                // try to get icon or image depending on type
                                try
                                {
                                    // depending on image type
                                    switch (GetImageTypeFromMemoryStream(ms))
                                    {
                                        case ImageType.Icon:
                                            // icon style
                                            ico = new Icon(ms);
                                            break;

                                        case ImageType.Bitmap:
                                        case ImageType.Jpg:
                                        case ImageType.Gif:
                                        case ImageType.Png:
                                        case ImageType.Tif:
                                            // bitmap style
                                            bmp = new System.Drawing.Bitmap(ms);
                                            break;

                                        default:
                                            // try with icon or when failed, load bitmap
                                            ico = new Icon(ms);
                                            break;
                                    }
                                }
                                catch
                                {
                                    // reset position
                                    ms.Position = 0;

                                    // failed, try to get bitmap from memory stream
                                    bmp = new System.Drawing.Bitmap(ms);
                                }

                                // set current image index within data row
                                row["ImageIndex"] = imageListSmall.Images.Count;

                                // try to load small image
                                LoadImage(imageListSmall, ico, bmp, blankImageSmall, 16, "small", Convert.ToInt32(row["XIconID"]));

                                // try to load medium image
                                LoadImage(imageListMedium, ico, bmp, blankImageMedium, 24, "medium", Convert.ToInt32(row["XIconID"]));

                                // try to load large image
                                LoadImage(imageListLarge, ico, bmp, blankImageLarge, 32, "large", Convert.ToInt32(row["XIconID"]));
                            }
                        }
                        catch (Exception ex)
                        {
                            Trace.Write(string.Format("MemoryStream Icon: {0}, {1}", row["XIconID"], ex));
                        }

                    }
                }

                qryXIcon.DataTable.Columns.Remove("Icon");
            }
        }

        #endregion

        #endregion
    }
}