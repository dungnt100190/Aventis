using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL
{
    public abstract class ServiceCRUDBase<T> : ServiceBase, IServiceCRUD<T>
        where T : class, IObjectWithChangeTracker, IValidating<T>, new()
    {
        #region Properties

        private ISessionService SessionService
        {
            get { return Container.Resolve<ISessionService>(); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual KissServiceResult DeleteData(IUnitOfWork unitOfWork, T dataToDelete, bool saveChanges = true)
        {
            // Validate Delete statically
            KissServiceResult result = IsDeleteAllowed(dataToDelete);

            if (!result)
            {
                return result;
            }

            // Delete the Entity in the DB
            using (var trx = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                var repository = UnitOfWork.GetRepository<T>(unitOfWork);

                dataToDelete.MarkAsDeleted();

                repository.ApplyChanges(dataToDelete);

                if (saveChanges)
                {
                    unitOfWork.SaveChanges();
                }

                trx.Complete();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public abstract T GetById(IUnitOfWork unitOfWork, int id);

        /// <summary>
        /// Gets an observable collection containing all data from table <typeparamref name="T"/>.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public virtual ObservableCollection<T> GetData(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = GetDataInternal(unitOfWork);
            var list = new ObservableCollection<T>(repository);

            foreach (var data in list)
            {
                SetEntityValidator(data);
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return list;
        }

        /// <summary>
        /// This method can be overloaded to initialize a new Entity.
        /// This method gets automatically called from within base.NewData() after the Entity was created
        /// </summary>
        /// <param name="newData">A new Entity</param>
        public virtual void InitData(T newData)
        {
            SetCreator(newData);
            SetModifier(newData);
            SetEntityValidator(newData);
        }

        /// <summary>
        /// This method can be overloaded to statically (without accessing the DB) check if deleting the entity is allowed
        /// This method gets automatically called from within base.DeleteData() before the Entity gets deleted in the DB 
        /// => If this method returns KissServiceResult.Ok, then base.DeleteData() will continue the delete
        /// </summary>
        /// <param name="dataToDelete"></param>
        /// <returns></returns>
        public virtual KissServiceResult IsDeleteAllowed(T dataToDelete)
        {
            return KissServiceResult.Ok();
        }

        public virtual KissServiceResult NewData(out T newData)
        {
            newData = new T();

            InitData(newData);

            newData.ChangeTracker.ChangeTrackingEnabled = true;

            return KissServiceResult.Ok();
        }

        public virtual KissServiceResult SaveData(IUnitOfWork unitOfWork, T dataToSave)
        {
            return SaveData(unitOfWork, dataToSave, true);
        }

        public virtual KissServiceResult SaveData(IUnitOfWork unitOfWork, List<T> dataToSave)
        {
            return SaveData(unitOfWork, dataToSave, new TimeSpan(0, 0, 30));
        }

        public virtual KissServiceResult SaveData(IUnitOfWork unitOfWork, List<T> dataToSave, TimeSpan timeout)
        {
            if (dataToSave == null)
            {
                return KissServiceResult.Ok();
            }

            KissServiceResult result = KissServiceResult.Ok();

            // Static Validation
            foreach (T entity in dataToSave)
            {
                // update the modifier/modified
                SetModifier(entity);

                result += ValidateInMemory(entity);
            }

            if (!result)
            {
                return result;
            }

            using (var trx = new TransactionScope(TransactionScopeOption.Required, timeout))
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                // Dynamic Validation: Check if Entity is also consistent with the DB at this point in time
                foreach (T entity in dataToSave)
                {
                    result += ValidateOnDatabase(unitOfWork, entity);
                }

                if (!result)
                {
                    return result;
                }

                foreach (T entity in dataToSave)
                {
                    SaveData(unitOfWork, entity, false);
                }

                trx.Complete();
            }

            foreach (T entity in dataToSave)
            {
                entity.AcceptChanges();
            }

            return result;
        }

        public virtual KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            T dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            return SaveData(unitOfWork, dataToSave);
        }

        public virtual KissServiceResult SaveData(IUnitOfWork unitOfWork, T dataToSave, bool acceptChanges)
        {
            if (dataToSave == null)
            {
                return KissServiceResult.Ok();
            }

            if (dataToSave.ChangeTracker.State == ObjectState.Unchanged)
            {
                return KissServiceResult.Ok();
            }

            // update the modifier/modified
            SetModifier(dataToSave);

            // Static-Validation
            KissServiceResult result = ValidateInMemory(dataToSave);

            if (!result)
            {
                return result;
            }

            using (var trx = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                IRepository<T> repository = UnitOfWork.GetRepository<T>(unitOfWork);

                // Dynamic Validation: Check if Entity is also consistent with the DB at this point in time
                result = ValidateOnDatabase(unitOfWork, dataToSave);

                if (!result)
                {
                    return result;
                }

                repository.ApplyChanges(dataToSave);

                unitOfWork.SaveChanges();

                trx.Complete();
            }

            if (acceptChanges)
            {
                dataToSave.AcceptChanges();
            }

            return result;
        }

        public void SetCreator(T data)
        {
            if (data == null)
            {
                return;
            }

            var t = typeof(T);

            var creator = t.GetProperty(Constant.CREATOR);
            var created = t.GetProperty(Constant.CREATED);

            if (creator != null)
            {
                creator.SetValue(data, SessionService.AuthenticatedUser.CreatorModifier, null);
            }

            if (created != null)
            {
                created.SetValue(data, DateTime.Now, null);
            }
        }

        public void SetEntityValidator(T entity)
        {
            entity.Validator = ValidateInMemory;
        }

        public void SetModifier(T data)
        {
            if (data == null)
            {
                return;
            }

            var t = typeof(T);

            var modifier = t.GetProperty(Constant.MODIFIER);
            var modified = t.GetProperty(Constant.MODIFIED);

            if (modifier != null)
            {
                modifier.SetValue(data, SessionService.AuthenticatedUser.CreatorModifier, null);
            }

            if (modified != null)
            {
                modified.SetValue(data, DateTime.Now, null);
            }
        }

        /// <summary>
        /// This method can be overloaded to statically (without accessing the DB) validate the entity
        /// This method gets automatically called from within base.SaveData() before the Entity gets updated in the DB 
        /// => If this method returns KissServiceResult.Ok, then base.SaveData() will continue the update
        /// </summary>
        /// <param name="dataToValidate"></param>
        /// <returns></returns>
        public virtual KissServiceResult ValidateInMemory(T dataToValidate)
        {
            return KissServiceResult.Ok();
        }

        /// <summary>
        /// This method can be overloaded to dynamically (e.g. with accessing the DB inside the transaction) validate the entity
        /// This method gets automatically called from within base.SaveData() before the Entity gets updated in the DB 
        /// => If this method returns KissServiceResult.Ok, then base.SaveData() will continue the update
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dataToValidate"></param>
        /// <returns></returns>
        public virtual KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, T dataToValidate)
        {
            return KissServiceResult.Ok();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Returns an <see cref="IRepository{T}"/> containing all the data from table <typeparamref name="T"/>.
        /// This method is used in <see cref="GetData(IUnitOfWork)"/>. Override to intercept the process for sorting, etc.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        protected virtual IQueryable<T> GetDataInternal(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            return UnitOfWork.GetRepository<T>(unitOfWork);
        }

        #endregion

        #endregion
    }
}