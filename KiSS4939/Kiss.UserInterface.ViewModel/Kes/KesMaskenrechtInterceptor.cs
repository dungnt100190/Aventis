using System.Threading.Tasks;

using Kiss.BusinessLogic.Kes;
using Kiss.DbContext.DTO.KissSystem;
using Kiss.Interfaces.UI;

using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesMaskenrechtInterceptor : IViewRightInterceptor
    {
        private readonly int _faLeistungId;

        public KesMaskenrechtInterceptor(int faLeistungId)
        {
            _faLeistungId = faLeistungId;
        }

        public async Task<IViewRight> GetViewRight()
        {
            var maskenRecht = new MaskenRechtDTO();
            var kesLeistungService = Container.Resolve<KesLeistungService>();
            var leistung = kesLeistungService.GetEntityById(_faLeistungId);

            if (leistung == null || leistung.DatumBis != null)
            {
                maskenRecht.CanDelete = false;
                maskenRecht.CanInsert = false;
                maskenRecht.CanUpdate = false;
            }
            else
            {
                maskenRecht.CanDelete = true;
                maskenRecht.CanInsert = true;
                maskenRecht.CanUpdate = true;
            }

            return maskenRecht;
        }
    }
}