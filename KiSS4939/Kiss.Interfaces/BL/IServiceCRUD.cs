using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kiss.Interfaces.BL
{
    public interface IServiceCRUD<T>
    {
        KissServiceResult DeleteData(IUnitOfWork unitOfWork, T dataToDelete, bool saveChanges = true);
        ObservableCollection<T> GetData(IUnitOfWork unitOfWork);
        KissServiceResult NewData(out T newData);
        KissServiceResult SaveData(IUnitOfWork unitOfWork, T dataToSave);
        KissServiceResult SaveData(IUnitOfWork unitOfWork, List<T> dataToSave);
        KissServiceResult SaveData(IUnitOfWork unitOfWork, T dataToSave, Dictionary<string, QuestionAnswerOption> questionsAndAnswers);
    }
}