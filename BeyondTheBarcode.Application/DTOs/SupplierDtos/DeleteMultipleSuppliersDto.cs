using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTheBarcode.Application.DTOs.SupplierDtos
{
    public class DeleteMultipleSuppliersDto
    {
        public List<int> Ids { get; set; } = new();
    }
}
