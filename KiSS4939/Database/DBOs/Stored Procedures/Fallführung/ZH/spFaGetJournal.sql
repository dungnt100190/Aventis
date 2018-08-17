SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaGetJournal;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetJournal
(
  @UserID INT, 
  @DmgPersonID INT
)
AS
declare @Result table (
  Datum       datetime,
  Typ         varchar(100),
  Titel       varchar(200),
  Autor       varchar(150),
  Text        varchar(7000),
  ThemenCodes varchar(100),
  DocumentID$ int
)

declare @Row table (
  FaFallID int, 
  FaPhaseID int, 
  GridRowID int
)


-- Besprechungen

insert @Row (FaFallID,GridRowID)
select distinct FAL.FaFallID,VAL.GridRowID 
from   FaFall FAL
       inner join DynaValue VAL on VAL.FaFallID = FAL.FaFallID
       inner join DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2 and
       FLD.Maskname = 'Fa_Dok_Besprechungen'

declare @FaDokBesprDatum int
declare @FaDokBesprAutor int
declare @FaDokBesprInhalt int
declare @FaDokBesprThemen int
declare @FaDokBesprStichwort int

set @FaDokBesprDatum     = (select DynaFieldID from DynaField where FieldName = 'FaDokBesprDatum')
set @FaDokBesprStichwort = (select DynaFieldID from DynaField where FieldName = 'FaDokBesprStichwort')
set @FaDokBesprAutor     = (select DynaFieldID from DynaField where FieldName = 'FaDokBesprAutor')
set @FaDokBesprInhalt    = (select DynaFieldID from DynaField where FieldName = 'FaDokBesprInhalt')
set @FaDokBesprThemen    = (select DynaFieldID from DynaField where FieldName = 'FaDokBesprThemen')

insert @Result
select Datum       = convert(datetime,A.Value),
       Typ         = 'Besprechung',
       Titel       = convert(varchar(200),B.Value),
       Autor       = (select LastName + isNull(', ' + FirstName,'') from XUser where UserID = convert(int,C.Value)),
       Text        = convert(varchar(7000),D.ValueText),
       ThemenCodes = convert(varchar(100),E.Value),
       DocumentID$ = null
from   @Row ROW
       left join DynaValue A on A.FaFallID    = ROW.FaFallID and A.GridRowID = ROW.GridRowID and
                                A.DynaFieldID = @FaDokBesprDatum
                                
       left join DynaValue B on B.FaFallID    = ROW.FaFallID and B.GridRowID = ROW.GridRowID and
                                B.DynaFieldID = @FaDokBesprStichwort
       left join DynaValue C on C.FaFallID    = ROW.FaFallID and C.GridRowID = ROW.GridRowID and
                                C.DynaFieldID = @FaDokBesprAutor
       left join DynaValue D on D.FaFallID    = ROW.FaFallID and D.GridRowID = ROW.GridRowID and
                                D.DynaFieldID = @FaDokBesprInhalt
       left join DynaValue E on E.FaFallID    = ROW.FaFallID and E.GridRowID = ROW.GridRowID and
                                E.DynaFieldID = @FaDokBesprThemen

-- Abmachungen

delete @Row

insert @Row (FaFallID,GridRowID)
select distinct FAL.FaFallID,VAL.GridRowID 
from   FaFall FAL
       inner join DynaValue VAL on VAL.FaFallID = FAL.FaFallID
       inner join DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2 and
       FLD.Maskname = 'Fa_Dok_Abmachungen'

declare @FaDokAbmDatum int
declare @FaDokAbmStichwort int
declare @FaDokAbmBespr int
declare @FaDokAbmPerDatum int
declare @FaDokAbmErledi int

set @FaDokAbmDatum     = (select DynaFieldID from DynaField where FieldName = 'FaDokAbmDatum')
set @FaDokAbmStichwort = (select DynaFieldID from DynaField where FieldName = 'FaDokAbmStichwort')
set @FaDokAbmBespr    = (select DynaFieldID from DynaField where FieldName = 'FaDokAbmBespr')
set @FaDokAbmPerDatum    = (select DynaFieldID from DynaField where FieldName = 'FaDokAbmPerDatum')
set @FaDokAbmErledi    = (select DynaFieldID from DynaField where FieldName = 'FaDokAbmErledi')

insert @Result
select Datum       = convert(datetime,A.Value),
       Typ         = 'Abmachung',
       Titel       = convert(varchar(200),B.Value),
       Autor       = 'Frist: ' + convert(varchar,C.Value,104) + 
                     case when convert(bit,E.Value) = 1 then ' (erledigt)' else ' (offen)' end,
       Text        = convert(varchar(7000),D.Value),
       ThemenCodes = null,
       DocumentID$ = null
from   @Row ROW
       left join DynaValue A on A.FaFallID    = ROW.FaFallID and A.GridRowID = ROW.GridRowID and
                                A.DynaFieldID = @FaDokAbmDatum                             
       left join DynaValue B on B.FaFallID    = ROW.FaFallID and B.GridRowID = ROW.GridRowID and
                                B.DynaFieldID = @FaDokAbmStichwort
       left join DynaValue C on C.FaFallID    = ROW.FaFallID and C.GridRowID = ROW.GridRowID and
                                C.DynaFieldID = @FaDokAbmPerDatum
       left join DynaValue D on D.FaFallID    = ROW.FaFallID and D.GridRowID = ROW.GridRowID and
                                D.DynaFieldID = @FaDokAbmBespr
       left join DynaValue E on E.FaFallID    = ROW.FaFallID and E.GridRowID = ROW.GridRowID and
                                E.DynaFieldID = @FaDokAbmErledi

-- Korrespondenz

delete @Row

insert @Row (FaFallID,GridRowID)
select distinct FAL.FaFallID,VAL.GridRowID 
from   FaFall FAL
       inner join DynaValue VAL on VAL.FaFallID = FAL.FaFallID
       inner join DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2 and
       FLD.Maskname = 'Fa_Dok_Korrespondenz'

declare @FaDokKorreDatum int
declare @FaDokKorreStichwort int
declare @FaDokKorreAbsend int
declare @FaDokKorreAddres int
declare @FaDokKorreThemen int
declare @FaDokKorreDokument int

set @FaDokKorreDatum     = (select DynaFieldID from DynaField where FieldName = 'FaDokKorreDatum')
set @FaDokKorreStichwort = (select DynaFieldID from DynaField where FieldName = 'FaDokKorreStichwort')
set @FaDokKorreAbsend    = (select DynaFieldID from DynaField where FieldName = 'FaDokKorreAbsend')
set @FaDokKorreAddres    = (select DynaFieldID from DynaField where FieldName = 'FaDokKorreAddres')
set @FaDokKorreThemen    = (select DynaFieldID from DynaField where FieldName = 'FaDokKorreThemen')
set @FaDokKorreDokument  = (select DynaFieldID from DynaField where FieldName = 'FaDokKorreDokument')

insert @Result
select Datum       = convert(datetime,A.Value),
       Typ         = 'Korrespondenz',
       Titel       = convert(varchar(200),B.Value),
       Autor       = convert(varchar(150),C.Value),
       Text        = 'Adressat: ' + 
                     case when convert(int,D.Value) > 0
                     then (select Name + isNull(', ' + Vorname1,'') 
                           from   DmgPerson 
                           where  DmgPersonID = convert(int,D.Value))
                     else (select OrganisationName + isnull(', ' + ADR.Ort,'') 
                           from   DmgOrganisation ORG
                                  left join DmgAdresse ADR on ADR.DmgAdresseID = ORG.DmgAdresseID 
                           where  DmgOrganisationID = -convert(int,D.Value))
                     end,
       ThemenCodes = convert(varchar(100),E.Value),
       DocumentID$ = convert(int,F.Value)
from   @Row ROW
       left join DynaValue A on A.FaFallID    = ROW.FaFallID and A.GridRowID = ROW.GridRowID and
                                A.DynaFieldID = @FaDokKorreDatum                             
       left join DynaValue B on B.FaFallID    = ROW.FaFallID and B.GridRowID = ROW.GridRowID and
                                B.DynaFieldID = @FaDokKorreStichwort
       left join DynaValue C on C.FaFallID    = ROW.FaFallID and C.GridRowID = ROW.GridRowID and
                                C.DynaFieldID = @FaDokKorreAbsend
       left join DynaValue D on D.FaFallID    = ROW.FaFallID and D.GridRowID = ROW.GridRowID and
                                D.DynaFieldID = @FaDokKorreAddres
       left join DynaValue E on E.FaFallID    = ROW.FaFallID and E.GridRowID = ROW.GridRowID and
                                E.DynaFieldID = @FaDokKorreThemen
       left join DynaValue F on F.FaFallID    = ROW.FaFallID and F.GridRowID = ROW.GridRowID and
                                F.DynaFieldID = @FaDokKorreDokument

-- Zielvereinbarung

delete @Row

insert @Row (FaPhaseID,GridRowID)
select distinct PHA.FaPhaseID,VAL.GridRowID 
from   FaFall FAL
       inner join FaPhase   PHA on PHA.FaFallID = FAL.FaFallID
       inner join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID
       inner join DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2 and
       PHA.FaPhaseCode = 2 and
       FLD.Maskname = 'Fa_Beratung_Beratungsplan_Ziele'

declare @FaZielvereinZielThema int
declare @FaZielvereinZielZiel int
declare @FaAuswertungZielGrad int

set @FaZielvereinZielThema     = (select DynaFieldID from DynaField where FieldName = 'FaZielvereinZielThema')
set @FaZielvereinZielZiel = (select DynaFieldID from DynaField where FieldName = 'FaZielvereinZielZiel')
set @FaAuswertungZielGrad    = (select DynaFieldID from DynaField where FieldName = 'FaAuswertungZielGrad')

insert @Result
select Datum       = PHA.DatumVon,
       Typ         = 'Zielvereinbarung',
       Titel       = convert(varchar(300),B.Value),
       Autor       = USR.LastName + isNull(', ' + USR.FirstName,''),
       Text        = case when convert(int,C.Value) is not null
                     then 'Auswertung: ' + dbo.fnLOVText('FaZielErreichungsgrad',convert(int,C.Value))
                     else 'noch nicht ausgewertet'
                     end,
       ThemenCodes = convert(varchar(10),A.Value),
       DocumentID$ = null
from   @Row ROW
       left join DynaValue A on A.FaPhaseID    = ROW.FaPhaseID and A.GridRowID = ROW.GridRowID and
                                A.DynaFieldID = @FaZielvereinZielThema                             
       left join DynaValue B on B.FaPhaseID    = ROW.FaPhaseID and B.GridRowID = ROW.GridRowID and
                                B.DynaFieldID = @FaZielvereinZielZiel
       left join DynaValue C on C.FaPhaseID    = ROW.FaPhaseID and C.GridRowID = ROW.GridRowID and
                                C.DynaFieldID = @FaAuswertungZielGrad
       inner join FaPhase PHA on PHA.FaPhaseID = ROW.FaPhaseID
       left  join XUser   USR on USR.UserID = PHA.UserID

-- Falleröffnung

insert @Result
select Datum       = FAL.DatumVon,
       Typ         = 'Fall',
       Titel       = 'Eröffnung',
       Autor       = USR.LastName + isNull(', ' + USR.FirstName,''),
       Text        = null,
       ThemenCodes = null,
       DocumentID$ = null
from   FaFall FAL
       inner join XUser USR on USR.UserID = FAL.UserID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2

-- Fallabschluss

insert @Result
select Datum       = FAL.DatumBis,
       Typ         = 'Fall',
       Titel       = 'Abschluss',
       Autor       = USR.LastName + isNull(', ' + USR.FirstName,''),
       Text        = null,
       ThemenCodes = null,
       DocumentID$ = null
from   FaFall FAL
       inner join XUser USR on USR.UserID = FAL.UserID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2 and
       FAL.DatumBis is not null

-- Phaseneröffnung

insert @Result
select Datum       = PHA.DatumVon,
       Typ         = 'Phase',
       Titel       = case FaPhaseCode
                     when 1 then 'Eröffnung Intake'
                     when 2 then 'Eröffnung Beratung'
                     end,
       Autor       = USR.LastName + isNull(', ' + USR.FirstName,''),
       Text        = null,
       ThemenCodes = null,
       DocumentID$ = null
from   FaFall FAL
       inner join FaPhase PHA on PHA.FaFallID = FAL.FaFallID
       left  join XUser   USR on USR.UserID = PHA.UserID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2

-- Phasenabschluss

insert @Result
select Datum       = PHA.DatumBis,
       Typ         = 'Phase',
       Titel       = case FaPhaseCode
                     when 1 then 'Abschluss Intake'
                     when 2 then 'Abschluss Beratung'
                     end,
       Autor       = USR.LastName + isNull(', ' + USR.FirstName,''),
       Text        = null,
       ThemenCodes = null,
       DocumentID$ = null
from   FaFall FAL
       inner join FaPhase PHA on PHA.FaFallID = FAL.FaFallID
       left  join XUser   USR on USR.UserID = PHA.UserID
where  FAL.DmgPersonID = @DmgPersonID and
       FAL.ModulCode = 2 and
       PHA.DatumBis is not null

-- Output

select RES.*,
       Tage   = datediff(d,getdate(),Datum),
       Themen = dbo.fnLOVTextListe('FaThema',ThemenCodes)
from   @Result RES
order by Datum, Typ
GO