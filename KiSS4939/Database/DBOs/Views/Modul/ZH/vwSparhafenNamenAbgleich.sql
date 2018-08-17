SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwSparhafenNamenAbgleich
GO

CREATE VIEW [dbo].[vwSparhafenNamenAbgleich]
AS
  SELECT DISTINCT
    NameVorname = Klient,
    TeilKontoNr = TeilKtoNr,
    BaPersonID
  FROM dbo.kgSparhafenabschluss
  WHERE BaPersonID IS NOT NULL -- and ungueltig = 0 
  UNION
  SELECT DISTINCT
    NameVorname,
    TeilKontoNr = Substring(KontoNr, 2, 3) + '.' + Substring(KontoNr, 5, 3),
    BaPersonID
  FROM dbo.kgSparhafenSaldo
  WHERE BaPersonID IS NOT NULL

