using System;
using System.Collections.Generic;

using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Helpers
{
    public class WshAbzugHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugDTOService _abzugDtoService = Container.Resolve<WshAbzugDTOService>();
        private readonly WshAbzugDetailDTOService _abzugDetailDtoService = Container.Resolve<WshAbzugDetailDTOService>();
        private readonly WshKategorieHelper _kategorieHelper = new WshKategorieHelper();
        private readonly WshKategorieService _kategorieService = Container.Resolve<WshKategorieService>();
        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly List<WshAbzugDTO> _list = new List<WshAbzugDTO>();
        private readonly List<WshGrundbudgetPosition> _listGrundbudgetPosition = new List<WshGrundbudgetPosition>();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private KbuKonto _gblKonto;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public WshAbzugDTO CreateAbzugRueckerstattungGbl(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _kontoHelper.Create(unitOfWork, "872", "Rückerstattung", LOVsGenerated.KbuKontoklasse.Ertrag, LOVsGenerated.KbuKontoTyp.Zulagen);
            var person = _personHelper.Create(unitOfWork);

            WshAbzugDTO dto;
            var result = _abzugDtoService.NewData(out dto);

            result.Assert();

            var grundbudgetPosition = dto.WshAbzug.WshGrundbudgetPosition;
            grundbudgetPosition.FaLeistung = leistung;
            grundbudgetPosition.KbuKonto = konto;
            grundbudgetPosition.BaPerson = person;
            grundbudgetPosition.BetragMonatlich = 50;
            grundbudgetPosition.BetragTotal = 500;
            grundbudgetPosition.DatumVon = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1);
            grundbudgetPosition.Bemerkung = "Das ist eine Bemerkung";
            grundbudgetPosition.Text = "Rückerstattung UnitTestPosition";
            grundbudgetPosition.WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt;
            grundbudgetPosition.WshKategorie = _kategorieService.GetById(unitOfWork, (int)LOVsGenerated.WshKategorie.Rueckerstattung);

            result = _abzugDtoService.SaveData(unitOfWork, dto, _questionsAnswers);

            result.Assert();

            _list.Add(dto);

            _abzugDtoService.SetDtoProperties(unitOfWork, dto);
            return dto;
        }

        public WshAbzugDTO CreateAbzugVerrechnung(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _gblKonto ?? (_gblKonto = _kontoHelper.Create(unitOfWork));
            var person = _personHelper.Create(unitOfWork);

            WshAbzugDTO dto;
            var result = _abzugDtoService.NewData(out dto);

            result.Assert();

            var grundbudgetPosition = dto.WshAbzug.WshGrundbudgetPosition;
            grundbudgetPosition.FaLeistung = leistung;
            grundbudgetPosition.KbuKonto = konto;
            grundbudgetPosition.BaPerson = person;
            grundbudgetPosition.BetragMonatlich = 146.9m;
            grundbudgetPosition.BetragTotal = 1500;
            grundbudgetPosition.DatumVon = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1);
            grundbudgetPosition.Bemerkung = "Das ist eine Bemerkung";
            grundbudgetPosition.Text = "Verrechnung UnitTestPosition";
            grundbudgetPosition.WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt;
            grundbudgetPosition.WshKategorie = _kategorieService.GetById(unitOfWork, (int)LOVsGenerated.WshKategorie.Verrechnung);

            result = _abzugDtoService.SaveData(unitOfWork, dto, _questionsAnswers);

            result.Assert();

            _abzugDtoService.SetDtoProperties(unitOfWork, dto);
            _list.Add(dto);

            return dto;
        }

        private readonly Dictionary<string, QuestionAnswerOption> _questionsAnswers = new Dictionary<string, QuestionAnswerOption>();

        public WshAbzugDTO CreateAbzugRueckerstattungGblDetails(IUnitOfWork unitOfWork)
        {
            WshAbzugDTO dto = CreateAbzugRueckerstattungGbl(unitOfWork);
            WshAbzugDetailDTO detailDTO;
            var result = _abzugDetailDtoService.NewData(out detailDTO);

            result.Assert();

            dto.WshAbzugDetailDto.Add(detailDTO);

            var konto = _gblKonto ?? (_gblKonto = _kontoHelper.Create(unitOfWork));

            detailDTO.WshAbzugDetail.Betrag = 100;
            detailDTO.WshAbzugDetail.KbuKonto = konto;
            _abzugDetailDtoService.SetDtoProperties(unitOfWork, detailDTO);

            result = _abzugDetailDtoService.SaveData(unitOfWork, detailDTO);

            result.Assert();

            _abzugDtoService.SetDtoProperties(unitOfWork, dto);

            return dto;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            foreach (var dto in _list)
            {
                Delete(unitOfWork, dto);
            }

            foreach (var position in _listGrundbudgetPosition)
            {
                WshGrundbudgetPositionHelper.DeleteWshGrundbudgetPosition(unitOfWork, position.WshGrundbudgetPositionID);
            }

            _kontoHelper.Delete(unitOfWork);
            _kategorieHelper.ClearWshKategorieMock(unitOfWork);
            _leistungHelper.Delete(unitOfWork);
            _personHelper.Delete(unitOfWork);
        }

        public void RegisterGrundbudgetPositionForDeletion(WshGrundbudgetPosition position)
        {
            _listGrundbudgetPosition.Add(position);
        }

        #endregion

        #region Private Methods

        private void Delete(IUnitOfWork unitOfWork, WshAbzugDTO dto)
        {
            var position = dto.WshAbzug.WshGrundbudgetPosition;
            _abzugDtoService.DeleteData(unitOfWork, dto);
            WshGrundbudgetPositionHelper.DeleteWshGrundbudgetPosition(unitOfWork, position.WshGrundbudgetPositionID);
        }

        #endregion

        #endregion
    }
}