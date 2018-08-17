using KiSS4.DB;

namespace Kiss.Integration.DataAccess.Fallfuehrung
{
    public class FallfuehrungDA
    {
        public string GetCaseTitle(int baPersonId)
        {
            return DBUtil.ExecuteScalarSQL(@"
                            WITH PersonCTE AS (
                              SELECT
                                Name   = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
                                Age    = CONVERT(VARCHAR, dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE()))),
                                Gender = NULLIF(dbo.fnLOVShortText('Geschlecht', PRS.GeschlechtCode), '')
                              FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                              WHERE PRS.BaPersonID = {0}
                            )
                            SELECT
                              Name +
                                CASE
                                  WHEN Age IS NOT NULL OR Gender IS NOT NULL
                                    THEN ' (' + ISNULL(Gender + ', ', '') + ISNULL(Age, '') + ')'
                                  ELSE ''
                                END
                            FROM PersonCTE;", baPersonId) as string;
        }

        public BaPersonInfoDTO GetPersonInfoDTO(int baPersonId)
        {
            return BaPersonInfo.GetPersonInfoTitelQuery(baPersonId);
        }
    }
}