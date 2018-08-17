SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaFillAMMBesch
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKaFillAMMBesch.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:22 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKaFillAMMBesch.sql $
 * 
 * 3     25.06.09 11:37 Ckaeser
 * Alter2Create
 * 
 * 2     2.12.08 9:22 Lgreulich
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spKaFillAMMBesch
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spKaFillAMMBesch
( @Monat    int,
  @Jahr     int)
AS BEGIN


-- Delete first the data in AMMBesch which are not printed yet for the act month and year!!
  DELETE FROM KaAmmBesch
  WHERE Monat = @Monat
  AND Jahr = @Jahr
  AND gedrucktFlag = CONVERT(bit, 0)

-- Delete all persons in AMMBesch, which no more exists in DmgPerson
  DELETE AMM
  FROM KaAmmBesch AMM
  WHERE NOT EXISTS (SELECT * FROM BaPerson WHERE BaPersonID = AMM.BaPersonID)

  DECLARE @tmp TABLE (
  ID          int identity,
  BaPersonID  int,
  UserID      int,
  KaEinsatzID int,
  ProfilCode  int,
  KaEinsatzplatzID int,
  DatumVon datetime,
  DatumBis datetime,
  AnweisungCode int,
  APVNr varchar(200)
  primary key (ID))

  INSERT @tmp (BaPersonID, UserID, KaEinsatzID, ProfilCode, KaEinsatzplatzID, DatumVon, DatumBis, AnweisungCode, APVNr )
  SELECT KAE.BaPersonID, FAL.UserID, KAE.KaEinsatzID, KEP.ProfilCode, KAE.KaEinsatzplatzID, KAE.DatumVon, IsNull(AUS.AustrittDatum, KAE.DatumBis), KAE.AnweisungCode, dbo.fnLOVText('KaAPV', KEP.APVCode)
  FROM 	 dbo.KaEinsatz KAE WITH (READUNCOMMITTED) 
     LEFT JOIN dbo.FaLeistung FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = KAE.BaPersonID AND ModulID = 7 AND FaProzessCode = 700
     LEFT JOIN dbo.KaEinsatzplatz2 KEP WITH (READUNCOMMITTED) ON KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
     OUTER APPLY dbo.fnKaGetAustrittDatumCode(KAE.FaLeistungID, KAE.KaEinsatzID) AUS
  WHERE  KAE.APVZusatzCode IN (1,2)
  AND 	 KAE.AnweisungCode in (2,3)
  AND	 ((CONVERT(datetime, KAE.DatumVon, 104) < DateAdd(month, 1, CONVERT(datetime, '01.' + CONVERT(varchar, @Monat) + '.' + CONVERT(varchar, @Jahr), 104))
  	 AND CONVERT(datetime, KAE.DatumBis, 104) >= CONVERT(datetime, '01.' + CONVERT(varchar, @Monat) + '.' + CONVERT(varchar, @Jahr), 104))
  	 OR (CONVERT(datetime, KAE.DatumVon, 104) >= CONVERT(datetime, '01.' + CONVERT(varchar, @Monat) + '.' + CONVERT(varchar, @Jahr), 104)
  	 AND CONVERT(datetime, KAE.DatumBis, 104) < DateAdd(month, 1, CONVERT(datetime, '01.' + CONVERT(varchar, @Monat) + '.' + CONVERT(varchar, @Jahr), 104))))
  AND	 (AUS.AustrittDatum IS NULL OR CONVERT(datetime, AUS.AustrittDatum, 104) >= CONVERT(datetime, '01.' + CONVERT(varchar, @Monat) + '.' + CONVERT(varchar, @Jahr), 104))
  ORDER BY KAE.BaPersonID, KAE.DatumVon ASC, dbo.fnLOVText('KaAPV', KEP.APVCode), KAE.AnweisungCode

  DECLARE @tbaPersonID INT
  DECLARE @tkaEinsatzID INT
  DECLARE @tprofilCode INT
  DECLARE @tkaEinsatzplatzID INT
  DECLARE @tdatumVon datetime
  DECLARE @tdatumBis datetime

  DECLARE cTmp CURSOR FOR
     SELECT BaPersonID, KaEinsatzID, ProfilCode, KaEinsatzplatzID, DatumVon, DatumBis
     FROM dbo.KaAmmBesch WITH (READUNCOMMITTED) 
     WHERE gedrucktFlag = 1
     AND Monat = @Monat
     AND Jahr = @Jahr
  OPEN cTmp

  FETCH NEXT FROM cTmp INTO  @tbaPersonID, @tkaEinsatzID, @tprofilCode, @tkaEinsatzplatzID, @tdatumVon, @tdatumBis

  WHILE (@@FETCH_STATUS=0) BEGIN

     DELETE FROM @tmp
		WHERE BaPersonID = @tbaPersonID
		--AND KaEinsatzID = @tkaEinsatzID
		AND ProfilCode = @tprofilCode
		AND KaEinsatzplatzID = @tkaEinsatzplatzID
		AND (DatumBis = @tdatumBis OR DatumVon = @tdatumVon)

     FETCH NEXT FROM cTmp INTO  @tbaPersonID, @tkaEinsatzID, @tprofilCode, @tkaEinsatzplatzID, @tdatumVon, @tdatumBis
  END
  CLOSE cTmp
  DEALLOCATE cTmp

  DECLARE @BaPersonID INT
  DECLARE @UserID INT
  DECLARE @KaEinsatzID INT
  DECLARE @ProfilCode INT
  DECLARE @KaEinsatzplatzID INT
  DECLARE @DatumVon datetime
  DECLARE @DatumBis datetime
  DECLARE @AnweisungCode INT
  DECLARE @apvNr varchar(200)

  DECLARE @prev_baPersonID INT
  DECLARE @prev_userID INT
  DECLARE @prev_kaEinsatzID INT
  DECLARE @prev_profilCode INT
  DECLARE @prev_kaEinsatzplatzID INT
  DECLARE @prev_datumVon datetime
  DECLARE @prev_datumBis datetime
  DECLARE @prev_anweisungCode INT
  DECLARE @prev_apvNr varchar(200)

  SET @prev_baPersonID = -1
  SET @prev_userID = -1
  SET @prev_kaEinsatzID = -1
  SET @prev_profilCode = -1
  SET @prev_kaEinsatzplatzID = -1
  SET @prev_datumVon = NULL
  SET @prev_datumBis = NULL
  SET @prev_anweisungCode = -1
  SET @prev_apvNr = ''

  DECLARE cur CURSOR FOR
     SELECT BaPersonID, UserID, KaEinsatzID, ProfilCode, KaEinsatzplatzID, DatumVon, DatumBis, AnweisungCode, APVNr
     FROM @tmp
  OPEN cur

  FETCH NEXT FROM cur INTO  @BaPersonID, @UserID, @KaEinsatzID, @ProfilCode, @KaEinsatzplatzID, @DatumVon, @DatumBis, @AnweisungCode, @apvNr
  WHILE (@@FETCH_STATUS=0) BEGIN

    IF (@BaPersonID = @prev_baPersonID AND @apvNr = @prev_apvNr AND @AnweisungCode = 3) BEGIN
       -- Update row with new date to!
       UPDATE KaAmmBesch
       SET DatumBis = @DatumBis, KaEinsatzID = @KaEinsatzID
       WHERE BaPersonID = @BaPersonID
       AND KaEinsatzID = @prev_kaEinsatzID
       AND Monat = @Monat
       AND Jahr = @Jahr
    END ELSE BEGIN
       -- Insert the data which not match with the data already exists for the act month and year!!
       INSERT INTO KaAmmBesch (BaPersonID, ZustaendigKaID, Monat, Jahr, KaEinsatzID, ProfilCode, KaEinsatzplatzID, DatumVon, DatumBis)
       VALUES (@BaPersonID, @UserID, @Monat, @Jahr, @KaEinsatzID, @ProfilCode, @KaEinsatzplatzID, @DatumVon, @DatumBis)
    END

  SET @prev_baPersonID = @BaPersonID
  SET @prev_userID = @UserID
  SET @prev_kaEinsatzID = @KaEinsatzID
  SET @prev_profilCode = @ProfilCode
  SET @prev_kaEinsatzplatzID = @KaEinsatzplatzID
  SET @prev_datumVon = @DatumVon
  SET @prev_datumBis = @DatumBis
  SET @prev_anweisungCode = @AnweisungCode
  SET @prev_apvNr = @apvNr

  FETCH NEXT FROM cur INTO  @BaPersonID, @UserID, @KaEinsatzID, @ProfilCode, @KaEinsatzplatzID, @DatumVon, @DatumBis, @AnweisungCode, @apvNr
  END
  CLOSE cur
  DEALLOCATE cur

END
GO