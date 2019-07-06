using iText.Kernel.Pdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IText7Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "Doc1.pdf";

            //Create new PDF document
            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
            PdfPTable table = new PdfPTable(3);

            // Relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 2f, 4f, 6f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;

            // Leave a gap before and after the table
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;



            PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1; //0=Left, 1=Center, 2=Right

            table.AddCell(cell);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");


            document.Open();
            document.Add(table);
            document.Close();


        }
    }
    
}
