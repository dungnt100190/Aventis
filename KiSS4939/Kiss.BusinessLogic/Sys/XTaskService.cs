using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Sys
{
    public class XTaskService : ServiceCRUD<XTask>
    {
        private XTaskService()
        {
        }

        public XTask GetLetztePendenteGastrechtAnfrage(int faLeistungID, int xUserIDSender, int xUserIDReceiver)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.XTask.GetLetztePendenteGastrechtAnfrage(faLeistungID, xUserIDSender, xUserIDReceiver);
            }
        }
    }
}