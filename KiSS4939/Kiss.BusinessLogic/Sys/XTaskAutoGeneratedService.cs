﻿using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Sys
{
    public class XTaskAutoGeneratedService : ServiceCRUD<XTaskAutoGenerated>
    {
        private XTaskAutoGeneratedService()
        {
        }

        public void DeleteKesMassnahmeAuftragVersandPendenz(int kesMassnahmeAuftragId)
        {
            XTaskAutoGenerated xTaskAutoGenerated;
            var tableName = typeof(KesMassnahmeAuftrag).Name;

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(tableName, kesMassnahmeAuftragId);
            }

            DeleteEntity(xTaskAutoGenerated);

            var xtaskService = Container.Resolve<XTaskService>();
            xtaskService.DeleteEntity(xTaskAutoGenerated.XTask);
        }

        /// <summary>
        /// Wird ein Dokument 'Beschluss Rückmeldung' eingefügt, werden alle offenen KesDokumentVersand-Pendenzen geschlossen.
        /// Abhängigkeit zur anderen Methode welche diese Pendenzen erzeugt.
        /// </summary>
        /// <param name="entity">KesAuftrag</param>
        public void ErledigeKesDokumentVersandPendenzen(KesAuftrag entity)
        {
            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_AuftragsAbklaerungsErledigung_Aktiv));

            if (!pendenzAktiv)
            {
                return;
            }

            if (entity.DocumentID_BeschlussRueckmeldung != null)
            {
                var xTaskAutoGenerated = new List<XTaskAutoGenerated>();
                var xtaskService = Container.Resolve<XTaskService>();

                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    var kesDokumente = unitOfWork.KesDokument.GetByKesAuftragId(entity.KesAuftragID, (int)LOVsGenerated.KesDokumentTyp.AuftragDokument, false);
                    xTaskAutoGenerated.AddRange(kesDokumente.Select(dok => unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(typeof(KesDokument).Name, dok.WrappedEntity.KesDokumentID)));
                }

                foreach (var autoGenerated in xTaskAutoGenerated.Where(x => x != null && x.XTask != null
                                                                            && x.XTask.DoneDate == null))
                {
                    autoGenerated.XTask.DoneDate = DateTime.Now;
                    autoGenerated.XTask.TaskStatusCode = (int)LOVsGenerated.TaskStatus.Erledigt;
                    xtaskService.SaveEntity(autoGenerated.XTask);
                }
            }
        }

        public IServiceResult GastrechtAnfragenErstellenPendenz(bool isUnbefristed, int faLeistungID, int userIDSender, string bemerkungen)
        {
            var xLovService = Container.Resolve<XLovService>();
            var xUserService = Container.Resolve<XUserService>();
            var baPersonService = Container.Resolve<BaPersonService>();
            var xModulService = Container.Resolve<XModulService>();
            var faLeistungService = Container.Resolve<FaLeistungService>();

            var taskTypeLOVCode = (isUnbefristed) ? (int)LOVsGenerated.TaskType.UnbefristesGastrechtErteilen : (int)LOVsGenerated.TaskType.BefristesGastrechtErteilen;
            var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                .First(lov => lov.Code == taskTypeLOVCode);

            FaLeistung faLeistung = faLeistungService.GetEntityById(faLeistungID);
            XUser xUserSender = xUserService.GetEntityById(userIDSender);
            string modulName = xModulService.GetEntityById(faLeistung.ModulID).Name;
            BaPerson baPerson = baPersonService.GetEntityById(faLeistung.BaPersonID);

            string taskDescription;
            if (isUnbefristed)
            {
                taskDescription = string.Format(
                    taskType.Value2,
                    xUserSender.FirstName,
                    xUserSender.LastName,
                    xUserSender.LogonName,
                    modulName,
                    baPerson.LastNameFirstName,
                    bemerkungen);
            }
            else
            {
                var configService = Container.Resolve<XConfigService>();
                int anzahlMonate = configService.GetConfigValue(ConfigNodes.System_Allgemein_GastrechtAnzahlMonate);

                taskDescription = string.Format(
                    taskType.Value2,
                    xUserSender.FirstName,
                    xUserSender.LastName,
                    xUserSender.LogonName,
                    anzahlMonate,
                    modulName,
                    baPerson.LastNameFirstName,
                    bemerkungen);
            }

            var xTask = new XTask
            {
                FaLeistungID = faLeistungID,
                TaskTypeCode = taskType.Code,
                TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                CreateDate = DateTime.Today,
                ExpirationDate = DateTime.Today,
                Subject = taskType.Value1,
                TaskDescription = taskDescription,
                SenderID = userIDSender,
                TaskSenderCode = (int)LOVsGenerated.TaskSender.Person,
                ReceiverID = faLeistung.UserID,
                TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person
            };

            var xTaskAutoGenerated = new XTaskAutoGenerated
            {
                XTask = xTask,
                XTaskAutoGeneratedTypeCode = (isUnbefristed) ? (int)LOVsGenerated.XTaskAutoGeneratedType.UnbefristesGastrechtErteilen : (int)LOVsGenerated.XTaskAutoGeneratedType.BefristesGastrechtErteilen
            };

            SaveEntity(xTaskAutoGenerated);

            return ServiceResult.Ok();
        }

        /// <summary>
        /// Diese Pendenz wird erzeugt sobald der SA ein Dokument in den Versand, Register Abklärung/Auftrag - Bearbeitung einfügt.
        /// Es wird darauf hingewiesen, dass nun das Einfügen eines Dokumentes 'Beschluss Rückmeldung' (Register Auftrag) fällig ist.
        /// Dieses Dokument 'Beschluss Rückmeldung' wird in der Erledigen-Methode erledigt.
        /// </summary>
        /// <param name="entity">KesDokument</param>
        public void InsertKesDokumentVersandPendenz(KesDokument entity)
        {
            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_AuftragsAbklaerungsErledigung_Aktiv));

            XTaskAutoGenerated xTaskAutoGenerated;

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(typeof(KesDokument).Name, entity.KesDokumentID);
            }

            if (!pendenzAktiv)
            {
                return;
            }

            if (xTaskAutoGenerated == null && entity.XDocumentID_Versand != null)
            {
                var xLovService = Container.Resolve<XLovService>();
                var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                    .First(lov => lov.Code == (int)LOVsGenerated.TaskType.FristablaufAbklaerungAuftragErledigung);

                var daysToAdd = Convert.ToInt32(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_AuftragsAbklaerungsErledigung_AnzahlTage));

                var kesAuftragService = Container.Resolve<KesAuftragService>();
                var kesAuftrag = kesAuftragService.GetEntityById((int)entity.KesAuftragID);

                var faLeistungService = Container.Resolve<FaLeistungService>();
                var baPersonID = faLeistungService.GetEntityById(kesAuftrag.FaLeistungID).BaPersonID;
                var faLeistung = entity.FaLeistung ?? faLeistungService.GetEntityById(kesAuftrag.FaLeistungID);

                var xTask = new XTask
                {
                    TaskSenderCode = (int)LOVsGenerated.TaskSender.DbScript,
                    TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                    TaskTypeCode = taskType.Code,
                    TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                    CreateDate = DateTime.Today,
                    FaFallID = faLeistung.FaFallID,
                    ExpirationDate = DateTime.Today.AddDays(daysToAdd),
                    Subject = taskType.Value1,
                    TaskDescription = taskType.Value2,
                    FaLeistungID = kesAuftrag.FaLeistungID,
                    BaPersonID = baPersonID,
                    ReceiverID = faLeistung.UserID,
                    JumpToPath = string.Format(
                           "ClassName=FrmFall;ModulID=29;BaPersonID={0};TreeNodeID=Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{1}/Kiss.UserInterface.View.Kes.KesAuftragView,Kiss.UserInterface.View;FindEntity=\"KesAuftrag.KesAuftragID={2}\";SelectedTabIndex=\"1\"",
                           baPersonID,
                           kesAuftrag.FaLeistungID,
                           kesAuftrag.KesAuftragID)
                };

                xTaskAutoGenerated = new XTaskAutoGenerated
                {
                    XTask = xTask,
                    ReferenceTable = typeof(KesDokument).Name,
                    ReferenceID = entity.KesDokumentID,
                    XTaskAutoGeneratedTypeCode = (int)LOVsGenerated.XTaskAutoGeneratedType.KesFrist
                };

                SaveEntity(xTaskAutoGenerated);

                // Pendenzen mit den Fristen aktualisieren, weil diese generierten Pendenzen
                // geschlossen werden sobald ein Versand-Dokument eingefügt wird.
                UpdateKesAuftragFristBisPendenz(kesAuftrag);
            }
        }

        /// <summary>
        /// Wenn im Kes-Auftrag eine Frist-Bis im Register Abklärung/Auftrag gesetzt wird, wünscht sich der Kunde die Generierung einer Pendenz.
        /// Diese wird als Erledigt markiert falls ein Versand-Dokument (Register Bearbeitung) eingfügt wird.
        /// Es wird synchron zum DatumFrist gehalten, deswegen wird die Pendenz auch gelöscht und upgedated.
        /// </summary>
        /// <param name="entity">KesAuftrag</param>
        public void UpdateKesAuftragFristBisPendenz(KesAuftrag entity)
        {
            XTaskAutoGenerated xTaskAutoGenerated;

            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_ErledigungSD_Aktiv));

            if (!pendenzAktiv || entity == null)
            {
                return;
            }

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(typeof(KesAuftrag).Name, entity.KesAuftragID);
            }

            var kesDocumentService = Container.Resolve<KesDokumentService>();
            var hasAnyVersandDokumente = kesDocumentService.GetByKesAuftragId(entity.KesAuftragID, (int)LOVsGenerated.KesDokumentTyp.AuftragDokument, false)
                                                           .Any(dok => dok.WrappedEntity.XDocumentID_Versand != null);

            if (xTaskAutoGenerated == null && entity.DatumFrist != null)
            {
                var xLovService = Container.Resolve<XLovService>();
                var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                                          .First(lov => lov.Code == (int)LOVsGenerated.TaskType.FristablaufAbklaerungAuftragErledigungSd);

                var faLeistungService = Container.Resolve<FaLeistungService>();
                var faLeistung = entity.FaLeistung ?? faLeistungService.GetEntityById(entity.FaLeistungID);

                var xTask = new XTask
                {
                    TaskSenderCode = (int)LOVsGenerated.TaskSender.DbScript,
                    TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                    TaskTypeCode = taskType.Code,
                    TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                    CreateDate = DateTime.Today,
                    FaFallID = faLeistung.FaFallID,
                    ExpirationDate = entity.DatumFrist,
                    Subject = taskType.Value1,
                    TaskDescription = taskType.Value2,
                    BaPersonID = faLeistung.BaPersonID,
                    ReceiverID = faLeistung.UserID,
                    FaLeistungID = entity.FaLeistungID,
                    JumpToPath = string.Format(
                                           "ClassName=FrmFall;ModulID=29;BaPersonID={0};TreeNodeID=Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{1}/Kiss.UserInterface.View.Kes.KesAuftragView,Kiss.UserInterface.View;FindEntity=\"KesAuftrag.KesAuftragID={2}\";SelectedTabIndex=\"0\"",
                                           faLeistung.BaPersonID,
                                           entity.FaLeistungID,
                                           entity.KesAuftragID)
                };

                xTaskAutoGenerated = new XTaskAutoGenerated
                {
                    XTask = xTask,
                    ReferenceTable = typeof(KesAuftrag).Name,
                    ReferenceID = entity.KesAuftragID,
                    XTaskAutoGeneratedTypeCode = (int)LOVsGenerated.XTaskAutoGeneratedType.KesFrist
                };

                SaveEntity(xTaskAutoGenerated);
            }
            else if (xTaskAutoGenerated != null
                && xTaskAutoGenerated.XTask.DoneDate == null
                && entity.DatumFrist == null)
            {
                DeleteEntity(xTaskAutoGenerated);

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.DeleteEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && !entity.DatumFrist.Equals(xTaskAutoGenerated.XTask.ExpirationDate))
            {
                xTaskAutoGenerated.XTask.ExpirationDate = entity.DatumFrist;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && hasAnyVersandDokumente)
            {
                xTaskAutoGenerated.XTask.DoneDate = DateTime.Now;
                xTaskAutoGenerated.XTask.TaskStatusCode = (int)LOVsGenerated.TaskStatus.Erledigt;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
        }

        /// <summary>
        /// Wenn in der KesMassnahmeAuftrag ein Dokument Versand im Register Aufträge/Anträge eingefügt wird, wünscht sich der Kunde die Generierung einer Pendenz.
        /// Diese wird als Erledigt markiert falls ein Verfügung-Kesb-Dokument (derselbe Datensatz) eingfügt wird.
        /// Es wird synchron zum Dokument Versand gehalten, deswegen wird die Pendenz auch gelöscht und upgedated.
        /// </summary>
        /// <param name="entity">KesMassnahmeAuftrag</param>
        public void UpdateKesMassnahmeAuftragErledigungPendenz(KesMassnahmeAuftrag entity)
        {
            XTaskAutoGenerated xTaskAutoGenerated;
            var tableName = typeof(KesMassnahmeAuftrag).Name;

            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_MassnahmeAuftragErledigung_Aktiv));

            if (!pendenzAktiv)
            {
                return;
            }

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(tableName, entity.KesMassnahmeAuftragID, (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeErledigung);
            }

            if (xTaskAutoGenerated == null && entity.ErledigungBis.HasValue)
            {
                // Create new Pendenz
                var xLovService = Container.Resolve<XLovService>();
                var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                                          .First(lov => lov.Code == (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeErledigung);

                var kesMassnahmeService = Container.Resolve<KesMassnahmeService>();
                var faLeistungService = Container.Resolve<FaLeistungService>();
                var kesMassnahme = kesMassnahmeService.GetEntityById(entity.KesMassnahmeID);
                var faLeistung = faLeistungService.GetEntityById(kesMassnahme.FaLeistungID);

                var xTask = new XTask
                {
                    TaskSenderCode = (int)LOVsGenerated.TaskSender.DbScript,
                    TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                    TaskTypeCode = taskType.Code,
                    TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                    CreateDate = DateTime.Today,
                    FaFallID = faLeistung.FaFallID,
                    ExpirationDate = entity.ErledigungBis.Value,
                    Subject = taskType.Value1,
                    TaskDescription = taskType.Value2,
                    FaLeistungID = faLeistung.FaLeistungID,
                    BaPersonID = faLeistung.BaPersonID,
                    ReceiverID = faLeistung.UserID,
                    JumpToPath = string.Format(
                           "ClassName=FrmFall;ModulID=29;BaPersonID={0};TreeNodeID=Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{1}/Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View;FindEntity=\"KesMassnahme.KesMassnahmeID={2}\";SelectedTabIndex=\"3\"",
                           faLeistung.BaPersonID,
                           faLeistung.FaLeistungID,
                           entity.KesMassnahmeID)
                };

                xTaskAutoGenerated = new XTaskAutoGenerated
                {
                    XTask = xTask,
                    ReferenceTable = tableName,
                    ReferenceID = entity.KesMassnahmeAuftragID,
                    XTaskAutoGeneratedTypeCode = (int)LOVsGenerated.XTaskAutoGeneratedType.KesFrist
                };

                SaveEntity(xTaskAutoGenerated);
            }
            else if (xTaskAutoGenerated != null
                && xTaskAutoGenerated.XTask.TaskTypeCode == (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeErledigung
                && xTaskAutoGenerated.XTask.DoneDate == null
                && !entity.ErledigungBis.HasValue)
            {
                DeleteEntity(xTaskAutoGenerated);

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.DeleteEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.TaskTypeCode == (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeErledigung
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && entity.ErledigungBis.HasValue
                     && xTaskAutoGenerated.XTask.ExpirationDate.HasValue
                     && entity.ErledigungBis.Value != xTaskAutoGenerated.XTask.ExpirationDate.Value)
            {
                xTaskAutoGenerated.XTask.ExpirationDate = entity.ErledigungBis.Value;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
        }

        /// <summary>
        /// Wenn in der KesMassnahmeAuftrag ein Dokument Versand im Register Aufträge/Anträge eingefügt wird, wünscht sich der Kunde die Generierung einer Pendenz.
        /// Diese wird als Erledigt markiert falls ein Verfügung-Kesb-Dokument (derselbe Datensatz) eingfügt wird.
        /// Es wird synchron zum Dokument Versand gehalten, deswegen wird die Pendenz auch gelöscht und upgedated.
        /// </summary>
        /// <param name="entity">KesMassnahmeAuftrag</param>
        public void UpdateKesMassnahmeAuftragVersandPendenz(KesMassnahmeAuftrag entity)
        {
            XTaskAutoGenerated xTaskAutoGenerated;
            var tableName = typeof(KesMassnahmeAuftrag).Name;

            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_MassnahmeAuftragVersandBericht_Aktiv));
            var tagePendenz = Convert.ToInt32(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_MassnahmeAuftragVersandBericht_AnzahlTage));

            if (!pendenzAktiv)
            {
                return;
            }

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(tableName, entity.KesMassnahmeAuftragID, (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeVersand);
            }

            if (xTaskAutoGenerated == null && entity.DocumentID_Versand != null)
            {
                // Create new Pendenz
                var xLovService = Container.Resolve<XLovService>();
                var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                                          .First(lov => lov.Code == (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeVersand);

                var kesMassnahmeService = Container.Resolve<KesMassnahmeService>();
                var faLeistungService = Container.Resolve<FaLeistungService>();
                var kesMassnahme = kesMassnahmeService.GetEntityById(entity.KesMassnahmeID);
                var faLeistung = faLeistungService.GetEntityById(kesMassnahme.FaLeistungID);

                var xTask = new XTask
                {
                    TaskSenderCode = (int)LOVsGenerated.TaskSender.DbScript,
                    TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                    TaskTypeCode = taskType.Code,
                    TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                    CreateDate = DateTime.Today,
                    FaFallID = faLeistung.FaFallID,
                    ExpirationDate = DateTime.Today.AddDays(tagePendenz),
                    Subject = taskType.Value1,
                    TaskDescription = taskType.Value2,
                    FaLeistungID = faLeistung.FaLeistungID,
                    BaPersonID = faLeistung.BaPersonID,
                    ReceiverID = faLeistung.UserID,
                    JumpToPath = string.Format(
                           "ClassName=FrmFall;ModulID=29;BaPersonID={0};TreeNodeID=Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{1}/Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View;FindEntity=\"KesMassnahme.KesMassnahmeID={2}\";SelectedTabIndex=\"3\"",
                           faLeistung.BaPersonID,
                           faLeistung.FaLeistungID,
                           entity.KesMassnahmeID)
                };

                xTaskAutoGenerated = new XTaskAutoGenerated
                {
                    XTask = xTask,
                    ReferenceTable = tableName,
                    ReferenceID = entity.KesMassnahmeAuftragID,
                    XTaskAutoGeneratedTypeCode = (int)LOVsGenerated.XTaskAutoGeneratedType.KesFrist
                };

                SaveEntity(xTaskAutoGenerated);
            }
            else if (xTaskAutoGenerated != null
                && xTaskAutoGenerated.XTask.TaskTypeCode == (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeVersand
                && xTaskAutoGenerated.XTask.DoneDate == null
                && entity.DocumentID_Versand == null)
            {
                DeleteEntity(xTaskAutoGenerated);

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.DeleteEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.TaskTypeCode == (int)LOVsGenerated.TaskType.FristablaufMassnahmenAuftraegeAntraegeVersand
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && entity.DocumentID_VerfuegungKESB != null)
            {
                xTaskAutoGenerated.XTask.DoneDate = DateTime.Now;
                xTaskAutoGenerated.XTask.TaskStatusCode = (int)LOVsGenerated.TaskStatus.Erledigt;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
        }

        /// <summary>
        /// Wenn in der KesMassnahme ein Datum Periode Bis im Register Berichts- und Rechnungsablage gesetzt wird, wünscht sich der Kunde die Generierung einer Pendenz.
        /// Diese wird als Erledigt markiert falls ein Versand-Dokument (derselbe Datensatz) eingfügt wird.
        /// Es wird synchron zum Datum Periode Bis gehalten, deswegen wird die Pendenz auch gelöscht und upgedated.
        /// </summary>
        /// <param name="entity">KesMassnahmeBericht</param>
        public void UpdateKesMassnahmePeriodeBisPendenz(KesMassnahmeBericht entity)
        {
            XTaskAutoGenerated xTaskAutoGenerated;

            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_MassnahmePeriode_Aktiv));

            if (!pendenzAktiv)
            {
                return;
            }

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(typeof(KesMassnahmeBericht).Name, entity.KesMassnahmeBerichtID);
            }

            if (xTaskAutoGenerated == null && entity.DatumBis != null)
            {
                var xLovService = Container.Resolve<XLovService>();
                var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                                          .First(lov => lov.Code == (int)LOVsGenerated.TaskType.FristablaufMassnahmenBerichtsUndRechnungsablageVersand);

                var kesMassnahmeService = Container.Resolve<KesMassnahmeService>();
                var faLeistungService = Container.Resolve<FaLeistungService>();
                var kesMassnahme = kesMassnahmeService.GetEntityById(entity.KesMassnahmeID);
                var faLeistung = faLeistungService.GetEntityById(kesMassnahme.FaLeistungID);

                var xTask = new XTask
                {
                    TaskSenderCode = (int)LOVsGenerated.TaskSender.DbScript,
                    TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                    TaskTypeCode = taskType.Code,
                    TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                    CreateDate = DateTime.Today,
                    FaFallID = faLeistung.FaFallID,
                    ExpirationDate = entity.DatumBis,
                    FaLeistungID = faLeistung.FaLeistungID,
                    Subject = taskType.Value1,
                    TaskDescription = taskType.Value2,
                    BaPersonID = faLeistung.BaPersonID,
                    ReceiverID = faLeistung.UserID,
                    JumpToPath = string.Format(
                           "ClassName=FrmFall;ModulID=29;BaPersonID={0};TreeNodeID=Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{1}/Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View;FindEntity=\"KesMassnahme.KesMassnahmeID={2}\";SelectedTabIndex=\"2\"",
                           faLeistung.BaPersonID,
                           faLeistung.FaLeistungID,
                           entity.KesMassnahmeID)
                };

                xTaskAutoGenerated = new XTaskAutoGenerated
                {
                    XTask = xTask,
                    ReferenceTable = typeof(KesMassnahmeBericht).Name,
                    ReferenceID = entity.KesMassnahmeBerichtID,
                    XTaskAutoGeneratedTypeCode = (int)LOVsGenerated.XTaskAutoGeneratedType.KesFrist
                };

                SaveEntity(xTaskAutoGenerated);
            }
            else if (xTaskAutoGenerated != null
                && xTaskAutoGenerated.XTask.DoneDate == null
                && entity.DatumBis == null)
            {
                DeleteEntity(xTaskAutoGenerated);

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.DeleteEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && !entity.DatumBis.Equals(xTaskAutoGenerated.XTask.ExpirationDate))
            {
                xTaskAutoGenerated.XTask.ExpirationDate = entity.DatumBis;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && entity.DocumentID_Versand != null)
            {
                xTaskAutoGenerated.XTask.DoneDate = DateTime.Now;
                xTaskAutoGenerated.XTask.TaskStatusCode = (int)LOVsGenerated.TaskStatus.Erledigt;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
        }

        /// <summary>
        /// Wenn in der KesMassnahme ein Dokument Versand im Register Berichts- und Rechnungsablage eingefügt wird, wünscht sich der Kunde die Generierung einer Pendenz.
        /// Diese wird als Erledigt markiert falls ein Verfügung-Kesb-Dokument (derselbe Datensatz) eingfügt wird.
        /// Es wird synchron zum Dokument Versand gehalten, deswegen wird die Pendenz auch gelöscht und upgedated.
        /// </summary>
        /// <param name="entity">KesMassnahmeBericht</param>
        public void UpdateKesMassnahmeVersandPendenz(KesMassnahmeBericht entity)
        {
            XTaskAutoGenerated xTaskAutoGenerated;
            var tableName = typeof(KesMassnahmeBericht).Name + "_Versand";

            var xConfigService = Container.Resolve<XConfigService>();
            var pendenzAktiv = Convert.ToBoolean(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_MassnahmeVersandBericht_Aktiv));
            var tagePendenz = Convert.ToInt32(xConfigService.GetConfigValue(ConfigNodes.System_Pendenzen_KesFrist_MassnahmeVersandBericht_AnzahlTage));

            if (!pendenzAktiv)
            {
                return;
            }

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                xTaskAutoGenerated = unitOfWork.XTaskAutoGenerated.GetByReferenceTableAndID(tableName, entity.KesMassnahmeBerichtID);
            }

            if (xTaskAutoGenerated == null && entity.DocumentID_Versand != null)
            {
                // Create new Pendenz
                var xLovService = Container.Resolve<XLovService>();
                var taskType = xLovService.GetLovCodesByLovName(typeof(LOVsGenerated.TaskType).Name)
                                          .First(lov => lov.Code == (int)LOVsGenerated.TaskType.FristablaufMassnahmenBerichtsUndRechnungsablageVerfuegungKesb);

                var kesMassnahmeService = Container.Resolve<KesMassnahmeService>();
                var faLeistungService = Container.Resolve<FaLeistungService>();
                var kesMassnahme = kesMassnahmeService.GetEntityById(entity.KesMassnahmeID);
                var faLeistung = faLeistungService.GetEntityById(kesMassnahme.FaLeistungID);

                var xTask = new XTask
                {
                    TaskSenderCode = (int)LOVsGenerated.TaskSender.DbScript,
                    TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                    TaskTypeCode = taskType.Code,
                    TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                    CreateDate = DateTime.Today,
                    FaFallID = faLeistung.FaFallID,
                    ExpirationDate = DateTime.Today.AddDays(tagePendenz),
                    Subject = taskType.Value1,
                    TaskDescription = taskType.Value2,
                    FaLeistungID = faLeistung.FaLeistungID,
                    BaPersonID = faLeistung.BaPersonID,
                    ReceiverID = faLeistung.UserID,
                    JumpToPath = string.Format(
                           "ClassName=FrmFall;ModulID=29;BaPersonID={0};TreeNodeID=Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{1}/Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View;FindEntity=\"KesMassnahme.KesMassnahmeID={2}\";SelectedTabIndex=\"2\"",
                           faLeistung.BaPersonID,
                           faLeistung.FaLeistungID,
                           entity.KesMassnahmeID)
                };

                xTaskAutoGenerated = new XTaskAutoGenerated
                {
                    XTask = xTask,
                    ReferenceTable = tableName,
                    ReferenceID = entity.KesMassnahmeBerichtID,
                    XTaskAutoGeneratedTypeCode = (int)LOVsGenerated.XTaskAutoGeneratedType.KesFrist
                };

                SaveEntity(xTaskAutoGenerated);
            }
            else if (xTaskAutoGenerated != null
                && xTaskAutoGenerated.XTask.DoneDate == null
                && entity.DocumentID_Versand == null)
            {
                DeleteEntity(xTaskAutoGenerated);

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.DeleteEntity(xTaskAutoGenerated.XTask);
            }
            else if (xTaskAutoGenerated != null
                     && xTaskAutoGenerated.XTask.DoneDate == null
                     && entity.DocumentID_VerfuegungKESB != null)
            {
                xTaskAutoGenerated.XTask.DoneDate = DateTime.Now;
                xTaskAutoGenerated.XTask.TaskStatusCode = (int)LOVsGenerated.TaskStatus.Erledigt;

                var xtaskService = Container.Resolve<XTaskService>();
                xtaskService.SaveEntity(xTaskAutoGenerated.XTask);
            }
        }
    }
}