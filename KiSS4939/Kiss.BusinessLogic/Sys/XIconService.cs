using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Sys.DTO;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Sys;

namespace Kiss.BusinessLogic.Sys
{
    public class XIconService : Service
    {
        private List<XIcon> _icons;

        public XIconService()
        {
            if (_icons == null)
            {
                LoadModulIcons();
            }
        }

        public virtual List<ModulIconDTO> GetModulIcons(int baPersonId, int? faFallId = null, bool treeExists = false, bool isPi = false)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var personExists = unitOfWork.BaPerson.Exists(baPersonId);

                List<FaFall> faelle = null;

                if (personExists)
                {
                    faelle = faFallId.HasValue ? new List<FaFall> { unitOfWork.FaFall.GetById(faFallId.Value) } : unitOfWork.FaFall.GetByPersonId(baPersonId);
                }

                List<FaLeistung> leistungen = null;
                if (faelle != null)
                {
                    leistungen = unitOfWork.FaLeistung.GetByFaFallIds(faelle.Select(fal => fal.FaFallID).ToList());
                }

                var modulDtoList = unitOfWork.XModul.GetForGotoFall(treeExists)
                    .Select(
                        mdl => new ModulIconDTO
                        {
                            ModulID = mdl.ModulID,
                            ShortName = mdl.ShortName,
                            SortKey = mdl.SortKey,
                            Status = GetXIconStatusForModulId(leistungen, mdl.ModulID, personExists),
                            OrderId = isPi ? (mdl.ModulID == 1 || mdl.ModulID == 2 ? mdl.ModulID : mdl.ModulID + 1) : 1,
                        })
                    .OrderBy(x => x.OrderId)
                    .ThenBy(x => x.SortKey)
                    .ThenBy(x => x.ModulID)
                    .ThenBy(x => x.ShortName)
                    .ToList();

                // Vormundschaft/KES
                var kesModulDto = modulDtoList.FirstOrDefault(x => x.ModulID == 29);
                if (!isPi && kesModulDto != null && leistungen != null && leistungen.Any(x => x.ModulID == 5) && !leistungen.Any(x => x.ModulID == 29))
                {
                    kesModulDto.Status = GetXIconStatusForModulId(leistungen, 5, true);
                }

                if (isPi && treeExists)
                {
                    modulDtoList.Add(
                        new ModulIconDTO
                        {
                            ModulID = 0,
                            ShortName = "",
                            IconId = 0,
                            OrderId = 3,
                            IsDummyIcon = true
                        });

                    modulDtoList = modulDtoList.OrderBy(x => x.OrderId).ToList();
                }

                foreach (var modul in modulDtoList.Where(modul => !modul.IsDummyIcon))
                {
                    modul.IconId = 1000 + (100 * modul.ModulID) + (int)modul.Status;
                    var icon = _icons.SingleOrDefault(ico => ico != null && ico.XIconID == modul.IconId);
                    if (icon != null)
                    {
                        modul.Icon = icon.Icon;
                    }
                }

                return modulDtoList;
            }
        }

        private XIconStatus GetXIconStatusForModulId(IEnumerable<FaLeistung> leistungen, int modulId, bool personExists)
        {
            var modulLeistungen = leistungen.Where(lei => lei.ModulID == modulId).ToList();

            return modulId == 1 && personExists
                       ? XIconStatus.Aktiv
                       : leistungen == null || !modulLeistungen.Any()
                             ? XIconStatus.Leer
                             : modulLeistungen.Any(lei => lei.FaLeistungArchiv.Any())
                                   ? XIconStatus.Archiviert
                                   : modulLeistungen.OrderByDescending(lei => lei.DatumVon).First().DatumBis.HasValue
                                         ? XIconStatus.Geschlossen
                                         : XIconStatus.Aktiv;
        }

        private void LoadModulIcons()
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                _icons = new List<XIcon>();
                var xModulIds = unitOfWork.XModul.GetForGotoFall(false);
                foreach (var modulId in xModulIds)
                {
                    for (var i = 0; i < 4; i++)
                    {
                        _icons.Add(unitOfWork.XIcon.GetById(1000 + (100 * modulId.ModulID) + i));
                    }
                }
            }
        }
    }
}