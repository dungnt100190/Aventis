using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Interfaces.BL.KissSystem
{
    public interface IXConfigService
    {
        /// <summary>
        /// TODO: This is a very minimalistic implementation.
        /// </summary>
        /// <typeparam name="T">The type of the property, for example string or int</typeparam>
        /// <param name="unitOfWork"></param>
        /// <param name="keyPath"></param>
        /// <returns></returns>
        T GetConfigValue<T>(IUnitOfWork unitOfWork, string keyPath);
    }
}
