CREATE TABLE [dbo].[BDEFerienanspruch_XUser](
	[BDEFerienanspruch_XUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[FerienanspruchStdProJahr] [money] NOT NULL,
	[ManualEdit] [bit] NOT NULL CONSTRAINT [DF_BDEFerienanspruch_XUser_ManualEdit]  DEFAULT ((0)),
	[BDEFerienanspruch_XUserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDEFerienanspruch_XUser] PRIMARY KEY CLUSTERED 
(
	[BDEFerienanspruch_XUserID] ASC
) ON [PRIMARY],
 CONSTRAINT [IX_BDEFerienanspruch_XUser] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[DatumVon] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BDEFerienanspruch_XUser] ADD  CONSTRAINT [FK_BDEFerienanspruch_XUser_XUser] FOREIGN KEY([UserID])
REFERENCES [XUser] ([UserID])
GO

ALTER TABLE [dbo].[BDEFerienanspruch_XUser] CHECK CONSTRAINT [FK_BDEFerienanspruch_XUser_XUser]
GO