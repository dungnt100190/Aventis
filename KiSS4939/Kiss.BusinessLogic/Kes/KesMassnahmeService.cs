using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DataAccess.Interfaces;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    public class KesMassnahmeService : ServiceCRUD<KesMassnahme>
    {
        private KesMassnahmeService()
        {
        }

        public virtual IList<KesMassnahme> GetByFaLeistungId(int faLeistungId, bool inclDeleted)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var massnahmen = unitOfWork.KesMassnahme.GetByFaLeistungId(faLeistungId, inclDeleted);

                foreach (var massnahme in massnahmen)
                {
                    SetZgbArtikelTextKurzOfMassnahme(unitOfWork, massnahme);
                }

                return massnahmen;
            }
        }

        public KesMassnahme GetCleanedCopyOfKesMassnahme(KesMassnahme oldMassnahme)
        {
            var cleanedCopyWithNewDocuments = (KesMassnahme)CopyEntity(oldMassnahme);
            cleanedCopyWithNewDocuments.IsDeleted = false; //Die Kopie darf nicht bereits als gelöscht markiert sein.

            CleanRelationsOfMassnahme(cleanedCopyWithNewDocuments);
            CopyKesMassnahmeDocuments(oldMassnahme, cleanedCopyWithNewDocuments);
            return cleanedCopyWithNewDocuments;
        }

        public override IServiceResult SaveEntity(KesMassnahme entityToSave)
        {
            var leistungService = Container.Resolve<KesLeistungService>();
            var leistung = leistungService.GetEntityById(entityToSave.FaLeistungID);

            if (leistung == null)
            {
                return ServiceResult.Error(KesServiceRes.ErrorUngueltigeLeistung);
            }

            var result = base.SaveEntity(entityToSave);

            if (result.IsOk)
            {
                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    try
                    {
                        unitOfWork.KesMassnahme.SaveKesArtikel(entityToSave);
                        unitOfWork.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result = KissServiceResult.Error(ex);
                    }
                }
            }

            return result;
        }

        public virtual void SetZgbArtikelTextKurzOfMassnahme(IKissUnitOfWork unitOfWork, KesMassnahme massnahme)
        {
            massnahme.ZgbArtikel = massnahme.KesMassnahme_KesArtikel != null ? massnahme.KesMassnahme_KesArtikel.Select(kar => kar.KesArtikelID).ToArray() : null;

            if (massnahme.ZgbArtikel != null && massnahme.ZgbArtikel.Any())
            {
                var artikel = unitOfWork.KesArtikel.GetByArtikelIds(massnahme.ZgbArtikel.ToArray());
                massnahme.ZgbArtikelTextKurz = string.Join(", ", artikel.Select(art => art.ArtikelText).ToList());
            }
            else
            {
                massnahme.ZgbArtikelTextKurz = "";
            }
        }

        protected override IServiceResult RemoveDependentEntities(DataAccess.Interfaces.IUnitOfWork uow, KesMassnahme entityToRemove)
        {
            var unitOfWork = (IKissUnitOfWork)uow;
            try
            {
                // Prüfen ob es abhängige Daten gibt
                var hasKesMandatsfuehrendePerson = unitOfWork.KesMandatsfuehrendePerson.HasKesMandatsfuehrendePerson(entityToRemove.KesMassnahmeID);
                var hasKesMassnahmeBericht = unitOfWork.KesMassnahmeBericht.HasKesMassnahmeBericht(entityToRemove.KesMassnahmeID);
                var hasKesMassnahmeAuftrag = unitOfWork.KesMassnahmeAuftrag.HasKesMassnahmeAuftrag(entityToRemove.KesMassnahmeID);

                if (hasKesMandatsfuehrendePerson ||
                    hasKesMassnahmeBericht ||
                    hasKesMassnahmeAuftrag)
                {
                    var errorDeleteDatenExistieren = KesServiceRes.ErrorDeleteDatenExistieren;
                    if (hasKesMandatsfuehrendePerson)
                    {
                        errorDeleteDatenExistieren += Environment.NewLine + KesServiceRes.ErrorDeleteMandatsfuehrendePersonExistieren;
                    }

                    if (hasKesMassnahmeBericht)
                    {
                        errorDeleteDatenExistieren += Environment.NewLine + KesServiceRes.ErrorDeleteMassnahmeBerichtExistieren;
                    }

                    if (hasKesMassnahmeAuftrag)
                    {
                        errorDeleteDatenExistieren += Environment.NewLine + KesServiceRes.ErrorDeleteMassnahmeAuftragExistieren;
                    }

                    return ServiceResult.Error(errorDeleteDatenExistieren);
                }

                // KesMassnahmeArtikel löschen
                unitOfWork.KesMassnahmeArtikel.RemoveByKesMassnahmeID(entityToRemove.KesMassnahmeID);

                // Dokumente löschen
                var documentRepository = (XDocumentRepository)unitOfWork.Repository<XDocument>();
                documentRepository.Remove(entityToRemove.DocumentID_Aufhebungsbeschluss);
                documentRepository.Remove(entityToRemove.DocumentID_Errichtungsbeschluss);
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        private static void CleanRelationsOfMassnahme(KesMassnahme newMassnahme)
        {
            newMassnahme.KesMassnahme_KesArtikel = null;
            newMassnahme.KesMassnahmeBericht = null;
            newMassnahme.KesMassnahmeAuftrag = null;
            newMassnahme.KesMandatsfuehrendePerson = null;
            newMassnahme.DocumentID_Aufhebungsbeschluss = null;
            newMassnahme.DocumentID_Errichtungsbeschluss = null;
        }

        private static void CopyKesMassnahmeDocuments(KesMassnahme oldMassnahme, KesMassnahme newMassnahme)
        {
            var documentService = Container.Resolve<XDocumentService>();
            newMassnahme.DocumentID_Aufhebungsbeschluss = oldMassnahme.DocumentID_Aufhebungsbeschluss != null ? documentService.CopyDocument((int)oldMassnahme.DocumentID_Aufhebungsbeschluss) : (int?)null;
            newMassnahme.DocumentID_Errichtungsbeschluss = oldMassnahme.DocumentID_Errichtungsbeschluss != null ? documentService.CopyDocument((int)oldMassnahme.DocumentID_Errichtungsbeschluss) : (int?)null;
        }
    }
}