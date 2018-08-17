using System.Linq;

using KiSS4.DB;
using KiSS4.Main;

namespace Kiss.Integration
{
    public class SearchKiss4
    {
        public SearchMatchKiss4[] Search(string searchString)
        {
            var query = DBUtil.OpenSQL(KissSearchDialog.GetSearchQuery(searchString, 30));

            return query.DataTable.Select().Select(row => new SearchMatchKiss4
            {
                BaPersonID = row[KissSearchDialog.COLUMN_PERSON_ID] as int?,
                Beschreibung = row[KissSearchDialog.COLUMN_DESCRIPTION] as string,
                FaFallID = row[KissSearchDialog.COLUMN_FALL_ID] as int?,
                FaLeistungID = row[KissSearchDialog.COLUMN_LEISTUNG_ID] as int?,
                ID = (int)row[KissSearchDialog.COLUMN_ID],
                JumpToPath = row[KissSearchDialog.COLUMN_JUMP_TO_PATH] as string,
                ParmDictionary = KissSearchDialog.GetJumpToPathDictionary(row, true),
                ModulID = row[KissSearchDialog.COLUMN_MODUL_ID] as int?,
                Typ = (int)row[KissSearchDialog.COLUMN_TYP],
            }).ToArray();
        }
    }
}