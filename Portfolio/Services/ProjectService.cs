using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class ProjectService
{
    private readonly HttpClient _client;
    private readonly Task<List<Project>?> _getProjectsTask;
    public ProjectService(HttpClient client)
    {
        _client = client;
        _getProjectsTask =
            _client.GetFromJsonAsync<List<Project>>(
                "projects-data/projects.json");
    }

    public async Task<List<Project>?> GetProjectsAsync()
    {
        List<Project>? projects;
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