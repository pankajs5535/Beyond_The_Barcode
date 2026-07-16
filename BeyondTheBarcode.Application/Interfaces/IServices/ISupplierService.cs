using BeyondTheBarcode.Application.DTOs.SupplierDtos;

namespace BeyondTheBarcode.Application.Interfaces.IServices
{
    public interface ISupplierService
    {
        // CRUD
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto?> GetByIdAsync(int id);
        Task<SupplierDto?> GetByCodeAsync(string code);

        Task AddAsync(CreateSupplierDto supplier);
        Task UpdateAsync(UpdateSupplierDto supplier);
        Task DeleteAsync(int id);

        //Delete Multiple Rows
        Task DeleteMultipleAsync(DeleteMultipleSuppliersDto dto);


        // Custom Methods
        Task<IEnumerable<SupplierDto>> GetApprovedSuppliersAsync();
        Task<IEnumerable<SupplierDto>> GetByTypeAsync(string type);
        Task<IEnumerable<SupplierDto>> SearchAsync(string keyword);
        Task<IEnumerable<SupplierDto>> GetActiveSuppliersAsync();
        Task<IEnumerable<SupplierDto>> GetInactiveSuppliersAsync();
        Task<IEnumerable<SupplierDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);

        // Validation
        Task<bool> IsSupplierCodeExistsAsync(string supplierCode);
        Task<bool> IsGstNumberExistsAsync(string gstNumber);
        Task<bool> IsPanNumberExistsAsync(string panNumber);
    }
}