- Add a region "Methods" that contains the Equals and GetHashCode methods.
"
	region.Begin("Methods");
#>

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		
		if (ReferenceEquals(this, obj))
		{
			return true;
		}

		if (GetType() != obj.GetType())
		{
			return false;
		}

		var entity = (<#=code.Escape(entity)#>)obj;
<#
	var edmPropertyId = entity.Properties
		.Where(p => p.TypeUsage.EdmType is PrimitiveType && p.DeclaringType == entity)
		.Where(p => ef.IsKey(p));
	
	foreach(var prop in edmPropertyId)
	{
#>
		if (!<#=code.FieldName(prop)#>.Equals(entity.<#=code.Escape(prop)#>))
		{
			return false;
		}
		
<#
	}
#>		return true;
	}
	
	public override int GetHashCode()
    {
<#
	var hashCodes = from prop in edmPropertyId
		            select string.Format("{0}.GetHashCode()", code.FieldName(prop));
#>        return <#=string.Join(" ^ ", hashCodes.ToArray())#>;
    }
<#
    region.End();
"
- Implementation von INotifyPropertyChanged nach EntityBase verschoben
  Gesamter Code von OnPropertyChanged(String) und OnNavigationPropertyChanged(String) und
  das Property: ChangeTracker sowie HandleObjectStateChanging(object,...) nach EntityBase verschoben

- ClearNavigationProperties hat jetzt in jedem Fall die Signatur: protected override void ClearNavigationProperties()
  Da die Methode in EntityBase abstract definiert wurde, muss sie jetzt in jedem Fall mit override deklariert werden.
  Vorher musste unterschieden werden anhand der BaseClass, ob virtual oder override eingesetzt werden muss.
