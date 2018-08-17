using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.XtraPrinting.Native;
using Kiss.BusinessLogic.LocalResources.System;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.DocumentHandling;

namespace Kiss.BusinessLogic.Sys
{
    /// <summary>
    /// Service to access system configuration
    /// </summary>
    public class XDocumentService : ServiceCRUD<XDocument>
    {
        private string _tempPath;

        private XDocumentService()
        {
            var configService = Container.Resolve<XConfigService>();
            _tempPath = configService.GetConfigValue(ConfigNodes.System_Dokumentemanagement_Temporaerpfad, DateTime.Now);
        }

        public bool CanSaveAsPdf(XDocument document)
        {
            //Zurzeit unterstützt werden Word, Excel und PDF
            switch (document.DocFormatCode)
            {
                case (int)DokFormat.Word:
                case (int)DokFormat.Excel:
                case (int)DokFormat.PDF:
                    return true;

                default:
                    return false;
            }
        }

        public int CopyDocument(int documentId)
        {
            var document = GetEntityById(documentId);
            var copiedDocument = (XDocument)CopyEntity(document);
            copiedDocument.DocumentID = 0;

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                unitOfWork.XDocument.InsertOrUpdateEntity(copiedDocument);
                SaveEntity(copiedDocument);
            }

            return copiedDocument.DocumentID;
        }

        public virtual void DeleteByDocumentIDs(List<int?> ids)
        {
            foreach (var documentId in ids.Where(documentId => documentId != null))
            {
                DeleteEntity((int)documentId);
            }
        }

        public virtual XDocument GetByDocumentID(int documentID)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.XDocument.GetById(documentID);
            }
        }

        public IServiceResult SaveDocumentAs(XDocument document, string fileName)
        {
            try
            {
                //sicherstellen, dass diese Datei nicht bereits existiert
                var file = new FileInfo(fileName);
                file.Delete();
                Zip.ExpandDataToFile(document.FileBinary, file);
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Error(ex);
            }
        }

        public IServiceResult SaveDocumentAsPdf(XDocument document, string fileName, bool disableMessageBox = false)
        {
            try
            {
                if (!Directory.Exists(_tempPath))
                {
                    // Create the directory as it does not exist yet.
                    Directory.CreateDirectory(_tempPath);
                }
            }
            catch //(Exception ex)
            {
                // Didn't like this, so let's use the temporary path instead then
                _tempPath = ConfigNodes.System_Dokumentemanagement_Temporaerpfad.DefaultValue;
            }

            var tempFileName = Path.Combine(_tempPath, document.DocumentID + ".tmp");
            var result = SaveDocumentAs(document, tempFileName);

            if (!result.IsOk)
            {
                return result;
            }

            try
            {
                File.Delete(fileName);

                if (document.DocFormatCode == (int)DokFormat.Word)
                {
                    var wordControl = Container.Resolve<IWordControl>();
                    wordControl.DisableMessageBox = disableMessageBox;
                    wordControl.Open(tempFileName, false, false, false, false, true, null);
                    wordControl.SaveAs(fileName, 17); // 17 = PDF
                    wordControl.CloseActiveDocument();
                    wordControl.Quit();
                }
                else if (document.DocFormatCode == (int)DokFormat.Excel)
                {
                    var excelControl = Container.Resolve<IExcelControl>();
                    excelControl.DisableMessageBox = disableMessageBox;
                    excelControl.OpenWorkbook(tempFileName);
                    excelControl.SaveAs(fileName, 57); // 57 = PDF
                    excelControl.CloseDocument();
                    excelControl.Quit();
                }
                else if (document.DocFormatCode == (int)DokFormat.PDF)
                {
                    File.Move(tempFileName, fileName);
                }

                //try to delete the tempFile
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }

                if (!File.Exists(fileName))
                {
                    return ServiceResult.Error(XDocumentServiceRes.PdfFileNotExists);
                }

                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Error(ex);
            }
        }
    }
}