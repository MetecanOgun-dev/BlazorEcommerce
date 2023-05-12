using System.Diagnostics.Tracing;

namespace BlazorEcommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task<ServiceResponse<Category>> GetCategory(int id);
        Task GetCategories();
    }
}
