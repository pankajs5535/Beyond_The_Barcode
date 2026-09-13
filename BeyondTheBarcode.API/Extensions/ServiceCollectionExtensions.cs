using BeyondTheBarcode.Application.Interfaces.IServices;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Application.Services;
using BeyondTheBarcode.Persistence.Data;
using BeyondTheBarcode.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // -------------------- CORS --------------------
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // -------------------- Controllers --------------------
            services.AddControllers();

            // -------------------- Database --------------------
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // -------------------- Swagger --------------------
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // -------------------- Dependency Injection --------------------
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IRawMaterialService, RawMaterialService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBillOfMaterialsBomService, BillOfMaterialsBomService>();
            services.AddScoped<IMachineMasterService, MachineMasterService>();
            services.AddScoped<IProductionOrderService, ProductionOrderService>();
            services.AddScoped<IWarehouseBinService, WarehouseBinService>();
            services.AddScoped<IWarehouseInventoryService, WarehouseInventoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IQualityControlLogService, QualityControlLogService>();
            services.AddScoped<IExciseStampService, ExciseStampService>();
            services.AddScoped<IPickingPackingListService, PickingPackingListService>();
            services.AddScoped<IShipmentLogService, ShipmentLogService>();
            services.AddScoped<IBatchTrackTraceService, BatchTrackTraceService>();

            return services;
        }
    }
}