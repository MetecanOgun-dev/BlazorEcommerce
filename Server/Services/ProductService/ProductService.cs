﻿namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _dataContext.Products.FindAsync(id);
            if(product == null)
            {
                response.Sucess = false;
                response.Message = "Product Does not exist";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductListAsync()
        {
            var response = new ServiceResponse<List<Product>>();
            response.Data = await _dataContext.Products.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>();
            response.Data = await _dataContext.Products
                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .ToListAsync();
            return response;
        }
    }
}
