using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using KiSS4.Gui;
using System.Windows.Forms;
using KiSS4.Messages;

namespace KiSS4.Dokument.ExcelAutomation
{
	/// <summary>
	/// 
	/// </summary>
	public class ExcelDocument : IDisposable
	{
		/// <summary>
		/// The Log4Net logger.
		/// </summary>
		private static readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private ExcelControl excelControl;
		private FileInfo documentFileInfo;
		private bool isTemporary;
		private bool disposed = false;

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ExcelDocument"/> class.
		/// </summary>
		/// <param name="templateFileInfo">The template file info.</param>
		/// <param name="docFileInfo">The doc file info.</param>
		/// <param name="context">The context.</param>
		public ExcelDocument(FileInfo templateFileInfo, FileInfo docFileInfo, IKissContext context)
		{
			excelControl = new ExcelControl(true);
			isTemporary = true;
			documentFileInfo = docFileInfo;

			excelControl.CreateDocumentFromTemplate(templateFileInfo, docFileInfo);
			Application.DoEvents();
		}

		#endregion

		#region Release & Disposing ...
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="ExcelDocument"/> is reclaimed by garbage collection.
		/// </summary>
		~ExcelDocument()
		{
			this.Dispose(false);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
		}



		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		private void Dispose(bool disposing)
		{
			if (this.disposed) return;
			try
			{
				if (disposing)
					GC.SuppressFinalize(this);
				if (this.isTemporary)
				{
					documentFileInfo.Delete();
				}
			}
			catch (Exception ex)
			{
				logger.Warn(ex);
			}
			finally
			{
				this.disposed = true;
			}
		}

		#endregion

		#region Businesslogic

		/// <summary>
		/// Gets the doc file info.
		/// </summary>
		/// <value>The doc file info.</value>
		public FileInfo DocFileInfo
		{
			get { return documentFileInfo; }
		}

		internal void CloseDocument()
		{
			if (excelControl == null) return;
			excelControl.CloseDocument();
			Application.DoEvents();
		}

		internal void RemoveDocumentFromFileSystem()
		{
			DlgProgressLog.AddLine(String.Format("Temporäres File: {0} wird vom Filesystem entfernt", documentFileInfo.FullName));
			documentFileInfo.Delete();
		}

		internal void QuitExcel()
		{
			if (excelControl == null) return;
			excelControl.Quit();
		}

		#endregion
	}
}
