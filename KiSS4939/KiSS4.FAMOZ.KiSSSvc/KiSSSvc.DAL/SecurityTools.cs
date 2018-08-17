using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions;

namespace KiSSSvc.DAL
{
    public class SecurityTools
    {
        public enum LogonType : int
        {
            LOGON32_LOGON_INTERACTIVE = 2,
            LOGON32_LOGON_NETWORK = 3,
            LOGON32_LOGON_BATCH = 4,
            LOGON32_LOGON_SERVICE = 5,
            LOGON32_LOGON_UNLOCK = 7,
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,	// Only for Win2K or higher
            LOGON32_LOGON_NEW_CREDENTIALS = 9		// Only for Win2K or higher
        };

        public enum LogonProvider : int
        {
            LOGON32_PROVIDER_DEFAULT = 0,
            LOGON32_PROVIDER_WINNT35 = 1,
            LOGON32_PROVIDER_WINNT40 = 2,
            LOGON32_PROVIDER_WINNT50 = 3
        };

        class AdvAPI32
        {

            /// <summary>
            /// see http://msdn.microsoft.com/en-us/library/windows/desktop/aa378184%28v=vs.85%29.aspx
            /// </summary>
            /// <param name="lpszUsername"></param>
            /// <param name="lpszDomain"></param>
            /// <param name="lpszPassword"></param>
            /// <param name="dwLogonType"></param>
            /// <param name="dwLogonProvider"></param>
            /// <param name="TokenHandle"></param>
            /// <returns></returns>
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
                int dwLogonType, int dwLogonProvider, ref IntPtr TokenHandle);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public extern static bool CloseHandle(IntPtr handle);

            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
                int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

            [DllImport("advapi32.dll", SetLastError = true)]
            public extern static int RevertToSelf();
        }

        public static void RevertToSelf()
        {
            AdvAPI32.RevertToSelf();
        }


        /// <summary>        
        /// http://msdn.microsoft.com/en-us/library/w070t6ka.aspx
        /// </summary>
        /// <param name="sUsername"></param>
        /// <param name="sDomain"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public static WindowsImpersonationContext
            ImpersonateUser(string sUsername, string sDomain, string sPassword)
        {
            // initialize tokens

            IntPtr pExistingTokenHandle = new IntPtr(0);
            IntPtr pDuplicateTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            pDuplicateTokenHandle = IntPtr.Zero;

            // if domain name was blank, assume local machine

            if (sDomain == "")
                sDomain = System.Environment.MachineName;

            try
            {
                string sResult = null;

                const int LOGON32_PROVIDER_DEFAULT = 0;

                // create token

                const int LOGON32_LOGON_INTERACTIVE = 2;
                //const int SecurityImpersonation = 2;

                // get handle to token

                bool bImpersonated = AdvAPI32.LogonUser(sUsername, sDomain, sPassword,
                    (int)LogonType.LOGON32_LOGON_INTERACTIVE, (int)LogonProvider.LOGON32_PROVIDER_DEFAULT,
                        ref pExistingTokenHandle);

                // did impersonation fail?

                if (false == bImpersonated)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();

                    // Log the reason why LogonUser failed
                    Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, "LogonUser() failed with error code: " + nErrorCode);
                    return null;
                }

                // Get identity before impersonation

                sResult += "Before impersonation: " +
                    WindowsIdentity.GetCurrent().Name + "\r\n";

                const int securityImpersonation = 2;

                bool bRetVal = AdvAPI32.DuplicateToken(pExistingTokenHandle,
                    securityImpersonation,
                        ref pDuplicateTokenHandle);

                // did DuplicateToken fail?

                if (false == bRetVal)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    // close existing handle

                    AdvAPI32.CloseHandle(pExistingTokenHandle);

                    // log the reason why DuplicateToken failed
                    Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, "DuplicateToken() failed with error code: " + nErrorCode);
                    return null;
                }
                else
                {
                    // create new identity using new primary token

                    WindowsIdentity newId = new WindowsIdentity
                                                (pDuplicateTokenHandle);
                    WindowsImpersonationContext impersonatedUser =
                                                newId.Impersonate();
                    return impersonatedUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close handle(s)

                if (pExistingTokenHandle != IntPtr.Zero)
                    AdvAPI32.CloseHandle(pExistingTokenHandle);
                if (pDuplicateTokenHandle != IntPtr.Zero)
                    AdvAPI32.CloseHandle(pDuplicateTokenHandle);
            }
        }

        public static string Decrypt(string encrypted)
        {
            if (!string.IsNullOrEmpty(encrypted))
            {
                Scrambler scrambler = new Scrambler("KiSS4");
                try
                {
                    return scrambler.DecryptString(encrypted);
                }
                catch
                {
                    return encrypted;
                }
            }
            return null;
        }
    }
}
