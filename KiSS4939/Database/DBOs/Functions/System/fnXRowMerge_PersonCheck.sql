SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXRowMerge_PersonCheck;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Zum überprüfen ob zwei Personen zusammengeführt werden können
    @BaPersonID_A: BaPersonID der erste Person
    @BaPersonID_B: BaPersonID der zweite Person
	@BaPersonID_ToDelete: BaPersonID der zu löschenden Person
  -
  RETURNS: Liste von Fehlern die vor der Zusammenführung angeschaut werden müssen
=================================================================================================
  TEST:    SELECT * FROM dbo.fnXRowMerge_PersonCheck(1, 2, 1, NULL);
           SELECT * FROM dbo.fnXRowMerge_PersonCheck(69250, 69570, 1, 69570);
           SELECT * FROM dbo.fnXRowMerge_PersonCheck(73153, 73157, 1, 73153);
=================================================================================================*/

CREATE FUNCTION dbo.fnXRowMerge_PersonCheck
(
  @BaPersonID_A INT,
  @BaPersonID_B INT,
  @LanguageCode INT,
  @BaPersonID_ToDelete INT
)
RETURNS @Result TABLE
(
  ID INT NOT NULL IDENTITY(1, 1),
  TableName VARCHAR(255) NOT NULL,
  Problem VARCHAR(200) NOT NULL,
  Solution VARCHAR(MAX) NOT NULL,
  JumpToPathA VARCHAR(1500),
  JumpToPathB VARCHAR(1500),
  SelectDeleteOne BIT NOT NULL
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- Declare and init vars
  -----------------------------------------------------------------------------
  DECLARE @BaPersonID_A_Str VARCHAR(50);
  DECLARE @BaPersonID_B_Str VARCHAR(50);
  
  SET @BaPersonID_A_Str = CONVERT(VARCHAR(50), @BaPersonID_A);
  SET @BaPersonID_B_Str = CONVERT(VARCHAR(50), @BaPersonID_B);
  
  -----------------------------------------------------------------------------
  -- BaAdresse
  -----------------------------------------------------------------------------
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT 
      TableName       = 'BaAdresse',	  
      Problem         = ISNULL(dbo.fnGetMLTextFromName('fnXRowMerge_PersonCheck', 'BaAdresseProblem', @LanguageCode),'Überschneidung der Adressen'),
      Solution        = ISNULL(dbo.fnGetMLTextFromName('fnXRowMerge_PersonCheck', 'UeberschneidungBeheben', @LanguageCode),'Überschneidung beheben: ') +
                        'Person A ' + @BaPersonID_A_Str + ' (' + ISNULL(CONVERT(VARCHAR(MAX), ADR_A.DatumVon, 104), '') + '-' + ISNULL(CONVERT(VARCHAR(MAX), ADR_A.DatumBis, 104), '') + ') und ' +
                        'Person B ' + @BaPersonID_B_Str + ' (' + ISNULL(CONVERT(VARCHAR(MAX), ADR_B.DatumVon, 104), '') + '-' + ISNULL(CONVERT(VARCHAR(MAX), ADR_B.DatumBis, 104), '') + ')',
      JumpToPathA     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_A_Str + ';TreeNodeID=P' + @BaPersonID_A_Str + ';Tab=Adressen;BaAdresseID=' + CONVERT(VARCHAR(MAX), ADR_A.BaAdresseID),
      JumpToPathB     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_B_Str + ';TreeNodeID=P' + @BaPersonID_B_Str + ';Tab=Adressen;BaAdresseID=' + CONVERT(VARCHAR(MAX), ADR_B.BaAdresseID),
      SelectDeleteOne = 0
    FROM dbo.BaAdresse         ADR_A WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaAdresse ADR_B WITH (READUNCOMMITTED) ON ADR_B.BaPersonID = @BaPersonID_B
                                                           AND ADR_B.AdresseCode = ADR_A.AdresseCode
                                                           AND ISNULL(ADR_B.DatumVon, '17530101') < ISNULL(ADR_A.DatumBis, '99991231')
                                                           AND ISNULL(ADR_B.DatumBis, '99991231') > ISNULL(ADR_A.DatumVon, '17530101')
    WHERE ADR_A.BaPersonID = @BaPersonID_A;
  
  -----------------------------------------------------------------------------
  -- BaArbeitAusbildung
  -----------------------------------------------------------------------------
  /* -- TODO: Here we need more help for the user, otherwise there will be new support-tickets....
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT 
      TableName       = 'BaArbeitAusbildung',
      Problem         = 'Doppelte Definition der Arbeitsdaten',
      Solution        = 'Auswahl des zu löschenden Datensatzes bei Person A ' + @BaPersonID_A_Str + ' oder Person B ' + @BaPersonID_B_Str,
      JumpToPathA     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_A_Str + ';TreeNodeID=P' + @BaPersonID_A_Str + '/CtlArbeit',
      JumpToPathB     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_B_Str + ';TreeNodeID=P' + @BaPersonID_B_Str + '/CtlArbeit',
      SelectDeleteOne = 1
    FROM dbo.BaArbeitAusbildung ARA_A WITH (READUNCOMMITTED)
    WHERE ARA_A.BaPersonID = @BaPersonID_A
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.BaArbeitAusbildung ARA_B WITH (READUNCOMMITTED)
                  WHERE ARA_B.BaPersonID = @BaPersonID_B);
  */
  
  -----------------------------------------------------------------------------
  -- BaGesundheit
  -----------------------------------------------------------------------------
  /* -- TODO: Here we need more help for the user, otherwise there will be new support-tickets....
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT 
      TableName       = 'BaGesundheit',
      Problem         = 'Doppelte Definition der Gesundheitsdaten',
      Solution        = 'Auswahl des zu löschenden Datensatzes bei Person A ' + @BaPersonID_A_Str + ' oder Person B ' + @BaPersonID_B_Str,
      JumpToPathA     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_A_Str + ';TreeNodeID=P' + @BaPersonID_A_Str + '/CtlGesundheit',
      JumpToPathB     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_B_Str + ';TreeNodeID=P' + @BaPersonID_B_Str + '/CtlGesundheit',
      SelectDeleteOne = 1
    FROM dbo.BaGesundheit GES_A WITH (READUNCOMMITTED)
    WHERE GES_A.BaPersonID = @BaPersonID_A
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.BaGesundheit GES_B WITH (READUNCOMMITTED)
                  WHERE GES_B.BaPersonID = @BaPersonID_B);
  */
  
  -----------------------------------------------------------------------------
  -- BaMietvertrag
  -----------------------------------------------------------------------------
   -- TODO: Here we need more help for the user, otherwise there will be new support-tickets....
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT 
      TableName       = 'BaMietvertrag',
      Problem         = 'Doppelte Definition der Mietvertragsdaten',
      Solution        = 'Auswahl des zu löschenden Datensatzes bei Person A ' + @BaPersonID_A_Str + ' oder Person B ' + @BaPersonID_B_Str,
      JumpToPathA     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_A_Str + ';TreeNodeID=CtlBaHaushalt',
      JumpToPathB     = 'ClassName=FrmFall;ModulID=1;BaPersonID=' + @BaPersonID_B_Str + ';TreeNodeID=CtlBaHaushalt',
      SelectDeleteOne = 1
    FROM dbo.BaMietvertrag MVT_A WITH (READUNCOMMITTED)
    WHERE MVT_A.BaPersonID = @BaPersonID_A 
	  AND (GETDATE() BETWEEN ISNULL(MVT_A.DatumVon, '17530101') AND ISNULL(MVT_A.DatumBis, '99991231'))
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.BaMietvertrag MVT_B WITH (READUNCOMMITTED)
                  WHERE MVT_B.BaPersonID = @BaPersonID_B
				    AND (GETDATE() BETWEEN MVT_B.DatumVon AND ISNULL(MVT_B.DatumBis, '99991231')));
  
  
  -----------------------------------------------------------------------------
  -- BFSDossierPerson
  -----------------------------------------------------------------------------
  /* -- TODO: Here we need more help for the user, otherwise there will be new support-tickets....
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT
      TableName       = 'BFSDossierPerson',
      Problem         = 'Doppelte Definition des BFS-Dossiers',
      Solution        = 'Manuelle Bereinigung auf der Datenbank, Zusammenführen nicht einfach möglich.',
      JumpToPathA     = 'ClassName=FrmSostat;SubClassName=CtlBfsDossiers;BaPersonID=' + @BaPersonID_A_Str,
      JumpToPathB     = 'ClassName=FrmSostat;SubClassName=CtlBfsDossiers;BaPersonID=' + @BaPersonID_B_Str,
      SelectDeleteOne = 0
    FROM dbo.BFSDossierPerson DOP_A WITH (READUNCOMMITTED)
    WHERE DOP_A.BaPersonID = @BaPersonID_A
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.BFSDossierPerson DOP_B WITH (READUNCOMMITTED)
                  WHERE DOP_B.BaPersonID = @BaPersonID_B);
  */
  
  -----------------------------------------------------------------------------
  -- FaLeistung
  -----------------------------------------------------------------------------
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT
      TableName       = 'FaLeistung',
      Problem         = 'Überschneidung der offenen Leistungen',
      Solution        = 'Überschneidung beheben: ' +
                        'Leistung "' + MDL.Name + '" (' + CONVERT(VARCHAR, LEI_A.DatumVon, 104) + ISNULL(' - ' + CONVERT(VARCHAR, LEI_A.DatumBis, 104), '') + ') ',
      JumpToPathA     = 'ClassName=FrmFall;ModulID=' + CONVERT(VARCHAR(50), LEI_A.ModulID) + ';BaPersonID=' + @BaPersonID_A_Str + ';Action=ShowFall',
      JumpToPathB     = 'ClassName=FrmFall;ModulID=' + CONVERT(VARCHAR(50), LEI_A.ModulID) + ';BaPersonID=' + @BaPersonID_B_Str + ';Action=ShowFall',
      SelectDeleteOne = 0
    FROM dbo.FaLeistung     LEI_A WITH (READUNCOMMITTED)
      INNER JOIN dbo.XModul MDL   WITH (READUNCOMMITTED) ON MDL.ModulID = LEI_A.ModulID
    WHERE LEI_A.BaPersonID = @BaPersonID_A
      AND LEI_A.DatumBis IS NULL                                                            -- A: only open (?)
      AND LEI_A.FaProzessCode <> 700                                                        -- A+B: not KA-Allgemein
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.FaLeistung LEI_B WITH (READUNCOMMITTED)
                  WHERE LEI_B.BaPersonID = @BaPersonID_B
                    AND LEI_B.ModulID = LEI_A.ModulID                                       -- B: same module!
                    AND ISNULL(LEI_B.FaProzessCode, -1) = ISNULL(LEI_A.FaProzessCode, -1)   -- B: same process code (?)
                    AND LEI_B.DatumBis IS NULL);                                            -- B: only open (?)
  

--------------------------------------------------------------------------------------------------------------
-- Ist Person A in einem Finanzplan unterstützt
-- Prüfung nur ausführen, wenn @BaPersonID_ToDelete gesetzt ist
--------------------------------------------------------------------------------------------------------------
  IF @BaPersonID_ToDelete IS NOT NULL 
    BEGIN
	  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
		SELECT TOP 1
		  TableName       = 'BgFinanzplan_BaPerson',
		  Problem         = 'Die zu löschende Person wurde in einem Finanzplan unterstützt',
		  Solution        = 'Eine Migration ist daher nicht möglich.' ,
		  JumpToPathA     = CASE WHEN FPP.IstUnterstuetzt = 1 THEN 'ClassName=FrmFall;ModulID=3' + ';BaPersonID=' + CONVERT(VARCHAR(MAX),LEI_A.BaPersonID) + ';TreeNodeID=CtlWhFinanzplan'+ CONVERT(VARCHAR(MAX),FPL.BgFinanzplanID)+'\BBG'+CONVERT(VARCHAR(MAX),BDG.BgBudgetID)+';Action=JumpToPath' ELSE NULL END,
		  JumpToPathB     = CASE WHEN FPP.IstUnterstuetzt = 1 THEN 'ClassName=FrmFall;ModulID=3' + ';BaPersonID=' + @BaPersonID_B_Str + ';Action=JumpToPath'  ELSE NULL END,
		  SelectDeleteOne = 0
	  FROM dbo.FaLeistung                  LEI_A WITH (READUNCOMMITTED)
	  INNER JOIN dbo.BgFinanzplan          FPL WITH (READUNCOMMITTED) ON LEI_A.FaLeistungID = FPL.FaLeistungID
	  INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
	  INNER JOIN dbo.BgBudget              BDG WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
	  WHERE LEI_A.Modulid = 3
	  AND FPP.IstUnterstuetzt = 1 
	  AND FPP.BaPersonID = @BaPersonID_ToDelete 	  
    END

  -----------------------------------------------------------------------------
  -- KaArbeitsrapport
  -----------------------------------------------------------------------------
  INSERT INTO @Result (TableName, Problem, Solution, JumpToPathA, JumpToPathB, SelectDeleteOne)
    SELECT
      TableName       = 'KaArbeitsrapport',
      Problem         = 'Doppelte Definition Präsenzzeit',
      Solution        = 'Auswahl des zu löschenden Datensatzes bei Person A ' + @BaPersonID_A_Str + ' oder Person B ' + @BaPersonID_B_Str + ' (Datum ' + CONVERT(VARCHAR, KAR_A.Datum, 104) + ')',
      JumpToPathA     = 'ClassName=FrmKaPraesenzzeit;BaPersonID=' + @BaPersonID_A_Str,
      JumpToPathB     = 'ClassName=FrmKaPraesenzzeit;BaPersonID=' + @BaPersonID_B_Str,
      SelectDeleteOne = 1
    FROM dbo.KaArbeitsrapport KAR_A WITH (READUNCOMMITTED)
    WHERE KAR_A.BaPersonID = @BaPersonID_A
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.KaArbeitsrapport KAR_B WITH (READUNCOMMITTED)
                  WHERE KAR_B.BaPersonID = @BaPersonID_B
                    AND KAR_B.Datum = KAR_A.Datum);
  
  -----------------------------------------------------------------------------
  -- TODO: go on with more checks...
  -- see: onenote:///W:\20_Personalmanagement\21_Organisation\21.3_KiSS-Team\OneNote\KiSS\32_Tasks.one#Sprint%206&section-id={017FDC86-F3D3-4B93-85EA-1F973063D7CA}&page-id={FE3AFCAE-873C-4864-91E4-CE65C125CCA6}&end
  -----------------------------------------------------------------------------
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO