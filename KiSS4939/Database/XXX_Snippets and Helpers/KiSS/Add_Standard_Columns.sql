/*
----------------------------------------------------------------------------
Script to Add the Columns Creater, Created, Modifier, Modified to a 
specified Table.

Copy the script to the Management Studio and use Ctrl + Shift + M 
to fill the Placeholders for TableName, CreatorName for the migration and
ModifierName for the migration.
----------------------------------------------------------------------------
*/

ALTER TABLE <TableName, VARCHAR, > ADD 
[Creator] [varchar](50) NOT NULL CONSTRAINT [DF_<TableName, VARCHAR, >_Creator] DEFAULT ('<CreatorName, VARCHAR,>'),
[Created] [datetime] NOT NULL CONSTRAINT [DF_<TableName, VARCHAR, >_Created]  DEFAULT (getdate()),
[Modifier] [varchar](50) NOT NULL CONSTRAINT [DF_<TableName, VARCHAR, >_Modifier] DEFAULT ('<ModifierName, VARCHAR,>'),
[Modified] [datetime] NOT NULL CONSTRAINT [DF_<TableName, VARCHAR, >_Modified]  DEFAULT (getdate())


ALTER TABLE <TableName, VARCHAR, >
DROP CONSTRAINT [DF_<TableName, VARCHAR, >_Creator]

ALTER TABLE <TableName, VARCHAR, >
DROP CONSTRAINT [DF_<TableName, VARCHAR, >_Modifier]
 