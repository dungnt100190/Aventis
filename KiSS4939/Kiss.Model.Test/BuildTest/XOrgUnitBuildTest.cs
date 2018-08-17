namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="XOrgUnit"/> entity at build time.
    /// </summary>
    class XOrgUnitBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new XOrgUnit();
            entity.XOrgUnit_IsParentOf = new TrackableCollection<XOrgUnit>();
            entity.XOrgUnit_Parent = new XOrgUnit();
            entity.XUser_Chief = new XUser();
            entity.XUser_Rechtsdienst = new XUser();
            entity.XUser_Representative = new XUser();
        }
    }
}
