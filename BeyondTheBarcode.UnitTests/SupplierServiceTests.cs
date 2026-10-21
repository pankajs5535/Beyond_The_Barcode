using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeyondTheBarcode.Application.Services;
using BeyondTheBarcode.Application.DTOs.SupplierDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Tests
{
    /*
    ================================================================
                SUPPLIER SERVICE UNIT TESTS
    ================================================================

    Framework : xUnit
    Mocking   : Moq

    PURPOSE:
    Test the actual SupplierService without connecting to a real
    database.

    REAL OBJECT:
        SupplierService

    MOCK OBJECTS:
        IUnitOfWork
        ISupplierRepository

    AAA PATTERN:
        Arrange -> Prepare test data and mock behavior.
        Act     -> Call the actual service method.
        Assert  -> Verify the expected result.

    ================================================================
    */

    public class SupplierServiceTests
    {
        // Mock Unit of Work to prevent access to a real database.
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        // Mock Supplier Repository to control repository responses.
        private readonly Mock<ISupplierRepository> _supplierRepositoryMock;

        // The actual service being tested.
        private readonly SupplierService _supplierService;


        // Constructor runs before each test and prepares dependencies.
        public SupplierServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _supplierRepositoryMock = new Mock<ISupplierRepository>();

            // When UnitOfWork.Suppliers is accessed,
            // return our mocked SupplierRepository.
            _unitOfWorkMock
                .Setup(u => u.Suppliers)
                .Returns(_supplierRepositoryMock.Object);

            // Create the actual service with the mocked Unit of Work.
            _supplierService =
                new SupplierService(_unitOfWorkMock.Object);
        }


        // Helper method: Creates reusable test supplier data.
        private static Supplier CreateSupplier()
        {
            return new Supplier
            {
                SupplierId = 1,
                SupplierCode = "SUP001",
                SupplierName = "ABC Suppliers",
                SupplierType = "Raw Material",
                Email = "abc@example.com",
                Phone = "9876543210",
                IsApproved = true,
                IsActive = true
            };
        }


        // =========================================================
        // 1. GetAllAsync
        // =========================================================

        [Fact]
        public async Task GetAllAsync_ReturnsAllSuppliers()
        {
            // Arrange: Prepare two suppliers.
            var suppliers = new List<Supplier>
            {
                CreateSupplier(),
                new Supplier
                {
                    SupplierId = 2,
                    SupplierCode = "SUP002",
                    SupplierName = "XYZ Suppliers"
                }
            };

            _supplierRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(suppliers);

            // Act: Retrieve all suppliers through the actual service.
            var result = await _supplierService.GetAllAsync();

            // Assert: Both suppliers should be returned.
            Assert.Equal(2, result.Count());
        }


        // =========================================================
        // 2. GetByIdAsync
        // =========================================================

        [Fact]
        public async Task GetByIdAsync_WhenSupplierExists_ReturnsDto()
        {
            // Arrange: Configure the repository to return a supplier.
            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(supplier);

            // Act: Request supplier ID 1.
            var result = await _supplierService.GetByIdAsync(1);

            // Assert: Verify that the entity was mapped to a DTO.
            Assert.NotNull(result);
            Assert.Equal("SUP001", result.SupplierCode);
            Assert.Equal("ABC Suppliers", result.SupplierName);
        }


        [Fact]
        public async Task GetByIdAsync_WhenSupplierDoesNotExist_ReturnsNull()
        {
            // Arrange: Simulate a missing supplier.
            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(99))
                .ReturnsAsync((Supplier?)null);

            // Act: Request a nonexistent supplier.
            var result = await _supplierService.GetByIdAsync(99);

            // Assert: The service should return null.
            Assert.Null(result);
        }


        // =========================================================
        // 3. AddAsync
        // =========================================================

        [Fact]
        public async Task AddAsync_AddsSupplierAndSavesChanges()
        {
            // Arrange: Prepare the new supplier DTO.
            var dto = new CreateSupplierDto
            {
                SupplierCode = "SUP003",
                SupplierName = "New Supplier"
            };

            // Simulate successful repository addition.
            _supplierRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Supplier>()))
                .Returns(Task.CompletedTask);

            // Simulate successful save.
            _unitOfWorkMock
                .Setup(u => u.SaveAsync())
                .ReturnsAsync(1);

            // Act: Add the supplier.
            await _supplierService.AddAsync(dto);

            // Assert: Verify the supplier was added with correct data.
            _supplierRepositoryMock.Verify(
                r => r.AddAsync(It.Is<Supplier>(
                    s => s.SupplierCode == "SUP003"
                      && s.SupplierName == "New Supplier")),
                Times.Once);

            // Verify that pending changes were saved.
            _unitOfWorkMock.Verify(
                u => u.SaveAsync(),
                Times.Once);
        }


        // =========================================================
        // 4. UpdateAsync
        // =========================================================

        [Fact]
        public async Task UpdateAsync_WhenSupplierExists_UpdatesSupplier()
        {
            // Arrange: Existing supplier.
            var supplier = CreateSupplier();

            var dto = new UpdateSupplierDto
            {
                SupplierId = 1,
                SupplierCode = "SUP001",
                SupplierName = "Updated Supplier"
            };

            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(supplier);

            _unitOfWorkMock
                .Setup(u => u.SaveAsync())
                .ReturnsAsync(1);

            // Act: Update the supplier.
            await _supplierService.UpdateAsync(dto);

            // Assert: Verify updated data and repository operation.
            Assert.Equal("Updated Supplier", supplier.SupplierName);

            _supplierRepositoryMock.Verify(
                r => r.Update(supplier),
                Times.Once);

            _unitOfWorkMock.Verify(
                u => u.SaveAsync(),
                Times.Once);
        }


        [Fact]
        public async Task UpdateAsync_WhenSupplierDoesNotExist_ThrowsException()
        {
            // Arrange: Simulate a missing supplier.
            var dto = new UpdateSupplierDto
            {
                SupplierId = 99
            };

            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(99))
                .ReturnsAsync((Supplier?)null);

            // Act and Assert: Updating a missing supplier must fail.
            await Assert.ThrowsAsync<Exception>(
                () => _supplierService.UpdateAsync(dto));
        }


        // =========================================================
        // 5. DeleteAsync
        // =========================================================

        [Fact]
        public async Task DeleteAsync_WhenSupplierExists_DeletesSupplier()
        {
            // Arrange: Existing supplier.
            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(supplier);

            _unitOfWorkMock
                .Setup(u => u.SaveAsync())
                .ReturnsAsync(1);

            // Act: Delete supplier ID 1.
            await _supplierService.DeleteAsync(1);

            // Assert: Verify deletion and saving.
            _supplierRepositoryMock.Verify(
                r => r.Delete(supplier),
                Times.Once);

            _unitOfWorkMock.Verify(
                u => u.SaveAsync(),
                Times.Once);
        }


        [Fact]
        public async Task DeleteAsync_WhenSupplierDoesNotExist_ThrowsException()
        {
            // Arrange: Supplier ID 99 does not exist.
            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(99))
                .ReturnsAsync((Supplier?)null);

            // Act and Assert: The service should throw an exception.
            await Assert.ThrowsAsync<Exception>(
                () => _supplierService.DeleteAsync(99));
        }


        // =========================================================
        // 6. DeleteMultipleAsync
        // =========================================================

        [Fact]
        public async Task DeleteMultipleAsync_DeletesExistingSuppliers()
        {
            // Arrange: Prepare one supplier for deletion.
            var supplier = CreateSupplier();

            var dto = new DeleteMultipleSuppliersDto
            {
                Ids = new List<int> { 1 }
            };

            _supplierRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(supplier);

            _unitOfWorkMock
                .Setup(u => u.SaveAsync())
                .ReturnsAsync(1);

            // Act: Delete all IDs supplied in the DTO.
            await _supplierService.DeleteMultipleAsync(dto);

            // Assert: Verify deletion and saving.
            _supplierRepositoryMock.Verify(
                r => r.Delete(supplier),
                Times.Once);

            _unitOfWorkMock.Verify(
                u => u.SaveAsync(),
                Times.Once);
        }


        // =========================================================
        // 7. GetByCodeAsync
        // =========================================================

        [Fact]
        public async Task GetByCodeAsync_WhenSupplierExists_ReturnsDto()
        {
            // Arrange: Configure the repository response.
            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetByCodeAsync("SUP001"))
                .ReturnsAsync(supplier);

            // Act: Search by supplier code.
            var result =
                await _supplierService.GetByCodeAsync("SUP001");

            // Assert: Verify the returned DTO.
            Assert.NotNull(result);
            Assert.Equal("SUP001", result.SupplierCode);
        }


        // =========================================================
        // 8. SearchAsync
        // =========================================================

        [Fact]
        public async Task SearchAsync_ReturnsMatchingSuppliers()
        {
            // Arrange: Simulate a search result.
            var suppliers = new List<Supplier>
            {
                CreateSupplier()
            };

            _supplierRepositoryMock
                .Setup(r => r.SearchAsync("ABC"))
                .ReturnsAsync(suppliers);

            // Act: Search for suppliers using a keyword.
            var result = await _supplierService.SearchAsync("ABC");

            // Assert: Verify the matching supplier is returned.
            Assert.Single(result);
            Assert.Equal("ABC Suppliers", result.First().SupplierName);
        }


        // =========================================================
        // 9. GetByTypeAsync
        // =========================================================

        [Fact]
        public async Task GetByTypeAsync_ReturnsSuppliersOfRequestedType()
        {
            // Arrange: Supplier of the requested type.
            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetByTypeAsync("Raw Material"))
                .ReturnsAsync(new List<Supplier> { supplier });

            // Act: Retrieve suppliers by type.
            var result =
                await _supplierService.GetByTypeAsync("Raw Material");

            // Assert: Verify the returned supplier.
            Assert.Single(result);
            Assert.Equal("Raw Material", result.First().SupplierType);
        }


        // =========================================================
        // 10. GetApprovedSuppliersAsync
        // =========================================================

        [Fact]
        public async Task GetApprovedSuppliersAsync_ReturnsSuppliers()
        {
            // Arrange: Simulate the repository response.
            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetApprovedSuppliersAsync())
                .ReturnsAsync(new List<Supplier> { supplier });

            // Act: Retrieve approved suppliers.
            var result =
                await _supplierService.GetApprovedSuppliersAsync();

            // Assert: Verify that a supplier was returned.
            Assert.Single(result);
            Assert.True(result.First().IsApproved);
        }


        // =========================================================
        // 11. GetActiveSuppliersAsync
        // =========================================================

        [Fact]
        public async Task GetActiveSuppliersAsync_ReturnsSuppliers()
        {
            // Arrange: Create an active supplier.
            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetActiveSuppliersAsync())
                .ReturnsAsync(new List<Supplier> { supplier });

            // Act: Retrieve active suppliers.
            var result =
                await _supplierService.GetActiveSuppliersAsync();

            // Assert: Verify the returned supplier is active.
            Assert.Single(result);
            Assert.True(result.First().IsActive);
        }


        // =========================================================
        // 12. GetInactiveSuppliersAsync
        // =========================================================

        [Fact]
        public async Task GetInactiveSuppliersAsync_ReturnsSuppliers()
        {
            // Arrange: Prepare an inactive supplier.
            var supplier = CreateSupplier();
            supplier.IsActive = false;

            _supplierRepositoryMock
                .Setup(r => r.GetInactiveSuppliersAsync())
                .ReturnsAsync(new List<Supplier> { supplier });

            // Act: Retrieve inactive suppliers.
            var result =
                await _supplierService.GetInactiveSuppliersAsync();

            // Assert: Verify the supplier is inactive.
            Assert.Single(result);
            Assert.False(result.First().IsActive);
        }


        // =========================================================
        // 13. GetByDateRangeAsync
        // =========================================================

        [Fact]
        public async Task GetByDateRangeAsync_ReturnsSuppliers()
        {
            // Arrange: Define the requested date range.
            var fromDate = new DateTime(2026, 1, 1);
            var toDate = new DateTime(2026, 12, 31);

            var supplier = CreateSupplier();

            _supplierRepositoryMock
                .Setup(r => r.GetByDateRangeAsync(fromDate, toDate))
                .ReturnsAsync(new List<Supplier> { supplier });

            // Act: Retrieve suppliers within the date range.
            var result = await _supplierService.GetByDateRangeAsync(
                fromDate, toDate);

            // Assert: Verify that the result contains a supplier.
            Assert.Single(result);
        }


        // =========================================================
        // 14. IsSupplierCodeExistsAsync
        // =========================================================

        [Fact]
        public async Task IsSupplierCodeExistsAsync_WhenCodeExists_ReturnsTrue()
        {
            // Arrange: Simulate an existing supplier code.
            _supplierRepositoryMock
                .Setup(r => r.IsSupplierCodeExistsAsync("SUP001"))
                .ReturnsAsync(true);

            // Act: Check whether the code exists.
            var result =
                await _supplierService.IsSupplierCodeExistsAsync("SUP001");

            // Assert: The result should be true.
            Assert.True(result);
        }


        // =========================================================
        // 15. IsGstNumberExistsAsync
        // =========================================================

        [Fact]
        public async Task IsGstNumberExistsAsync_WhenGstExists_ReturnsTrue()
        {
            // Arrange: Simulate an existing GST number.
            _supplierRepositoryMock
                .Setup(r => r.IsGstNumberExistsAsync("GST123"))
                .ReturnsAsync(true);

            // Act: Check whether the GST number exists.
            var result =
                await _supplierService.IsGstNumberExistsAsync("GST123");

            // Assert: The result should be true.
            Assert.True(result);
        }


        // =========================================================
        // 16. IsPanNumberExistsAsync
        // =========================================================

        [Fact]
        public async Task IsPanNumberExistsAsync_WhenPanExists_ReturnsTrue()
        {
            // Arrange: Simulate an existing PAN number.
            _supplierRepositoryMock
                .Setup(r => r.IsPanNumberExistsAsync("PAN123"))
                .ReturnsAsync(true);

            // Act: Check whether the PAN number exists.
            var result =
                await _supplierService.IsPanNumberExistsAsync("PAN123");

            // Assert: The result should be true.
            Assert.True(result);
        }
    }
}
