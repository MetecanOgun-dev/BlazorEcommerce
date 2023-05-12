namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        Task<ServiceResponse<Product>> GetProduct(int id);
        Task GetProducts(string categoryUrl = null);
    }
}
