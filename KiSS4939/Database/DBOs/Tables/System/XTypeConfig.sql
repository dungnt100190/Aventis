CREATE TABLE [dbo].[XTypeConfig](
  [XTypeConfigID] [int] IDENTITY(1,1) NOT NULL,
  [LookupTypeName] [varchar](100) NOT NULL,
  [LookupTypeNamespace] [varchar](200) NOT NULL,
  [LookupTypeAssemblyName] [varchar](200) NOT NULL,
  [ConcreteStandardTypeName] [varchar](100) NOT NULL,
  [ConcreteStandardTypeNamespace] [varchar](200) NOT NULL,
  [ConcreteStandardTypeAssemblyName] [varchar](200) NOT NULL,
  [ConcreteCustomTypeName] [varchar](100) NULL,
  [ConcreteCustomTypeNamespace] [varchar](200) NULL,
  [ConcreteCustomTypeAssemblyName] [varchar](200) NULL,
  [InstanceScopeCode] [int] NOT NULL,
  [XTypeConfigTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTypeConfig] PRIMARY KEY CLUSTERED 
(
  [XTypeConfigID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UK_XTypeConfig_LookupTypeNamespace_LookupTypeName] UNIQUE NONCLUSTERED 
(
  [LookupTypeNamespace] ASC,
  [LookupTypeName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MD_Description', @value=N'Primärschlüssel für XTypeConfig Einträge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'XTypeConfigID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typename des Lookup-Types (z.B. eines Interfaces), ohne Namespace. Bsp. `IBaPersonService`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'LookupTypeName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace des Lookup-Types (z.B. eines Interfaces), ohne den Namen des Typs. Bsp. `Kiss.Interfaces.BL.BA`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'LookupTypeNamespace'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name des Assemblies des Lookup-Types (z.B. eines Interfaces), ohne File Extension. Bsp. `Kiss.Interfaces`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'LookupTypeAssemblyName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard-Implementation: Typename des Typs (Klasse), das den Lookup-Typ implementiert, ohne Namespace. Bsp. `BaPersonService`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'ConcreteStandardTypeName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard-Implementation: Namespace des Typs (Klasse), das den Lookup-Typ implementiert, ohne den Namen des Typs. Bsp. `Kiss.BL.BA`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'ConcreteStandardTypeNamespace'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard-Implementation: Name des Typs (Klasse), das den Lookup-Typ implementiert, ohne File Extension. Bsp. `Kiss.BL`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'ConcreteStandardTypeAssemblyName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kundenspezifische Implementation: Typename des Typs (Klasse), das den Lookup-Typ implementiert, ohne Namespace. Bsp. `BaPersonService`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'ConcreteCustomTypeName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kundenspezifische Implementation: Namespace des Typs (Klasse), das den Lookup-Typ implementiert, ohne den Namen des Typs. Bsp. `Kiss.BL.BA.ZH`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'ConcreteCustomTypeNamespace'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kundenspezifische Implementation: Name des Typs (Klasse), das den Lookup-Typ implementiert, ohne File Extension. Bsp. `Kiss.BL`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'ConcreteCustomTypeAssemblyName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV InstanceScope: Singleton, PerRequest, PerThread' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'InstanceScopeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig', @level2type=N'COLUMN',@level2name=N'XTypeConfigTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Reto Stahel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Liste aller Typen (z.B. Interfaces), die in Kiss dynamisch konfiguriert und so z.B. kundenspezifische Funktionalität (Services etc) instanziert werden können. Jeweils ein Lookup-Type (z.B. ein Interface) zeigt auf eine konkrete Standard-Implementierung und optional auf die Kundenspezifische Implementationsvariante dieses Lookup-Typs.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'IoC-Container von Kiss für Typ-Resolving' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTypeConfig'
GO

ALTER TABLE [dbo].[XTypeConfig] ADD  CONSTRAINT [DF_XTypeConfig_InstanceScopeCode]  DEFAULT ((1)) FOR [InstanceScopeCode]
GO


