CREATE TABLE [dbo].[FaIntake](
	[FaIntakeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[EmpfohlenVonCode] [int] NULL,
	[AnlassthemenCodes] [varchar](255) NULL,
	[Anlass] [varchar](max) NULL,
	[Situationsbeschrieb] [varchar](max) NULL,
	[WeiteresVorgehen] [varchar](max) NULL,
	[RueckrufBis] [datetime] NULL,
	[DurchWenCode] [int] NULL,
	[VereinbartesTreffen] [datetime] NULL,
	[InvolvierteFachstellen] [varchar](max) NULL,
	[IntakeProtokollDocID] [int] NULL,
	[visdat36Area] [varchar](255) NULL,
	[visdat36ID] [varchar](6) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaIntakeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaIntake] PRIMARY KEY CLUSTERED 
(
	[FaIntakeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2],
 CONSTRAINT [UK_FaIntake_FaLeistungID] UNIQUE NONCLUSTERED 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaIntake_FaLeistungID_EmpfohlenVonCode_AnlassthemenCodes] ON [dbo].[FaIntake] 
(
	[FaLeistungID] ASC,
	[EmpfohlenVonCode] ASC,
	[AnlassthemenCodes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'EmpfohlenVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaIntake', @level2type=N'COLUMN',@level2name=N'EmpfohlenVonCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaIntake', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaIntake', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaIntake', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaIntake', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[FaIntake]  WITH CHECK ADD  CONSTRAINT [FK_FaIntake_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaIntake] CHECK CONSTRAINT [FK_FaIntake_FaLeistung]
GO

ALTER TABLE [dbo].[FaIntake] ADD  CONSTRAINT [DF_FaIntake_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaIntake] ADD  CONSTRAINT [DF_FaIntake_Modified]  DEFAULT (getdate()) FOR [Modified]
GO