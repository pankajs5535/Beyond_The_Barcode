using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class BillOfMaterialsBomRepository : GenericRepository<BillOfMaterialsBom>, IBillOfMaterialsBomRepository
    {
        public BillOfMaterialsBomRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Get BOM by Version
        public async Task<BillOfMaterialsBom?> GetByVersionAsync(string version)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Bomversion == version);
        }

        // Get BOMs by Product
        public async Task<IEnumerable<BillOfMaterialsBom>> GetByProductAsync(int productId)
        {
            return await _dbSet
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        // Get BOMs by Raw Material
        public async Task<IEnumerable<BillOfMaterialsBom>> GetByRawMaterialAsync(int rawMaterialId)
        {
            return await _dbSet
                .Where(x => x.RawMaterialId == rawMaterialId)
                .ToListAsync();
        }

        // Search BOM
        public async Task<IEnumerable<BillOfMaterialsBom>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet
                .Where(x =>
                    x.Bomversion.ToLower().Contains(keyword) ||
                    x.Bomstatus.ToLower().Contains(keyword) ||
                    x.Uom.ToLower().Contains(keyword))
                .ToListAsync();
        }

        // Get Active BOMs
        public async Task<IEnumerable<BillOfMaterialsBom>> GetActiveAsync()
        {
            return await _dbSet
                .Where(x => x.EffectiveTo == null || x.EffectiveTo >= DateOnly.FromDateTime(DateTime.Today))
                .ToListAsync();
        }

        // Get BOMs by Effective Date
        public async Task<IEnumerable<BillOfMaterialsBom>> GetByEffectiveDateAsync(DateOnly fromDate, DateOnly toDate)
        {
            return await _dbSet
                .Where(x => x.EffectiveFrom >= fromDate &&
                            (x.EffectiveTo == null || x.EffectiveTo <= toDate))
                .ToListAsync();
        }

        // Check BOM Version Exists
        public async Task<bool> IsBomVersionExistsAsync(string version)
        {
            return await _dbSet.AnyAsync(x => x.Bomversion == version);
        }

        // Get Critical Components
        public async Task<IEnumerable<BillOfMaterialsBom>> GetCriticalComponentsAsync()
        {
            return await _dbSet
                .Where(x => x.IsCritical)
                .ToListAsync();
        }

        // Get Substitute Allowed BOMs
        public async Task<IEnumerable<BillOfMaterialsBom>> GetSubstituteAllowedAsync()
        {
            return await _dbSet
                .Where(x => x.SubstituteAllowed)
                .ToListAsync();
        }
    }
}