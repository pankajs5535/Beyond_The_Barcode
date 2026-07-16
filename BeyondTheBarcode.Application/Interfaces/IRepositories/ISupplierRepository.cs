using BeyondTheBarcode.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTheBarcode.Application.Interfaces.IRepositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        // Get Supplier by Supplier Code
        Task<Supplier?> GetByCodeAsync(string code);

        // Get Approved & Active Suppliers
        Task<IEnumerable<Supplier>> GetApprovedSuppliersAsync();

        // Get Suppliers by Type
        Task<IEnumerable<Supplier>> GetByTypeAsync(string type);

        // Enterprise Search (Code, Name, GST, PAN, Phone, Contact Person)
        Task<IEnumerable<Supplier>> SearchAsync(string keyword);

        // Active / Inactive
        Task<IEnumerable<Supplier>> GetActiveSuppliersAsync();

        Task<IEnumerable<Supplier>> GetInactiveSuppliersAsync();

        // Date Range
        Task<IEnumerable<Supplier>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);

        // Duplicate Validation
        Task<bool> IsSupplierCodeExistsAsync(string supplierCode);

        Task<bool> IsGstNumberExistsAsync(string gstNumber);

        Task<bool> IsPanNumberExistsAsync(string panNumber);

    }
}
