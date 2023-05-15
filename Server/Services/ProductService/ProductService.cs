using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Services.ProductService
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
            //var product = await _dataContext.Products.FindAsync(id);
            var product = await _dataContext.Products
                .Include(p=> p.Variants)
                .ThenInclude(v=> v.ProductType)
                .FirstOrDefaultAsync(p=> p.Id == id);
                //fill the "ProductVariant" of Product model with given id  == "Include",
                //fill the "ProductType" of Product model's ProducVariant with given id  == "ThenInclude"
            if (product == null)
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
            response.Data = await _dataContext.Products
                .Include(p => p.Variants)
                .ToListAsync();
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

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>();
            var products = await FindProductsBySearchText(searchText);
            response.Data = products;

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            List<string> results = new List<string>();
            ServiceResponse<List<string>> response = new ServiceResponse<List<string>>();
            var products = await FindProductsBySearchText(searchText);
            
            foreach (var item in products)
            {
                if (item.Title.ToLower().Contains(searchText.ToLower()))
                {
                    results.Add(item.Title);
                }
                if(item.Description != null)
                {
                    var punctutation = item.Description.ToLower()
                        .Where(char.IsPunctuation)
                        .Distinct()
                        .ToArray();
                    var words = item.Description.ToLower()
                        .Split()
                        .Select(s => s.Trim(punctutation));

                    foreach(var word in words)
                    {
                        if(word.Contains(searchText.ToLower()) && !results.Contains(word))
                        {
                            results.Add(word);
                        }
                    }
                }
            }
            response.Data = results;

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _dataContext.Products
                .Where(p =>
                        p.Title.ToLower().Contains(searchText.ToLower())
                        ||
                        p.Description.ToLower().Contains(searchText.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync();
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>();
            response.Data = await _dataContext.Products.Where(p => p.Featured)
                .Include(p=> p.Variants)
                .ToListAsync();

            return response;
        }
    }
}
