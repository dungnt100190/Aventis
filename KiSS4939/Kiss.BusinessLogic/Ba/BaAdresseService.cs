using System;
using System.Collections.Generic;

using Kiss.BusinessLogic.LocalResources.Ba;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Ba
{
    public class BaAdresseService : ServiceCRUD<BaAdresse>
    {
        public string GetAddressTextMultiline(BaAdresse baAdresse)
        {
            var lines = new List<string>();
            if (baAdresse.Zusatz != null)
            {
                lines.Add(baAdresse.Zusatz);
            }

            if (baAdresse.Strasse != null)
            {
                lines.Add(baAdresse.Strasse + " " + baAdresse.HausNr);
            }

            if (baAdresse.PostfachOhneNr || baAdresse.Postfach != null)
            {
                lines.Add(BaAdresseRes.Postfach + (!baAdresse.PostfachOhneNr ? " " + baAdresse.Postfach : null));
            }

            if (baAdresse.PLZ != null)
            {
                lines.Add(baAdresse.PLZ + " " + baAdresse.Ort);
            }
            return string.Join(Environment.NewLine, lines);
        }

        public virtual BaAdresse GetByBaInstitutionId(int baInstitutionId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaAdresse.GetByBaInstitutionId(baInstitutionId);
            }
        }

        public virtual BaAdresse GetByBapersonId(int bapersonId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaAdresse.GetByBaPersonId(bapersonId);
            }
        }

        public virtual List<BaAdresse> GetByListOfBaInstitutionIds(List<int?> listOfBaInstitutionIds)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaAdresse.GetByListOfBaInstitutionIds(listOfBaInstitutionIds);
            }
        }

        public virtual List<BaAdresse> GetByListOfBapersonId(List<int?> listOfBapersonId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaAdresse.GetByListOfBaPersonIds(listOfBapersonId);
            }
        }

        public virtual BaAdresse GetByUserId(int userId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaAdresse.GetByUserId(userId);
            }
        }
    }
}