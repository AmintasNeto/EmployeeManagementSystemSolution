using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class EmployeeRepository(AppDbContext appDbContext) : IGenerictRepositoryInterface<Employee>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            if (employee is null) return NotFound();

            appDbContext.Employees.Remove(employee);
            await Commit();
            return Success();
        }

        public async Task<List<Employee>> GetAll() => await appDbContext
            .Employees.AsNoTracking()
            .Include(t => t.Town)
            .ThenInclude(c => c.City)
            .ThenInclude(ct => ct.Country)
            .Include(b => b.Branch)
            .ThenInclude(d => d.Department)
            .ThenInclude(d => d.GeneralDepartment)
            .ToListAsync();

        public async Task<Employee> GetById(int id) => await appDbContext.Employees.FindAsync(id);

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (!await CheckName(item.Name)) return new(false, "Employee already Registered");
            appDbContext.Employees.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Employee item)
        {
            var findUser = await appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == item.Id);
            if (findUser is null) return new(false, "Employee does not exist");

            findUser.Name = item.Name;
            findUser.Other = item.Other;
            findUser.Address = item.Address;
            findUser.TelephoneNumber = item.TelephoneNumber;
            findUser.BranchId = item.BranchId;
            findUser.TownId = item.TownId;
            findUser.CivilId = item.CivilId;
            findUser.FileNumber = item.FileNumber;
            findUser.JobName = item.JobName;
            findUser.Photo = item.Photo;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, employee not foun");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
