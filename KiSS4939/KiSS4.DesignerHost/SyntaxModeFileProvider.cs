using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;
using ICSharpCode.TextEditor.Document;

namespace KiSS4.DesignerHost
{
	public class SyntaxModeFileProvider
		:
		ISyntaxModeFileProvider
	{
		#region Fields and Properties

		ArrayList alSyntaxModes = new ArrayList();

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SyntaxModeFileProvider"/> class.
		/// </summary>
		public SyntaxModeFileProvider()
		{
			alSyntaxModes.Add(new SyntaxMode("TSQL-Mode.xshd", "SQL", "sql"));
			alSyntaxModes.Add(new SyntaxMode("CSharp-Mode-VSEnh.xshd", "CS", "cs"));
		}

		#endregion

		#region ISyntaxModeFileProvider Members

		/// <summary>
		/// Gets the syntax modes.
		/// </summary>
		/// <value>The syntax modes.</value>
		ArrayList ISyntaxModeFileProvider.SyntaxModes
		{
			get { return alSyntaxModes; }
		}

		XmlTextReader ISyntaxModeFileProvider.GetSyntaxModeFile(SyntaxMode syntaxMode)
		{
			return new XmlTextReader(GetEmbResStream(syntaxMode.FileName));
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Gets the embedded ressource stream.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		private static Stream GetEmbResStream(string name)
		{
			Assembly asm = typeof(SyntaxModeFileProvider).Assembly;

			return asm.GetManifestResourceStream(asm.GetName().Name + ".EmbeddedResources." + name);
		}

		#endregion
	}
}
