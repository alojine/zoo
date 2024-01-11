using Zoo.Data;
using Zoo.Dtos;
using Zoo.Enums;
using Zoo.Models;
using Zoo.Services.Interfaces;
using Zoo.Utils;

namespace Zoo.Services
{
    public class EnclosureService : IEnclosureService
    {
        private readonly DataContext _dataContext;

        public EnclosureService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Enclosure>> GetAllEnclosures()
        {
            return await _dataContext.Enclosures
                // .Include(e => e.Objects)
                .ToListAsync();
        }

        public async Task<List<EnclosureStructureDto>> GetEnclosuresWithAnimals()
        {
            var enclosures = await GetAllEnclosures();

            var enclosuresWithAnimals = enclosures.Select(enclosure => new EnclosureStructureDto
            {
                Name = enclosure.Name,
                Animals = enclosure.Animals?.Select(animal => animal.Species).ToList() ?? new List<string>(),
                Size = SizeHelper.ToString(enclosure.Size),
                Location = enclosure.isOutside ? "Outside" : "Inside",
                Objects = enclosure.Objects.Select(obj => obj.Name).ToList(),
            }).ToList();

            return enclosuresWithAnimals;
        }
        
        public async Task<List<Enclosure>> SaveEnclosures(List<EnclosureDto> enclosureDtoList)
        {
            var enclosures = enclosureDtoList.Select(enclosureDto => new Enclosure
            {
                Name = enclosureDto.name,
                Size = SizeHelper.ToEnum(enclosureDto.size),
                isOutside = enclosureDto.location == "Outside",
                Objects = enclosureDto.objects.Select(obj => new EnclosureObject { Name = obj }).ToList()
            }).ToList();

            _dataContext.Enclosures.AddRange(enclosures);
            await _dataContext.SaveChangesAsync();
            return enclosures;
        }
    }
}