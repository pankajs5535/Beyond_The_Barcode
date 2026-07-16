using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Supplier?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.SupplierCode == code);
        }

        public async Task<IEnumerable<Supplier>> GetApprovedSuppliersAsync()
        {
            return await _dbSet
                .Where(x => x.IsApproved && x.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetByTypeAsync(string type)
        {
            return await _dbSet
                .Where(x => x.SupplierType == type && x.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetActiveSuppliersAsync()
        {
            return await _dbSet
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetInactiveSuppliersAsync()
        {
            return await _dbSet
                .Where(x => !x.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _dbSet
                .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate)
                .ToListAsync();
        }

        public async Task<bool> IsSupplierCodeExistsAsync(string supplierCode)
        {
            return await _dbSet
                .AnyAsync(x => x.SupplierCode == supplierCode);
        }

        public async Task<bool> IsGstNumberExistsAsync(string gstNumber)
        {
            return await _dbSet
                .AnyAsync(x => x.Gstnumber == gstNumber);
        }

        public async Task<bool> IsPanNumberExistsAsync(string panNumber)
        {
            return await _dbSet
                .AnyAsync(x => x.Pannumber == panNumber);
        }

        public async Task<IEnumerable<Supplier>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet
                .Where(x =>
                    x.SupplierCode.ToLower().Contains(keyword) ||
                    x.SupplierName.ToLower().Contains(keyword) ||
                    x.Gstnumber.ToLower().Contains(keyword) ||
                    x.Pannumber.ToLower().Contains(keyword) ||
                    x.Phone.ToLower().Contains(keyword) ||
                    x.ContactPersonName.ToLower().Contains(keyword))
                .ToListAsync();
        }
    }
}


/*

SupplierRepository Explanation

1. SupplierRepository(ApplicationDbContext context)
Purpose: Receives ApplicationDbContext through Dependency Injection and passes it to GenericRepository using base(context). GenericRepository initializes _context and _dbSet, so SupplierRepository can directly use _dbSet for database operations.

2. GetByCodeAsync(string code)
Purpose: Returns a single supplier using its unique SupplierCode.
Example: SUP0001
Used when viewing supplier details or validating supplier codes before creating Purchase Orders.

3. GetApprovedSuppliersAsync()
Purpose: Returns only suppliers where IsApproved = true and IsActive = true.
Used by the Purchase Department so only approved suppliers are available for procurement.

4. GetByTypeAsync(string type)
Purpose: Returns suppliers based on SupplierType.
Example: Raw Tobacco Leaf, Packaging Material, Filter Supplier, Chemical Supplier.
Used to filter suppliers according to business requirements.

5. GetActiveSuppliersAsync()
Purpose: Returns all active suppliers (IsActive = true).
Used for dropdowns, purchase orders, and daily operations.

6. GetInactiveSuppliersAsync()
Purpose: Returns all inactive suppliers (IsActive = false).
Used by Admin to review or reactivate suppliers.

7. GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
Purpose: Returns suppliers created between the given dates using CreatedAt.
Used for reports like "Suppliers added this month" or audit reports.

8. IsSupplierCodeExistsAsync(string supplierCode)
Purpose: Checks whether a SupplierCode already exists.
Used before inserting a new supplier to avoid duplicate supplier codes.

9. IsGstNumberExistsAsync(string gstNumber)
Purpose: Checks whether a GST Number already exists.
Used to prevent duplicate GST registrations.

10. IsPanNumberExistsAsync(string panNumber)
Purpose: Checks whether a PAN Number already exists.
Used to ensure every supplier has a unique PAN.

11. SearchAsync(string keyword)
Purpose: Performs enterprise-level multi-column search using a single search box.
Searches in:
• SupplierCode
• SupplierName
• Gstnumber
• Pannumber
• Phone
• ContactPersonName
Example: If the user enters "Rajesh", "SUP0001", "27ABCDE", or a phone number, the matching supplier records are returned.

Why SupplierRepository?
GenericRepository contains common CRUD operations (GetAll, GetById, Add, Update, Delete, Exists, Count). SupplierRepository contains Supplier-specific business logic that cannot be shared with other entities. This follows the Repository + Unit of Work pattern used in enterprise applications.

   
*/