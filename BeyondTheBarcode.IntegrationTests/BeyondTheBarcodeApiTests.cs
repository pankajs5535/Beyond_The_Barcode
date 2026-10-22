using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BeyondTheBarcode.IntegrationTests
{
    public class BeyondTheBarcodeApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public BeyondTheBarcodeApiTests(WebApplicationFactory<Program> factory)
        {
            // Creates an HTTP client that sends requests to the test server hosting the API.
            _client = factory.CreateClient();
        }

        // 1. GET ALL SUPPLIERS
        [Fact]
        public async Task GetAllSuppliers_Should_ReturnOk()
        {
            // GetAsync sends an HTTP GET request to retrieve all suppliers.
            var response = await _client.GetAsync("/api/Supplier");

            // Verifies that the API returns HTTP 200 OK.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 2. GET SUPPLIER BY ID
        [Fact]
        public async Task GetSupplierById_Should_ReturnNotFound_WhenSupplierDoesNotExist()
        {
            // Requests a supplier ID assumed not to exist in the test database.
            var response = await _client.GetAsync("/api/Supplier/999999");

            // Verifies that the API returns HTTP 404 Not Found.
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // 3. GET SUPPLIER BY CODE
        [Fact]
        public async Task GetSupplierByCode_Should_ReturnNotFound_WhenCodeDoesNotExist()
        {
            // Requests a supplier using a test code assumed not to exist.
            var response = await _client.GetAsync("/api/Supplier/code/TEST-CODE-NOT-FOUND");

            // Verifies that the API returns HTTP 404 Not Found.
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // 4. CREATE SUPPLIER
        [Fact]
        public async Task CreateSupplier_Should_ReturnBadRequest_WhenJsonIsInvalid()
        {
            // Sends malformed JSON to verify that invalid request data is rejected.
            var content = new StringContent("{", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Supplier", content);

            // Verifies that the API rejects the malformed request with HTTP 400.
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        // 5. UPDATE SUPPLIER
        [Fact]
        public async Task UpdateSupplier_Should_ReturnBadRequest_WhenJsonIsInvalid()
        {
            // PUT sends data intended to update a supplier; malformed JSON should be rejected.
            var content = new StringContent("{", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Supplier", content);

            // Verifies that the API returns HTTP 400 for malformed request data.
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        // 6. DELETE SUPPLIER
        [Fact]
        public async Task DeleteSupplier_Should_ReturnNotFound_WhenSupplierDoesNotExist()
        {
            // Sends a DELETE request for an ID assumed not to exist.
            var response = await _client.DeleteAsync("/api/Supplier/999999");

            // Verifies that the API returns HTTP 404 without deleting a real supplier.
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // 7. DELETE MULTIPLE SUPPLIERS
        [Fact]
        public async Task DeleteMultipleSuppliers_Should_ReturnBadRequest_WhenIdsAreEmpty()
        {
            // Sends an empty ID list to verify that the API rejects an invalid deletion request.
            var content = new StringContent("{\"ids\":[]}", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Supplier/delete-multiple", content);

            // Verifies that the API returns HTTP 400 when no suppliers are selected.
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        // 8. SEARCH SUPPLIERS
        [Fact]
        public async Task SearchSuppliers_Should_ReturnBadRequest_WhenKeywordIsMissing()
        {
            // Sends a search request without the required keyword.
            var response = await _client.GetAsync("/api/Supplier/search");

            // Verifies that the API rejects a missing search keyword.
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        // 9. GET APPROVED SUPPLIERS
        [Fact]
        public async Task GetApprovedSuppliers_Should_ReturnOk()
        {
            // Requests suppliers marked as approved.
            var response = await _client.GetAsync("/api/Supplier/approved");

            // Verifies that the API successfully processes the request.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 10. GET SUPPLIERS BY TYPE
        [Fact]
        public async Task GetSuppliersByType_Should_ReturnOk()
        {
            // Requests suppliers belonging to the specified supplier type.
            var response = await _client.GetAsync("/api/Supplier/type/Raw%20Material");

            // Verifies that the API successfully processes the filtered request.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 11. GET ACTIVE SUPPLIERS
        [Fact]
        public async Task GetActiveSuppliers_Should_ReturnOk()
        {
            // Requests suppliers whose active status is true.
            var response = await _client.GetAsync("/api/Supplier/active");

            // Verifies that the API returns HTTP 200 OK.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 12. GET INACTIVE SUPPLIERS
        [Fact]
        public async Task GetInactiveSuppliers_Should_ReturnOk()
        {
            // Requests suppliers whose active status is false.
            var response = await _client.GetAsync("/api/Supplier/inactive");

            // Verifies that the API returns HTTP 200 OK.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 13. GET SUPPLIERS BY DATE RANGE
        [Fact]
        public async Task GetSuppliersByDateRange_Should_ReturnOk()
        {
            // Sends a date range to retrieve suppliers created within the specified period.
            var response = await _client.GetAsync(
                "/api/Supplier/daterange?fromDate=2026-01-01&toDate=2026-12-31");

            // Verifies that the API successfully processes the date-range request.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 14. CHECK SUPPLIER CODE
        [Fact]
        public async Task SupplierCodeExists_Should_ReturnOk()
        {
            // Checks whether the supplied test code exists; the response body may be true or false.
            var response = await _client.GetAsync(
                "/api/Supplier/exists/code/TEST-CODE-123");

            // The endpoint should return HTTP 200 for a successfully processed existence check.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 15. CHECK GST NUMBER
        [Fact]
        public async Task GstNumberExists_Should_ReturnOk()
        {
            // Checks whether the supplied test GST number exists.
            var response = await _client.GetAsync(
                "/api/Supplier/exists/gst/TEST-GST-123");

            // Verifies that the existence-check endpoint responds successfully.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // 16. CHECK PAN NUMBER
        [Fact]
        public async Task PanNumberExists_Should_ReturnOk()
        {
            // Checks whether the supplied test PAN number exists.
            var response = await _client.GetAsync(
                "/api/Supplier/exists/pan/TESTPAN1234");

            // Verifies that the existence-check endpoint responds successfully.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}