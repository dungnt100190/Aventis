CREATE TABLE [dbo].[BDEAusbezahlteUeberstunden_XUser](
	[BDEAusbezahlteUeberstunden_XUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[AusbezahlteStd] [money] NOT NULL,
	[ManualEdit] [bit] NOT NULL CONSTRAINT [DF_BDEAusbezahlteUeberstunden_XUser_ManualEdit]  DEFAULT ((0)),
	[BDEAusbezahlteUeberstunden_XUserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDEAusbezahlteUeberstunden_XUser] PRIMARY KEY CLUSTERED 
(
	[BDEAusbezahlteUeberstunden_XUserID] ASC
) ON [PRIMARY],
 CONSTRAINT [IX_BDEAusbezahlteUeberstunden_XUser] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[Jahr] ASC,
	[DatumVon] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BDEAusbezahlteUeberstunden_XUser]  WITH CHECK ADD  CONSTRAINT [FK_BDEAusbezahlteUeberstunden_XUser_XUser] FOREIGN KEY([UserID])
REFERENCES [XUser] ([UserID])
GO