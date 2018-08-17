using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KiSS4.Textmarken
{
    class Start
    {
        static void Main()
        {
            String filename = @"C:\Users\mboss\Desktop\tasktype.xlsx";
            BmExcelDocument xlsDoc = new BmExcelDocument(new FileInfo(filename));
        }
    }
}