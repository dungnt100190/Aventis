using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using Kiss.BusinessLogic.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using IUnitOfWork = Kiss.DataAccess.Interfaces.IUnitOfWork;

namespace Kiss.BusinessLogic
{
    public class ServiceCRUD<T> : Service, IServiceCRUD<T, int>
        where T : class, IAutoIdentityEntity<int>, new()
    {
        #region Methods

        #region Public Static Methods

        public static object CopyEntity(object source)
        {
            var type = source.GetType();
            var properties = type.GetProperties();

            var target = type.InvokeMember("", BindingFlags.CreateInstance, null, source, null);

            foreach (var propertyInfo in properties.Where(pi => pi.CanWrite))
            {
                propertyInfo.SetValue(target, propertyInfo.GetValue(source, null), null);
            }

            return target;
        }

        #endregion

        #region Public Methods

        public string ConfirmDeleteQuestion()
        {
            return Properties.Resources.QuestionBeforeDelete;
        }

        /// <summary>
        /// Löscht eine Entität
        /// </summary>
        /// <param name="id">ID der zu löschenden Entität</param>
        /// <returns>Fehler-/Erfolgsmeldung</returns>
        public virtual IServiceResult DeleteEntity(int id)
        {
            try
            {
                using (var unitOfWork = CreateNewUnitOfWork())
                {
                    var repository = unitOfWork.Repository<T>();
                    var entityToDelete = repository.GetById(id);
                    var result = RemoveEntity(unitOfWork, entityToDelete);
                    unitOfWork.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        /// <summary>
        /// Löscht eine Entität
        /// </summary>
        /// <param name="entity">Zu löschende Entität</param>
        /// <returns>Fehler-/Erfolgsmeldung</returns>
        public IServiceResult DeleteEntity(T entity)
        {
            return DeleteEntity(entity.AutoIdentityID);
        }

        /// <summary>
        /// Lädt alle Entitäten
        /// </summary>
        /// <returns>Liste</returns>
        public IEnumerable<T> GetAllEntities()
        {
            using (var uow = CreateNewUnitOfWork())
            {
                return uow.Repository<T>().GetAllEntities().ToArray();
            }
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="id">Die ID des Datensatzes, normalerweise ein int</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public T GetEntityById(int id)
        {
            using (var uow = CreateNewUnitOfWork())
            {
                return uow.Repository<T>().GetById(id);
            }
        }

        public void RefreshTree(bool doRefresh = true)
        {
            if (!doRefresh)
            {
                return;
            }

            var formController = Container.Resolve<IKissFormController>();
            formController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        /// <summary>
        /// Speichert Entitäten auf der DB
        /// </summary>
        /// <param name="entitiesToSave"></param>
        /// <returns></returns>
        public virtual IServiceResult SaveEntities(IEnumerable<T> entitiesToSave)
        {
            using (var unitOfWork = CreateNewUnitOfWork())
            {
                var result = InsertOrUpdateEntities(unitOfWork, entitiesToSave);
                if (result.IsOk())
                {
                    try
                    {
                        unitOfWork.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result = new ServiceResult(ex); // ToDo: Message
                    }
                }
                return result;
            }
        }

        public virtual IServiceResult SaveEntity(T entityToSave)
        {
            return SaveEntity(entityToSave, null);
        }

        public virtual IServiceResult SaveEntity(T entityToSave, Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            using (var unitOfWork = CreateNewUnitOfWork())
            {
                return UnitOfWorkInsertOrUpdateEntitiesAndInvokeAction( 
                        unitOfWork, 
                        entityToSave, 
                        unitOfWork.SaveChanges);
            }
        }

        public virtual IServiceResult ValidateUnChangedEntities(T entityToCheck)
        {
            using (var unitOfWork = CreateNewUnitOfWork())
            {
                return UnitOfWorkInsertOrUpdateEntitiesAndInvokeAction(  
                                            unitOfWork, 
                                            entityToCheck, 
                                            unitOfWork.ValidateUnChangedEntities);
            }
        }

        private IServiceResult UnitOfWorkInsertOrUpdateEntitiesAndInvokeAction(IUnitOfWork unitOfWork, T entity, Action unitofWorkaction)
        {
            var result = InsertOrUpdateEntity(unitOfWork, entity);
            if (result == true)
            {
                try
                {
                    unitofWorkaction.Invoke();
                }
                catch (DbEntityValidationException ex) // ToDo: auslagern, damit dieser Codeteil nicht wiederholt werden muss
                {
					result = ServiceResult.Ok();
                    foreach (var validationError in ex.EntityValidationErrors.SelectMany(error => error.ValidationErrors))
                    {
                        result.Add(new ServiceResult(ServiceResultType.Error, validationError.ErrorMessage));
                    }
                }
                catch (Exception ex)
                {
                    result = new ServiceResult(ex); // ToDo: Message
                }
            }
            return result;
        }

        #endregion

        #region Protected Methods

        protected virtual IServiceResult InsertOrUpdateEntities(IUnitOfWork unitOfWork, IEnumerable<T> entitiesToSave)
        {
            if (entitiesToSave == null)
            {
                return ServiceResult.Ok();
            }

            var result = ServiceResult.Ok();

            foreach (var entity in entitiesToSave)
            {
                result.Add(InsertOrUpdateEntity(unitOfWork, entity));
            }

            return result;
        }

        protected virtual ServiceResult InsertOrUpdateEntity(IUnitOfWork unitOfWork, T entityToSave)
        {
            try
            {
                unitOfWork.Repository<T>().InsertOrUpdateEntity(entityToSave);
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        protected virtual IServiceResult RemoveDependentEntities(IUnitOfWork unitOfWork, T entityToRemove)
        {
            return ServiceResult.Ok();
        }

        protected virtual IServiceResult RemoveEntity(IUnitOfWork unitOfWork, T entityToRemove)
        {
            try
            {
                var result = RemoveDependentEntities(unitOfWork, entityToRemove);
                if (!result.IsOk)
                {
                    return result;
                }

                unitOfWork.Repository<T>().Remove(entityToRemove);
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        #endregion

        #endregion

        #region Other

        //private ISessionService SessionService
        //{
        //    get { return Container.Resolve<ISessionService>(); }
        //}

        #endregion
    }
}