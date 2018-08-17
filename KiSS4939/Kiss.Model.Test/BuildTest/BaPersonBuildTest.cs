namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="BaPerson"/> entity at build time.
    /// </summary>
    class BaPersonBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new BaPerson();
            entity.FaLeistung = new TrackableCollection<FaLeistung>();
            entity.FaLeistung_Schuldner = new TrackableCollection<FaLeistung>();
            entity.FaDokumente_IsAdressatOf = new TrackableCollection<FaDokumente>();
            entity.FaDokumente_IsLtOf = new TrackableCollection<FaDokumente>();
        }
    }
}