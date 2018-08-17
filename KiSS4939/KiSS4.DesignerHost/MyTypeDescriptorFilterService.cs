//------------------------------------------------------------------------------
/// <copyright from='1997' to='2002' company='Microsoft Corporation'>
///    Copyright (c) Microsoft Corporation. All Rights Reserved.
///
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>
//------------------------------------------------------------------------------
using System.ComponentModel;
using System.ComponentModel.Design;

namespace KiSS4.DesignerHost
{
	/// This service relays requests for filtering a component's exposed
	/// attributes, properties, and events to that component's designer.
	public class MyTypeDescriptorFilterService : ITypeDescriptorFilterService
	{
		public IDesignerHost host;

		public MyTypeDescriptorFilterService(IDesignerHost host)
		{
			this.host = host;
		}

		/// Get the designer for the given component and cast it as a designer filter.
		private IDesignerFilter GetDesignerFilter(IComponent component)
		{
			return host.GetDesigner(component) as IDesignerFilter;
		}

		#region Implementation of ITypeDescriptorFilterService
		/// Tell the given component's designer to filter properties.
		public bool FilterProperties(System.ComponentModel.IComponent component, System.Collections.IDictionary properties)
		{
			IDesignerFilter filter = GetDesignerFilter(component);
			if (filter != null)
			{
				filter.PreFilterProperties(properties);

				// Remove general unused Properties
				properties.Remove("AccessibleDescription");
				properties.Remove("AccessibleName");
				properties.Remove("AccessibleRole");

				properties.Remove("Locked");

				properties.Remove("DataBindings");
				
				properties.Remove("Language");
				properties.Remove("Localizable");


				filter.PostFilterProperties(properties);
				return true;
			}
			return false;
		}

		/// Tell the given component's designer to filter attributes.
		public bool FilterAttributes(System.ComponentModel.IComponent component, System.Collections.IDictionary attributes)
		{
			IDesignerFilter filter = GetDesignerFilter(component);
			if (filter != null)
			{
				filter.PreFilterAttributes(attributes);
				filter.PostFilterAttributes(attributes);
				return true;
			}
			return false;
		}

		/// Tell the given component's designer to filter events.
		public bool FilterEvents(System.ComponentModel.IComponent component, System.Collections.IDictionary events)
		{
			IDesignerFilter filter = GetDesignerFilter(component);
			if (filter != null)
			{
				filter.PreFilterEvents(events);
				filter.PostFilterEvents(events);
				return true;
			}
			return false;
		}
		#endregion
	}
}
