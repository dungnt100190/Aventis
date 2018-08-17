using System.Collections.Generic;

using Kiss.Infrastructure;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public abstract class StringSearchBoxVM
    {
        public virtual SearchForStringEventHandler SearchEventHandler
        {
            get { return Search; }
        }

        public abstract IList<object> Search(string searchString, object searchParam);
    }
}