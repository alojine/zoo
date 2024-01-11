namespace Zoo.Models
{
    public class Animal
    {
        public int Id {  get; set; }
        public int EnclosureId { get; set; }
        public string Species { get; set; }
        public bool IsVegetarian { get; set; }
        public int Amount { get; set; }

        public virtual Enclosure Enclosure { get; set; }
    }
}
