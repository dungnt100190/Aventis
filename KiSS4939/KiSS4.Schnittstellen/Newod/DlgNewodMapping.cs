using Kiss.Infrastructure;

namespace KiSS4.Schnittstellen.Newod
{
    public class DlgNewodMapping : KiSS4.Gui.KissDialog
    {
        private CtlKiSSNewodMappingWeb ctlKiSSNewodMappingWeb1;

        public DlgNewodMapping(string baPersonID)
        {
            ctlKiSSNewodMappingWeb1 = new CtlKiSSNewodMappingWeb(baPersonID);
            this.Controls.Add(ctlKiSSNewodMappingWeb1);
            this.Shown += new System.EventHandler(DlgNewodMapping_Shown);
            this.Text = "Person mit NEWOD verknüpfen";
        }

        private void DlgNewodMapping_Shown(object sender, System.EventArgs e)
        {
            /// TODO: Zuerst Maske öffnen, dann lookup
            ApplicationFacade.DoEvents();
            ctlKiSSNewodMappingWeb1.LookupKiSSPersons();
        }
    }
}