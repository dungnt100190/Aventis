SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XTypeConfig]
GO
SET IDENTITY_INSERT [XTypeConfig] ON
GO
INSERT INTO [XTypeConfig] ([XTypeConfigID], [LookupTypeName], [LookupTypeNamespace], [LookupTypeAssemblyName], [ConcreteStandardTypeName], [ConcreteStandardTypeNamespace], [ConcreteStandardTypeAssemblyName], [ConcreteCustomTypeName], [ConcreteCustomTypeNamespace], [ConcreteCustomTypeAssemblyName], [InstanceScopeCode]) VALUES (2, N'ISessionService', N'Kiss.Interfaces.BL', N'Kiss.Interfaces', N'SessionService', N'Kiss.BL', N'Kiss.BL', NULL, NULL, NULL, 2)
INSERT INTO [XTypeConfig] ([XTypeConfigID], [LookupTypeName], [LookupTypeNamespace], [LookupTypeAssemblyName], [ConcreteStandardTypeName], [ConcreteStandardTypeNamespace], [ConcreteStandardTypeAssemblyName], [ConcreteCustomTypeName], [ConcreteCustomTypeNamespace], [ConcreteCustomTypeAssemblyName], [InstanceScopeCode]) VALUES (3, N'IKissFormController', N'Kiss.Interfaces.UI', N'Kiss.Interfaces', N'FormController', N'KiSS4.Gui', N'KiSS4.Gui', NULL, NULL, NULL, 1)
INSERT INTO [XTypeConfig] ([XTypeConfigID], [LookupTypeName], [LookupTypeNamespace], [LookupTypeAssemblyName], [ConcreteStandardTypeName], [ConcreteStandardTypeNamespace], [ConcreteStandardTypeAssemblyName], [ConcreteCustomTypeName], [ConcreteCustomTypeNamespace], [ConcreteCustomTypeAssemblyName], [InstanceScopeCode]) VALUES (4, N'IXDocumentLogic', N'Kiss.Interfaces.UI', N'Kiss.Interfaces', N'XDokumentLogik', N'KiSS4.Dokument', N'KiSS4.Dokument', NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [XTypeConfig] OFF
GO
COMMIT
GO