using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using KiSS4.Schnittstellen.Newod.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Schnittstellen.Test
{
    [TestClass]
    public class NewodPendenzServiceTest
    {
        [TestMethod]
        public void InsertPendenz_JustExecuting()
        {
            //Arrange
            NewodPendenzService service = new NewodPendenzService();

            //Act
            service.InsertPendenz(65141, new List<PropertyInfo>());
        }
    }
}
