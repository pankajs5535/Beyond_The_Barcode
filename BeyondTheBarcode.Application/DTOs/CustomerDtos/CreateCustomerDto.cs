namespace BeyondTheBarcode.Application.DTOs.CustomerDtos;

public class CreateCustomerDto
{
        public string CustomerCode { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string CustomerType { get; set; } = null!;
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
        public string? LicenseIssuingAuthority { get; set; }
        public DateOnly? LicenseExpiryDate { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankIfsccode { get; set; }
        public string? BankName { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public decimal OutstandingBalance { get; set; }
        public string? PaymentTerms { get; set; }
        public int? AssignedSalesRepId { get; set; }
        public string? DistributionZone { get; set; }
        public string? TerritoryCode { get; set; }
        public string? RegionCode { get; set; }
        public DateOnly? CustomerSince { get; set; }
        public DateOnly? LastOrderDate { get; set; }
        public int TotalOrders { get; set; }
        public bool IsActive { get; set; }
        public string? Remarks { get; set; }
}
