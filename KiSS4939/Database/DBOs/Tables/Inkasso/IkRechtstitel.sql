CREATE TABLE [dbo].[IkRechtstitel](
	[IkRechtstitelID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[IkBezugKinderzulagenCode] [int] NULL,
	[IkRechtstitelStatusCode] [int] NULL,
	[IkRechtstitelTypCode] [int] NULL,
	[InkassoFallName] [varchar](50) NULL,
	[RechtstitelInfo] [varchar](2048) NULL,
	[RechtstitelDatumVon] [datetime] NULL,
	[RechtstitelRechtskraeftig] [datetime] NULL,
	[IkElterlicheSorgeCode] [int] NULL,
	[ElterlicheSorgeBemerkung] [varchar](200) NULL,
	[BaPersonID] [int] NULL,
	[IkIndexTypCode] [int] NULL,
	[IndexStandPunkte] [float] NULL,
	[IndexStandVom] [datetime] NULL,
	[IkIndexRundenCode] [int] NULL,
	[BasisKinderalimente] [money] NULL,
	[BasisEhegattenalimente] [money] NULL,
	[IkInkassoBemuehungCode] [int] NULL,
	[VerjaehrungAm] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[SchuldnerMahnen] [bit] NULL,
	[IkAlimenteUnterartCode] [int] NULL,
	[IkRueckerstattungTypCode] [int] NULL,
	[IkRechtstitelGueltigVon] [datetime] NULL,
	[IkRechtstitelGueltigBis] [datetime] NULL,
	[IkRechtstitelTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkRechtstitel] PRIMARY KEY CLUSTERED 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkRechtstitel_BaPersonID] ON [dbo].[IkRechtstitel] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_IkRechtstitel_FaLeistungID] ON [dbo].[IkRechtstitel] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für IkRechtstitel Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkRechtstitel', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkRechtstitel_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkRechtstitel', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkRechtstitel_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkRechtstitel', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

ALTER TABLE [dbo].[IkRechtstitel]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitel_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkRechtstitel] CHECK CONSTRAINT [FK_IkRechtstitel_BaPerson]
GO

ALTER TABLE [dbo].[IkRechtstitel]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitel_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkRechtstitel] CHECK CONSTRAINT [FK_IkRechtstitel_FaLeistung]
GO

ALTER TABLE [dbo].[IkRechtstitel] ADD  CONSTRAINT [DF_IkRechtstitel_IkBezugKinderzulagenCode]  DEFAULT ((1)) FOR [IkBezugKinderzulagenCode]
GO

ALTER TABLE [dbo].[IkRechtstitel] ADD  CONSTRAINT [DF_Ikrechtstitel_IkRechtstitelStatusCode]  DEFAULT ((1)) FOR [IkRechtstitelStatusCode]
GO

ALTER TABLE [dbo].[IkRechtstitel] ADD  CONSTRAINT [DF_IkRechtstitel_SchuldnerMahnen]  DEFAULT ((1)) FOR [SchuldnerMahnen]
GO