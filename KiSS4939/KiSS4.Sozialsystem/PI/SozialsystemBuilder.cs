using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Sozialsystem.Famoz;

namespace KiSS4.Sozialsystem.PI
{
    public class SozialsystemBuilder
    {
        #region Constants

        // Weite des Randes zur äusseren ersten Box-Linie inv. Organisationen
        public const int cstBordInvOrgs = 20;

        // Weite des Randes zur äusseren ersten Box-Linie
        //public const int cstBordClient = 20;
        // Weite des Randes zur äusseren ersten Box-Linie inv. Personen
        public const int cstBordInvPers = 20;

        public const int cstBoxBorderX = 20;
        public const int cstBoxBorderY = 20;

        // Breite der Boxen für Klienten
        public const int cstClientBoxSizeX = 200;

        // Höhe der Boxen für Klienten
        public const int cstClientBoxSizeY = 78;

        public const int cstDistanceInvOrgsY = 20;
        public const int cstDistanceInvPersY = 20;

        // Halbe Breite der Boxen für Klienten
        public const int cstHalfSizeX = 100;

        // Halbe Höhe der Boxen für Klienten
        public const int cstHalfSizeY = 39;

        // Höhe der Beschriftung der Relationslinie
        public const int cstLabelHeight = 78;

        // Weite der Beschriftung der Relationslinie
        public const int cstLabelWidth = 20;

        // Distanz zwischen zwei vertikalen Linien
        public const int cstLineSpaceX = 16;

        // Distanz zwischen zwei horizontalen Linien
        public const int cstLineSpaceY = 16;

        public const int cstMaxDockingPoints = 10000;

        // Max. Anzahl Stufen für Priorität der Linienerstellung
        public const int cstMaxLineGeneratingSteps = 6;

        // Distanz zwischen zwei Leistungserbringer
        public const int cstServProvBorderTop = 30;

        // Distanz zwischen zwei Leistungserbringer
        public const int cstServProvSpaceX = 20;

        // Dieser Abstand berücksichtigt die Höhe des Titel-Labels:
        public const int cstTitelLabelHeight = 30;

        #endregion

        #region Fields

        public List<SSGraphIDRelation> ClientIcons = new List<SSGraphIDRelation>();
        public List<SSGraphLineItem> ClientLines = new List<SSGraphLineItem>();
        public List<SSGraphLineItem> InvOrgLines = new List<SSGraphLineItem>();
        public List<SSGraphLineItem> InvPersLines = new List<SSGraphLineItem>();
        public List<SSGraphIDRelation> ServProvClients = new List<SSGraphIDRelation>();
        public List<SSGraphIDRelation> ServProvIcons = new List<SSGraphIDRelation>();
        private List<BoxSpaces> aBoxSpacesListX = new List<BoxSpaces>();
        private List<BoxSpaces> aBoxSpacesListY = new List<BoxSpaces>();
        private List<SSGraphInvolOrg> InvOrgsList = new List<SSGraphInvolOrg>();
        private List<SSGraphInvolvedPerson> InvPersList = new List<SSGraphInvolvedPerson>();

        // Liste aller Klienten
        private List<SSGraphPerson> PersonList = new List<SSGraphPerson>();

        // Liste aller Relationen
        private List<SSGraphRelation> RelationList = new List<SSGraphRelation>();

        // Liste aller Linienstücke, welche für eine Relationslinie zusammen gesetzt werden
        private List<SSGraphServiceProvider> ServProvList = new List<SSGraphServiceProvider>();

        #endregion

        #region Constructors

        public SozialsystemBuilder(PI.CtlSozialsystem aCtlSozialsystem, Int32 BaPersonID)
        {
            #region SQL Anweisung um Daten aus Db zu holen

            // Korrekte Version (kann noch mit Datum (hier NULL) erweitert werden)
            SqlCommand aCmd = new SqlCommand(String.Format("EXEC dbo.spFaGetSozialsystem {0}, NULL, {1}", BaPersonID, Session.User.LanguageCode), Session.Connection);

            #endregion

            #region Daten abfüllen

            SqlDataReader aSDR = aCmd.ExecuteReader();
            Int32 TmpIdx = 0;

            // Resultat der StoredProcedure auslesen
            try
            {
                // Personen
                TmpIdx = 0;
                while (aSDR.Read())
                {
                    // create new person
                    SSGraphPerson aSSGraphPerson = new SSGraphPerson();

                    // apply values from db
                    aSSGraphPerson.PersonID = Utils.ConvertToInt(aSDR["baPersonID"]);
                    aSSGraphPerson.FirstName = Utils.ConvertToString(aSDR["Vorname"]);
                    aSSGraphPerson.LastName = Utils.ConvertToString(aSDR["Name"]);
                    aSSGraphPerson.Gender = DBUtil.IsEmpty(aSDR["GeschlechtCode"]) ? 1 : (int)aSDR["GeschlechtCode"];
                    aSSGraphPerson.Age = Utils.ConvertToInt(aSDR["Alter"]);
                    aSSGraphPerson.IsDead = Utils.ConvertToBool(aSDR["Gestorben"]);

                    // setup position
                    aSSGraphPerson.Location.X = -1;
                    aSSGraphPerson.Location.Y = -1;
                    aSSGraphPerson.HasPosition = false;

                    // add to list
                    PersonList.Add(aSSGraphPerson);

                    // count up
                    TmpIdx += 1;
                }

                // Relation
                TmpIdx = 1;
                aSDR.NextResult();

                while (aSDR.Read())
                {
                    SSGraphRelation aSSGraphRelation = new SSGraphRelation();
                    aSSGraphRelation.PersonID1 = Utils.ConvertToInt(aSDR["baPersonID_1"]);
                    aSSGraphRelation.PersonID2 = Utils.ConvertToInt(aSDR["baPersonID_2"]);
                    aSSGraphRelation.RelationName1 = Utils.ConvertToString(aSDR["RelationName1"]);
                    aSSGraphRelation.RelationName2 = Utils.ConvertToString(aSDR["RelationName2"]);
                    aSSGraphRelation.Symmetric = DBUtil.IsEmpty(aSDR["Symmetrisch"]) ? true : (bool)aSDR["Symmetrisch"];

                    //aSSGraphRelation.SymmetricStep = (int)aSDR["SymmetricStep"];
                    //aSSGraphRelation.RelationCode = DBUtil.IsEmpty(aSDR["BaRelationCode"]) ? -1 : (int)aSDR["BaRelationCode"];
                    //if ((aSSGraphRelation.RelationCode == relationCodeParent) && (aSSGraphRelation.PersonID2 == KlientID)) HasParent = true;

                    RelationList.Add(aSSGraphRelation);
                    TmpIdx += 1;
                }

                // Leistungserbinger
                TmpIdx = 1;
                aSDR.NextResult();
                while (aSDR.Read())
                {
                    SSGraphServiceProvider aSSGraphServiceProvider = new SSGraphServiceProvider();
                    aSSGraphServiceProvider.ClientID = Utils.ConvertToInt(aSDR["LeistungsTraegerID"]);
                    aSSGraphServiceProvider.UserID = Utils.ConvertToInt(aSDR["UserID"]);
                    aSSGraphServiceProvider.IconID = Utils.ConvertToInt(aSDR["IconID"]);
                    aSSGraphServiceProvider.FirstName = Utils.ConvertToString(aSDR["FirstName"]);
                    aSSGraphServiceProvider.LastName = Utils.ConvertToString(aSDR["LastName"]);
                    aSSGraphServiceProvider.Function = Utils.ConvertToString(aSDR["Function"]);
                    aSSGraphServiceProvider.Organisation = Utils.ConvertToString(aSDR["OrgUnit"]);
                    aSSGraphServiceProvider.Contact = Utils.ConvertToString(aSDR["Contact"]);
                    aSSGraphServiceProvider.Location.X = TmpIdx;
                    aSSGraphServiceProvider.Location.Y = 1;
                    ServProvList.Add(aSSGraphServiceProvider);
                    TmpIdx += 1;
                }

                // Leistungseinheit
                aSDR.NextResult();

                // Involvierte Personen
                TmpIdx = 1;
                aSDR.NextResult();

                while (aSDR.Read())
                {
                    SSGraphInvolvedPerson aSSGraphInvolvedPerson = new SSGraphInvolvedPerson();
                    aSSGraphInvolvedPerson.ClientID = Utils.ConvertToInt(aSDR["BaPersonID"]);

                    // nur zum Testen:
                    //if (TmpIdx == 1) aSSGraphInvolvedPerson.ClientID = 28808;
                    //if (TmpIdx == 2) aSSGraphInvolvedPerson.ClientID = 2;
                    //if (TmpIdx == 3) aSSGraphInvolvedPerson.ClientID = 25;
                    //if (TmpIdx == 4) aSSGraphInvolvedPerson.ClientID = 2;

                    aSSGraphInvolvedPerson.FirstName = Utils.ConvertToString(aSDR["Vorname"]);
                    aSSGraphInvolvedPerson.LastName = Utils.ConvertToString(aSDR["Name"]);
                    aSSGraphInvolvedPerson.Gender = Utils.ConvertToInt(aSDR["GeschlechtCode"]);
                    aSSGraphInvolvedPerson.Function = Utils.ConvertToString(aSDR["Rolle"]);
                    aSSGraphInvolvedPerson.Contact = Utils.ConvertToString(aSDR["Contact"]);

                    aSSGraphInvolvedPerson.Location.X = 1;
                    aSSGraphInvolvedPerson.Location.Y = TmpIdx;

                    InvPersList.Add(aSSGraphInvolvedPerson);

                    TmpIdx += 1;
                }

                // Involvierte Institutionen
                TmpIdx = 1;
                aSDR.NextResult();
                while (aSDR.Read())
                {
                    SSGraphInvolOrg aSSGraphInvolOrg = new SSGraphInvolOrg();
                    aSSGraphInvolOrg.ClientID = Utils.ConvertToInt(aSDR["baPersonID"]);
                    aSSGraphInvolOrg.InstitutionName = Utils.ConvertToString(aSDR["Name"]);
                    aSSGraphInvolOrg.PLZ = Utils.ConvertToString(aSDR["PLZ"]);
                    aSSGraphInvolOrg.Ort = Utils.ConvertToString(aSDR["Ort"]);
                    aSSGraphInvolOrg.ContactPerson = Utils.ConvertToString(aSDR["AnsprechPerson"]);
                    aSSGraphInvolOrg.Contact = Utils.ConvertToString(aSDR["Contact"]);
                    aSSGraphInvolOrg.EMail = Utils.ConvertToString(aSDR["EMail"]);
                    aSSGraphInvolOrg.Relation = Utils.ConvertToString(aSDR["Relation"]);
                    aSSGraphInvolOrg.Location.X = 1;
                    aSSGraphInvolOrg.Location.Y = TmpIdx;

                    // Nur zum Testen
                    //if (TmpIdx == 1) aSSGraphInvolOrg.ClientID = 28808;
                    //if (TmpIdx == 2) aSSGraphInvolOrg.ClientID = 2;
                    //if (TmpIdx == 3) aSSGraphInvolOrg.ClientID = 25;

                    InvOrgsList.Add(aSSGraphInvolOrg);
                    TmpIdx += 1;
                }

                // Icons Definitionen Klienten
                TmpIdx = 1;
                aSDR.NextResult();
                while (aSDR.Read())
                {
                    SSGraphIDRelation aIcon = new SSGraphIDRelation();
                    aIcon.ID = Utils.ConvertToInt(aSDR["BaPersonID"]);
                    aIcon.RelID = Utils.ConvertToInt(aSDR["IconID"]);
                    ClientIcons.Add(aIcon);
                }

                // Icons Definitionen Leistungserbringer
                TmpIdx = 1;
                aSDR.NextResult();
                while (aSDR.Read())
                {
                    SSGraphIDRelation aIcon = new SSGraphIDRelation();
                    aIcon.ID = Utils.ConvertToInt(aSDR["UserID"]);
                    aIcon.RelID = Utils.ConvertToInt(aSDR["IconID"]);
                    ServProvIcons.Add(aIcon);
                }

                // Relationen Leistungserbringer - Klienten
                TmpIdx = 1;
                aSDR.NextResult();
                while (aSDR.Read())
                {
                    SSGraphIDRelation aID = new SSGraphIDRelation();
                    aID.ID = Utils.ConvertToInt(aSDR["UserID"]);
                    aID.RelID = Utils.ConvertToInt(aSDR["BaPersonID"]);
                    ServProvClients.Add(aID);
                }
            }
            finally
            {
                aSDR.Close();
            }

            #endregion

            #region Initialisierung der Listen

            // Liste der Anzahl Linien für Berechnung der Abstände
            // Personenliste
            for (int j = 0; j < PersonList.Count; j++)
            {
                PersonList[j].HasPosition = false;
                PersonList[j].HasRelation = false;
                // HasRelation anhand der Relationsliste setzen:
                for (int k = 0; k < RelationList.Count; k++)
                    if ((RelationList[k].PersonID1 == PersonList[j].PersonID) ||
                        (RelationList[k].PersonID2 == PersonList[j].PersonID))
                    {
                        PersonList[j].HasRelation = true;
                        break;
                    }
            }

            // Relationenliste
            for (int j = 0; j < RelationList.Count; j++)
            {
                RelationList[j].Stufe = 0;
                RelationList[j].From.X = 0;
                RelationList[j].From.Y = 0;
                RelationList[j].To.X = 0;
                RelationList[j].To.Y = 0;
                RelationList[j].LineType = LineTypes.ltNone;
                RelationList[j].IsProcessed = false;
                RelationList[j].PListID1 = GetIndex(RelationList[j].PersonID1);
                RelationList[j].PListID2 = GetIndex(RelationList[j].PersonID2);
            }

            #endregion

            #region Positionierung des Klienten und Bezugspersonen

            // Positionierung des ersten Eintrags, welches immer der Klient des aktuellen Falles ist:
            PersonList[0].Location.X = 0;
            PersonList[0].Location.Y = 0;
            PersonList[0].HasPosition = true;

            // Zuerst sollen nur Relationen mit dem Klienten berücksichtigt werden:
            // Wir gehen davon aus, dass der Klient einer der Personen ist, welche sehr viele Relationen hat.
            // Also ordnen wir zuerst die Personen mit Relation zum klienten an,
            // möglichts kurze Linein zu erhalten:
            int Idx1;
            int Idx2;
            for (int IdxR = 0; IdxR < RelationList.Count; IdxR++)
                if ((RelationList[IdxR].PListID1 == 0) || (RelationList[IdxR].PListID2 == 0))
                    ProcessRelation(IdxR);

            #region Optimierung nach Häufigkeit der Relationen (wird zur Zeit nicht verwendet)

            // Möglicher Ansatz:
            // Wir positionieren zuerst jene Personen, welche die meisten Relationen, sprich Linien aufweisen.
            // Dann werden die weiteren Personen um die bereits positionierten Personen herum angeordnet,
            // damit sollten möglichst kurze Linien entstehen:
            // Die Gesamtlänge aller Linien soll minimiert werden.

            //// Dann suchen wir nach allen Personen, welche noch keine Relation haben.
            //// Diese werden dann sortiert nach der Anzahl Relationen zu den bereits positionierten Personen.
            //// Die Personen mit den meisten Relationen werden dann als erste weiter positioniert:
            //for (int IdxR = 0; IdxR < RelationList.Count; IdxR++)
            //    if (!RelationList[IdxR].IsProcessed)
            //    {
            //        Idx1 = RelationList[IdxR].PListID1;
            //        Idx2 = RelationList[IdxR].PListID2;
            //        if (PersonList[Idx1].HasPosition) RelationList[IdxR].RelationCounts += 1;
            //        if (PersonList[Idx2].HasPosition) RelationList[IdxR].RelationCounts += 1;
            //    }

            //// Damit es schneller geht, werden jetzt die Schlüssel in einer Liste zusammengefasst:
            //List<System.Drawing.Point> aSortList = new List<System.Drawing.Point>();
            //for (int IdxR = 0; IdxR < RelationList.Count; IdxR++)
            //    if ((!RelationList[IdxR].IsProcessed) && RelationList[IdxR].RelationCounts > 0)
            //    {
            //        System.Drawing.Point aPt = new System.Drawing.Point();
            //        aPt.X = IdxR;
            //        aPt.Y = RelationList[IdxR].RelationCounts;
            //        aSortList.Add(aPt);
            //    }
            //// dann die Liste sortieren
            //System.Drawing.Point aPtTmp = new System.Drawing.Point();

            //if (aSortList.Count > 1)
            //{
            //    bool Sorted = false;
            //    while (!Sorted)
            //        for (int i = 0; i < aSortList.Count - 1; i++)
            //        {
            //            Sorted = true;
            //            if (aSortList[i].Y < aSortList[i + 1].Y)
            //            {
            //                aPtTmp = aSortList[i + 1];
            //                aSortList[i] = aSortList[i + 1];
            //                aSortList[i + 1] = aPtTmp;
            //                Sorted = false;
            //            }
            //        }
            //}
            //// dann diese Relationen abarbeiten:
            //for (int i = 0; i < aSortList.Count; i++) ProcessRelation(aSortList[i].X);

            #endregion

            // dann müssen noch solche die Restlichen positioniert werden:
            for (int IdxR = 0; IdxR < RelationList.Count; IdxR++)
                if (!RelationList[IdxR].IsProcessed)
                    ProcessRelation(IdxR);

            // ev gibt Personen, welche keine Relation haben.
            // Diese werden einfach zuunterst auf einer horizontalen Linie angeordnet:
            bool AllPersonsHavePositions = false;
            int Iteration = 0;
            while (!((AllPersonsHavePositions) || (Iteration > 100)))
            {
                for (int IdxR = 0; IdxR < RelationList.Count; IdxR++)
                    if (!RelationList[IdxR].IsProcessed)
                        ProcessRelation(IdxR);

                // Jetzt nachschauen, ob noch Perosnen keine Positionierung haben.
                // Wenn nicht muss die Iteraion fortgesetzt werden:
                AllPersonsHavePositions = true;
                Iteration += 1;
                for (int i = 0; i < RelationList.Count; i++)
                    if (!RelationList[i].IsProcessed)
                    {
                        AllPersonsHavePositions = false;
                        break;
                    }
            }

            // Meldung ausgeben, wenn nicht alle Personen mit Relationen zugeordnet werden konnten:
            // TODO: Diese Meldung anzeigen oder nicht?
            //if (!AllPersonsHavePositions)
            //    KissMsg.ShowInfo("Es konnten nicht alle Personen positioinert werden.");

            #endregion

            #region Gitter-Koordinatensystem verschieben, falls notwendig

            // Bei Eltern und Grosseltern des Klienten wurde oben angefügt.
            // Dehalb muss jetzte jede Positionierng entsprechend korrigiert werden.
            // Dazu wird zuerst Minimum und Maximum aller Positionen ermittelt:
            int MinX = 0;
            int MinY = 0;
            int MaxX = 0;
            int MaxY = 0;
            for (int i = 0; i < PersonList.Count; i++)
                if (PersonList[i].HasPosition)
                {
                    if (MinX > PersonList[i].Location.X)
                        MinX = PersonList[i].Location.X;
                    if (MinY > PersonList[i].Location.Y)
                        MinY = PersonList[i].Location.Y;
                    if (MaxX < PersonList[i].Location.X)
                        MaxX = PersonList[i].Location.X;
                    if (MaxY < PersonList[i].Location.Y)
                        MaxY = PersonList[i].Location.Y;
                }
            if (MinX < 0)
            {
                // in X Richtung verschieben
                for (int i = 0; i < PersonList.Count; i++)
                    if (PersonList[i].HasPosition)
                        PersonList[i].Location.X -= MinX;
                MaxX -= MinX;
            }
            if (MinY < 0)
            {
                // in Y Richtung verschieben
                for (int i = 0; i < PersonList.Count; i++)
                    if (PersonList[i].HasPosition)
                        PersonList[i].Location.Y -= MinY;
                MaxY -= MinY;
            }

            #endregion

            #region Alle Personen positionieren, welche keine Relationen haben

            // Alle Personen positionieren, welche keine Relationen haben
            int NewPosX = 0;
            for (int i = 0; i < PersonList.Count; i++)
                if (!PersonList[i].HasPosition)
                {
                    PersonList[i].Location.X = NewPosX;
                    PersonList[i].Location.Y = MaxY + 1;
                    PersonList[i].HasPosition = true;
                    NewPosX += 1;
                }
            if (NewPosX > 0)
            {
                if (MaxX < NewPosX)
                    MaxX = NewPosX;
                MaxY += 1;
            }

            #endregion

            #region Alle Linien-Informationen für Abstände zwischen den Boxen erstellen

            // Diese Liste enthält alle Informationen über die Zwischenräume zwischen den Boxen.
            // Z.B. Anzahl Linien, Beschriftungen, aktuelle Grösse in Pixel usw.
            for (int q = 0; q <= MaxX + 1; q++)
            {
                BoxSpaces aSp = new BoxSpaces();
                aSp.StartTopLeft = cstBoxBorderX + cstClientBoxSizeX + ((q - 1) * (cstClientBoxSizeX + cstBoxBorderX + cstBoxBorderX));
                aSp.LineCount = 0;
                aSp.PixelSize = cstBoxBorderX;
                if ((q > 0) && (q < MaxX))
                    aSp.PixelSize += cstBoxBorderX;
                aBoxSpacesListX.Add(aSp);
            }
            for (int q = 0; q <= MaxY + 1; q++)
            {
                BoxSpaces aSp = new BoxSpaces();
                aSp.StartTopLeft = cstBoxBorderY + cstTitelLabelHeight + cstClientBoxSizeY + ((q - 1) * (cstClientBoxSizeY + cstBoxBorderY + cstBoxBorderY));
                aSp.LineCount = 0;
                aSp.PixelSize = cstBoxBorderY;
                if (q == 0)
                    aSp.PixelSize += cstTitelLabelHeight;
                if ((q > 0) && (q < MaxX))
                    aSp.PixelSize += cstBoxBorderY;
                aBoxSpacesListY.Add(aSp);
            }

            #endregion

            #region Alle Personen nun positionieren (Pixels setzen)

            // Hier werden die Pixelkoordinaten aller Klientenboxen erstellt.
            for (int z = 0; z < PersonList.Count; z++)
            {
                PersonList[z].Pixels.X = cstBoxBorderX +
                    (PersonList[z].Location.X * (cstBoxBorderX + cstBoxBorderX + cstClientBoxSizeX));
                PersonList[z].Pixels.Y = cstBoxBorderY + cstTitelLabelHeight +
                    (PersonList[z].Location.Y * (cstBoxBorderY + cstBoxBorderY + cstClientBoxSizeY));
            }

            #endregion

            #region Linientyp erstellen

            for (int z = 0; z < RelationList.Count; z++)
            {
                Idx1 = RelationList[z].PListID1;
                Idx2 = RelationList[z].PListID2;
                RelationList[z].From = PersonList[Idx1].Location;
                RelationList[z].To = PersonList[Idx2].Location;

                if ((PersonList[Idx1].Location.X == PersonList[Idx2].Location.X) &&
                    (Math.Abs(PersonList[Idx1].Location.Y - PersonList[Idx2].Location.Y) == 1))
                {
                    // Boxen liegen genau überneinander:
                    RelationList[z].LineType = LineTypes.ltVer;
                }
                else if ((PersonList[Idx1].Location.X == PersonList[Idx2].Location.X) &&
                         (Math.Abs(PersonList[Idx1].Location.Y - PersonList[Idx2].Location.Y) > 1))
                {
                    // Boxen liegen übereinander, aber über mehrere Reihen:
                    RelationList[z].LineType = LineTypes.ltVerMany;
                }
                else if ((PersonList[Idx1].Location.Y == PersonList[Idx2].Location.Y) &&
                         (Math.Abs(PersonList[Idx1].Location.X - PersonList[Idx2].Location.X) == 1))
                {
                    // Boxen liegen genau nebeneinander:
                    RelationList[z].LineType = LineTypes.ltHor;
                }
                else if ((PersonList[Idx1].Location.Y == PersonList[Idx2].Location.Y) &&
                         (Math.Abs(PersonList[Idx1].Location.X - PersonList[Idx2].Location.X) > 1))
                {
                    // Boxen liegen nebeneinander, aber über mehrere Reihen:
                    RelationList[z].LineType = LineTypes.ltHorMany;
                }
                else if ((Math.Abs(PersonList[Idx1].Location.X - PersonList[Idx2].Location.X) >= 1) &&
                         (Math.Abs(PersonList[Idx1].Location.Y - PersonList[Idx2].Location.Y) == 1))
                {
                    // Boxen liegen diagonal genau nebeneinander:
                    // über mehrere horizontale Punkte, aber nur eine Differenz in der Höhe
                    RelationList[z].LineType = LineTypes.ltSimple;
                }
                else
                //if ((Math.Abs(PersonList[Idx1].Location.X - PersonList[Idx2].Location.X) >= 1) &&
                //    (Math.Abs(PersonList[Idx1].Location.Y - PersonList[Idx2].Location.Y) > 1))
                {
                    // Boxen liegen diagonal nebeneinander, aber über mehrere Reihen:
                    RelationList[z].LineType = LineTypes.ltComplexMany;
                }
            }

            #endregion

            // Ab hier werden die einzelnen Linien für Klienten berechnet

            #region Vertikale Linien über eine Achse

            int WishedX, NewPosY;
            DockPointTypes aDp;
            int DokPos1;
            int DokPos2;
            int DokPixX1;
            int DokPixX2;

            // zuerst nur die vertikalen verbindungen, welche von Box zu Box unten gehen oder umgekehrt
            int NewLIdx, aLineY, aLineX, DokPosX, aTop;
            bool FromLeftToRight, FromTopToBottom;
            for (int z = 0; z < RelationList.Count; z++)
                if (RelationList[z].LineType.Equals(LineTypes.ltVer))
                {
                    Idx1 = RelationList[z].PListID1;
                    Idx2 = RelationList[z].PListID2;

                    // Jetzt noch kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                    FromTopToBottom = (RelationList[z].From.Y < RelationList[z].To.Y);
                    //if (FromTopToBottom) ALineY += 1;
                    GetNewVerticalLinePositionY2(z, RelationList[z].From.Y + 1, false, true, true, true, 0, 0);

                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, true, LineDirectionType.ldVer, -1, -1);
                    ClientLines[NewLIdx].From.X = PersonList[Idx1].Pixels.X + cstHalfSizeX;
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    if (FromTopToBottom)
                    {
                        // Person 1 ist genau oberhalb von Person 2
                        DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx,
                            DockPointTypes.dpBottom,
                            RelationList[z].RelationName1, 0,
                            RelationList[z].LineType, 0, DockPointTextTypes.dptClient, 0);
                        ClientLines[NewLIdx].From.X = ClientLines[NewLIdx].From.X + (DokPosX * cstLabelWidth);
                        DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx,
                            DockPointTypes.dpTop,
                            RelationList[z].RelationName2, 0,
                            RelationList[z].LineType, 0, DockPointTextTypes.dptClient, 0);
                        ClientLines[NewLIdx].To.X += (DokPosX * cstLabelWidth);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y + cstClientBoxSizeY;
                        ClientLines[NewLIdx].To.Y = PersonList[Idx2].Pixels.Y;
                        aLineY = PersonList[Idx1].Location.Y + 1;
                        aTop = ClientLines[NewLIdx].From.Y;
                    }
                    else
                    {
                        // Person 1 ist genau unterhalb von Person 2
                        DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx,
                            DockPointTypes.dpTop,
                            RelationList[z].RelationName1, 0,
                            RelationList[z].LineType, 0, DockPointTextTypes.dptClient, 0);
                        ClientLines[NewLIdx].From.X = ClientLines[NewLIdx].From.X + (DokPosX * cstLabelWidth);
                        DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx,
                            DockPointTypes.dpBottom,
                            RelationList[z].RelationName2, 0,
                            RelationList[z].LineType, 0, DockPointTextTypes.dptClient, 0);
                        ClientLines[NewLIdx].To.X += (DokPosX * cstLabelWidth);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y;
                        ClientLines[NewLIdx].To.Y = PersonList[Idx2].Pixels.Y + cstClientBoxSizeY;
                        aLineY = PersonList[Idx1].Location.Y;
                        aTop = ClientLines[NewLIdx].To.Y;
                    }
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;
                    RelationList[z].LinesProcessed = true;
                    RelationList[z].Stufe = 0;
                }

            #endregion

            #region Horizontale Linien über mehrere Achsen

            // zuerst nur die vertikalen verbindungen, welche von Box zu Box nach unten oder oben
            for (int z = 0; z < RelationList.Count; z++)
                if (RelationList[z].LineType.Equals(LineTypes.ltHorMany))
                {
                    Idx1 = RelationList[z].PListID1;
                    Idx2 = RelationList[z].PListID2;
                    FromLeftToRight = (PersonList[Idx1].Location.X < PersonList[Idx2].Location.X);
                    if (RelationList[z].From.Y == 0)
                    {
                        // zuerst nach oben, wenn es die oberste Linie ist
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        // neu: 30.09.2007
                        aDp = DockPointTypes.dpTop;
                        DokPos1 = CalculateDockingPosition(Idx1, aDp, !FromLeftToRight, 0);
                        DokPos2 = CalculateDockingPosition(Idx2, aDp, FromLeftToRight, 0);
                        DokPixX1 = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPos1 * cstLabelWidth);
                        DokPixX2 = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPos2 * cstLabelWidth);

                        NewPosY = GetDistanceTopLineY(z, Idx1, true, LineTypes.ltHorMany, DokPixX1, DokPixX2);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, 0);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                    }
                    else
                    {
                        // sonst nach unten
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        // neu: 30.09.2007
                        aDp = DockPointTypes.dpBottom;
                        //if (aBoxSpacesListY[RelationList[z].From.Y + 1].LineCount > aBoxSpacesListY[RelationList[z].From.Y].LineCount)
                        //    aDp = DockPointTypes.dpTop;

                        DokPos1 = CalculateDockingPosition(Idx1, aDp, !FromLeftToRight, 0);
                        DokPos2 = CalculateDockingPosition(Idx2, aDp, FromLeftToRight, 0);
                        DokPixX1 = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPos1 * cstLabelWidth);
                        DokPixX2 = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPos2 * cstLabelWidth);

                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y + 1, true, true, true, false, DokPixX1, DokPixX2);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y + 1);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y + cstClientBoxSizeY;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                    }
                    WishedX = -2;
                    if (FromLeftToRight)
                        WishedX = 2;
                    DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx, aDp,
                        RelationList[z].RelationName1, WishedX,
                        RelationList[z].LineType, WishedX, DockPointTextTypes.dptClient, NewPosY);
                    ClientLines[NewLIdx].From.X = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    // Jetzt horizontale Linie zeichnen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    ClientLines[NewLIdx].To.X = PersonList[Idx2].Pixels.X + cstHalfSizeX;
                    DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx, aDp,
                        RelationList[z].RelationName2, -WishedX,
                        RelationList[z].LineType, -WishedX, DockPointTextTypes.dptClient, NewPosY);
                    ClientLines[NewLIdx].To.X += (DokPosX * cstLabelWidth);
                    // nicht notwendig: LineList[NewLIdx].To.Y = LineList[NewLIdx - 1].To.Y;

                    // Jetzt wieder nach oben oder unten:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, true, LineDirectionType.ldVer, -1, -1);
                    // nicht notwendig: LineList[NewLIdx].To.X = LineList[NewLIdx - 1].To.X;
                    ClientLines[NewLIdx].To.Y = ClientLines[NewLIdx - 2].From.Y;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    RelationList[z].LinesProcessed = true;
                    RelationList[z].Stufe = 1;
                }

            #endregion

            #region Horizontale Linien über eine Achse

            // zuerst nur die vertikalen verbindungen, welche von Box zu Box nach unten oder oben
            for (int z = 0; z < RelationList.Count; z++)
                if (RelationList[z].LineType.Equals(LineTypes.ltHor))
                {
                    Idx1 = RelationList[z].PListID1;
                    Idx2 = RelationList[z].PListID2;
                    FromLeftToRight = (PersonList[Idx1].Location.X < PersonList[Idx2].Location.X);
                    if (RelationList[z].From.Y == 0)
                    {
                        // zuerst nach oben, wenn es die oberste Linie ist
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        aDp = DockPointTypes.dpTop;
                        DokPos1 = CalculateDockingPosition(Idx1, aDp, !FromLeftToRight, 0);
                        DokPos2 = CalculateDockingPosition(Idx2, aDp, FromLeftToRight, 0);
                        DokPixX1 = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPos1 * cstLabelWidth);
                        DokPixX2 = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPos2 * cstLabelWidth);

                        NewPosY = GetDistanceTopLineY(z, Idx1, false, LineTypes.ltHor, DokPixX1, DokPixX2);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, 0);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                    }
                    else
                    {
                        // sonst nach unten
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        aDp = DockPointTypes.dpBottom;
                        DokPos1 = CalculateDockingPosition(Idx1, aDp, !FromLeftToRight, 0);
                        DokPos2 = CalculateDockingPosition(Idx2, aDp, FromLeftToRight, 0);
                        DokPixX1 = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPos1 * cstLabelWidth);
                        DokPixX2 = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPos2 * cstLabelWidth);

                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y + 1, true, false, true, false, DokPixX1, DokPixX2);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y + 1);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y + cstClientBoxSizeY;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                    }
                    WishedX = -3;
                    if (RelationList[z].From.X < RelationList[z].To.X)
                        WishedX = 3;
                    DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx, aDp,
                        RelationList[z].RelationName1, WishedX,
                        RelationList[z].LineType, WishedX, DockPointTextTypes.dptClient, 0);
                    ClientLines[NewLIdx].From.X = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    // Jetzt horizontale Linie zeichnen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    ClientLines[NewLIdx].To.X = PersonList[Idx2].Pixels.X + cstHalfSizeX;
                    //WishedX = 3;
                    //if (RelationList[z].From.X < RelationList[z].To.X) WishedX = -3;
                    DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx, aDp,
                        RelationList[z].RelationName2, -WishedX,
                        RelationList[z].LineType, -WishedX, DockPointTextTypes.dptClient, NewPosY);
                    ClientLines[NewLIdx].To.X += (DokPosX * cstLabelWidth);
                    // nicht notwendig: LineList[NewLIdx].To.Y = LineList[NewLIdx].From.Y;

                    // Jetzt wieder nach oben oder unten:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, true, LineDirectionType.ldVer, -1, -1);
                    // nicht notwendig: LineList[NewLIdx].To.X = LineList[NewLIdx].From.X;
                    ClientLines[NewLIdx].To.Y = ClientLines[NewLIdx - 2].From.Y;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;
                    RelationList[z].LinesProcessed = true;
                    RelationList[z].Stufe = 0;
                }

            #endregion

            #region Vertikale Linien über mehrere Achsen

            // zuerst nur die vertikalen verbindungen, welche von Box zu Box nach unten oder oben
            //int NewLIdx, aLineY, aLineX, DokPosX, aTop, minHeight;
            for (int z = 0; z < RelationList.Count; z++)
                if (RelationList[z].LineType.Equals(LineTypes.ltVerMany))
                {
                    Idx1 = RelationList[z].PListID1;
                    Idx2 = RelationList[z].PListID2;
                    FromTopToBottom = (RelationList[z].From.Y < RelationList[z].To.Y);
                    if (FromTopToBottom)
                    {
                        // nach unten
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y + 1, true, true, false, true, 0, 0);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y + 1);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y + cstClientBoxSizeY;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                        aDp = DockPointTypes.dpBottom;
                    }
                    else
                    {
                        // sonst nach oben
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y, true, true, true, false, 0, 0);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                        aDp = DockPointTypes.dpTop;
                    }
                    WishedX = -1;
                    if (RelationList[z].From.X > 0)
                        WishedX = 1;
                    DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx, aDp,
                        RelationList[z].RelationName1, WishedX,
                        RelationList[z].LineType, WishedX, DockPointTextTypes.dptClient, 0);
                    ClientLines[NewLIdx].From.X = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    // Jetzt horizontale Linie zeichnen:
                    aDp = DockPointTypes.dpNone;
                    if (RelationList[z].From.X == 0)
                    {
                        // wenn es die erste Linie ist, dann soll links herum gegangen werden:
                        NewPosX = GetDistanceLeftLineX(false, LineTypes.ltVerMany);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    }
                    else
                    {
                        // sonst rechts herum
                        NewPosX = GetNewHorizontalLinePositionX(RelationList[z].From.X + 1, true, true, false, false);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    }
                    ClientLines[NewLIdx].To.X = NewPosX;

                    // Jetzt wieder nach oben oder unten:
                    if (!FromTopToBottom)
                    {
                        // nach oben,
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].To.Y + 1, true, true, false, true, 0, 0);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldVer, -1, -1);
                        ClientLines[NewLIdx].GridLineY = RelationList[z].To.Y + 1;
                    }
                    else
                    {
                        // sonst nach unten
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].To.Y, true, true, true, false, 0, 0);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldVer, -1, -1);
                        //aDp = SSGraphDockPointTypes.dpBottom;
                        ClientLines[NewLIdx].GridLineY = RelationList[z].To.Y;
                    }
                    ClientLines[NewLIdx].To.Y = NewPosY;
                    // nicht notwendig: LineList[NewLIdx].To.X = LineList[NewLIdx].From.X;

                    // jetzt wieder nach links oder rechst
                    if (aDp.Equals(DockPointTypes.dpTop))
                        aDp = DockPointTypes.dpBottom;
                    else
                        aDp = DockPointTypes.dpTop;
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    // nicht notwendig: LineList[NewLIdx].To.Y = LineList[NewLIdx].From.Y;
                    DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx, aDp,
                        RelationList[z].RelationName2, WishedX,
                        RelationList[z].LineType, WishedX, DockPointTextTypes.dptClient, 0);
                    ClientLines[NewLIdx].To.X = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);

                    // Jetzt wieder nach oben oder unten, und abschliessen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, true, LineDirectionType.ldVer, -1, -1);
                    // nicht notwendig: LineList[NewLIdx].To.X = LineList[NewLIdx].From.X;
                    ClientLines[NewLIdx].To.Y = PersonList[Idx2].Pixels.Y;
                    if (!FromTopToBottom)
                        ClientLines[NewLIdx].To.Y += cstClientBoxSizeY;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    RelationList[z].LinesProcessed = true;
                    RelationList[z].Stufe = 2;
                }

            #endregion

            #region Simple, über mehrere horizontale Punkte, aber nur eine Differenz in der Höhe

            // zuerst nur die vertikalen Verbindungen, welche von Box zu Box nach unten oder oben
            for (int z = 0; z < RelationList.Count; z++)
                //if ((RelationList[z].LineType.Equals(LineTypes.ltSimple)) &&
                //    (Math.Abs(RelationList[z].From.Y - RelationList[z].To.Y) == 1))
                if (RelationList[z].LineType.Equals(LineTypes.ltSimple))
                {
                    Idx1 = RelationList[z].PListID1;
                    Idx2 = RelationList[z].PListID2;
                    FromTopToBottom = (RelationList[z].From.Y < RelationList[z].To.Y);
                    FromLeftToRight = (RelationList[z].From.X < RelationList[z].To.X);
                    if (FromTopToBottom)
                    {
                        // nach unten
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        aDp = DockPointTypes.dpBottom;
                        DokPos1 = CalculateDockingPosition(Idx1, aDp, !FromLeftToRight, 0);
                        DokPos2 = CalculateDockingPosition(Idx2, DockPointTypes.dpTop, FromLeftToRight, 0);
                        DokPixX1 = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPos1 * cstLabelWidth);
                        DokPixX2 = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPos2 * cstLabelWidth);

                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y + 1, true, true, true, true, DokPixX1, DokPixX2);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y + 1);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y + cstClientBoxSizeY;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                    }
                    else
                    {
                        // sonst nach oben
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        aDp = DockPointTypes.dpTop;
                        DokPos1 = CalculateDockingPosition(Idx1, aDp, !FromLeftToRight, 0);
                        DokPos2 = CalculateDockingPosition(Idx2, DockPointTypes.dpBottom, FromLeftToRight, 0);
                        DokPixX1 = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPos1 * cstLabelWidth);
                        DokPixX2 = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPos2 * cstLabelWidth);

                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y, true, false, true, false, DokPixX1, DokPixX2);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                    }
                    WishedX = -1;
                    if (FromLeftToRight)
                        WishedX = 1;
                    DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx, aDp,
                        RelationList[z].RelationName1, WishedX,
                        RelationList[z].LineType, 1, DockPointTextTypes.dptClient, 0);
                    ClientLines[NewLIdx].From.X = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    // Jetzt horizontale Linie zeichnen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    ClientLines[NewLIdx].To.Y = ClientLines[NewLIdx].From.Y;
                    WishedX = -1;
                    if (!FromLeftToRight)
                        WishedX = 1;
                    if (aDp.Equals(DockPointTypes.dpTop))
                        aDp = DockPointTypes.dpBottom;
                    else
                        aDp = DockPointTypes.dpTop;
                    DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx, aDp,
                        RelationList[z].RelationName2, WishedX,
                        RelationList[z].LineType, (3 * WishedX), DockPointTextTypes.dptClient, NewPosY);
                    ClientLines[NewLIdx].To.X = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);

                    // Jetzt wieder nach oben oder unten, und abschliessen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, true, LineDirectionType.ldVer, -1, -1);
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    ClientLines[NewLIdx].To.Y = PersonList[Idx2].Pixels.Y;
                    if (!FromTopToBottom)
                        ClientLines[NewLIdx].To.Y += cstClientBoxSizeY;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    RelationList[z].LinesProcessed = true;
                    RelationList[z].Stufe = 4;
                }

            #endregion

            #region Komplex

            for (int z = 0; z < RelationList.Count; z++)
                if (RelationList[z].LineType.Equals(LineTypes.ltComplexMany))
                {
                    Idx1 = RelationList[z].PListID1;
                    Idx2 = RelationList[z].PListID2;
                    FromTopToBottom = (RelationList[z].From.Y < RelationList[z].To.Y);
                    FromLeftToRight = (RelationList[z].From.X < RelationList[z].To.X);
                    if (FromTopToBottom)
                    {
                        // sonst nach unten
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y + 1, true, true, true, false, 0, 0);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y + 1);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y + cstClientBoxSizeY;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                        aDp = DockPointTypes.dpBottom;
                    }
                    else
                    {
                        // sonst nach oben
                        // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
                        NewPosY = GetNewVerticalLinePositionY2(z, RelationList[z].From.Y, true, false, false, true, 0, 0);
                        NewLIdx = GetNewLineItem(z, Idx1, Idx2, true, false, LineDirectionType.ldVer, -1, RelationList[z].From.Y);
                        ClientLines[NewLIdx].From.Y = PersonList[Idx1].Pixels.Y;
                        ClientLines[NewLIdx].To.Y = NewPosY;
                        aDp = DockPointTypes.dpTop;
                    }
                    WishedX = -1;
                    if (FromLeftToRight)
                        WishedX = 1;
                    DokPosX = GetDockingPointPosition(z, Idx1, NewLIdx, aDp,
                        RelationList[z].RelationName1, WishedX,
                        RelationList[z].LineType, 1, DockPointTextTypes.dptClient, 0);
                    ClientLines[NewLIdx].From.X = PersonList[Idx1].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);
                    ClientLines[NewLIdx].To.X = ClientLines[NewLIdx].From.X;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    // Jetzt horizontale Linie zeichnen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    aLineX = RelationList[z].To.X;
                    if (!FromLeftToRight)
                        aLineX += 1;
                    NewPosX = GetNewHorizontalLinePositionX(aLineX, true, true, false, false);
                    ClientLines[NewLIdx].To.X = NewPosX;

                    // Jetzt vertikale Linie zeichnen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldVer, -1, -1);
                    aLineY = RelationList[z].To.Y;
                    if (!FromTopToBottom)
                        aLineY += 1;
                    ClientLines[NewLIdx].GridLineY = aLineY;
                    NewPosY = GetNewVerticalLinePositionY2(z, aLineY, true, true, false, false, 0, 0);
                    ClientLines[NewLIdx].To.Y = NewPosY;

                    // Jetzt horizontale Linie zeichnen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, false, LineDirectionType.ldHor, -1, -1);
                    WishedX = -1;
                    if (!FromLeftToRight)
                        WishedX = 1;
                    if (aDp.Equals(DockPointTypes.dpTop))
                        aDp = DockPointTypes.dpBottom;
                    else
                        aDp = DockPointTypes.dpTop;
                    DokPosX = GetDockingPointPosition(z, Idx2, NewLIdx, aDp,
                        RelationList[z].RelationName2, WishedX,
                        RelationList[z].LineType, -1, DockPointTextTypes.dptClient, NewPosY);
                    ClientLines[NewLIdx].To.X = PersonList[Idx2].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);

                    // Jetzt wieder nach oben oder unten, und abschliessen:
                    NewLIdx = GetNewLineItem(z, Idx1, Idx2, false, true, LineDirectionType.ldVer, -1, -1);
                    ClientLines[NewLIdx].To.Y = PersonList[Idx2].Pixels.Y;
                    if (!FromTopToBottom)
                        ClientLines[NewLIdx].To.Y += cstClientBoxSizeY;
                    ClientLines[NewLIdx].BoxPositionX = DokPosX;

                    RelationList[z].LinesProcessed = true;
                    RelationList[z].Stufe = 5;
                }

            #endregion

            // Involvierte Institutionen

            #region Involvierte Institutionen in Grafik einfügen

            PI.CtlItemInvolvedOrganisation aInvOrg;

            int NewPosInvOrgY = cstTitelLabelHeight + cstBoxBorderY;
            NewPosInvOrgY = aBoxSpacesListY[0].PixelSize;

            for (int Idx = 0; Idx < InvOrgsList.Count; Idx++)
            {
                aInvOrg = new PI.CtlItemInvolvedOrganisation(
                    InvOrgsList[Idx].InstitutionName,
                    InvOrgsList[Idx].PLZ + " " + InvOrgsList[Idx].Ort,
                    InvOrgsList[Idx].ContactPerson,
                    InvOrgsList[Idx].Contact,
                    InvOrgsList[Idx].EMail,
                    InvOrgsList[Idx].Relation,
                    InvOrgsList[Idx].ClientID);

                aCtlSozialsystem.panInvolvedOrganisations.Controls.Add(aInvOrg);
                aInvOrg.Left = cstBordInvOrgs;
                aInvOrg.Top = NewPosInvOrgY;
                NewPosInvOrgY = NewPosInvOrgY + cstDistanceInvOrgsY + aInvOrg.Height;
                // Für Linien Berechnung:
                InvOrgsList[Idx].Top = aInvOrg.Top;
                InvOrgsList[Idx].Left = aInvOrg.Left;
                InvOrgsList[Idx].Height = aInvOrg.Height;
                InvOrgsList[Idx].Width = aInvOrg.Width;
            }

            #endregion

            #region Linien für Involvierte Institutionen erstellen

            Int32 DiffX = 0;
            Int32 DiffY = 0;
            Int32 InstIndex = 0;
            Boolean DrawLinesInvOrgs = false;
            Int32 DokPosY;

            if (DrawLinesInvOrgs)
            {
                for (int Idx = 0; Idx < InvOrgsList.Count; Idx++)
                    if (InvOrgsList[Idx].ClientID > 0)
                    {
                        int PersIdx = GetIndex(InvOrgsList[Idx].ClientID);
                        if (PersIdx >= 0)
                        {
                            int ToX2 = PersonList[PersIdx].Pixels.X;
                            int ToY = PersonList[PersIdx].Pixels.Y + cstHalfSizeY;
                            // Weg zur  Person suchen
                            // Zuerst Platz für eine neue Linie schaffen
                            NewPosX = GetNewHorizontalLinePositionX(MaxX + 1, true, false, false, false);

                            // Neue Linie erstellen
                            // Für alle gehen wir zuerst nach links
                            InstIndex += 1;
                            NewLIdx = GetNewLineInvOrganisations(InstIndex, PersIdx, true, false, LineDirectionType.ldHor);
                            InvOrgLines[NewLIdx].To.X = NewPosX;
                            InvOrgLines[NewLIdx].From.X = NewPosX + cstBoxBorderX + InvOrgsList[Idx].Left;
                            InvOrgLines[NewLIdx].From.Y = InvOrgsList[Idx].Top + (InvOrgsList[Idx].Height / 2) - DiffY;
                            InvOrgLines[NewLIdx].To.Y = InvOrgLines[NewLIdx].From.Y;

                            aDp = DockPointTypes.dpRight;
                            if (PersonList[PersIdx].Location.X < MaxX)
                            {
                                // schauen, ob die Linie horizontal direkt zur Box des Klienten geführt werden kann,
                                // oder ob es dawischen Boxen oder Labels hat
                                if (HasClientsOnHorLine(ToY, 0, ToX2))
                                {
                                    // es hat Boxen auf der Linie, also muss ein anderer Weg gesucht werden
                                    // je nachdem, wo der Weg kleiner ist
                                    aDp = DockPointTypes.dpBottom;
                                    if (InvOrgLines[NewLIdx].To.Y < ToY)
                                        aDp = DockPointTypes.dpTop;
                                }
                            }

                            // jetzt vertikale Linie zeichnen
                            if (aDp.Equals(DockPointTypes.dpRight))
                            {
                                // Es kann links an der Box angedockt werden
                                NewLIdx = GetNewLineInvOrganisations(InstIndex, PersIdx, false, false, LineDirectionType.ldVer);
                                InvOrgLines[NewLIdx].To.Y = PersonList[PersIdx].Pixels.Y + cstHalfSizeY;

                                // jetzt noch die horizontale Linie erstellen und abschliessen
                                NewLIdx = GetNewLineInvOrganisations(InstIndex, PersIdx, false, true, LineDirectionType.ldHor);
                                InvOrgLines[NewLIdx].To.X = PersonList[PersIdx].Pixels.X + cstClientBoxSizeX;
                            }
                            else
                            {
                                // Es kann nicht links an der Box angedockt werden, also unten oder oben
                                if (aDp.Equals(DockPointTypes.dpTop))
                                {
                                    // Es soll oben an der Box angedockt werden
                                    if (PersonList[PersIdx].Location.Y == 0)
                                    {
                                        // Wenn in der obersten Reihe eine Linie eingefügt werden soll
                                        NewPosY = GetDistanceTopLineY(-1, PersIdx, true, LineTypes.ltHorMany, 0, 0);
                                    }
                                    else
                                    {
                                        // Wenn in den anderen Reihen eingefügt werden soll
                                        NewPosY = GetNewVerticalLinePositionY2(-1, PersonList[PersIdx].Location.Y, true, false, false, false, 0, 0);
                                    }
                                    DokPosY = PersonList[PersIdx].Pixels.Y;
                                }
                                else
                                {
                                    // Es soll unten an der Box angedockt werden
                                    NewPosY = GetNewVerticalLinePositionY2(-1, PersonList[PersIdx].Location.Y + 1, true, true, false, false, 0, 0);
                                    DokPosY = PersonList[PersIdx].Pixels.Y + cstClientBoxSizeY;
                                }
                                NewLIdx = GetNewLineInvOrganisations(InstIndex, PersIdx, false, false, LineDirectionType.ldVer);
                                InvOrgLines[NewLIdx].To.Y = NewPosY;

                                // jetzt horizontal nach rechts gehen, damit an die Box von oben oder unten angedockt werden kann
                                NewLIdx = GetNewLineInvOrganisations(InstIndex, PersIdx, false, false, LineDirectionType.ldHor);
                                WishedX = 4;
                                DokPosX = GetDockingPointPosition(Idx, PersIdx, NewLIdx, aDp, "", WishedX, LineTypes.ltNone, WishedX, DockPointTextTypes.dptInvOrg, 0);
                                InvOrgLines[NewLIdx].To.X = PersonList[PersIdx].Pixels.X + cstHalfSizeX + (DokPosX * cstLabelWidth);

                                // dann vertikal andocken
                                NewLIdx = GetNewLineInvOrganisations(InstIndex, PersIdx, false, true, LineDirectionType.ldVer);
                                InvOrgLines[NewLIdx].To.Y = PersonList[PersIdx].Pixels.Y;
                                if (aDp.Equals(DockPointTypes.dpBottom))
                                    InvOrgLines[NewLIdx].To.Y += cstClientBoxSizeY;
                            }
                        }
                    }
            }

            #endregion

            // Schnittpunkte berechnen

            #region Die Schnittpunkte Klientensystem erstellen

            System.Drawing.Point NewCrossPoint;

            // Schnittpunkte berechnen nur innerhalb Klientensystem
            if (ClientLines.Count > 1)
            {
                for (int i = 0; i < ClientLines.Count - 1; i++)
                {
                    for (int j = i + 1; j < ClientLines.Count; j++)
                    {
                        if (HasIntersection(ClientLines[i], ClientLines[j], true, out NewCrossPoint))
                        {
                            ClientLines[j].CrossPoints.Add(NewCrossPoint);
                        }
                    }
                }
            }

            // Zum Kontrollieren der Angabe LineDir:
            //for (int i = 0; i < LineList.Count; i++)
            //{
            //    if (LineList[i].LineDir.Equals(LineDirectionType.ldHor) &&
            //        (LineList[i].From.Y != LineList[i].To.Y)
            //       )
            //    {
            //        KissMsg.ShowInfo("Falscher Linientyp.");
            //    }
            //    if (LineList[i].LineDir.Equals(LineDirectionType.ldVer) &&
            //        (LineList[i].From.X != LineList[i].To.X)
            //       )
            //    {
            //        KissMsg.ShowInfo("Falscher Linientyp.");
            //    }
            //}

            // Zum Kontrollieren der Schnittpunkte:
            //for (int i = 0; i < LineList.Count; i++)
            //{
            //    for (int j = 0; j < LineList[i].CrossPoints.Count; j++)
            //    {
            //        if (LineList[i].LineDir.Equals(LineDirectionType.ldHor))
            //        {
            //            if ((LineList[i].CrossPoints[j].Y != LineList[i].From.Y) ||
            //                (LineList[i].CrossPoints[j].Y != LineList[i].To.Y))
            //            {
            //                KissMsg.ShowInfo("Falscher Schnittpunkt Horizontal.");
            //            }
            //        }
            //        else if (LineList[i].LineDir.Equals(LineDirectionType.ldVer))
            //        {
            //        }
            //        if ((LineList[i].CrossPoints[j].X != LineList[i].From.X) ||
            //            (LineList[i].CrossPoints[j].X != LineList[i].To.X))
            //        {
            //            KissMsg.ShowInfo("Falscher Schnittpunkt Vertikal.");
            //        }
            //    }
            //}

            #endregion

            #region Involvierte Personen: Schnittpunkte bestimmen

            // Die Schnittpunkte erstellen
            for (int i = 0; i < InvPersLines.Count; i++)
            {
                for (int j = 0; j < ClientLines.Count; j++)
                {
                    if (HasIntersection(InvPersLines[i], ClientLines[j], false, out NewCrossPoint))
                    {
                        InvPersLines[i].CrossPoints.Add(NewCrossPoint);
                    }
                }
            }

            if (InvPersLines.Count > 1)
            {
                for (int i = 0; i < InvPersLines.Count - 1; i++)
                {
                    for (int j = i + 1; j < InvPersLines.Count; j++)
                    {
                        if (HasIntersection(InvPersLines[i], InvPersLines[j], true, out NewCrossPoint))
                        {
                            InvPersLines[j].CrossPoints.Add(NewCrossPoint);
                        }
                    }
                }
            }

            #endregion

            #region Involvierte Institutionen: Schnittpunkte bestimmen

            // Die Schnittpunkte erstellen
            for (int i = 0; i < InvOrgLines.Count; i++)
            {
                for (int j = 0; j < ClientLines.Count; j++)
                {
                    if (HasIntersection(InvOrgLines[i], ClientLines[j], false, out NewCrossPoint))
                    {
                        InvOrgLines[i].CrossPoints.Add(NewCrossPoint);
                    }
                }
            }

            for (int i = 0; i < InvOrgLines.Count; i++)
            {
                for (int j = 0; j < InvPersLines.Count; j++)
                {
                    if (HasIntersection(InvOrgLines[i], InvPersLines[j], false, out NewCrossPoint))
                    {
                        InvOrgLines[i].CrossPoints.Add(NewCrossPoint);
                    }
                }
            }

            for (int i = 0; i < InvOrgLines.Count - 1; i++)
            {
                for (int j = i; j < InvOrgLines.Count; j++)
                {
                    if (HasIntersection(InvOrgLines[i], InvOrgLines[j], true, out NewCrossPoint))
                    {
                        InvOrgLines[j].CrossPoints.Add(NewCrossPoint);
                    }
                }
            }

            #endregion

            #region Umrechnung Koordinatensystem

            // Inv. Personen
            //DiffX = 0;
            //DiffY = 0;
            for (int Idx = 0; Idx < InvPersLines.Count; Idx++)
            {
                if (!InvPersLines[Idx].IsStartPoint)
                    InvPersLines[Idx].From.X += DiffX;
                //PersLineList[Idx].From.Y += DiffY;
                InvPersLines[Idx].To.X += DiffX;
                //PersLineList[Idx].To.Y += DiffY;
                for (int j = 0; j < InvPersLines[Idx].CrossPoints.Count; j++)
                {
                    /*PersLineList[Idx].CrossPoints[j] = new System.Drawing.Point(
                        PersLineList[Idx].CrossPoints[j].X + DiffX,
                        PersLineList[Idx].CrossPoints[j].Y + DiffY);
                     * */
                    InvPersLines[Idx].CrossPoints[j] = new System.Drawing.Point(
                        InvPersLines[Idx].CrossPoints[j].X + DiffX,
                        InvPersLines[Idx].CrossPoints[j].Y);
                }
            }

            // Inv. Organisationen
            for (int Idx = 0; Idx < InvOrgLines.Count; Idx++)
            {
                InvOrgLines[Idx].From.X += DiffX;
                InvOrgLines[Idx].From.Y += DiffY;
                InvOrgLines[Idx].To.X += DiffX;
                InvOrgLines[Idx].To.Y += DiffY;
                for (int j = 0; j < InvOrgLines[Idx].CrossPoints.Count; j++)
                {
                    InvOrgLines[Idx].CrossPoints[j] = new System.Drawing.Point(
                        InvOrgLines[Idx].CrossPoints[j].X + DiffX,
                        InvOrgLines[Idx].CrossPoints[j].Y + DiffY);
                }
            }

            #endregion

            // Alles zeichnen

            #region Klienten und Bezugspersonen erstellen

            // alle Elemente einfügen
            PI.CtlItemClient aCtlItemClient;
            int PosLeft = 0;
            for (Int32 Idx = 0; Idx < PersonList.Count; Idx++)
            {
                String strID = ",";
                for (Int32 rID = 0; rID < ServProvClients.Count; rID++)
                {
                    if (ServProvClients[rID].RelID == PersonList[Idx].PersonID)
                    {
                        strID += ServProvClients[rID].ID.ToString() + ",";
                    }
                }

                // Element erstellen
                aCtlItemClient = new PI.CtlItemClient(
                    PersonList[Idx].PersonID,
                    PersonList[Idx].FirstName,
                    PersonList[Idx].LastName,
                    PersonList[Idx].Gender,
                    PersonList[Idx].Age,
                    PersonList[Idx].InfoText,
                    PersonList[Idx].IsDead,
                    strID);

                // Element noch positionieren
                aCtlItemClient.Left = PersonList[Idx].Pixels.X;
                aCtlItemClient.Top = PersonList[Idx].Pixels.Y;

                PosLeft = 12;
                for (int iIdx = 0; iIdx < ClientIcons.Count; iIdx++)
                    if (ClientIcons[iIdx].ID == PersonList[Idx].PersonID)
                    {
                        // Icons einfügen
                        AddIcon(aCtlItemClient, ClientIcons[iIdx].RelID, PosLeft, 55 + 2,
                            ClientIcons[iIdx].ID);
                        PosLeft += 20;
                    }

                //ctlItemClient.Location
                aCtlSozialsystem.panClients.Controls.Add(aCtlItemClient);
                aCtlItemClient.BringToFront();
                if (Idx == 0)
                    aCtlItemClient.Focus();

                // Relation zu Icons setzen:
                // TODO:
                /*
                for (int iIdx=0; iIdx<IconListAll.Count; iIdx++)
                    if (IconListAll[iIdx].PersonID == PersonList[Idx].PersonID)
                        IconListAll[iIdx].CtlClient = aCtlItemClient;
                 * */
            }

            #endregion

            #region für Klienten: Anpassung an Koordinatensystem und Linien zeichnen

            // Die Linien aufteilen und der Grafik übergeben
            List<SSGraphLineItem> aSSGraphLineItemListTmp = new List<SSGraphLineItem>();

            DiffY = 0;
            for (int i = 0; i < ClientLines.Count; i++)
            {
                if (ClientLines[i].IsStartPoint)
                    // Es wurde ein Startpunkt gefunden,
                    // deshalb muss die Liste aSSGraphLineItemListTmp zuerst gelöscht werden:
                    aSSGraphLineItemListTmp.Clear();

                // jetzt kann die Liste gefüllt werden:
                aSSGraphLineItemListTmp.Add(ClientLines[i]);

                if (ClientLines[i].IsEndPoint)
                {
                    // Der letzte Punkt wurde gefunden, also jetzt die Liste der Grafik übergeben
                    // Zuerst Umrechnen auf Koordinatensystem des Fensters
                    for (int j = 0; j < aSSGraphLineItemListTmp.Count; j++)
                    {
                        aSSGraphLineItemListTmp[j].From.X += DiffX;
                        aSSGraphLineItemListTmp[j].From.Y += DiffY;
                        aSSGraphLineItemListTmp[j].To.X += DiffX;
                        aSSGraphLineItemListTmp[j].To.Y += DiffY;

                        // TODO: Code wieder entfernen
                        // Testen ohne Schnittpunkte
                        //aSSGraphLineItemListTmp[j].CrossPoints = new List<System.Drawing.Point>();

                        for (int k = 0; k < aSSGraphLineItemListTmp[j].CrossPoints.Count; k++)
                        {
                            aSSGraphLineItemListTmp[j].CrossPoints[k] = new System.Drawing.Point(
                                aSSGraphLineItemListTmp[j].CrossPoints[k].X + DiffX,
                                aSSGraphLineItemListTmp[j].CrossPoints[k].Y + DiffY);
                        }
                    }

                    //Relation aRelation = new Relation(aCtlSozialsystem.panClients, RelationType.Client_Client, aSSGraphLineItemListTmp);
                    Relation aRelation = new Relation(aCtlSozialsystem.panSozialsystem, RelationType.Client_Client, aSSGraphLineItemListTmp);
                    aSSGraphLineItemListTmp.Clear();
                }
            }
            aSSGraphLineItemListTmp.Clear();

            #endregion

            // Leistungsträger

            #region Leistungstraeger in Grafik einfügen

            // alle Leistungstraeger einfügen
            PI.CtlItemServiceProvider aServProv;
            int ServProvWidth = 0;

            for (int Idx = 0; Idx < ServProvList.Count; Idx++)
            {
                aServProv = new PI.CtlItemServiceProvider(
                    ServProvList[Idx].Function,
                    ServProvList[Idx].FirstName + " " +
                    ServProvList[Idx].LastName,
                    ServProvList[Idx].Organisation,
                    ServProvList[Idx].Contact,
                    ServProvList[Idx].UserID);

                PosLeft = 8;
                for (int iIdx = 0; iIdx < ServProvIcons.Count; iIdx++)
                    if (ServProvIcons[iIdx].ID == ServProvList[Idx].UserID)
                    {
                        // Icons einfügen
                        AddIcon(aServProv, ServProvIcons[iIdx].RelID, PosLeft, 55 + 2,
                            ServProvIcons[iIdx].ID);
                        PosLeft += 20;
                    }

                aCtlSozialsystem.panServiceProviders.Controls.Add(aServProv);
                aServProv.Left = cstBoxBorderX + ((aServProv.Width + cstServProvSpaceX) * Idx);
                ServProvList[Idx].Left = aServProv.Left;
                ServProvList[Idx].Width = aServProv.Width;
                aServProv.Top = cstServProvBorderTop;
                ServProvWidth = aServProv.Left + aServProv.Width + cstBoxBorderX;
            }
            aCtlSozialsystem.panServiceProviders.Width = ServProvWidth;

            #endregion

            #region Maximum für Fenstergrösse bestimmen und Grösse des Grafikfensters anpassen

            // Korrekturen für Grösse des Fensters
            DiffX = 0;
            DiffY = 0;
            int TotalMaxX = 0;
            int TotalMaxY = 0;
            for (int i = 0; i < PersonList.Count; i++)
            {
                if (TotalMaxX < PersonList[i].Pixels.X + cstClientBoxSizeX + cstBoxBorderX + DiffX)
                    TotalMaxX = PersonList[i].Pixels.X + cstClientBoxSizeX + cstBoxBorderX + DiffX;
                if (TotalMaxY < PersonList[i].Pixels.Y + cstClientBoxSizeY + cstBoxBorderY + DiffY)
                    TotalMaxY = PersonList[i].Pixels.Y + cstClientBoxSizeY + cstBoxBorderY + DiffY;
            }

            for (int i = 0; i < ClientLines.Count; i++)
            {
                if (TotalMaxX < ClientLines[i].From.X + cstBoxBorderX)
                    TotalMaxX = ClientLines[i].From.X + cstBoxBorderX;
                if (TotalMaxY < ClientLines[i].From.Y + cstBoxBorderY)
                    TotalMaxY = ClientLines[i].From.Y + cstBoxBorderY;
                if (TotalMaxX < ClientLines[i].To.X + cstBoxBorderX)
                    TotalMaxX = ClientLines[i].To.X + cstBoxBorderX;
                if (TotalMaxY < ClientLines[i].To.Y + cstBoxBorderY)
                    TotalMaxY = ClientLines[i].To.Y + cstBoxBorderY;
            }

            // Leistungsträger
            int MaxServProvWidth = 0;
            for (int i = 0; i < ServProvList.Count; i++)
            {
                if (MaxServProvWidth < ServProvList[i].Left + ServProvList[i].Width + cstBoxBorderX)
                    MaxServProvWidth = ServProvList[i].Left + ServProvList[i].Width + cstBoxBorderX;
            }

            // Inv. Personen
            for (int i = 0; i < InvPersList.Count; i++)
            {
                if (TotalMaxY < InvPersList[i].Top + InvPersList[i].Height + cstBoxBorderY)
                    TotalMaxY = InvPersList[i].Top + InvPersList[i].Height + cstBoxBorderY;
            }
            for (int i = 0; i < InvPersLines.Count; i++)
            {
                if (TotalMaxX < InvPersLines[i].From.X)
                    TotalMaxX = InvPersLines[i].From.X;
                if (TotalMaxY < InvPersLines[i].From.Y)
                    TotalMaxY = InvPersLines[i].From.Y;
                if (TotalMaxX < InvPersLines[i].To.X)
                    TotalMaxX = InvPersLines[i].To.X;
                if (TotalMaxY < InvPersLines[i].To.Y)
                    TotalMaxY = InvPersLines[i].To.Y;
            }

            // Organisationen
            for (int i = 0; i < InvOrgsList.Count; i++)
            {
                if (TotalMaxY < InvOrgsList[i].Top + InvOrgsList[i].Height + cstBoxBorderY)
                    TotalMaxY = InvOrgsList[i].Top + InvOrgsList[i].Height + cstBoxBorderY;
            }

            for (int i = 0; i < InvOrgLines.Count; i++)
            {
                if (!InvOrgLines[i].IsStartPoint)
                {
                    if (TotalMaxX < InvOrgLines[i].From.X + cstBoxBorderX)
                        TotalMaxX = InvOrgLines[i].From.X + cstBoxBorderX;
                    if (TotalMaxY < InvOrgLines[i].From.Y + cstBoxBorderY)
                        TotalMaxY = InvOrgLines[i].From.Y + cstBoxBorderY;
                    if (TotalMaxX < InvOrgLines[i].To.X + cstBoxBorderX)
                        TotalMaxX = InvOrgLines[i].To.X + cstBoxBorderX;
                    if (TotalMaxY < InvOrgLines[i].To.Y + cstBoxBorderY)
                        TotalMaxY = InvOrgLines[i].To.Y + cstBoxBorderY;
                }
            }
            for (int i = 0; i < InvOrgLines.Count; i++)
            {
                if (InvOrgLines[i].IsStartPoint)
                    InvOrgLines[i].From.X = TotalMaxX + cstBordInvOrgs;
            }

            aCtlSozialsystem.panServiceProviders.Width = MaxServProvWidth;

            // Grösse des Fensters für die Darstellung optimieren, damit alles ohne Scrollbars sichtbar ist:
            aCtlSozialsystem.MinControlSize = new System.Drawing.Size(
                // Bei der Breite des Fensters muss das Panel rechts berücksichtig werden:
                TotalMaxX + aCtlSozialsystem.panInvolvedOrganisations.Width,
                // Höhe des Fensters: Für das unterste Label reservieren wir 30 Pixel:
                TotalMaxY + cstTitelLabelHeight
            );

            #endregion

            #region Linien für involvierte Personen zeichnen

            for (int i = 0; i < InvPersLines.Count; i++)
            {
                // TODO
                // Für Test:
                //PersLineList[i].CrossPoints = new List<System.Drawing.Point>();

                if (InvPersLines[i].IsStartPoint)
                    // Es wurde ein Startpunkt gefunden,
                    // deshalb muss die Liste aSSGraphLineItemListTmp zuerst gelöscht werden:
                    aSSGraphLineItemListTmp.Clear();

                // jetzt kann die Liste gefüllt werden:
                aSSGraphLineItemListTmp.Add(InvPersLines[i]);

                if (InvPersLines[i].IsEndPoint)
                {
                    // Der letzte Punkt wurde gefunden, also jetzt die Liste der Grafik übergeben
                    Relation aRelation = new Relation(aCtlSozialsystem.panSozialsystem, RelationType.InvolvedPerson_Client, aSSGraphLineItemListTmp);
                    aSSGraphLineItemListTmp.Clear();
                }
            }
            aSSGraphLineItemListTmp.Clear();

            #endregion

            #region Linien für involvierte Institutionen zeichnen

            for (int i = 0; i < InvOrgLines.Count; i++)
            {
                if (InvOrgLines[i].IsStartPoint)
                    // Es wurde ein Startpunkt gefunden,
                    // deshalb muss die Liste aSSGraphLineItemListTmp zuerst gelöscht werden:
                    aSSGraphLineItemListTmp.Clear();

                // jetzt kann die Liste gefüllt werden:
                aSSGraphLineItemListTmp.Add(InvOrgLines[i]);

                if (InvOrgLines[i].IsEndPoint)
                {
                    // Der letzte Punkt wurde gefunden, also jetzt die Liste der Grafik übergeben
                    Relation aRelation = new Relation(aCtlSozialsystem.panSozialsystem, RelationType.InvolvedOrganisation_Client, aSSGraphLineItemListTmp);
                    aSSGraphLineItemListTmp.Clear();
                }
            }
            aSSGraphLineItemListTmp.Clear();

            #endregion

            // Freigabe der Listen

            #region Alle Listen aus dem Memory entfernen

            //
            for (int i = 0; i < PersonList.Count; i++)
                PersonList[i].dpListBottom.Clear();
            for (int i = 0; i < PersonList.Count; i++)
                PersonList[i].dpListTop.Clear();
            for (int i = 0; i < PersonList.Count; i++)
                PersonList[i].dpListRight.Clear();
            for (int i = 0; i < PersonList.Count; i++)
                PersonList[i].dpListLeft.Clear();
            PersonList.Clear();
            RelationList.Clear();
            ServProvList.Clear();
            InvPersList.Clear();
            InvOrgsList.Clear();
            ClientIcons.Clear();
            ServProvIcons.Clear();

            for (int i = 0; i < ClientLines.Count; i++)
                ClientLines[i].CrossPoints.Clear();
            ClientLines.Clear();
            for (int i = 0; i < InvPersLines.Count; i++)
                InvPersLines[i].CrossPoints.Clear();
            InvPersLines.Clear();
            for (int i = 0; i < InvOrgLines.Count; i++)
                InvOrgLines[i].CrossPoints.Clear();
            InvOrgLines.Clear();

            aBoxSpacesListX.Clear();
            aBoxSpacesListY.Clear();

            #endregion
        }

        #endregion

        #region Private Methods

        private void AddIcon(CtlBaseItem item, int iconID, int PosLeft, int PosTop, int aID)
        {
            // add icon
            PictureBox picIcon = new PictureBox();
            picIcon.Image = KissImageList.GetSmallImage(iconID);
            picIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            picIcon.Left = PosLeft;
            picIcon.Top = PosTop;
            picIcon.Tag = string.Format("{0}", aID);
            item.Controls.Add(picIcon);
            picIcon.BringToFront();
        }

        private int CalculateDockingPosition(int PersIdx, DockPointTypes AType, bool PreferLeftSide, int actY)
        {
            int dpMaxPosLeft = 0;
            int dpMaxPosRight = 0;
            int dpValue = 0;
            if (AType.Equals(DockPointTypes.dpBottom))
            {
                for (int d = 0; d < PersonList[PersIdx].dpListBottom.Count; d++)
                {
                    if (dpMaxPosLeft > PersonList[PersIdx].dpListBottom[d].Position)
                        dpMaxPosLeft = PersonList[PersIdx].dpListBottom[d].Position;
                    if (dpMaxPosRight < PersonList[PersIdx].dpListBottom[d].Position)
                        dpMaxPosRight = PersonList[PersIdx].dpListBottom[d].Position;
                }
                // Wenn es bereits Punkte gibt, dann nächst freien zurückliefern
                if (PersonList[PersIdx].dpListBottom.Count > 0)
                    dpMaxPosLeft -= 1;
                if (PersonList[PersIdx].dpListBottom.Count > 0)
                    dpMaxPosRight += 1;

                if (PreferLeftSide)
                    dpValue = dpMaxPosLeft;
                else
                    dpValue = dpMaxPosRight;
                while (DockingLineHasConflict(PersIdx, true, dpValue, actY))
                {
                    if (PreferLeftSide)
                        dpValue -= 1;
                    else
                        dpValue += 1;
                }
            }
            else
            {
                for (int d = 0; d < PersonList[PersIdx].dpListTop.Count; d++)
                {
                    if (dpMaxPosLeft > PersonList[PersIdx].dpListTop[d].Position)
                        dpMaxPosLeft = PersonList[PersIdx].dpListTop[d].Position;
                    if (dpMaxPosRight < PersonList[PersIdx].dpListTop[d].Position)
                        dpMaxPosRight = PersonList[PersIdx].dpListTop[d].Position;
                }
                // Wenn es bereits Punkte gibt, dann nächst freien zurückliefern
                if (PersonList[PersIdx].dpListTop.Count > 0)
                    dpMaxPosLeft -= 1;
                if (PersonList[PersIdx].dpListTop.Count > 0)
                    dpMaxPosRight += 1;

                if (PreferLeftSide)
                    dpValue = dpMaxPosLeft;
                else
                    dpValue = dpMaxPosRight;
                while (DockingLineHasConflict(PersIdx, false, dpValue, actY))
                {
                    if (PreferLeftSide)
                        dpValue -= 1;
                    else
                        dpValue += 1;
                }
            }
            return dpValue;
        }

        private bool CheckIntersectionsY(int aRelIdx, int aLineIdx, int newX1, int newX2, int newY)
        {
            // Checken, ob es eine Lineienüberschneidung gibt:
            if (newX1 == 0 && newX2 == 0)
                return true;
            if (aRelIdx == -1)
                return true;

            int leftX = Math.Min(newX1, newX2);
            int rightX = Math.Max(newX1, newX2);
            int leftLine;
            int rightLine;
            for (int x = 0; x < ClientLines.Count; x++)
                if (ClientLines[x].LineDir == LineDirectionType.ldHor &&
                    ClientLines[x].GridLineY == aLineIdx &&
                    ClientLines[x].RelationID != aRelIdx &&
                    (ClientLines[x].From.Y == newY && newY > 0))
                {
                    leftLine = Math.Min(ClientLines[x].From.X, ClientLines[x].To.X);
                    rightLine = Math.Max(ClientLines[x].From.X, ClientLines[x].To.X);
                    if (!((leftX < leftLine && rightX < leftLine) ||
                           (leftX > rightLine && rightX > rightLine)))
                        return true;
                }
            return false;
        }

        private bool DockingLineHasConflict(int PersIdx, bool IsTop, int DokPos, int actY)
        {
            // Check, ob die vertikale Dockinglinie mit einer Dockinglinie einer Box
            // oberhalb oder unterhalb Überschneidungen hat

            // Wenn es die oberste Linie ist, dann kein Konflikt
            if (actY == 0)
                return false;
            if (IsTop && PersonList[PersIdx].Location.Y == 0)
                return false;

            // Wenn keine Box existiert,  dann kein Konflikt
            int CheckPersIdx = GetNextClientBoxIndex_Vertical(PersIdx, IsTop);
            if (CheckPersIdx < 0)
                return false;

            // Wenn auf der Box kein Docking Punkt existiert, dann kein Konflikt
            int DockLineIdx = GetDockingLineIndex(CheckPersIdx, !IsTop, DokPos);
            if (DockLineIdx < 0)
                return false;

            bool HasConflict = false;
            int otherTop = Math.Min(ClientLines[DockLineIdx].From.Y, ClientLines[DockLineIdx].To.Y);
            int otherBottom = Math.Max(ClientLines[DockLineIdx].From.Y, ClientLines[DockLineIdx].To.Y);

            if (IsTop)
                HasConflict = (otherBottom >= actY);
            else
                HasConflict = (otherTop <= actY);

            return HasConflict;
        }

        private int GetDistanceLeftLineX(bool AddLineOnLeft, LineTypes LineType)
        {
            // Liefert die Distanz von linken Boxrand zur zu erstellenden Linie
            // kontrollieren, ob der Abstand zwischen Boxen ganz links
            // und den inv. Personen vergrössert werden muss oder nicht
            aBoxSpacesListX[0].LineCount += 1;
            int ResultX = cstBoxBorderX;

            int MinDistX = cstBoxBorderX;
            if (aBoxSpacesListX[0].LineCount > 0)
                MinDistX += cstBoxBorderX;
            MinDistX += ((aBoxSpacesListX[0].LineCount - 1) * cstLineSpaceX);

            int Distance = MinDistX - aBoxSpacesListX[0].PixelSize;
            if (Distance > 0)
            {
                if (AddLineOnLeft)
                {
                    MoveAllComponentsLeft(0, cstBoxBorderX - 1, Distance);
                }
                else
                {
                    MoveAllComponentsLeft(0, MinDistX - 1, Distance);
                    ResultX = MinDistX;
                }
            }
            aBoxSpacesListX[0].PixelSize = MinDistX;
            return ResultX;
        }

        private int GetDistanceTopLineY(int aRelIdx, int PersIdx, bool AddLineOnTop, LineTypes LineType, int newX1, int newX2)
        {
            // Liefert die Distanz von oberen Boxrand zur zu erstellenden Linie oberhalb
            // kontrollieren, ob der Abstand zwischen den Boxen vergrössert werden muss oder nicht
            // Neuer Code, damit wird verhindert, dass sich die Linientypen ltHor und ltHorMany überschneiden:

            if (aBoxSpacesListY[0].LineCount == 0)
                aBoxSpacesListY[0].LineCount += 1;
            else
            {
                bool HasIntersection = false;
                int tmpY = cstBoxBorderY + cstTitelLabelHeight;
                if ((!AddLineOnTop) && (aBoxSpacesListY[0].LineCount > 1))
                    tmpY += ((aBoxSpacesListY[0].LineCount - 1) * cstLineSpaceY);
                HasIntersection = CheckIntersectionsY(aRelIdx, 0, newX1, newX2, tmpY);
                if (HasIntersection)
                    aBoxSpacesListY[0].LineCount += 1;
            }

            // alt: 30.09.2007
            //aBoxSpacesListY[0].LineCount += 1;

            int MinDistY = cstBoxBorderY + cstLabelHeight + cstTitelLabelHeight;
            if (aBoxSpacesListY[0].LineCount > 1)
                MinDistY += ((aBoxSpacesListY[0].LineCount - 1) * cstLineSpaceY);

            // Position der neuen Linie bestimmen
            int Distance, MoveTop, ResultY;
            if (AddLineOnTop)
            {
                // Die neue Linie wird zuoberst angefügt:
                ResultY = cstBoxBorderY + cstTitelLabelHeight;
                MoveTop = ResultY - 1;
            }
            else
            {
                // Die neue Linie wird unterhalb der anderen Linien angefügt:
                ResultY = cstBoxBorderY + cstTitelLabelHeight;
                if (aBoxSpacesListY[0].LineCount > 1)
                    ResultY += ((aBoxSpacesListY[0].LineCount - 1) * cstLineSpaceY);
                MoveTop = ResultY + 1;
            }
            Distance = MinDistY - aBoxSpacesListY[0].PixelSize;
            if (Distance > 0)
                MoveAllComponentsDown(0, MoveTop, Distance);
            aBoxSpacesListY[0].PixelSize = MinDistY;
            return ResultY;
        }

        private int GetDockingLineIndex(int CheckPersIdx, bool IsTop, int DokPos)
        {
            if (IsTop)
            {
                for (int x1 = 0; x1 < PersonList[CheckPersIdx].dpListBottom.Count; x1++)
                    if (PersonList[CheckPersIdx].dpListBottom[x1].Position == DokPos)
                        return PersonList[CheckPersIdx].dpListBottom[x1].LineItemIdx;
            }
            else
            {
                for (int x1 = 0; x1 < PersonList[CheckPersIdx].dpListTop.Count; x1++)
                    if (PersonList[CheckPersIdx].dpListTop[x1].Position == DokPos)
                        return PersonList[CheckPersIdx].dpListTop[x1].LineItemIdx;
            }
            return -1;
        }

        private int GetDockingPointPosition(int RelIdx, int PersIdx, int aLineItemIdx, DockPointTypes AType,
            string dpText, int WishedX, LineTypes aLineType, int aPreferedPosition, DockPointTextTypes aTextType, int actY)
        {
            /*
            int dpMaxPosLeft = 0;
            int dpMaxPosRight = 0;
            if (AType.Equals(DockPointTypes.dpBottom))
            {
                // Zuerst schauen, ob es einen Punkt mit diesem Text bereits gibt
                // TODO:
                // Vorerst ausgeschaltet, da zuviele Überschneidungen entstanden
                /*
                for (int d = 0; d < PersonList[PersIdx].dpListBottom.Count; d++)
                    if ((PersonList[PersIdx].dpListBottom[d].DockingText == dpText) &&
                        (PersonList[PersIdx].dpListBottom[d].TextType.Equals(aTextType)))
                        return PersonList[PersIdx].dpListBottom[d].Position;
                 * */

            // ... sonst eine neuen suchen
            /*                for (int d = 0; d < PersonList[PersIdx].dpListBottom.Count; d++)
                            {
                                if (dpMaxPosLeft > PersonList[PersIdx].dpListBottom[d].Position)
                                    dpMaxPosLeft = PersonList[PersIdx].dpListBottom[d].Position;
                                if (dpMaxPosRight < PersonList[PersIdx].dpListBottom[d].Position)
                                    dpMaxPosRight = PersonList[PersIdx].dpListBottom[d].Position;
                            }

                            // Wenn es bereits Punkte gibt, dann nächst freien zurückliefern
                            if (PersonList[PersIdx].dpListBottom.Count > 0) dpMaxPosLeft -= 1;
                            if (PersonList[PersIdx].dpListBottom.Count > 0) dpMaxPosRight += 1;

                            DockPoint adp = new DockPoint();
                            adp.DockingText = dpText;
                            adp.LineItemIdx = aLineItemIdx;
                            adp.LineType = aLineType;
                            adp.TextType = aTextType;
                            adp.PreferedPosition = aPreferedPosition;
                            if (WishedX > 0) adp.Position = dpMaxPosRight; else adp.Position = dpMaxPosLeft;
                            PersonList[PersIdx].dpListBottom.Add(adp);
                            return adp.Position;
                        }
                        else
                        {
                            // Zuerst schauen, ob es einen Punkt mit diesem Text bereits gibt
                            // TODO:
                            // Vorerst ausgeschaltet, da zuviele Überschneidungen entstanden
                            /*
                            for (int d = 0; d < PersonList[PersIdx].dpListTop.Count; d++)
                                if ((PersonList[PersIdx].dpListTop[d].DockingText == dpText) &&
                                    (PersonList[PersIdx].dpListTop[d].TextType.Equals(aTextType)))
                                    return PersonList[PersIdx].dpListTop[d].Position;
                             * */

            // ... sonst eine neuen suchen
            /*                for (int d = 0; d < PersonList[PersIdx].dpListTop.Count; d++)
                            {
                                if (dpMaxPosLeft > PersonList[PersIdx].dpListTop[d].Position)
                                    dpMaxPosLeft = PersonList[PersIdx].dpListTop[d].Position;
                                if (dpMaxPosRight < PersonList[PersIdx].dpListTop[d].Position)
                                    dpMaxPosRight = PersonList[PersIdx].dpListTop[d].Position;
                            }
                            // Wenn es bereits Punkte gibt, dann nächst freien zurückliefern
                            if (PersonList[PersIdx].dpListTop.Count > 0) dpMaxPosLeft -= 1;
                            if (PersonList[PersIdx].dpListTop.Count > 0) dpMaxPosRight += 1;

                            DockPoint adp = new DockPoint();
                            adp.DockingText = dpText;
                            adp.LineItemIdx = aLineItemIdx;
                            adp.LineType = aLineType;
                            adp.TextType = aTextType;
                            adp.PreferedPosition = aPreferedPosition;
                            if (WishedX > 0) adp.Position = dpMaxPosRight; else adp.Position = dpMaxPosLeft;
                            PersonList[PersIdx].dpListTop.Add(adp);
                            return adp.Position;
                        }
             * */

            // Neu:
            bool PreferLeftSide = (WishedX < 0);
            int newPos = CalculateDockingPosition(PersIdx, AType, PreferLeftSide, actY);

            DockPoint adp = new DockPoint();
            adp.DockingText = dpText;
            adp.LineItemIdx = aLineItemIdx;
            adp.LineType = aLineType;
            adp.TextType = aTextType;
            adp.PreferedPosition = aPreferedPosition;
            adp.Position = newPos;
            if (AType.Equals(DockPointTypes.dpBottom))
                PersonList[PersIdx].dpListBottom.Add(adp);
            else
                PersonList[PersIdx].dpListTop.Add(adp);
            return adp.Position;
        }

        private int GetIndex(int aPersonID)
        {
            // Liefert den Index in der Personenliste, wenn die DB-ID übergeben wird
            for (int j = 0; j < PersonList.Count; j++)
                if (PersonList[j].PersonID == aPersonID)
                    return j;
            // TODO: Diese Meldung anzeigen oder nicht?
            //KissMsg.ShowInfo("Personenschlüssel in Relationen nicht gefunden.");
            return -1;
        }

        private int GetNewHorizontalLinePositionX(int aLineIdx, bool AddNewLine, bool AddLineOnLeft, bool AddLabelLeft, bool AddLabelRight)
        {
            // X-Wert-Position einer neuen vertikalen Linie bestimmen:
            // Angabe, ob bei dieser Linie der Platz für eine Beschriftung reserviert werden soll oder nicht
            if (AddLabelLeft)
                aBoxSpacesListX[aLineIdx].HasLabelTopLeft = true;
            if (AddLabelRight)
                aBoxSpacesListX[aLineIdx].HasLabelBottomRight = true;

            // Linienplatz erhöhen
            if (AddNewLine)
                aBoxSpacesListX[aLineIdx].LineCount += 1;

            // Neue Grösse
            int NewWidth = 0;
            if (aBoxSpacesListX[aLineIdx].HasLabelTopLeft)
                NewWidth = cstLabelWidth;
            else
                NewWidth = cstBoxBorderX;
            if (aBoxSpacesListX[aLineIdx].HasLabelBottomRight)
                NewWidth += cstLabelWidth;
            else
                NewWidth += cstBoxBorderX;
            if (aBoxSpacesListX[aLineIdx].LineCount > 1)
                NewWidth += ((aBoxSpacesListX[aLineIdx].LineCount - 1) * cstLineSpaceX);

            // Neue Position
            int NewPosition = 0;
            if (aBoxSpacesListX[aLineIdx].HasLabelTopLeft)
                NewPosition = cstLabelWidth;
            else
                NewPosition = cstBoxBorderX;
            if (!AddLineOnLeft)
                NewPosition += ((aBoxSpacesListX[aLineIdx].LineCount - 1) * cstLineSpaceX);

            // Wenn nötig, alles verschieben:
            int Distance = NewWidth - aBoxSpacesListX[aLineIdx].PixelSize;
            if (Distance > 0)
            {
                int aTop = aBoxSpacesListX[aLineIdx].StartTopLeft;
                if (!AddLineOnLeft)
                    aTop += NewPosition;
                MoveAllComponentsLeft(aLineIdx, aTop, Distance);
            }
            aBoxSpacesListX[aLineIdx].PixelSize = NewWidth;
            NewPosition += aBoxSpacesListX[aLineIdx].StartTopLeft;
            return NewPosition;
        }

        private int GetNewLineInvOrganisations(int InvOrgsIdx, int ClientIdx, bool IsStartLine, bool IsEndLine, LineDirectionType aLineDir)
        {
            SSGraphLineItem aOrgsLine = new SSGraphLineItem();
            aOrgsLine.RelationID = InvOrgsIdx;
            aOrgsLine.ToPersonIdx = ClientIdx;
            aOrgsLine.LineDir = aLineDir;
            aOrgsLine.IsStartPoint = IsStartLine;
            aOrgsLine.IsEndPoint = IsEndLine;
            if (IsStartLine)
            {
                aOrgsLine.LineIndex = 0;
                aOrgsLine.Anchor =
                    System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Left |
                    System.Windows.Forms.AnchorStyles.Right;
            }
            else
            {
                aOrgsLine.From.X = InvOrgLines[InvOrgLines.Count - 1].To.X;
                aOrgsLine.From.Y = InvOrgLines[InvOrgLines.Count - 1].To.Y;
                aOrgsLine.LineIndex = InvOrgLines[InvOrgLines.Count - 1].LineIndex + 1;
                aOrgsLine.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
                if (aLineDir.Equals(LineDirectionType.ldHor))
                    aOrgsLine.To.Y = aOrgsLine.From.Y;
                else
                    aOrgsLine.To.X = aOrgsLine.From.X;
            }
            InvOrgLines.Add(aOrgsLine);
            return InvOrgLines.Count - 1;
        }

        private int GetNewLineInvPersons(int InvPersIdx, int ClientIdx, bool IsStartLine, bool IsEndLine, LineDirectionType aLineDir)
        {
            SSGraphLineItem aPersLine = new SSGraphLineItem();
            aPersLine.RelationID = InvPersIdx;
            aPersLine.ToPersonIdx = ClientIdx;
            aPersLine.LineDir = aLineDir;
            aPersLine.IsStartPoint = IsStartLine;
            aPersLine.IsEndPoint = IsEndLine;
            aPersLine.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            if (IsStartLine)
                aPersLine.LineIndex = 0;
            if (!IsStartLine)
            {
                aPersLine.From.X = InvPersLines[InvPersLines.Count - 1].To.X;
                aPersLine.From.Y = InvPersLines[InvPersLines.Count - 1].To.Y;
                aPersLine.LineIndex = InvPersLines[InvPersLines.Count - 1].LineIndex + 1;
                if (aLineDir.Equals(LineDirectionType.ldHor))
                    aPersLine.To.Y = aPersLine.From.Y;
                else
                    aPersLine.To.X = aPersLine.From.X;
            }
            InvPersLines.Add(aPersLine);
            return InvPersLines.Count - 1;
        }

        private int GetNewLineItem(int RelIdx, int FromPersIdx, int ToPersIdx, bool IsFirstItem, bool IsLastItem, LineDirectionType aLineDir, int LineIdxX, int LineIdxY)
        {
            // Erstellt eine neues Linien Stück
            // und übernimmt den Punkt der letzten Position, wenn IsFirstItem = false ist.
            // Liefert den Index des neuen Elementes
            SSGraphLineItem aSSGraphLineItem = new SSGraphLineItem();
            ClientLines.Add(aSSGraphLineItem);
            int MaxIdx = ClientLines.Count - 1;
            ClientLines[MaxIdx].RelationID = RelIdx;
            ClientLines[MaxIdx].DockingTextFrom = "";
            ClientLines[MaxIdx].DockingTextTo = "";
            ClientLines[MaxIdx].IsStartPoint = IsFirstItem;
            ClientLines[MaxIdx].IsEndPoint = IsLastItem;
            ClientLines[MaxIdx].LineDir = aLineDir;
            ClientLines[MaxIdx].Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // Index für Docking Points setzen:
            if (IsFirstItem)
            {
                int aDkPoInd = RelationList[RelIdx].DockPointFromIdx;
                ClientLines[MaxIdx].DockPointFromIdx = aDkPoInd;
                int aPersIdx = RelationList[RelIdx].PListID1;
                ClientLines[MaxIdx].DockingTextFrom = RelationList[RelIdx].RelationName1;
                // für zusätzliche Abstände
                ClientLines[MaxIdx].GridFrom = PersonList[aPersIdx].Location;
                ClientLines[MaxIdx].GridTo = ClientLines[MaxIdx].GridFrom;
                ClientLines[MaxIdx].FromPersonIdx = FromPersIdx;
                ClientLines[MaxIdx].GridLineX = LineIdxX;
                ClientLines[MaxIdx].GridLineY = LineIdxY;
            }
            if (IsLastItem)
            {
                int aDkPoInd = RelationList[RelIdx].DockPointToIdx;
                ClientLines[MaxIdx].DockPointToIdx = aDkPoInd;
                int aPersIdx = RelationList[RelIdx].PListID2;
                ClientLines[MaxIdx].DockingTextTo = RelationList[RelIdx].RelationName2;
                // für zusätzliche Abstände
                if (!IsFirstItem)
                    ClientLines[MaxIdx].GridFrom = PersonList[aPersIdx].Location;
                ClientLines[MaxIdx].GridTo = PersonList[aPersIdx].Location;
                ClientLines[MaxIdx].FromPersonIdx = ToPersIdx;
            }

            // Wenn es nicht das erste Element der Linie ist,
            // dann können die Startkoordinaten aus den Endkoordinate des vorhergehenden Elements übernommen werden
            if (!IsFirstItem)
            {
                ClientLines[MaxIdx].From = ClientLines[MaxIdx - 1].To;
                ClientLines[MaxIdx].To = ClientLines[MaxIdx].From;
                ClientLines[MaxIdx].GridFrom = ClientLines[MaxIdx - 1].GridTo;
                ClientLines[MaxIdx].BoxPositionY = ClientLines[MaxIdx - 1].BoxPositionY;
                ClientLines[MaxIdx].GridLineY = ClientLines[MaxIdx - 1].GridLineY;
                ClientLines[MaxIdx].GridLineX = ClientLines[MaxIdx - 1].GridLineX;
            }
            return MaxIdx;
        }

        private System.Drawing.Point GetNewPersonPosition(int aPersonIdx, int aRelationIdx, bool DownWard)
        {
            System.Drawing.Point tmpPoint = new System.Drawing.Point();

            // Wenn strikt verschiedene Generationen auf verschiedenen Linien erstellt werden sollen, kann verwendet werden:
            //int SymmStep = RelationList[aRelationIdx].SymmetricStep;
            //if ((!DownWard) && (SymmStep>0)) SymmStep = -RelationList[aRelationIdx].SymmetricStep;

            // Wenn dies keine Rolle spielt, also z.B. Vater und Grossvater auf einer Horizontalen sein dürfen:
            int SymmStep = 1;
            if (RelationList[aRelationIdx].Symmetric)
                SymmStep = 0;

            if (SymmStep == 0)
            {
                // Symmetrisch
                // Wenn auf der Linie des Klienten eingefügt wird...
                int NewX = GetNewPointOnLine(
                    PersonList[aPersonIdx].Location.Y,
                    PersonList[aPersonIdx].Location.X,
                    PersonList[aPersonIdx].Location.X + 1);
                tmpPoint.X = NewX;
                tmpPoint.Y = PersonList[aPersonIdx].Location.Y;
            }
            else
            {
                // Nicht Symmetrisch, Step nach oben
                // TODO: wenn eltern nach oben gehen sollen
                if (!DownWard)
                    SymmStep = -1;
                int NewX = GetNewPointOnLine(
                    PersonList[aPersonIdx].Location.Y + SymmStep,
                    PersonList[aPersonIdx].Location.X,
                    PersonList[aPersonIdx].Location.X);
                tmpPoint.X = NewX;
                tmpPoint.Y = PersonList[aPersonIdx].Location.Y + SymmStep;
            }
            return tmpPoint;
        }

        private int GetNewPointOnLine(int LineY, int LineX, int WishedX)
        {
            // Sucht suchen wir Links und rechst des Startpunkts LineX, schauen welche Distanz kürzer ist,
            // und liefern diesen Punkt zurück (kürzere Linie)
            int Anordnung = 1; // 1 = einmal rechts, einmal links
            // 2 = immer nach rechts aufreihen

            int FirstFreePositionOnLeft = WishedX;
            int FirstFreePositionOnRight = WishedX;
            bool FreePositionFoundOnLeft = false;
            bool FreePositionFoundOnRight = false;
            if (Anordnung == 1)
            {
                while (!(FreePositionFoundOnLeft && FreePositionFoundOnRight))
                {
                    FreePositionFoundOnLeft = PositionIsFree(FirstFreePositionOnLeft, LineY);
                    if (!FreePositionFoundOnLeft)
                        FirstFreePositionOnLeft -= 1;
                    FreePositionFoundOnRight = PositionIsFree(FirstFreePositionOnRight, LineY);
                    if (!FreePositionFoundOnRight)
                        FirstFreePositionOnRight += 1;
                }
                if (Math.Abs(FirstFreePositionOnLeft - LineX) < Math.Abs(FirstFreePositionOnRight - LineX))
                    return FirstFreePositionOnLeft;
                else
                    return FirstFreePositionOnRight;
            }
            else //if (Anordnung == 2)
            {
                //FirstFreePositionOnLeft = 0;
                while (!FreePositionFoundOnLeft)
                {
                    FreePositionFoundOnLeft = PositionIsFree(FirstFreePositionOnLeft, LineY);
                    if (!FreePositionFoundOnLeft)
                        FirstFreePositionOnLeft += 1;
                }
                return FirstFreePositionOnLeft;
            }
        }

        private int GetNewPositionY(int aLineIdx, bool AddLineOnTop)
        {
            int tmp = cstBoxBorderY;
            if (aBoxSpacesListY[aLineIdx].HasLabelTopLeft)
                tmp = cstLabelHeight;
            tmp += aBoxSpacesListY[aLineIdx].StartTopLeft;
            if ((!AddLineOnTop) && (aBoxSpacesListY[aLineIdx].LineCount > 1))
                tmp += ((aBoxSpacesListY[aLineIdx].LineCount - 1) * cstLineSpaceY);
            return tmp;
        }

        private int GetNewVerticalLinePositionY2(int aRelIdx, int aLineIdx, bool AddNewLine, bool AddLineOnTop, bool AddLabelTop, bool AddLabelBottom, int newX1, int newX2)
        {
            // Y-Wert-Position einer neuen horizontalen Linie bestimmen:
            // Angabe, ob bei dieser Linie der Platz für eine Beschriftung reserviert werden soll oder nicht
            if (AddLabelTop)
                aBoxSpacesListY[aLineIdx].HasLabelTopLeft = true;
            if (AddLabelBottom)
                aBoxSpacesListY[aLineIdx].HasLabelBottomRight = true;

            // Linienplatz erhöhen
            if (AddNewLine)
            {
                if (aBoxSpacesListY[aLineIdx].LineCount == 0)
                    aBoxSpacesListY[aLineIdx].LineCount += 1;
                else
                {
                    bool HasIntersection = false;
                    int TestPosY = GetNewPositionY(aLineIdx, AddLineOnTop);
                    HasIntersection = CheckIntersectionsY(aRelIdx, aLineIdx, newX1, newX2, TestPosY);
                    if (HasIntersection)
                        aBoxSpacesListY[aLineIdx].LineCount += 1;
                }
            }
            // alt: 30.09.2007
            //if (AddNewLine) aBoxSpacesListY[aLineIdx].LineCount += 1;

            // Neue Grösse
            int NewHeight = 0;
            if (aBoxSpacesListY[aLineIdx].HasLabelTopLeft)
                NewHeight = cstLabelHeight;
            else
                NewHeight = cstBoxBorderY;
            if (aBoxSpacesListY[aLineIdx].HasLabelBottomRight)
                NewHeight += cstLabelHeight;
            else
                NewHeight += cstBoxBorderY;
            if (aBoxSpacesListY[aLineIdx].LineCount > 1)
                NewHeight += ((aBoxSpacesListY[aLineIdx].LineCount - 1) * cstLineSpaceY);

            // Neue Position
            int NewPosition = 0;
            if (aBoxSpacesListY[aLineIdx].HasLabelTopLeft)
                NewPosition = cstLabelHeight;
            else
                NewPosition = cstBoxBorderY;
            if ((!AddLineOnTop) && (aBoxSpacesListY[aLineIdx].LineCount > 1))
                NewPosition += ((aBoxSpacesListY[aLineIdx].LineCount - 1) * cstLineSpaceY);

            // Wenn nötig, alles verschieben:
            int Distance = NewHeight - aBoxSpacesListY[aLineIdx].PixelSize;
            if (Distance > 0)
            {
                int aTop = aBoxSpacesListY[aLineIdx].StartTopLeft;
                if (!AddLineOnTop)
                    aTop += NewPosition;
                MoveAllComponentsDown(aLineIdx, aTop, Distance);
            }
            aBoxSpacesListY[aLineIdx].PixelSize = NewHeight;
            NewPosition += aBoxSpacesListY[aLineIdx].StartTopLeft;
            return NewPosition;
        }

        private int GetNextClientBoxIndex_Vertical(int PersIdx, bool IsTop)
        {
            for (int x1 = 0; x1 < PersonList.Count; x1++)
                if (x1 != PersIdx && PersonList[x1].Location.X == PersonList[PersIdx].Location.X)
                {
                    if (IsTop && PersonList[x1].Location.Y == PersonList[PersIdx].Location.Y + 1)
                        return x1;
                    if (!IsTop && PersonList[x1].Location.Y == PersonList[PersIdx].Location.Y - 1)
                        return x1;
                }
            return -1;
        }

        private bool HasClientsOnHorLine(int PixelY, int FromX, int ToX)
        {
            // TODO
            // Dies wird als Kontrolle verwendet, um eine horizontale Linie (y = PixelY) von den involvierten Personen
            // oder den involvierten Organisationen zu einer Box zu führen.
            // Wenn es auf dieser Linie ein Label oder eine Klientenbox hat (HasClientsOnHorLine = TRUE),
            // dann muss die Linie um Box / Label herum geführt werden.
            return true;
        }

        private bool HasIntersection(SSGraphLineItem Line1, SSGraphLineItem Line2, bool IsSameSystem, out System.Drawing.Point NewCrossPnt)
        {
            NewCrossPnt = new System.Drawing.Point();
            NewCrossPnt.X = 0;
            NewCrossPnt.Y = 0;
            bool HasPoint = false;

            // Wir kontrollieren nur die Fälle, wo eine Linie horizontal bzw vertikal
            // und die andere vertikal bzw. horizontal ist.
            // Die anderen Fälle wären sich überschneidende Linien, welche vorher abgefangen wurden.
            // Wenn nicht, gäbe es sowieso nicht einen Schnittpunkt, sondern eine Schnittgerade,
            // was wir sowiso nicht darstellen können und wollen
            if (Line1.LineDir.Equals(LineDirectionType.ldHor) && Line2.LineDir.Equals(LineDirectionType.ldVer))
            {
                // Die erste Linie ist eine horizontale, die zweite eine vertikale:
                NewCrossPnt.X = Line2.From.X;
                NewCrossPnt.Y = Line1.From.Y;
                HasPoint = (
                    ((NewCrossPnt.X > Line1.From.X && NewCrossPnt.X < Line1.To.X) || (NewCrossPnt.X > Line1.To.X && NewCrossPnt.X < Line1.From.X)) &&
                    ((NewCrossPnt.Y > Line2.From.Y && NewCrossPnt.Y < Line2.To.Y) || (NewCrossPnt.Y > Line2.To.Y && NewCrossPnt.Y < Line2.From.Y))
                    );
            }
            else if (Line1.LineDir.Equals(LineDirectionType.ldVer) && Line2.LineDir.Equals(LineDirectionType.ldHor))
            {
                // Die erste Linie ist eine vertikale, die zweite eine horizontale:
                NewCrossPnt.X = Line1.From.X;
                NewCrossPnt.Y = Line2.From.Y;
                HasPoint = (
                    ((NewCrossPnt.X > Line2.From.X && NewCrossPnt.X < Line2.To.X) || (NewCrossPnt.X > Line2.To.X && NewCrossPnt.X < Line2.From.X)) &&
                    ((NewCrossPnt.Y > Line1.From.Y && NewCrossPnt.Y < Line1.To.Y) || (NewCrossPnt.Y > Line1.To.Y && NewCrossPnt.Y < Line1.From.Y))
                    );
            }
            if (IsSameSystem)
                HasPoint = (HasPoint && (Line1.RelationID != Line2.RelationID));
            return HasPoint;
        }

        private void MoveAllComponentsDown(int aLine, int FromPos, int Distance)
        {
            // Personen veschieben
            for (int b = 0; b < PersonList.Count; b++)
            {
                if ((PersonList[b].Pixels.Y > FromPos) ||
                    ((aLine == 0) && (PersonList[b].Pixels.Y.Equals(cstBoxBorderY + cstTitelLabelHeight))))
                    PersonList[b].Pixels.Y += Distance;
            }
            // Linien verschieben
            for (int c = 0; c < ClientLines.Count; c++)
            {
                if (ClientLines[c].From.Y > FromPos)
                    ClientLines[c].From.Y += Distance;
                if (ClientLines[c].To.Y > FromPos)
                    ClientLines[c].To.Y += Distance;
            }
            for (int c = 0; c < InvPersLines.Count; c++)
                if (!InvPersLines[c].IsStartPoint)
                {
                    if (!(InvPersLines[c].LineIndex == 1))
                        if (InvPersLines[c].From.Y > FromPos)
                            InvPersLines[c].From.Y += Distance;
                    if (InvPersLines[c].To.Y > FromPos)
                        InvPersLines[c].To.Y += Distance;
                }
            for (int c = 0; c < InvOrgLines.Count; c++)
                if (!InvOrgLines[c].IsStartPoint)
                {
                    if (!(InvOrgLines[c].LineIndex == 1))
                        if (InvOrgLines[c].From.Y > FromPos)
                            InvOrgLines[c].From.Y += Distance;
                    if (InvOrgLines[c].To.Y > FromPos)
                        InvOrgLines[c].To.Y += Distance;
                }
            for (int b = aLine + 1; b < aBoxSpacesListY.Count; b++)
                aBoxSpacesListY[b].StartTopLeft += Distance;
        }

        private void MoveAllComponentsLeft(int aLine, int FromPos, int Distance)
        {
            // Personen veschieben
            for (int b = 0; b < PersonList.Count; b++)
            {
                if (PersonList[b].Pixels.X > FromPos)
                    PersonList[b].Pixels.X = PersonList[b].Pixels.X + Distance;
            }
            // Linien verschieben
            for (int c = 0; c < ClientLines.Count; c++)
            {
                if (ClientLines[c].From.X > FromPos)
                    ClientLines[c].From.X = ClientLines[c].From.X + Distance;
                if (ClientLines[c].To.X > FromPos)
                    ClientLines[c].To.X = ClientLines[c].To.X + Distance;
            }
            for (int c = 0; c < InvPersLines.Count; c++)
            {
                if (!InvPersLines[c].IsStartPoint)
                    if (InvPersLines[c].From.X > FromPos)
                        InvPersLines[c].From.X = InvPersLines[c].From.X + Distance;
                if (InvPersLines[c].To.X > FromPos)
                    InvPersLines[c].To.X = InvPersLines[c].To.X + Distance;
            }
            for (int b = aLine + 1; b < aBoxSpacesListX.Count; b++)
                aBoxSpacesListX[b].StartTopLeft += Distance;
        }

        private bool PositionIsFree(int aX, int aY)
        {
            for (int l = 0; l < PersonList.Count; l++)
                if (PersonList[l].Location.X == aX &&
                    PersonList[l].Location.Y == aY &&
                    PersonList[l].HasPosition)
                    return false;
            return true;
        }

        private void ProcessRelation(int IndexRel)
        {
            if (RelationList[IndexRel].IsProcessed)
                return;
            int Idx1 = RelationList[IndexRel].PListID1;
            int Idx2 = RelationList[IndexRel].PListID2;
            // wenn es eine Relation zum Klienten ist
            if ((PersonList[Idx1].HasPosition) && (!PersonList[Idx2].HasPosition))
            {
                // Die erste Person hat eine Positionerung, also kann die 2. Person gesetzt werden
                PersonList[Idx2].Location = GetNewPersonPosition(Idx1, IndexRel, true);
                PersonList[Idx2].HasPosition = true;
                RelationList[IndexRel].IsProcessed = true;
                RelationList[IndexRel].From = PersonList[Idx1].Location;
                RelationList[IndexRel].To = PersonList[Idx2].Location;
            }
            else if ((PersonList[Idx2].HasPosition) && (!PersonList[Idx1].HasPosition))
            {
                // Die zweite Person hat eine Positionerung, also kann die erste Person gesetzt werden
                PersonList[Idx1].Location = GetNewPersonPosition(Idx2, IndexRel, false);
                PersonList[Idx1].HasPosition = true;
                RelationList[IndexRel].IsProcessed = true;
                RelationList[IndexRel].From = PersonList[Idx1].Location;
                RelationList[IndexRel].To = PersonList[Idx2].Location;
            }
            else if ((PersonList[Idx2].HasPosition) && (PersonList[Idx1].HasPosition))
            {
                RelationList[IndexRel].IsProcessed = true;
                RelationList[IndexRel].From = PersonList[Idx1].Location;
                RelationList[IndexRel].To = PersonList[Idx2].Location;
            }
        }

        #endregion
    }
}