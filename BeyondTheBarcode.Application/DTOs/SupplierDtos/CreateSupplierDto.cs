namespace BeyondTheBarcode.Application.DTOs.SupplierDtos;

public class CreateSupplierDto
{
        public string SupplierCode { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
        public string SupplierType { get; set; } = null!;
        public string? ContactPersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string? Gstnumber { get; set; }
        public string? Pannumber { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseType { get; set; }
        public DateOnly? LicenseExpiryDate { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankIfsccode { get; set; }
        public string? BankName { get; set; }
        public int LeadTimeDays { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public string? PaymentTerms { get; set; }
        public byte? QualityRating { get; set; }
        public bool IsApproved { get; set; }
        public bool IsBlacklisted { get; set; }
        public string? BlacklistReason { get; set; }
        public bool IsActive { get; set; }
        public string? Remarks { get; set; }
}
