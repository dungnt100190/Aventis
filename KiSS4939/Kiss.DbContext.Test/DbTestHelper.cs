using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DbContext.Test
{
    public class DbTestHelper : IDisposable
    {
        private readonly List<object> _deleteOnCleanup = new List<object>();

        public BaPerson Person { get; private set; }
        //public XUser User { get; private set; }
        //public FaLeistung Leistung { get; private set; }
        public HistoryVersion HistoryVersion { get; private set; }

        public DbTestHelper()
        {
            using (var context = new KissContext())
            {
                try
                {
                    HistoryVersion = new HistoryVersion
                    {
                        AppUser = "UnitTest Runner",
                        AppName = "KiSS",
                        HostName = "Host",
                        SystemUser = "SystemUser",
                        dbUser = "dbUser",
                        SessionID = -1,
                        VersionDate = DateTime.Now,
                    };
                    context.HistoryVersion.Add(HistoryVersion);
                    context.SaveChanges(); // Verbindung über Trigger - das merkt DbContext nicht

                    Person = new BaPerson
                    {
                        Name = "UnitTest Nachname",
                        Vorname = "Fritz",
                        Creator = "abc",
                        Created = DateTime.Now,
                        Modifier = "abc",
                        Modified = DateTime.Now,
                    };
                    context.BaPerson.Add(Person);

                    //XUser

                    //Leistung = new FaLeistung
                    //               {
                    //                   BaPersonID = Person.BaPersonID,
                    //                   DatumVon = DateTime.Today
                    //               };
                    //context.FaLeistung.Add(Leistung);

                    context.SaveChanges();

                    //DeleteOnCleanup(HistoryVersion); // kann nicht gelöscht werden
                    DeleteOnCleanup(Person);
                    //DeleteOnCleanup(Leistung);
                }
                catch (DbEntityValidationException ex)
                {
                    var errors = ex.EntityValidationErrors.ToArray();
                }
            }
        }

        public void DeleteOnCleanup(object entity)
        {
            _deleteOnCleanup.Add(entity);
        }

        public void Dispose()
        {
            using (var context = new KissContext())
            {
                foreach (var entity in _deleteOnCleanup)
                {
                    //var dbSet = context.Set(entity.GetType());
                    //if (dbSet != null)
                    //{
                    //    dbSet.Attach(entity);
                    //    dbSet.Remove(entity);
                    //}

                    var key = context.ObjectContext.CreateEntityKey(ComposeEntitySetName(entity), entity);
                    object entityToDelete;
                    if (context.ObjectContext.TryGetObjectByKey(key, out entityToDelete))
                    {
                        context.ObjectContext.DeleteObject(entityToDelete);
                    }
                }
                context.SaveChanges();
            }
        }

        private static string ComposeEntitySetName(object entity)
        {
//            return string.Format("{0}.{1}", typeof(KissContext).Name, entity.GetType().Name); // ToDo: edmx umbenennen
            return string.Format("{0}.{1}", "KiSS_Entities", entity.GetType().Name);
        }


        public static void AssertAreEqual(byte[] expected, byte[] actual, string message = null)
        {
            if (expected.Length != actual.Length)
            {
                throw new AssertFailedException("Arrays sind nicht gleich lang");
            }

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], message);
            }
        }

        public static void AssertRowVersionChanged(byte[] before, byte[] after)
        {
            if (before.Length != 8 && before.Length != after.Length)
            {
                throw new AssertFailedException("RowVersion muss eine 8-Byte-Array sein");
            }
            Assert.IsTrue(RowVersionToNumber(after) > RowVersionToNumber(before));
        }

        private static long RowVersionToNumber(byte[] rowVersion)
        {
            long number = 0;
            var byteSize = byte.MaxValue + 1;
            for (int i = 0; i < rowVersion.Length; i++)
            {
                number += rowVersion[rowVersion.Length - 1 - i] * (long)Math.Pow(byteSize, i);
            }
            return number;
        }
    }

}
