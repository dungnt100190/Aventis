using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.GetPendenzenData
{
    public class GetPendenzenHandler : TypedMessageHandler<GetPendenzenQuery, IEnumerable<PendenzenItem>>
	{
		private readonly SqlConnection _dbConnection;
		
		public GetPendenzenHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<IEnumerable<PendenzenItem>> Handle(GetPendenzenQuery query)
		{
			var userId = query.UserId;

			string searchCommand = GetPendenzenCommand.GetPendenzen;
			if (!string.IsNullOrEmpty(query.ItemType))
			{
				searchCommand += " WHERE ";
				switch (query.ItemType)
				{
					case "1_1": // set load condition of case Meine Pendenzen - fällige
						searchCommand += GetPendenzenCommand.FilterPendenzen_11;
						break;
					case "1_2": // set load condition of case Meine Pendenzen - offene
						searchCommand += GetPendenzenCommand.FilterPendenzen_12;
						break;
					case "1_3": // set load condition of case Meine Pendenzen - in Bearbeitung
						searchCommand += GetPendenzenCommand.FilterPendenzen_13;
						break;
					case "1_4": // set load condition of case Meine Pendenzen - selber erstellte
						searchCommand += GetPendenzenCommand.FilterPendenzen_14;
						break;
					case "1_5": // set load condition of case Meine Pendenzen - erhaltene
						searchCommand += GetPendenzenCommand.FilterPendenzen_15;
						break;
					case "1_6": // set load condition of case Meine Pendenzen - zu visierende
						searchCommand += GetPendenzenCommand.FilterPendenzen_16;
                        break;
                    case "1_7": // set load condition of case Meine Pendenzen - zu visierende
                        searchCommand += GetPendenzenCommand.FilterPendenzen_17;
                        break;
                    case "1_8": // set load condition of case Meine Pendenzen - erledigte
                        searchCommand += GetPendenzenCommand.FilterPendenzen_18;
						break;
					case "2_1": // set load condition of case Erstellte Pendenzen - fällige
						searchCommand += GetPendenzenCommand.FilterPendenzen_21;
						break;
					case "2_2": // set load condition of case Erstellte Pendenzen - offene
						searchCommand += GetPendenzenCommand.FilterPendenzen_22;
						break;
					case "2_3": // set load condition of case Erstellte Pendenzen - allgemeine
						searchCommand += GetPendenzenCommand.FilterPendenzen_23;
						break;
					case "2_4": // set load condition of case Erstellte Pendenzen - zu visierende
						searchCommand += GetPendenzenCommand.FilterPendenzen_24;
                        break;
                    case "2_5": // set load condition of case Erstellte Pendenzen - zu visierende
                        searchCommand += GetPendenzenCommand.FilterPendenzen_25;
                        break;
                    case "2_6": // set load condition of case Erstellte Pendenzen - erledigte
                        searchCommand += GetPendenzenCommand.FilterPendenzen_26;
						break;
				}
                searchCommand += " ORDER BY TSK.CreateDate DESC";

				var data = await _dbConnection.QueryAsync<PendenzenItem>(searchCommand, new { userId });
				var result = data.AsList();
				if (result.Count > 0)
				{
					return result;
				}
			}
			return new List<PendenzenItem>();
		}
	}
}
