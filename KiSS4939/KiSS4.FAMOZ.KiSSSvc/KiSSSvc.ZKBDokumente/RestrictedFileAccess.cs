using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KiSSSvc.DAL;
using System.IO;
using System.Configuration;

namespace KiSSSvc.ZKBDokumente
{

    /// <summary>
    /// Der User vom IIS hat keinen Zugriff auf das File-Share Verzeichnis
    /// mit den PDF Dokumenten der ZKB.
    /// Vor dem Zugriff wird eine Impersonalisierung gemacht.
    /// Username und Passwort sind  in der web.config Datei zu finden.
    /// Keys: ZKBDokumentePfad.username und ZKBDokumentePfad.password
    /// Domäne ist goblal (hardcoded).
    /// http://msdn.microsoft.com/en-us/library/w070t6ka.aspx
    /// </summary>
    public class RestrictedFileAccess
    {
        public string ZKBDokumentePfadUserName
        {
            get
            {
                // Muss im Web.Config konfiguriert sein
                return SecurityTools.Decrypt(ConfigurationManager.AppSettings["ZKBDokumentePfad.username"]);
            }
        }

        public string ZKBDokumentePfadPassword
        {
            get
            {
                // Muss im Web.Config konfiguriert sein
                return SecurityTools.Decrypt(ConfigurationManager.AppSettings["ZKBDokumentePfad.password"]);
            }
        }

        public void Impersonate()
        {
            // Damit wir auf die Verzeichnisse zugreifen können, müssen wir diesen Thread einem anderen UserAccount anmelden
            // 
            // Für Tests und Änderungen: Die Entschlüsselung und Verschlüsselung des Usernamens/Passworts kann mit folgendem Statement im Immediate-Fenster gemacht werden
            //      Verschlüsseln    
            //          new KiSS4.DB.Scrambler("KiSS4").EncryptString("PlainTextPasswort")
            //      Entschlüsseln
            //          new KiSS4.DB.Scrambler("KiSS4").DecryptString("ZG9ETiTRplKmMELlsdf4GwlILfPKROAc")
            //
            SecurityTools.ImpersonateUser(ZKBDokumentePfadUserName, "global", ZKBDokumentePfadPassword);
        }

        public void RevertToSelf()
        {
            SecurityTools.RevertToSelf();
        }
    }
}
