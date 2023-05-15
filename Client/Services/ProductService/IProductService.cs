namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        Task<ServiceResponse<Product>> GetProduct(int id);
        Task GetProducts(string categoryUrl = null);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
