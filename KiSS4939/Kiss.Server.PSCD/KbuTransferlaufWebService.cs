using Kiss.BL;
using Kiss.Interfaces.BL;

namespace Kiss.Server.PSCD
{
    public class KbuTransferlaufWebService : IKbuTransferlaufWebService
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Bricht einen Transferlauf ab
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="authenticatedUser"></param>
        /// <param name="kbuTransferlaufID"></param>
        /// <returns></returns>
        public KissServiceResult CancelTransferlauf(string dbName, SerializableUser authenticatedUser, int kbuTransferlaufID)
        {
            return TransferlaufRunner.CancelTransferlauf(dbName, authenticatedUser, kbuTransferlaufID);
        }

        /// <summary>
        /// Gibt den Status des aktuell laufenden bzw. des zuletzt gelaufenen Transferlaufs zurück
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="authenticatedUser"></param>
        /// <returns></returns>
        public KbuTransferlaufStateDTO GetTransferlaufProgress(string dbName, SerializableUser authenticatedUser)
        {
            return TransferlaufRunner.GetTransferlaufProgress(dbName, authenticatedUser);
        }

        /// <summary>
        /// Startet einen Transferlauf
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="authenticatedUser"></param>
        /// <param name="kbuTransferlaufID"></param>
        /// <returns></returns>
        public KissServiceResult StartTransferlauf(string dbName, SerializableUser authenticatedUser, int kbuTransferlaufID)
        {
            return TransferlaufRunner.StartTransferlauf(dbName, authenticatedUser, kbuTransferlaufID);
        }

        #endregion

        private static KbuTransferlaufRunner TransferlaufRunner
        {
            get 
            {
                return KbuTransferlaufRunner.Instance;
                // no singleton behaviour: Container.Resolve<KbuTransferlaufRunner>();
            }
        }

        #endregion
    }
}