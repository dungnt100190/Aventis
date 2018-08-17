using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Sostat
{
    public class CtlBfsQueryVariablen : KissQueryControl
    {
        #region Fields

        private const string CTL_BFS_QUERY_VARIABLEN_GRID_COL_DEF = "CtlBfsQueryVariablenGridColDef";

        #region Private Fields

        private KissButton btnExportCSV;
        private KissButton btnLoadColDef;
        private KissButton btnSaveColDef;
        private KissCheckEdit chkExcelExport;
        private KissCheckEdit chkNurDossiertraeger;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col10;
        private DevExpress.XtraGrid.Columns.GridColumn col100;
        private DevExpress.XtraGrid.Columns.GridColumn col101;
        private DevExpress.XtraGrid.Columns.GridColumn col102;
        private DevExpress.XtraGrid.Columns.GridColumn col103;
        private DevExpress.XtraGrid.Columns.GridColumn col104;
        private DevExpress.XtraGrid.Columns.GridColumn col107;
        private DevExpress.XtraGrid.Columns.GridColumn col108;
        private DevExpress.XtraGrid.Columns.GridColumn col109;
        private DevExpress.XtraGrid.Columns.GridColumn col11;
        private DevExpress.XtraGrid.Columns.GridColumn col110;
        private DevExpress.XtraGrid.Columns.GridColumn col111;
        private DevExpress.XtraGrid.Columns.GridColumn col112;
        private DevExpress.XtraGrid.Columns.GridColumn col12;
        private DevExpress.XtraGrid.Columns.GridColumn col13;
        private DevExpress.XtraGrid.Columns.GridColumn col14;
        private DevExpress.XtraGrid.Columns.GridColumn col143;
        private DevExpress.XtraGrid.Columns.GridColumn col144;
        private DevExpress.XtraGrid.Columns.GridColumn col145;
        private DevExpress.XtraGrid.Columns.GridColumn col146;
        private DevExpress.XtraGrid.Columns.GridColumn col147;
        private DevExpress.XtraGrid.Columns.GridColumn col148;
        private DevExpress.XtraGrid.Columns.GridColumn col149;
        private DevExpress.XtraGrid.Columns.GridColumn col15;
        private DevExpress.XtraGrid.Columns.GridColumn col150;
        private DevExpress.XtraGrid.Columns.GridColumn col151;
        private DevExpress.XtraGrid.Columns.GridColumn col152;
        private DevExpress.XtraGrid.Columns.GridColumn col153;
        private DevExpress.XtraGrid.Columns.GridColumn col154;
        private DevExpress.XtraGrid.Columns.GridColumn col155;
        private DevExpress.XtraGrid.Columns.GridColumn col156;
        private DevExpress.XtraGrid.Columns.GridColumn col157;
        private DevExpress.XtraGrid.Columns.GridColumn col16;
        private DevExpress.XtraGrid.Columns.GridColumn col160;
        private DevExpress.XtraGrid.Columns.GridColumn col161;
        private DevExpress.XtraGrid.Columns.GridColumn col162;
        private DevExpress.XtraGrid.Columns.GridColumn col163;
        private DevExpress.XtraGrid.Columns.GridColumn col164;
        private DevExpress.XtraGrid.Columns.GridColumn col165;
        private DevExpress.XtraGrid.Columns.GridColumn col166;
        private DevExpress.XtraGrid.Columns.GridColumn col167;
        private DevExpress.XtraGrid.Columns.GridColumn col168;
        private DevExpress.XtraGrid.Columns.GridColumn col169;
        private DevExpress.XtraGrid.Columns.GridColumn col17;
        private DevExpress.XtraGrid.Columns.GridColumn col170;
        private DevExpress.XtraGrid.Columns.GridColumn col171;
        private DevExpress.XtraGrid.Columns.GridColumn col172;
        private DevExpress.XtraGrid.Columns.GridColumn col173;
        private DevExpress.XtraGrid.Columns.GridColumn col174;
        private DevExpress.XtraGrid.Columns.GridColumn col175;
        private DevExpress.XtraGrid.Columns.GridColumn col176;
        private DevExpress.XtraGrid.Columns.GridColumn col177;
        private DevExpress.XtraGrid.Columns.GridColumn col178;
        private DevExpress.XtraGrid.Columns.GridColumn col179;
        private DevExpress.XtraGrid.Columns.GridColumn col180;
        private DevExpress.XtraGrid.Columns.GridColumn col181;
        private DevExpress.XtraGrid.Columns.GridColumn col182;
        private DevExpress.XtraGrid.Columns.GridColumn col183;
        private DevExpress.XtraGrid.Columns.GridColumn col184;
        private DevExpress.XtraGrid.Columns.GridColumn col185;
        private DevExpress.XtraGrid.Columns.GridColumn col186;
        private DevExpress.XtraGrid.Columns.GridColumn col187;
        private DevExpress.XtraGrid.Columns.GridColumn col188;
        private DevExpress.XtraGrid.Columns.GridColumn col189;
        private DevExpress.XtraGrid.Columns.GridColumn col19;
        private DevExpress.XtraGrid.Columns.GridColumn col190;
        private DevExpress.XtraGrid.Columns.GridColumn col191;
        private DevExpress.XtraGrid.Columns.GridColumn col192;
        private DevExpress.XtraGrid.Columns.GridColumn col193;
        private DevExpress.XtraGrid.Columns.GridColumn col194;
        private DevExpress.XtraGrid.Columns.GridColumn col195;
        private DevExpress.XtraGrid.Columns.GridColumn col196;
        private DevExpress.XtraGrid.Columns.GridColumn col197;
        private DevExpress.XtraGrid.Columns.GridColumn col198;
        private DevExpress.XtraGrid.Columns.GridColumn col199;
        private DevExpress.XtraGrid.Columns.GridColumn col20;
        private DevExpress.XtraGrid.Columns.GridColumn col200;
        private DevExpress.XtraGrid.Columns.GridColumn col201;
        private DevExpress.XtraGrid.Columns.GridColumn col202;
        private DevExpress.XtraGrid.Columns.GridColumn col203;
        private DevExpress.XtraGrid.Columns.GridColumn col204;
        private DevExpress.XtraGrid.Columns.GridColumn col205;
        private DevExpress.XtraGrid.Columns.GridColumn col206;
        private DevExpress.XtraGrid.Columns.GridColumn col207;
        private DevExpress.XtraGrid.Columns.GridColumn col208;
        private DevExpress.XtraGrid.Columns.GridColumn col209;
        private DevExpress.XtraGrid.Columns.GridColumn col21;
        private DevExpress.XtraGrid.Columns.GridColumn col210;
        private DevExpress.XtraGrid.Columns.GridColumn col211;
        private DevExpress.XtraGrid.Columns.GridColumn col212;
        private DevExpress.XtraGrid.Columns.GridColumn col213;
        private DevExpress.XtraGrid.Columns.GridColumn col214;
        private DevExpress.XtraGrid.Columns.GridColumn col215;
        private DevExpress.XtraGrid.Columns.GridColumn col216;
        private DevExpress.XtraGrid.Columns.GridColumn col217;
        private DevExpress.XtraGrid.Columns.GridColumn col218;
        private DevExpress.XtraGrid.Columns.GridColumn col219;
        private DevExpress.XtraGrid.Columns.GridColumn col220;
        private DevExpress.XtraGrid.Columns.GridColumn col221;
        private DevExpress.XtraGrid.Columns.GridColumn col222;
        private DevExpress.XtraGrid.Columns.GridColumn col223;
        private DevExpress.XtraGrid.Columns.GridColumn col224;
        private DevExpress.XtraGrid.Columns.GridColumn col225;
        private DevExpress.XtraGrid.Columns.GridColumn col226;
        private DevExpress.XtraGrid.Columns.GridColumn col228;
        private DevExpress.XtraGrid.Columns.GridColumn col229;
        private DevExpress.XtraGrid.Columns.GridColumn col23;
        private DevExpress.XtraGrid.Columns.GridColumn col230;
        private DevExpress.XtraGrid.Columns.GridColumn col231;
        private DevExpress.XtraGrid.Columns.GridColumn col232;
        private DevExpress.XtraGrid.Columns.GridColumn col233;
        private DevExpress.XtraGrid.Columns.GridColumn col234;
        private DevExpress.XtraGrid.Columns.GridColumn col235;
        private DevExpress.XtraGrid.Columns.GridColumn col236;
        private DevExpress.XtraGrid.Columns.GridColumn col237;
        private DevExpress.XtraGrid.Columns.GridColumn col238;
        private DevExpress.XtraGrid.Columns.GridColumn col239;
        private DevExpress.XtraGrid.Columns.GridColumn col24;
        private DevExpress.XtraGrid.Columns.GridColumn col240;
        private DevExpress.XtraGrid.Columns.GridColumn col241;
        private DevExpress.XtraGrid.Columns.GridColumn col242;
        private DevExpress.XtraGrid.Columns.GridColumn col243;
        private DevExpress.XtraGrid.Columns.GridColumn col244;
        private DevExpress.XtraGrid.Columns.GridColumn col245;
        private DevExpress.XtraGrid.Columns.GridColumn col246;
        private DevExpress.XtraGrid.Columns.GridColumn col247;
        private DevExpress.XtraGrid.Columns.GridColumn col25;
        private DevExpress.XtraGrid.Columns.GridColumn col252;
        private DevExpress.XtraGrid.Columns.GridColumn col26;
        private DevExpress.XtraGrid.Columns.GridColumn col27;
        private DevExpress.XtraGrid.Columns.GridColumn col28;
        private DevExpress.XtraGrid.Columns.GridColumn col29;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col30;
        private DevExpress.XtraGrid.Columns.GridColumn col31;
        private DevExpress.XtraGrid.Columns.GridColumn col32;
        private DevExpress.XtraGrid.Columns.GridColumn col391;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col419;
        private DevExpress.XtraGrid.Columns.GridColumn col428;
        private DevExpress.XtraGrid.Columns.GridColumn col429;
        private DevExpress.XtraGrid.Columns.GridColumn col434;
        private DevExpress.XtraGrid.Columns.GridColumn col435;
        private DevExpress.XtraGrid.Columns.GridColumn col436;
        private DevExpress.XtraGrid.Columns.GridColumn col437;
        private DevExpress.XtraGrid.Columns.GridColumn col438;
        private DevExpress.XtraGrid.Columns.GridColumn col49;
        private DevExpress.XtraGrid.Columns.GridColumn col5;
        private DevExpress.XtraGrid.Columns.GridColumn col50;
        private DevExpress.XtraGrid.Columns.GridColumn col51;
        private DevExpress.XtraGrid.Columns.GridColumn col518;
        private DevExpress.XtraGrid.Columns.GridColumn col52;
        private DevExpress.XtraGrid.Columns.GridColumn col53;
        private DevExpress.XtraGrid.Columns.GridColumn col54;
        private DevExpress.XtraGrid.Columns.GridColumn col55;
        private DevExpress.XtraGrid.Columns.GridColumn col56;
        private DevExpress.XtraGrid.Columns.GridColumn col57;
        private DevExpress.XtraGrid.Columns.GridColumn col576;
        private DevExpress.XtraGrid.Columns.GridColumn col577;
        private DevExpress.XtraGrid.Columns.GridColumn col578;
        private DevExpress.XtraGrid.Columns.GridColumn col579;
        private DevExpress.XtraGrid.Columns.GridColumn col58;
        private DevExpress.XtraGrid.Columns.GridColumn col580;
        private DevExpress.XtraGrid.Columns.GridColumn col581;
        private DevExpress.XtraGrid.Columns.GridColumn col582;
        private DevExpress.XtraGrid.Columns.GridColumn col59;
        private DevExpress.XtraGrid.Columns.GridColumn col594;
        private DevExpress.XtraGrid.Columns.GridColumn col6;
        private DevExpress.XtraGrid.Columns.GridColumn col60;
        private DevExpress.XtraGrid.Columns.GridColumn col61;
        private DevExpress.XtraGrid.Columns.GridColumn col62;
        private DevExpress.XtraGrid.Columns.GridColumn col63;
        private DevExpress.XtraGrid.Columns.GridColumn col630;
        private DevExpress.XtraGrid.Columns.GridColumn col631;
        private DevExpress.XtraGrid.Columns.GridColumn col632;
        private DevExpress.XtraGrid.Columns.GridColumn col633;
        private DevExpress.XtraGrid.Columns.GridColumn col634;
        private DevExpress.XtraGrid.Columns.GridColumn col635;
        private DevExpress.XtraGrid.Columns.GridColumn col637;
        private DevExpress.XtraGrid.Columns.GridColumn col64;
        private DevExpress.XtraGrid.Columns.GridColumn col65;
        private DevExpress.XtraGrid.Columns.GridColumn col66;
        private DevExpress.XtraGrid.Columns.GridColumn col67;
        private DevExpress.XtraGrid.Columns.GridColumn col68;
        private DevExpress.XtraGrid.Columns.GridColumn col69;
        private DevExpress.XtraGrid.Columns.GridColumn col7;
        private DevExpress.XtraGrid.Columns.GridColumn col70;
        private DevExpress.XtraGrid.Columns.GridColumn col71;
        private DevExpress.XtraGrid.Columns.GridColumn col72;
        private DevExpress.XtraGrid.Columns.GridColumn col720;
        private DevExpress.XtraGrid.Columns.GridColumn col724;
        private DevExpress.XtraGrid.Columns.GridColumn col725;
        private DevExpress.XtraGrid.Columns.GridColumn col73;
        private DevExpress.XtraGrid.Columns.GridColumn col74;
        private DevExpress.XtraGrid.Columns.GridColumn col75;
        private DevExpress.XtraGrid.Columns.GridColumn col76;
        private DevExpress.XtraGrid.Columns.GridColumn col77;
        private DevExpress.XtraGrid.Columns.GridColumn col78;
        private DevExpress.XtraGrid.Columns.GridColumn col79;
        private DevExpress.XtraGrid.Columns.GridColumn col8;
        private DevExpress.XtraGrid.Columns.GridColumn col80;
        private DevExpress.XtraGrid.Columns.GridColumn col82;
        private DevExpress.XtraGrid.Columns.GridColumn col83;
        private DevExpress.XtraGrid.Columns.GridColumn col84;
        private DevExpress.XtraGrid.Columns.GridColumn col85;
        private DevExpress.XtraGrid.Columns.GridColumn col86;
        private DevExpress.XtraGrid.Columns.GridColumn col87;
        private DevExpress.XtraGrid.Columns.GridColumn col88;
        private DevExpress.XtraGrid.Columns.GridColumn col89;
        private DevExpress.XtraGrid.Columns.GridColumn col9;
        private DevExpress.XtraGrid.Columns.GridColumn col90;
        private DevExpress.XtraGrid.Columns.GridColumn col91;
        private DevExpress.XtraGrid.Columns.GridColumn col92;
        private DevExpress.XtraGrid.Columns.GridColumn col93;
        private DevExpress.XtraGrid.Columns.GridColumn col94;
        private DevExpress.XtraGrid.Columns.GridColumn col95;
        private DevExpress.XtraGrid.Columns.GridColumn col96;
        private DevExpress.XtraGrid.Columns.GridColumn col97;
        private DevExpress.XtraGrid.Columns.GridColumn col98;
        private DevExpress.XtraGrid.Columns.GridColumn col99;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAntragsteller;
        private DevExpress.XtraGrid.Columns.GridColumn colDossierNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonenTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStichtag;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colV10011;
        private DevExpress.XtraGrid.Columns.GridColumn colV10011ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz;
        private DevExpress.XtraGrid.Columns.GridColumn colV10012;
        private DevExpress.XtraGrid.Columns.GridColumn colV10012ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz;
        private DevExpress.XtraGrid.Columns.GridColumn colV10021;
        private DevExpress.XtraGrid.Columns.GridColumn colV10021ALV;
        private DevExpress.XtraGrid.Columns.GridColumn colV10022;
        private DevExpress.XtraGrid.Columns.GridColumn colV10022ALV;
        private DevExpress.XtraGrid.Columns.GridColumn colV10031;
        private DevExpress.XtraGrid.Columns.GridColumn colV10031Altersrente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10032;
        private DevExpress.XtraGrid.Columns.GridColumn colV10032Altersrente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10041;
        private DevExpress.XtraGrid.Columns.GridColumn colV10041WitwenWaisenrente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10042;
        private DevExpress.XtraGrid.Columns.GridColumn colV10042WitwenWaisenrente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10051;
        private DevExpress.XtraGrid.Columns.GridColumn colV10051BVG;
        private DevExpress.XtraGrid.Columns.GridColumn colV10052;
        private DevExpress.XtraGrid.Columns.GridColumn colV10052BVG;
        private DevExpress.XtraGrid.Columns.GridColumn colV10061;
        private DevExpress.XtraGrid.Columns.GridColumn colV10061Hilflosenentschdigung;
        private DevExpress.XtraGrid.Columns.GridColumn colV10062;
        private DevExpress.XtraGrid.Columns.GridColumn colV10062Hilflosenentschdigung;
        private DevExpress.XtraGrid.Columns.GridColumn colV10063;
        private DevExpress.XtraGrid.Columns.GridColumn colV10063GradHilflosigkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colV10071;
        private DevExpress.XtraGrid.Columns.GridColumn colV10071IVRente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10072;
        private DevExpress.XtraGrid.Columns.GridColumn colV10072IVRente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10073;
        private DevExpress.XtraGrid.Columns.GridColumn colV10073Invalidittsgrad;
        private DevExpress.XtraGrid.Columns.GridColumn colV10081;
        private DevExpress.XtraGrid.Columns.GridColumn colV10081SUVARente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10082;
        private DevExpress.XtraGrid.Columns.GridColumn colV10082SUVARente;
        private DevExpress.XtraGrid.Columns.GridColumn colV10091;
        private DevExpress.XtraGrid.Columns.GridColumn colV10091TaggeldKrankenversicherung;
        private DevExpress.XtraGrid.Columns.GridColumn colV10092;
        private DevExpress.XtraGrid.Columns.GridColumn colV10092TaggeldKrankenversicherung;
        private DevExpress.XtraGrid.Columns.GridColumn colV100a;
        private DevExpress.XtraGrid.Columns.GridColumn colV100aLeistungstyp;
        private DevExpress.XtraGrid.Columns.GridColumn colV100b;
        private DevExpress.XtraGrid.Columns.GridColumn colV100bIdentifikationFallfhrungssystem;
        private DevExpress.XtraGrid.Columns.GridColumn colV10101;
        private DevExpress.XtraGrid.Columns.GridColumn colV10101IVTaggeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV10102;
        private DevExpress.XtraGrid.Columns.GridColumn colV10102IVTaggeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV10111;
        private DevExpress.XtraGrid.Columns.GridColumn colV10111UnfallTaggeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV10112;
        private DevExpress.XtraGrid.Columns.GridColumn colV10112UnfallTaggeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV10121;
        private DevExpress.XtraGrid.Columns.GridColumn colV10121AndereSozialversicherungsleistungenRenteTaggelder;
        private DevExpress.XtraGrid.Columns.GridColumn colV10122;
        private DevExpress.XtraGrid.Columns.GridColumn colV10122AndereSozialversicherungsleistungenRenteTaggelder;
        private DevExpress.XtraGrid.Columns.GridColumn colV10131;
        private DevExpress.XtraGrid.Columns.GridColumn colV10131Unterhaltsbeitrge;
        private DevExpress.XtraGrid.Columns.GridColumn colV10132;
        private DevExpress.XtraGrid.Columns.GridColumn colV10132Unterhaltsbeitrge;
        private DevExpress.XtraGrid.Columns.GridColumn colV10141;
        private DevExpress.XtraGrid.Columns.GridColumn colV10141Alimentenbevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colV10142;
        private DevExpress.XtraGrid.Columns.GridColumn colV10142Alimentenbevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colV101a;
        private DevExpress.XtraGrid.Columns.GridColumn colV101aGemeindecode4;
        private DevExpress.XtraGrid.Columns.GridColumn colV101b;
        private DevExpress.XtraGrid.Columns.GridColumn colV101bInstitution6;
        private DevExpress.XtraGrid.Columns.GridColumn colV101c;
        private DevExpress.XtraGrid.Columns.GridColumn colV101cLeistungstyp2;
        private DevExpress.XtraGrid.Columns.GridColumn colV101d;
        private DevExpress.XtraGrid.Columns.GridColumn colV101dErhebungsjahr4;
        private DevExpress.XtraGrid.Columns.GridColumn colV101e;
        private DevExpress.XtraGrid.Columns.GridColumn colV101eDossiernummer8;
        private DevExpress.XtraGrid.Columns.GridColumn colV101f;
        private DevExpress.XtraGrid.Columns.GridColumn colV101fAnfangszust0Stichtag1;
        private DevExpress.XtraGrid.Columns.GridColumn colV102;
        private DevExpress.XtraGrid.Columns.GridColumn colV1020;
        private DevExpress.XtraGrid.Columns.GridColumn colV1020AnwendungSKOSRichtlinien2005;
        private DevExpress.XtraGrid.Columns.GridColumn colV10211;
        private DevExpress.XtraGrid.Columns.GridColumn colV10211MinimaleIntegrationszulageMIZStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV10212;
        private DevExpress.XtraGrid.Columns.GridColumn colV10212MinimaleIntegrationszulageMIZStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV10213;
        private DevExpress.XtraGrid.Columns.GridColumn colV10213MassnahmezuMIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colV10221;
        private DevExpress.XtraGrid.Columns.GridColumn colV10221IntegrationszulagefrNichtErwerbsttigeIZUStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV10222;
        private DevExpress.XtraGrid.Columns.GridColumn colV10222IntegrationszulagefrNichtErwerbsttigeIZUStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV10223;
        private DevExpress.XtraGrid.Columns.GridColumn colV10223MassnahmezuIZU;
        private DevExpress.XtraGrid.Columns.GridColumn colV10231;
        private DevExpress.XtraGrid.Columns.GridColumn colV10231EinkommensfreibetragfrErwerbsttigeEFBStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV10232;
        private DevExpress.XtraGrid.Columns.GridColumn colV10232EinkommensfreibetragfrErwerbsttigeEFBStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV102Aufnahmedatum;
        private DevExpress.XtraGrid.Columns.GridColumn colV103;
        private DevExpress.XtraGrid.Columns.GridColumn colV1030;
        private DevExpress.XtraGrid.Columns.GridColumn colV1030ErhaltenandereMitgliederderUntersttzungseinheitErwerbseinkommenSozialversicherungsleistungen;
        private DevExpress.XtraGrid.Columns.GridColumn colV103KennnummerdesAntragstellersAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colV104;
        private DevExpress.XtraGrid.Columns.GridColumn colV104DatumdesBeginnsderAnspruchsberechtigung;
        private DevExpress.XtraGrid.Columns.GridColumn colV105;
        private DevExpress.XtraGrid.Columns.GridColumn colV105VersichertennummerneueAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colV1201;
        private DevExpress.XtraGrid.Columns.GridColumn colV1201Vermgensfreibetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colV1202;
        private DevExpress.XtraGrid.Columns.GridColumn colV1202EinkommenausVermgen;
        private DevExpress.XtraGrid.Columns.GridColumn colV1203;
        private DevExpress.XtraGrid.Columns.GridColumn colV1203GuthabenPensionskasse2Sule;
        private DevExpress.XtraGrid.Columns.GridColumn colV1204;
        private DevExpress.XtraGrid.Columns.GridColumn colV1204Wohneigentumvorhanden;
        private DevExpress.XtraGrid.Columns.GridColumn colV12051;
        private DevExpress.XtraGrid.Columns.GridColumn colV12051KinderzulagewennnichtimLohnenthalten;
        private DevExpress.XtraGrid.Columns.GridColumn colV12052;
        private DevExpress.XtraGrid.Columns.GridColumn colV12052KinderzulagewennnichtimLohnenthalten;
        private DevExpress.XtraGrid.Columns.GridColumn colV12061;
        private DevExpress.XtraGrid.Columns.GridColumn colV12061Arbeitslosenhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colV12062;
        private DevExpress.XtraGrid.Columns.GridColumn colV12062Arbeitslosenhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colV12071;
        private DevExpress.XtraGrid.Columns.GridColumn colV12071ELBetragIVAHV;
        private DevExpress.XtraGrid.Columns.GridColumn colV12072;
        private DevExpress.XtraGrid.Columns.GridColumn colV12072ELBetragIVAHV;
        private DevExpress.XtraGrid.Columns.GridColumn colV12081;
        private DevExpress.XtraGrid.Columns.GridColumn colV12081IndividWohnkostenzuschuss;
        private DevExpress.XtraGrid.Columns.GridColumn colV12082;
        private DevExpress.XtraGrid.Columns.GridColumn colV12082IndividWohnkostenzuschuss;
        private DevExpress.XtraGrid.Columns.GridColumn colV12091;
        private DevExpress.XtraGrid.Columns.GridColumn colV12091Mutterschaftsbeitrge;
        private DevExpress.XtraGrid.Columns.GridColumn colV12092;
        private DevExpress.XtraGrid.Columns.GridColumn colV12092Mutterschaftsbeitrge;
        private DevExpress.XtraGrid.Columns.GridColumn colV12101;
        private DevExpress.XtraGrid.Columns.GridColumn colV12101Erziehungsgeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV12102;
        private DevExpress.XtraGrid.Columns.GridColumn colV12102Erziehungsgeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV12121;
        private DevExpress.XtraGrid.Columns.GridColumn colV12121Stipendien;
        private DevExpress.XtraGrid.Columns.GridColumn colV12122;
        private DevExpress.XtraGrid.Columns.GridColumn colV12122Stipendien;
        private DevExpress.XtraGrid.Columns.GridColumn colV12131;
        private DevExpress.XtraGrid.Columns.GridColumn colV12131Gemeindezuschsse;
        private DevExpress.XtraGrid.Columns.GridColumn colV12132;
        private DevExpress.XtraGrid.Columns.GridColumn colV12132Gemeindezuschsse;
        private DevExpress.XtraGrid.Columns.GridColumn colV12141;
        private DevExpress.XtraGrid.Columns.GridColumn colV12141andere;
        private DevExpress.XtraGrid.Columns.GridColumn colV12142;
        private DevExpress.XtraGrid.Columns.GridColumn colV12142andere;
        private DevExpress.XtraGrid.Columns.GridColumn colV12151;
        private DevExpress.XtraGrid.Columns.GridColumn colV12151ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag;
        private DevExpress.XtraGrid.Columns.GridColumn colV12152;
        private DevExpress.XtraGrid.Columns.GridColumn colV12152ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag;
        private DevExpress.XtraGrid.Columns.GridColumn colV12161;
        private DevExpress.XtraGrid.Columns.GridColumn colV12161Verwandtenuntersttzung;
        private DevExpress.XtraGrid.Columns.GridColumn colV12162;
        private DevExpress.XtraGrid.Columns.GridColumn colV12162Verwandtenuntersttzung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1220;
        private DevExpress.XtraGrid.Columns.GridColumn colV1220GesamtbetraganrechenbaresEinkommen;
        private DevExpress.XtraGrid.Columns.GridColumn colV1221;
        private DevExpress.XtraGrid.Columns.GridColumn colV1221GesamtbetragErwerbseinkommen;
        private DevExpress.XtraGrid.Columns.GridColumn colV1222;
        private DevExpress.XtraGrid.Columns.GridColumn colV1222TotalSozialversicherungsleistungenimStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV1223;
        private DevExpress.XtraGrid.Columns.GridColumn colV1223TotalbedarfsabhngigeSozialleistungenimStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV1224;
        private DevExpress.XtraGrid.Columns.GridColumn colV1224TotalderZusatzeinkommenimStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV13011;
        private DevExpress.XtraGrid.Columns.GridColumn colV13011weitereVersicherungsprmien;
        private DevExpress.XtraGrid.Columns.GridColumn colV13012;
        private DevExpress.XtraGrid.Columns.GridColumn colV13012weitereVersicherungsprmien;
        private DevExpress.XtraGrid.Columns.GridColumn colV13021;
        private DevExpress.XtraGrid.Columns.GridColumn colV13021SchuldenbelastunginklSteuerschuldenSchtzung;
        private DevExpress.XtraGrid.Columns.GridColumn colV13022;
        private DevExpress.XtraGrid.Columns.GridColumn colV13022SchuldenbelastunginklSteuerschuldenSchtzung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1303;
        private DevExpress.XtraGrid.Columns.GridColumn colV1303Einkommenspfndung;
        private DevExpress.XtraGrid.Columns.GridColumn colV13041;
        private DevExpress.XtraGrid.Columns.GridColumn colV13041UnterhaltsbeitraganEhepartnerbzwKinder;
        private DevExpress.XtraGrid.Columns.GridColumn colV13042;
        private DevExpress.XtraGrid.Columns.GridColumn colV13042UnterhaltsbeitraganEhepartnerbzwKinder;
        private DevExpress.XtraGrid.Columns.GridColumn colV1401;
        private DevExpress.XtraGrid.Columns.GridColumn colV140121Amtsvormundschaft;
        private DevExpress.XtraGrid.Columns.GridColumn colV1402;
        private DevExpress.XtraGrid.Columns.GridColumn colV140211Jugendanwaltschaft;
        private DevExpress.XtraGrid.Columns.GridColumn colV1403;
        private DevExpress.XtraGrid.Columns.GridColumn colV140312JugendamtJugendsekretariat;
        private DevExpress.XtraGrid.Columns.GridColumn colV1404;
        private DevExpress.XtraGrid.Columns.GridColumn colV140420BewhrungshilfeStrafentlassenenhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colV1405;
        private DevExpress.XtraGrid.Columns.GridColumn colV140515Spitex;
        private DevExpress.XtraGrid.Columns.GridColumn colV1406;
        private DevExpress.XtraGrid.Columns.GridColumn colV140625Wohnungsvermittlung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1407;
        private DevExpress.XtraGrid.Columns.GridColumn colV140726VermittlunginWohngruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colV1408;
        private DevExpress.XtraGrid.Columns.GridColumn colV140819SozialberatungvonexternerStelle;
        private DevExpress.XtraGrid.Columns.GridColumn colV1409;
        private DevExpress.XtraGrid.Columns.GridColumn colV140913JugendErziehungsberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1410;
        private DevExpress.XtraGrid.Columns.GridColumn colV14108Eheberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1411;
        private DevExpress.XtraGrid.Columns.GridColumn colV14119Familienberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1412;
        private DevExpress.XtraGrid.Columns.GridColumn colV141224Auslnderberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1413;
        private DevExpress.XtraGrid.Columns.GridColumn colV141323Rechtsberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1414;
        private DevExpress.XtraGrid.Columns.GridColumn colV14143materielleLeistungenFondsetc;
        private DevExpress.XtraGrid.Columns.GridColumn colV1415;
        private DevExpress.XtraGrid.Columns.GridColumn colV14152Schuldenberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1416;
        private DevExpress.XtraGrid.Columns.GridColumn colV14161Budgetberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1417;
        private DevExpress.XtraGrid.Columns.GridColumn colV141710Kinderbetreuung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1418;
        private DevExpress.XtraGrid.Columns.GridColumn colV141822Opferhilfeberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1419;
        private DevExpress.XtraGrid.Columns.GridColumn colV14194Berufsberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1420;
        private DevExpress.XtraGrid.Columns.GridColumn colV14205Weiterbildungsmassnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colV1421;
        private DevExpress.XtraGrid.Columns.GridColumn colV142114Gesundheitsberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1422;
        private DevExpress.XtraGrid.Columns.GridColumn colV142217Alkoholberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1423;
        private DevExpress.XtraGrid.Columns.GridColumn colV142318Drogenberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1424;
        private DevExpress.XtraGrid.Columns.GridColumn colV142416psychiatrischpsycholDienste;
        private DevExpress.XtraGrid.Columns.GridColumn colV1425;
        private DevExpress.XtraGrid.Columns.GridColumn colV14256BeschftigungsmassnahmeRAV;
        private DevExpress.XtraGrid.Columns.GridColumn colV1426;
        private DevExpress.XtraGrid.Columns.GridColumn colV14267BeschftigungsmassnahmeGemeindeKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colV1427;
        private DevExpress.XtraGrid.Columns.GridColumn colV142727andereundzwar;
        private DevExpress.XtraGrid.Columns.GridColumn colV1428;
        private DevExpress.XtraGrid.Columns.GridColumn colV142828andereundzwar;
        private DevExpress.XtraGrid.Columns.GridColumn colV1429;
        private DevExpress.XtraGrid.Columns.GridColumn colV142929UnterbringungdesAntragstellers;
        private DevExpress.XtraGrid.Columns.GridColumn colV1430;
        private DevExpress.XtraGrid.Columns.GridColumn colV143030UnterbringungeinesMitgliedsUE;
        private DevExpress.XtraGrid.Columns.GridColumn colV1431;
        private DevExpress.XtraGrid.Columns.GridColumn colV143131UnterbringungeinesHaushaltsmitglieds;
        private DevExpress.XtraGrid.Columns.GridColumn colV1501;
        private DevExpress.XtraGrid.Columns.GridColumn colV1501Antrag;
        private DevExpress.XtraGrid.Columns.GridColumn colV1502;
        private DevExpress.XtraGrid.Columns.GridColumn colV1502FrhereUntersttzung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1503;
        private DevExpress.XtraGrid.Columns.GridColumn colV1503wennjaDauerderletztenUntersttzung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1504;
        private DevExpress.XtraGrid.Columns.GridColumn colV150401;
        private DevExpress.XtraGrid.Columns.GridColumn colV150401GrundbedarfI;
        private DevExpress.XtraGrid.Columns.GridColumn colV150402;
        private DevExpress.XtraGrid.Columns.GridColumn colV150402ZuschlagzumGrundbedarfI;
        private DevExpress.XtraGrid.Columns.GridColumn colV150403;
        private DevExpress.XtraGrid.Columns.GridColumn colV150403GrundbedarfII;
        private DevExpress.XtraGrid.Columns.GridColumn colV150404;
        private DevExpress.XtraGrid.Columns.GridColumn colV150404AngerechneteMietWohnkosteninklNebenkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colV150405;
        private DevExpress.XtraGrid.Columns.GridColumn colV150405MedizinischeGrundversorgung;
        private DevExpress.XtraGrid.Columns.GridColumn colV150406;
        private DevExpress.XtraGrid.Columns.GridColumn colV150406AllgemeineErwerbsunkostenArbeitspensum;
        private DevExpress.XtraGrid.Columns.GridColumn colV150407;
        private DevExpress.XtraGrid.Columns.GridColumn colV150407SpezielleErwerbsunkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colV150408;
        private DevExpress.XtraGrid.Columns.GridColumn colV150408KostenfrKinderbetreuung;
        private DevExpress.XtraGrid.Columns.GridColumn colV150409;
        private DevExpress.XtraGrid.Columns.GridColumn colV150409SchuleundErstausbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colV150410;
        private DevExpress.XtraGrid.Columns.GridColumn colV150410TherapieoderHeimkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colV150411;
        private DevExpress.XtraGrid.Columns.GridColumn colV150411PauschalefrPersoneninstationrenEinrichtungenSackgeld;
        private DevExpress.XtraGrid.Columns.GridColumn colV150412;
        private DevExpress.XtraGrid.Columns.GridColumn colV150412weiteresonstigeLeistungen;
        private DevExpress.XtraGrid.Columns.GridColumn colV150413;
        private DevExpress.XtraGrid.Columns.GridColumn colV150413Grundbedarf;
        private DevExpress.XtraGrid.Columns.GridColumn colV150414;
        private DevExpress.XtraGrid.Columns.GridColumn colV150414minusSanktion;
        private DevExpress.XtraGrid.Columns.GridColumn colV150415;
        private DevExpress.XtraGrid.Columns.GridColumn colV150415TotalderMinimalenIntegrationszulagenMIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colV150416;
        private DevExpress.XtraGrid.Columns.GridColumn colV150416TotalderIntegrationszulagenfrNichterwerbsttigeIZU;
        private DevExpress.XtraGrid.Columns.GridColumn colV150417;
        private DevExpress.XtraGrid.Columns.GridColumn colV150417TotalderEinkommensfreibetrgeEFB;
        private DevExpress.XtraGrid.Columns.GridColumn colV150418;
        private DevExpress.XtraGrid.Columns.GridColumn colV150418EffektiveErwerbsunkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colV1504BruttobedarfderUntersttzungseinheitMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV15051;
        private DevExpress.XtraGrid.Columns.GridColumn colV15051BerechneterNettobedarfgemssSKOS;
        private DevExpress.XtraGrid.Columns.GridColumn colV15052;
        private DevExpress.XtraGrid.Columns.GridColumn colV15052ZugesprocheneLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1506;
        private DevExpress.XtraGrid.Columns.GridColumn colV1506DatumdererstenAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1508;
        private DevExpress.XtraGrid.Columns.GridColumn colV1508GesamterAuszahlungsbetragseitJahresbeginn;
        private DevExpress.XtraGrid.Columns.GridColumn colV1509;
        private DevExpress.XtraGrid.Columns.GridColumn colV1509GesamterAuszahlungsbetragseitJahresbeginnKrankheitskosten;
        private DevExpress.XtraGrid.Columns.GridColumn colV1511;
        private DevExpress.XtraGrid.Columns.GridColumn colV1511Januar;
        private DevExpress.XtraGrid.Columns.GridColumn colV1512;
        private DevExpress.XtraGrid.Columns.GridColumn colV1512Februar;
        private DevExpress.XtraGrid.Columns.GridColumn colV1513;
        private DevExpress.XtraGrid.Columns.GridColumn colV1513Mrz;
        private DevExpress.XtraGrid.Columns.GridColumn colV1514;
        private DevExpress.XtraGrid.Columns.GridColumn colV1514April;
        private DevExpress.XtraGrid.Columns.GridColumn colV1515;
        private DevExpress.XtraGrid.Columns.GridColumn colV1515Mai;
        private DevExpress.XtraGrid.Columns.GridColumn colV1516;
        private DevExpress.XtraGrid.Columns.GridColumn colV1516Juni;
        private DevExpress.XtraGrid.Columns.GridColumn colV1517;
        private DevExpress.XtraGrid.Columns.GridColumn colV1517Juli;
        private DevExpress.XtraGrid.Columns.GridColumn colV1518;
        private DevExpress.XtraGrid.Columns.GridColumn colV1518August;
        private DevExpress.XtraGrid.Columns.GridColumn colV1519;
        private DevExpress.XtraGrid.Columns.GridColumn colV1519September;
        private DevExpress.XtraGrid.Columns.GridColumn colV1520;
        private DevExpress.XtraGrid.Columns.GridColumn colV1520Oktober;
        private DevExpress.XtraGrid.Columns.GridColumn colV1521;
        private DevExpress.XtraGrid.Columns.GridColumn colV1521November;
        private DevExpress.XtraGrid.Columns.GridColumn colV1522;
        private DevExpress.XtraGrid.Columns.GridColumn colV1522Dezember;
        private DevExpress.XtraGrid.Columns.GridColumn colV1601;
        private DevExpress.XtraGrid.Columns.GridColumn colV1601HatdieUEfrdenMonatDezembereineZahlungerhalten;
        private DevExpress.XtraGrid.Columns.GridColumn colV1602;
        private DevExpress.XtraGrid.Columns.GridColumn colV1602DatumderletztenAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1603;
        private DevExpress.XtraGrid.Columns.GridColumn colV1603AuszahlungsbetrgealsberbrckungvorrangigerLeistungengewhrt;
        private DevExpress.XtraGrid.Columns.GridColumn colV1604;
        private DevExpress.XtraGrid.Columns.GridColumn colV1604HauptgrundfrBeendigungderUntersttzungszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colV1605;
        private DevExpress.XtraGrid.Columns.GridColumn colV1605Dossierabgeschlossenam;
        private DevExpress.XtraGrid.Columns.GridColumn colV201;
        private DevExpress.XtraGrid.Columns.GridColumn colV201Name;
        private DevExpress.XtraGrid.Columns.GridColumn colV202;
        private DevExpress.XtraGrid.Columns.GridColumn colV202Vornamen;
        private DevExpress.XtraGrid.Columns.GridColumn colV203;
        private DevExpress.XtraGrid.Columns.GridColumn colV203FrhererName;
        private DevExpress.XtraGrid.Columns.GridColumn colV204;
        private DevExpress.XtraGrid.Columns.GridColumn colV204Strasse;
        private DevExpress.XtraGrid.Columns.GridColumn colV205;
        private DevExpress.XtraGrid.Columns.GridColumn colV205Nummer;
        private DevExpress.XtraGrid.Columns.GridColumn colV206;
        private DevExpress.XtraGrid.Columns.GridColumn colV206ZivilrechtlicherWohnsitzPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colV207a;
        private DevExpress.XtraGrid.Columns.GridColumn colV207aZivilrechtlicherWohnsitzBFSCode;
        private DevExpress.XtraGrid.Columns.GridColumn colV207b;
        private DevExpress.XtraGrid.Columns.GridColumn colV207bZivilrechtlicherWohnsitzOrtGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colV301;
        private DevExpress.XtraGrid.Columns.GridColumn colV301UntersttzungswohnsitzPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colV302a;
        private DevExpress.XtraGrid.Columns.GridColumn colV302aUntersttzungswohnsitzBFSCode;
        private DevExpress.XtraGrid.Columns.GridColumn colV302b;
        private DevExpress.XtraGrid.Columns.GridColumn colV302bUntersttzungswohnsitzOrtGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colV303;
        private DevExpress.XtraGrid.Columns.GridColumn colV303AufenthaltsortPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colV304a;
        private DevExpress.XtraGrid.Columns.GridColumn colV304aAufenthaltsortBFSCode;
        private DevExpress.XtraGrid.Columns.GridColumn colV304b;
        private DevExpress.XtraGrid.Columns.GridColumn colV304bAufenthaltsortOrtGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colV305;
        private DevExpress.XtraGrid.Columns.GridColumn colV305BrgerortbzwAuslnder;
        private DevExpress.XtraGrid.Columns.GridColumn colV306;
        private DevExpress.XtraGrid.Columns.GridColumn colV306WohnhaftinderGemeindeseit;
        private DevExpress.XtraGrid.Columns.GridColumn colV307;
        private DevExpress.XtraGrid.Columns.GridColumn colV307wenigerals2Jahre;
        private DevExpress.XtraGrid.Columns.GridColumn colV308;
        private DevExpress.XtraGrid.Columns.GridColumn colV308ZuzugindieGemeindevonGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colV309;
        private DevExpress.XtraGrid.Columns.GridColumn colV309ZuzugindieGemeindevonLand;
        private DevExpress.XtraGrid.Columns.GridColumn colV310;
        private DevExpress.XtraGrid.Columns.GridColumn colV310WohnhaftimKantonseit;
        private DevExpress.XtraGrid.Columns.GridColumn colV311;
        private DevExpress.XtraGrid.Columns.GridColumn colV311wenigerals2Jahre;
        private DevExpress.XtraGrid.Columns.GridColumn colV312;
        private DevExpress.XtraGrid.Columns.GridColumn colV312ZuzugindenKantonvon;
        private DevExpress.XtraGrid.Columns.GridColumn colV35002;
        private DevExpress.XtraGrid.Columns.GridColumn colV35002EinkommenausVermgen;
        private DevExpress.XtraGrid.Columns.GridColumn colV35005;
        private DevExpress.XtraGrid.Columns.GridColumn colV35005KinderzulagewennnichtimLohnenthalten;
        private DevExpress.XtraGrid.Columns.GridColumn colV35006;
        private DevExpress.XtraGrid.Columns.GridColumn colV35006Arbeitslosenhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colV35007;
        private DevExpress.XtraGrid.Columns.GridColumn colV35007ELordentliche;
        private DevExpress.XtraGrid.Columns.GridColumn colV35008;
        private DevExpress.XtraGrid.Columns.GridColumn colV35008IndividWohnkostenzuschuss;
        private DevExpress.XtraGrid.Columns.GridColumn colV35009;
        private DevExpress.XtraGrid.Columns.GridColumn colV35009ElternMutterschaftsbeitrge;
        private DevExpress.XtraGrid.Columns.GridColumn colV35010;
        private DevExpress.XtraGrid.Columns.GridColumn colV35010ErziehungsgeldFamilienzuschuss;
        private DevExpress.XtraGrid.Columns.GridColumn colV35012;
        private DevExpress.XtraGrid.Columns.GridColumn colV35012Stipendien;
        private DevExpress.XtraGrid.Columns.GridColumn colV35014;
        private DevExpress.XtraGrid.Columns.GridColumn colV35014andere;
        private DevExpress.XtraGrid.Columns.GridColumn colV35017;
        private DevExpress.XtraGrid.Columns.GridColumn colV35017wirtschaftlicheSozialhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colV35018;
        private DevExpress.XtraGrid.Columns.GridColumn colV35018kantonaleBeihilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colV35019;
        private DevExpress.XtraGrid.Columns.GridColumn colV35019direkteIndividuellePrmienverbilligungIPV;
        private DevExpress.XtraGrid.Columns.GridColumn colV35020;
        private DevExpress.XtraGrid.Columns.GridColumn colV35020brigesEinkommenzBVermgensverzehrimStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV35101;
        private DevExpress.XtraGrid.Columns.GridColumn colV35101ErwerbseinkommenimStichmonat;
        private DevExpress.XtraGrid.Columns.GridColumn colV35102;
        private DevExpress.XtraGrid.Columns.GridColumn colV35102ALV;
        private DevExpress.XtraGrid.Columns.GridColumn colV35103;
        private DevExpress.XtraGrid.Columns.GridColumn colV35103Altersrente;
        private DevExpress.XtraGrid.Columns.GridColumn colV35104;
        private DevExpress.XtraGrid.Columns.GridColumn colV35104WitwenWaisenrente;
        private DevExpress.XtraGrid.Columns.GridColumn colV35105;
        private DevExpress.XtraGrid.Columns.GridColumn colV35105BVG;
        private DevExpress.XtraGrid.Columns.GridColumn colV35106;
        private DevExpress.XtraGrid.Columns.GridColumn colV35106Hilflosenentschdigung;
        private DevExpress.XtraGrid.Columns.GridColumn colV35107;
        private DevExpress.XtraGrid.Columns.GridColumn colV35107IVRente;
        private DevExpress.XtraGrid.Columns.GridColumn colV35108;
        private DevExpress.XtraGrid.Columns.GridColumn colV35108SUVARente;
        private DevExpress.XtraGrid.Columns.GridColumn colV35112;
        private DevExpress.XtraGrid.Columns.GridColumn colV35112AndereSozialversicherungsleistungenRenteTaggelder;
        private DevExpress.XtraGrid.Columns.GridColumn colV35113;
        private DevExpress.XtraGrid.Columns.GridColumn colV35113Unterhaltsbeitrge;
        private DevExpress.XtraGrid.Columns.GridColumn colV35114;
        private DevExpress.XtraGrid.Columns.GridColumn colV35114Alimentenbevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colV35115;
        private DevExpress.XtraGrid.Columns.GridColumn colV35115TaggelderKKSUVAIV;
        private DevExpress.XtraGrid.Columns.GridColumn colV4001;
        private DevExpress.XtraGrid.Columns.GridColumn colV40011;
        private DevExpress.XtraGrid.Columns.GridColumn colV40011ZugesprochenerBetragimStichmonatanAntragsteller;
        private DevExpress.XtraGrid.Columns.GridColumn colV40012;
        private DevExpress.XtraGrid.Columns.GridColumn colV40012DatumdererstenAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colV40013;
        private DevExpress.XtraGrid.Columns.GridColumn colV40013GesamterAuszahlungsbetragseitJahresbeginn;
        private DevExpress.XtraGrid.Columns.GridColumn colV40014;
        private DevExpress.XtraGrid.Columns.GridColumn colV40014HatderAntragsteller1MitgliedUEfrdenMonatDezembereineZahlungerhalten;
        private DevExpress.XtraGrid.Columns.GridColumn colV40015;
        private DevExpress.XtraGrid.Columns.GridColumn colV40015DatumderletztenAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colV4001WiederaufnahmenachUnterbrechung6MteoBezug;
        private DevExpress.XtraGrid.Columns.GridColumn colV401;
        private DevExpress.XtraGrid.Columns.GridColumn colV401Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colV402;
        private DevExpress.XtraGrid.Columns.GridColumn colV402Geschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colV403;
        private DevExpress.XtraGrid.Columns.GridColumn colV403Zivilstand;
        private DevExpress.XtraGrid.Columns.GridColumn colV404;
        private DevExpress.XtraGrid.Columns.GridColumn colV404Nationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colV405;
        private DevExpress.XtraGrid.Columns.GridColumn colV405Aufenthaltsstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colV406;
        private DevExpress.XtraGrid.Columns.GridColumn colV406InderSchweizseitwann;
        private DevExpress.XtraGrid.Columns.GridColumn colV407;
        private DevExpress.XtraGrid.Columns.GridColumn colV407LebtimHaushaltallein;
        private DevExpress.XtraGrid.Columns.GridColumn colV408;
        private DevExpress.XtraGrid.Columns.GridColumn colV408PersonenimgesamtenHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colV409;
        private DevExpress.XtraGrid.Columns.GridColumn colV409PersoneninUntersttzungseinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colV5101;
        private DevExpress.XtraGrid.Columns.GridColumn colV5101BeziehungstypzurAntragstellendenPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colV5a2;
        private DevExpress.XtraGrid.Columns.GridColumn colV5a2SeparateUntersttzungDossier;
        private DevExpress.XtraGrid.Columns.GridColumn colV601;
        private DevExpress.XtraGrid.Columns.GridColumn colV601Wohnstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colV602;
        private DevExpress.XtraGrid.Columns.GridColumn colV602Wohnungsgrssegesamt;
        private DevExpress.XtraGrid.Columns.GridColumn colV603;
        private DevExpress.XtraGrid.Columns.GridColumn colV603MietkostenganzeWohnung;
        private DevExpress.XtraGrid.Columns.GridColumn colV604;
        private DevExpress.XtraGrid.Columns.GridColumn colV604MietkostenanteilsmssigtatschlichangrechneteundbernommeneMietkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colV7011;
        private DevExpress.XtraGrid.Columns.GridColumn colV70111Erwerbssituation;
        private DevExpress.XtraGrid.Columns.GridColumn colV7012;
        private DevExpress.XtraGrid.Columns.GridColumn colV70122Erwerbssituation;
        private DevExpress.XtraGrid.Columns.GridColumn colV7013;
        private DevExpress.XtraGrid.Columns.GridColumn colV70133Erwerbssituation;
        private DevExpress.XtraGrid.Columns.GridColumn colV7014;
        private DevExpress.XtraGrid.Columns.GridColumn colV70144Erwerbssituation;
        private DevExpress.XtraGrid.Columns.GridColumn colV7021;
        private DevExpress.XtraGrid.Columns.GridColumn colV7021NormalarbeitszeitproWoche;
        private DevExpress.XtraGrid.Columns.GridColumn colV7022;
        private DevExpress.XtraGrid.Columns.GridColumn colV7022keineregelmssigeArbeitszeit;
        private DevExpress.XtraGrid.Columns.GridColumn colV703;
        private DevExpress.XtraGrid.Columns.GridColumn colV703Beschftigungsgrad;
        private DevExpress.XtraGrid.Columns.GridColumn colV704;
        private DevExpress.XtraGrid.Columns.GridColumn colV704HauptgrundfrTeilzeit;
        private DevExpress.XtraGrid.Columns.GridColumn colV705;
        private DevExpress.XtraGrid.Columns.GridColumn colV705WeitererGrundfrTeilzeit;
        private DevExpress.XtraGrid.Columns.GridColumn colV706;
        private DevExpress.XtraGrid.Columns.GridColumn colV706Stempelbeginn;
        private DevExpress.XtraGrid.Columns.GridColumn colV707;
        private DevExpress.XtraGrid.Columns.GridColumn colV707Ausgesteuert;
        private DevExpress.XtraGrid.Columns.GridColumn colV708;
        private DevExpress.XtraGrid.Columns.GridColumn colV708Ausgesteuertseit;
        private DevExpress.XtraGrid.Columns.GridColumn colV709;
        private DevExpress.XtraGrid.Columns.GridColumn colV709ErlernterBeruf;
        private DevExpress.XtraGrid.Columns.GridColumn colV710;
        private DevExpress.XtraGrid.Columns.GridColumn colV710LetzteodergegenwrtigeberuflicheTtigkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colV711;
        private DevExpress.XtraGrid.Columns.GridColumn colV711Branche;
        private DevExpress.XtraGrid.Columns.GridColumn colV712;
        private DevExpress.XtraGrid.Columns.GridColumn colV712Wieoftindenletzten3Jahrenarbeitslosgewesen;
        private DevExpress.XtraGrid.Columns.GridColumn colV713;
        private DevExpress.XtraGrid.Columns.GridColumn colV713HchsteabgeschlosseneAusbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colV714;
        private DevExpress.XtraGrid.Columns.GridColumn colV714EineAusbildungvordemAbschlussabgebrochen;
        private DevExpress.XtraGrid.Columns.GridColumn colV715;
        private DevExpress.XtraGrid.Columns.GridColumn colV715LetzteabgebrocheneAusbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colV801;
        private DevExpress.XtraGrid.Columns.GridColumn colV801IVEingliederungsmassnahmen;
        private DevExpress.XtraGrid.Columns.GridColumn colV802;
        private DevExpress.XtraGrid.Columns.GridColumn colV802PflegebedrftigePersonenimHaushaltinsgesamt;
        private DevExpress.XtraGrid.Columns.GridColumn colV803;
        private DevExpress.XtraGrid.Columns.GridColumn colV803PflegeoderBetreuungdurch;
        private DevExpress.XtraGrid.Columns.GridColumn colV901;
        private DevExpress.XtraGrid.Columns.GridColumn colV901KrankenversicherungGrundversicherung;
        private DevExpress.XtraGrid.Columns.GridColumn colV902;
        private DevExpress.XtraGrid.Columns.GridColumn colV902KrankenversicherungZusatzversicherung;
        private DevExpress.XtraGrid.Columns.GridColumn colV904;
        private DevExpress.XtraGrid.Columns.GridColumn colV904KrankenkasseName;
        private DevExpress.XtraGrid.Columns.GridColumn colV905;
        private DevExpress.XtraGrid.Columns.GridColumn colV905KrankenkassenPrmieganzeUE;
        private DevExpress.XtraGrid.Columns.GridColumn colV9061;
        private DevExpress.XtraGrid.Columns.GridColumn colV9061KrankenkassenprmienzuschussIPVganzeUE;
        private DevExpress.XtraGrid.Columns.GridColumn colV9062;
        private DevExpress.XtraGrid.Columns.GridColumn colV9062KrankenkassenprmienzuschussIPVganzeUE;
        private IContainer components;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissLookUpEdit edtBFSLeistungsartCode;
        private KiSS4.Gui.KissCalcEdit edtErhebungsjahr;
        private KissCheckEdit edtNurAnfangszustandX;
        private KissCheckEdit edtNurStichtagX;
        private KissButtonEdit edtSARX;
        private KissLookUpEdit edtSektionX;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblBaPersonIDX;
        private KiSS4.Gui.KissLabel lblErhebungsjahrX;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KissLabel lblSARX;
        private KissLabel lblSektion;
        private SqlQuery qrySektion;

        #endregion

        #endregion

        #region Constructors

        // End Rule
        public CtlBfsQueryVariablen()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsQueryVariablen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.chkNurDossiertraeger = new KiSS4.Gui.KissCheckEdit();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtBFSLeistungsartCode = new KiSS4.Gui.KissLookUpEdit();
            this.chkExcelExport = new KiSS4.Gui.KissCheckEdit();
            this.lblErhebungsjahrX = new KiSS4.Gui.KissLabel();
            this.lblBaPersonIDX = new KiSS4.Gui.KissLabel();
            this.edtErhebungsjahr = new KiSS4.Gui.KissCalcEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col100 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col101 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col102 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col103 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col104 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col107 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col108 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col109 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col110 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col111 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col112 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col143 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col144 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col145 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col146 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col147 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col148 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col149 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col150 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col151 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col152 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col153 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col154 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col155 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col156 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col157 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col160 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col161 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col162 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col163 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col164 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col165 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col166 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col167 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col168 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col169 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col170 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col171 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col172 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col173 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col174 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col175 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col176 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col177 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col178 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col179 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col180 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col181 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col182 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col183 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col184 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col185 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col186 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col187 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col188 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col189 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col190 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col191 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col192 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col193 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col194 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col195 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col196 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col197 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col198 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col199 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col200 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col201 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col202 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col203 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col204 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col205 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col206 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col207 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col208 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col209 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col210 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col211 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col212 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col213 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col214 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col215 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col216 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col217 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col218 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col219 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col220 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col221 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col222 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col223 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col224 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col225 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col226 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col228 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col229 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col230 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col231 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col232 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col233 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col234 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col235 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col236 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col237 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col238 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col239 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col240 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col241 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col242 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col243 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col244 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col245 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col246 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col247 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col252 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col391 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col419 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col428 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col429 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col434 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col435 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col436 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col437 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col438 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col518 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col576 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col577 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col578 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col579 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col580 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col581 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col582 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col59 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col594 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col61 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col630 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col631 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col632 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col633 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col634 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col635 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col637 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col68 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col69 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col70 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col71 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col72 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col720 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col724 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col725 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col73 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col74 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col75 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col76 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col77 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col78 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col79 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col80 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col82 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col83 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col84 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col85 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col86 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col87 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col88 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col89 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col90 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col91 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col92 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col93 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col94 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col95 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col96 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col97 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col99 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAntragsteller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDossierNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonenTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichtag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10011ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10012ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10021 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10021ALV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10022 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10022ALV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10031 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10031Altersrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10032 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10032Altersrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10041 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10041WitwenWaisenrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10042 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10042WitwenWaisenrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10051 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10051BVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10052 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10052BVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10061 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10061Hilflosenentschdigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10062 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10062Hilflosenentschdigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10063 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10063GradHilflosigkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10071 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10071IVRente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10072 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10072IVRente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10073 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10073Invalidittsgrad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10081 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10081SUVARente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10082 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10082SUVARente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10091 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10091TaggeldKrankenversicherung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10092 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10092TaggeldKrankenversicherung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV100a = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV100aLeistungstyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV100b = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV100bIdentifikationFallfhrungssystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10101 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10101IVTaggeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10102 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10102IVTaggeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10111 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10111UnfallTaggeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10112 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10112UnfallTaggeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10121 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10121AndereSozialversicherungsleistungenRenteTaggelder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10122 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10122AndereSozialversicherungsleistungenRenteTaggelder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10131 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10131Unterhaltsbeitrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10132 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10132Unterhaltsbeitrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10141 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10141Alimentenbevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10142 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10142Alimentenbevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101a = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101aGemeindecode4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101b = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101bInstitution6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101c = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101cLeistungstyp2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101d = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101dErhebungsjahr4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101e = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101eDossiernummer8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101f = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV101fAnfangszust0Stichtag1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV102 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1020 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1020AnwendungSKOSRichtlinien2005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10211 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10211MinimaleIntegrationszulageMIZStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10212 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10212MinimaleIntegrationszulageMIZStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10213 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10213MassnahmezuMIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10221 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10221IntegrationszulagefrNichtErwerbsttigeIZUStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10222 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10222IntegrationszulagefrNichtErwerbsttigeIZUStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10223 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10223MassnahmezuIZU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10231 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10231EinkommensfreibetragfrErwerbsttigeEFBStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10232 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV10232EinkommensfreibetragfrErwerbsttigeEFBStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV102Aufnahmedatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV103 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1030 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1030ErhaltenandereMitgliederderUntersttzungseinheitErwerbseinkommenSozialversicherungsleistungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV103KennnummerdesAntragstellersAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV104 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV104DatumdesBeginnsderAnspruchsberechtigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV105 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV105VersichertennummerneueAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1201 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1201Vermgensfreibetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1202 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1202EinkommenausVermgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1203 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1203GuthabenPensionskasse2Sule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1204 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1204Wohneigentumvorhanden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12051 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12051KinderzulagewennnichtimLohnenthalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12052 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12052KinderzulagewennnichtimLohnenthalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12061 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12061Arbeitslosenhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12062 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12062Arbeitslosenhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12071 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12071ELBetragIVAHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12072 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12072ELBetragIVAHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12081 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12081IndividWohnkostenzuschuss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12082 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12082IndividWohnkostenzuschuss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12091 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12091Mutterschaftsbeitrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12092 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12092Mutterschaftsbeitrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12101 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12101Erziehungsgeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12102 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12102Erziehungsgeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12121 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12121Stipendien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12122 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12122Stipendien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12131 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12131Gemeindezuschsse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12132 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12132Gemeindezuschsse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12141 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12141andere = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12142 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12142andere = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12151 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12151ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12152 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12152ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12161 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12161Verwandtenuntersttzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12162 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV12162Verwandtenuntersttzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1220 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1220GesamtbetraganrechenbaresEinkommen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1221 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1221GesamtbetragErwerbseinkommen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1222 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1222TotalSozialversicherungsleistungenimStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1223 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1223TotalbedarfsabhngigeSozialleistungenimStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1224 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1224TotalderZusatzeinkommenimStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13011weitereVersicherungsprmien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13012weitereVersicherungsprmien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13021 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13021SchuldenbelastunginklSteuerschuldenSchtzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13022 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13022SchuldenbelastunginklSteuerschuldenSchtzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1303 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1303Einkommenspfndung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13041 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13041UnterhaltsbeitraganEhepartnerbzwKinder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13042 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV13042UnterhaltsbeitraganEhepartnerbzwKinder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1401 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140121Amtsvormundschaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1402 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140211Jugendanwaltschaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1403 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140312JugendamtJugendsekretariat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1404 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140420BewhrungshilfeStrafentlassenenhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1405 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140515Spitex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1406 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140625Wohnungsvermittlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1407 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140726VermittlunginWohngruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1408 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140819SozialberatungvonexternerStelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1409 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV140913JugendErziehungsberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1410 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14108Eheberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1411 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14119Familienberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1412 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV141224Auslnderberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1413 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV141323Rechtsberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1414 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14143materielleLeistungenFondsetc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1415 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14152Schuldenberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1416 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14161Budgetberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1417 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV141710Kinderbetreuung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1418 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV141822Opferhilfeberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1419 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14194Berufsberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1420 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14205Weiterbildungsmassnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1421 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142114Gesundheitsberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1422 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142217Alkoholberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1423 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142318Drogenberatung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1424 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142416psychiatrischpsycholDienste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1425 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14256BeschftigungsmassnahmeRAV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1426 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV14267BeschftigungsmassnahmeGemeindeKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1427 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142727andereundzwar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1428 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142828andereundzwar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1429 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV142929UnterbringungdesAntragstellers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1430 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV143030UnterbringungeinesMitgliedsUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1431 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV143131UnterbringungeinesHaushaltsmitglieds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1501 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1501Antrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1502 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1502FrhereUntersttzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1503 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1503wennjaDauerderletztenUntersttzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1504 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150401 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150401GrundbedarfI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150402 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150402ZuschlagzumGrundbedarfI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150403 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150403GrundbedarfII = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150404 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150404AngerechneteMietWohnkosteninklNebenkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150405 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150405MedizinischeGrundversorgung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150406 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150406AllgemeineErwerbsunkostenArbeitspensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150407 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150407SpezielleErwerbsunkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150408 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150408KostenfrKinderbetreuung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150409 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150409SchuleundErstausbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150410 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150410TherapieoderHeimkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150411 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150411PauschalefrPersoneninstationrenEinrichtungenSackgeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150412 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150412weiteresonstigeLeistungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150413 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150413Grundbedarf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150414 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150414minusSanktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150415 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150415TotalderMinimalenIntegrationszulagenMIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150416 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150416TotalderIntegrationszulagenfrNichterwerbsttigeIZU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150417 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150417TotalderEinkommensfreibetrgeEFB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150418 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV150418EffektiveErwerbsunkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1504BruttobedarfderUntersttzungseinheitMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV15051 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV15051BerechneterNettobedarfgemssSKOS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV15052 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV15052ZugesprocheneLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1506 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1506DatumdererstenAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1508 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1508GesamterAuszahlungsbetragseitJahresbeginn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1509GesamterAuszahlungsbetragseitJahresbeginnKrankheitskosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1511 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1511Januar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1512 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1512Februar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1513 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1513Mrz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1514 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1514April = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1515 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1515Mai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1516 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1516Juni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1517 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1517Juli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1518 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1518August = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1519 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1519September = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1520 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1520Oktober = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1521 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1521November = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1522 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1522Dezember = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1601 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1601HatdieUEfrdenMonatDezembereineZahlungerhalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1602 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1602DatumderletztenAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1603 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1603AuszahlungsbetrgealsberbrckungvorrangigerLeistungengewhrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1604 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1604HauptgrundfrBeendigungderUntersttzungszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1605 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV1605Dossierabgeschlossenam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV201 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV201Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV202 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV202Vornamen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV203 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV203FrhererName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV204 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV204Strasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV205 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV205Nummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV206 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV206ZivilrechtlicherWohnsitzPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV207a = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV207aZivilrechtlicherWohnsitzBFSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV207b = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV207bZivilrechtlicherWohnsitzOrtGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV301 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV301UntersttzungswohnsitzPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV302a = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV302aUntersttzungswohnsitzBFSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV302b = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV302bUntersttzungswohnsitzOrtGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV303 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV303AufenthaltsortPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV304a = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV304aAufenthaltsortBFSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV304b = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV304bAufenthaltsortOrtGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV305 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV305BrgerortbzwAuslnder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV306 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV306WohnhaftinderGemeindeseit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV307 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV307wenigerals2Jahre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV308 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV308ZuzugindieGemeindevonGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV309 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV309ZuzugindieGemeindevonLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV310 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV310WohnhaftimKantonseit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV311 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV311wenigerals2Jahre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV312 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV312ZuzugindenKantonvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35002EinkommenausVermgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35005KinderzulagewennnichtimLohnenthalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35006Arbeitslosenhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35007ELordentliche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35008IndividWohnkostenzuschuss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35009ElternMutterschaftsbeitrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35010ErziehungsgeldFamilienzuschuss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35012Stipendien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35014andere = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35017 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35017wirtschaftlicheSozialhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35018 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35018kantonaleBeihilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35019 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35019direkteIndividuellePrmienverbilligungIPV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35020 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35020brigesEinkommenzBVermgensverzehrimStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35101 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35101ErwerbseinkommenimStichmonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35102 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35102ALV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35103 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35103Altersrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35104 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35104WitwenWaisenrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35105 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35105BVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35106 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35106Hilflosenentschdigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35107 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35107IVRente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35108 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35108SUVARente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35112 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35112AndereSozialversicherungsleistungenRenteTaggelder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35113 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35113Unterhaltsbeitrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35114 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35114Alimentenbevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35115 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV35115TaggelderKKSUVAIV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV4001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40011ZugesprochenerBetragimStichmonatanAntragsteller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40012DatumdererstenAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40013GesamterAuszahlungsbetragseitJahresbeginn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40014HatderAntragsteller1MitgliedUEfrdenMonatDezembereineZahlungerhalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV40015DatumderletztenAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV4001WiederaufnahmenachUnterbrechung6MteoBezug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV401 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV401Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV402 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV402Geschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV403 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV403Zivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV404 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV404Nationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV405 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV405Aufenthaltsstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV406 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV406InderSchweizseitwann = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV407 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV407LebtimHaushaltallein = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV408 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV408PersonenimgesamtenHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV409 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV409PersoneninUntersttzungseinheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV5101 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV5101BeziehungstypzurAntragstellendenPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV5a2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV5a2SeparateUntersttzungDossier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV601 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV601Wohnstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV602 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV602Wohnungsgrssegesamt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV603 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV603MietkostenganzeWohnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV604 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV604MietkostenanteilsmssigtatschlichangrechneteundbernommeneMietkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV70111Erwerbssituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV70122Erwerbssituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV70133Erwerbssituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV70144Erwerbssituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7021 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7021NormalarbeitszeitproWoche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7022 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV7022keineregelmssigeArbeitszeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV703 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV703Beschftigungsgrad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV704 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV704HauptgrundfrTeilzeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV705 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV705WeitererGrundfrTeilzeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV706 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV706Stempelbeginn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV707 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV707Ausgesteuert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV708 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV708Ausgesteuertseit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV709 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV709ErlernterBeruf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV710 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV710LetzteodergegenwrtigeberuflicheTtigkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV711 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV711Branche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV712 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV712Wieoftindenletzten3Jahrenarbeitslosgewesen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV713 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV713HchsteabgeschlosseneAusbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV714 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV714EineAusbildungvordemAbschlussabgebrochen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV715 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV715LetzteabgebrocheneAusbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV801 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV801IVEingliederungsmassnahmen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV802 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV802PflegebedrftigePersonenimHaushaltinsgesamt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV803 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV803PflegeoderBetreuungdurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV901 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV901KrankenversicherungGrundversicherung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV902 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV902KrankenversicherungZusatzversicherung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV904 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV904KrankenkasseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV905 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV905KrankenkassenPrmieganzeUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV9061 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV9061KrankenkassenprmienzuschussIPVganzeUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV9062 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV9062KrankenkassenprmienzuschussIPVganzeUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtSARX = new KiSS4.Gui.KissButtonEdit();
            this.lblSARX = new KiSS4.Gui.KissLabel();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.edtSektionX = new KiSS4.Gui.KissLookUpEdit();
            this.qrySektion = new KiSS4.DB.SqlQuery(this.components);
            this.edtNurAnfangszustandX = new KiSS4.Gui.KissCheckEdit();
            this.edtNurStichtagX = new KiSS4.Gui.KissCheckEdit();
            this.btnExportCSV = new KiSS4.Gui.KissButton();
            this.btnLoadColDef = new KiSS4.Gui.KissButton();
            this.btnSaveColDef = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurDossiertraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcelExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErhebungsjahrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSARX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAnfangszustandX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurStichtagX.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.FillTimeOut = 3600;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = null;
            //
            // tabControlSearch
            //
            this.tabControlSearch.SelectedTabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnSaveColDef);
            this.tpgListe.Controls.Add(this.btnLoadColDef);
            this.tpgListe.Controls.Add(this.btnExportCSV);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnExportCSV, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnLoadColDef, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnSaveColDef, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtNurAnfangszustandX);
            this.tpgSuchen.Controls.Add(this.edtNurStichtagX);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.edtSektionX);
            this.tpgSuchen.Controls.Add(this.edtSARX);
            this.tpgSuchen.Controls.Add(this.lblSARX);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtErhebungsjahr);
            this.tpgSuchen.Controls.Add(this.lblBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.lblErhebungsjahrX);
            this.tpgSuchen.Controls.Add(this.chkExcelExport);
            this.tpgSuchen.Controls.Add(this.edtBFSLeistungsartCode);
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.chkNurDossiertraeger);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkNurDossiertraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBFSLeistungsartCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkExcelExport, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblErhebungsjahrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErhebungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSektionX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurStichtagX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAnfangszustandX, 0);
            //
            // chkNurDossiertraeger
            //
            this.chkNurDossiertraeger.EditValue = false;
            this.chkNurDossiertraeger.Location = new System.Drawing.Point(112, 229);
            this.chkNurDossiertraeger.Name = "chkNurDossiertraeger";
            this.chkNurDossiertraeger.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNurDossiertraeger.Properties.Appearance.Options.UseBackColor = true;
            this.chkNurDossiertraeger.Properties.Caption = "nur Dossierträger";
            this.chkNurDossiertraeger.Size = new System.Drawing.Size(148, 19);
            this.chkNurDossiertraeger.TabIndex = 4;
            //
            // lblLeistungsart
            //
            this.lblLeistungsart.Location = new System.Drawing.Point(24, 135);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(82, 24);
            this.lblLeistungsart.TabIndex = 21;
            this.lblLeistungsart.Text = "Leistungsart";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            //
            // edtBFSLeistungsartCode
            //
            this.edtBFSLeistungsartCode.Location = new System.Drawing.Point(112, 135);
            this.edtBFSLeistungsartCode.Name = "edtBFSLeistungsartCode";
            this.edtBFSLeistungsartCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSLeistungsartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSLeistungsartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLeistungsartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSLeistungsartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSLeistungsartCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSLeistungsartCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSLeistungsartCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLeistungsartCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSLeistungsartCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSLeistungsartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBFSLeistungsartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBFSLeistungsartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSLeistungsartCode.Properties.NullText = "";
            this.edtBFSLeistungsartCode.Properties.ShowFooter = false;
            this.edtBFSLeistungsartCode.Properties.ShowHeader = false;
            this.edtBFSLeistungsartCode.Size = new System.Drawing.Size(318, 24);
            this.edtBFSLeistungsartCode.TabIndex = 22;
            //
            // chkExcelExport
            //
            this.chkExcelExport.EditValue = true;
            this.chkExcelExport.Location = new System.Drawing.Point(112, 254);
            this.chkExcelExport.Name = "chkExcelExport";
            this.chkExcelExport.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkExcelExport.Properties.Appearance.Options.UseBackColor = true;
            this.chkExcelExport.Properties.Caption = "Formatierung für Excel-Export";
            this.chkExcelExport.Size = new System.Drawing.Size(279, 19);
            this.chkExcelExport.TabIndex = 24;
            //
            // lblErhebungsjahrX
            //
            this.lblErhebungsjahrX.Location = new System.Drawing.Point(24, 46);
            this.lblErhebungsjahrX.Name = "lblErhebungsjahrX";
            this.lblErhebungsjahrX.Size = new System.Drawing.Size(82, 24);
            this.lblErhebungsjahrX.TabIndex = 25;
            this.lblErhebungsjahrX.Text = "Jahr";
            this.lblErhebungsjahrX.UseCompatibleTextRendering = true;
            //
            // lblBaPersonIDX
            //
            this.lblBaPersonIDX.Location = new System.Drawing.Point(24, 105);
            this.lblBaPersonIDX.Name = "lblBaPersonIDX";
            this.lblBaPersonIDX.Size = new System.Drawing.Size(82, 24);
            this.lblBaPersonIDX.TabIndex = 26;
            this.lblBaPersonIDX.Text = "Klient";
            this.lblBaPersonIDX.UseCompatibleTextRendering = true;
            //
            // edtErhebungsjahr
            //
            this.edtErhebungsjahr.Location = new System.Drawing.Point(112, 45);
            this.edtErhebungsjahr.Name = "edtErhebungsjahr";
            this.edtErhebungsjahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErhebungsjahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErhebungsjahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErhebungsjahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErhebungsjahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtErhebungsjahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErhebungsjahr.Properties.Appearance.Options.UseFont = true;
            this.edtErhebungsjahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErhebungsjahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErhebungsjahr.Properties.Mask.EditMask = "####";
            this.edtErhebungsjahr.Size = new System.Drawing.Size(100, 24);
            this.edtErhebungsjahr.TabIndex = 27;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Location = new System.Drawing.Point(112, 105);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(237, 24);
            this.edtBaPersonID.TabIndex = 28;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            //
            // col1
            //
            this.col1.Name = "col1";
            //
            // col10
            //
            this.col10.Name = "col10";
            //
            // col100
            //
            this.col100.Name = "col100";
            //
            // col101
            //
            this.col101.Name = "col101";
            //
            // col102
            //
            this.col102.Name = "col102";
            //
            // col103
            //
            this.col103.Name = "col103";
            //
            // col104
            //
            this.col104.Name = "col104";
            //
            // col107
            //
            this.col107.Name = "col107";
            //
            // col108
            //
            this.col108.Name = "col108";
            //
            // col109
            //
            this.col109.Name = "col109";
            //
            // col11
            //
            this.col11.Name = "col11";
            //
            // col110
            //
            this.col110.Name = "col110";
            //
            // col111
            //
            this.col111.Name = "col111";
            //
            // col112
            //
            this.col112.Name = "col112";
            //
            // col12
            //
            this.col12.Name = "col12";
            //
            // col13
            //
            this.col13.Name = "col13";
            //
            // col14
            //
            this.col14.Name = "col14";
            //
            // col143
            //
            this.col143.Name = "col143";
            //
            // col144
            //
            this.col144.Name = "col144";
            //
            // col145
            //
            this.col145.Name = "col145";
            //
            // col146
            //
            this.col146.Name = "col146";
            //
            // col147
            //
            this.col147.Name = "col147";
            //
            // col148
            //
            this.col148.Name = "col148";
            //
            // col149
            //
            this.col149.Name = "col149";
            //
            // col15
            //
            this.col15.Name = "col15";
            //
            // col150
            //
            this.col150.Name = "col150";
            //
            // col151
            //
            this.col151.Name = "col151";
            //
            // col152
            //
            this.col152.Name = "col152";
            //
            // col153
            //
            this.col153.Name = "col153";
            //
            // col154
            //
            this.col154.Name = "col154";
            //
            // col155
            //
            this.col155.Name = "col155";
            //
            // col156
            //
            this.col156.Name = "col156";
            //
            // col157
            //
            this.col157.Name = "col157";
            //
            // col16
            //
            this.col16.Name = "col16";
            //
            // col160
            //
            this.col160.Name = "col160";
            //
            // col161
            //
            this.col161.Name = "col161";
            //
            // col162
            //
            this.col162.Name = "col162";
            //
            // col163
            //
            this.col163.Name = "col163";
            //
            // col164
            //
            this.col164.Name = "col164";
            //
            // col165
            //
            this.col165.Name = "col165";
            //
            // col166
            //
            this.col166.Name = "col166";
            //
            // col167
            //
            this.col167.Name = "col167";
            //
            // col168
            //
            this.col168.Name = "col168";
            //
            // col169
            //
            this.col169.Name = "col169";
            //
            // col17
            //
            this.col17.Name = "col17";
            //
            // col170
            //
            this.col170.Name = "col170";
            //
            // col171
            //
            this.col171.Name = "col171";
            //
            // col172
            //
            this.col172.Name = "col172";
            //
            // col173
            //
            this.col173.Name = "col173";
            //
            // col174
            //
            this.col174.Name = "col174";
            //
            // col175
            //
            this.col175.Name = "col175";
            //
            // col176
            //
            this.col176.Name = "col176";
            //
            // col177
            //
            this.col177.Name = "col177";
            //
            // col178
            //
            this.col178.Name = "col178";
            //
            // col179
            //
            this.col179.Name = "col179";
            //
            // col180
            //
            this.col180.Name = "col180";
            //
            // col181
            //
            this.col181.Name = "col181";
            //
            // col182
            //
            this.col182.Name = "col182";
            //
            // col183
            //
            this.col183.Name = "col183";
            //
            // col184
            //
            this.col184.Name = "col184";
            //
            // col185
            //
            this.col185.Name = "col185";
            //
            // col186
            //
            this.col186.Name = "col186";
            //
            // col187
            //
            this.col187.Name = "col187";
            //
            // col188
            //
            this.col188.Name = "col188";
            //
            // col189
            //
            this.col189.Name = "col189";
            //
            // col19
            //
            this.col19.Name = "col19";
            //
            // col190
            //
            this.col190.Name = "col190";
            //
            // col191
            //
            this.col191.Name = "col191";
            //
            // col192
            //
            this.col192.Name = "col192";
            //
            // col193
            //
            this.col193.Name = "col193";
            //
            // col194
            //
            this.col194.Name = "col194";
            //
            // col195
            //
            this.col195.Name = "col195";
            //
            // col196
            //
            this.col196.Name = "col196";
            //
            // col197
            //
            this.col197.Name = "col197";
            //
            // col198
            //
            this.col198.Name = "col198";
            //
            // col199
            //
            this.col199.Name = "col199";
            //
            // col20
            //
            this.col20.Name = "col20";
            //
            // col200
            //
            this.col200.Name = "col200";
            //
            // col201
            //
            this.col201.Name = "col201";
            //
            // col202
            //
            this.col202.Name = "col202";
            //
            // col203
            //
            this.col203.Name = "col203";
            //
            // col204
            //
            this.col204.Name = "col204";
            //
            // col205
            //
            this.col205.Name = "col205";
            //
            // col206
            //
            this.col206.Name = "col206";
            //
            // col207
            //
            this.col207.Name = "col207";
            //
            // col208
            //
            this.col208.Name = "col208";
            //
            // col209
            //
            this.col209.Name = "col209";
            //
            // col21
            //
            this.col21.Name = "col21";
            //
            // col210
            //
            this.col210.Name = "col210";
            //
            // col211
            //
            this.col211.Name = "col211";
            //
            // col212
            //
            this.col212.Name = "col212";
            //
            // col213
            //
            this.col213.Name = "col213";
            //
            // col214
            //
            this.col214.Name = "col214";
            //
            // col215
            //
            this.col215.Name = "col215";
            //
            // col216
            //
            this.col216.Name = "col216";
            //
            // col217
            //
            this.col217.Name = "col217";
            //
            // col218
            //
            this.col218.Name = "col218";
            //
            // col219
            //
            this.col219.Name = "col219";
            //
            // col220
            //
            this.col220.Name = "col220";
            //
            // col221
            //
            this.col221.Name = "col221";
            //
            // col222
            //
            this.col222.Name = "col222";
            //
            // col223
            //
            this.col223.Name = "col223";
            //
            // col224
            //
            this.col224.Name = "col224";
            //
            // col225
            //
            this.col225.Name = "col225";
            //
            // col226
            //
            this.col226.Name = "col226";
            //
            // col228
            //
            this.col228.Name = "col228";
            //
            // col229
            //
            this.col229.Name = "col229";
            //
            // col23
            //
            this.col23.Name = "col23";
            //
            // col230
            //
            this.col230.Name = "col230";
            //
            // col231
            //
            this.col231.Name = "col231";
            //
            // col232
            //
            this.col232.Name = "col232";
            //
            // col233
            //
            this.col233.Name = "col233";
            //
            // col234
            //
            this.col234.Name = "col234";
            //
            // col235
            //
            this.col235.Name = "col235";
            //
            // col236
            //
            this.col236.Name = "col236";
            //
            // col237
            //
            this.col237.Name = "col237";
            //
            // col238
            //
            this.col238.Name = "col238";
            //
            // col239
            //
            this.col239.Name = "col239";
            //
            // col24
            //
            this.col24.Name = "col24";
            //
            // col240
            //
            this.col240.Name = "col240";
            //
            // col241
            //
            this.col241.Name = "col241";
            //
            // col242
            //
            this.col242.Name = "col242";
            //
            // col243
            //
            this.col243.Name = "col243";
            //
            // col244
            //
            this.col244.Name = "col244";
            //
            // col245
            //
            this.col245.Name = "col245";
            //
            // col246
            //
            this.col246.Name = "col246";
            //
            // col247
            //
            this.col247.Name = "col247";
            //
            // col25
            //
            this.col25.Name = "col25";
            //
            // col252
            //
            this.col252.Name = "col252";
            //
            // col26
            //
            this.col26.Name = "col26";
            //
            // col27
            //
            this.col27.Name = "col27";
            //
            // col28
            //
            this.col28.Name = "col28";
            //
            // col29
            //
            this.col29.Name = "col29";
            //
            // col3
            //
            this.col3.Name = "col3";
            //
            // col30
            //
            this.col30.Name = "col30";
            //
            // col31
            //
            this.col31.Name = "col31";
            //
            // col32
            //
            this.col32.Name = "col32";
            //
            // col391
            //
            this.col391.Name = "col391";
            //
            // col4
            //
            this.col4.Name = "col4";
            //
            // col419
            //
            this.col419.Name = "col419";
            //
            // col428
            //
            this.col428.Name = "col428";
            //
            // col429
            //
            this.col429.Name = "col429";
            //
            // col434
            //
            this.col434.Name = "col434";
            //
            // col435
            //
            this.col435.Name = "col435";
            //
            // col436
            //
            this.col436.Name = "col436";
            //
            // col437
            //
            this.col437.Name = "col437";
            //
            // col438
            //
            this.col438.Name = "col438";
            //
            // col49
            //
            this.col49.Name = "col49";
            //
            // col5
            //
            this.col5.Name = "col5";
            //
            // col50
            //
            this.col50.Name = "col50";
            //
            // col51
            //
            this.col51.Name = "col51";
            //
            // col518
            //
            this.col518.Name = "col518";
            //
            // col52
            //
            this.col52.Name = "col52";
            //
            // col53
            //
            this.col53.Name = "col53";
            //
            // col54
            //
            this.col54.Name = "col54";
            //
            // col55
            //
            this.col55.Name = "col55";
            //
            // col56
            //
            this.col56.Name = "col56";
            //
            // col57
            //
            this.col57.Name = "col57";
            //
            // col576
            //
            this.col576.Name = "col576";
            //
            // col577
            //
            this.col577.Name = "col577";
            //
            // col578
            //
            this.col578.Name = "col578";
            //
            // col579
            //
            this.col579.Name = "col579";
            //
            // col58
            //
            this.col58.Name = "col58";
            //
            // col580
            //
            this.col580.Name = "col580";
            //
            // col581
            //
            this.col581.Name = "col581";
            //
            // col582
            //
            this.col582.Name = "col582";
            //
            // col59
            //
            this.col59.Name = "col59";
            //
            // col594
            //
            this.col594.Name = "col594";
            //
            // col6
            //
            this.col6.Name = "col6";
            //
            // col60
            //
            this.col60.Name = "col60";
            //
            // col61
            //
            this.col61.Name = "col61";
            //
            // col62
            //
            this.col62.Name = "col62";
            //
            // col63
            //
            this.col63.Name = "col63";
            //
            // col630
            //
            this.col630.Name = "col630";
            //
            // col631
            //
            this.col631.Name = "col631";
            //
            // col632
            //
            this.col632.Name = "col632";
            //
            // col633
            //
            this.col633.Name = "col633";
            //
            // col634
            //
            this.col634.Name = "col634";
            //
            // col635
            //
            this.col635.Name = "col635";
            //
            // col637
            //
            this.col637.Name = "col637";
            //
            // col64
            //
            this.col64.Name = "col64";
            //
            // col65
            //
            this.col65.Name = "col65";
            //
            // col66
            //
            this.col66.Name = "col66";
            //
            // col67
            //
            this.col67.Name = "col67";
            //
            // col68
            //
            this.col68.Name = "col68";
            //
            // col69
            //
            this.col69.Name = "col69";
            //
            // col7
            //
            this.col7.Name = "col7";
            //
            // col70
            //
            this.col70.Name = "col70";
            //
            // col71
            //
            this.col71.Name = "col71";
            //
            // col72
            //
            this.col72.Name = "col72";
            //
            // col720
            //
            this.col720.Name = "col720";
            //
            // col724
            //
            this.col724.Name = "col724";
            //
            // col725
            //
            this.col725.Name = "col725";
            //
            // col73
            //
            this.col73.Name = "col73";
            //
            // col74
            //
            this.col74.Name = "col74";
            //
            // col75
            //
            this.col75.Name = "col75";
            //
            // col76
            //
            this.col76.Name = "col76";
            //
            // col77
            //
            this.col77.Name = "col77";
            //
            // col78
            //
            this.col78.Name = "col78";
            //
            // col79
            //
            this.col79.Name = "col79";
            //
            // col8
            //
            this.col8.Name = "col8";
            //
            // col80
            //
            this.col80.Name = "col80";
            //
            // col82
            //
            this.col82.Name = "col82";
            //
            // col83
            //
            this.col83.Name = "col83";
            //
            // col84
            //
            this.col84.Name = "col84";
            //
            // col85
            //
            this.col85.Name = "col85";
            //
            // col86
            //
            this.col86.Name = "col86";
            //
            // col87
            //
            this.col87.Name = "col87";
            //
            // col88
            //
            this.col88.Name = "col88";
            //
            // col89
            //
            this.col89.Name = "col89";
            //
            // col9
            //
            this.col9.Name = "col9";
            //
            // col90
            //
            this.col90.Name = "col90";
            //
            // col91
            //
            this.col91.Name = "col91";
            //
            // col92
            //
            this.col92.Name = "col92";
            //
            // col93
            //
            this.col93.Name = "col93";
            //
            // col94
            //
            this.col94.Name = "col94";
            //
            // col95
            //
            this.col95.Name = "col95";
            //
            // col96
            //
            this.col96.Name = "col96";
            //
            // col97
            //
            this.col97.Name = "col97";
            //
            // col98
            //
            this.col98.Name = "col98";
            //
            // col99
            //
            this.col99.Name = "col99";
            //
            // colAHVNummer
            //
            this.colAHVNummer.Name = "colAHVNummer";
            //
            // colAntragsteller
            //
            this.colAntragsteller.Name = "colAntragsteller";
            //
            // colDossierNr
            //
            this.colDossierNr.Name = "colDossierNr";
            //
            // colFallNr
            //
            this.colFallNr.Name = "colFallNr";
            //
            // colJahr
            //
            this.colJahr.Name = "colJahr";
            //
            // colLeistungsNr
            //
            this.colLeistungsNr.Name = "colLeistungsNr";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colPersonenTyp
            //
            this.colPersonenTyp.Name = "colPersonenTyp";
            //
            // colPersonNr
            //
            this.colPersonNr.Name = "colPersonNr";
            //
            // colStichtag
            //
            this.colStichtag.Name = "colStichtag";
            //
            // colText
            //
            this.colText.Name = "colText";
            //
            // colV10011
            //
            this.colV10011.Name = "colV10011";
            //
            // colV10011ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz
            //
            this.colV10011ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz.Name = "colV10011ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenaberv" +
                "orSteuernbz";
            //
            // colV10012
            //
            this.colV10012.Name = "colV10012";
            //
            // colV10012ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz
            //
            this.colV10012ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenabervorSteuernbz.Name = "colV10012ErwerbseinkommenimStichmonatErwerbseinkommennettodhnachSozialabzgenaberv" +
                "orSteuernbz";
            //
            // colV10021
            //
            this.colV10021.Name = "colV10021";
            //
            // colV10021ALV
            //
            this.colV10021ALV.Name = "colV10021ALV";
            //
            // colV10022
            //
            this.colV10022.Name = "colV10022";
            //
            // colV10022ALV
            //
            this.colV10022ALV.Name = "colV10022ALV";
            //
            // colV10031
            //
            this.colV10031.Name = "colV10031";
            //
            // colV10031Altersrente
            //
            this.colV10031Altersrente.Name = "colV10031Altersrente";
            //
            // colV10032
            //
            this.colV10032.Name = "colV10032";
            //
            // colV10032Altersrente
            //
            this.colV10032Altersrente.Name = "colV10032Altersrente";
            //
            // colV10041
            //
            this.colV10041.Name = "colV10041";
            //
            // colV10041WitwenWaisenrente
            //
            this.colV10041WitwenWaisenrente.Name = "colV10041WitwenWaisenrente";
            //
            // colV10042
            //
            this.colV10042.Name = "colV10042";
            //
            // colV10042WitwenWaisenrente
            //
            this.colV10042WitwenWaisenrente.Name = "colV10042WitwenWaisenrente";
            //
            // colV10051
            //
            this.colV10051.Name = "colV10051";
            //
            // colV10051BVG
            //
            this.colV10051BVG.Name = "colV10051BVG";
            //
            // colV10052
            //
            this.colV10052.Name = "colV10052";
            //
            // colV10052BVG
            //
            this.colV10052BVG.Name = "colV10052BVG";
            //
            // colV10061
            //
            this.colV10061.Name = "colV10061";
            //
            // colV10061Hilflosenentschdigung
            //
            this.colV10061Hilflosenentschdigung.Name = "colV10061Hilflosenentschdigung";
            //
            // colV10062
            //
            this.colV10062.Name = "colV10062";
            //
            // colV10062Hilflosenentschdigung
            //
            this.colV10062Hilflosenentschdigung.Name = "colV10062Hilflosenentschdigung";
            //
            // colV10063
            //
            this.colV10063.Name = "colV10063";
            //
            // colV10063GradHilflosigkeit
            //
            this.colV10063GradHilflosigkeit.Name = "colV10063GradHilflosigkeit";
            //
            // colV10071
            //
            this.colV10071.Name = "colV10071";
            //
            // colV10071IVRente
            //
            this.colV10071IVRente.Name = "colV10071IVRente";
            //
            // colV10072
            //
            this.colV10072.Name = "colV10072";
            //
            // colV10072IVRente
            //
            this.colV10072IVRente.Name = "colV10072IVRente";
            //
            // colV10073
            //
            this.colV10073.Name = "colV10073";
            //
            // colV10073Invalidittsgrad
            //
            this.colV10073Invalidittsgrad.Name = "colV10073Invalidittsgrad";
            //
            // colV10081
            //
            this.colV10081.Name = "colV10081";
            //
            // colV10081SUVARente
            //
            this.colV10081SUVARente.Name = "colV10081SUVARente";
            //
            // colV10082
            //
            this.colV10082.Name = "colV10082";
            //
            // colV10082SUVARente
            //
            this.colV10082SUVARente.Name = "colV10082SUVARente";
            //
            // colV10091
            //
            this.colV10091.Name = "colV10091";
            //
            // colV10091TaggeldKrankenversicherung
            //
            this.colV10091TaggeldKrankenversicherung.Name = "colV10091TaggeldKrankenversicherung";
            //
            // colV10092
            //
            this.colV10092.Name = "colV10092";
            //
            // colV10092TaggeldKrankenversicherung
            //
            this.colV10092TaggeldKrankenversicherung.Name = "colV10092TaggeldKrankenversicherung";
            //
            // colV100a
            //
            this.colV100a.Name = "colV100a";
            //
            // colV100aLeistungstyp
            //
            this.colV100aLeistungstyp.Name = "colV100aLeistungstyp";
            //
            // colV100b
            //
            this.colV100b.Name = "colV100b";
            //
            // colV100bIdentifikationFallfhrungssystem
            //
            this.colV100bIdentifikationFallfhrungssystem.Name = "colV100bIdentifikationFallfhrungssystem";
            //
            // colV10101
            //
            this.colV10101.Name = "colV10101";
            //
            // colV10101IVTaggeld
            //
            this.colV10101IVTaggeld.Name = "colV10101IVTaggeld";
            //
            // colV10102
            //
            this.colV10102.Name = "colV10102";
            //
            // colV10102IVTaggeld
            //
            this.colV10102IVTaggeld.Name = "colV10102IVTaggeld";
            //
            // colV10111
            //
            this.colV10111.Name = "colV10111";
            //
            // colV10111UnfallTaggeld
            //
            this.colV10111UnfallTaggeld.Name = "colV10111UnfallTaggeld";
            //
            // colV10112
            //
            this.colV10112.Name = "colV10112";
            //
            // colV10112UnfallTaggeld
            //
            this.colV10112UnfallTaggeld.Name = "colV10112UnfallTaggeld";
            //
            // colV10121
            //
            this.colV10121.Name = "colV10121";
            //
            // colV10121AndereSozialversicherungsleistungenRenteTaggelder
            //
            this.colV10121AndereSozialversicherungsleistungenRenteTaggelder.Name = "colV10121AndereSozialversicherungsleistungenRenteTaggelder";
            //
            // colV10122
            //
            this.colV10122.Name = "colV10122";
            //
            // colV10122AndereSozialversicherungsleistungenRenteTaggelder
            //
            this.colV10122AndereSozialversicherungsleistungenRenteTaggelder.Name = "colV10122AndereSozialversicherungsleistungenRenteTaggelder";
            //
            // colV10131
            //
            this.colV10131.Name = "colV10131";
            //
            // colV10131Unterhaltsbeitrge
            //
            this.colV10131Unterhaltsbeitrge.Name = "colV10131Unterhaltsbeitrge";
            //
            // colV10132
            //
            this.colV10132.Name = "colV10132";
            //
            // colV10132Unterhaltsbeitrge
            //
            this.colV10132Unterhaltsbeitrge.Name = "colV10132Unterhaltsbeitrge";
            //
            // colV10141
            //
            this.colV10141.Name = "colV10141";
            //
            // colV10141Alimentenbevorschussung
            //
            this.colV10141Alimentenbevorschussung.Name = "colV10141Alimentenbevorschussung";
            //
            // colV10142
            //
            this.colV10142.Name = "colV10142";
            //
            // colV10142Alimentenbevorschussung
            //
            this.colV10142Alimentenbevorschussung.Name = "colV10142Alimentenbevorschussung";
            //
            // colV101a
            //
            this.colV101a.Name = "colV101a";
            //
            // colV101aGemeindecode4
            //
            this.colV101aGemeindecode4.Name = "colV101aGemeindecode4";
            //
            // colV101b
            //
            this.colV101b.Name = "colV101b";
            //
            // colV101bInstitution6
            //
            this.colV101bInstitution6.Name = "colV101bInstitution6";
            //
            // colV101c
            //
            this.colV101c.Name = "colV101c";
            //
            // colV101cLeistungstyp2
            //
            this.colV101cLeistungstyp2.Name = "colV101cLeistungstyp2";
            //
            // colV101d
            //
            this.colV101d.Name = "colV101d";
            //
            // colV101dErhebungsjahr4
            //
            this.colV101dErhebungsjahr4.Name = "colV101dErhebungsjahr4";
            //
            // colV101e
            //
            this.colV101e.Name = "colV101e";
            //
            // colV101eDossiernummer8
            //
            this.colV101eDossiernummer8.Name = "colV101eDossiernummer8";
            //
            // colV101f
            //
            this.colV101f.Name = "colV101f";
            //
            // colV101fAnfangszust0Stichtag1
            //
            this.colV101fAnfangszust0Stichtag1.Name = "colV101fAnfangszust0Stichtag1";
            //
            // colV102
            //
            this.colV102.Name = "colV102";
            //
            // colV1020
            //
            this.colV1020.Name = "colV1020";
            //
            // colV1020AnwendungSKOSRichtlinien2005
            //
            this.colV1020AnwendungSKOSRichtlinien2005.Name = "colV1020AnwendungSKOSRichtlinien2005";
            //
            // colV10211
            //
            this.colV10211.Name = "colV10211";
            //
            // colV10211MinimaleIntegrationszulageMIZStichmonat
            //
            this.colV10211MinimaleIntegrationszulageMIZStichmonat.Name = "colV10211MinimaleIntegrationszulageMIZStichmonat";
            //
            // colV10212
            //
            this.colV10212.Name = "colV10212";
            //
            // colV10212MinimaleIntegrationszulageMIZStichmonat
            //
            this.colV10212MinimaleIntegrationszulageMIZStichmonat.Name = "colV10212MinimaleIntegrationszulageMIZStichmonat";
            //
            // colV10213
            //
            this.colV10213.Name = "colV10213";
            //
            // colV10213MassnahmezuMIZ
            //
            this.colV10213MassnahmezuMIZ.Name = "colV10213MassnahmezuMIZ";
            //
            // colV10221
            //
            this.colV10221.Name = "colV10221";
            //
            // colV10221IntegrationszulagefrNichtErwerbsttigeIZUStichmonat
            //
            this.colV10221IntegrationszulagefrNichtErwerbsttigeIZUStichmonat.Name = "colV10221IntegrationszulagefrNichtErwerbsttigeIZUStichmonat";
            //
            // colV10222
            //
            this.colV10222.Name = "colV10222";
            //
            // colV10222IntegrationszulagefrNichtErwerbsttigeIZUStichmonat
            //
            this.colV10222IntegrationszulagefrNichtErwerbsttigeIZUStichmonat.Name = "colV10222IntegrationszulagefrNichtErwerbsttigeIZUStichmonat";
            //
            // colV10223
            //
            this.colV10223.Name = "colV10223";
            //
            // colV10223MassnahmezuIZU
            //
            this.colV10223MassnahmezuIZU.Name = "colV10223MassnahmezuIZU";
            //
            // colV10231
            //
            this.colV10231.Name = "colV10231";
            //
            // colV10231EinkommensfreibetragfrErwerbsttigeEFBStichmonat
            //
            this.colV10231EinkommensfreibetragfrErwerbsttigeEFBStichmonat.Name = "colV10231EinkommensfreibetragfrErwerbsttigeEFBStichmonat";
            //
            // colV10232
            //
            this.colV10232.Name = "colV10232";
            //
            // colV10232EinkommensfreibetragfrErwerbsttigeEFBStichmonat
            //
            this.colV10232EinkommensfreibetragfrErwerbsttigeEFBStichmonat.Name = "colV10232EinkommensfreibetragfrErwerbsttigeEFBStichmonat";
            //
            // colV102Aufnahmedatum
            //
            this.colV102Aufnahmedatum.Name = "colV102Aufnahmedatum";
            //
            // colV103
            //
            this.colV103.Name = "colV103";
            //
            // colV1030
            //
            this.colV1030.Name = "colV1030";
            //
            // colV1030ErhaltenandereMitgliederderUntersttzungseinheitErwerbseinkommenSozialversicherungsleistungen
            //
            this.colV1030ErhaltenandereMitgliederderUntersttzungseinheitErwerbseinkommenSozialversicherungsleistungen.Name = "colV1030ErhaltenandereMitgliederderUntersttzungseinheitErwerbseinkommenSozialvers" +
                "icherungsleistungen";
            //
            // colV103KennnummerdesAntragstellersAHVNummer
            //
            this.colV103KennnummerdesAntragstellersAHVNummer.Name = "colV103KennnummerdesAntragstellersAHVNummer";
            //
            // colV104
            //
            this.colV104.Name = "colV104";
            //
            // colV104DatumdesBeginnsderAnspruchsberechtigung
            //
            this.colV104DatumdesBeginnsderAnspruchsberechtigung.Name = "colV104DatumdesBeginnsderAnspruchsberechtigung";
            //
            // colV105
            //
            this.colV105.Name = "colV105";
            //
            // colV105VersichertennummerneueAHVNummer
            //
            this.colV105VersichertennummerneueAHVNummer.Name = "colV105VersichertennummerneueAHVNummer";
            //
            // colV1201
            //
            this.colV1201.Name = "colV1201";
            //
            // colV1201Vermgensfreibetrag
            //
            this.colV1201Vermgensfreibetrag.Name = "colV1201Vermgensfreibetrag";
            //
            // colV1202
            //
            this.colV1202.Name = "colV1202";
            //
            // colV1202EinkommenausVermgen
            //
            this.colV1202EinkommenausVermgen.Name = "colV1202EinkommenausVermgen";
            //
            // colV1203
            //
            this.colV1203.Name = "colV1203";
            //
            // colV1203GuthabenPensionskasse2Sule
            //
            this.colV1203GuthabenPensionskasse2Sule.Name = "colV1203GuthabenPensionskasse2Sule";
            //
            // colV1204
            //
            this.colV1204.Name = "colV1204";
            //
            // colV1204Wohneigentumvorhanden
            //
            this.colV1204Wohneigentumvorhanden.Name = "colV1204Wohneigentumvorhanden";
            //
            // colV12051
            //
            this.colV12051.Name = "colV12051";
            //
            // colV12051KinderzulagewennnichtimLohnenthalten
            //
            this.colV12051KinderzulagewennnichtimLohnenthalten.Name = "colV12051KinderzulagewennnichtimLohnenthalten";
            //
            // colV12052
            //
            this.colV12052.Name = "colV12052";
            //
            // colV12052KinderzulagewennnichtimLohnenthalten
            //
            this.colV12052KinderzulagewennnichtimLohnenthalten.Name = "colV12052KinderzulagewennnichtimLohnenthalten";
            //
            // colV12061
            //
            this.colV12061.Name = "colV12061";
            //
            // colV12061Arbeitslosenhilfe
            //
            this.colV12061Arbeitslosenhilfe.Name = "colV12061Arbeitslosenhilfe";
            //
            // colV12062
            //
            this.colV12062.Name = "colV12062";
            //
            // colV12062Arbeitslosenhilfe
            //
            this.colV12062Arbeitslosenhilfe.Name = "colV12062Arbeitslosenhilfe";
            //
            // colV12071
            //
            this.colV12071.Name = "colV12071";
            //
            // colV12071ELBetragIVAHV
            //
            this.colV12071ELBetragIVAHV.Name = "colV12071ELBetragIVAHV";
            //
            // colV12072
            //
            this.colV12072.Name = "colV12072";
            //
            // colV12072ELBetragIVAHV
            //
            this.colV12072ELBetragIVAHV.Name = "colV12072ELBetragIVAHV";
            //
            // colV12081
            //
            this.colV12081.Name = "colV12081";
            //
            // colV12081IndividWohnkostenzuschuss
            //
            this.colV12081IndividWohnkostenzuschuss.Name = "colV12081IndividWohnkostenzuschuss";
            //
            // colV12082
            //
            this.colV12082.Name = "colV12082";
            //
            // colV12082IndividWohnkostenzuschuss
            //
            this.colV12082IndividWohnkostenzuschuss.Name = "colV12082IndividWohnkostenzuschuss";
            //
            // colV12091
            //
            this.colV12091.Name = "colV12091";
            //
            // colV12091Mutterschaftsbeitrge
            //
            this.colV12091Mutterschaftsbeitrge.Name = "colV12091Mutterschaftsbeitrge";
            //
            // colV12092
            //
            this.colV12092.Name = "colV12092";
            //
            // colV12092Mutterschaftsbeitrge
            //
            this.colV12092Mutterschaftsbeitrge.Name = "colV12092Mutterschaftsbeitrge";
            //
            // colV12101
            //
            this.colV12101.Name = "colV12101";
            //
            // colV12101Erziehungsgeld
            //
            this.colV12101Erziehungsgeld.Name = "colV12101Erziehungsgeld";
            //
            // colV12102
            //
            this.colV12102.Name = "colV12102";
            //
            // colV12102Erziehungsgeld
            //
            this.colV12102Erziehungsgeld.Name = "colV12102Erziehungsgeld";
            //
            // colV12121
            //
            this.colV12121.Name = "colV12121";
            //
            // colV12121Stipendien
            //
            this.colV12121Stipendien.Name = "colV12121Stipendien";
            //
            // colV12122
            //
            this.colV12122.Name = "colV12122";
            //
            // colV12122Stipendien
            //
            this.colV12122Stipendien.Name = "colV12122Stipendien";
            //
            // colV12131
            //
            this.colV12131.Name = "colV12131";
            //
            // colV12131Gemeindezuschsse
            //
            this.colV12131Gemeindezuschsse.Name = "colV12131Gemeindezuschsse";
            //
            // colV12132
            //
            this.colV12132.Name = "colV12132";
            //
            // colV12132Gemeindezuschsse
            //
            this.colV12132Gemeindezuschsse.Name = "colV12132Gemeindezuschsse";
            //
            // colV12141
            //
            this.colV12141.Name = "colV12141";
            //
            // colV12141andere
            //
            this.colV12141andere.Name = "colV12141andere";
            //
            // colV12142
            //
            this.colV12142.Name = "colV12142";
            //
            // colV12142andere
            //
            this.colV12142andere.Name = "colV12142andere";
            //
            // colV12151
            //
            this.colV12151.Name = "colV12151";
            //
            // colV12151ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag
            //
            this.colV12151ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag.Name = "colV12151ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag";
            //
            // colV12152
            //
            this.colV12152.Name = "colV12152";
            //
            // colV12152ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag
            //
            this.colV12152ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag.Name = "colV12152ErhaltvonHaushaltsentschdigungKonkubinatsbeitrag";
            //
            // colV12161
            //
            this.colV12161.Name = "colV12161";
            //
            // colV12161Verwandtenuntersttzung
            //
            this.colV12161Verwandtenuntersttzung.Name = "colV12161Verwandtenuntersttzung";
            //
            // colV12162
            //
            this.colV12162.Name = "colV12162";
            //
            // colV12162Verwandtenuntersttzung
            //
            this.colV12162Verwandtenuntersttzung.Name = "colV12162Verwandtenuntersttzung";
            //
            // colV1220
            //
            this.colV1220.Name = "colV1220";
            //
            // colV1220GesamtbetraganrechenbaresEinkommen
            //
            this.colV1220GesamtbetraganrechenbaresEinkommen.Name = "colV1220GesamtbetraganrechenbaresEinkommen";
            //
            // colV1221
            //
            this.colV1221.Name = "colV1221";
            //
            // colV1221GesamtbetragErwerbseinkommen
            //
            this.colV1221GesamtbetragErwerbseinkommen.Name = "colV1221GesamtbetragErwerbseinkommen";
            //
            // colV1222
            //
            this.colV1222.Name = "colV1222";
            //
            // colV1222TotalSozialversicherungsleistungenimStichmonat
            //
            this.colV1222TotalSozialversicherungsleistungenimStichmonat.Name = "colV1222TotalSozialversicherungsleistungenimStichmonat";
            //
            // colV1223
            //
            this.colV1223.Name = "colV1223";
            //
            // colV1223TotalbedarfsabhngigeSozialleistungenimStichmonat
            //
            this.colV1223TotalbedarfsabhngigeSozialleistungenimStichmonat.Name = "colV1223TotalbedarfsabhngigeSozialleistungenimStichmonat";
            //
            // colV1224
            //
            this.colV1224.Name = "colV1224";
            //
            // colV1224TotalderZusatzeinkommenimStichmonat
            //
            this.colV1224TotalderZusatzeinkommenimStichmonat.Name = "colV1224TotalderZusatzeinkommenimStichmonat";
            //
            // colV13011
            //
            this.colV13011.Name = "colV13011";
            //
            // colV13011weitereVersicherungsprmien
            //
            this.colV13011weitereVersicherungsprmien.Name = "colV13011weitereVersicherungsprmien";
            //
            // colV13012
            //
            this.colV13012.Name = "colV13012";
            //
            // colV13012weitereVersicherungsprmien
            //
            this.colV13012weitereVersicherungsprmien.Name = "colV13012weitereVersicherungsprmien";
            //
            // colV13021
            //
            this.colV13021.Name = "colV13021";
            //
            // colV13021SchuldenbelastunginklSteuerschuldenSchtzung
            //
            this.colV13021SchuldenbelastunginklSteuerschuldenSchtzung.Name = "colV13021SchuldenbelastunginklSteuerschuldenSchtzung";
            //
            // colV13022
            //
            this.colV13022.Name = "colV13022";
            //
            // colV13022SchuldenbelastunginklSteuerschuldenSchtzung
            //
            this.colV13022SchuldenbelastunginklSteuerschuldenSchtzung.Name = "colV13022SchuldenbelastunginklSteuerschuldenSchtzung";
            //
            // colV1303
            //
            this.colV1303.Name = "colV1303";
            //
            // colV1303Einkommenspfndung
            //
            this.colV1303Einkommenspfndung.Name = "colV1303Einkommenspfndung";
            //
            // colV13041
            //
            this.colV13041.Name = "colV13041";
            //
            // colV13041UnterhaltsbeitraganEhepartnerbzwKinder
            //
            this.colV13041UnterhaltsbeitraganEhepartnerbzwKinder.Name = "colV13041UnterhaltsbeitraganEhepartnerbzwKinder";
            //
            // colV13042
            //
            this.colV13042.Name = "colV13042";
            //
            // colV13042UnterhaltsbeitraganEhepartnerbzwKinder
            //
            this.colV13042UnterhaltsbeitraganEhepartnerbzwKinder.Name = "colV13042UnterhaltsbeitraganEhepartnerbzwKinder";
            //
            // colV1401
            //
            this.colV1401.Name = "colV1401";
            //
            // colV140121Amtsvormundschaft
            //
            this.colV140121Amtsvormundschaft.Name = "colV140121Amtsvormundschaft";
            //
            // colV1402
            //
            this.colV1402.Name = "colV1402";
            //
            // colV140211Jugendanwaltschaft
            //
            this.colV140211Jugendanwaltschaft.Name = "colV140211Jugendanwaltschaft";
            //
            // colV1403
            //
            this.colV1403.Name = "colV1403";
            //
            // colV140312JugendamtJugendsekretariat
            //
            this.colV140312JugendamtJugendsekretariat.Name = "colV140312JugendamtJugendsekretariat";
            //
            // colV1404
            //
            this.colV1404.Name = "colV1404";
            //
            // colV140420BewhrungshilfeStrafentlassenenhilfe
            //
            this.colV140420BewhrungshilfeStrafentlassenenhilfe.Name = "colV140420BewhrungshilfeStrafentlassenenhilfe";
            //
            // colV1405
            //
            this.colV1405.Name = "colV1405";
            //
            // colV140515Spitex
            //
            this.colV140515Spitex.Name = "colV140515Spitex";
            //
            // colV1406
            //
            this.colV1406.Name = "colV1406";
            //
            // colV140625Wohnungsvermittlung
            //
            this.colV140625Wohnungsvermittlung.Name = "colV140625Wohnungsvermittlung";
            //
            // colV1407
            //
            this.colV1407.Name = "colV1407";
            //
            // colV140726VermittlunginWohngruppe
            //
            this.colV140726VermittlunginWohngruppe.Name = "colV140726VermittlunginWohngruppe";
            //
            // colV1408
            //
            this.colV1408.Name = "colV1408";
            //
            // colV140819SozialberatungvonexternerStelle
            //
            this.colV140819SozialberatungvonexternerStelle.Name = "colV140819SozialberatungvonexternerStelle";
            //
            // colV1409
            //
            this.colV1409.Name = "colV1409";
            //
            // colV140913JugendErziehungsberatung
            //
            this.colV140913JugendErziehungsberatung.Name = "colV140913JugendErziehungsberatung";
            //
            // colV1410
            //
            this.colV1410.Name = "colV1410";
            //
            // colV14108Eheberatung
            //
            this.colV14108Eheberatung.Name = "colV14108Eheberatung";
            //
            // colV1411
            //
            this.colV1411.Name = "colV1411";
            //
            // colV14119Familienberatung
            //
            this.colV14119Familienberatung.Name = "colV14119Familienberatung";
            //
            // colV1412
            //
            this.colV1412.Name = "colV1412";
            //
            // colV141224Auslnderberatung
            //
            this.colV141224Auslnderberatung.Name = "colV141224Auslnderberatung";
            //
            // colV1413
            //
            this.colV1413.Name = "colV1413";
            //
            // colV141323Rechtsberatung
            //
            this.colV141323Rechtsberatung.Name = "colV141323Rechtsberatung";
            //
            // colV1414
            //
            this.colV1414.Name = "colV1414";
            //
            // colV14143materielleLeistungenFondsetc
            //
            this.colV14143materielleLeistungenFondsetc.Name = "colV14143materielleLeistungenFondsetc";
            //
            // colV1415
            //
            this.colV1415.Name = "colV1415";
            //
            // colV14152Schuldenberatung
            //
            this.colV14152Schuldenberatung.Name = "colV14152Schuldenberatung";
            //
            // colV1416
            //
            this.colV1416.Name = "colV1416";
            //
            // colV14161Budgetberatung
            //
            this.colV14161Budgetberatung.Name = "colV14161Budgetberatung";
            //
            // colV1417
            //
            this.colV1417.Name = "colV1417";
            //
            // colV141710Kinderbetreuung
            //
            this.colV141710Kinderbetreuung.Name = "colV141710Kinderbetreuung";
            //
            // colV1418
            //
            this.colV1418.Name = "colV1418";
            //
            // colV141822Opferhilfeberatung
            //
            this.colV141822Opferhilfeberatung.Name = "colV141822Opferhilfeberatung";
            //
            // colV1419
            //
            this.colV1419.Name = "colV1419";
            //
            // colV14194Berufsberatung
            //
            this.colV14194Berufsberatung.Name = "colV14194Berufsberatung";
            //
            // colV1420
            //
            this.colV1420.Name = "colV1420";
            //
            // colV14205Weiterbildungsmassnahme
            //
            this.colV14205Weiterbildungsmassnahme.Name = "colV14205Weiterbildungsmassnahme";
            //
            // colV1421
            //
            this.colV1421.Name = "colV1421";
            //
            // colV142114Gesundheitsberatung
            //
            this.colV142114Gesundheitsberatung.Name = "colV142114Gesundheitsberatung";
            //
            // colV1422
            //
            this.colV1422.Name = "colV1422";
            //
            // colV142217Alkoholberatung
            //
            this.colV142217Alkoholberatung.Name = "colV142217Alkoholberatung";
            //
            // colV1423
            //
            this.colV1423.Name = "colV1423";
            //
            // colV142318Drogenberatung
            //
            this.colV142318Drogenberatung.Name = "colV142318Drogenberatung";
            //
            // colV1424
            //
            this.colV1424.Name = "colV1424";
            //
            // colV142416psychiatrischpsycholDienste
            //
            this.colV142416psychiatrischpsycholDienste.Name = "colV142416psychiatrischpsycholDienste";
            //
            // colV1425
            //
            this.colV1425.Name = "colV1425";
            //
            // colV14256BeschftigungsmassnahmeRAV
            //
            this.colV14256BeschftigungsmassnahmeRAV.Name = "colV14256BeschftigungsmassnahmeRAV";
            //
            // colV1426
            //
            this.colV1426.Name = "colV1426";
            //
            // colV14267BeschftigungsmassnahmeGemeindeKanton
            //
            this.colV14267BeschftigungsmassnahmeGemeindeKanton.Name = "colV14267BeschftigungsmassnahmeGemeindeKanton";
            //
            // colV1427
            //
            this.colV1427.Name = "colV1427";
            //
            // colV142727andereundzwar
            //
            this.colV142727andereundzwar.Name = "colV142727andereundzwar";
            //
            // colV1428
            //
            this.colV1428.Name = "colV1428";
            //
            // colV142828andereundzwar
            //
            this.colV142828andereundzwar.Name = "colV142828andereundzwar";
            //
            // colV1429
            //
            this.colV1429.Name = "colV1429";
            //
            // colV142929UnterbringungdesAntragstellers
            //
            this.colV142929UnterbringungdesAntragstellers.Name = "colV142929UnterbringungdesAntragstellers";
            //
            // colV1430
            //
            this.colV1430.Name = "colV1430";
            //
            // colV143030UnterbringungeinesMitgliedsUE
            //
            this.colV143030UnterbringungeinesMitgliedsUE.Name = "colV143030UnterbringungeinesMitgliedsUE";
            //
            // colV1431
            //
            this.colV1431.Name = "colV1431";
            //
            // colV143131UnterbringungeinesHaushaltsmitglieds
            //
            this.colV143131UnterbringungeinesHaushaltsmitglieds.Name = "colV143131UnterbringungeinesHaushaltsmitglieds";
            //
            // colV1501
            //
            this.colV1501.Name = "colV1501";
            //
            // colV1501Antrag
            //
            this.colV1501Antrag.Name = "colV1501Antrag";
            //
            // colV1502
            //
            this.colV1502.Name = "colV1502";
            //
            // colV1502FrhereUntersttzung
            //
            this.colV1502FrhereUntersttzung.Name = "colV1502FrhereUntersttzung";
            //
            // colV1503
            //
            this.colV1503.Name = "colV1503";
            //
            // colV1503wennjaDauerderletztenUntersttzung
            //
            this.colV1503wennjaDauerderletztenUntersttzung.Name = "colV1503wennjaDauerderletztenUntersttzung";
            //
            // colV1504
            //
            this.colV1504.Name = "colV1504";
            //
            // colV150401
            //
            this.colV150401.Name = "colV150401";
            //
            // colV150401GrundbedarfI
            //
            this.colV150401GrundbedarfI.Name = "colV150401GrundbedarfI";
            //
            // colV150402
            //
            this.colV150402.Name = "colV150402";
            //
            // colV150402ZuschlagzumGrundbedarfI
            //
            this.colV150402ZuschlagzumGrundbedarfI.Name = "colV150402ZuschlagzumGrundbedarfI";
            //
            // colV150403
            //
            this.colV150403.Name = "colV150403";
            //
            // colV150403GrundbedarfII
            //
            this.colV150403GrundbedarfII.Name = "colV150403GrundbedarfII";
            //
            // colV150404
            //
            this.colV150404.Name = "colV150404";
            //
            // colV150404AngerechneteMietWohnkosteninklNebenkosten
            //
            this.colV150404AngerechneteMietWohnkosteninklNebenkosten.Name = "colV150404AngerechneteMietWohnkosteninklNebenkosten";
            //
            // colV150405
            //
            this.colV150405.Name = "colV150405";
            //
            // colV150405MedizinischeGrundversorgung
            //
            this.colV150405MedizinischeGrundversorgung.Name = "colV150405MedizinischeGrundversorgung";
            //
            // colV150406
            //
            this.colV150406.Name = "colV150406";
            //
            // colV150406AllgemeineErwerbsunkostenArbeitspensum
            //
            this.colV150406AllgemeineErwerbsunkostenArbeitspensum.Name = "colV150406AllgemeineErwerbsunkostenArbeitspensum";
            //
            // colV150407
            //
            this.colV150407.Name = "colV150407";
            //
            // colV150407SpezielleErwerbsunkosten
            //
            this.colV150407SpezielleErwerbsunkosten.Name = "colV150407SpezielleErwerbsunkosten";
            //
            // colV150408
            //
            this.colV150408.Name = "colV150408";
            //
            // colV150408KostenfrKinderbetreuung
            //
            this.colV150408KostenfrKinderbetreuung.Name = "colV150408KostenfrKinderbetreuung";
            //
            // colV150409
            //
            this.colV150409.Name = "colV150409";
            //
            // colV150409SchuleundErstausbildung
            //
            this.colV150409SchuleundErstausbildung.Name = "colV150409SchuleundErstausbildung";
            //
            // colV150410
            //
            this.colV150410.Name = "colV150410";
            //
            // colV150410TherapieoderHeimkosten
            //
            this.colV150410TherapieoderHeimkosten.Name = "colV150410TherapieoderHeimkosten";
            //
            // colV150411
            //
            this.colV150411.Name = "colV150411";
            //
            // colV150411PauschalefrPersoneninstationrenEinrichtungenSackgeld
            //
            this.colV150411PauschalefrPersoneninstationrenEinrichtungenSackgeld.Name = "colV150411PauschalefrPersoneninstationrenEinrichtungenSackgeld";
            //
            // colV150412
            //
            this.colV150412.Name = "colV150412";
            //
            // colV150412weiteresonstigeLeistungen
            //
            this.colV150412weiteresonstigeLeistungen.Name = "colV150412weiteresonstigeLeistungen";
            //
            // colV150413
            //
            this.colV150413.Name = "colV150413";
            //
            // colV150413Grundbedarf
            //
            this.colV150413Grundbedarf.Name = "colV150413Grundbedarf";
            //
            // colV150414
            //
            this.colV150414.Name = "colV150414";
            //
            // colV150414minusSanktion
            //
            this.colV150414minusSanktion.Name = "colV150414minusSanktion";
            //
            // colV150415
            //
            this.colV150415.Name = "colV150415";
            //
            // colV150415TotalderMinimalenIntegrationszulagenMIZ
            //
            this.colV150415TotalderMinimalenIntegrationszulagenMIZ.Name = "colV150415TotalderMinimalenIntegrationszulagenMIZ";
            //
            // colV150416
            //
            this.colV150416.Name = "colV150416";
            //
            // colV150416TotalderIntegrationszulagenfrNichterwerbsttigeIZU
            //
            this.colV150416TotalderIntegrationszulagenfrNichterwerbsttigeIZU.Name = "colV150416TotalderIntegrationszulagenfrNichterwerbsttigeIZU";
            //
            // colV150417
            //
            this.colV150417.Name = "colV150417";
            //
            // colV150417TotalderEinkommensfreibetrgeEFB
            //
            this.colV150417TotalderEinkommensfreibetrgeEFB.Name = "colV150417TotalderEinkommensfreibetrgeEFB";
            //
            // colV150418
            //
            this.colV150418.Name = "colV150418";
            //
            // colV150418EffektiveErwerbsunkosten
            //
            this.colV150418EffektiveErwerbsunkosten.Name = "colV150418EffektiveErwerbsunkosten";
            //
            // colV1504BruttobedarfderUntersttzungseinheitMonat
            //
            this.colV1504BruttobedarfderUntersttzungseinheitMonat.Name = "colV1504BruttobedarfderUntersttzungseinheitMonat";
            //
            // colV15051
            //
            this.colV15051.Name = "colV15051";
            //
            // colV15051BerechneterNettobedarfgemssSKOS
            //
            this.colV15051BerechneterNettobedarfgemssSKOS.Name = "colV15051BerechneterNettobedarfgemssSKOS";
            //
            // colV15052
            //
            this.colV15052.Name = "colV15052";
            //
            // colV15052ZugesprocheneLeistung
            //
            this.colV15052ZugesprocheneLeistung.Name = "colV15052ZugesprocheneLeistung";
            //
            // colV1506
            //
            this.colV1506.Name = "colV1506";
            //
            // colV1506DatumdererstenAuszahlung
            //
            this.colV1506DatumdererstenAuszahlung.Name = "colV1506DatumdererstenAuszahlung";
            //
            // colV1508
            //
            this.colV1508.Name = "colV1508";
            //
            // colV1508GesamterAuszahlungsbetragseitJahresbeginn
            //
            this.colV1508GesamterAuszahlungsbetragseitJahresbeginn.Name = "colV1508GesamterAuszahlungsbetragseitJahresbeginn";
            //
            // colV1509
            //
            this.colV1509.Name = "colV1509";
            //
            // colV1509GesamterAuszahlungsbetragseitJahresbeginnKrankheitskosten
            //
            this.colV1509GesamterAuszahlungsbetragseitJahresbeginnKrankheitskosten.Name = "colV1509GesamterAuszahlungsbetragseitJahresbeginnKrankheitskosten";
            //
            // colV1511
            //
            this.colV1511.Name = "colV1511";
            //
            // colV1511Januar
            //
            this.colV1511Januar.Name = "colV1511Januar";
            //
            // colV1512
            //
            this.colV1512.Name = "colV1512";
            //
            // colV1512Februar
            //
            this.colV1512Februar.Name = "colV1512Februar";
            //
            // colV1513
            //
            this.colV1513.Name = "colV1513";
            //
            // colV1513Mrz
            //
            this.colV1513Mrz.Name = "colV1513Mrz";
            //
            // colV1514
            //
            this.colV1514.Name = "colV1514";
            //
            // colV1514April
            //
            this.colV1514April.Name = "colV1514April";
            //
            // colV1515
            //
            this.colV1515.Name = "colV1515";
            //
            // colV1515Mai
            //
            this.colV1515Mai.Name = "colV1515Mai";
            //
            // colV1516
            //
            this.colV1516.Name = "colV1516";
            //
            // colV1516Juni
            //
            this.colV1516Juni.Name = "colV1516Juni";
            //
            // colV1517
            //
            this.colV1517.Name = "colV1517";
            //
            // colV1517Juli
            //
            this.colV1517Juli.Name = "colV1517Juli";
            //
            // colV1518
            //
            this.colV1518.Name = "colV1518";
            //
            // colV1518August
            //
            this.colV1518August.Name = "colV1518August";
            //
            // colV1519
            //
            this.colV1519.Name = "colV1519";
            //
            // colV1519September
            //
            this.colV1519September.Name = "colV1519September";
            //
            // colV1520
            //
            this.colV1520.Name = "colV1520";
            //
            // colV1520Oktober
            //
            this.colV1520Oktober.Name = "colV1520Oktober";
            //
            // colV1521
            //
            this.colV1521.Name = "colV1521";
            //
            // colV1521November
            //
            this.colV1521November.Name = "colV1521November";
            //
            // colV1522
            //
            this.colV1522.Name = "colV1522";
            //
            // colV1522Dezember
            //
            this.colV1522Dezember.Name = "colV1522Dezember";
            //
            // colV1601
            //
            this.colV1601.Name = "colV1601";
            //
            // colV1601HatdieUEfrdenMonatDezembereineZahlungerhalten
            //
            this.colV1601HatdieUEfrdenMonatDezembereineZahlungerhalten.Name = "colV1601HatdieUEfrdenMonatDezembereineZahlungerhalten";
            //
            // colV1602
            //
            this.colV1602.Name = "colV1602";
            //
            // colV1602DatumderletztenAuszahlung
            //
            this.colV1602DatumderletztenAuszahlung.Name = "colV1602DatumderletztenAuszahlung";
            //
            // colV1603
            //
            this.colV1603.Name = "colV1603";
            //
            // colV1603AuszahlungsbetrgealsberbrckungvorrangigerLeistungengewhrt
            //
            this.colV1603AuszahlungsbetrgealsberbrckungvorrangigerLeistungengewhrt.Name = "colV1603AuszahlungsbetrgealsberbrckungvorrangigerLeistungengewhrt";
            //
            // colV1604
            //
            this.colV1604.Name = "colV1604";
            //
            // colV1604HauptgrundfrBeendigungderUntersttzungszahlung
            //
            this.colV1604HauptgrundfrBeendigungderUntersttzungszahlung.Name = "colV1604HauptgrundfrBeendigungderUntersttzungszahlung";
            //
            // colV1605
            //
            this.colV1605.Name = "colV1605";
            //
            // colV1605Dossierabgeschlossenam
            //
            this.colV1605Dossierabgeschlossenam.Name = "colV1605Dossierabgeschlossenam";
            //
            // colV201
            //
            this.colV201.Name = "colV201";
            //
            // colV201Name
            //
            this.colV201Name.Name = "colV201Name";
            //
            // colV202
            //
            this.colV202.Name = "colV202";
            //
            // colV202Vornamen
            //
            this.colV202Vornamen.Name = "colV202Vornamen";
            //
            // colV203
            //
            this.colV203.Name = "colV203";
            //
            // colV203FrhererName
            //
            this.colV203FrhererName.Name = "colV203FrhererName";
            //
            // colV204
            //
            this.colV204.Name = "colV204";
            //
            // colV204Strasse
            //
            this.colV204Strasse.Name = "colV204Strasse";
            //
            // colV205
            //
            this.colV205.Name = "colV205";
            //
            // colV205Nummer
            //
            this.colV205Nummer.Name = "colV205Nummer";
            //
            // colV206
            //
            this.colV206.Name = "colV206";
            //
            // colV206ZivilrechtlicherWohnsitzPLZ
            //
            this.colV206ZivilrechtlicherWohnsitzPLZ.Name = "colV206ZivilrechtlicherWohnsitzPLZ";
            //
            // colV207a
            //
            this.colV207a.Name = "colV207a";
            //
            // colV207aZivilrechtlicherWohnsitzBFSCode
            //
            this.colV207aZivilrechtlicherWohnsitzBFSCode.Name = "colV207aZivilrechtlicherWohnsitzBFSCode";
            //
            // colV207b
            //
            this.colV207b.Name = "colV207b";
            //
            // colV207bZivilrechtlicherWohnsitzOrtGemeinde
            //
            this.colV207bZivilrechtlicherWohnsitzOrtGemeinde.Name = "colV207bZivilrechtlicherWohnsitzOrtGemeinde";
            //
            // colV301
            //
            this.colV301.Name = "colV301";
            //
            // colV301UntersttzungswohnsitzPLZ
            //
            this.colV301UntersttzungswohnsitzPLZ.Name = "colV301UntersttzungswohnsitzPLZ";
            //
            // colV302a
            //
            this.colV302a.Name = "colV302a";
            //
            // colV302aUntersttzungswohnsitzBFSCode
            //
            this.colV302aUntersttzungswohnsitzBFSCode.Name = "colV302aUntersttzungswohnsitzBFSCode";
            //
            // colV302b
            //
            this.colV302b.Name = "colV302b";
            //
            // colV302bUntersttzungswohnsitzOrtGemeinde
            //
            this.colV302bUntersttzungswohnsitzOrtGemeinde.Name = "colV302bUntersttzungswohnsitzOrtGemeinde";
            //
            // colV303
            //
            this.colV303.Name = "colV303";
            //
            // colV303AufenthaltsortPLZ
            //
            this.colV303AufenthaltsortPLZ.Name = "colV303AufenthaltsortPLZ";
            //
            // colV304a
            //
            this.colV304a.Name = "colV304a";
            //
            // colV304aAufenthaltsortBFSCode
            //
            this.colV304aAufenthaltsortBFSCode.Name = "colV304aAufenthaltsortBFSCode";
            //
            // colV304b
            //
            this.colV304b.Name = "colV304b";
            //
            // colV304bAufenthaltsortOrtGemeinde
            //
            this.colV304bAufenthaltsortOrtGemeinde.Name = "colV304bAufenthaltsortOrtGemeinde";
            //
            // colV305
            //
            this.colV305.Name = "colV305";
            //
            // colV305BrgerortbzwAuslnder
            //
            this.colV305BrgerortbzwAuslnder.Name = "colV305BrgerortbzwAuslnder";
            //
            // colV306
            //
            this.colV306.Name = "colV306";
            //
            // colV306WohnhaftinderGemeindeseit
            //
            this.colV306WohnhaftinderGemeindeseit.Name = "colV306WohnhaftinderGemeindeseit";
            //
            // colV307
            //
            this.colV307.Name = "colV307";
            //
            // colV307wenigerals2Jahre
            //
            this.colV307wenigerals2Jahre.Name = "colV307wenigerals2Jahre";
            //
            // colV308
            //
            this.colV308.Name = "colV308";
            //
            // colV308ZuzugindieGemeindevonGemeinde
            //
            this.colV308ZuzugindieGemeindevonGemeinde.Name = "colV308ZuzugindieGemeindevonGemeinde";
            //
            // colV309
            //
            this.colV309.Name = "colV309";
            //
            // colV309ZuzugindieGemeindevonLand
            //
            this.colV309ZuzugindieGemeindevonLand.Name = "colV309ZuzugindieGemeindevonLand";
            //
            // colV310
            //
            this.colV310.Name = "colV310";
            //
            // colV310WohnhaftimKantonseit
            //
            this.colV310WohnhaftimKantonseit.Name = "colV310WohnhaftimKantonseit";
            //
            // colV311
            //
            this.colV311.Name = "colV311";
            //
            // colV311wenigerals2Jahre
            //
            this.colV311wenigerals2Jahre.Name = "colV311wenigerals2Jahre";
            //
            // colV312
            //
            this.colV312.Name = "colV312";
            //
            // colV312ZuzugindenKantonvon
            //
            this.colV312ZuzugindenKantonvon.Name = "colV312ZuzugindenKantonvon";
            //
            // colV35002
            //
            this.colV35002.Name = "colV35002";
            //
            // colV35002EinkommenausVermgen
            //
            this.colV35002EinkommenausVermgen.Name = "colV35002EinkommenausVermgen";
            //
            // colV35005
            //
            this.colV35005.Name = "colV35005";
            //
            // colV35005KinderzulagewennnichtimLohnenthalten
            //
            this.colV35005KinderzulagewennnichtimLohnenthalten.Name = "colV35005KinderzulagewennnichtimLohnenthalten";
            //
            // colV35006
            //
            this.colV35006.Name = "colV35006";
            //
            // colV35006Arbeitslosenhilfe
            //
            this.colV35006Arbeitslosenhilfe.Name = "colV35006Arbeitslosenhilfe";
            //
            // colV35007
            //
            this.colV35007.Name = "colV35007";
            //
            // colV35007ELordentliche
            //
            this.colV35007ELordentliche.Name = "colV35007ELordentliche";
            //
            // colV35008
            //
            this.colV35008.Name = "colV35008";
            //
            // colV35008IndividWohnkostenzuschuss
            //
            this.colV35008IndividWohnkostenzuschuss.Name = "colV35008IndividWohnkostenzuschuss";
            //
            // colV35009
            //
            this.colV35009.Name = "colV35009";
            //
            // colV35009ElternMutterschaftsbeitrge
            //
            this.colV35009ElternMutterschaftsbeitrge.Name = "colV35009ElternMutterschaftsbeitrge";
            //
            // colV35010
            //
            this.colV35010.Name = "colV35010";
            //
            // colV35010ErziehungsgeldFamilienzuschuss
            //
            this.colV35010ErziehungsgeldFamilienzuschuss.Name = "colV35010ErziehungsgeldFamilienzuschuss";
            //
            // colV35012
            //
            this.colV35012.Name = "colV35012";
            //
            // colV35012Stipendien
            //
            this.colV35012Stipendien.Name = "colV35012Stipendien";
            //
            // colV35014
            //
            this.colV35014.Name = "colV35014";
            //
            // colV35014andere
            //
            this.colV35014andere.Name = "colV35014andere";
            //
            // colV35017
            //
            this.colV35017.Name = "colV35017";
            //
            // colV35017wirtschaftlicheSozialhilfe
            //
            this.colV35017wirtschaftlicheSozialhilfe.Name = "colV35017wirtschaftlicheSozialhilfe";
            //
            // colV35018
            //
            this.colV35018.Name = "colV35018";
            //
            // colV35018kantonaleBeihilfe
            //
            this.colV35018kantonaleBeihilfe.Name = "colV35018kantonaleBeihilfe";
            //
            // colV35019
            //
            this.colV35019.Name = "colV35019";
            //
            // colV35019direkteIndividuellePrmienverbilligungIPV
            //
            this.colV35019direkteIndividuellePrmienverbilligungIPV.Name = "colV35019direkteIndividuellePrmienverbilligungIPV";
            //
            // colV35020
            //
            this.colV35020.Name = "colV35020";
            //
            // colV35020brigesEinkommenzBVermgensverzehrimStichmonat
            //
            this.colV35020brigesEinkommenzBVermgensverzehrimStichmonat.Name = "colV35020brigesEinkommenzBVermgensverzehrimStichmonat";
            //
            // colV35101
            //
            this.colV35101.Name = "colV35101";
            //
            // colV35101ErwerbseinkommenimStichmonat
            //
            this.colV35101ErwerbseinkommenimStichmonat.Name = "colV35101ErwerbseinkommenimStichmonat";
            //
            // colV35102
            //
            this.colV35102.Name = "colV35102";
            //
            // colV35102ALV
            //
            this.colV35102ALV.Name = "colV35102ALV";
            //
            // colV35103
            //
            this.colV35103.Name = "colV35103";
            //
            // colV35103Altersrente
            //
            this.colV35103Altersrente.Name = "colV35103Altersrente";
            //
            // colV35104
            //
            this.colV35104.Name = "colV35104";
            //
            // colV35104WitwenWaisenrente
            //
            this.colV35104WitwenWaisenrente.Name = "colV35104WitwenWaisenrente";
            //
            // colV35105
            //
            this.colV35105.Name = "colV35105";
            //
            // colV35105BVG
            //
            this.colV35105BVG.Name = "colV35105BVG";
            //
            // colV35106
            //
            this.colV35106.Name = "colV35106";
            //
            // colV35106Hilflosenentschdigung
            //
            this.colV35106Hilflosenentschdigung.Name = "colV35106Hilflosenentschdigung";
            //
            // colV35107
            //
            this.colV35107.Name = "colV35107";
            //
            // colV35107IVRente
            //
            this.colV35107IVRente.Name = "colV35107IVRente";
            //
            // colV35108
            //
            this.colV35108.Name = "colV35108";
            //
            // colV35108SUVARente
            //
            this.colV35108SUVARente.Name = "colV35108SUVARente";
            //
            // colV35112
            //
            this.colV35112.Name = "colV35112";
            //
            // colV35112AndereSozialversicherungsleistungenRenteTaggelder
            //
            this.colV35112AndereSozialversicherungsleistungenRenteTaggelder.Name = "colV35112AndereSozialversicherungsleistungenRenteTaggelder";
            //
            // colV35113
            //
            this.colV35113.Name = "colV35113";
            //
            // colV35113Unterhaltsbeitrge
            //
            this.colV35113Unterhaltsbeitrge.Name = "colV35113Unterhaltsbeitrge";
            //
            // colV35114
            //
            this.colV35114.Name = "colV35114";
            //
            // colV35114Alimentenbevorschussung
            //
            this.colV35114Alimentenbevorschussung.Name = "colV35114Alimentenbevorschussung";
            //
            // colV35115
            //
            this.colV35115.Name = "colV35115";
            //
            // colV35115TaggelderKKSUVAIV
            //
            this.colV35115TaggelderKKSUVAIV.Name = "colV35115TaggelderKKSUVAIV";
            //
            // colV4001
            //
            this.colV4001.Name = "colV4001";
            //
            // colV40011
            //
            this.colV40011.Name = "colV40011";
            //
            // colV40011ZugesprochenerBetragimStichmonatanAntragsteller
            //
            this.colV40011ZugesprochenerBetragimStichmonatanAntragsteller.Name = "colV40011ZugesprochenerBetragimStichmonatanAntragsteller";
            //
            // colV40012
            //
            this.colV40012.Name = "colV40012";
            //
            // colV40012DatumdererstenAuszahlung
            //
            this.colV40012DatumdererstenAuszahlung.Name = "colV40012DatumdererstenAuszahlung";
            //
            // colV40013
            //
            this.colV40013.Name = "colV40013";
            //
            // colV40013GesamterAuszahlungsbetragseitJahresbeginn
            //
            this.colV40013GesamterAuszahlungsbetragseitJahresbeginn.Name = "colV40013GesamterAuszahlungsbetragseitJahresbeginn";
            //
            // colV40014
            //
            this.colV40014.Name = "colV40014";
            //
            // colV40014HatderAntragsteller1MitgliedUEfrdenMonatDezembereineZahlungerhalten
            //
            this.colV40014HatderAntragsteller1MitgliedUEfrdenMonatDezembereineZahlungerhalten.Name = "colV40014HatderAntragsteller1MitgliedUEfrdenMonatDezembereineZahlungerhalten";
            //
            // colV40015
            //
            this.colV40015.Name = "colV40015";
            //
            // colV40015DatumderletztenAuszahlung
            //
            this.colV40015DatumderletztenAuszahlung.Name = "colV40015DatumderletztenAuszahlung";
            //
            // colV4001WiederaufnahmenachUnterbrechung6MteoBezug
            //
            this.colV4001WiederaufnahmenachUnterbrechung6MteoBezug.Name = "colV4001WiederaufnahmenachUnterbrechung6MteoBezug";
            //
            // colV401
            //
            this.colV401.Name = "colV401";
            //
            // colV401Geburtsdatum
            //
            this.colV401Geburtsdatum.Name = "colV401Geburtsdatum";
            //
            // colV402
            //
            this.colV402.Name = "colV402";
            //
            // colV402Geschlecht
            //
            this.colV402Geschlecht.Name = "colV402Geschlecht";
            //
            // colV403
            //
            this.colV403.Name = "colV403";
            //
            // colV403Zivilstand
            //
            this.colV403Zivilstand.Name = "colV403Zivilstand";
            //
            // colV404
            //
            this.colV404.Name = "colV404";
            //
            // colV404Nationalitt
            //
            this.colV404Nationalitt.Name = "colV404Nationalitt";
            //
            // colV405
            //
            this.colV405.Name = "colV405";
            //
            // colV405Aufenthaltsstatus
            //
            this.colV405Aufenthaltsstatus.Name = "colV405Aufenthaltsstatus";
            //
            // colV406
            //
            this.colV406.Name = "colV406";
            //
            // colV406InderSchweizseitwann
            //
            this.colV406InderSchweizseitwann.Name = "colV406InderSchweizseitwann";
            //
            // colV407
            //
            this.colV407.Name = "colV407";
            //
            // colV407LebtimHaushaltallein
            //
            this.colV407LebtimHaushaltallein.Name = "colV407LebtimHaushaltallein";
            //
            // colV408
            //
            this.colV408.Name = "colV408";
            //
            // colV408PersonenimgesamtenHaushalt
            //
            this.colV408PersonenimgesamtenHaushalt.Name = "colV408PersonenimgesamtenHaushalt";
            //
            // colV409
            //
            this.colV409.Name = "colV409";
            //
            // colV409PersoneninUntersttzungseinheit
            //
            this.colV409PersoneninUntersttzungseinheit.Name = "colV409PersoneninUntersttzungseinheit";
            //
            // colV5101
            //
            this.colV5101.Name = "colV5101";
            //
            // colV5101BeziehungstypzurAntragstellendenPerson
            //
            this.colV5101BeziehungstypzurAntragstellendenPerson.Name = "colV5101BeziehungstypzurAntragstellendenPerson";
            //
            // colV5a2
            //
            this.colV5a2.Name = "colV5a2";
            //
            // colV5a2SeparateUntersttzungDossier
            //
            this.colV5a2SeparateUntersttzungDossier.Name = "colV5a2SeparateUntersttzungDossier";
            //
            // colV601
            //
            this.colV601.Name = "colV601";
            //
            // colV601Wohnstatus
            //
            this.colV601Wohnstatus.Name = "colV601Wohnstatus";
            //
            // colV602
            //
            this.colV602.Name = "colV602";
            //
            // colV602Wohnungsgrssegesamt
            //
            this.colV602Wohnungsgrssegesamt.Name = "colV602Wohnungsgrssegesamt";
            //
            // colV603
            //
            this.colV603.Name = "colV603";
            //
            // colV603MietkostenganzeWohnung
            //
            this.colV603MietkostenganzeWohnung.Name = "colV603MietkostenganzeWohnung";
            //
            // colV604
            //
            this.colV604.Name = "colV604";
            //
            // colV604MietkostenanteilsmssigtatschlichangrechneteundbernommeneMietkosten
            //
            this.colV604MietkostenanteilsmssigtatschlichangrechneteundbernommeneMietkosten.Name = "colV604MietkostenanteilsmssigtatschlichangrechneteundbernommeneMietkosten";
            //
            // colV7011
            //
            this.colV7011.Name = "colV7011";
            //
            // colV70111Erwerbssituation
            //
            this.colV70111Erwerbssituation.Name = "colV70111Erwerbssituation";
            //
            // colV7012
            //
            this.colV7012.Name = "colV7012";
            //
            // colV70122Erwerbssituation
            //
            this.colV70122Erwerbssituation.Name = "colV70122Erwerbssituation";
            //
            // colV7013
            //
            this.colV7013.Name = "colV7013";
            //
            // colV70133Erwerbssituation
            //
            this.colV70133Erwerbssituation.Name = "colV70133Erwerbssituation";
            //
            // colV7014
            //
            this.colV7014.Name = "colV7014";
            //
            // colV70144Erwerbssituation
            //
            this.colV70144Erwerbssituation.Name = "colV70144Erwerbssituation";
            //
            // colV7021
            //
            this.colV7021.Name = "colV7021";
            //
            // colV7021NormalarbeitszeitproWoche
            //
            this.colV7021NormalarbeitszeitproWoche.Name = "colV7021NormalarbeitszeitproWoche";
            //
            // colV7022
            //
            this.colV7022.Name = "colV7022";
            //
            // colV7022keineregelmssigeArbeitszeit
            //
            this.colV7022keineregelmssigeArbeitszeit.Name = "colV7022keineregelmssigeArbeitszeit";
            //
            // colV703
            //
            this.colV703.Name = "colV703";
            //
            // colV703Beschftigungsgrad
            //
            this.colV703Beschftigungsgrad.Name = "colV703Beschftigungsgrad";
            //
            // colV704
            //
            this.colV704.Name = "colV704";
            //
            // colV704HauptgrundfrTeilzeit
            //
            this.colV704HauptgrundfrTeilzeit.Name = "colV704HauptgrundfrTeilzeit";
            //
            // colV705
            //
            this.colV705.Name = "colV705";
            //
            // colV705WeitererGrundfrTeilzeit
            //
            this.colV705WeitererGrundfrTeilzeit.Name = "colV705WeitererGrundfrTeilzeit";
            //
            // colV706
            //
            this.colV706.Name = "colV706";
            //
            // colV706Stempelbeginn
            //
            this.colV706Stempelbeginn.Name = "colV706Stempelbeginn";
            //
            // colV707
            //
            this.colV707.Name = "colV707";
            //
            // colV707Ausgesteuert
            //
            this.colV707Ausgesteuert.Name = "colV707Ausgesteuert";
            //
            // colV708
            //
            this.colV708.Name = "colV708";
            //
            // colV708Ausgesteuertseit
            //
            this.colV708Ausgesteuertseit.Name = "colV708Ausgesteuertseit";
            //
            // colV709
            //
            this.colV709.Name = "colV709";
            //
            // colV709ErlernterBeruf
            //
            this.colV709ErlernterBeruf.Name = "colV709ErlernterBeruf";
            //
            // colV710
            //
            this.colV710.Name = "colV710";
            //
            // colV710LetzteodergegenwrtigeberuflicheTtigkeit
            //
            this.colV710LetzteodergegenwrtigeberuflicheTtigkeit.Name = "colV710LetzteodergegenwrtigeberuflicheTtigkeit";
            //
            // colV711
            //
            this.colV711.Name = "colV711";
            //
            // colV711Branche
            //
            this.colV711Branche.Name = "colV711Branche";
            //
            // colV712
            //
            this.colV712.Name = "colV712";
            //
            // colV712Wieoftindenletzten3Jahrenarbeitslosgewesen
            //
            this.colV712Wieoftindenletzten3Jahrenarbeitslosgewesen.Name = "colV712Wieoftindenletzten3Jahrenarbeitslosgewesen";
            //
            // colV713
            //
            this.colV713.Name = "colV713";
            //
            // colV713HchsteabgeschlosseneAusbildung
            //
            this.colV713HchsteabgeschlosseneAusbildung.Name = "colV713HchsteabgeschlosseneAusbildung";
            //
            // colV714
            //
            this.colV714.Name = "colV714";
            //
            // colV714EineAusbildungvordemAbschlussabgebrochen
            //
            this.colV714EineAusbildungvordemAbschlussabgebrochen.Name = "colV714EineAusbildungvordemAbschlussabgebrochen";
            //
            // colV715
            //
            this.colV715.Name = "colV715";
            //
            // colV715LetzteabgebrocheneAusbildung
            //
            this.colV715LetzteabgebrocheneAusbildung.Name = "colV715LetzteabgebrocheneAusbildung";
            //
            // colV801
            //
            this.colV801.Name = "colV801";
            //
            // colV801IVEingliederungsmassnahmen
            //
            this.colV801IVEingliederungsmassnahmen.Name = "colV801IVEingliederungsmassnahmen";
            //
            // colV802
            //
            this.colV802.Name = "colV802";
            //
            // colV802PflegebedrftigePersonenimHaushaltinsgesamt
            //
            this.colV802PflegebedrftigePersonenimHaushaltinsgesamt.Name = "colV802PflegebedrftigePersonenimHaushaltinsgesamt";
            //
            // colV803
            //
            this.colV803.Name = "colV803";
            //
            // colV803PflegeoderBetreuungdurch
            //
            this.colV803PflegeoderBetreuungdurch.Name = "colV803PflegeoderBetreuungdurch";
            //
            // colV901
            //
            this.colV901.Name = "colV901";
            //
            // colV901KrankenversicherungGrundversicherung
            //
            this.colV901KrankenversicherungGrundversicherung.Name = "colV901KrankenversicherungGrundversicherung";
            //
            // colV902
            //
            this.colV902.Name = "colV902";
            //
            // colV902KrankenversicherungZusatzversicherung
            //
            this.colV902KrankenversicherungZusatzversicherung.Name = "colV902KrankenversicherungZusatzversicherung";
            //
            // colV904
            //
            this.colV904.Name = "colV904";
            //
            // colV904KrankenkasseName
            //
            this.colV904KrankenkasseName.Name = "colV904KrankenkasseName";
            //
            // colV905
            //
            this.colV905.Name = "colV905";
            //
            // colV905KrankenkassenPrmieganzeUE
            //
            this.colV905KrankenkassenPrmieganzeUE.Name = "colV905KrankenkassenPrmieganzeUE";
            //
            // colV9061
            //
            this.colV9061.Name = "colV9061";
            //
            // colV9061KrankenkassenprmienzuschussIPVganzeUE
            //
            this.colV9061KrankenkassenprmienzuschussIPVganzeUE.Name = "colV9061KrankenkassenprmienzuschussIPVganzeUE";
            //
            // colV9062
            //
            this.colV9062.Name = "colV9062";
            //
            // colV9062KrankenkassenprmienzuschussIPVganzeUE
            //
            this.colV9062KrankenkassenprmienzuschussIPVganzeUE.Name = "colV9062KrankenkassenprmienzuschussIPVganzeUE";
            //
            // gridView1
            //
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            //
            // edtSARX
            //
            this.edtSARX.Location = new System.Drawing.Point(112, 75);
            this.edtSARX.Name = "edtSARX";
            this.edtSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSARX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSARX.Properties.Appearance.Options.UseFont = true;
            this.edtSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSARX.Size = new System.Drawing.Size(237, 24);
            this.edtSARX.TabIndex = 30;
            this.edtSARX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSARX_UserModifiedFld);
            //
            // lblSARX
            //
            this.lblSARX.Location = new System.Drawing.Point(24, 75);
            this.lblSARX.Name = "lblSARX";
            this.lblSARX.Size = new System.Drawing.Size(82, 24);
            this.lblSARX.TabIndex = 29;
            this.lblSARX.Text = "Mitarbeiter/-in";
            this.lblSARX.UseCompatibleTextRendering = true;
            //
            // lblSektion
            //
            this.lblSektion.Location = new System.Drawing.Point(24, 165);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(82, 24);
            this.lblSektion.TabIndex = 150;
            this.lblSektion.Text = "Sektion/Team";
            this.lblSektion.UseCompatibleTextRendering = true;
            //
            // edtSektionX
            //
            this.edtSektionX.Location = new System.Drawing.Point(112, 165);
            this.edtSektionX.Name = "edtSektionX";
            this.edtSektionX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSektionX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSektionX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektionX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSektionX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSektionX.Properties.Appearance.Options.UseFont = true;
            this.edtSektionX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSektionX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektionX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSektionX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSektionX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSektionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSektionX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSektionX.Properties.NullText = "";
            this.edtSektionX.Properties.ShowFooter = false;
            this.edtSektionX.Properties.ShowHeader = false;
            this.edtSektionX.Size = new System.Drawing.Size(236, 24);
            this.edtSektionX.TabIndex = 149;
            //
            // qrySektion
            //
            this.qrySektion.SelectStatement = "SELECT \r\n   Text = ItemName,   \r\n   Code = OrgUnitID\r\nFROM XOrgUnit\r\nUNION\r\nSELEC" +
                "T\r\n   Text = \'\',\r\n   Code = null\r\nORDER BY Text";
            //
            // edtNurAnfangszustandX
            //
            this.edtNurAnfangszustandX.EditValue = true;
            this.edtNurAnfangszustandX.Location = new System.Drawing.Point(207, 204);
            this.edtNurAnfangszustandX.Name = "edtNurAnfangszustandX";
            this.edtNurAnfangszustandX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAnfangszustandX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAnfangszustandX.Properties.Caption = "Anfangszustand";
            this.edtNurAnfangszustandX.Size = new System.Drawing.Size(124, 19);
            this.edtNurAnfangszustandX.TabIndex = 12;
            //
            // edtNurStichtagX
            //
            this.edtNurStichtagX.EditValue = true;
            this.edtNurStichtagX.Location = new System.Drawing.Point(112, 204);
            this.edtNurStichtagX.Name = "edtNurStichtagX";
            this.edtNurStichtagX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurStichtagX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurStichtagX.Properties.Caption = "Stichtag";
            this.edtNurStichtagX.Size = new System.Drawing.Size(89, 19);
            this.edtNurStichtagX.TabIndex = 11;
            //
            // btnExportCSV
            //
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Location = new System.Drawing.Point(673, 400);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(96, 24);
            this.btnExportCSV.TabIndex = 4;
            this.btnExportCSV.Text = "&Export CSV";
            this.btnExportCSV.UseCompatibleTextRendering = true;
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            //
            // btnLoadColDef
            //
            this.btnLoadColDef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadColDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadColDef.Location = new System.Drawing.Point(571, 400);
            this.btnLoadColDef.Name = "btnLoadColDef";
            this.btnLoadColDef.Size = new System.Drawing.Size(96, 24);
            this.btnLoadColDef.TabIndex = 5;
            this.btnLoadColDef.Text = "&Reset Kol-Def.";
            this.btnLoadColDef.UseCompatibleTextRendering = true;
            this.btnLoadColDef.UseVisualStyleBackColor = false;
            this.btnLoadColDef.Click += new System.EventHandler(this.btnLoadColDef_Click);
            //
            // btnSaveColDef
            //
            this.btnSaveColDef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveColDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveColDef.Location = new System.Drawing.Point(447, 400);
            this.btnSaveColDef.Name = "btnSaveColDef";
            this.btnSaveColDef.Size = new System.Drawing.Size(118, 24);
            this.btnSaveColDef.TabIndex = 6;
            this.btnSaveColDef.Text = "&Speichere Kol-Def.";
            this.btnSaveColDef.UseCompatibleTextRendering = true;
            this.btnSaveColDef.UseVisualStyleBackColor = false;
            this.btnSaveColDef.Click += new System.EventHandler(this.btnSaveColDef_Click);
            //
            // CtlBfsQueryVariablen
            //
            this.Name = "CtlBfsQueryVariablen";
            this.Load += new System.EventHandler(this.CtlBfsQueryVariablen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkNurDossiertraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcelExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErhebungsjahrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSARX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAnfangszustandX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurStichtagX.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void CtlBfsQueryVariablen_Load(object sender, System.EventArgs e)
        {
            edtBFSLeistungsartCode.LoadQuery(DBUtil.OpenSQL(@"
                select Code, Text
                from   BFSLOVCode
                where  LOVName = 'BFSLeistungsart'"));

            // Auswahl der Sektionen erstellen
            qrySektion.Fill();
            edtSektionX.LoadQuery(qrySektion);
            edtSektionX.ItemIndex = 0;

            edtBFSLeistungsartCode.EditValue = 2;
        }

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg["Name"];
                edtBaPersonID.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtSARX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtSARX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtSARX.EditValue = null;
                    edtSARX.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSARX.EditValue = dlg["Name"];
                edtSARX.LookupID = dlg["UserID"];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            this.edtErhebungsjahr.Text = DBUtil.GetConfigValue(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year).ToString();
        }

        protected override void RunSearch()
        {
            ResetSelectColumns();
            base.RunSearch();
        }

        #endregion

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.DefaultExt = "*.csv";
            dlg.InitialDirectory = DBUtil.GetConfigValue(@"System\Sostat\Exportpfad", "C:\temp").ToString();
            dlg.FileName = string.Format("BFSVariablen_Export_{0:yyyy-MM-dd}.csv", DateTime.UtcNow);

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string exportPath = dlg.FileName;

            StreamWriter stream = new StreamWriter(exportPath, false, Encoding.Default);

            StringBuilder csvRow = new StringBuilder();

            // Kolonnen-Titel
            for (int col = 0; col < qryQuery.DataTable.Columns.Count; col++)
            {
                csvRow.Append(qryQuery.DataTable.Columns[col].Caption.Replace(";", ",")).Append(";");
            }
            stream.WriteLine(csvRow);

            int rowCount = 0;
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                csvRow = new StringBuilder();
                for (int col = 0; col < qryQuery.DataTable.Columns.Count; col++)
                {
                    csvRow.Append(row[col].ToString().Replace(";", ",")).Append(";");
                }

                stream.WriteLine(csvRow);
                rowCount++;
            }

            stream.Close();

            KissMsg.ShowInfo(string.Format("Der Export ist erfolgreich erstellt, {0} Zeilen exportiert. Das File kann mit Excel geöffnet werden.", rowCount));
        }

        #endregion

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            try
            {
                Stream stream = new MemoryStream();
                grdQuery1.View.SaveLayoutToStream(stream, OptionsLayoutBase.FullLayout);
                stream.Seek(0, SeekOrigin.Begin);

                Label tempLbl = new Label();

                using (StreamReader reader = new StreamReader(stream))
                {
                    tempLbl.Text = reader.ReadToEnd();
                }

                stream.Close();
                stream.Dispose();

                KissControlLayout.SaveSimpleProperty(e, CTL_BFS_QUERY_VARIABLEN_GRID_COL_DEF + edtBFSLeistungsartCode.EditValue, tempLbl, "Text");
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Es ist ein Fehler beim Speichern des Kolonnen-Layouts aufgetreten.", ex);
            }
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            try
            {
                Label tempLbl = new Label();

                KissControlLayout.ReadSimpleProperty(e, CTL_BFS_QUERY_VARIABLEN_GRID_COL_DEF + edtBFSLeistungsartCode.EditValue, tempLbl, "Text");

                if (tempLbl.Text != null && tempLbl.Text != "")
                {
                    Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(tempLbl.Text));
                    grdQuery1.View.RestoreLayoutFromStream(stream, OptionsLayoutBase.FullLayout);
                    stream.Close();
                    stream.Dispose();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Es ist ein Fehler beim Laden des Kolonnen-Layouts aufgetreten. Bitte speichern Sie das Kolonnen-Layout nochmals ab.", ex);
            }
        }

        private void btnLoadColDef_Click(object sender, EventArgs e)
        {
            RestoreLayout();
        }

        private void btnSaveColDef_Click(object sender, EventArgs e)
        {
            SaveLayout();
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            RestoreLayout();
        }
    }
}