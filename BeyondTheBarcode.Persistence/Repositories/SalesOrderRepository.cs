using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<SalesOrder?> GetByOrderNumberAsync(string orderNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);
        }

        public async Task<IEnumerable<SalesOrder>> GetByCustomerAsync(int customerId)
        {
            return await _dbSet.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.OrderNumber.ToLower().Contains(keyword) ||
                x.OrderStatus.ToLower().Contains(keyword) ||
                (x.InvoiceNumber ?? "").ToLower().Contains(keyword) ||
                (x.Ponumber ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.OrderStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetByPaymentStatusAsync(string paymentStatus)
        {
            return await _dbSet.Where(x => x.PaymentStatus == paymentStatus).ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate)
        {
            return await _dbSet.Where(x => x.OrderDate >= fromDate && x.OrderDate <= toDate).ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetApprovedOrdersAsync()
        {
            return await _dbSet.Where(x => x.ApprovedBy != null).ToListAsync();
        }

        public async Task<bool> IsOrderNumberExistsAsync(string orderNumber)
        {
            return await _dbSet.AnyAsync(x => x.OrderNumber == orderNumber);
        }
    }
}