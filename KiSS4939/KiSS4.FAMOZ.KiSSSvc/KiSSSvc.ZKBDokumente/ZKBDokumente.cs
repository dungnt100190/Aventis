using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

using iTextSharp.text.pdf;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.Logging;

namespace KiSSSvc.ZKBDokumente
{
    public class ZKBDokumente
    {
        /// <summary>
        /// Auszug aus der ZKB-Spezifikation V0.4 (Stand 14.5.2011)
        /// Die Metadaten werden im Feld „Keywords“ implementiert. Jeder Wert der Metadaten wird mit einer eindeutigen Id und einem Label ergänzt.
        /// Id, Label und Wert werden durch Doppelpunkt (:) getrennt. (Bsp. 007000012:GeschaeftsNr:1234-0123.456). Die ID besteht aus 9 Ziffern.
        /// Die einzelnen Elemente Id:Label:Wert werden jeweils durch einen Strichpunkt (;) getrennt. Die Metadaten werden mit einem Strichpunkt abgeschlossen.
        /// Bsp:
        ///         007000012:GeschaeftsNr:1116-0123.456;007000026:PartnerNr:1.234.567;
        /// </summary>
        /// <param name="metaDataString"></param>
        /// <returns></returns>
        public static string ExtractMetadata(string metaDataString, string label)
        {
            string[] nvpairs = metaDataString.Split(';');

            foreach (string nvpair in nvpairs)
            {
                if (nvpair.Contains(label))
                {
                    string value;

                    try
                    {
                        string[] fields = nvpair.Split(':');
                        if (fields.Length != 3)
                        {
                            Log.Warn(
                                    MethodBase.GetCurrentMethod().ReflectedType,
                                    string.Format("Fehler beim Parsen des Metadaten-Strings '{0}': Es sind nicht genau 3 Felder mit ':' getrennt für das Label {1}", metaDataString, label));
                            value = "";
                        }
                        else
                        {
                            value = fields[2];
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(
                                    MethodBase.GetCurrentMethod().ReflectedType,
                                    string.Format("Fehler beim Parsen des Metadaten-Strings '{0}', gesucht war das label {1}: {2}", metaDataString, label, ex));
                        value = "";
                    }

                    return value;
                }
            }

            return "";
        }

        public static string ImportiereZKBDokumente(int? minSize)
        {
            string pfadFuerKontoauszuege = ConfigurationManager.AppSettings["ZKBDokumentePfadFuerKontoauszuege"];
            string pfadFuerBelastungen = ConfigurationManager.AppSettings["ZKBDokumentePfadFuerBelastungen"];
            string pfadFuerGutschriften = ConfigurationManager.AppSettings["ZKBDokumentePfadFuerGutschriften"];

            var result = new StringBuilder();

            // Kontoauszug
            Log.Info(
                MethodBase.GetCurrentMethod().ReflectedType,
                string.Format("Start des ZKB Kontoauszug-Imports von '{0}'", pfadFuerKontoauszuege));
            result.AppendLine(ImportiereDokumente(pfadFuerKontoauszuege, 1, minSize));

            // Belastungsanzeige
            Log.Info(
                MethodBase.GetCurrentMethod().ReflectedType,
                string.Format("Start des ZKB Belastungen-Imports von '{0}'", pfadFuerBelastungen));
            result.AppendLine(ImportiereDokumente(pfadFuerBelastungen, 2, minSize));

            // Gutschriftanzeige
            Log.Info(
                MethodBase.GetCurrentMethod().ReflectedType,
                string.Format("Start des ZKB Gutschriften-Imports von '{0}'", pfadFuerGutschriften));
            result.AppendLine(ImportiereDokumente(pfadFuerGutschriften, 3, minSize));

            Log.Info(
                MethodBase.GetCurrentMethod().ReflectedType,
                "Import der ZKB-Dokumente abgeschlossen");

            var resultString = result.ToString();
            return string.IsNullOrWhiteSpace(resultString) ? null : resultString;
        }

        /// <summary>
        /// Importiert PDF Dokumente von der ZKB.
        /// </summary>
        /// <param name="pfad">
        ///   Pfad, wo sich die Dokumente befinden.
        /// </param>
        /// <param name="docType">
        /// 1: Kontoauszüge
        /// 2: Belastungen
        /// 3: Gutschriften
        /// </param>
        /// <param name="minSize">Minimalgrösse eines Dokuments, welches importiert wird (Bytes).</param>
        private static string ImportiereDokumente(string pfad, int docType, int? minSize = null)
        {
            FileInfo[] files;
            int processedFileCount = 0;
            minSize = minSize ?? 0;
            var errors = new StringBuilder();

            // Ensure that the C1Zip-DLL is already loaded (otherwise this created Problems with Impersonation later)
            AppDomain.CurrentDomain.Load("C1.C1Zip");

            RestrictedFileAccess restrictedFileAccess = new RestrictedFileAccess();

            try
            {
                restrictedFileAccess.Impersonate();
                var directoryInfo = new DirectoryInfo(pfad);
                files = directoryInfo.GetFiles();
                restrictedFileAccess.RevertToSelf();

                Log.Info(
                    MethodBase.GetCurrentMethod().ReflectedType,
                    string.Format("Im Verzeichnis '{0}' liegen {1} Dateien.", pfad, files.Length));
            }
            catch (Exception ex)
            {
                var message = string.Format("Fehler beim Auslesen des ZKB-Dokument-Verzeichnisses '{0}'.", pfad);
                Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message, ex);

                return string.Format("{0} - {1}", message, ex);
            }
            finally
            {
                restrictedFileAccess.RevertToSelf();
            }

            SstZKBDokumenteTableAdapter adapter = new SstZKBDokumenteTableAdapter();
            adapter.InitializeKiSSAdapter(null);

            PdfReader reader = null;
            FileStream stream = null;
            string fullpath = "";

            foreach (var file in files)
            {
                bool singleFileImportCompletedSuccessfully = false;
                int? docID = null;
                try
                {
                    if (file.Extension == null || !file.Extension.Equals(".pdf", StringComparison.InvariantCultureIgnoreCase))
                    {
                        errors.AppendLine(string.Format("Die Datei '{0}' ist keine PDF-Datei und wird nicht importiert.", file.FullName));
                        continue;
                    }

                    if (minSize.Value > 0 && file.Length < minSize.Value)
                    {
                        errors.AppendLine(
                            string.Format(
                                "Die Datei '{0}' mit Grösse {1} Bytes unterschreitet die minimale Grösse von {2} Bytes und wird nicht importiert.",
                                file.FullName,
                                file.Length,
                                minSize.Value));
                        continue;
                    }

                    fullpath = file.FullName;

                    // Lese die Kontonummer aus den PDF-Metadaten
                    Dictionary<string, string> metaData;
                    try
                    {
                        restrictedFileAccess.Impersonate();

                        //Eventuell braucht man es später.
                        reader = new PdfReader(fullpath);
                        metaData = reader.Info;
                    }
                    catch (Exception ex)
                    {
                        var message = string.Format("Die Datei '{0}' konnte nicht als PDF gelesen werden und wird nicht importiert.", fullpath);
                        Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message, ex);
                        errors.AppendLine(message);
                        continue;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                            reader = null;
                        }

                        restrictedFileAccess.RevertToSelf();
                    }

                    if (!metaData.ContainsKey("Keywords"))
                    {
                        // Das PDF hat keine Keywords-Metadaten, wir können das Dokument nicht zuordnen
                        var message =
                            string.Format(
                                "Fehler beim Auslesen der PDF-Metadaten aus dem ZKB-Dokument '{0}': Die Metadaten 'Keywords' existieren nicht.",
                                fullpath);
                        Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message);
                        errors.AppendLine(message);
                        continue;
                    }

                    string keywords = metaData["Keywords"];

                    string geschaeftsNr = ExtractMetadata(keywords, "GeschaeftsNr");
                    string partnerNr = ExtractMetadata(keywords, "PartnerNr");
                    DateTime belegDatum = Convert.ToDateTime(ExtractMetadata(keywords, "BelegDatum"));

                    if (string.IsNullOrEmpty(geschaeftsNr))
                    {
                        var message =
                            string.Format(
                                "Fehler beim Auslesen der PDF-Metadaten aus dem ZKB-Dokument '{0}': Die Metadaten konnten nicht vollständig ausgelesen werden.",
                                fullpath);
                        Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message);
                        errors.AppendLine(message);
                        continue;
                    }

                    string filename;

                    byte[] tmpMemoryBuffer;

                    try
                    {
                        restrictedFileAccess.Impersonate();

                        // Nun lese das Dokument als Binärstream ein und speichere es in der DB
                        stream = File.OpenRead(fullpath);

                        tmpMemoryBuffer = new byte[stream.Length];

                        stream.Read(tmpMemoryBuffer, 0, (int)stream.Length);

                        // Stelle sicher, dass wir max. 100 Zeichen des Filenames übergeben
                        filename = Path.GetFileName(fullpath);
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                            stream = null;
                        }

                        restrictedFileAccess.RevertToSelf();
                    }

                    //Während der Impersonalisierung kann nicht auf die ZIP Library zugegriffen werden, da der User keinen Zugriff auf diese DLL hat.
                    //Zippen findet unter dem standard User statt.
                    MemoryStream outputMemoryStream = new MemoryStream(tmpMemoryBuffer);
                    var doc = Zip.CompressData(outputMemoryStream);

                    if (filename.Length > 100)
                    {
                        filename = filename.Substring(filename.Length - 100);
                    }

                    // Speichere das Dokument
                    docID = adapter.spSstZKBDokumentSave(docType, filename, geschaeftsNr, partnerNr, doc, belegDatum) as int?;

                    if (docID == null)
                    {
                        var message =
                            string.Format(
                                "Fehler beim Importieren des ZKB-Dokuments '{0}', die Stored Procedure spSstZKBDokumentSave gab keine XDocumentID zurück.",
                                fullpath);
                        Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message);
                        errors.AppendLine(message);
                        continue;
                    }

                    if (docID == -1)
                    {
                        Log.Warn(
                            MethodBase.GetCurrentMethod().ReflectedType,
                            string.Format(
                                "Warnung beim Importieren des ZKB-Dokuments '{0}': Das Dokument existiert bereits in der Datenbank und wird daher nicht nochmals importiert.",
                                fullpath));
                        continue;
                    }

                    singleFileImportCompletedSuccessfully = true;
                    processedFileCount++;
                }
                catch (Exception ex)
                {
                    var message = string.Format("Fehler beim Importieren des ZKB-Dokuments '{0}':", fullpath);
                    Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message, ex);
                    errors.AppendLine(string.Format("{0} - {1}", message, ex));
                }

                if (singleFileImportCompletedSuccessfully)
                {
                    // Wenn das Dokument vollständig verarbeitet werden konnte, wird es nun noch gelöscht von der Disk
                    Log.Info(
                        MethodBase.GetCurrentMethod().ReflectedType,
                        string.Format("ZKB-Dokument wurde erfolgreich importiert mit XDocumentID={0}: {1}", docID, fullpath));

                    try
                    {
                        try
                        {
                            restrictedFileAccess.Impersonate();
                            File.Delete(fullpath);
                        }
                        finally
                        {
                            restrictedFileAccess.RevertToSelf();
                        }
                    }
                    catch (Exception ex)
                    {
                        var message =
                            string.Format(
                                "Fehler beim Löschen der temporären Datei '{0}' (Das ZKB-Dokument wurde bereits vollständig importiert).",
                                fullpath);
                        Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message, ex);
                        errors.AppendLine(string.Format("{0} - {1}", message, ex));
                    }
                }
            }

            try
            {
                // Verarbeite die importierten Dokumente
                adapter.spSstZKBDokumenteZuordnen();
            }
            catch (Exception ex)
            {
                var message = "Fehler beim Zuordnen der importierten ZKB-Dokumente.";
                Log.Error(MethodBase.GetCurrentMethod().ReflectedType, message, ex);
                errors.AppendLine(string.Format("{0} - {1}", message, ex));
            }

            var msg = string.Format(
                "Ende des Imports aus dem Pfad '{0}': {1} von {2} Dateien wurden vollständig importiert.",
                pfad,
                processedFileCount,
                files.Length);
            Log.Info(MethodBase.GetCurrentMethod().ReflectedType, msg);

            if (processedFileCount != files.Length)
            {
                errors.AppendLine(msg);
            }

            return errors.ToString();
        }
    }
}