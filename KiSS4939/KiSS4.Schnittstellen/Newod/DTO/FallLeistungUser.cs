using System;
using System.Collections.Generic;
using System.Text;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    class FallLeistungUser
    {
        private int _userID;

        public FallLeistungUser(int userID)//, int? faLeistungID)
        {
            this.UserID = userID;
            //this.FaLeistungID = FaLeistungID;
        }

        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                this._userID = value;
            }
        }
        //public int? FaLeistungID { get;set;}
    }
}
