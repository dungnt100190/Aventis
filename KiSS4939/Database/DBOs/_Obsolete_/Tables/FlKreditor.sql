-- wird temporär noch verwendet um manuell Zahlungsege zu migrieren
CREATE TABLE [dbo].[FlKreditor](
	[FlKreditorID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Vorname] [varchar](50) NULL,
	[Strasse] [varchar](50) NULL,
	[PLZ] [varchar](8) NULL,
	[Ort] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_tcoKissFbKreditor_IsActive]  DEFAULT (1),
	[ModulID] [int] NOT NULL CONSTRAINT [DF__FlKredito__Modul__731BDD5C]  DEFAULT (3),
	[FlKreditorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FlKreditor] PRIMARY KEY NONCLUSTERED 
(
	[FlKreditorID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_FlKreditor] ON [dbo].[FlKreditor] 
(
	[ModulID] ASC,
	[Name] ASC,
	[Vorname] ASC
) ON [PRIMARY]
GO