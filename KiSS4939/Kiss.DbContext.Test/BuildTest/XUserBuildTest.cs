namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="XUser"/> entity at build time.
    /// </summary>
    class XUserBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new XUser
            {
                XUser_Chief = new XUser(),
                XUser_IsChiefOf = new XUser[]{},
                XUser_PrimaryUser = new XUser(),
                XUser_IsPrimaryUserOf = new XUser[]{},
                XUser_Sachbearbeiter = new XUser(),
                XUser_IsSachbearbeiterOf = new XUser[]{},
                FaLeistung_Sachbearbeiter = new FaLeistung[]{},
                XOrgUnit_IsChiefOf = new XOrgUnit[]{},
                XOrgUnit_IsRechtsdienstOf = new XOrgUnit[]{},
                XOrgUnit_IsRepresentativeOf = new XOrgUnit[]{},
                FaDokumente_IsAbsenderOf = new FaDokumente[]{},
                FaDokumente_IsEkVisumOf = new FaDokumente[]{},
                FaDokumente_IsVisiertDurchOf = new FaDokumente[]{},
                FaDokumente_IsVisumBeantragtBeiOf = new FaDokumente[]{},
                FaDokumente_IsVisumBeantragtDurchOf = new FaDokumente[]{},
                FaWeisung_IsCreatorOf = new FaWeisung[]{},
                FaWeisung_IsVerantwortlichRdOf = new FaWeisung[]{},
                FaWeisung_IsVerantwortlichSarOf = new FaWeisung[]{},
                XTask_IsBearbeitungOf = new XTask[]{},
                XTask_IsErledigtOf = new XTask[]{},
                FaFall = new FaFall[]{}
            };
        }
    }
}
