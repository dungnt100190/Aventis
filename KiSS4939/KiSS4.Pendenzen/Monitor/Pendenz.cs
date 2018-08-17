using System;

namespace KiSS4.Pendenzen.Monitor
{
    public class Pendenz : IPendenz
    {
        private static Int32 numofInstances = 0;
        private Int32 id;
        private Int32 type;
        private Int32 state;
        private DateTime creationDate;
        private DateTime startDate;
        private DateTime expirationDate;
        private String subject;
        private String description;

        /// <summary>
        /// 
        /// </summary>
        public Pendenz()
        {
            id = numofInstances++;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { this.id = value; }
            get { return this.id; }
        }

        #region IPendenz Members

        /// <summary>
        /// TaskTypeCode
        /// </summary>
        public Int32 Type
        {
            set {this.type = value; }
            get {return this.type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 State
        {
            set { this.state = value; }
            get { return this.state; }
        }

        public DateTime CreationDate
        {
            set { this.creationDate = value; }
            get { return this.creationDate; }
        }

        public DateTime StartDate
        {
            set { this.startDate = value; }
            get { return this.startDate; }
        }

        public DateTime ExpirationDate
        {
            set { this.expirationDate = value; }
            get { return this.expirationDate; }
        }

        public String Subject
        {
            set { this.subject = value; }
            get { return this.subject; }
        }

        public String Description
        {
            set { this.description = value; }  
            get { return this.description; }
        }

        #endregion
    }
}
