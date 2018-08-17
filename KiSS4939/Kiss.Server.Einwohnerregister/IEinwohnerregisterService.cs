using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;

namespace Kiss.Server.Einwohnerregister
{
    public interface IEinwohnerregisterService
    {
        ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string pid, int xUserId);

        ServiceResult PersonAbmelden(BaEinwohnerregisterPersonStatusDTO dto);

        ServiceResult PersonAnmelden(BaEinwohnerregisterPersonStatusDTO dto);

        ServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(BaEinwohnerregisterPersonSucheDTO personSucheDto, int xUserId);

        ServiceResult ProcessEvents(int packetSize, bool includeFailedEvents);
    }
}