 /*
 This table is not intended to be in KiSS Standard.
 
 It's a temporary Solution till something happens. ;-)
 */
 
 CREATE TABLE [dbo].[XDBLine](
    [XDBLineID]    [int]          NOT NULL,
    [DatabaseName] [varchar](255) NOT NULL,
    [Kunde]        [varchar](255) NOT NULL,
	[ObjectName]   [varchar](255) NOT NULL,
	[ModulID]      [int]              NULL,
	[Description]  [text]             NULL,
	[Branch]       [varchar](128)     NULL,
	[BuildNr]      [int]              NULL,
	[XDBLineTS] [timestamp]       NOT NULL,
 CONSTRAINT [PK_XDBLine] PRIMARY KEY CLUSTERED 
(
	[XDBLineID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

