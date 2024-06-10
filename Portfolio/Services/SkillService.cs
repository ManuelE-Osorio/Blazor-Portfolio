using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class SkillService
{
    private readonly HttpClient _client;
    private readonly Task<List<Skill>?> _getSkillsTask;
    public SkillService(HttpClient client)
    {
        _client = client;
        _getSkillsTask =
            _client.GetFromJsonAsync<List<Skill>>(
                "projects-data/skills.json");
    }

    public async Task<List<Skill>?> GetSkillsAsync()
    {
        List<Skill>? skills;
        try
        {
            skills = await _getSkillsTask;
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
            skills = null;
        }
        return  skills;
    }
    
    public void Dispose() => _client.Dispose();
}