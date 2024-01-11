using Zoo.Data;
using Zoo.Dtos;
using Zoo.Models;
using Zoo.Services.Interfaces;
using Zoo.Utils;

namespace Zoo.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly DataContext _dataContext;

        private readonly IEnclosureService _enclosureService;

        public AnimalService(DataContext dataContext, IEnclosureService enclosureService)
        {
            _dataContext = dataContext;
            _enclosureService = enclosureService;
        }

        private async Task<Animal> SaveAnimal(Animal animal)
        {
            _dataContext.Animals.Add(animal);
            await _dataContext.SaveChangesAsync();
            return animal;
        }

        private async Task<Animal> AssignAnimalToEnclosure(Animal animal, Enclosure enclosure)
        {
            animal.EnclosureId = enclosure.Id;
            return await SaveAnimal(animal);
        }
        
        public async Task AccomodateAnimals(List<AnimalDto> animalDtoList)
        {
            var sortedAnimalDtoList = animalDtoList.OrderByDescending(a => a.amount).ToList();
            Console.WriteLine("got sorted animal list");
            foreach (var animalDto in sortedAnimalDtoList)
            {
                var enclosures = await _enclosureService.GetAllEnclosures();
                Console.WriteLine("got All enclosures");
                var animal = new Animal
                {
                    Species = animalDto.species,
                    IsVegetarian = animalDto.food == "Herbivore",
                    Amount = animalDto.amount,
                };
                
                var suitableEnclosure = await FindSuitableEnclosure(animal, enclosures.ToList());
                Console.WriteLine("Found suitable encolure");
                if (suitableEnclosure != null)
                {
                    await AssignAnimalToEnclosure(animal, suitableEnclosure);
                }
                
                else
                {
                    if (animal.IsVegetarian)
                    {
                        /*animal.IsVegetarian = true;
                        foreach (var enclosure in enclosures)
                        {
                            if (SizeHelper.IsConsideredBig(enclosure.Size) && enclosure.Animals == null || enclosure.Animals.Contains())
                            {

                            }
                        }*/
                    
                    }
                    else
                    {
                    
                    }
                }
            }
        }

        private async Task<Enclosure> FindSuitableEnclosure(Animal animal, List<Enclosure> enclosures)
        {
            // Same species together
            var sameSpeciesEnclosure =
                enclosures.FirstOrDefault(e => e.Animals?.Any(a => a.Species == animal.Species) == true);
            if (sameSpeciesEnclosure != null)
            {
                return sameSpeciesEnclosure;
            }
            
            // Herbivore animals. there will be a lot of herbivores together so they must go into a big meaning(Large, Huge) enclosure
            if (animal.IsVegetarian)
            {
                var herbivoreEnclosure = enclosures.FirstOrDefault(e =>
                    SizeHelper.IsConsideredBig(e.Size) && (e.Animals == null || e.Animals.All(a => a.IsVegetarian)));
                /*if (AmountHelper.IsConsideredMany(animal.Species == ))
                {
                }*/

                if (herbivoreEnclosure != null)
                {
                    return herbivoreEnclosure;
                }
            }
            
            // Carnivore animals
            else
            {
                // 4 or more
                if (AmountHelper.IsConsideredMany(animal.Amount))
                {
                    var carnivoreEnclosureForManny =
                        enclosures.FirstOrDefault(e => SizeHelper.IsConsideredBig(e.Size) && e.Animals == null);
                        
                    if (carnivoreEnclosureForManny != null)
                    {
                        return carnivoreEnclosureForManny;
                    }
                }
                // 3 or less
                else
                {
                    var carnivoreEnclosureForFew =
                        enclosures.FirstOrDefault(e => !SizeHelper.IsConsideredBig(e.Size) && e.Animals == null);
                    
                    if (carnivoreEnclosureForFew != null)
                    {
                        return carnivoreEnclosureForFew;
                    }
                }
            }

            return null;
        }
    }
}
