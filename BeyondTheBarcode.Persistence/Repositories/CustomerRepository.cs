using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.CustomerCode == code);
        }

        public async Task<IEnumerable<Customer>> GetByTypeAsync(string type)
        {
            return await _dbSet.Where(x => x.CustomerType == type && x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.CustomerCode.ToLower().Contains(keyword) ||
                x.CustomerName.ToLower().Contains(keyword) ||
                (x.Gstnumber ?? "").ToLower().Contains(keyword) ||
                (x.Pannumber ?? "").ToLower().Contains(keyword) ||
                (x.Phone ?? "").ToLower().Contains(keyword) ||
                (x.ContactPersonName ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetActiveAsync()
        {
            return await _dbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetInactiveAsync()
        {
            return await _dbSet.Where(x => !x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetByZoneAsync(string zone)
        {
            return await _dbSet.Where(x => x.DistributionZone == zone).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetByRegionAsync(string region)
        {
            return await _dbSet.Where(x => x.RegionCode == region).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetBySalesRepAsync(int salesRepId)
        {
            return await _dbSet.Where(x => x.AssignedSalesRepId == salesRepId).ToListAsync();
        }

        public async Task<bool> IsCustomerCodeExistsAsync(string customerCode)
        {
            return await _dbSet.AnyAsync(x => x.CustomerCode == customerCode);
        }
    }
}