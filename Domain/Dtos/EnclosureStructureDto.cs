using Zoo.Enums;

namespace Zoo.Dtos;

public class EnclosureStructureDto
{
    public string Name {  get; set; }
    public List<string> Animals { get; set; }
    public string Size { get; set; }
    public string Location { get; set; }
    public List<string> Objects { get; set; }
}