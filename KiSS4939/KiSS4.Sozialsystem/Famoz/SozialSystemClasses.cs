using System;
using System.Collections.Generic;
using System.Drawing;

namespace KiSS4.Sozialsystem.Famoz
{
    #region Aufzählungstypen für Grafische Darstellung

    public enum DockPointTextTypes
    {
        dptClient,     // Dockingpunkt ist für Linien Klienten
        dptInvPerson,  // Dockingpunkt ist für Linien inv. Personen
        dptInvOrg      // Dockingpunkt ist für Linien inv. Institutionen
    };

    public enum DockPointTypes
    {
        dpNone,    // ohne Definition
        dpTop,     // Linie wird oben an Box angefügt
        dpBottom,  // Linie wird unten an Box angefügt
        dpLeft,    // Linie wird links an Box angefügt
        dpRight    // Linie wird rechts an Box angefügt
    };

    public enum LineDirectionType
    {
        ldHor, // Horizontal einfach
        ldVer  // Vertikal einfach
    };

    public enum LineTypes
    {
        ltNone,         // Keine Zuordnung
        ltHor,          // Horizontal einfach
        ltVer,          // Vertikal einfach
        ltHorMany,      // Horizontal mehrfach
        ltVerMany,      // Vertikal mehrfach
        ltSimple,       // Komplex: Horizontal mehrfach und/oder Vertikal mehrfach
        ltComplexMany   // Komplex: Horizontal mehrfach und/oder Vertikal mehrfach
    };

    //public enum SSGraphPersonTypes
    //{
    //    cstServiceProvider,  // Leistungserbringer
    //    cstClient,           // Klient
    //    cstParent,           // Eltern
    //    cstPartner,          // Ehepartner
    //    cstBrotherSister,    // Geschwister
    //    cstChilds            // Kinder
    //};

    #endregion

    #region Klasse für Bestimmung der Docking Points

    public class DockPoint
    {
        public int Count;
        public string DockingText = "";
        public bool HasPosition;
        public int LineItemIdx;
        public LineTypes LineType;
        public int Position;
        public int PreferedPosition = 0;  // 0 = Mitte, 1,2,3 = rechts/unten, -1, -2, -3 = links/oben
        public DockPointTextTypes TextType;
    }

    #endregion

    #region Klasse für Bestimmung der Distanzen zwischen zwei Boxen

    public class BoxSpaces
    {
        //public int LabelTopLeftCount = 0;
        // Gibt an, ob es unterhalb oder lirechts Labels hat
        public bool HasLabelBottomRight = false;

        // Gibt an, ob es oberhalb oder links Labels hat
        public bool HasLabelTopLeft = false;

        // 0 = Abstand zwischen Rand und erster Box
        // 1 = Abstand zwischen erster und zweiter Box, usw:
        // Anzahl zusätzlicher Linien
        public int LineCount = 1;

        public int PixelSize = 0;
        public int StartTopLeft = 0;
        //public int LabelBottomRightCount = 0;
    }

    #endregion

    #region Klasse für Klienten und Bezugspersonen

    public class SSGraphPerson
    {
        public Int32 Age;
        public List<DockPoint> dpListBottom = new List<DockPoint>();
        public List<DockPoint> dpListLeft = new List<DockPoint>();
        public List<DockPoint> dpListRight = new List<DockPoint>();
        public List<DockPoint> dpListTop = new List<DockPoint>();
        public String FirstName;
        public Int32 Gender;
        public Boolean HasPosition;
        public Boolean HasRelation;
        public String InfoText;
        public Boolean IsDead = false;
        public String LastName;
        public Point Location;
        public Int32 PersonID;
        public Point Pixels;
    }

    #endregion

    #region Klasse für Anzahl Positionierungen auf einer Zeile

    //
    //public class SSGraphLineCount
    //{
    //    public int Line;
    //    public int Count;
    //}

    #endregion

    #region Klasse für Relationen

    // Klasse für Relationen
    public class SSGraphRelation
    {
        public int DockPointFromIdx;

        // Index auf Liste der Dockingpoints in der Liste der Person 1
        public int DockPointToIdx;

        public Point From;

        public bool IsProcessed;

        // Relation abgearbeitet
        public bool LinesProcessed;

        public LineTypes LineType;

        // DB-Keys
        public int PersonID1;

        public int PersonID2;

        // Index der Liste der Perosnen
        public int PListID1;

        public int PListID2;
        public string RelationName1;
        public string RelationName2;

        //public int SymmetricStep;
        public int Stufe;

        //public int RelationCode;
        public bool Symmetric;

        // Reiehenfolge zum erstellen der Linien
        // Typ der Linie
        // Startpunkt in Gitter-Koordinaten
        public Point To;                   // Endpunkt in Gitter-Koordinaten

        // Linien wurden erstellt
        // Index auf Liste der Dockingpoints in der Liste der Person 2
    }

    #endregion

    #region Klasse für Leistungserbringer

    //
    public class SSGraphServiceProvider
    {
        public int ClientID;
        public string Contact;
        public string FirstName;
        public string Function;
        public int IconID;
        public string LastName;
        public int Left;
        public Point Location;
        public string Organisation;
        public int UserID;
        public int Width;
    }

    #endregion

    #region Klasse für involvierte Personen

    //
    public class SSGraphInvolvedPerson
    {
        public int ClientID;
        public string Contact;
        public string FirstName;
        public string Function;
        public int Gender;
        public int Height;
        public string LastName;
        public int Left;
        public Point Location;
        public int Top;
        public int Width;
    }

    #endregion

    #region Klasse für involvierte Stellen

    //
    public class SSGraphInvolOrg
    {
        public Int32 ClientID;
        public String Contact;
        public String ContactPerson;
        public String EMail;
        public Int32 Height;
        public String InstitutionName;
        public Int32 Left;
        public Point Location;
        public String Ort;
        public String PLZ;
        public String Relation;
        public Int32 Top;
        public Int32 Width;
    }

    #endregion

    #region Klasse für ein Teil einer Verbindungslinie

    //
    public class SSGraphLineItem
    {
        public System.Windows.Forms.AnchorStyles Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        public int BoxPositionX = 0;
        public int BoxPositionY = 0;
        public List<System.Drawing.Point> CrossPoints = new List<Point>();
        public int DeltaToX;
        public int DeltaToY;
        public string DockingTextFrom;
        public string DockingTextTo;
        public int DockPointFromIdx;

        // Liefert den Index der Liste DockingPoints in der Klasse der Personen beim Start
        public int DockPointToIdx;

        public DockPointTypes dpTypeEnd = DockPointTypes.dpNone;
        public DockPointTypes dpTypeStart = DockPointTypes.dpNone;
        public Point From;
        public int FromPersonIdx;
        public Point GridFrom;

        //public SSGraphDockPointTypes DockPointFrom;
        //public SSGraphDockPointTypes DockPointTo;
        public int GridLineX;

        // Liegt links neben dem Gitterpunkt auf einer vertikalen Linie
        public int GridLineY;

        // Startpunkt in Gitterkoordinaten, damit die zusätzlichen Abstände einfach korrigiert werden können
        public Point GridTo;

        public bool IsEndPoint;

        // Endpunkt in Gitterkoordinaten, damit die zusätzlichen Abstände einfach korrigiert werden können
        public bool IsStartPoint;

        // Liegt oberhalb dem Gitterpunkt auf einer horizontalen Linie
        // Liefert den Index der Liste DockingPoints in der Klasse der Personen beim Ende
        public LineDirectionType LineDir;

        public int LineIndex;
        public int RelationID;  // Index in der Liste aller Relationen

        // Nummerierung der einzelen Linien
        // Startpunkt in Pixels
        public Point To;        // Endpunkt in Pixels

        public int ToPersonIdx;
    }

    #endregion

    #region Klasse für eine Verbindungslinie

    ////
    //public class SSGraphLine
    //{
    //    public int IDFrom;
    //    public int IDTo;
    //    //public SSGraphLineConnects SSGraphLineConnectsFrom;
    //    //public SSGraphLineConnects SSGraphLineConnectsTo;
    //    //public string RelationName1;
    //    //public string RelationName2;
    //    public List<SSGraphLineItem> SSGraphLineItemList;
    //}

    #endregion

    #region Klasse für ein Element auf der Zeichnungsfläche

    //
    //public class SSGraphElement
    //{
    //    public int ID;
    //    public int PosX;
    //    public int PosY;
    //    public int PersonID;
    //    public int RelationID;
    //    public SSGraphPersonTypes aSSGraphPersonTypes;
    //    public List<SSGraphLine> aSSGraphLineList;
    //}

    #endregion

    #region Klasse für ein Icon

    public class SSGraphIDRelation
    {
        public int ID;
        public int RelID;
    }

    #endregion
}