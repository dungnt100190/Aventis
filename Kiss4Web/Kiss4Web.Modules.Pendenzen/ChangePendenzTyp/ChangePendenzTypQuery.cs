using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Pendenzen.ChangePendenzTyp
{
    public class ChangePendenzTypQuery : Message<ChangePendenzTypItem>
	{
        public int LanguageCode { get; set; }
        public int LovCode { get; set; }
    }
}
