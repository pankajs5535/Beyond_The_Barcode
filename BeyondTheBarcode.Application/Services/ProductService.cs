using BeyondTheBarcode.Application.DTOs.ProductDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Select(MapToDto);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return null;

            return MapToDto(product);
        }

        public async Task<ProductDto?> GetByCodeAsync(string code)
        {
            var product = await _unitOfWork.Products.GetByCodeAsync(code);

            if (product == null)
                return null;

            return MapToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetByBrandAsync(string brand)
        {
            var products = await _unitOfWork.Products.GetByBrandAsync(brand);
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(string category)
        {
            var products = await _unitOfWork.Products.GetByCategoryAsync(category);
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> SearchAsync(string keyword)
        {
            var products = await _unitOfWork.Products.SearchAsync(keyword);
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetActiveAsync()
        {
            var products = await _unitOfWork.Products.GetActiveAsync();
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetInactiveAsync()
        {
            var products = await _unitOfWork.Products.GetInactiveAsync();
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            var products = await _unitOfWork.Products.GetByDateRangeAsync(fromDate, toDate);
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetExportProductsAsync()
        {
            var products = await _unitOfWork.Products.GetExportProductsAsync();
            return products.Select(MapToDto);
        }
        public async Task<IEnumerable<ProductDto>> GetHealthWarningProductsAsync()
        {
            var products = await _unitOfWork.Products.GetHealthWarningProductsAsync();
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetDiscontinuedProductsAsync()
        {
            var products = await _unitOfWork.Products.GetDiscontinuedProductsAsync();
            return products.Select(MapToDto);
        }

        public async Task<bool> IsProductCodeExistsAsync(string productCode)
        {
            return await _unitOfWork.Products.IsProductCodeExistsAsync(productCode);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                ProductCode = dto.ProductCode,
                ProductName = dto.ProductName,
                Brand = dto.Brand,
                Category = dto.Category,
                SubCategory = dto.SubCategory,
                Description = dto.Description,
                NicotineContent = dto.NicotineContent,
                TarContent = dto.TarContent,
                FilterType = dto.FilterType,
                CigaretteLengthMm = dto.CigaretteLengthMm,
                CigaretteDiameterMm = dto.CigaretteDiameterMm,
                PackagingType = dto.PackagingType,
                UnitsPerPack = dto.UnitsPerPack,
                PacksPerCarton = dto.PacksPerCarton,
                CartonsPerMasterCarton = dto.CartonsPerMasterCarton,
                UnitCostPrice = dto.UnitCostPrice,
                UnitSalePrice = dto.UnitSalePrice,
                Mrp = dto.Mrp,
                ExciseDutyRate = dto.ExciseDutyRate,
                ExciseDutyBasis = dto.ExciseDutyBasis,
                Gstrate = dto.Gstrate,
                CompensationCessRate = dto.CompensationCessRate,
                Hsncode = dto.Hsncode,
                CountryOfOrigin = dto.CountryOfOrigin,
                RegulatoryApprovalRef = dto.RegulatoryApprovalRef,
                HealthWarningRequired = dto.HealthWarningRequired,
                HealthWarningText = dto.HealthWarningText,
                IsExportProduct = dto.IsExportProduct,
                IsActive = dto.IsActive,
                DiscontinuedDate = dto.DiscontinuedDate,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(dto.ProductId);

            if (product == null)
                throw new Exception("Product not found.");

            product.ProductCode = dto.ProductCode;
            product.ProductName = dto.ProductName;
            product.Brand = dto.Brand;
            product.Category = dto.Category;
            product.SubCategory = dto.SubCategory;
            product.Description = dto.Description;
            product.NicotineContent = dto.NicotineContent;
            product.TarContent = dto.TarContent;
            product.FilterType = dto.FilterType;
            product.CigaretteLengthMm = dto.CigaretteLengthMm;
            product.CigaretteDiameterMm = dto.CigaretteDiameterMm;
            product.PackagingType = dto.PackagingType;
            product.UnitsPerPack = dto.UnitsPerPack;
            product.PacksPerCarton = dto.PacksPerCarton;
            product.CartonsPerMasterCarton = dto.CartonsPerMasterCarton;
            product.UnitCostPrice = dto.UnitCostPrice;
            product.UnitSalePrice = dto.UnitSalePrice;
            product.Mrp = dto.Mrp;
            product.ExciseDutyRate = dto.ExciseDutyRate;
            product.ExciseDutyBasis = dto.ExciseDutyBasis;
            product.Gstrate = dto.Gstrate;
            product.CompensationCessRate = dto.CompensationCessRate;
            product.Hsncode = dto.Hsncode;
            product.CountryOfOrigin = dto.CountryOfOrigin;
            product.RegulatoryApprovalRef = dto.RegulatoryApprovalRef;
            product.HealthWarningRequired = dto.HealthWarningRequired;
            product.HealthWarningText = dto.HealthWarningText;
            product.IsExportProduct = dto.IsExportProduct;
            product.IsActive = dto.IsActive;
            product.DiscontinuedDate = dto.DiscontinuedDate;
            product.Remarks = dto.Remarks;
            product.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                throw new Exception("Product not found.");

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Brand = product.Brand,
                Category = product.Category,
                SubCategory = product.SubCategory,
                Description = product.Description,
                NicotineContent = product.NicotineContent,
                TarContent = product.TarContent,
                FilterType = product.FilterType,
                CigaretteLengthMm = product.CigaretteLengthMm,
                CigaretteDiameterMm = product.CigaretteDiameterMm,
                PackagingType = product.PackagingType,
                UnitsPerPack = product.UnitsPerPack,
                PacksPerCarton = product.PacksPerCarton,
                CartonsPerMasterCarton = product.CartonsPerMasterCarton,
                UnitCostPrice = product.UnitCostPrice,
                UnitSalePrice = product.UnitSalePrice,
                Mrp = product.Mrp,
                ExciseDutyRate = product.ExciseDutyRate,
                ExciseDutyBasis = product.ExciseDutyBasis,
                Gstrate = product.Gstrate,
                CompensationCessRate = product.CompensationCessRate,
                Hsncode = product.Hsncode,
                CountryOfOrigin = product.CountryOfOrigin,
                RegulatoryApprovalRef = product.RegulatoryApprovalRef,
                HealthWarningRequired = product.HealthWarningRequired,
                HealthWarningText = product.HealthWarningText,
                IsExportProduct = product.IsExportProduct,
                IsActive = product.IsActive,
                DiscontinuedDate = product.DiscontinuedDate,
                Remarks = product.Remarks,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                CreatedBy = product.CreatedBy,
                UpdatedBy = product.UpdatedBy
            };
        }
    }
}