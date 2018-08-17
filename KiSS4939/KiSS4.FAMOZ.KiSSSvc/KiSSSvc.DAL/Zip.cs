using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using C1.C1Zip;

namespace KiSSSvc.DAL
{
    public static class Zip
    {
        // copied from zip.cs, Dokument-Project
        /// <summary>
        /// Compress content of a file
        /// </summary>
        /// <param name="file">FileInfo of the File</param>
        /// <returns>Compressed data in a byte array</returns>
        public static byte[] CompressData(Stream fs)
        {
            // Reset position to the beginning
            fs.Position = 0;

            using (MemoryStream ms = new MemoryStream())
            {
                // attach compressor stream to the stream
                using (C1ZStreamWriter sw = new C1ZStreamWriter(ms))
                {
                    StreamCopy(fs, sw);
                    sw.Close();
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Copies a stream.
        /// </summary>
        /// <param name="srcStream">The source stream.</param>
        /// <param name="dstStream">The destination stream.</param>
        private static void StreamCopy(Stream srcStream, Stream dstStream)
        {
            // --- number of bytes to read in one step
            byte[] buffer = new byte[32768];
            int read;

            while ((read = srcStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                dstStream.Write(buffer, 0, read);
            }

            dstStream.Flush();
        }
    }
}
