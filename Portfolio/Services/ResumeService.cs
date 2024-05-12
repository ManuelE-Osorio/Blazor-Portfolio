using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class ResumeService
{
    private readonly HttpClient _client;
    private readonly Task<List<ResumeFromJson>?> _getResumeQtyTask;
    public ResumeService(HttpClient client)
    {
        _client = client;
        _getResumeQtyTask =
            _client.GetFromJsonAsync<List<ResumeFromJson>>(
                "projects-data/resume.json");
    }

    public async Task<ResumeFromJson?> GetResumeQtyAsync()
    {
        List<ResumeFromJson>? projects;
        try
        {
            projects = await _getResumeQtyTask;
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
            projects = null;
        }
        return  projects?.FirstOrDefault();
    }
    
    public void Dispose() => _client.Dispose();
}