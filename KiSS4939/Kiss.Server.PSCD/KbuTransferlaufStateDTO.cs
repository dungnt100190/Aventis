using System;
using System.Runtime.Serialization;

using Kiss.Interfaces.BL;

namespace Kiss.Server.PSCD
{
    [DataContract]
    public class KbuTransferlaufStateDTO
    {
        #region Properties

        [DataMember]
        public int BelegCountFehlerhaft
        {
            get;
            set;
        }

        [DataMember]
        public int BelegCountTotal
        {
            get;
            set;
        }

        [DataMember]
        public int BelegCountTransferiert
        {
            get;
            set;
        }

        [DataMember]
        public DateTime CurrentTime
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? DoneTime
        {
            get;
            set;
        }

        [DataMember]
        public int KbuTransferlaufID
        {
            get;
            set;
        }

        [DataMember]
        public int KbuTransferlaufStatusCode
        {
            get;
            set;
        }

        [DataMember]
        public int PercentProgress
        {
            get;
            set;
        }

        [DataMember]
        public KissServiceResult Result
        {
            get;
            set;
        }

        [DataMember]
        public DateTime StartTime
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Internal Methods

        internal KbuTransferlaufStateDTO Clone()
        {
            return new KbuTransferlaufStateDTO
            {
                KbuTransferlaufID = KbuTransferlaufID,
                BelegCountTotal = BelegCountTotal,
                BelegCountTransferiert = BelegCountTransferiert,
                BelegCountFehlerhaft = BelegCountFehlerhaft,
                PercentProgress = PercentProgress,
                StartTime = StartTime,
                CurrentTime = CurrentTime,
                DoneTime = DoneTime,
                KbuTransferlaufStatusCode = KbuTransferlaufStatusCode,
                Result = Result
            };
        }

        #endregion

        #endregion
    }
}