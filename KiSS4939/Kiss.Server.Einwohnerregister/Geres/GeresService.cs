using System;

using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;

namespace Kiss.Server.Einwohnerregister.Geres
{
    /// <summary>
    /// TODO momentan zu Testzwecken, um zu schauen, ob die Auflösung über das Interface klappt
    /// </summary>
    public class GeresService : EinwohnerregisterService
    {
        public override ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string pid, int xUserId)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult PersonAbmelden(BaEinwohnerregisterPersonStatusDTO fremdsystemID)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult PersonAnmelden(BaEinwohnerregisterPersonStatusDTO fremdsystemID)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(BaEinwohnerregisterPersonSucheDTO personSucheDto, int xUserId)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult ProcessEvents(int packetSize, bool includeFailedEvents)
        {
            throw new NotImplementedException();
        }
    }
}