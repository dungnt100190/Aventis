using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Kiss.Model;

namespace Kiss.UI.ViewModel
{
    public class EntityWrapperList<TEntity> : ObservableCollection<EntityWrapper<TEntity>>
    {
        /// <summary>
        /// Erstellen einer neuen Entität mit einer bool spalte z.B. für Selektion
        /// </summary>
        /// <param name="list">Liste der Entität</param>
        /// <param name="defaultSelection">Defaultwert der Selektion</param>
        public EntityWrapperList(IEnumerable<TEntity> list, bool defaultSelection)
        {
            foreach(TEntity entity in list)
            {
                EntityWrapper<TEntity> item = new EntityWrapper<TEntity>(entity);
                item.Selected = defaultSelection;
                base.Add(item);
            }
        }
    }
}
