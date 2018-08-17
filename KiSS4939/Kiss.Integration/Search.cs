using System;
using System.Collections.Generic;
using System.Linq;

using KiSS4.DB;

namespace Kiss.Integration
{
    public class Search
    {
        public IEnumerable<SearchMatch> SearchPerson(string searchString)
        {
            // Prevent injections
            searchString = searchString.Replace("'", "''").ToLower();

            // Wildcards durch SQL-gültige Wildcards ersetzen
            searchString = searchString.Replace("*", "%");
            searchString = searchString.Replace("?", "_");

            var splitted = searchString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //var trimmed = searchString.Replace(" ", string.Empty);

            const string singleSearchSql = @"
                  SELECT ResultDescription, ResultInfo1, ResultInfo2, ResultInfo3, ReferenceID
                  FROM SysGlobalSearchResult
                  WHERE SearchExpression LIKE N'{0}%'";

            var sql = string.Join(string.Format("{0}{0}INTERSECT{0}{0}", Environment.NewLine), splitted.Select(str => string.Format(singleSearchSql, str)));
            sql = string.Format(@"--SQLCHECK_IGNORE--
                                  SELECT TOP 31 ResultDescription, ResultInfo1, ResultInfo2, ResultInfo3, ReferenceID
                                  FROM ({0}) TMP", sql);
            var query = DBUtil.OpenSQL(sql);

            return query.DataTable.Select().Select(row => new SearchMatch
                                                              {
                                                                  ResultDescription = (string)row["ResultDescription"],
                                                                  ResultInfo1 = row["ResultInfo1"] as string,
                                                                  ResultInfo2 = row["ResultInfo2"] as string,
                                                                  ResultInfo3 = row["ResultInfo3"] as string,
                                                                  ReferenceID = (int)row["ReferenceID"]
                                                              }).ToArray();
        }
    }
}