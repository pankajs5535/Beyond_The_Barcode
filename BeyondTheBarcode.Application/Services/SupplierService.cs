using BeyondTheBarcode.Application.DTOs.SupplierDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IServices;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static SupplierDto MapToDto(Supplier supplier)
        {
            return new SupplierDto
            {
                SupplierId = supplier.SupplierId,
                SupplierCode = supplier.SupplierCode,
                SupplierName = supplier.SupplierName,
                SupplierType = supplier.SupplierType,
                ContactPersonName = supplier.ContactPersonName,
                Email = supplier.Email,
                Phone = supplier.Phone,
                AlternatePhone = supplier.AlternatePhone,
                Address = supplier.Address,
                City = supplier.City,
                State = supplier.State,
                Country = supplier.Country,
                PostalCode = supplier.PostalCode,
                Gstnumber = supplier.Gstnumber,
                Pannumber = supplier.Pannumber,
                LicenseNumber = supplier.LicenseNumber,
                LicenseType = supplier.LicenseType,
                LicenseExpiryDate = supplier.LicenseExpiryDate,
                BankAccountNumber = supplier.BankAccountNumber,
                BankIfsccode = supplier.BankIfsccode,
                BankName = supplier.BankName,
                LeadTimeDays = supplier.LeadTimeDays,
                CreditLimit = supplier.CreditLimit,
                CreditDays = supplier.CreditDays,
                PaymentTerms = supplier.PaymentTerms,
                QualityRating = supplier.QualityRating,
                IsApproved = supplier.IsApproved,
                ApprovedBy = supplier.ApprovedBy,
                ApprovedAt = supplier.ApprovedAt,
                IsBlacklisted = supplier.IsBlacklisted,
                BlacklistReason = supplier.BlacklistReason,
                IsActive = supplier.IsActive,
                Remarks = supplier.Remarks,
                CreatedAt = supplier.CreatedAt,
                UpdatedAt = supplier.UpdatedAt,
                CreatedBy = supplier.CreatedBy,
                UpdatedBy = supplier.UpdatedBy
            };
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _unitOfWork.Suppliers.GetAllAsync();

            return suppliers.Select(MapToDto);
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
                return null;

            return MapToDto(supplier);
        }

        public async Task AddAsync(CreateSupplierDto dto)
        {
            var supplier = new Supplier
            {
                SupplierCode = dto.SupplierCode,
                SupplierName = dto.SupplierName,
                SupplierType = dto.SupplierType,
                ContactPersonName = dto.ContactPersonName,
                Email = dto.Email,
                Phone = dto.Phone,
                AlternatePhone = dto.AlternatePhone,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                Gstnumber = dto.Gstnumber,
                Pannumber = dto.Pannumber,
                LicenseNumber = dto.LicenseNumber,
                LicenseType = dto.LicenseType,
                LicenseExpiryDate = dto.LicenseExpiryDate,
                BankAccountNumber = dto.BankAccountNumber,
                BankIfsccode = dto.BankIfsccode,
                BankName = dto.BankName,
                LeadTimeDays = dto.LeadTimeDays,
                CreditLimit = dto.CreditLimit,
                CreditDays = dto.CreditDays,
                PaymentTerms = dto.PaymentTerms,
                QualityRating = dto.QualityRating,
                IsApproved = dto.IsApproved,
                IsBlacklisted = dto.IsBlacklisted,
                BlacklistReason = dto.BlacklistReason,
                IsActive = dto.IsActive,
                Remarks = dto.Remarks,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Suppliers.AddAsync(supplier);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(UpdateSupplierDto dto)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(dto.SupplierId);

            if (supplier == null)
                throw new Exception("Supplier not found.");

            supplier.SupplierCode = dto.SupplierCode;
            supplier.SupplierName = dto.SupplierName;
            supplier.SupplierType = dto.SupplierType;
            supplier.ContactPersonName = dto.ContactPersonName;
            supplier.Email = dto.Email;
            supplier.Phone = dto.Phone;
            supplier.AlternatePhone = dto.AlternatePhone;
            supplier.Address = dto.Address;
            supplier.City = dto.City;
            supplier.State = dto.State;
            supplier.Country = dto.Country;
            supplier.PostalCode = dto.PostalCode;
            supplier.Gstnumber = dto.Gstnumber;
            supplier.Pannumber = dto.Pannumber;
            supplier.LicenseNumber = dto.LicenseNumber;
            supplier.LicenseType = dto.LicenseType;
            supplier.LicenseExpiryDate = dto.LicenseExpiryDate;
            supplier.BankAccountNumber = dto.BankAccountNumber;
            supplier.BankIfsccode = dto.BankIfsccode;
            supplier.BankName = dto.BankName;
            supplier.LeadTimeDays = dto.LeadTimeDays;
            supplier.CreditLimit = dto.CreditLimit;
            supplier.CreditDays = dto.CreditDays;
            supplier.PaymentTerms = dto.PaymentTerms;
            supplier.QualityRating = dto.QualityRating;
            supplier.IsApproved = dto.IsApproved;
            supplier.IsBlacklisted = dto.IsBlacklisted;
            supplier.BlacklistReason = dto.BlacklistReason;
            supplier.IsActive = dto.IsActive;
            supplier.Remarks = dto.Remarks;

            supplier.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Suppliers.Update(supplier);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
                throw new Exception("Supplier not found.");

            _unitOfWork.Suppliers.Delete(supplier);

            await _unitOfWork.SaveAsync();
        }


        public async Task DeleteMultipleAsync(DeleteMultipleSuppliersDto dto)
        {
            foreach (var id in dto.Ids)
            {
                var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);

                if (supplier != null)
                {
                    _unitOfWork.Suppliers.Delete(supplier);
                }
            }

            await _unitOfWork.SaveAsync();
        }


        public async Task<SupplierDto?> GetByCodeAsync(string code)
        {
            var supplier = await _unitOfWork.Suppliers.GetByCodeAsync(code);

            if (supplier == null)
                return null;

            return MapToDto(supplier);
        }

        public async Task<IEnumerable<SupplierDto>> SearchAsync(string keyword)
        {
            var suppliers = await _unitOfWork.Suppliers.SearchAsync(keyword);

            return suppliers.Select(MapToDto);
        }

        public async Task<IEnumerable<SupplierDto>> GetByTypeAsync(string type)
        {
            var suppliers = await _unitOfWork.Suppliers.GetByTypeAsync(type);

            return suppliers.Select(MapToDto);
        }
        public async Task<IEnumerable<SupplierDto>> GetApprovedSuppliersAsync()
        {
            var suppliers = await _unitOfWork.Suppliers.GetApprovedSuppliersAsync();

            return suppliers.Select(MapToDto);
        }

        public async Task<IEnumerable<SupplierDto>> GetActiveSuppliersAsync()
        {
            var suppliers = await _unitOfWork.Suppliers.GetActiveSuppliersAsync();

            return suppliers.Select(MapToDto);
        }

        public async Task<IEnumerable<SupplierDto>> GetInactiveSuppliersAsync()
        {
            var suppliers = await _unitOfWork.Suppliers.GetInactiveSuppliersAsync();

            return suppliers.Select(MapToDto);
        }

        public async Task<IEnumerable<SupplierDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            var suppliers = await _unitOfWork.Suppliers.GetByDateRangeAsync(fromDate, toDate);

            return suppliers.Select(MapToDto);
        }

        public async Task<bool> IsSupplierCodeExistsAsync(string supplierCode)
        {
            return await _unitOfWork.Suppliers.IsSupplierCodeExistsAsync(supplierCode);
        }

        public async Task<bool> IsGstNumberExistsAsync(string gstNumber)
        {
            return await _unitOfWork.Suppliers.IsGstNumberExistsAsync(gstNumber);
        }

        public async Task<bool> IsPanNumberExistsAsync(string panNumber)
        {
            return await _unitOfWork.Suppliers.IsPanNumberExistsAsync(panNumber);
        }
    }
}