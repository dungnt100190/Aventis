using System.ComponentModel;
using System.Runtime.Serialization;
using Kiss.Infrastructure;

namespace Kiss.DbContext
{
    public interface IPocoEntity : INotifyPropertyChanged//, IAutoIdentityEntity<int> //ToDo, wenn alle Tabellen int-PK haben
    {
    }

    [DataContract(IsReference = true)]
    public abstract class PocoEntity : IPocoEntity
    {
        //public abstract int AutoIdentityID { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private NotifyPropertyChanged _notifyPropertyChanged;

        private NotifyPropertyChanged NotifyPropertyChanged
        {
            get
            {
                return _notifyPropertyChanged ?? (_notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged));
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
        }

        // not needed anymore because fields an not properties are being serialized
        //protected bool IsDeserializing { get; private set; }

        //[OnDeserializing]
        //public void OnDeserializingMethod(StreamingContext context)
        //{
        //    IsDeserializing = true;
        //}

        //[OnDeserialized]
        //public void OnDeserializedMethod(StreamingContext context)
        //{
        //    IsDeserializing = false;
        //}


    }
}
