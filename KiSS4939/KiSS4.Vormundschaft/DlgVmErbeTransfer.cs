using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for DlgVmErbeTransfer.
    /// </summary>
    public partial class DlgVmErbeTransfer : KissDialog
    {
        private object _vmSiegelungID;
        private object _vmTestamentID;
        private object _vmErbschaftsdienstID;

        public DlgVmErbeTransfer()
        {
            InitializeComponent();
        }

        public void Init(int faLeistungID, object vmSiegelungID, object vmTestamentID, object vmErbschaftsdienstID)
        {
            _vmSiegelungID = vmSiegelungID;
            _vmTestamentID = vmTestamentID;
            _vmErbschaftsdienstID = vmErbschaftsdienstID;

            string sql = @"
				select  ERB.VmErbeID,
                        Dienst = case 
								 when VSI.VmSiegelungID is not null then 'Siegelung'
							     when VTM.VmTestamentID is not null then 'Testament'
								 when VED.VmErbschaftsdienstID is not null then 'Erbschaft'
								 end,
						Nr =     case 
								 when VSI.VmSiegelungID is not null then convert(varchar,VSI.BezirkNr) + '-' + 
																		 convert(varchar,VSI.LaufNr) + '-' + 
																		 convert(varchar,VSI.Jahr)
								 when VTM.VmTestamentID is not null then convert(varchar,VTM.LaufNr)
								 when VED.VmErbschaftsdienstID is not null then convert(varchar,VED.LaufNr) + '-' + 
																				convert(varchar,VED.Jahr)
								 end,
						Text =   space(Level*8) +
		                         case when Titel is not null or Titel2 is not null
							     then isnull(Titel + ' ','') + isnull(Titel2,'')
							     else isnull(Anrede + ' ','') + isnull(FamilienNamen + ' ','') + isnull(Vornamen,'') +
									  isnull(', ' + Geburtsdatum,'') +
									  isnull(', ' + Strasse,'') + isnull(', ' + Ort,'') + isnull(', ' + Land,'') +
									  isnull(', ' + Ergaenzung,'')
								 end
				from    VmErbe ERB
                        left join VmSiegelung        VSI on VSI.VmSiegelungID = ERB.VmSiegelungID and
															VSI.FaLeistungID = {0}
                        left join VmTestament        VTM on VTM.VmTestamentID = ERB.VmTestamentID and
															VTM.FaLeistungID = {0}
                        left join VmErbschaftsdienst VED on VED.VmErbschaftsdienstID = ERB.VmErbschaftsdienstID and
															VED.FaLeistungID = {0}
				where	(VSI.VmSiegelungID is not null or
						VTM.VmTestamentID is not null or
						VED.VmErbschaftsdienstID is not null)";

            if (!DBUtil.IsEmpty(vmSiegelungID))
            {
                sql += " and isNull(ERB.VmSiegelungID,0) <> " + DBUtil.SqlLiteral(vmSiegelungID);
            }

            if (!DBUtil.IsEmpty(vmTestamentID))
            {
                sql += " and isNull(ERB.VmTestamentID,0) <> " + DBUtil.SqlLiteral(vmTestamentID);
            }

            if (!DBUtil.IsEmpty(vmErbschaftsdienstID))
            {
                sql += " and isNull(ERB.VmErbschaftsdienstID,0) <> " + DBUtil.SqlLiteral(vmErbschaftsdienstID);
            }

            sql += " order by ERB.VmSiegelungID,ERB.VMTestamentID,ERB.VmErbschaftsdienstID,Position";
            qryVmErbe.Fill(sql, faLeistungID);
        }

        private void btnTransfer_Click(object sender, System.EventArgs e)
        {
            object id;
            string fldName;

            if (!DBUtil.IsEmpty(_vmSiegelungID))
            {
                id = _vmSiegelungID;
                fldName = "VmSiegelungID";
            }
            else if (!DBUtil.IsEmpty(_vmTestamentID))
            {
                id = _vmTestamentID;
                fldName = "VmTestamentID";
            }
            else if (!DBUtil.IsEmpty(_vmErbschaftsdienstID))
            {
                id = _vmErbschaftsdienstID;
                fldName = "VmErbschaftsdienstID";
            }
            else
                return;


            int maxPosition = (int)DBUtil.ExecuteScalarSQL(string.Format(@"
				select isNull(max(Position),0)
				from   VmErbe
				where {0} = {1}", fldName, id));

            for (int rowHandle = 0; rowHandle < Grid1.View.RowCount; rowHandle++)
            {
                if (Grid1.View.IsRowSelected(rowHandle))
                {
                    object vmErbeID = Grid1.View.GetDataRow(rowHandle)["VmErbeID"];
                    maxPosition++;

                    DBUtil.ExecSQL(@"
                        --SQLCHECK_IGNORE--
						insert  VmErbe
								(" + fldName + @",Position,Level,
								Titel,Titel2,Geburtsdatum,Anrede,
								FamilienNamen,Vornamen,Strasse,Ort,Land,Ergaenzung,
								KontaktAdresse,Bemerkung)
						select  {0},{1},0,
								Titel,Titel2,Geburtsdatum,Anrede,
								FamilienNamen,Vornamen,Strasse,Ort,Land,Ergaenzung,
								KontaktAdresse,Bemerkung
						from	VmErbe ERB
						where	VmErbeID = {2}",
                        id,
                        maxPosition,
                        vmErbeID);
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void btnSelectAll_Click(object sender, System.EventArgs e)
        {
            Grid1.View.SelectAll();
        }

    }
}
