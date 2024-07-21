using CsvHelper.Configuration.Attributes;

namespace disneyland_scripts;

public record RideInfo
{
    public string Name { get; set; }
    public string Park { get; set; }
    public string Land { get; set; }
    [Name("Minimum height")]
    public string MinimumHeight { get; set; }
    public string Samuel { get; set; }
    public string Madeline { get; set; }
    public string Maxwell { get; set; }
    public string MJ { get; set; }
    public string Melissa { get; set; }
    public string Melinda { get; set; }
    public string Nadine { get; set; }
    public string Melody { get; set; }
}