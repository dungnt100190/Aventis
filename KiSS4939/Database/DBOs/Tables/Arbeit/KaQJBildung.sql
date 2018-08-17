-- =============================================
-- Create Table KaQJBildung
-- =============================================


CREATE TABLE [dbo].[KaQJBildung](
	[KaQJBildungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[KursBewerbungFlag] [bit] NOT NULL,
	[KursInformatikFlag] [bit] NOT NULL,
	[KursVideoFlag] [bit] NOT NULL,
	[KursWissenFlag] [bit] NOT NULL,
	[KursCustom1Flag] [bit] NOT NULL,
	[KursCustom1Text] [varchar](255) NULL,
	[KursCustom2Flag] [bit] NOT NULL,
	[KursCustom2Text] [varchar](255) NULL,
	[KursCustom3Flag] [bit] NOT NULL,
	[KursCustom3Text] [varchar](255) NULL,
	[KursCustom4Flag] [bit] NOT NULL,
	[KursCustom4Text] [varchar](255) NULL,
	[KursCustom5Flag] [bit] NOT NULL,
	[KursCustom5Text] [varchar](255) NULL,
	[KursCustom6Flag] [bit] NOT NULL,
	[KursCustom6Text] [varchar](255) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQJBildungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJBildung] PRIMARY KEY CLUSTERED 
(
	[KaQJBildungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[KaQJBildung]  WITH CHECK ADD  CONSTRAINT [FK_KaQJBildung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KaQJBildung] CHECK CONSTRAINT [FK_KaQJBildung_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursBewerbungFlag]  DEFAULT ((0)) FOR [KursBewerbungFlag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursInformatikFlag]  DEFAULT ((0)) FOR [KursInformatikFlag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursVideoFlag]  DEFAULT ((0)) FOR [KursVideoFlag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursWissenFlag]  DEFAULT ((0)) FOR [KursWissenFlag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursCustom1Flag]  DEFAULT ((0)) FOR [KursCustom1Flag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursCustom2Flag]  DEFAULT ((0)) FOR [KursCustom2Flag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursCustom3Flag]  DEFAULT ((0)) FOR [KursCustom3Flag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursCustom4Flag]  DEFAULT ((0)) FOR [KursCustom4Flag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursCustom5Flag]  DEFAULT ((0)) FOR [KursCustom5Flag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_KursCustom6Flag]  DEFAULT ((0)) FOR [KursCustom6Flag]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaQJBildung] ADD  CONSTRAINT [DF_KaQJBildung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


