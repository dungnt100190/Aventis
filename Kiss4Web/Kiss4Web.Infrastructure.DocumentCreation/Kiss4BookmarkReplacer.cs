using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class Kiss4BookmarkReplacer
    {
        private readonly Kiss4BookmarkDataProvider _bookmarkDataProvider;

        public Kiss4BookmarkReplacer(Kiss4BookmarkDataProvider bookmarkDataProvider)
        {
            _bookmarkDataProvider = bookmarkDataProvider;
        }

        public async Task<WordprocessingDocument> ReplaceBookmarks(WordprocessingDocument document,
                                                                   IEnumerable<ContextValue> contextValues)
        {
            var bookmarks = document
                            .MainDocumentPart
                            .RootElement
                            .Descendants<BookmarkStart>()
                            .Where(bmk => bmk.Name != "_GoBack" // marks the position of the cursor when the document was closed
                                       && !bmk.Name.Value.StartsWith("NOKISS"))
                            .Select(bmk => new BookmarkMetadata
                            {
                                Name = bmk.Name,
                                BookmarkDefinitionName = RedactBookmarkName(bmk.Name),
                                Start = bmk
                            })
                            .ToList();

            await _bookmarkDataProvider.GetData(bookmarks, contextValues);

            foreach (var bookmark in bookmarks)
            {
                //var bookmarkText = bookmarkStart.NextSibling<Run>();
                //if (bookmarkText != null)
                //{
                //    bookmarkText.GetFirstChild<Text>().Text = "blabla";
                //}

                var elem = bookmark.Start.NextSibling();

                // Remove everything between bookmark start and end
                while (elem != null && !(elem is BookmarkEnd))
                {
                    var nextElem = elem.NextSibling();
                    elem.Remove();
                    elem = nextElem;
                }

                // insert new content
                var rowCount = bookmark.Data?.Count();
                if (rowCount == null || rowCount == 0)
                {
                    bookmark.Start.Parent.InsertAfter(new Run(new Text()), bookmark.Start);
                }
                else if (rowCount == 1 && bookmark.ColumnCount == 1)
                {
                    var value = bookmark.Data.First()[0];
                    if (value is bool)
                    {
                        // ToDo: set checkbox value, see WordControl.SetCheckboxValue()
                    }
                    else if (bookmark.LovCode.HasValue)
                    {
                        // ToDo: set multiselection checkboxes, see WordControl.SetCheckboxValue()
                    }
                    else
                    {
                        // ToDo: WordDoc.ReplaceBookmarkByValue()
                        bookmark.Start.Parent.InsertAfter(new Run(new Text(value.ToString())), bookmark.Start);
                    }
                }
                else
                {
                    // fill tables
                    // ToDo, see WordDoc.ReplaceBookmarkByValues()
                }
            }

            return document;
        }

        private string RedactBookmarkName(string bookmarkName)
        {
            var position = bookmarkName.IndexOf("_", StringComparison.Ordinal);

            return position > 0
                ? bookmarkName.Substring(0, position)
                : bookmarkName;
        }
    }
}