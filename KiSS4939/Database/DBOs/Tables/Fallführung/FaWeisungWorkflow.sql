CREATE TABLE [dbo].[FaWeisungWorkflow] (
	[FaWeisungWorkflowID] [int] IDENTITY (1, 1) NOT NULL ,
	[XTaskTemplateID_RD] [int] NULL ,
	[XTaskTemplateID_SAR] [int] NULL ,
	[StatusCode] [int] NOT NULL ,
	[Aktion] [varchar] (100) NOT NULL ,
	[AktionTID] [int] NULL ,
	[NeuerStatusCode] [int] NOT NULL ,
	[ZustaendigCode] [int] NOT NULL CONSTRAINT [DF_FaWeisungWorkflow_Zustaendig] DEFAULT ((0)),
	[TerminMuss] [bit] NOT NULL ,
	[NaechsterTerminCode] [int] NULL ,
	[NaechsterTerminAnpassen] [bit] NOT NULL CONSTRAINT [DF_FaWeisungWorkflow_NaechsterTerminAnpassen] DEFAULT ((0)),
	[PendenzSAR] [bit] NOT NULL CONSTRAINT [DF_FaWeisungWorkflow_PendenzSAR] DEFAULT ((0)),
	[PendenzRD] [bit] NOT NULL CONSTRAINT [DF_FaWeisungWorkflow_PendenzRD] DEFAULT ((0)),
	[SARPendenzAnpassen] [bit] NOT NULL CONSTRAINT [DF_FaWeisungWorkflow_SARPendenzAnpassen] DEFAULT ((0)),
	[WeisungErfuellt] [bit] NOT NULL CONSTRAINT [DF_FaWeisungWorkflow_WeisungErfuellt] DEFAULT ((0)),
	[FaWeisungWorkflowTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaWeisungWorkflow] PRIMARY KEY  Clustered
	(
		[FaWeisungWorkflowID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_FaWeisungWorkflow_XTaskTemplate_RD] FOREIGN KEY
	(
		[XTaskTemplateID_RD]
	) REFERENCES [dbo].[XTaskTemplate] (
		[XTaskTemplateID]
	),
	CONSTRAINT [FK_FaWeisungWorkflow_XTaskTemplate_SAR] FOREIGN KEY
	(
		[XTaskTemplateID_SAR]
	) REFERENCES [dbo].[XTaskTemplate] (
		[XTaskTemplateID]
	),
	CONSTRAINT [CK_FaWeisungWorkflow_XTaskTemplateID_RD] CHECK (NOT ([PendenzRD]=(1) AND [XTaskTemplateID_RD] IS NULL)),
	CONSTRAINT [CK_FaWeisungWorkflow_XTaskTemplateID_SAR] CHECK (NOT (([PendenzSAR]=(1) OR [SARPendenzAnpassen]=(1)) AND [XTaskTemplateID_SAR] IS NULL))
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'beinhaltet Einträge für die Steuerung von Weisungen', N'user', N'dbo', N'table', N'FaWeisungWorkflow'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel vom Workflow-Eintrag', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'FaWeisungWorkflowID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Aktueller Status. Wert vom Enum FaWeisungStatus', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'StatusCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Aktion für den aktuellen Status', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'Aktion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'TID für die Mehrsprachigkeit der Aktion', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'AktionTID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Neuer Status der Weisung. Wert vom Enum FaWeisungStatus', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'NeuerStatusCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Person die für die Weisung Zuschtändig ist.
ZustaendigCode ist ein Enum (FaWeisung.Zustaendig)', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'ZustaendigCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Das nächste Termin ist ein Mussfeld', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'TerminMuss'
GO
EXEC sp_addextendedproperty N'MS_Description', N'TerminCode zum wissen in welchem Feld das nächste Termin kopiert sein muss.
TerminCode ist ein Enum (FaWeisung.Termin)', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'NaechsterTerminCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Zum wissen ob das Datum vom NaechstenTerminCode angepasst sein muss.', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'NaechsterTerminAnpassen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Eine Pendenz soll für den Sacharbeiter generiert werden (=1)', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'PendenzSAR'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Eine Pendenz soll für den Rechstdienst generiert werden (=1)', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'PendenzRD'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Die Pendenz vom SAR muss angepasst weden, und nicht neu erstellt (=1)', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'SARPendenzAnpassen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Zum wissen ob die Weisung nach dieser Aktion erfüllt ist.', N'user', N'dbo', N'table', N'FaWeisungWorkflow', N'column', N'WeisungErfuellt'
GO
