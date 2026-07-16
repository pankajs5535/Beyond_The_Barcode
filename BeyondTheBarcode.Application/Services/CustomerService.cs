using BeyondTheBarcode.Application.DTOs.CustomerDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Customers
        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return customers.Select(MapToDto);
        }

        // Get Customer by Id
        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
                return null;

            return MapToDto(customer);
        }

        // Get Customer by Customer Code
        public async Task<CustomerDto?> GetByCodeAsync(string code)
        {
            var customer = await _unitOfWork.Customers.GetByCodeAsync(code);

            if (customer == null)
                return null;

            return MapToDto(customer);
        }

        // Get Customers by Type
        public async Task<IEnumerable<CustomerDto>> GetByTypeAsync(string type)
        {
            var customers = await _unitOfWork.Customers.GetByTypeAsync(type);
            return customers.Select(MapToDto);
        }

        // Search Customers
        public async Task<IEnumerable<CustomerDto>> SearchAsync(string keyword)
        {
            var customers = await _unitOfWork.Customers.SearchAsync(keyword);
            return customers.Select(MapToDto);
        }

        // Get Active Customers
        public async Task<IEnumerable<CustomerDto>> GetActiveAsync()
        {
            var customers = await _unitOfWork.Customers.GetActiveAsync();
            return customers.Select(MapToDto);
        }

        // Get Inactive Customers
        public async Task<IEnumerable<CustomerDto>> GetInactiveAsync()
        {
            var customers = await _unitOfWork.Customers.GetInactiveAsync();
            return customers.Select(MapToDto);
        }

        // Get Customers by Distribution Zone
        public async Task<IEnumerable<CustomerDto>> GetByZoneAsync(string zone)
        {
            var customers = await _unitOfWork.Customers.GetByZoneAsync(zone);
            return customers.Select(MapToDto);
        }

        // Get Customers by Region
        public async Task<IEnumerable<CustomerDto>> GetByRegionAsync(string region)
        {
            var customers = await _unitOfWork.Customers.GetByRegionAsync(region);
            return customers.Select(MapToDto);
        }

        // Get Customers by Sales Representative
        public async Task<IEnumerable<CustomerDto>> GetBySalesRepAsync(int salesRepId)
        {
            var customers = await _unitOfWork.Customers.GetBySalesRepAsync(salesRepId);
            return customers.Select(MapToDto);
        }

        // Check Customer Code Exists
        public async Task<bool> IsCustomerCodeExistsAsync(string customerCode)
        {
            return await _unitOfWork.Customers.IsCustomerCodeExistsAsync(customerCode);
        }

        // Create Customer
        public async Task CreateAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                CustomerCode = dto.CustomerCode,
                CustomerName = dto.CustomerName,
                CustomerType = dto.CustomerType,
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
                LicenseIssuingAuthority = dto.LicenseIssuingAuthority,
                LicenseExpiryDate = dto.LicenseExpiryDate,
                BankAccountNumber = dto.BankAccountNumber,
                BankIfsccode = dto.BankIfsccode,
                BankName = dto.BankName,
                CreditLimit = dto.CreditLimit,
                CreditDays = dto.CreditDays,
                OutstandingBalance = dto.OutstandingBalance,
                PaymentTerms = dto.PaymentTerms,
                AssignedSalesRepId = dto.AssignedSalesRepId,
                DistributionZone = dto.DistributionZone,
                TerritoryCode = dto.TerritoryCode,
                RegionCode = dto.RegionCode,
                CustomerSince = dto.CustomerSince,
                LastOrderDate = dto.LastOrderDate,
                TotalOrders = dto.TotalOrders,
                IsActive = dto.IsActive,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveAsync();
        }

        // Update Customer
        public async Task UpdateAsync(UpdateCustomerDto dto)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(dto.CustomerId);

            if (customer == null)
                throw new Exception("Customer not found.");

            customer.CustomerCode = dto.CustomerCode;
            customer.CustomerName = dto.CustomerName;
            customer.CustomerType = dto.CustomerType;
            customer.ContactPersonName = dto.ContactPersonName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.AlternatePhone = dto.AlternatePhone;
            customer.Address = dto.Address;
            customer.City = dto.City;
            customer.State = dto.State;
            customer.Country = dto.Country;
            customer.PostalCode = dto.PostalCode;
            customer.Gstnumber = dto.Gstnumber;
            customer.Pannumber = dto.Pannumber;
            customer.LicenseNumber = dto.LicenseNumber;
            customer.LicenseType = dto.LicenseType;
            customer.LicenseIssuingAuthority = dto.LicenseIssuingAuthority;
            customer.LicenseExpiryDate = dto.LicenseExpiryDate;
            customer.BankAccountNumber = dto.BankAccountNumber;
            customer.BankIfsccode = dto.BankIfsccode;
            customer.BankName = dto.BankName;
            customer.CreditLimit = dto.CreditLimit;
            customer.CreditDays = dto.CreditDays;
            customer.OutstandingBalance = dto.OutstandingBalance;
            customer.PaymentTerms = dto.PaymentTerms;
            customer.AssignedSalesRepId = dto.AssignedSalesRepId;
            customer.DistributionZone = dto.DistributionZone;
            customer.TerritoryCode = dto.TerritoryCode;
            customer.RegionCode = dto.RegionCode;
            customer.CustomerSince = dto.CustomerSince;
            customer.LastOrderDate = dto.LastOrderDate;
            customer.TotalOrders = dto.TotalOrders;
            customer.IsActive = dto.IsActive;
            customer.Remarks = dto.Remarks;
            customer.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveAsync();
        }

        // Delete Customer
        public async Task DeleteAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
                throw new Exception("Customer not found.");

            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                CustomerType = customer.CustomerType,
                ContactPersonName = customer.ContactPersonName,
                Email = customer.Email,
                Phone = customer.Phone,
                AlternatePhone = customer.AlternatePhone,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                Gstnumber = customer.Gstnumber,
                Pannumber = customer.Pannumber,
                LicenseNumber = customer.LicenseNumber,
                LicenseType = customer.LicenseType,
                LicenseIssuingAuthority = customer.LicenseIssuingAuthority,
                LicenseExpiryDate = customer.LicenseExpiryDate,
                BankAccountNumber = customer.BankAccountNumber,
                BankIfsccode = customer.BankIfsccode,
                BankName = customer.BankName,
                CreditLimit = customer.CreditLimit,
                CreditDays = customer.CreditDays,
                OutstandingBalance = customer.OutstandingBalance,
                PaymentTerms = customer.PaymentTerms,
                AssignedSalesRepId = customer.AssignedSalesRepId,
                DistributionZone = customer.DistributionZone,
                TerritoryCode = customer.TerritoryCode,
                RegionCode = customer.RegionCode,
                CustomerSince = customer.CustomerSince,
                LastOrderDate = customer.LastOrderDate,
                TotalOrders = customer.TotalOrders,
                IsActive = customer.IsActive,
                Remarks = customer.Remarks,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                CreatedBy = customer.CreatedBy,
                UpdatedBy = customer.UpdatedBy
            };
        }
    }
}



