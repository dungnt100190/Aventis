/****** Object:  Table [dbo].[EdEinsatzvereinbarung_EdReduktion]    Script Date: 12/22/2009 11:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EdEinsatzvereinbarung_EdReduktion](
	[EdEinsatzvereinbarung_EdReduktionID] [int] IDENTITY(1,1) NOT NULL,
	[EdEinsatzvereinbarungID] [int] NOT NULL,
	[EdReduktionID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_EdEinsatzvereinbarung_EdReduktion_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_EdEinsatzvereinbarung_EdReduktion_Modified]  DEFAULT (getdate()),
	[EdEinsatzvereinbarung_EdReduktionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdEinsatzvereinbarung_EdReduktion] PRIMARY KEY CLUSTERED 
(
	[EdEinsatzvereinbarung_EdReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_EdEinsatzvereinbarung_EdReduktion_EdEinsatzvereinbarungID_EdReduktionID] UNIQUE NONCLUSTERED 
(
	[EdEinsatzvereinbarungID] ASC,
	[EdReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_EdEinsatzvereinbarung_EdReduktion_EdEinsatzvereinbarungID]    Script Date: 12/22/2009 11:28:07 ******/
CREATE NONCLUSTERED INDEX [IX_EdEinsatzvereinbarung_EdReduktion_EdEinsatzvereinbarungID] ON [dbo].[EdEinsatzvereinbarung_EdReduktion] 
(
	[EdEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_EdEinsatzvereinbarung_EdReduktion_EdReduktionID]    Script Date: 12/22/2009 11:28:07 ******/
CREATE NONCLUSTERED INDEX [IX_EdEinsatzvereinbarung_EdReduktion_EdReduktionID] ON [dbo].[EdEinsatzvereinbarung_EdReduktion] 
(
	[EdReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel, eine ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'EdEinsatzvereinbarung_EdReduktionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Einsatzvereinbarung welche mit einer Reduktion verknüpft werden soll. Fremdschlüssel auf EdEinsatzvereinbarung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'EdEinsatzvereinbarungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Reduktion welche mit einer Einsatzvereinbarung verknüpft werden soll. Fremdschlüssel auf EdReduktion.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'EdReduktionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Eintrag erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letztes verändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag als letztes verändert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung_EdReduktion', @level2type=N'COLUMN',@level2name=N'EdEinsatzvereinbarung_EdReduktionTS'
GO
ALTER TABLE [dbo].[EdEinsatzvereinbarung_EdReduktion]  WITH CHECK ADD  CONSTRAINT [FK_EdEinsatzvereinbarung_EdReduktion_EdEinsatzvereinbarung] FOREIGN KEY([EdEinsatzvereinbarungID])
REFERENCES [dbo].[EdEinsatzvereinbarung] ([EdEinsatzvereinbarungID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EdEinsatzvereinbarung_EdReduktion] CHECK CONSTRAINT [FK_EdEinsatzvereinbarung_EdReduktion_EdEinsatzvereinbarung]
GO
ALTER TABLE [dbo].[EdEinsatzvereinbarung_EdReduktion]  WITH CHECK ADD  CONSTRAINT [FK_EdEinsatzvereinbarung_EdReduktion_EdReduktion] FOREIGN KEY([EdReduktionID])
REFERENCES [dbo].[EdReduktion] ([EdReduktionID])
GO
ALTER TABLE [dbo].[EdEinsatzvereinbarung_EdReduktion] CHECK CONSTRAINT [FK_EdEinsatzvereinbarung_EdReduktion_EdReduktion]