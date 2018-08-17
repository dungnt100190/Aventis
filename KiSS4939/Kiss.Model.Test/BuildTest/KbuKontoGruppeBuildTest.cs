namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="KbuKontoGruppe"/> entity at build time.
    /// </summary>
    class KbuKontoGruppeBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new KbuKontoGruppe();
            entity.KbuKontoGruppe_Parent = new KbuKontoGruppe();
            entity.KbuKontoGruppe_IsParentOf = new TrackableCollection<KbuKontoGruppe>();
        }
    }
}
