EXECUTE dbo.spDropObject fnGetEhepaarName;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Liefert den Namen einer Person sowie den des Partners (Ehepaar, rechtliche Partnerschaft, Konkubinatspaar) zurück. Bsp:
           'Hans Muster'
           'Hans Muster und Heidi Test'
           'Hans und Heidi Muster'

    @BaPersonID: Die ID der Person.
    @BgFinanzplanID: Die ID des Finanzplans
    @InklAnrede: 1, falls Anrede zurückgegeben werden soll, 0 für keine Anrede
    @LanguageCode: Sprachcode  
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT dbo.fnGetEhepaarName(2091, 123, 1, 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnGetEhepaarName
(
  @BaPersonID INT,
  @BgFinanzplanID INT = NULL,
  @InklAnrede BIT = 0,
  @LanguageCode INT = 1
)
RETURNS VARCHAR(100)
AS
BEGIN
  DECLARE @Text VARCHAR(100);
  DECLARE @Herr Varchar(10);
  DECLARE @Frau Varchar(10);  
  DECLARE @Und Varchar(10);

  SELECT @Herr = CASE WHEN @LanguageCode = 1 THEN 'Herr'
                      WHEN @LanguageCode = 2 THEN 'Monsieur'
                      WHEN @LanguageCode = 3 THEN 'Signore'
                 END
  
  SELECT @Frau = CASE WHEN @LanguageCode = 1 THEN 'Frau'
                      WHEN @LanguageCode = 2 THEN 'Madame'
                      WHEN @LanguageCode = 3 THEN 'Signora'
                 END
                 
  SELECT @Und = CASE WHEN @LanguageCode = 1 THEN ' und '
                     WHEN @LanguageCode = 2 THEN ' et '
                     WHEN @LanguageCode = 3 THEN ' e '
                 END 
                              
  SELECT @Text = CASE
                   WHEN @BgFinanzplanID IS NULL OR FPP.IstUnterstuetzt = 1 THEN /* konkateniert unter beachtung der namen*/
																		   CASE               
																			 WHEN PRS.Name = PRSE.Name THEN 
		                                                                CASE WHEN @InklAnrede = 1 THEN 
		                                                                            CASE PRS.GeschlechtCode WHEN 1 THEN @Herr WHEN 2 THEN @Frau END 
		                                                                                 + @Und + 
		                                                                            CASE PRSE.GeschlechtCode WHEN 1 THEN @Herr WHEN 2 THEN @Frau END + char(13) + char(10) +
                                                                              PRS.Vorname + @Und + PRSE.Vorname + ' ' + PRS.NAME
		                                                                     ELSE
		    															                                        PRS.Vorname + @Und + PRSE.Vorname + ' ' + PRS.NAME
		                                                                END    															                                        
																			                                        
																			 ELSE 
																			      CASE WHEN @InklAnrede = 1 THEN
		                                                                    CASE PRS.GeschlechtCode WHEN 1 THEN @Herr WHEN 2 THEN @Frau END 
		                                                                         + @Und + 
		                                                                    CASE PRSE.GeschlechtCode WHEN 1 THEN @Herr WHEN 2 THEN @Frau END + char(13) + char(10) +																	 
																			                                    PRS.VornameName + ISNULL(@Und + PRSE.VornameName, '') 																			                                                                                                   
		                                        ELSE PRS.VornameName + ISNULL(@Und + PRSE.VornameName, '')                                             END																       
																		  END
				       ELSE /*sonst nur falltraeger*/ 
				           CASE WHEN @InklAnrede = 1 THEN 
				                              CASE PRS.GeschlechtCode WHEN 1 THEN @Herr WHEN 2 THEN @Frau END + ' ' + char(13) + char(10) + PRS.VornameName 
		                ELSE PRS.VornameName
		               END      		       
				      END
					
  FROM dbo.vwPerson PRS
    LEFT JOIN dbo.vwPerson PRSE WITH (READUNCOMMITTED) ON PRSE.BaPersonID = (SELECT TOP 1 
                                                                               CASE
                                                                                 WHEN R.BaPersonID_2 = PRS.BaPersonID THEN R.BaPersonID_1
                                                                                 ELSE R.BaPersonID_2
                                                                               END
                                                                             FROM dbo.BaPerson_Relation R
                                                                             WHERE (R.BaPersonID_1 = PRS.BaPersonID OR R.BaPersonID_2 = PRS.BaPersonID)
                                                                               AND R.BaRelationID IN (13, 14, 15) -- Ehepaar, rechtliche Partnerschaft, Konkubinatspaar
                                                                               AND dbo.fnDateOf(GETDATE()) BETWEEN ISNULL(R.DatumVon, dbo.fnDateOf(GETDATE())) AND ISNULL(R.DatumBis, dbo.fnDateOf(GETDATE()))
                                                                             ORDER BY R.BaRelationID ASC, R.DatumVon DESC)
	LEFT JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = @BgFinanzplanID 
	                                                              AND FPP.BaPersonID = PRSE.BaPersonID																			
  WHERE PRS.BaPersonID = @BaPersonID;

  RETURN @Text;
END;
GO