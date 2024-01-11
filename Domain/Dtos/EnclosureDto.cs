namespace Zoo.Dtos
{
    public class EnclosureDto
    {
        public string name {  get; set; }
        public string size { get; set; }
        public string location { get; set; }
        public List<string> objects { get; set; }
    }
    
    public class EnclosuresWrapperDto
    {
        public List<EnclosureDto> enclosures { get; set; }
    }
}
