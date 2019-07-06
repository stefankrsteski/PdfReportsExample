using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharpExample.Models;
using System;
using System.Collections.Generic;

namespace PdfSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Budget> budgets = GenerateBudgets();
            var document = new Document();

            var section = document.AddSection();
            section.AddParagraph($"List of transactions in Budget with title {budgets[0].Title}");
            section.AddParagraph(); // Add an empty paragraph to make it look good

            float sectionWidth = (int)document.DefaultPageSetup.PageWidth - (int)document.DefaultPageSetup.LeftMargin - (int)document.DefaultPageSetup.RightMargin;
            float columnWidth = sectionWidth / 4; // Divide by 4 because we will have 4 columns

            var table = new Table();
            table.Borders.Width = 0.5;

            var column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;


            var row = table.AddRow();
            var cell = row.Cells[0];
            cell.AddParagraph("Date");
            cell.Format.Font.Bold = true;

            cell = row.Cells[1];
            cell.AddParagraph("Amount");
            cell.Format.Font.Bold = true;

            cell = row.Cells[2];
            cell.AddParagraph("Coins");
            cell.Format.Font.Bold = true;

            cell = row.Cells[3];
            cell.AddParagraph("Note");
            cell.Format.Font.Bold = true;

            foreach (var item in budgets[0].Transactions)
            {
                row = table.AddRow();

                cell = row.Cells[0];
                cell.VerticalAlignment = VerticalAlignment.Center;
                cell.AddParagraph(item.Date.ToString());

                cell = row.Cells[1];
                cell.VerticalAlignment = VerticalAlignment.Center;
                cell.AddParagraph(item.Amount.ToString());

                cell = row.Cells[2];
                cell.VerticalAlignment = VerticalAlignment.Center;
                cell.AddParagraph(item.Coins.ToString());

                cell = row.Cells[3];
                cell.VerticalAlignment = VerticalAlignment.Center;
                cell.AddParagraph(item.Note);
            }

            document.LastSection.Add(table);

            var pdfDocumentRenderer = new PdfDocumentRenderer(false);
            pdfDocumentRenderer.Document = document;
            pdfDocumentRenderer.RenderDocument();

            pdfDocumentRenderer.PdfDocument.Save("Table test.pdf");


        }

        private static List<Budget> GenerateBudgets()
        {
            return new List<Budget>() {
                new Budget("First budget", new List<Transaction>() {
                    new Transaction(DateTime.Now, 1001, 11, "Lorem Ipsum is simply dummy text of the printing and typesetting"),
                    new Transaction(DateTime.Now, 1002, 12, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC"),
                    new Transaction(DateTime.Now, 1003, 13),
                    new Transaction(DateTime.Now, 1004, 14),
                    new Transaction(DateTime.Now, 1005, 15)}),

                new Budget("Second budget", new List<Transaction>() {
                    new Transaction(DateTime.Now, 2001, 21),
                    new Transaction(DateTime.Now, 2002, 22),
                    new Transaction(DateTime.Now, 2003, 23),
                    new Transaction(DateTime.Now, 2004, 24)}),

                new Budget("Third budget", new List<Transaction>() {
                    new Transaction(DateTime.Now, 3001, 31),
                    new Transaction(DateTime.Now, 3002, 32),
                    new Transaction(DateTime.Now, 3003, 33)}),

                new Budget("Fourth budget", new List<Transaction>() {
                    new Transaction(DateTime.Now, 4001, 41),
                    new Transaction(DateTime.Now, 4002, 42)}),

                new Budget("Fifth budget", new List<Transaction>() {
                    new Transaction(DateTime.Now, 5000, 50)})};
        }
    }
}
