using Data_Katmani;
using Domain_Katmani;
using Service_Katmani.Abstract;
using Service_Katmani.DTOs;
using Service_Katmani.UnitofWorkPattern;
using System.Linq;


namespace Service_Katmani.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository, IUnitOfWork uow)
        {
            _uow = uow;
            _productRepository = productRepository;
        }
        public void AddProduct(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };
            _uow.Products.Add(product);
            _uow.SaveChanges();
        }
        // Benzer şekilde Update, Delete, GetAll metotları
        public void UpdateProduct(ProductDto dto)
        {
            var product = _productRepository.GetById(dto.Id);
            if (product == null) return;

            product.Name = dto.Name;
            product.Price = dto.Price;
            _productRepository.Update(product);
            _uow.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return;

            _productRepository.Delete(product);
            _uow.SaveChanges();
        }
        public IQueryable<ProductDto> GetAllProducts()
        {
            return _productRepository.GetAll()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                });
        }
        // public IQueryable<ProductDto> GetAllProducts() => _productRepository.GetAll();
    }

}
