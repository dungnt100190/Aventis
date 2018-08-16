using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Pendenzen.GetPendenzenDetail
{
	public class PendenzenDetailQuery : Message<PendenzenDetailItem>
	{
		public int TaskId { get; set; }
	}
}
