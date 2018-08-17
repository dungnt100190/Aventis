USE [KiSS4_BSS_Demo]
GO
/*
Skript zum Aufrufen von spCopyFall.
Kopiert alle Personen in einem bestimmten ID-Bereich i-mal. Unbedingt Werte vor Gebrauch anpassen!
*/

declare @PersonID int
declare @i int
DECLARE	@return_value int
declare @postfix varchar(255)

--set @PersonID=64805
--while @PersonID<=64810
set @PersonID=64812
while @PersonID<=64820
begin
	set @i=1

	while @i<=10
	begin
		set @postfix='_'+convert(varchar, @i)

		EXEC	@return_value = [dbo].[spCopyFall]
				@BaPersonID = @PersonID,
				@KlientNamePostfix = @postfix

		--SELECT	'Return Value' = @return_value
		set @i = @i+1
	end

	set @PersonID=@PersonID+1
end
GO

/*
64805
64806
64807
64808
64809
64810
64812
64813
64814
64815
64816
64817
64818
64819
64820
*/