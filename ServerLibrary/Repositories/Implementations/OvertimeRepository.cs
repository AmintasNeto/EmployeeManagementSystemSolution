using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class OvertimeRepository(AppDbContext appDbContext) : IGenerictRepositoryInterface<Overtime>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var item = await appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Overtimes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Overtime>> GetAll() => await appDbContext
            .Overtimes
            .AsNoTracking()
            .ToListAsync();

        public async Task<Overtime> GetById(int id) => await appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

        public async Task<GeneralResponse> Insert(Overtime item)
        {
            appDbContext.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Overtime item)
        {
            var obj = await appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();

            obj.OvertimeTypeId = item.OvertimeTypeId;
            obj.StartDate = item.StartDate;
            obj.EndDate = item.EndDate;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, branch not foun");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
