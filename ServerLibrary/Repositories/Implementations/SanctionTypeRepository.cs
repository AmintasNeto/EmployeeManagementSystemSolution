
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SanctionTypeRepository(AppDbContext appDbContext) : IGenerictRepositoryInterface<SanctionType>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var item = await appDbContext.SanctionTypes.FirstOrDefaultAsync(eid => eid.Id == id);
            if (item is null) return NotFound();

            appDbContext.SanctionTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<SanctionType>> GetAll() => await appDbContext
            .SanctionTypes
            .AsNoTracking()
            .ToListAsync();

        public async Task<SanctionType> GetById(int id) => await appDbContext.SanctionTypes.FirstOrDefaultAsync(eid => eid.Id == id);

        public async Task<GeneralResponse> Insert(SanctionType item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Sanction Type already added");
            appDbContext.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(SanctionType item)
        {
            var obj = await appDbContext.SanctionTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();

            obj.Name = item.Name;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, branch not foun");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.SanctionTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
