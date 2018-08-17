using System;

using KiSS4.Common;

namespace KiSS4.Query
{
    public partial class CtlQueryAdmAngemeldeteBenutzer : KissQueryControl
    {
        #region Constructors

        public CtlQueryAdmAngemeldeteBenutzer()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            qrySperrUser.Fill(qryQuery["gesperrt durch"]);
            //qrySperrUser.Fill(64);
            //edtLockPid.LoadQuery(qrySperrUser);
            //edtLockUser.LoadQuery(qrySperrUser);
            //edtLockUserOe.LoadQuery(qrySperrUser);
            //edtLockUserTel.LoadQuery(qrySperrUser);
            //edtLockUserPc.LoadQuery(qrySperrUser);
        }

        #endregion
    }
}