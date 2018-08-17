SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spVISSyncWithKiSS
GO
/*===============================================================================================
  $Revision: 25 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Fall vom KiSS mit VIS synchronisieren (ZH-Spezifisch).
    @FaLeistungID: VM-Leistung, die mit der entsprechenden VIS-Massnahme via VIS_VormschID synchronisiert werden soll.
                   Falls NULL, dann werden alle VM-Leistungen synchronisiert.
  -
  RETURNS: -
=================================================================================================
  TEST:    EXEC dbo.spVISSyncWithKiSS @FaLeistungID;
=================================================================================================*/

CREATE PROCEDURE dbo.spVISSyncWithKiSS
(
  @FaLeistungID INT = NULL
)
AS BEGIN
  --------------------------------------------------------------------------------------------------------------------
  -- Update der Massnahmen aus VIS
  ------------------------------------------------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: Update der Massnahmen aus VIS');
  UPDATE MAS
    SET DatumVon                       = VMAS.BESCH_A_ED,
        DatumBis                       = VMAS.BESCH_A_AD,
        ZGB                            = VMAS.Massnahme,
        Mandatstyp                     = VMAS.Mandatstyp,
        Waisenrat                      = ISNULL((SELECT ABT.Abteilung + ': ' + REPLACE(REPLACE(ABT.Waisenrat, CHAR(13), ' '), CHAR(10), ' ') + ', Tel ' + ABT.Telefon
                                                 FROM dbo.vwVIS_ABTEILUNG ABT WITH (READUNCOMMITTED)
                                                 WHERE id = (SELECT DepartmentId
                                                             FROM dbo.vwVIS_DOSSIER VVD WITH (READUNCOMMITTED)
                                                             WHERE id = VMAS.DossierId)), ''),
        VIS_FallNr                     = CONVERT(INT, VMAS.FALL_NR),
        VIS_DossierId                  = VMAS.DossierId,
        VIS_VormschID                  = VMAS.Vormsch_ID,
        VIS_ArrangementId              = VMAS.ArrangementId,
        VIS_ArrangementId_Neurechtlich = VMAS.ArrangementId_Neurechtlich,
        IstNeurechtlich                = VMAS.IstNeurechtlich
  FROM dbo.VmMassnahme MAS
    CROSS APPLY (SELECT *
                 FROM dbo.vwVIS_MASSNAHMEN VVM WITH (READUNCOMMITTED)
                 WHERE ArrangementId = MAS.VIS_ArrangementId) VMAS
  WHERE (@FaLeistungID IS NULL OR MAS.FaLeistungID = @FaLeistungID);
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Massnahmen aktualisiert');

  --================================================================================================================
  -- Berichtsperioden Synchronisieren (Abgleichschlüssel ist VIS_BK_ID):
  -- 1. im VIS überführte Berichte die im KiSS bereits vorhanden sind auf die korrekte Massnahme umhängen
  -- 2. Noch nicht vorhandene Berichte von VIS nach KiSS kopieren
  -- 3. Vorhandene Berichte in KiSS updaten
  --================================================================================================================
  ------------------------------------------------------------------------------------------------------------------
  -- Berichtsperioden Synchronisieren (Abgleichschlüssel ist VIS_BK_ID):
  -- 1. im VIS überführte Berichte die im KiSS bereits vorhanden sind auf die korrekte Massnahme umhängen
  ------------------------------------------------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: 1. im VIS überführte Berichte die im KiSS bereits vorhanden sind auf die korrekte Massnahme umhängen');
  ;WITH BerichtCte AS
  (
    SELECT DISTINCT 
      VmMassnahmeID = MAS.VmMassnahmeID,
      BK_ID         = VBER.BK_ID,
      VmBerichtID   = BER.VmBerichtID,
      VmMassnahmeID_Bericht = BER.VmMassnahmeID
    FROM dbo.VmMassnahme           MAS 
      INNER JOIN dbo.vwVIS_BERICHT VBER ON VBER.ArrangementId = MAS.VIS_ArrangementId
      LEFT  JOIN dbo.VmBericht     BER  ON BER.VIS_BK_ID = VBER.BK_ID
    WHERE (@FaLeistungID IS NULL OR MAS.FaLeistungID = @FaLeistungID)
      AND BER.VmMassnahmeID <> MAS.VmMassnahmeID
  )
  
  UPDATE BER
    SET VmMassnahmeID = CTE.VmMassnahmeID
  FROM BerichtCte CTE
    INNER JOIN dbo.VmBericht BER ON BER.VmBerichtID = CTE.VmBerichtID;
    
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte umgehängt');


  ------------------------------------------------------------------------------------------------------------------
  -- Berichtsperioden Synchronisieren (Abgleichschlüssel ist VIS_BK_ID)
  -- 2. Noch nicht vorhandene Berichte von VIS nach KiSS kopieren
  ------------------------------------------------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: 2. Noch nicht vorhandene Berichte von VIS nach KiSS kopieren');
  ;WITH BerichtCte AS
  (
    SELECT DISTINCT 
      VmMassnahmeID = MAS.VmMassnahmeID,
      BK_ID         = VBER.BK_ID
    FROM dbo.VmMassnahme           MAS 
      INNER JOIN dbo.vwVIS_BERICHT VBER ON VBER.ArrangementId = MAS.VIS_ArrangementId
      LEFT  JOIN dbo.VmBericht     BER  ON BER.VIS_BK_ID = VBER.BK_ID
    WHERE (@FaLeistungID IS NULL OR MAS.FaLeistungID = @FaLeistungID)
      AND BER.VmBerichtID IS NULL -- der Bericht ist noch nicht im KiSS vorhanden
  )
  -- Erstelle den Berichts-Eintrag (Kopiere die Daten aus VIS)
  INSERT INTO dbo.VmBericht (VmMassnahmeID, VIS_BK_ID, VIS_MandateId, Berichtsart, DatumVon, DatumBis, 
                             MandatsTraegerName, DatumMahnung1, DatumMahnung2, DatumMahnung3, 
                             DatumGenehmigung1, DatumGenehmigung2, DatumFristerstreckung, IstAktiv,
                             VIS_Berichtsnummer)
    SELECT 
      VmMassnahmeID         = CTE.VmMassnahmeID,
      VIS_BK_ID             = CTE.BK_ID,
      VIS_MandateId         = VBER.MandateId,
      Berichtsart           = VBER.T1,
      DatumVon              = VBER.BERICHT_VON,
      DatumBis              = VBER.BERICHT_PER,
      MandatsTraegerName    = NULL, -- wird im Update gemacht
      DatumMahnung1         = VBER.MAHNUNG1,
      DatumMahnung2         = VBER.MAHNUNG2,
      DatumMahnung3         = VBER.MAHNUNG3,
      DatumGenehmigung1     = NULL, -- wird im Update gemacht
      DatumGenehmigung2     = VBER.RB_SB_BRZ,
      DatumFristerstreckung = VBER.FRISTERSTRECKUNG,
      IstAktiv              = VBER.IstAktiv,
      VIS_Berichtsnummer    = VBER.MAND_ID
    FROM BerichtCte                CTE
      INNER JOIN dbo.vwVIS_BERICHT VBER ON VBER.BK_ID = CTE.BK_ID

  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' neue Berichte importiert');

  ------------------------------------------------------------------------------------------------------------------
  -- Berichtsperioden Synchronisieren (Abgleichschlüssel ist VIS_BK_ID)
  -- 3. Vorhandene Berichte in KiSS updaten
  ------------------------------------------------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: 3. Vorhandene Berichte in KiSS updaten');
  DECLARE @TmpBericht TABLE
  (
    ID                    INT IDENTITY(1, 1) NOT NULL,
    VIS_MandateId         UNIQUEIDENTIFIER,
    DatumBerichtsTermin   DATETIME,
    Berichtsart           VARCHAR(255),
    DatumVon              DATETIME,
    DatumBis              DATETIME,
    DatumMahnung1         DATETIME,
    DatumMahnung2         DATETIME,
    DatumMahnung3         DATETIME,
    DatumGenehmigung1     DATETIME,
    DatumGenehmigung2     DATETIME,
    DatumFristerstreckung DATETIME,
    MandatsTraegerName    VARCHAR(512),
    IstAktiv              BIT,
    VmBerichtID           INT,
    VIS_Berichtsnummer    INT
  );

  INSERT INTO @TmpBericht (VIS_MandateId, DatumBerichtsTermin, Berichtsart, DatumVon, DatumBis, DatumMahnung1, DatumMahnung2, DatumMahnung3, DatumGenehmigung1, DatumGenehmigung2, DatumFristerstreckung, MandatsTraegerName, IstAktiv, VmBerichtID, VIS_Berichtsnummer)
    SELECT VIS_MandateId         = VBER.MandateId,
           DatumBerichtsTermin   = VBER.BERICHTSTERMIN,
           Berichtsart           = VBER.T1,
           DatumVon              = VBER.BERICHT_VON,
           DatumBis              = VBER.BERICHT_PER,
           DatumMahnung1         = VBER.MAHNUNG1,
           DatumMahnung2         = VBER.MAHNUNG2,
           DatumMahnung3         = VBER.MAHNUNG3,
           DatumGenehmigung1     = CASE WHEN VBER.RB_SB_BRZ IS NULL
                                     THEN NULL
                                     ELSE (SELECT GenemigungVB
                                           FROM dbo.vwVIS_OPERATION VVO WITH (READUNCOMMITTED)
                                           WHERE MandateReportInfoId = VBER.BK_ID)
                                   END,
           DatumGenehmigung2     = VBER.RB_SB_BRZ,
           DatumFristerstreckung = VBER.FRISTERSTRECKUNG,
           MandatsTraegerName    = VMT.NameVorname,
           IstAktiv              = VBER.IstAktiv, 
           VmBerichtID           = BER.VmBerichtID,
           VIS_Berichtsnummer    = VBER.MAND_ID
    FROM dbo.VmBericht                           BER
    INNER JOIN dbo.VmMassnahme                   MAS  ON MAS.VmMassnahmeID = BER.VmMassnahmeID
      INNER JOIN dbo.vwVIS_BERICHT               VBER ON VBER.BK_ID = BER.VIS_BK_ID
      INNER JOIN dbo.vwVIS_MANDATSTRAEGER_Simple VMT  ON VMT.MandateId = VBER.MandateId
  WHERE (@FaLeistungID IS NULL OR MAS.FaLeistungID = @FaLeistungID);

  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: VIS-Berichte laden');

  UPDATE BER
    SET VIS_MandateId         = TMP.VIS_MandateId,
        DatumBerichtsTermin   = TMP.DatumBerichtsTermin,
        Berichtsart           = TMP.Berichtsart,
        DatumVon              = TMP.DatumVon,
        DatumBis              = TMP.DatumBis, 
        DatumMahnung1         = TMP.DatumMahnung1,
        DatumMahnung2         = TMP.DatumMahnung2,
        DatumMahnung3         = TMP.DatumMahnung3,
        DatumGenehmigung1     = TMP.DatumGenehmigung1,
        DatumGenehmigung2     = TMP.DatumGenehmigung2,
        DatumFristerstreckung = TMP.DatumFristerstreckung,
        IstAktiv              = TMP.IstAktiv,
        MandatsTraegerName    = TMP.MandatsTraegerName,
        VIS_Berichtsnummer    = TMP.VIS_Berichtsnummer
  FROM @TmpBericht TMP
    INNER JOIN dbo.VmBericht BER ON BER.VmBerichtID = TMP.VmBerichtID;
  PRINT (CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) + ' Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte aktualisiert');
END;
