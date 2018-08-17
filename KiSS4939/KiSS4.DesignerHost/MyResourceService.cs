using System.ComponentModel.Design;
using System.IO;
using System.Resources;

namespace KiSS4.DesignerHost
{
	/// Empty implementation of a ResourceService. Here is where you can control the way in which
	/// resources are read and written. This sample doesn't play with them though.
	public class MyResourceService : IResourceService
	{
		private ResourceReader reader;
		private MyResourceWriter writer = new MyResourceWriter();
		private IDesignerHost host;

		public MyResourceService(IDesignerHost host) 
		{
			this.host = host;
		}

		public bool SaveToFile(string FileName)
		{
			return writer.WriteToFile(FileName);
		}

		#region Implementation of IResourceService

		public System.Resources.IResourceReader GetResourceReader(System.Globalization.CultureInfo info)
		{				
			if (reader == null)
				reader = new ResourceReader(new MemoryStream());

			return reader;
		}

		public System.Resources.IResourceWriter GetResourceWriter(System.Globalization.CultureInfo info)
		{
			if (info.EnglishName == "Invariant Language (Invariant Country)")
				return writer;
			else
				return new ResourceWriter(new MemoryStream());
		}

		#endregion

		internal class MyResourceWriter : IResourceWriter
		{
			System.Collections.Hashtable htResources = new System.Collections.Hashtable();

			public bool WriteToFile(string FileName)
			{
				if (htResources.Count == 0) return false;

				ResourceWriter writer = new ResourceWriter(FileName);

				foreach (string name in htResources.Keys)
				{
					if (htResources[name] is byte[])
						writer.AddResource(name, (byte[])htResources[name]);
					else if (htResources[name] is string)
						writer.AddResource(name, (string)htResources[name]);
					else
						writer.AddResource(name, htResources[name]);
				}

				writer.Close();

				return true;
			}

			#region IResourceWriter Members

			public void Close()
			{
				// TODO:  Add MyResourceWriter.Close implementation
			}

			public void AddResource(string name, byte[] value)
			{
                htResources[name] = value;
			}

			void System.Resources.IResourceWriter.AddResource(string name, object value)
			{
                htResources[name] = value;
			}

			void System.Resources.IResourceWriter.AddResource(string name, string value)
			{
                htResources[name] = value;
			}

			public void Generate()
			{
				// TODO:  Add MyResourceWriter.Generate implementation
			}

			#endregion

			#region IDisposable Members

			public void Dispose()
			{
				// TODO:  Add MyResourceWriter.Dispose implementation
			}

			#endregion
		}
	}
}
