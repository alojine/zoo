namespace Zoo.Dtos
{
    public class AnimalDto
    {
        public string species {  get; set; }
        public string food { get; set; }
        public int amount { get; set; } 
    }
    
    public class AnimalWrapperDto
    {
        public List<AnimalDto> animals { get; set; }
    }
}
