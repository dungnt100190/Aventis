using System.Collections.Generic;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Interfaces
{
    public interface IServiceCRUD<T, in TKey> where T : class, new()
    {
        string ConfirmDeleteQuestion();

        IServiceResult DeleteEntity(TKey id);

        IServiceResult DeleteEntity(T entity);

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="id">Die ID des Datensatzes, normalerweise ein int</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        T GetEntityById(TKey id);

        IServiceResult SaveEntities(IEnumerable<T> dataToSave);

        IServiceResult SaveEntity(T dataToSave);

        IServiceResult SaveEntity(T dataToSave, Dictionary<string, QuestionAnswerOption> questionsAndAnswers);

        IServiceResult ValidateUnChangedEntities(T entityToSave);

    }
}