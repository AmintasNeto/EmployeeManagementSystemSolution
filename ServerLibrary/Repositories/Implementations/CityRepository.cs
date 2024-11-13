using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CityRepository(AppDbContext appDbContext) : IGenerictRepositoryInterface<City>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var city = await appDbContext.Cities.FindAsync(id);
            if (city is null) return NotFound();

            appDbContext.Cities.Remove(city);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await appDbContext
            .Cities
            .AsNoTracking()
            .Include(c => c.Country)
            .ToListAsync();

        public async Task<City> GetById(int id) => await appDbContext.Cities.FindAsync(id);

        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name)) return new(false, "Department already created");
            appDbContext.Cities.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await appDbContext.Cities.FindAsync(item.Id);
            if (city is null) return NotFound();
            city.Name = item.Name;
            city.Country = item.Country;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, department not foun");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
