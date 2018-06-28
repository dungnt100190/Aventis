using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.I18N;
using Microsoft.Extensions.Logging;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class Kiss4BookmarkDataProvider
    {
        private readonly ContextValuesProvider _contextValuesProvider;
        private readonly RequestLanguageCode _languageCode;
        private readonly ILogger _logger;
        private readonly SqlConnection _sqlConnection;
        private readonly SqlParameterReplacer _sqlParameterReplacer;
        private readonly IKiss4TranslationProvider _translation;

        public Kiss4BookmarkDataProvider(SqlConnection sqlConnection,
                                         RequestLanguageCode languageCode,
                                         ILogger logger,
                                         IKiss4TranslationProvider translation,
                                         SqlParameterReplacer sqlParameterReplacer,
                                         ContextValuesProvider contextValuesProvider)
        {
            _sqlConnection = sqlConnection;
            _languageCode = languageCode;
            _logger = logger;
            _translation = translation;
            _sqlParameterReplacer = sqlParameterReplacer;
            _contextValuesProvider = contextValuesProvider;
        }

        public async Task GetData(IEnumerable<BookmarkMetadata> templateBookmarks,
                                  IEnumerable<ContextValue> contextValues)
        {
            var bookmarkDefinitions = (await _sqlConnection.QueryAsync<BookmarkDefinition>(@"
                SELECT BookmarkName = LEFT(BookmarkName, 40),
                       BookmarkCode,
                       SQL
                FROM dbo.XBookmark WITH(READUNCOMMITTED)
                WHERE BookmarkName IN @bookmarkNames AND
                      TableName IS NULL

                UNION ALL

                SELECT BookmarkName = LEFT(SBO.BookmarkName, 40),
                       SBO.BookmarkCode,
                       REPLACE(CONVERT(VARCHAR(8000), SBO.SQL), '<TableColumn>', SBO.ReplaceCode)
                FROM dbo.fnGetStandardBookmarks(@languageCode) SBO
                WHERE SBO.BookmarkName IN @bookmarkNames", new { bookmarkNames = templateBookmarks.Select(bmk => bmk.BookmarkDefinitionName), _languageCode.LanguageCode })).ToList();

            foreach (var templateBookmark in templateBookmarks)
            {
                var bookmarkDefinition = bookmarkDefinitions.FirstOrDefault(bmd => bmd.BookmarkName == templateBookmark.BookmarkDefinitionName);
                if (bookmarkDefinition == null)
                {
                    _logger.LogError(EventIds.BookmarkDefinitionNotFoundEventId, await _translation.GetText("WordDoc", "TextmarkeNichtGefunden"), templateBookmark.BookmarkDefinitionName);
                    templateBookmark.Data = null;
                    continue;
                }

                var replaceResult = _sqlParameterReplacer.ReformatParametersFromKissToDapper(bookmarkDefinition.Sql);
                var parameters = await _contextValuesProvider.GetParameters(replaceResult.parameterNames, contextValues, templateBookmark.Name);
                templateBookmark.Data = await _sqlConnection.QueryAsync(replaceResult.sql, parameters);
                templateBookmark.ColumnCount = CountProperties(templateBookmark.Data.FirstOrDefault());
                templateBookmark.Type = bookmarkDefinition.BookmarkCode;
                templateBookmark.LovCode = GetLovCode(templateBookmark.Name);
            }
        }

        private static int? CountProperties(dynamic row)
        {
            return row?.GetType()?.GetProperties()?.Count();
        }

        private static int? GetLovCode(string templateBookmarkName)
        {
            var index = templateBookmarkName.IndexOf("_C", StringComparison.InvariantCulture);
            return index >= 0 && int.TryParse(templateBookmarkName.Substring(index + 2), out var lovCode)
                ? (int?)lovCode
                : null;
        }
    }
}