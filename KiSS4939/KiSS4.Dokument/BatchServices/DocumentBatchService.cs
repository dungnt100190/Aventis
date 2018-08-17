//using System;
//using System.Collections.Generic;
//using System.Text;
//using KiSS4.DB;
//using KiSS4.Gui;

//namespace KiSS4.Dokument.BatchServices
//{
//   /// <summary>
//   /// 
//   /// </summary>
//   public class DocumentBatchService
//   {
//      private static DocumentBatchService instance;

//      private DocumentProcessor documentProcessor;

//      #region Instance Control
//      /// <summary>
//      /// Initializes a new instance of the <see cref="DocumentBatchService"/> class.
//      /// </summary>
//      private DocumentBatchService()
//      { }

//      /// <summary>
//      /// Gets the instance.
//      /// </summary>
//      /// <value>The instance.</value>
//      public static DocumentBatchService Instance
//      {
//         get
//         {
//            if (instance == null)
//            {
//               instance = new DocumentBatchService();
//            }
//            return instance;
//         }
//      }

//      #endregion


//      /// <summary>
//      /// Gets or sets the document processor.
//      /// </summary>
//      /// <value>The document processor.</value>
//      internal DocumentProcessor DocumentProcessor
//      {
//         get
//         {
//            if (documentProcessor == null)
//            {
//               documentProcessor = new DocumentProcessor();
//            }
//            return documentProcessor;
//         }
//         set { documentProcessor = value; }
//      }

//      /// <summary>
//      /// Creates the documents.
//      /// </summary>
//      /// <param name="templateId">The template id.</param>
//      /// <param name="listOfKisKontexts">The list of kis kontexts.</param>
//      public void CreateDocuments(object templateId, IList<IKissContext> listOfKisKontexts)
//      {
//         DocumentProcessor.CreateDocumentsForContextList(templateId, listOfKisKontexts);
//      }

//      /// <summary>
//      /// Signs the documents.
//      /// </summary>
//      /// <param name="signText">The sign text.</param>
//      /// <param name="listOfDocumentIds">The list of document ids.</param>
//      public void SignDocuments(String signText, IList<String> listOfDocumentIds, IKissContextEdit context)
//      {
//         context.AddContextValue("POSTSignature", signText);
//         DocumentProcessor.SignDocuments(context, listOfDocumentIds);
//      }
//   }
//}
