using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class CtlBgColors : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ModulID _modul;

        #endregion

        #endregion

        #region Constructors

        public CtlBgColors(ModulID modul)
        {
            InitializeComponent();

            _modul = modul;
        }

        #endregion

        #region EventHandlers

        private void CtlBgColorsr_Load(object sender, EventArgs e)
        {
            string keyPath = null;

            switch (_modul)
            {
                case ModulID.S:
                    keyPath = @"System\Sozialhilfe\BudgetFarben";
                    lblEinnahmenSD.Text = "Einnahmen, vom Sozialdienst verwaltet";
                    break;
                case ModulID.A:
                    keyPath = @"System\Asyl\BudgetFarben";
                    lblEinnahmenSD.Text = "Einnahmen, vom Asyldienst verwaltet";
                    break;
            }

            qryColor.Fill(@"
                SELECT *,
                  Color0x  = convert(int,null),
                  Color1x  = convert(int,null),
                  Color2x  = convert(int,null),
                  Color3x  = convert(int,null),
                  Color4x  = convert(int,null),
                  Color5x  = convert(int,null),
                  Color6x  = convert(int,null),
                  Color7x  = convert(int,null),
                  Color8x  = convert(int,null),
                  Color9x  = convert(int,null),
                  Color10x = convert(int,null),
                  Color11x = convert(int,null),
                  Color12x = convert(int,null),
                  Color13x = convert(int,null),
                  Color14x = convert(int,null),
                  Color15x = convert(int,null),
                  Color16x = convert(int,null)
                FROM dbo.XConfig
                WHERE KeyPath = {0};",
                keyPath); // Postfix x: Um Ambigous Felder zu vermeiden

            if (qryColor.Count == 0)
            {
                DBUtil.ExecSQL(@"
                    INSERT dbo.XConfig (KeyPath, DatumVon, ValueCode, ValueVarchar)
                    VALUES ({0}, '19000101' , 1, '')",
                    keyPath);

                qryColor.Refresh();
            }
        }

        private void qryColor_BeforePost(object sender, EventArgs e)
        {
            string colors = "";

            for (int i = 0; i < 17; i++)
            {
                if (i != 0) colors += ",";
                colors += qryColor["Color" + i.ToString() + "x"].ToString();
            }

            qryColor["ValueVarchar"] = colors;
        }

        private void qryColor_PositionChanged(object sender, EventArgs e)
        {
            string[] colorCodes = qryColor["ValueVarchar"].ToString().Split(new char[] { ',' });

            for (int i = 0; i < colorCodes.Length; i++)
            {
                int colorValue = 0;
                try
                {
                    colorValue = Convert.ToInt32(colorCodes[i]);
                }
                catch { }

                switch (i)
                {
                    case 0: qryColor["Color0x"] = colorValue; break;
                    case 1: qryColor["Color1x"] = colorValue; break;
                    case 2: qryColor["Color2x"] = colorValue; break;
                    case 3: qryColor["Color3x"] = colorValue; break;
                    case 4: qryColor["Color4x"] = colorValue; break;
                    case 5: qryColor["Color5x"] = colorValue; break;
                    case 6: qryColor["Color6x"] = colorValue; break;
                    case 7: qryColor["Color7x"] = colorValue; break;
                    case 8: qryColor["Color8x"] = colorValue; break;
                    case 9: qryColor["Color9x"] = colorValue; break;
                    case 10: qryColor["Color10x"] = colorValue; break;
                    case 11: qryColor["Color11x"] = colorValue; break;
                    case 12: qryColor["Color12x"] = colorValue; break;
                    case 13: qryColor["Color13x"] = colorValue; break;
                    case 14: qryColor["Color14x"] = colorValue; break;
                    case 15: qryColor["Color15x"] = colorValue; break;
                    case 16: qryColor["Color16x"] = colorValue; break;
                }
            }
            qryColor.Row.AcceptChanges();
            qryColor.RowModified = false;
        }

        #endregion
    }
}