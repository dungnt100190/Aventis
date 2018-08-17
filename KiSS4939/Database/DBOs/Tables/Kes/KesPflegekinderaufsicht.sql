CREATE TABLE [dbo].[KesPflegekinderaufsicht](
	[KesPflegekinderaufsichtID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[KesPflegeartCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesPflegekinderaufsichtTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesPflegekinderaufsicht] PRIMARY KEY CLUSTERED 
(
	[KesPflegekinderaufsichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KesPflegekinderaufsicht_BaInstitutionID]    Script Date: 02/20/2014 14:04:58 ******/
CREATE NONCLUSTERED INDEX [IX_KesPflegekinderaufsicht_BaInstitutionID] ON [dbo].[KesPflegekinderaufsicht] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesPflegekinderaufsicht_FaLeistungID]    Script Date: 02/20/2014 14:04:58 ******/
CREATE NONCLUSTERED INDEX [IX_KesPflegekinderaufsicht_FaLeistungID] ON [dbo].[KesPflegekinderaufsicht] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesPflegekinderaufsicht_UserID]    Script Date: 02/20/2014 14:04:58 ******/
CREATE NONCLUSTERED INDEX [IX_KesPflegekinderaufsicht_UserID] ON [dbo].[KesPflegekinderaufsicht] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel KesPflegekinderaufsicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'KesPflegekinderaufsichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verantwortliche Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tages-/Pflegeeltern des Kindes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pflegekinderaufsicht Beginn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pflegekinderaufsicht Ende' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Liste von Pflegearten (LOV KesPflegeart)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'KesPflegeartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht', @level2type=N'COLUMN',@level2name=N'KesPflegekinderaufsichtTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kes Pflegekinderaufsicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPflegekinderaufsicht'
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht]  WITH CHECK ADD  CONSTRAINT [FK_KesPflegekinderaufsicht_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht] CHECK CONSTRAINT [FK_KesPflegekinderaufsicht_BaInstitution]
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht]  WITH CHECK ADD  CONSTRAINT [FK_KesPflegekinderaufsicht_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht] CHECK CONSTRAINT [FK_KesPflegekinderaufsicht_FaLeistung]
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht]  WITH CHECK ADD  CONSTRAINT [FK_KesPflegekinderaufsicht_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht] CHECK CONSTRAINT [FK_KesPflegekinderaufsicht_XUser]
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht] ADD  CONSTRAINT [DF_KesPflegekinderaufsicht_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesPflegekinderaufsicht] ADD  CONSTRAINT [DF_KesPflegekinderaufsicht_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

