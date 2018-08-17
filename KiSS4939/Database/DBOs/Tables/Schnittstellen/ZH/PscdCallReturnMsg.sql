CREATE TABLE [dbo].[PscdCallReturnMsg](
	[PscdCallReturnMsgID] [bigint] IDENTITY(1,1) NOT NULL,
	[PscdCallID] [bigint] NULL,
	[Severity] [char](1) NULL,
	[MessageClass] [varchar](20) NULL,
	[MessageNumber] [int] NULL,
	[Message] [varchar](220) NULL,
	[LogNr] [varchar](20) NULL,
	[LogNrInternal] [bigint] NULL,
	[Message1] [varchar](50) NULL,
	[Message2] [varchar](50) NULL,
	[Message3] [varchar](50) NULL,
	[Message4] [varchar](50) NULL,
	[Parameter] [varchar](32) NULL,
	[Row] [int] NULL,
	[Field] [varchar](30) NULL,
	[CausingSystem] [varchar](10) NULL,
 CONSTRAINT [PK_PscdReturnMsg] PRIMARY KEY CLUSTERED 
(
	[PscdCallReturnMsgID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_PscdCallReturnMsg_PscdCallID]    Script Date: 11/23/2011 16:24:18 ******/
CREATE NONCLUSTERED INDEX [IX_PscdCallReturnMsg_PscdCallID] ON [dbo].[PscdCallReturnMsg] 
(
	[PscdCallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PscdCallReturnMsg]  WITH CHECK ADD  CONSTRAINT [FK_PscdCallReturnMsg_PscdCall] FOREIGN KEY([PscdCallID])
REFERENCES [dbo].[PscdCall] ([PscdCallID])
GO
ALTER TABLE [dbo].[PscdCallReturnMsg] CHECK CONSTRAINT [FK_PscdCallReturnMsg_PscdCall]