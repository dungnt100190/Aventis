using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class WshPositionAbzugDTOService : ServiceBase, IServiceCRUD<WshPositionAbzugDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshPositionService _wshPositionService = Container.Resolve<WshPositionService>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshPositionAbzugDTO dataToDelete, bool saveChanges = true)
        {
            return _wshPositionService.DeleteData(unitOfWork, dataToDelete.WshPosition, saveChanges);
        }

        public ObservableCollection<WshPositionAbzugDTO> GetByWshGrundbudgetPositionId(
            IUnitOfWork unitOfWork,
            int wshGrundbudgetPositionID,
            decimal? startSaldo)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var query = _wshPositionService.GetByWshGrundbudgetPositionIdQueryable(unitOfWork, wshGrundbudgetPositionID);

            query = query.OrderByDescending(pos => pos.MonatVon);

            IList<WshPosition> positionen = _wshPositionService.SummenDerWshPositionenBerechnen(unitOfWork, query);
            var positionDtos = new ObservableCollection<WshPositionAbzugDTO>();
            foreach (WshPosition pos in positionen)
            {
                positionDtos.Add(new WshPositionAbzugDTO(pos));
            }

            SetSaldo(positionDtos, startSaldo);
            return positionDtos;
        }

        public ObservableCollection<WshPositionAbzugDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public KissServiceResult NewData(out WshPositionAbzugDTO newData)
        {
            throw new NotImplementedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshPositionAbzugDTO dataToSave)
        {
            KissServiceResult result;

            using (var trx = new TransactionScope())
            {
                result = ValidateOnDatabase(dataToSave);
                if (!result.IsOk)
                {
                    return result;
                }

                dataToSave.WshPosition.Betrag = dataToSave.BetragAnzeige;
                result += _wshPositionService.SaveData(unitOfWork, dataToSave.WshPosition);

                trx.Complete();
            }

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshPositionAbzugDTO> dataToSave)
        {
            throw new NotImplementedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork,
            WshPositionAbzugDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Berechnet den Saldo für jede Monatsposition.
        /// todo: Redundanz mit Update-Betrag.
        /// </summary>
        /// <param name="positionDtos"></param>
        public void SetSaldo(ObservableCollection<WshPositionAbzugDTO> positionDtos, decimal? startSaldo)
        {
            if (startSaldo == null)
            {
                return;
            }

            var saldo = startSaldo.Value;

            for (var i = positionDtos.Count() - 1; i >= 0; i--)
            {
                saldo -= positionDtos[i].WshPosition.Betrag;
                positionDtos[i].Saldo = saldo;
            }
        }

        /// <summary>
        /// Berechnet die Beträge der Positionen neu.
        /// Saldo wird auch neu berechnet.
        /// Wenn Saldo aufgebraucht wird, werden die Beträge
        /// der Positionen reduziert oder auf 0 gesetzt.
        /// Es werden keine neuen Positionen angelegt, wenn Positionen inaktiviert werden.
        /// </summary>
        /// <param name="abzugDto"></param>
        /// <param name="entityList"></param>
        /// <param name="selectedEntity"></param>
        public void UpdateBetrag(WshAbzugDTO abzugDto, ObservableCollection<WshPositionAbzugDTO> entityList, WshPositionAbzugDTO selectedEntity)
        {
            if (selectedEntity != null)
            {

                if(selectedEntity.Aktiv)
                {
                    selectedEntity.WshPosition.Betrag = abzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich;
                }

                decimal? startSaldo = abzugDto.WshAbzug.WshGrundbudgetPosition.BetragTotal;


                if (startSaldo == null)
                {
                    return;
                }

                var saldo = startSaldo.Value;

                //grüne Positionen dürfen nicht verändert werden.
                //nur graue Positionen dürfen angepasst werden.
                decimal betragNichtGrauePositionen = 0;
                List<WshPositionAbzugDTO> grauePositionen = new List<WshPositionAbzugDTO>();
                foreach (WshPositionAbzugDTO monatsPosition in entityList)
                {
                    if ((monatsPosition.WshPosition.PositionsStatus & WshPositionsstatus.Vorbereitet) == WshPositionsstatus.Vorbereitet)
                    {
                        grauePositionen.Add(monatsPosition);
                    }
                    else
                    {
                        betragNichtGrauePositionen += monatsPosition.WshPosition.Betrag;
                    }
                }
                decimal restSaldo = saldo - betragNichtGrauePositionen;
                foreach (WshPositionAbzugDTO grauePosition in grauePositionen)
                {                    
                    decimal b;
                    if (restSaldo <= 0)
                    {
                        b = 0;
                    }
                    else
                    {
                        b = saldo;
                    }
                    if (grauePosition.Aktiv)
                    {
                        grauePosition.WshPosition.Betrag = Math.Min(b, abzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich);
                    }
                    else
                    {
                        grauePosition.WshPosition.Betrag = 0;
                    }
                    restSaldo -= grauePosition.WshPosition.Betrag;
                }

                SetSaldo(entityList, saldo);

              
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataToValidate"></param>
        /// <returns></returns>
        public KissServiceResult ValidateOnDatabase(WshPositionAbzugDTO dataToValidate)
        {
            //Neues UnitOfWork ist nötig, sonst kommt Exception, dass Objekt bereits im Context ist (ApplyChanges).
            var unitOfWork = UnitOfWork.GetNew;

            // Summen der Position sind nötig um den Status zu berechnen
            var service = Container.Resolve<WshPositionService>();
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            var query = repository.Where(x => x.WshPositionID == dataToValidate.WshPosition.WshPositionID);
            var position = service.SummenDerWshPositionenBerechnen(unitOfWork, query).SingleOrDefault();

            if (position == null)
            {
                return KissServiceResult.Ok();
            }

            //Betrag darf nur geändert werden, wenn Position grau ist.
            if ((position.PositionsStatus & WshPositionsstatus.Vorbereitet) == 0)
            {
                if (dataToValidate.WshPosition.Betrag != position.Betrag)
                {
                    KissServiceResult.Error(new Exception("Der Betrag kann nur bei grauen Positionen geändert werden."));
                }
            }

            return KissServiceResult.Ok();
        }

        #endregion

        #endregion
    }
}