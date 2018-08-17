CREATE TABLE [dbo].[IkAlvAusgleichBuffer](
	[IkAlvAusgleichBufferID] [int] IDENTITY(1,1) NOT NULL,
	[OpKbBuchungID] [int] NOT NULL,
	[AusgleichBetrag] [money] NULL,
	[KreditorKtoNr] [varchar](50) NULL,
	[Fehlermeldung] [varchar](200) NULL,
 CONSTRAINT [PK_IkAlvAusgleichBuffer] PRIMARY KEY CLUSTERED 
(
	[IkAlvAusgleichBufferID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON