namespace Zoo.Models
{
    public class Enclosure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public bool isOutside { get; set; }
        public List<EnclosureObject> Objects { get; set; }
    }
    
    public class EnclosureObject
    {
        public string Name { get; set; }
    }
}
