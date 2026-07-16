using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Persistence.Data;
using BeyondTheBarcode.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTheBarcode.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ISupplierRepository Suppliers { get; }

        public IRawMaterialRepository RawMaterials { get; }

        public IProductRepository Products { get; }

        public IBillOfMaterialsBomRepository BillOfMaterialsBoms { get; }

        public IMachineMasterRepository MachineMasters { get; }

        public IProductionOrderRepository ProductionOrders { get; }

        public IWarehouseBinRepository WarehouseBins { get; }

        public IWarehouseInventoryRepository WarehouseInventories { get; }

        public ICustomerRepository Customers { get; }

        public ISalesOrderRepository SalesOrders { get; }

        public IQualityControlLogRepository QualityControlLogs { get; }

        public IExciseStampRepository ExciseStamps { get; }

        public IPickingPackingListRepository PickingPackingLists { get; }

        public IShipmentLogRepository ShipmentLogs { get; }

        public IBatchTrackTraceRepository BatchTrackTraces { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Suppliers = new SupplierRepository(context);
            RawMaterials = new RawMaterialRepository(context);
            Products = new ProductRepository(context);
            BillOfMaterialsBoms = new BillOfMaterialsBomRepository(context);
            MachineMasters = new MachineMasterRepository(context);
            ProductionOrders = new ProductionOrderRepository(context);
            WarehouseBins = new WarehouseBinRepository(context);
            WarehouseInventories = new WarehouseInventoryRepository(context);
            Customers = new CustomerRepository(context);
            SalesOrders = new SalesOrderRepository(context);
            QualityControlLogs = new QualityControlLogRepository(context);
            ExciseStamps = new ExciseStampRepository(context);
            PickingPackingLists = new PickingPackingListRepository(context);
            ShipmentLogs = new ShipmentLogRepository(context);
            BatchTrackTraces = new BatchTrackTraceRepository(context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


/*

UnitOfWork Explanation

1. private readonly ApplicationDbContext _context;
Purpose: Stores the ApplicationDbContext instance. 
All repositories share this same DbContext, ensuring that every database operation is part of the same unit of work.

2. public ISupplierRepository Suppliers { get; }
Purpose: Exposes the SupplierRepository through the Unit of Work. Instead of creating repositories in controllers or 
services, they are accessed through _unitOfWork.

Example:
_unitOfWork.Suppliers.GetAllAsync();

3. public UnitOfWork(ApplicationDbContext context)
Purpose: Receives the ApplicationDbContext through Dependency Injection and initializes the SupplierRepository.

Code:
_context = context;
Suppliers = new SupplierRepository(context);

This ensures both UnitOfWork and SupplierRepository use the same DbContext instance.

4. public async Task<int> SaveAsync()
Purpose: Saves all pending changes to the database by calling SaveChangesAsync().

Example:
await _unitOfWork.Suppliers.AddAsync(supplier);
await _unitOfWork.SaveAsync();

Nothing is permanently stored in the database until SaveAsync() is called.

5. public void Dispose()
Purpose: Releases the ApplicationDbContext from memory after the request is completed, 
preventing memory leaks and freeing database connections.

Why use UnitOfWork?

Without UnitOfWork:
SupplierRepository -> SaveChanges()
ProductRepository -> SaveChanges()
RawMaterialRepository -> SaveChanges()

This creates multiple database transactions.

With UnitOfWork:
SupplierRepository -> Add()
ProductRepository -> Update()
RawMaterialRepository -> Delete()
UnitOfWork -> SaveAsync()

All operations are committed together in a single transaction, improving performance, 
maintaining data consistency, and following enterprise Repository + Unit of Work architecture. 
 
 
*/