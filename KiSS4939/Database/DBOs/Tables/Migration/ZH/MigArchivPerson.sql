CREATE TABLE [dbo].[MigArchivPerson](
	[MigArchivPersonID] [int] NOT NULL,
	[VorName] [varchar](50) NULL,
	[NachName] [varchar](50) NULL,
	[GeburtsDatum] [datetime] NULL,
	[GeschlechtsCode] [int] NULL,
	[GeschlechtsText] [varchar](50) NULL,
	[ZIP] [int] NULL,
	[RESO] [int] NULL,
	[RESOArchivNummer25] [varchar](50) NULL,
	[RESOArchivText25] [varchar](50) NULL,
	[RESOArchivNummer35] [varchar](50) NULL,
	[RESOArchivText35] [varchar](50) NULL,
	[RESOArchivNummer37] [varchar](50) NULL,
	[RESOArchivText37] [varchar](50) NULL,
	[VonDatum] [datetime] NULL,
	[BisDatum] [datetime] NULL,
	[FallArtCode] [int] NULL,
	[FallArtText] [varchar](50) NULL,
	[FallAlt] [bigint] NULL,
	[Herkunft] [varchar](50) NULL,
 CONSTRAINT [PK_MigArchivPerson] PRIMARY KEY CLUSTERED 
(
	[MigArchivPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON