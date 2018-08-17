using System.Data.Entity;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.Constant;

namespace Kiss.DataAccess.Sys
{
    public class XTaskRepository : Repository<XTask>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public XTaskRepository()
        {
        }

        public XTaskRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new XTaskValidator());
        }

        public XTask[] GetByBaPersonID(int baPersonID)
        {
            return DbSet
                   .Where(tsk => tsk.BaPersonID == baPersonID) //ToDo: nicht FaLeistungID?
                   .Include(tsk => tsk.XUser_Receiver)
                   .Include(tsk => tsk.FaPendenzgruppe_Receiver)
                   .ToArray();
        }

        public XTask GetLetztePendenteGastrechtAnfrage(int faLeistungID, int xUserIDSender, int xUserIDReceiver)
        {
            if (DbSet != null)
            {
                var task = DbSet
                    .Where(tsk => tsk.FaLeistungID == faLeistungID)
                    .Where(tsk => (tsk.TaskTypeCode == (int)LOVsGenerated.TaskType.UnbefristesGastrechtErteilen ||
                                   (tsk.TaskTypeCode == (int)LOVsGenerated.TaskType.BefristesGastrechtErteilen)))
                    .Where(tsk => (tsk.TaskStatusCode == (int)LOVsGenerated.TaskStatus.Pendent ||
                                   tsk.TaskStatusCode == (int)LOVsGenerated.TaskStatus.InBearbeitung))
                    .Where(tsk => tsk.SenderID == xUserIDSender)
                    .Where(tsk => tsk.ReceiverID == xUserIDReceiver)
                    .OrderByDescending(tsk => tsk.ExpirationDate)
                    .FirstOrDefault();
                return task;
            }
            return null;
        }
    }
}