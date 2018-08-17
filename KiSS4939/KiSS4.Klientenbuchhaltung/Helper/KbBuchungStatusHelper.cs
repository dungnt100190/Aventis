using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public class KbBuchungStatusHelper
    {
        public static void AddBuchungStatusToRepositoryItems(List<RepositoryItemImageComboBox> repositoryItems)
        {
            var qryStati = DBUtil.OpenSQL("SELECT * FROM XLOVCode WHERE LOVName = 'KbBuchungsStatus' ORDER BY SortKey");

            foreach (var repositoryItem in repositoryItems)
            {
                repositoryItem.SmallImages = KissImageList.SmallImageList;
                foreach (DataRow row in qryStati.DataTable.Rows)
                {
                    repositoryItem.Items.Add(
                        new ImageComboBoxItem(
                            row["Text"].ToString(),
                            (int)row["Code"],
                            KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
                }
            }
        }
    }
}