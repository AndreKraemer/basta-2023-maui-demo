using ConferenceMauiDemo.Models;
using System.Diagnostics;

namespace ConferenceMauiDemo.Services;

public interface IExportService
{
    Task ExportSessions(IEnumerable<Session> sessions);
}
