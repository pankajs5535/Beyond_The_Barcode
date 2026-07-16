using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class RawMaterialRepository : GenericRepository<RawMaterial>, IRawMaterialRepository
    {
        public RawMaterialRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Get Raw Material by Material Code
        public async Task<RawMaterial?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.MaterialCode == code);
        }

        // Get Raw Materials by Material Type
        public async Task<IEnumerable<RawMaterial>> GetByTypeAsync(string type)
        {
            return await _dbSet
                .Where(x => x.MaterialType == type && x.IsActive)
                .ToListAsync();
        }

        // Search by Code, Name, Grade, Specification, HSN, Country, Quality Standard
        public async Task<IEnumerable<RawMaterial>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet
                .Where(x =>
                    x.MaterialCode.ToLower().Contains(keyword) ||
                    x.MaterialName.ToLower().Contains(keyword) ||
                    (x.Grade ?? "").ToLower().Contains(keyword) ||
                    (x.Specification ?? "").ToLower().Contains(keyword) ||
                    (x.Hsncode ?? "").ToLower().Contains(keyword) ||
                    (x.CountryOfOrigin ?? "").ToLower().Contains(keyword) ||
                    (x.QualityStandard ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        // Get Active Raw Materials
        public async Task<IEnumerable<RawMaterial>> GetActiveAsync()
        {
            return await _dbSet
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        // Get Inactive Raw Materials
        public async Task<IEnumerable<RawMaterial>> GetInactiveAsync()
        {
            return await _dbSet
                .Where(x => !x.IsActive)
                .ToListAsync();
        }

        // Get Raw Materials created between two dates
        public async Task<IEnumerable<RawMaterial>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _dbSet
                .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate)
                .ToListAsync();
        }

        // Check duplicate Material Code
        public async Task<bool> IsMaterialCodeExistsAsync(string materialCode)
        {
            return await _dbSet
                .AnyAsync(x => x.MaterialCode == materialCode);
        }

        // Get Raw Materials below Reorder Point
        public async Task<IEnumerable<RawMaterial>> GetLowStockAsync()
        {
            return await _dbSet
                .Where(x => x.CurrentStock <= x.ReorderPoint)
                .ToListAsync();
        }

        // Get Raw Materials supplied by a specific Supplier
        public async Task<IEnumerable<RawMaterial>> GetBySupplierAsync(int supplierId)
        {
            return await _dbSet
                .Where(x => x.PrimarySupplierId == supplierId)
                .ToListAsync();
        }

        // Get Controlled Substance Raw Materials
        public async Task<IEnumerable<RawMaterial>> GetControlledSubstancesAsync()
        {
            return await _dbSet
                .Where(x => x.IsControlledSubstance)
                .ToListAsync();
        }
    }
}