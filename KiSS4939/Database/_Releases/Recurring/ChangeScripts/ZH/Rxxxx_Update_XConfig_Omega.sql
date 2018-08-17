/*===============================================================================================
  SUMMARY: Use this script to update config values for DEV databases.
=================================================================================================*/

SET NOCOUNT ON;
GO

UPDATE dbo.XConfig
SET ValueBit = 0
WHERE KeyPath = 'System\Schnittstellen\Omega\DeleteEventFiles';

UPDATE dbo.XConfig
SET ValueVarchar = 'ftp://sapdrehscheibe-dev.stzh.ch/eCH0020_V2.3/O212_S02_Ereignisse/SAPOUT/'
WHERE KeyPath = 'System\Schnittstellen\Omega\FtpUrl';

UPDATE dbo.XConfig
SET ValueVarchar = 'kiss_sstxi7'
WHERE KeyPath = 'System\Schnittstellen\Omega\FtpUser';

UPDATE dbo.XConfig
SET ValueVarchar = 'KISSeCH14'
WHERE KeyPath = 'System\Schnittstellen\Omega\FtpPassword';

UPDATE dbo.XConfig
SET ValueVarchar = 'http://localhost:8090/KissEinwohnerregisterService.svc'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\KissWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O101_S01e_PAnfrage:CC_O101_S01e_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O101_S01e_PAnfrage&amp;Interface=http%3A%2F%2Fstzh.ch%2FO101%2FeCH-0020%2F2.3%5ESI_O101_L_Anfrage_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\AnfrageWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O102_S07_PSuche:CC_O102_S07_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O102_S07_PSuche&amp;Interface=http%3A%2F%2Fstzh.ch%2FO102%2FeCH-0020%2F2.3%5ESI_O102_Suche_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\SucheWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O13_S03_Regist:CC_O13_S03_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O13_S03_Regist&amp;Interface=http%3A%2F%2Fstzh.ch%2FO13%2FeCH-0020%2F2.3%5ESI_O13_Regist_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\RegistWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O13_S03_Regist:CC_O13_S03b_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O13_S03_Regist&amp;Interface=http%3A%2F%2Fstzh.ch%2FO13%2FeCH-0020%2F2.3%5ESI_O13_deRegist_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\DeRegistWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O103_S05_Person_Adr:CC_O103_S05b_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O103_S05_Person_Adr&amp;Interface=http%3A%2F%2Fstzh.ch%2FO103%2FeCH-0020%2F2.3%5ESI_O103_histAdr_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\AdresseHistWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'S_SD_KISS_I_AA'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesUsername'

UPDATE dbo.XConfig
SET ValueVarchar = 'KISS_if_14i'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesPassword'

SET NOCOUNT OFF;
GO
