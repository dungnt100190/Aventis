SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstIKAuszugExportXML
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spSstIKAuszugExportXML.sql $
  $Author: Rstahel $
  $Modtime: 25.08.10 14:39 $
  $Revision: 11 $
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
  $Log:
 * 
=================================================================================================*/

CREATE PROCEDURE [dbo].[spSstIKAuszugExportXML]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- XML-Anforderung generieren
	DECLARE @IKRequest XML 
    
	;WITH XMLNAMESPACES('http://www.w3.org/2001/XMLSchema-instance' as [xsi], 'http://www.ech.ch/xmlns/eCH-0058/2' as [eCH-0058], 'http://igs-gmbh.ch/xmlns/igs-0002/1' as [igs-0002], 'http://igs-gmbh.ch/xmlns/igs-0001/1' as [igs-0001], 'http://www.ech.ch/xmlns/eCH-0044/1' as [eCH-0044] )

	UPDATE IKA SET
		MessageID = REPLACE(PER.Versichertennummer, '.', '') + CONVERT(varchar(20), GetDate(), 112),
		Versichertennummer = PER.Versichertennummer,
		ExportXML = '<?xml version="1.0" encoding="UTF-8" ?>' + (
			SELECT
				  'http://igs-gmbh.ch/xmlns/igs-0002/1 igs-0002-1-0.xsd' as '@xsi:schemaLocation',
				  'FZH1' 'igs-0002:header/igs-0001:senderId',
				  REPLACE(PER.Versichertennummer, '.', '') + CONVERT(varchar(20), GetDate(), 112) 'igs-0002:header/igs-0001:messageId', 
				  0 'igs-0002:header/igs-0001:messageType',
				  'Diartis AG' 'igs-0002:header/igs-0001:sendingApplication/eCH-0058:manufacturer',
				  'KiSS' 'igs-0002:header/igs-0001:sendingApplication/eCH-0058:product',
				  (SELECT TOP 1 CONVERT(varchar(5), MajorVersion) + '.' + CONVERT(varchar(5), MinorVersion) + '.' + CONVERT(varchar(5), Build) + '.'
					+ CONVERT(varchar(10), Revision) FROM XDBVersion ORDER BY XDBVersionID DESC) 'igs-0002:header/igs-0001:sendingApplication/eCH-0058:productVersion',
				  GetDate() 'igs-0002:header/igs-0001:messageDate',
				  GetDate() 'igs-0002:header/igs-0001:eventDate', 
				  5 'igs-0002:header/igs-0001:action',
				  'false' 'igs-0002:header/igs-0001:testDeliveryFlag', 
				  REPLACE(PER.Versichertennummer, '.', '') 'igs-0002:searchIndividualAccountRequest/igs-0002:vn',
				  PER.[Name] 'igs-0002:searchIndividualAccountRequest/igs-0002:officialName',
				  PER.Vorname 'igs-0002:searchIndividualAccountRequest/igs-0002:firstName',
				  CONVERT(varchar, PER.Geburtsdatum, 23) 'igs-0002:searchIndividualAccountRequest/igs-0002:dateOfBirth/eCH-0044:yearMonthDay',
				  VIKA2.JahrVon 'igs-0002:searchIndividualAccountRequest/igs-0002:yearFrom',
				  VIKA2.JahrBis 'igs-0002:searchIndividualAccountRequest/igs-0002:yearTo'
			FROM vwSstIkAuszug VIKA2
			INNER JOIN vwPerson PER  WITH (READUNCOMMITTED) ON PER.BaPersonID = VIKA2.BaPersonID
			WHERE VIKA2.SstIKAuszugID = IKA.SstIKAuszugID
			FOR XML PATH('igs-0002:message'))
	FROM SstIKAuszug IKA 
	INNER JOIN vwSstIKAuszug VIKA WITH (READUNCOMMITTED) ON VIKA.SstIKAuszugID = IKA.SstIKAuszugID
	INNER JOIN vwPerson PER  WITH (READUNCOMMITTED) ON PER.BaPersonID = IKA.BaPersonID
	WHERE VIKA.SstIkAuszugStatusCode IN (1, 4)	-- Angefordert oder Importiert mit Fehler
		 AND PER.Versichertennummer IS NOT NULL 
	
END

-- Test:
--UPDATE SstIKAuszug Set ExportDatum = NULL, ExportXML = NULL
--Select * from vwSstIKAuszug
--EXEC spSstIKAuszugExportXML
--Select * from vwSstIKAuszug