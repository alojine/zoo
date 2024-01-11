using Zoo.Dtos;
using Zoo.Models;

namespace Zoo.Services.Interfaces
{
    public interface IAnimalService
    {
        // Task<List<Animal>> AccomodateAnimals(List<AnimalDto> animalDtoList);
        Task AccomodateAnimals(List<AnimalDto> animalDtoList);
    }
}
