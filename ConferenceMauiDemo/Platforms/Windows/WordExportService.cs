using ConferenceMauiDemo.Models;
using ConferenceMauiDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceMauiDemo.Platforms.Windows
{
    public class WordExportService : IExportService
    {
        public Task ExportSessions(IEnumerable<Session> sessions)
        {

            try
            {
                // Neues Word-Dokument   
                var word = new Microsoft.Office.Interop.Word.Application
                {
                    Visible = true
                };
                var doc = word.Documents.Add();

                // Create a table in the word document with all the sessions
                var table = doc.Tables.Add(doc.Range(0, 0), sessions.Count(), 5);
                table.Borders.Enable = 1;
                table.Cell(1, 1).Range.Bold = 1;
                table.Cell(1, 1).Range.Text = "Session ID";
                table.Cell(1, 2).Range.Bold = 1;
                table.Cell(1, 2).Range.Text = "Title";
                table.Cell(1, 3).Range.Bold = 1;
                table.Cell(1, 3).Range.Text = "Speaker";
                table.Cell(1, 4).Range.Bold = 1;
                table.Cell(1, 4).Range.Text = "Time";
                table.Cell(1, 5).Range.Bold = 1;
                table.Cell(1, 5).Range.Text = "Room";
                var row = 2;
                table.Cell(2, 1).Range.Bold = 0;
                foreach (var session in sessions)
                {
                    table.Cell(row, 1).Range.Text = session.Id.ToString();
                    table.Cell(row, 2).Range.Text = session.Title;
                    table.Cell(row, 3).Range.Text = session.Speaker?.Name;
                    table.Cell(row, 4).Range.Text = session.Time;
                    table.Cell(row, 5).Range.Text = session.Location;
                    row++;
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return Task.CompletedTask;

        }
    }
}
