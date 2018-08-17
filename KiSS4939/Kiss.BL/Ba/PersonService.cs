using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Database.Common;
using Kiss.Model;

using Microsoft.Practices.Unity;

namespace Kiss.BL.Ba
{
    public class PersonService : ServiceBase
    {
        public PersonService(IAuthenticatedUser user, IUnityContainer container)
        {
            User = user;
            Container = container;
        }

        public BaPerson GetPerson(int id)
        {
            var rep = Container.Resolve<IRepository<BaPerson>>();
            
            var ret = rep.Where(x => x.BaPersonID == id).SingleOrDefault();

            if (ret == null)
                throw new InvalidOperationException("no person found with id: " + id);

            return ret;
        }

        public IList<BaPerson> GetRelatedPersons(int idPerson)
        {
            return GetPerson(idPerson).BaPerson_Relation.Select(x => x.BaPerson1)
                .Union(GetPerson(idPerson).BaPerson_Relation1.Select(x => x.BaPerson))
                .Distinct()
                .ToList();
        }

        public IQueryable<BaPerson> GetQueryable()
        {
            return Container.Resolve<IRepository<BaPerson>>();//.Where(x => x.Active);
        }

        public BaAdresse GetWohnsitzAddress(BaPerson person, DateTime date)
        {
            return person.BaAdresse.Where(x => x.AdresseCode == 1 && (x.DatumVon ?? DateTime.MinValue) <= date && (x.DatumBis ?? DateTime.MaxValue) >= date).SingleOrDefault();
        }

        public BaPerson_Relation GetRelation(int falltraegerId, int relatedPersonId)
        {
            var rep = Container.Resolve<IRepository<BaPerson_Relation>>();
            var ret = rep.Where(x => (x.BaPersonID_1 == falltraegerId && x.BaPersonID_2 == relatedPersonId) || (x.BaPersonID_1 == relatedPersonId && x.BaPersonID_2 == falltraegerId)).SingleOrDefault();

            if (ret == null)
                throw new InvalidOperationException("no relation found with falltraeger id: " + falltraegerId + " and id: " + relatedPersonId);

            return ret;
        }
    }
}