using Zoo.Dtos;
using Zoo.Models;

namespace Zoo.Services.Interfaces
{
    public interface IEnclosureService
    {
        Task<List<Enclosure>> SaveEnclosures(List<EnclosureDto> enclosureDtoList);
    }
}
