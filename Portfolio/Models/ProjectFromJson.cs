namespace Portfolio.Models;

public class ProjectFromJson
{
    public string? Framework {get; set;}
    public int? Id {get; set;}
    public string? GifPath {get; set;}
    public string? GithubLink {get; set;}
    public List<string> Technologies {get; set;} = [];
}