using Xceed.Words.NET;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class Kiss4BookmarkReplacerDocX
    {
        public DocX ReplaceBookmarks(DocX document)
        {
            foreach (var bookmark in document.Bookmarks)
            {
                if (bookmark.Name == "_GoBack")
                {
                    continue;
                }

                bookmark.SetText("blabla");
            }
            return document;
        }
    }
}