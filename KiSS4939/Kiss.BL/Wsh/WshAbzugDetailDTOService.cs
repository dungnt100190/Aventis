using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Kbu;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshAbzugDetailDTO.
    /// </summary>
    public class WshAbzugDetailDTOService : ServiceBase, IServiceCRUD<WshAbzugDetailDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugDetailService _abzugDetailService = Container.Resolve<WshAbzugDetailService>();
        private readonly WshGrundbudgetPositionService _grundbudgetPositionService = Container.Resolve<WshGrundbudgetPositionService>();
        private readonly List<WshAbzugDetailDTO> _isCalculatingGblBetrag = new List<WshAbzugDetailDTO>();
        private readonly KbuGeldbetragRundungsService _rundungsService = Container.Resolve<KbuGeldbetragRundungsService>();

        #endregion

        #endregion

        #region Constructors

        private WshAbzugDetailDTOService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshAbzugDetailDTO dataToDelete, bool saveChanges = true)
        {
            return DeleteData(unitOfWork, dataToDelete.WshAbzugDetail, saveChanges);
        }

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshAbzugDetail dataToDelete, bool saveChanges = true)
        {
            return _abzugDetailService.DeleteData(unitOfWork, dataToDelete, saveChanges);
        }

        public ObservableCollection<WshAbzugDetailDTO> GetByWshAbzugId(IUnitOfWork unitOfWork, int abzugId)
        {
            var details = _abzugDetailService.GetByWshAbzugId(unitOfWork, abzugId);

            var result = new ObservableCollection<WshAbzugDetailDTO>();

            foreach (var wshAbzugDetail in details)
            {
                var dto = new WshAbzugDetailDTO(wshAbzugDetail);
                SetDtoProperties(unitOfWork, dto);
                result.Add(dto);
            }

            return result;
        }

        public ObservableCollection<WshAbzugDetailDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public LOVsGenerated.SysEditMode GetSysEditModePersonBetrifft(int kbuKontoId, DateTime? datumVon, DateTime? datumBis)
        {
            return _grundbudgetPositionService.GetSysEditModePersonBetrifft(kbuKontoId, datumVon, datumBis);
        }

        public KissServiceResult NewData(out WshAbzugDetailDTO newData)
        {
            WshAbzugDetail detail;
            var result = _abzugDetailService.NewData(out detail);
            newData = new WshAbzugDetailDTO(detail);
            return result;
        }

        public KissServiceResult NewData(WshAbzug wshAbzug, out WshAbzugDetailDTO newData)
        {
            var result = NewData(out newData);
            newData.WshAbzugDetail.WshAbzug = wshAbzug;
            SetDtoProperties(null, newData);
            return result;
        }

        public KissServiceResult NewData(WshAbzugDetail originalAbzugDetail, out WshAbzugDetail newData)
        {
            var result = _abzugDetailService.NewData(out newData);

            newData.BaPerson = originalAbzugDetail.BaPerson;
            newData.BaPersonID = originalAbzugDetail.BaPersonID;
            newData.Betrag = originalAbzugDetail.Betrag;
            newData.KbuKonto = originalAbzugDetail.KbuKonto;
            newData.KbuKontoID = originalAbzugDetail.KbuKontoID;

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshAbzugDetailDTO dataToSave)
        {
            if (dataToSave == null)
            {
                return KissServiceResult.Ok();
            }

            // Validate
            var result = ValidateInMemory(dataToSave);

            if (!result)
            {
                return result;
            }

            return _abzugDetailService.SaveData(unitOfWork, dataToSave.WshAbzugDetail);
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshAbzugDetailDTO> dataToSave)
        {
            var result = KissServiceResult.Ok();
            dataToSave.ForEach(x => result += SaveData(unitOfWork, x));
            return result;
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshAbzugDetailDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotSupportedException();
        }

        public void SetDetailAbzugBetrag(IUnitOfWork unitOfWork, WshAbzugDetailDTO dto)
        {
            if (_isCalculatingGblBetrag.Contains(dto))
            {
                return;
            }

            try
            {
                _isCalculatingGblBetrag.Add(dto);
                var totalBetrag = dto.GblAktuell;
                var gblAbzugProzent = dto.GblAbzugProzent;

                if (totalBetrag.HasValue && gblAbzugProzent.HasValue)
                {
                    // Set DTO properties
                    dto.WshAbzugDetail.Betrag = _rundungsService.GeldbetragRunden(totalBetrag.Value * gblAbzugProzent.Value / 100);
                }
                else
                {
                    dto.WshAbzugDetail.Betrag = 0;
                }
            }
            finally
            {
                _isCalculatingGblBetrag.Remove(dto);
            }
        }

        public void SetDtoProperties(IUnitOfWork unitOfWork, IList<WshAbzugDetailDTO> dtoList)
        {
            dtoList.ToList().ForEach(x => SetDtoProperties(unitOfWork, x));
        }

        public void SetDtoProperties(IUnitOfWork unitOfWork, WshAbzugDetailDTO dto)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            SetGblAktuell(unitOfWork, dto);
            SetGblAbzugProzent(unitOfWork, dto);
        }

        public void SetGblAbzugProzent(IUnitOfWork unitOfWork, WshAbzugDetailDTO dto)
        {
            if (_isCalculatingGblBetrag.Contains(dto))
            {
                return;
            }

            try
            {
                _isCalculatingGblBetrag.Add(dto);

                var kontoService = Container.Resolve<KbuKontoService>();
                var gblKontoIds = kontoService.GetAllGblKontoIds(unitOfWork);

                var detailBetrag = dto.WshAbzugDetail != null ? dto.WshAbzugDetail.Betrag : (decimal?)null;
                var totalBetrag = dto.GblAktuell;
                bool isGblKonto = dto.WshAbzugDetail != null && gblKontoIds.Contains(dto.WshAbzugDetail.KbuKontoID);

                if (detailBetrag.HasValue && totalBetrag.HasValue && isGblKonto)
                {
                    // Set DTO properties
                    dto.GblAbzugProzent = detailBetrag > 0 ? Math.Round(100 / totalBetrag.Value * detailBetrag.Value, 2) : (decimal?)null;
                }
                else
                {
                    dto.GblAbzugProzent = null;
                }
            }
            finally
            {
                _isCalculatingGblBetrag.Remove(dto);
            }
        }

        // TODO do the same as in WshAbzugDTOService
        public void SetGblAktuell(IUnitOfWork unitOfWork, WshAbzugDetailDTO dto)
        {
            // GBL-Detailbetrag holen
            var kontoService = Container.Resolve<KbuKontoService>();
            var gblKontoIds = kontoService.GetAllGblKontoIds(unitOfWork);

            // Aktuelle GBL-Position holen
            var gbService = Container.Resolve<WshGrundbudgetPositionService>();
            var gblPosition =
                gbService.GetByFaLeistungIDQueryable(unitOfWork, dto.WshAbzugDetail.WshAbzug.WshGrundbudgetPosition.FaLeistungID, DateTime.Today, false, false)
                    .Where(x => gblKontoIds.Contains(x.KbuKontoID))
                    .OrderBy(x => !x.Berechnet) //berechnete Positionen zuerst, dann nach Datum
                    .ThenByDescending(x => x.DatumVon)
                    .FirstOrDefault(); //es kann sein, dass es mehrere GBL-Positionen hat

            if (gblPosition != null)
            {
                var totalBetrag = gblPosition.BetragMonatlich;
                dto.GblAktuell = totalBetrag;
            }
            else
            {
                dto.GblAktuell = null;
            }
        }

        #endregion

        #region Private Methods

        private KissServiceResult ValidateInMemory(WshAbzugDetailDTO dataToValidate)
        {
            return WshAbzugDetailDTOValidator.ValidateEntity(dataToValidate);
        }

        #endregion

        #endregion
    }
}