using System;
using System.IO;
using System.Net;

namespace Kiss.Infrastructure.IO
{
    /// <summary>
    /// Class to manage web requests
    /// </summary>
    public class WebRequest
    {
        /// <summary>
        /// Gets a <see cref="Stream"/> from the web
        /// </summary>
        /// <param name="address">URI to get the <see cref="Stream"/> from</param>
        /// <returns><see cref="Stream"/> on the downloaded data</returns>
        /// <exception cref="WebRequestException"></exception>
        public static Stream GetStream(string address)
        {
            try
            {
                WebClient webClient = new WebClient();
                Stream stream = new MemoryStream(webClient.DownloadData(address));
                return stream;
            }
            catch (WebException ex)
            {
                throw new WebRequestException("Diese Adresse ist ungültig", ex);
            }
            catch (ArgumentException ex)
            {
                throw new WebRequestException("Diese Adresse ist ungültig", ex);
            }
        }
    }
}