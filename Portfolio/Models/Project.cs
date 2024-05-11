namespace Portfolio.Models;

public class Project
{
    public string Framework {get; set;} = string.Empty;
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public string GifPath {get; set;} = string.Empty;
    public string GithubLink {get; set;} = string.Empty;
    public List<string> Skills {get; set;} = [];
}