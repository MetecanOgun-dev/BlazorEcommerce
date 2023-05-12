namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("/api/category");
            if(response != null && response.Data != null)
            {
                Categories = response.Data;
            }
        }

        public async Task<ServiceResponse<Category>> GetCategory(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Category>>($"/api/category/{id}");
            if(response != null && response.Data != null)
            {
                var category = response.Data;
                return response;
            }
            return response;
        }
    }
}
