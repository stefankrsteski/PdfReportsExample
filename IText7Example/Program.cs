using IText7Example.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace IText7Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = new Budget("First budget", new List<Transaction>() {
                    new Transaction(DateTime.Now, 1001, 11, "Lorem Ipsum is simply dummy text of the printing and typesetting"),
                    new Transaction(DateTime.Now, 1002, 12, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC"),
                    new Transaction(DateTime.Now, 1003, 13),
                    new Transaction(DateTime.Now, 1004, 14),
                    new Transaction(DateTime.Now, 1005, 15)});

            string filename = "Doc1.pdf";

            //Create new PDF document
            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
            PdfPTable table = new PdfPTable(4);

            // Relative col widths in proportions
            float[] widths = new float[] { 1,1,2,4 };
            table.SetWidths(widths);
            // Make the table as wide as the page
            table.WidthPercentage = 100;

            var font = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

            // Set a big cell at the top for showing the title
            PdfPCell cell = new PdfPCell(new Phrase($"Report for {budget.Title}", font));
            cell.Colspan = 4;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            // Reset the cell, so it doesn't keep the old formatting (mostly for removing the column span)
            cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            // Add the column headers
            cell.Phrase = new Phrase("Date", font);
            table.AddCell(cell);

            cell.Phrase = new Phrase("Amount", font);
            table.AddCell(cell);

            cell.Phrase = new Phrase("Coins", font);
            table.AddCell(cell);

            cell.Phrase = new Phrase("Note", font);
            table.AddCell(cell);

            // Add the rows with data
            foreach(var item in budget.Transactions)
            {
                cell.Phrase = new Phrase(item.Date.ToString());
                table.AddCell(cell);
                cell.Phrase = new Phrase(item.Amount.ToString());
                table.AddCell(cell);
                cell.Phrase = new Phrase(item.Coins.ToString());
                table.AddCell(cell);
                cell.Phrase = new Phrase(item.Note);
                table.AddCell(cell);
            }

            document.Open();
            document.Add(table);
            document.Close();

        }
    }
    
}
