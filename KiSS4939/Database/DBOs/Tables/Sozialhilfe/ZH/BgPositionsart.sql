CREATE TABLE [dbo].[BgPositionsart](
  [BgPositionsartID] [int] IDENTITY(1,1) NOT NULL,
  [ModulID] [int] NOT NULL,
  [BgKategorieCode] [int] NOT NULL,
  [BgGruppeCode] [int] NOT NULL,
  [Name] [varchar](100) NOT NULL,
  [SortKey] [int] NOT NULL,
  [BgKostenartID] [int] NULL,
  [VerwaltungSD_Default] [bit] NULL,
  [Spezkonto] [bit] NOT NULL,
  [KeinKreditor] [bit] NOT NULL,
  [ProPerson] [bit] NOT NULL,
  [ProUE] [bit] NOT NULL,
  [Verrechenbar] [bit] NOT NULL,
  [ErzeugtBfsDossier] [bit] NOT NULL,
  [Bemerkung] [text] NULL,
  [Masterbudget_EditMask] [int] NOT NULL,
  [Monatsbudget_EditMask] [int] NOT NULL,
  [sqlRichtlinie] [varchar](3000) NULL,
  [VarName] [varchar](50) NULL,
  [BgPositionsartTS] [timestamp] NOT NULL,
  [SpezHauptvorgang] [int] NULL,
  [SpezTeilvorgang] [int] NULL,
 CONSTRAINT [PK_BgPositionsart] PRIMARY KEY CLUSTERED 
(
  [BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BgPositionsart_BgKostenartID] ON [dbo].[BgPositionsart] 
(
  [BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPositionsart_ModulID] ON [dbo].[BgPositionsart] 
(
  [ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_BgPositionsart_Sicherung] ON [dbo].[BgPositionsart] 
(
  [BgKategorieCode] ASC,
  [BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BgPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_BgPositionsart_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[BgPositionsart] CHECK CONSTRAINT [FK_BgPositionsart_BgKostenart]
GO

ALTER TABLE [dbo].[BgPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_BgPositionsart_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[BgPositionsart] CHECK CONSTRAINT [FK_BgPositionsart_XModul]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Spezkonto]  DEFAULT ((0)) FOR [Spezkonto]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_KeinKreditor]  DEFAULT ((0)) FOR [KeinKreditor]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ProPerson]  DEFAULT ((0)) FOR [ProPerson]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ProUE]  DEFAULT ((0)) FOR [ProUE]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Verrechenbar]  DEFAULT ((1)) FOR [Verrechenbar]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ErzeugtBfsDossier]  DEFAULT ((0)) FOR [ErzeugtBfsDossier]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Masterbudget_EditMask]  DEFAULT ((16773120)) FOR [Masterbudget_EditMask]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Monatsbudget_EditMask]  DEFAULT ((4095)) FOR [Monatsbudget_EditMask]
GO