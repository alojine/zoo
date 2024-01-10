using Zoo.Data;
using Zoo.Dtos;
using Zoo.Models;
using Zoo.Services.Interfaces;

namespace Zoo.Services
{
    public class EnclosureService : IEnclosureService
    {
        private readonly DataContext _dataContext;

        public EnclosureService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Enclosure>> SaveEnclosures(List<EnclosureDto> enclosureDtoList)
        {
            var enclosures = enclosureDtoList.Select(enclosureDto => new Enclosure
            {
                Name = enclosureDto.name,
                Size = enclosureDto.size,
                isOutside = enclosureDto.location == "Outside",
                Objects = enclosureDto.objects.Select(obj => new EnclosureObject { Name = obj }).ToList()
            }).ToList();

            _dataContext.Enclosures.AddRange(enclosures);
            await _dataContext.SaveChangesAsync();
            return enclosures;
        }
    }
}