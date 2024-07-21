namespace disneyland_scripts;

public record OutputRecord
{
    public string Name { get; set; }
    public string Park { get; set; }
    public string Land { get; set; }
    public string WantToGo { get; set; }
    public string DoNotCare { get; set; }
    public string DoNotWantToGo { get; set; }
}