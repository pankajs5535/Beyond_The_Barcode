using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTheBarcode.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }

        IRawMaterialRepository RawMaterials { get; }

        IProductRepository Products { get; }

        IBillOfMaterialsBomRepository BillOfMaterialsBoms { get; }

        IMachineMasterRepository MachineMasters { get; }

        IProductionOrderRepository ProductionOrders { get; }

        IWarehouseBinRepository WarehouseBins { get; }

        IWarehouseInventoryRepository WarehouseInventories { get; }

        ICustomerRepository Customers { get; }

        ISalesOrderRepository SalesOrders { get; }

        IQualityControlLogRepository QualityControlLogs { get; }

        IExciseStampRepository ExciseStamps { get; }

        IPickingPackingListRepository PickingPackingLists { get; }

        IShipmentLogRepository ShipmentLogs { get; }

        IBatchTrackTraceRepository BatchTrackTraces { get; }

        Task<int> SaveAsync();
    }
}


/*
 
IUnitOfWork Explanation

1. public interface IUnitOfWork : IDisposable
Purpose: Defines a single unit of work for all database operations. 
It ensures multiple repository operations are committed together using one SaveAsync() call. 
Inheriting IDisposable ensures the ApplicationDbContext is disposed properly after use.

2. ISupplierRepository Suppliers { get; }
Purpose: Exposes the SupplierRepository through the Unit of Work.
Usage:
_unitOfWork.Suppliers.GetAllAsync();
_unitOfWork.Suppliers.AddAsync(supplier);

As more modules are developed, more repositories will be added here, for example:
• IRawMaterialRepository RawMaterials
• IProductRepository Products
• IBillOfMaterialsRepository BillOfMaterials
• IMachineRepository Machines
• IProductionOrderRepository ProductionOrders
• IWarehouseRepository WarehouseInventory
• ICustomerRepository Customers
• ISalesOrderRepository SalesOrders

3. Task<int> SaveAsync()
Purpose: Saves all pending changes to the database by calling ApplicationDbContext.SaveChangesAsync().
Returns the number of affected rows.
Example:
await _unitOfWork.Suppliers.AddAsync(supplier);
await _unitOfWork.SaveAsync();

This ensures all operations are saved in a single transaction.

Why use Unit of Work?
Without Unit of Work, every repository would call SaveChanges() individually, resulting in 
multiple database transactions. With Unit of Work, all repository operations are performed first, 
and only one SaveAsync() is called. This provides better performance, maintains data consistency, 
supports transactions, and follows enterprise Repository + Unit of Work architecture.


 */