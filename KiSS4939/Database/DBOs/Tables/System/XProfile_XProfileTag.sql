CREATE TABLE [dbo].[XProfile_XProfileTag](
	[XProfile_XProfileTagID] [int] IDENTITY(1,1) NOT NULL,
	[XProfileID] [int] NOT NULL,
	[XProfileTagID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XProfile_XProfileTagTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XProfile_XProfileTag] PRIMARY KEY CLUSTERED 
(
	[XProfile_XProfileTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_XProfile_XProfileTag_XProfileID] ON [dbo].[XProfile_XProfileTag] 
(
	[XProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XProfile_XProfileTag_XProfileTagID] ON [dbo].[XProfile_XProfileTag] 
(
	[XProfileTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfile_XProfileTagID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XProfile' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfileID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Fremdschlüssel zu XProfile' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfileID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XProfileTag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfileTagID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfile_XProfileTagTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle zwischen XProfileTag und XProfile' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile_XProfileTag'
GO

ALTER TABLE [dbo].[XProfile_XProfileTag]  WITH CHECK ADD  CONSTRAINT [FK_XProfile_XProfileTag_XProfile] FOREIGN KEY([XProfileID])
REFERENCES [dbo].[XProfile] ([XProfileID])
GO

ALTER TABLE [dbo].[XProfile_XProfileTag] CHECK CONSTRAINT [FK_XProfile_XProfileTag_XProfile]
GO

ALTER TABLE [dbo].[XProfile_XProfileTag]  WITH CHECK ADD  CONSTRAINT [FK_XProfile_XProfileTag_XProfileTag] FOREIGN KEY([XProfileTagID])
REFERENCES [dbo].[XProfileTag] ([XProfileTagID])
GO

ALTER TABLE [dbo].[XProfile_XProfileTag] CHECK CONSTRAINT [FK_XProfile_XProfileTag_XProfileTag]
GO

ALTER TABLE [dbo].[XProfile_XProfileTag] ADD  CONSTRAINT [DF_XProfile_XProfileTag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XProfile_XProfileTag] ADD  CONSTRAINT [DF_XProfile_XProfileTag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO