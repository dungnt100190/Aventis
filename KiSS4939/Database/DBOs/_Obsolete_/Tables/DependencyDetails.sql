Create Proc DependencyDetails (@TableName As Varchar(100)='')
As

SET NOCOUNT ON

Declare @MinTableID Int, @MaxTableID Int

IF Len(@TableName) = 0
	Begin
		Select @MinTableID = Min(ID), @MaxTableID = Max(ID) From SysObjects Where xType = 'U'	
	End
Else IF Len(@TableName) > 0
	Begin
		IF Exists (Select ID From SysObjects Where Name = @TableName And xType = 'U')
			Begin
				Select @MinTableID = ID, @MaxTableID = ID 
				From SysObjects Where Name = @TableName And xType = 'U'
			End
		Else
			Begin
				Print 'Passed parameter [' + @TableName + '] is not an User Table'
				Return 0
			End
	End
Select 
	Distinct SO.Name, SO1.Name "Referred Object", 'Select *' As "Used for" 
From 
	SysDepends SD, SysObjects SO, SysObjects SO1
Where 
	SO.ID = SD.DepID And 
	SelAll = 1 And
	SD.ID = SO1.ID And
	SD.DepID >= @MinTableID And SD.DepID <= @MaxTableID
Union 
Select 
	Distinct SO.Name, SO1.Name "Referred Object", 'Insert/Update/Delete' As "Used for" 
From 
	SysDepends SD, SysObjects SO, SysObjects SO1
Where 
	SO.ID = SD.DepID And 
	SD.ResultObj = 1  And
	SD.ID = SO1.ID And
	SD.DepID >= @MinTableID And SD.DepID <= @MaxTableID
Union 
Select 
	Distinct SO.Name, SO1.Name "Referred Object", 'Selected Columns' As "Used for" 
From 
	SysDepends SD, SysObjects SO, SysObjects SO1
Where 
	SO.ID = SD.DepID And 
	SD.ReadObj = 1  And
	SD.ID = SO1.ID And
	SD.DepID >= @MinTableID And SD.DepID <= @MaxTableID
Order By SO.Name

SET NOCOUNT OFF
GO