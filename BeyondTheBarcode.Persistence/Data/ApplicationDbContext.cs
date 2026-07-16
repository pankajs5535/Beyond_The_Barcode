using BeyondTheBarcode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // =========================
    // Master Tables
    // =========================

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<RawMaterial> RawMaterials => Set<RawMaterial>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<MachineMaster> MachineMasters => Set<MachineMaster>();

    public DbSet<WarehouseBin> WarehouseBins => Set<WarehouseBin>();

    // =========================
    // Manufacturing
    // =========================

    public DbSet<BillOfMaterialsBom> BillOfMaterialsBoms => Set<BillOfMaterialsBom>();

    public DbSet<ProductionOrder> ProductionOrders => Set<ProductionOrder>();

    public DbSet<QualityControlLog> QualityControlLogs => Set<QualityControlLog>();

    public DbSet<ExciseStamp> ExciseStamps => Set<ExciseStamp>();

    public DbSet<BatchTrackTrace> BatchTrackTraces => Set<BatchTrackTrace>();

    // =========================
    // Inventory
    // =========================

    public DbSet<WarehouseInventory> WarehouseInventories => Set<WarehouseInventory>();

    // =========================
    // Sales
    // =========================

    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();

    public DbSet<PickingPackingList> PickingPackingLists => Set<PickingPackingList>();

    public DbSet<ShipmentLog> ShipmentLogs => Set<ShipmentLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =========================
        // Supplier
        // =========================
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);
        });

        // =========================
        // Raw Material
        // =========================
        modelBuilder.Entity<RawMaterial>(entity =>
        {
            entity.HasKey(e => e.RawMaterialId);

            entity.HasOne(e => e.PrimarySupplier)
                  .WithMany(s => s.RawMaterials)
                  .HasForeignKey(e => e.PrimarySupplierId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Product
        // =========================
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
        });

        // =========================
        // Bill Of Materials
        // =========================
        modelBuilder.Entity<BillOfMaterialsBom>(entity =>
        {
            entity.HasKey(e => e.Bomid);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.BillOfMaterialsBoms)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial)
                  .WithMany(r => r.BillOfMaterialsBomRawMaterials)
                  .HasForeignKey(e => e.RawMaterialId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.SubstituteRawMaterial)
                  .WithMany(r => r.BillOfMaterialsBomSubstituteRawMaterials)
                  .HasForeignKey(e => e.SubstituteRawMaterialId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Machine Master
        // =========================
        modelBuilder.Entity<MachineMaster>(entity =>
        {
            entity.HasKey(e => e.MachineId);
        });

        // =========================
        // Production Order
        // =========================
        modelBuilder.Entity<ProductionOrder>(entity =>
        {
            entity.HasKey(e => e.ProductionOrderId);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.ProductionOrders)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Bom)
                  .WithMany(b => b.ProductionOrders)
                  .HasForeignKey(e => e.Bomid)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Machine)
                  .WithMany(m => m.ProductionOrders)
                  .HasForeignKey(e => e.MachineId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Warehouse Bin
        // =========================
        modelBuilder.Entity<WarehouseBin>(entity =>
        {
            entity.HasKey(e => e.BinId);
        });

        // =========================
        // Warehouse Inventory
        // =========================
        modelBuilder.Entity<WarehouseInventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId);

            entity.HasOne(e => e.Bin)
                  .WithMany(b => b.WarehouseInventories)
                  .HasForeignKey(e => e.BinId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.WarehouseInventories)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial)
                  .WithMany(r => r.WarehouseInventories)
                  .HasForeignKey(e => e.RawMaterialId)
                  .OnDelete(DeleteBehavior.Restrict);
        });


        // =========================
        // Customer
        // =========================
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
        });

        // =========================
        // Sales Order
        // =========================
        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId);

            entity.HasOne(e => e.Customer)
                  .WithMany(c => c.SalesOrders)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.SalesOrders)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Picking & Packing
        // =========================
        modelBuilder.Entity<PickingPackingList>(entity =>
        {
            entity.HasKey(e => e.PickPackId);

            entity.HasOne(e => e.SalesOrder)
                  .WithMany(s => s.PickingPackingLists)
                  .HasForeignKey(e => e.SalesOrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.PickingPackingLists)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Bin)
                  .WithMany(b => b.PickingPackingLists)
                  .HasForeignKey(e => e.BinId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Shipment Log
        // =========================
        modelBuilder.Entity<ShipmentLog>(entity =>
        {
            entity.HasKey(e => e.ShipmentId);

            entity.HasOne(e => e.SalesOrder)
                  .WithMany(s => s.ShipmentLogs)
                  .HasForeignKey(e => e.SalesOrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.PickPack)
                  .WithMany(p => p.ShipmentLogs)
                  .HasForeignKey(e => e.PickPackId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Quality Control Log
        // =========================
        modelBuilder.Entity<QualityControlLog>(entity =>
        {
            entity.HasKey(e => e.Qcid);

            entity.HasOne(e => e.ProductionOrder)
                  .WithMany(p => p.QualityControlLogs)
                  .HasForeignKey(e => e.ProductionOrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.QualityControlLogs)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial)
                  .WithMany(r => r.QualityControlLogs)
                  .HasForeignKey(e => e.RawMaterialId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Excise Stamp
        // =========================
        modelBuilder.Entity<ExciseStamp>(entity =>
        {
            entity.HasKey(e => e.StampId);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.ExciseStamps)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AppliedToProductionOrder)
                  .WithMany(p => p.ExciseStamps)
                  .HasForeignKey(e => e.AppliedToProductionOrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.StorageLocationBin)
                  .WithMany(b => b.ExciseStamps)
                  .HasForeignKey(e => e.StorageLocationBinId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // Batch Track Trace
        // =========================
        modelBuilder.Entity<BatchTrackTrace>(entity =>
        {
            entity.HasKey(e => e.TraceId);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.BatchTrackTraces)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ProductionOrder)
                  .WithMany(p => p.BatchTrackTraces)
                  .HasForeignKey(e => e.ProductionOrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial)
                  .WithMany(r => r.BatchTrackTraces)
                  .HasForeignKey(e => e.RawMaterialId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Supplier)
                  .WithMany(s => s.BatchTrackTraces)
                  .HasForeignKey(e => e.SupplierId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Qclog)
                  .WithMany(q => q.BatchTrackTraces)
                  .HasForeignKey(e => e.QclogId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.WarehouseInventory)
                  .WithMany(w => w.BatchTrackTraces)
                  .HasForeignKey(e => e.WarehouseInventoryId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.SalesOrder)
                  .WithMany(s => s.BatchTrackTraces)
                  .HasForeignKey(e => e.SalesOrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Shipment)
                  .WithMany(s => s.BatchTrackTraces)
                  .HasForeignKey(e => e.ShipmentId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Customer)
                  .WithMany(c => c.BatchTrackTraces)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Stamp)
                  .WithMany(s => s.BatchTrackTraces)
                  .HasForeignKey(e => e.StampId)
                  .OnDelete(DeleteBehavior.Restrict);
        });


    }
}