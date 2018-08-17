using System;

namespace Kiss.Interfaces.BL.Wsh
{
    public interface IWshPositionService : IService
    {
        bool DoPositionenExist(IUnitOfWork unitOfWork, int faLeistungID, int baPersonID, DateTime? datumVon, DateTime? datumBis, bool stichtagInklusive);
    }
}