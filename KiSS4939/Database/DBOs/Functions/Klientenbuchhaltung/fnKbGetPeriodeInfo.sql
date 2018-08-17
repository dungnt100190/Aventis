SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKbGetPeriodeInfo;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get periode string from KbPeriodeID
    @KbPeriodeID:  The id of the periode within KbPeriode
    @Mode:         The mode to display data
                   - 'klibu': "Mandant: '<Mandant>' (ID: <KbMandantID>), '<DatumVon>'-'<DatumBis>' (ID: <KbPeriodeID>)"
                   - 'wv':    "'<DatumVon>'-'<DatumBis>' (ID: <KbPeriodeID>), Mandant: '<Mandant>' (Nr. <KbMandantID>)"
                   (further modes to be continued...)
    @LanguageCode: The language code (1 = de, 2 = fr, 3 = it)
  -
  RETURNS: Text as defined with parameters or '' in case of unknown data or error
  -
  TEST:    SELECT dbo.fnKbGetPeriodeInfo(30, 'wv')
           SELECT dbo.fnKbGetPeriodeInfo(30, 'klibu')
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetPeriodeInfo
(
  @KbPeriodeID  INT,
  @Mode         VARCHAR(20),
  @LanguageCode INT
)
RETURNS VARCHAR(500)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (ISNULL(@KbPeriodeID, -1) < 1 OR ISNULL(@Mode, '') = '')
  BEGIN
    -- invalid parameters
    RETURN '';
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Output VARCHAR(500);
  
  DECLARE @KbPeriodeIDVc VARCHAR(50);
  DECLARE @KbPeriodeVonVc VARCHAR(50);
  DECLARE @KbPeriodeBisVc VARCHAR(50);
  DECLARE @KbMandantIDVc VARCHAR(50);
  DECLARE @KbMandant VARCHAR(100);
  
  DECLARE @MaskName VARCHAR(100);
  DECLARE @TextPeriodeKlibu VARCHAR(100);
  DECLARE @TextPeriodeWv VARCHAR(100);
  
  -----------------------------------------------------------------------------
  -- get values
  -----------------------------------------------------------------------------
  SELECT @KbPeriodeVonVc = CONVERT(VARCHAR, PRD.PeriodeVon, 104),
         @KbPeriodeBisVc = CONVERT(VARCHAR, PRD.PeriodeBis, 104),
         @KbMandantIDVc  = CONVERT(VARCHAR, MAN.KbMandantID),
         @KbMandant      = dbo.fnGetMLTextByDefault(MAN.MandantTID, @LanguageCode, MAN.Mandant)
  FROM dbo.KbPeriode         PRD WITH (READUNCOMMITTED)
    INNER JOIN dbo.KbMandant MAN WITH (READUNCOMMITTED) ON MAN.KbMandantID = PRD.KbMandantID
  WHERE PRD.KbPeriodeID = @KbPeriodeID;
  
  SET @MaskName = 'KliBuEnvironment';
  SELECT @TextPeriodeKlibu = dbo.fnGetMLTextFromName(@MaskName, 'TextPeriodeKlibu', @LanguageCode); 
  SELECT @TextPeriodeWv = dbo.fnGetMLTextFromName(@MaskName, 'TextPeriodeWv', @LanguageCode); 
  
  
  -- validate vars and set defaults
  SET @KbPeriodeIDVc  = ISNULL(CONVERT(VARCHAR, @KbPeriodeID), '-');
  SET @KbPeriodeVonVc = ISNULL(@KbPeriodeVonVc, '-');
  SET @KbPeriodeBisVc = ISNULL(@KbPeriodeBisVc, '-');
  SET @KbMandantIDVc  = ISNULL(@KbMandantIDVc, '-');
  SET @KbMandant      = ISNULL(@KbMandant, '-');
  
  -----------------------------------------------------------------------------
  -- mode depending output
  -----------------------------------------------------------------------------
  IF (@Mode = 'klibu') 
  BEGIN
    SET @Output = @TextPeriodeKlibu;
    SET @Output = REPLACE(@Output, '{0}', @KbMandant);
    SET @Output = REPLACE(@Output, '{1}', @KbMandantIDVc);
    SET @Output = REPLACE(@Output, '{2}', @KbPeriodeVonVc);
    SET @Output = REPLACE(@Output, '{3}', @KbPeriodeBisVc);
    SET @Output = REPLACE(@Output, '{4}', @KbPeriodeIDVc);
  END
  ELSE IF (@Mode = 'wv') 
  BEGIN
    SET @Output = @TextPeriodeWv;
    SET @Output = REPLACE(@Output, '{0}', @KbMandant);
    SET @Output = REPLACE(@Output, '{1}', @KbMandantIDVc);
    SET @Output = REPLACE(@Output, '{2}', @KbPeriodeVonVc);
    SET @Output = REPLACE(@Output, '{3}', @KbPeriodeBisVc);
    SET @Output = REPLACE(@Output, '{4}', @KbPeriodeIDVc);
  END;
  
  -----------------------------------------------------------------------------
  -- return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@Output, '');
END;
GO