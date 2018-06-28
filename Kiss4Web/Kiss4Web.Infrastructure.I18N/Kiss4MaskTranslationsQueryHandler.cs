using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.I18N.RequestLanguage;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.I18N
{
    public class Kiss4MaskTranslationsQueryHandler : TypedMessageHandler<Kiss4MaskTranslationsQuery, IEnumerable<ControlTranslation>>
    {
        private readonly SqlConnection _dbConnection;
        private readonly ILanguageResolver _languageResolver;

        public Kiss4MaskTranslationsQueryHandler(SqlConnection dbConnection, ILanguageResolver languageResolver)
        {
            _dbConnection = dbConnection;
            _languageResolver = languageResolver;
        }

        public override Task<IEnumerable<ControlTranslation>> Handle(Kiss4MaskTranslationsQuery query)
        {
            return _dbConnection.QueryAsync<ControlTranslation>(@"
SELECT ControlName, Text
FROM
(
  SELECT ControlName = CTL.ControlName,
         Text = ISNULL(TXT.Text, TXT_D.Text)
  FROM dbo.XClassControl     CTL   WITH(READUNCOMMITTED)
    LEFT  JOIN dbo.XLangText TXT   WITH(READUNCOMMITTED) ON TXT.TID = CTL.ControlTID
                                                        AND TXT.LanguageCode = @LanguageCode
    INNER JOIN dbo.XLangText TXT_D WITH(READUNCOMMITTED) ON TXT_D.TID = CTL.ControlTID
                                                        AND TXT_D.LanguageCode = 1
  WHERE ClassName = @ClassName

  UNION ALL

  SELECT ControlName = CMP.ComponentName,
         Text = ISNULL(TXT.Text, TXT_D.Text)
  FROM dbo.XClassComponent   CMP   WITH(READUNCOMMITTED)
    LEFT  JOIN dbo.XLangText TXT   WITH(READUNCOMMITTED) ON TXT.TID = CMP.ComponentTID
                                                        AND TXT.LanguageCode = @LanguageCode
    INNER JOIN dbo.XLangText TXT_D WITH(READUNCOMMITTED) ON TXT_D.TID = CMP.ComponentTID
                                                        AND TXT_D.LanguageCode = 1
  WHERE ClassName = @ClassName

  UNION ALL

  SELECT ControlName = CLA.ClassName,
         Text = ISNULL(TXT.Text, TXT_D.Text)
  FROM dbo.XClass            CLA   WITH(READUNCOMMITTED)
    LEFT  JOIN dbo.XLangText TXT   WITH(READUNCOMMITTED) ON TXT.TID = CLA.ClassTID
                                                        AND TXT.LanguageCode = @LanguageCode
    INNER JOIN dbo.XLangText TXT_D WITH(READUNCOMMITTED) ON TXT_D.TID = CLA.ClassTID
                                                        AND TXT_D.LanguageCode = 1
WHERE ClassName = @ClassName
) TMP
WHERE Text NOT IN('[leer]', '[vide]')", new { ClassName = query.MaskName, LanguageCode = query.Language ?? _languageResolver.GetRequestLanguageKiss4Code() });
        }
    }
}