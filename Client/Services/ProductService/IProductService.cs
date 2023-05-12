namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task<ServiceResponse<Product>> GetProduct(int id);
        Task GetProducts();
    }
}
