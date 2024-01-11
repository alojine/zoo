using Zoo.Enums;

namespace Zoo.Models
{
    public class Enclosure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Size Size { get; set; }
        public bool isOutside { get; set; }
        public List<EnclosureObject> Objects { get; set; }
        
        public virtual List<Animal> Animals { get; set; }
    }
    
    public class EnclosureObject
    {
        public string Name { get; set; }
    }
}
