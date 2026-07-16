using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class PickingPackingListRepository : GenericRepository<PickingPackingList>, IPickingPackingListRepository
    {
        public PickingPackingListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<PickingPackingList?> GetByNumberAsync(string pickPackNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.PickPackNumber == pickPackNumber);
        }

        public async Task<IEnumerable<PickingPackingList>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _dbSet.Where(x => x.SalesOrderId == salesOrderId).ToListAsync();
        }

        public async Task<IEnumerable<PickingPackingList>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<PickingPackingList>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.PickPackNumber.ToLower().Contains(keyword) ||
                x.BatchNumber.ToLower().Contains(keyword) ||
                (x.LotNumber ?? "").ToLower().Contains(keyword) ||
                x.Status.ToLower().Contains(keyword) ||
                (x.SealNumber ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<PickingPackingList>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<PickingPackingList>> GetReadyForDispatchAsync()
        {
            return await _dbSet.Where(x => x.DispatchReadyAt != null).ToListAsync();
        }

        public async Task<IEnumerable<PickingPackingList>> GetByPickerAsync(int pickerId)
        {
            return await _dbSet.Where(x => x.AssignedToPickerId == pickerId).ToListAsync();
        }

        public async Task<bool> IsPickPackNumberExistsAsync(string pickPackNumber)
        {
            return await _dbSet.AnyAsync(x => x.PickPackNumber == pickPackNumber);
        }
    }
}