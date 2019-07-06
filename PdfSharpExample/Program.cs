using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharpExample.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PdfSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Budget> budgets = GenerateBudgets();
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 20);
            gfx.DrawString("Test of PdfSharp", font, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 130);
            document.Save(Path.Combine("test.pdf"));

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
