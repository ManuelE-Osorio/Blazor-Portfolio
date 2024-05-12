using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class ProjectService
{
    private readonly HttpClient _client;
    private readonly Task<List<ProjectFromJson>?> _getProjectsTask;
    public ProjectService(HttpClient client)
    {
        _client = client;
        _getProjectsTask =
            _client.GetFromJsonAsync<List<ProjectFromJson>>(
                "projects-data/projects.json");
    }

    public async Task<List<ProjectFromJson>?> GetProjectsAsync()
    {
        List<ProjectFromJson>? projects;
        try
        {
            projects = await _getProjectsTask;
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
            projects = null;
        }
        return  projects;
    }
    
    public void Dispose() => _client.Dispose();
}