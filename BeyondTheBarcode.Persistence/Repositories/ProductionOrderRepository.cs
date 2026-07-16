using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class ProductionOrderRepository : GenericRepository<ProductionOrder>, IProductionOrderRepository
    {
        public ProductionOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ProductionOrder?> GetByOrderNumberAsync(string orderNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);
        }

        public async Task<IEnumerable<ProductionOrder>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<ProductionOrder>> GetByMachineAsync(int machineId)
        {
            return await _dbSet.Where(x => x.MachineId == machineId).ToListAsync();
        }

        public async Task<IEnumerable<ProductionOrder>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.OrderNumber.ToLower().Contains(keyword) ||
                x.BatchNumber.ToLower().Contains(keyword) ||
                (x.LotNumber ?? "").ToLower().Contains(keyword) ||
                x.OrderType.ToLower().Contains(keyword) ||
                x.Status.ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductionOrder>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<ProductionOrder>> GetByPriorityAsync(byte priority)
        {
            return await _dbSet.Where(x => x.Priority == priority).ToListAsync();
        }

        public async Task<IEnumerable<ProductionOrder>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate)
        {
            return await _dbSet.Where(x =>
                x.PlannedStartDate >= fromDate &&
                x.PlannedEndDate <= toDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductionOrder>> GetOpenOrdersAsync()
        {
            return await _dbSet.Where(x => x.Status != "Completed").ToListAsync();
        }

        public async Task<bool> IsOrderNumberExistsAsync(string orderNumber)
        {
            return await _dbSet.AnyAsync(x => x.OrderNumber == orderNumber);
        }
    }
}