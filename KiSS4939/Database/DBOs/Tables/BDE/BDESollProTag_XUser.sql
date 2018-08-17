CREATE TABLE [dbo].[BDESollProTag_XUser](
	[BDESollProTag_XUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[SollStundenProTag] [money] NOT NULL,
	[ManualEdit] [bit] NOT NULL CONSTRAINT [DF_BDESollProTag_XUser_ManualEdit]  DEFAULT ((0)),
	[BDESollProTag_XUserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDESollProTag_XUser] PRIMARY KEY CLUSTERED 
(
	[BDESollProTag_XUserID] ASC
) ON [PRIMARY],
 CONSTRAINT [IX_BDESollProTag_XUser] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[DatumVon] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BDESollProTag_XUser] ADD  CONSTRAINT [FK_BDESollProTag_XUser_XUser] FOREIGN KEY([UserID])
REFERENCES [XUser] ([UserID])
GO

ALTER TABLE [dbo].[BDESollProTag_XUser] CHECK CONSTRAINT [FK_BDESollProTag_XUser_XUser]
GO