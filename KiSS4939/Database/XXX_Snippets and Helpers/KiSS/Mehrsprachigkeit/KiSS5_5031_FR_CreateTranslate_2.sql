USE [KiSS_Standard_R5031_FR]
GO




-- ========== --
-- TOOLS --
-- ========== --

/*
DECLARE @className AS varchar(255) = 'CtlFibuBuchungCode'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colBank'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Finanz Institut',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Institution financière',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKontoNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Konto Nr') WHERE ClassName = @className AND ComponentName = @controlName
*/

/*
DECLARE @className AS varchar(255) = 'CtlFibuDTAZugang'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'lblFinanzInstitut'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Bank') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPostBank'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Post/Bank',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Poste/Banque',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

*/

SELECT * FROM dbo.XLangText xt WHERE xt.TID IN (SELECT TID FROM dbo.XLangText xt WHERE xt.Text LIKE '%Zahlungsfrist%')
GO

SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Buchungsdatum'

DECLARE @className AS varchar(255) = 'CtlFibuIbanGenerieren'
SELECT * FROM dbo.XClass xt WHERE xt.ClassName = @className
SELECT * FROM dbo.XClassComponent xc WHERE xc.ClassName = @className
SELECT * FROM dbo.XClassControl xt WHERE xt.ClassName = @className
GO




SELECT * FROM dbo.XLangText xt WHERE xt.TID = 15709
GO

SELECT xc.* FROM dbo.XClassComponent xc WHERE xc.ComponentName LIKE '%Kontenplan%'

SELECT * FROM dbo.XModulTree xt WHERE xt.ClassName = 'CtlIkLeistung'
SELECT * FROM dbo.XModulTree xt WHERE xt.ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Elternbeitrag')

SELECT * FROM dbo.XModulTree xt WHERE xt.ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung')

SELECT * FROM dbo.XModulTree xt WHERE xt.ModulTreeID IN(40000, 40007,40011)

-- ========== --
-- /TOOLS --
-- ========== --

