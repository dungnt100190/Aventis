using System.IO;
using System.Runtime.Serialization;

namespace Kiss.Utilities
{

    /// <summary>
    /// Creates deep copies of objects.
    /// </summary>
    public static class ObjectCloner
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Perform a deep copy of the object. 
        /// Link: http://stackoverflow.com/questions/78536/cloning-objects-in-c
        /// Since our entities are not attributed with [Serializable],
        /// we use DataContractSerializer (like in WCF).
        /// options:
        /// - BinaryFormatter: objects have to be marked as serialized
        /// - DataContractSerializer: object have to marked as [DataContract], Members as [DataMember]
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            var memoryStream = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(memoryStream, source);
            memoryStream.Seek(0, SeekOrigin.Begin);


            var target = (T)serializer.ReadObject(memoryStream);
            return target;
        }

        #endregion

        #endregion
    }
}