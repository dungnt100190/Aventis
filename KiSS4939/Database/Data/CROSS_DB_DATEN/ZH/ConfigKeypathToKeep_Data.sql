SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [ConfigKeyPathToKeep]
GO
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Allgemein\DbName')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Alpha\AlphaWebServiceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Alpha\LetzteSendungAnZVM')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Alpha\LetzteVerarbeitungZVM')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Alpha\Proxy')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\BackgroundWorkerService\BackgroundWorkerWebServiceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\KIS\URL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\PSCD\Proxy')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\PSCD\ProxyAsync')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\PSCD\ProxyServer')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\PSCD\PSCDNotificationWebServiceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\PSCD\PSCDWebServiceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\AdresseHistWebserviceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\AnfrageWebserviceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\DeRegistWebserviceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesPassword')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesProxy')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesUsername')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\KissWebserviceProxy')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\KissWebserviceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\KissWebserviceValidateCertificate')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\RegistWebserviceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Einwohnerregister\SucheWebserviceURL')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Omega\DeleteEventFiles')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Omega\FtpPassword')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Omega\FtpUrl')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Schnittstellen\Omega\FtpUser')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Allgemein\Benutzername_TechnischerBenutzer')
INSERT INTO [ConfigKeyPathToKeep] ([KeyPath]) VALUES (N'System\Allgemein\Passwort_TechnischerBenutzer')

GO
COMMIT
GO