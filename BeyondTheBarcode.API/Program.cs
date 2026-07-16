using BeyondTheBarcode.Application.Interfaces.IServices;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Application.Services;
using BeyondTheBarcode.Persistence.Data;
using BeyondTheBarcode.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -------------------- CORS --------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// -------------------- Controllers --------------------
builder.Services.AddControllers();

// -------------------- Database --------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// -------------------- Swagger --------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------- Dependency Injection --------------------
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
builder.Services.AddScoped<IRawMaterialService, RawMaterialService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBillOfMaterialsBomService, BillOfMaterialsBomService>();
builder.Services.AddScoped<IMachineMasterService, MachineMasterService>();
builder.Services.AddScoped<IProductionOrderService, ProductionOrderService>();
builder.Services.AddScoped<IWarehouseBinService, WarehouseBinService>();
builder.Services.AddScoped<IWarehouseInventoryService, WarehouseInventoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IQualityControlLogService, QualityControlLogService>();
builder.Services.AddScoped<IExciseStampService, ExciseStampService>();
builder.Services.AddScoped<IPickingPackingListService, PickingPackingListService>();
builder.Services.AddScoped<IShipmentLogService, ShipmentLogService>();
builder.Services.AddScoped<IBatchTrackTraceService, BatchTrackTraceService>();



var app = builder.Build();

// -------------------- Middleware --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

// Uncomment later if required
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();