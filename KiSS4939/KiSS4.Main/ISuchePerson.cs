
namespace KiSS4.Main
{
    public interface ISuchePerson
    {
        int SelectedTabIndex { get;}
        int? GetPersonIDCreateIfNecessary(bool checkIfFallExist);
    }
}
