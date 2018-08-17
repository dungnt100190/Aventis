using System;
using System.Collections.Generic;

using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryKaSerienbrief : Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaSerienbrief()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKaSerienbrief_Load(object sender, EventArgs e)
        {
            var items = new Dictionary<int, string>
            {
                { 1, "aktiv" },
                { 2, "abgeschlossen" },
                { 3, "archiviert" }
            };
            edtStatus.ApplyCodeTextPairsAsPopupDataSource(items);

            edtLeistung.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = 0,
                       Text = '',
                       SortKey = '0'

                UNION ALL

                SELECT Code,
                       Text,
                       SortKey = CONVERT(VARCHAR, SortKey)
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'FaProzess'
                  AND Code BETWEEN 701 AND 799
                  AND Code != 704

                UNION ALL

                SELECT Code = 704,
                       Text = 'Jobtimum',
                       SortKey = '7040'

                UNION ALL

                SELECT Code = -704,
                       Text = 'EPQ',
                       SortKey = '7041'
                ORDER BY SortKey;"));
        }

        #endregion
    }
}