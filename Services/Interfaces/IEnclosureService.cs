using Zoo.Dtos;
using Zoo.Models;

namespace Zoo.Services.Interfaces
{
    public interface IEnclosureService
    {
        Task<List<Enclosure>> GetAllEnclosures();
        Task<List<EnclosureStructureDto>> GetEnclosuresWithAnimals();
        Task<List<Enclosure>> SaveEnclosures(List<EnclosureDto> enclosureDtoList);
    }
}
