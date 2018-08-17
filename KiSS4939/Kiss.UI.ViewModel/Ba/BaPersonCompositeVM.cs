namespace Kiss.UI.ViewModel.Ba
{
    public class BaPersonCompositeVM : ViewModelBase
    {
        public BaPersonVM BaPersonVM { get; private set; }
        public BaAdresseVM BaAdresseVM { get; private set; }
        public SearchBaPersonVM SearchBaPersonVM { get; private set; }

        public BaPersonCompositeVM(int personId)
        {
            // Erstelle das ViewModel der Person
            BaPersonVM = new BaPersonVM(personId);
       
            // Erstelle das ViewModel der Adressen und initalisiere das Adress-ViewModel mit allen Adressen der geladenen Person
            BaAdresseVM = new BaAdresseVM(BaPersonVM.Entity.BaAdresse);

            // Erstelle das ViewModel der Adressen und initalisiere das Adress-ViewModel mit allen Adressen der geladenen Person
            SearchBaPersonVM = new SearchBaPersonVM();
        }
    }
}
