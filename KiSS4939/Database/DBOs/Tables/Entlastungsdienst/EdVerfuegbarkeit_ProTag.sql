CREATE TABLE [dbo].[EdVerfuegbarkeit_ProTag](
	[EdVerfuegbarkeit_ProTagID] [int] IDENTITY(1,1) NOT NULL,
	[EdVerfuegbarkeitID] [int] NOT NULL,
	[WochentagID] [int] NOT NULL,
	[VerfuegbarMorgen] [bit] NOT NULL,
	[VerfuegbarNachmittag] [bit] NOT NULL,
	[VerfuegbarAbend] [bit] NOT NULL,
	[VerfuegbarNacht] [bit] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[EdVerfuegbarkeit_ProTagTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdVerfuegbarkeit_ProTag] PRIMARY KEY CLUSTERED 
(
	[EdVerfuegbarkeit_ProTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_EdVerfuegbarkeit_ProTag_EdVerfuegbarkeitID_WochentagID] UNIQUE NONCLUSTERED 
(
	[EdVerfuegbarkeitID] ASC,
	[WochentagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummerierung des Wochentags für den Eintrag (Mo=1,Di=2,Mi=3,Do=4,Fr=5,Sa=6,So=7)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdVerfuegbarkeit_ProTag', @level2type=N'COLUMN',@level2name=N'WochentagID'
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag]  WITH CHECK ADD  CONSTRAINT [FK_EdVerfuegbarkeit_ProTag_EdVerfuegbarkeit] FOREIGN KEY([EdVerfuegbarkeitID])
REFERENCES [dbo].[EdVerfuegbarkeit] ([EdVerfuegbarkeitID])
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag] CHECK CONSTRAINT [FK_EdVerfuegbarkeit_ProTag_EdVerfuegbarkeit]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_ProTag_VerfuegbarMorgen]  DEFAULT ((0)) FOR [VerfuegbarMorgen]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_ProTag_VerfuegbarNachmittag]  DEFAULT ((0)) FOR [VerfuegbarNachmittag]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_ProTag_VerfuegbarAbend]  DEFAULT ((0)) FOR [VerfuegbarAbend]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_ProTag_VerfuegbarNacht]  DEFAULT ((0)) FOR [VerfuegbarNacht]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit_ProTag] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_ProTag_Created]  DEFAULT (getdate()) FOR [Created]
GO