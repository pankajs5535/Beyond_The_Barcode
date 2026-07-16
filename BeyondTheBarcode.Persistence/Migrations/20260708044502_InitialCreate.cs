using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeyondTheBarcode.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gstnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pannumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseIssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankIfsccode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedSalesRepId = table.Column<int>(type: "int", nullable: true),
                    DistributionZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerritoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerSince = table.Column<DateOnly>(type: "date", nullable: true),
                    LastOrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "MachineMasters",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetTagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CapacityUom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstallationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LastMaintenanceDate = table.Column<DateOnly>(type: "date", nullable: true),
                    NextMaintenanceDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MaintenanceFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceVendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmccontractRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciationRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InsuranceRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineMasters", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NicotineContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CigaretteLengthMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CigaretteDiameterMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackagingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsPerPack = table.Column<int>(type: "int", nullable: false),
                    PacksPerCarton = table.Column<int>(type: "int", nullable: false),
                    CartonsPerMasterCarton = table.Column<int>(type: "int", nullable: false),
                    UnitCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitSalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mrp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExciseDutyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExciseDutyBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gstrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompensationCessRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hsncode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegulatoryApprovalRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthWarningRequired = table.Column<bool>(type: "bit", nullable: false),
                    HealthWarningText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExportProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DiscontinuedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gstnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pannumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankIfsccode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityRating = table.Column<byte>(type: "tinyint", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlacklisted = table.Column<bool>(type: "bit", nullable: false),
                    BlacklistReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseBins",
                columns: table => new
                {
                    BinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxWeightCapacityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxVolumeCapacityCbm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentWeightUsedKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentVolumeUsedCbm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinTemperatureC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxTemperatureC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TemperatureZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseBins", x => x.BinId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RequestedDeliveryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ConfirmedDeliveryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConfirmedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShippedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BackOrderQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Gstrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cgstamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sgstamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Igstamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CessAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExciseDutyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RoundOff = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingPincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInterstate = table.Column<bool>(type: "bit", nullable: false),
                    Ponumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesRepId = table.Column<int>(type: "int", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledBy = table.Column<int>(type: "int", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EwayBillNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    RawMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinStockLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxStockLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReorderPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrimarySupplierId = table.Column<int>(type: "int", nullable: true),
                    StorageConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HazardClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsControlledSubstance = table.Column<bool>(type: "bit", nullable: false),
                    ShelfLifeDays = table.Column<int>(type: "int", nullable: true),
                    Hsncode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastReceivedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LastReceivedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.RawMaterialId);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Suppliers_PrimarySupplierId",
                        column: x => x.PrimarySupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PickingPackingLists",
                columns: table => new
                {
                    PickPackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickPackNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    PickPackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedToPickerId = table.Column<int>(type: "int", nullable: true),
                    PickingStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickingCompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PackingStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PackingCompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BinId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShortQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackagingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartonCount = table.Column<int>(type: "int", nullable: true),
                    CartonNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalGrossWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNetWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalVolumeM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SealNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperatureAtPacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HumidityAtPacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QcverifiedBy = table.Column<int>(type: "int", nullable: true),
                    QcverifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QcverificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qcremarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchReadyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickingPackingLists", x => x.PickPackId);
                    table.ForeignKey(
                        name: "FK_PickingPackingLists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PickingPackingLists_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PickingPackingLists_WarehouseBins_BinId",
                        column: x => x.BinId,
                        principalTable: "WarehouseBins",
                        principalColumn: "BinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterialsBoms",
                columns: table => new
                {
                    Bomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Bomversion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bomstatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    QuantityRequired = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScrapPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectiveQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ComponentSequence = table.Column<int>(type: "int", nullable: true),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false),
                    SubstituteAllowed = table.Column<bool>(type: "bit", nullable: false),
                    SubstituteRawMaterialId = table.Column<int>(type: "int", nullable: true),
                    CostContributionPct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EffectiveFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    EffectiveTo = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterialsBoms", x => x.Bomid);
                    table.ForeignKey(
                        name: "FK_BillOfMaterialsBoms_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterialsBoms_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "RawMaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterialsBoms_RawMaterials_SubstituteRawMaterialId",
                        column: x => x.SubstituteRawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "RawMaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseInventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinId = table.Column<int>(type: "int", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    RawMaterialId = table.Column<int>(type: "int", nullable: true),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DamagedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuarantineQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManufacturingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValuationMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QcreleaseRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grnreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastCycleCountDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LastCycleCountQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VarianceQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseInventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_WarehouseInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseInventories_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "RawMaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseInventories_WarehouseBins_BinId",
                        column: x => x.BinId,
                        principalTable: "WarehouseBins",
                        principalColumn: "BinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentLogs",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    PickPackId = table.Column<int>(type: "int", nullable: false),
                    ShipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DispatchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedDeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransportMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lrnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EwayBillNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreightCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentLogs", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_ShipmentLogs_PickingPackingLists_PickPackId",
                        column: x => x.PickPackId,
                        principalTable: "PickingPackingLists",
                        principalColumn: "PickPackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLogs_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                columns: table => new
                {
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Bomid = table.Column<int>(type: "int", nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlannedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RejectedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YieldPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false),
                    PlannedStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PlannedEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActualStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    OperatorId = table.Column<int>(type: "int", nullable: true),
                    ShiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedLaborHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualLaborHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborCostPlanned = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaterialCostPlanned = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaterialCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverheadCostPlanned = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverheadCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReasonForDeviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedBy = table.Column<int>(type: "int", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    RawMaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.ProductionOrderId);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_BillOfMaterialsBoms_Bomid",
                        column: x => x.Bomid,
                        principalTable: "BillOfMaterialsBoms",
                        principalColumn: "Bomid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_MachineMasters_MachineId",
                        column: x => x.MachineId,
                        principalTable: "MachineMasters",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "RawMaterialId");
                });

            migrationBuilder.CreateTable(
                name: "ExciseStamps",
                columns: table => new
                {
                    StampId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StampSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StampSeriesFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampSeriesTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StampDenomination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernmentOrderRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExciseOfficerRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReceivedQty = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AppliedToProductionOrderId = table.Column<int>(type: "int", nullable: true),
                    AppliedQty = table.Column<int>(type: "int", nullable: true),
                    RemainingQty = table.Column<int>(type: "int", nullable: true),
                    DamagedQty = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DutyAmountPerStamp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDutyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AppliedDutyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CessAmountPerStamp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentChallanRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ReturnFiledRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnFiledDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StorageLocationBinId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExciseStamps", x => x.StampId);
                    table.ForeignKey(
                        name: "FK_ExciseStamps_ProductionOrders_AppliedToProductionOrderId",
                        column: x => x.AppliedToProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExciseStamps_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExciseStamps_WarehouseBins_StorageLocationBinId",
                        column: x => x.StorageLocationBinId,
                        principalTable: "WarehouseBins",
                        principalColumn: "BinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityControlLogs",
                columns: table => new
                {
                    Qcid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QcreferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    RawMaterialId = table.Column<int>(type: "int", nullable: true),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamplingStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectorId = table.Column<int>(type: "int", nullable: false),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FailedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoistureContentPct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureSpecMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureSpecMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NicotineLevelMg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NicotineSpecMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NicotineSpecMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TarLevelMg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TarSpecMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TarSpecMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrawResistancePa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrawResistanceSpecMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrawResistanceSpecMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CigaretteDiameterMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CigaretteLengthMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackWeightGm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TensileStrength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VentilationPct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrintingQualityResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthWarningPresent = table.Column<bool>(type: "bit", nullable: true),
                    BarcodeVerified = table.Column<bool>(type: "bit", nullable: true),
                    OverallResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefectCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ncrnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectiveAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreventiveAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    ReleasedBy = table.Column<int>(type: "int", nullable: true),
                    ReleasedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestReportAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlLogs", x => x.Qcid);
                    table.ForeignKey(
                        name: "FK_QualityControlLogs_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlLogs_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "RawMaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchTrackTraces",
                columns: table => new
                {
                    TraceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: true),
                    RawMaterialBatch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ManufacturingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PackagingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShelfLifeDays = table.Column<int>(type: "int", nullable: true),
                    StampId = table.Column<int>(type: "int", nullable: true),
                    ExciseChallanRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QclogId = table.Column<int>(type: "int", nullable: true),
                    Qcstatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QcreleasedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarehouseInventoryId = table.Column<int>(type: "int", nullable: true),
                    ReceiptDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DispatchDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SalesOrderId = table.Column<int>(type: "int", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRecalled = table.Column<bool>(type: "bit", nullable: false),
                    RecallReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecallInitiatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecallInitiatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDestroyed = table.Column<bool>(type: "bit", nullable: false),
                    DestroyedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DestroyedBy = table.Column<int>(type: "int", nullable: true),
                    DestructionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraceabilityChain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchTrackTraces", x => x.TraceId);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_ExciseStamps_StampId",
                        column: x => x.StampId,
                        principalTable: "ExciseStamps",
                        principalColumn: "StampId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_QualityControlLogs_QclogId",
                        column: x => x.QclogId,
                        principalTable: "QualityControlLogs",
                        principalColumn: "Qcid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "RawMaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_ShipmentLogs_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "ShipmentLogs",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchTrackTraces_WarehouseInventories_WarehouseInventoryId",
                        column: x => x.WarehouseInventoryId,
                        principalTable: "WarehouseInventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_CustomerId",
                table: "BatchTrackTraces",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_ProductId",
                table: "BatchTrackTraces",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_ProductionOrderId",
                table: "BatchTrackTraces",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_QclogId",
                table: "BatchTrackTraces",
                column: "QclogId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_RawMaterialId",
                table: "BatchTrackTraces",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_SalesOrderId",
                table: "BatchTrackTraces",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_ShipmentId",
                table: "BatchTrackTraces",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_StampId",
                table: "BatchTrackTraces",
                column: "StampId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_SupplierId",
                table: "BatchTrackTraces",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTrackTraces_WarehouseInventoryId",
                table: "BatchTrackTraces",
                column: "WarehouseInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterialsBoms_ProductId",
                table: "BillOfMaterialsBoms",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterialsBoms_RawMaterialId",
                table: "BillOfMaterialsBoms",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterialsBoms_SubstituteRawMaterialId",
                table: "BillOfMaterialsBoms",
                column: "SubstituteRawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ExciseStamps_AppliedToProductionOrderId",
                table: "ExciseStamps",
                column: "AppliedToProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExciseStamps_ProductId",
                table: "ExciseStamps",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExciseStamps_StorageLocationBinId",
                table: "ExciseStamps",
                column: "StorageLocationBinId");

            migrationBuilder.CreateIndex(
                name: "IX_PickingPackingLists_BinId",
                table: "PickingPackingLists",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_PickingPackingLists_ProductId",
                table: "PickingPackingLists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PickingPackingLists_SalesOrderId",
                table: "PickingPackingLists",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_Bomid",
                table: "ProductionOrders",
                column: "Bomid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_MachineId",
                table: "ProductionOrders",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_ProductId",
                table: "ProductionOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_RawMaterialId",
                table: "ProductionOrders",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlLogs_ProductId",
                table: "QualityControlLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlLogs_ProductionOrderId",
                table: "QualityControlLogs",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlLogs_RawMaterialId",
                table: "QualityControlLogs",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_PrimarySupplierId",
                table: "RawMaterials",
                column: "PrimarySupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLogs_PickPackId",
                table: "ShipmentLogs",
                column: "PickPackId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLogs_SalesOrderId",
                table: "ShipmentLogs",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseInventories_BinId",
                table: "WarehouseInventories",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseInventories_ProductId",
                table: "WarehouseInventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseInventories_RawMaterialId",
                table: "WarehouseInventories",
                column: "RawMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchTrackTraces");

            migrationBuilder.DropTable(
                name: "ExciseStamps");

            migrationBuilder.DropTable(
                name: "QualityControlLogs");

            migrationBuilder.DropTable(
                name: "ShipmentLogs");

            migrationBuilder.DropTable(
                name: "WarehouseInventories");

            migrationBuilder.DropTable(
                name: "ProductionOrders");

            migrationBuilder.DropTable(
                name: "PickingPackingLists");

            migrationBuilder.DropTable(
                name: "BillOfMaterialsBoms");

            migrationBuilder.DropTable(
                name: "MachineMasters");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "WarehouseBins");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
