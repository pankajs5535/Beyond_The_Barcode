using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class ShipmentLogRepository : GenericRepository<ShipmentLog>, IShipmentLogRepository
    {
        public ShipmentLogRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ShipmentLog?> GetByShipmentNumberAsync(string shipmentNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.ShipmentNumber == shipmentNumber);
        }

        public async Task<IEnumerable<ShipmentLog>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _dbSet.Where(x => x.SalesOrderId == salesOrderId).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentLog>> GetByPickPackAsync(int pickPackId)
        {
            return await _dbSet.Where(x => x.PickPackId == pickPackId).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentLog>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.ShipmentNumber.ToLower().Contains(keyword) ||
                (x.InvoiceNumber ?? "").ToLower().Contains(keyword) ||
                (x.EwayBillNumber ?? "").ToLower().Contains(keyword) ||
                (x.VehicleNumber ?? "").ToLower().Contains(keyword) ||
                (x.TransporterName ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<ShipmentLog>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.ShipmentStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentLog>> GetDeliveredAsync()
        {
            return await _dbSet.Where(x => x.ActualDeliveryDateTime != null).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentLog>> GetPendingDeliveriesAsync()
        {
            return await _dbSet.Where(x => x.ActualDeliveryDateTime == null).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentLog>> GetByTransporterAsync(string transporter)
        {
            return await _dbSet.Where(x => x.TransporterName == transporter).ToListAsync();
        }

        public async Task<bool> IsShipmentNumberExistsAsync(string shipmentNumber)
        {
            return await _dbSet.AnyAsync(x => x.ShipmentNumber == shipmentNumber);
        }
    }
}   