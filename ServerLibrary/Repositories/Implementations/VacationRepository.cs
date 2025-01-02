using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class VacationRepository(AppDbContext appDbContext) : IGenerictRepositoryInterface<Vacation>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var item = await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Vacations.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Vacation>> GetAll() => await appDbContext
            .Vacations
            .AsNoTracking()
            .ToListAsync();

        public async Task<Vacation> GetById(int id) => await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

        public async Task<GeneralResponse> Insert(Vacation item)
        {
            appDbContext.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Vacation item)
        {
            var obj = await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();

            obj.StartDate = item.StartDate;
            obj.EndDate = item.EndDate;
            obj.VacationTypeId = item.VacationTypeId;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, branch not foun");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
