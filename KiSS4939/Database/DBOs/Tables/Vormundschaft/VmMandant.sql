CREATE TABLE [dbo].[VmMandant](
	[VmMandantID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[UserID] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[Vorname] [varchar](100) NULL,
	[Geburtsdatum] [datetime] NULL,
	[ZivilstandCode] [int] NULL,
	[HeimatgemeindeBaGemeindeID] [int] NULL,
	[Beruf] [varchar](100) NULL,
	[WertschriftenDepot] [varchar](200) NULL,
	[AHVNummer] [varchar](16) NULL,
	[Versichertennummer] [varchar](18) NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmMandantTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmMandant] PRIMARY KEY CLUSTERED 
(
	[VmMandantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmMandant_BaPersonID] ON [dbo].[VmMandant] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_VmMandant_UserID] ON [dbo].[VmMandant] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmMandant Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandant', @level2type=N'COLUMN',@level2name=N'VmMandantID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmMandant_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandant', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmMandant_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandant', @level2type=N'COLUMN',@level2name=N'UserID'
GO

ALTER TABLE [dbo].[VmMandant]  WITH CHECK ADD  CONSTRAINT [FK_VmMandant_BaGemeinde] FOREIGN KEY([HeimatgemeindeBaGemeindeID])
REFERENCES [dbo].[BaGemeinde] ([BaGemeindeID])
GO

ALTER TABLE [dbo].[VmMandant] CHECK CONSTRAINT [FK_VmMandant_BaGemeinde]
GO

ALTER TABLE [dbo].[VmMandant]  WITH CHECK ADD  CONSTRAINT [FK_VmMandant_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[VmMandant] CHECK CONSTRAINT [FK_VmMandant_BaPerson]
GO

ALTER TABLE [dbo].[VmMandant]  WITH CHECK ADD  CONSTRAINT [FK_VmMandant_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmMandant] CHECK CONSTRAINT [FK_VmMandant_XUser]
GO