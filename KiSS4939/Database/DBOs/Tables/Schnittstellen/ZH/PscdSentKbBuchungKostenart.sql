CREATE TABLE [dbo].[PscdSentKbBuchungKostenart](
	[KbBuchungKostenartID] [int] NOT NULL,
	[KbBuchungKostenartTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL,
 CONSTRAINT [PK_PscdSentKbBuchungKostenart] PRIMARY KEY CLUSTERED 
(
	[KbBuchungKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON