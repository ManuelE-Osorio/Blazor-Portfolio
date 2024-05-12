namespace Portfolio.Models;

public class Project
{
    public string? Framework {get; set;}
    public string? Name {get; set;}
    public string? Description {get; set;}
    public string? GifPath {get; set;}
    public string? GithubLink {get; set;}
    public List<string> Technologies {get; set;} = [];

    public Project(ProjectFromJson project, string name, string description)
    {
        Framework = project.Framework;
        Name = name;
        Description = description;
        GifPath = project.GifPath;
        GithubLink = project.GithubLink;
        Technologies = project.Technologies;
    }

}