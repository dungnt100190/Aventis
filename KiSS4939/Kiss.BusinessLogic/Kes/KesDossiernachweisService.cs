using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    public class KesDossiernachweisService : Service
    {
        private KesDossiernachweisService()
        {
        }

        public virtual IServiceResult<IEnumerable<KesDossiernachweisDTO>> GetDossiernachweisList(KesDossiernachweisSearchParamDTO searchParameters)
        {
            var result = new List<KesDossiernachweisDTO>();

            var xConfigService = Container.Resolve<XConfigService>();
            var xLovService = Container.Resolve<XLovService>();

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                try
                {
                    var gemeinden = xLovService.GetLovCodesByLovName("GemeindeSozialdienst")
                        .WhereIf(searchParameters.GemeindeSozialdienstCode != null, gem => gem.Code == searchParameters.GemeindeSozialdienstCode)
                        .Select(gem => gem.Code)
                        .ToList();

                    var kapitel = KesDossiernachweisServiceRes.Kapitel7;
                    var praeventionen = unitOfWork.FaLeistung.GetKesDossiernachweisPraeventionen(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis).ToList();
                    AddEmptyGemeindeDtos(gemeinden, praeventionen);
                    var dictionary = praeventionen.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalPraeventionen = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.Praeventionen,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalPraeventionen
                        });

                    var massnahmen = unitOfWork.FaLeistung.GetKesDossiernachweisMassnahmen(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis).ToList();
                    AddEmptyGemeindeDtos(gemeinden, massnahmen);
                    dictionary = massnahmen.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalMassnahmen = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.Massnahmen,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalMassnahmen
                        });

                    var auftraegeWeitereAufgaben = unitOfWork.FaLeistung.GetKesDossiernachweisAuftraege(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis,
                        auf => auf.KesAuftragDurchCode == 4 || /*4 = Abklärungsauftrag KESB*/
                               auf.KesAuftragAbklaerungsartCode == 10) //10 = 'Vaterschafts- und Unterhaltsregelung'
                        .ToList();
                    AddEmptyGemeindeDtos(gemeinden, auftraegeWeitereAufgaben);
                    dictionary = auftraegeWeitereAufgaben.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalAuftraegeWeitereAufgaben = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.AuftraegeWeitereAufgaben,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalAuftraegeWeitereAufgaben
                        });

                    var auftraegeGemeinsameElterlicheSorge = unitOfWork.FaLeistung.GetKesDossiernachweisAuftraege(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis,
                        auf => auf.KesAuftragAbklaerungsartCode == 5) //5 = 'Gemeinsame elterliche Sorge KS'
                        .ToList();
                    AddEmptyGemeindeDtos(gemeinden, auftraegeGemeinsameElterlicheSorge);
                    dictionary = auftraegeGemeinsameElterlicheSorge.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalAuftraegeGemeinsameElterlicheSorge = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.AuftraegeGemeinsameElterlicheSorge,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalAuftraegeGemeinsameElterlicheSorge
                        });

                    var tagespflegeMinuten =
                        xConfigService.GetConfigValue(ConfigNodes.System_Kes_Abfragen_DossiernachweisGEF_PflegekinderaufsichtTagespflege);
                    var pflegekinderaufsicht = unitOfWork.FaLeistung.GetKesDossiernachweisPflegekinderaufsicht(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis,
                        tagespflegeMinuten).ToList();
                    AddEmptyGemeindeDtos(gemeinden, pflegekinderaufsicht);
                    dictionary = pflegekinderaufsicht.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalPflegekinderaufsicht = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.Pflegekinderaufsicht,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalPflegekinderaufsicht
                        });

                    kapitel = KesDossiernachweisServiceRes.Kapitel8;
                    var ernennungPriMa = unitOfWork.FaLeistung.GetKesDossiernachweisErnennungPriMa(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis).ToList();
                    AddEmptyGemeindeDtos(gemeinden, ernennungPriMa);
                    dictionary = ernennungPriMa.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalErnennungPriMa = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.ErnennungPriMa,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalErnennungPriMa
                        });

                    var anzahlRegelmaessig = xConfigService.GetConfigValue(ConfigNodes.System_Kes_Abfragen_DossiernachweisGEF_RegelmaessigeBeratung);
                    var beratungPriMa = unitOfWork.FaLeistung.GetKesDossiernachweisBeratungPriMa(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis,
                        anzahlRegelmaessig).ToList();
                    AddEmptyGemeindeDtos(gemeinden, beratungPriMa);
                    dictionary = beratungPriMa.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalBeratungPriMa = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.BeratungPriMa,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalBeratungPriMa
                        });

                    var uebernahmeRechnungsfuehrung = unitOfWork.FaLeistung.GetKesDossiernachweisUebernahmeRechnungsfuehrung(
                        searchParameters.GemeindeSozialdienstCode,
                        searchParameters.DatumVon,
                        searchParameters.DatumBis).ToList();
                    AddEmptyGemeindeDtos(gemeinden, uebernahmeRechnungsfuehrung);
                    dictionary = uebernahmeRechnungsfuehrung.ToDictionary(dto => dto.GemeindeSozialdienstCode);
                    var totalUebernahmeRechnungsfuehrung = dictionary.Values.Sum(x => x.Anzahl);
                    result.Add(
                        new KesDossiernachweisDTO
                        {
                            Kapitel = kapitel,
                            Text = KesDossiernachweisServiceRes.UebernahmeRechnungsfuehrung,
                            DossiernachweisGemeindeDTOs = dictionary,
                            Total = totalUebernahmeRechnungsfuehrung
                        });
                    return new ServiceResult<IEnumerable<KesDossiernachweisDTO>>(result);
                }
                catch (Exception ex)
                {
                    return ServiceResult<IEnumerable<KesDossiernachweisDTO>>.Error(ex);
                }
            }
        }

        private void AddEmptyGemeindeDtos(IEnumerable<int> gemeinden, IList<KesDossiernachweisGemeindeDTO> kesDossiernachweisGemeindeDtos)
        {
            foreach (var gemeindeCode in gemeinden)
            {
                if (!kesDossiernachweisGemeindeDtos.Any(dto => dto.GemeindeSozialdienstCode == gemeindeCode))
                {
                    kesDossiernachweisGemeindeDtos.Add(new KesDossiernachweisGemeindeDTO
                    {
                        Anzahl = 0,
                        GemeindeSozialdienstCode = gemeindeCode
                    });
                }
            }
        }
    }
}