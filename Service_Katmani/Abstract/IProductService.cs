using Service_Katmani.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Katmani.Abstract
{
    public interface IProductService
    {
        void AddProduct(ProductDto dto);
        void UpdateProduct(ProductDto dto);
        void DeleteProduct(int id);
        IQueryable<ProductDto> GetAllProducts();
    }
}
