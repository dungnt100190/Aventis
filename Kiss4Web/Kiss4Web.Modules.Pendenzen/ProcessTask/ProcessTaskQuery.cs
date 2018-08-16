using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Modules.Pendenzen.ProcessTask
{
	public class ProcessTaskQuery : Message<bool>
	{
		public int TaskId { get; set; }
		public string ProcessType { get; set; }
		public int? ReceiverId { get; set; }
		public string DescriptionTask { get; set; }
		public string UserId { get; set; }

	}
}
