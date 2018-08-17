using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Kiss.Update
{
    /// <summary>
    /// PInvoke wrapper for CopyEx
    /// http://stackoverflow.com/a/8341945/1511066
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa363852.aspx
    /// </summary>
    public class XCopy
    {
        #region DllImport

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CopyFileEx(
            string lpExistingFileName,
            string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine,
            IntPtr lpData,
            ref Int32 pbCancel,
            CopyFileFlags dwCopyFlags);

        #endregion

        #region Enumerations

        [Flags]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_NO_BUFFERING = 0x00001000,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }

        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }

        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }

        #endregion

        #region Fields

        #region Private Fields

        private string _destination;
        private int _filePercentCompleted;
        private int _isCancelled;
        private Func<bool> _isCancelledFunction;
        private string _source;

        #endregion

        #endregion

        #region Constructors

        private XCopy()
        {
            _isCancelled = 0;
        }

        #endregion

        #region Delegates

        private delegate CopyProgressResult CopyProgressRoutine(
            long TotalFileSize,
            long TotalBytesTransferred,
            long StreamSize,
            long StreamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);

        #endregion

        #region Events

        private event EventHandler Completed;

        private event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        #endregion

        #region Methods

        #region Public Static Methods

        public static void Copy(string source, string destination, bool overwrite, bool nobuffering, Func<bool> isCancelledFunction, EventHandler<ProgressChangedEventArgs> handler)
        {
            new XCopy().CopyInternal(source, destination, overwrite, nobuffering, isCancelledFunction, handler);
        }

        #endregion

        #region Private Methods

        private void CopyInternal(string source, string destination, bool overwrite, bool nobuffering, Func<bool> isCancelledFunction, EventHandler<ProgressChangedEventArgs> handler)
        {
            try
            {
                CopyFileFlags copyFileFlags = CopyFileFlags.COPY_FILE_RESTARTABLE;

                if (!overwrite)
                {
                    copyFileFlags |= CopyFileFlags.COPY_FILE_FAIL_IF_EXISTS;
                }

                if (nobuffering)
                {
                    copyFileFlags |= CopyFileFlags.COPY_FILE_NO_BUFFERING;
                }

                _source = source;
                _destination = destination;
                _isCancelledFunction = isCancelledFunction;

                if (handler != null)
                {
                    ProgressChanged += handler;
                }

                bool result = CopyFileEx(_source, _destination, CopyProgressHandler, IntPtr.Zero, ref _isCancelled, copyFileFlags);
                if (!result)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

            }
            catch (Exception)
            {
                if (handler != null)
                {
                    ProgressChanged -= handler;
                }

                throw;
            }
        }

        private CopyProgressResult CopyProgressHandler(
            long total,
            long transferred,
            long streamSize,
            long streamByteTrans,
            uint dwStreamNumber,
            CopyProgressCallbackReason reason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData)
        {
            if (reason == CopyProgressCallbackReason.CALLBACK_CHUNK_FINISHED)
            {
                OnProgressChanged((transferred / (double)total) * 100.0);
            }

            if (transferred >= total)
            {
                OnCompleted();
            }

            if (_isCancelledFunction != null && _isCancelledFunction())
            {
                _isCancelled = 1;
            }

            return CopyProgressResult.PROGRESS_CONTINUE;
        }

        private void OnCompleted()
        {
            var handler = Completed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnProgressChanged(double percent)
        {
            // only raise an event when progress has changed
            if ((int)percent > _filePercentCompleted)
            {
                _filePercentCompleted = (int)percent;

                var handler = ProgressChanged;
                if (handler != null)
                    handler(this, new ProgressChangedEventArgs(_filePercentCompleted, null));
            }
        }

        #endregion

        #endregion
    }
}