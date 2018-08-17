namespace Kiss.Model.Test.BuildTest
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
            var entity = new XUser();
            entity.XUser_Chief = new XUser();
            entity.XUser_IsChiefOf = new TrackableCollection<XUser>();
            entity.XUser_PrimaryUser = new XUser();
            entity.XUser_IsPrimaryUserOf = new TrackableCollection<XUser>();
            entity.XUser_Sachbearbeiter = new XUser();
            entity.XUser_IsSachbearbeiterOf = new TrackableCollection<XUser>();
            entity.FaLeistung_Sachbearbeiter = new TrackableCollection<FaLeistung>();
            entity.XOrgUnit_IsChiefOf = new TrackableCollection<XOrgUnit>();
            entity.XOrgUnit_IsRechtsdienstOf = new TrackableCollection<XOrgUnit>();
            entity.XOrgUnit_IsRepresentativeOf = new TrackableCollection<XOrgUnit>();
            entity.FaDokumente_IsAbsenderOf = new TrackableCollection<FaDokumente>();
            entity.FaDokumente_IsEkVisumOf = new TrackableCollection<FaDokumente>();
            entity.FaDokumente_IsVisiertDurchOf = new TrackableCollection<FaDokumente>();
            entity.FaDokumente_IsVisumBeantragtBeiOf = new TrackableCollection<FaDokumente>();
            entity.FaDokumente_IsVisumBeantragtDurchOf = new TrackableCollection<FaDokumente>();
            entity.FaWeisung_IsCreatorOf = new TrackableCollection<FaWeisung>();
            entity.FaWeisung_IsVerantwortlichRdOf = new TrackableCollection<FaWeisung>();
            entity.FaWeisung_IsVerantwortlichSarOf = new TrackableCollection<FaWeisung>();
            entity.XTask_IsBearbeitungOf = new TrackableCollection<XTask>();
            entity.XTask_IsErledigtOf = new TrackableCollection<XTask>();
        }
    }
}
