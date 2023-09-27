using ConferenceMauiDemo.Models;
using System.Diagnostics;
using System.Text;

namespace ConferenceMauiDemo.Services;

public class CsvExportService : IExportService
{
    public async Task ExportSessions(IEnumerable<Session> sessions)
    {
        var exportFile = Path.Combine(FileSystem.AppDataDirectory, "sessions.csv");
        using (var writer = new StreamWriter(exportFile,false, Encoding.UTF8))
        {
            await writer.WriteLineAsync("Session ID;Title;Speaker;Time;Room");
            foreach (var session in sessions)
            {
                await writer.WriteLineAsync($"{session.Id}; {session.Title}; {session.Speaker?.Name}; {session.Time}; {session.Location}");
            }
        }
        await Launcher.Default.OpenAsync(new OpenFileRequest("CSV Export öffnen", new ReadOnlyFile(exportFile)));
    }
}
