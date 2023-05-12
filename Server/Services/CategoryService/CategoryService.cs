using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Category>> GetCategoryAsync(int id)
        {
            var response = new ServiceResponse<Category>();
            var category = await _dataContext.Categories.FindAsync(id);
            if(category == null)
            {
                response.Message = "Category doe not exists.";
                return response;
            }
            else
            {
                response.Data = category;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoryListAsync()
        {
            var response = new ServiceResponse<List<Category>>();
            response.Data = await _dataContext.Categories.ToListAsync();
            return response;

        }
    }
}
