using BlazorEcommerce.Shared.Dtos;

namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _dataContext;

        public CartService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductDTO>>();
            result.Data = new List<CartProductDTO>();

            foreach(var item in cartItems)
            {
                var product = await _dataContext.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if(product == null) // ???
                    continue;

                var productVariant = await _dataContext.ProductVariant
                    .Where(v=> v.ProductId == item.ProductId
                           &&
                           v.ProductTypeId == item.ProductTypeId)
                    .Include(v=> v.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                    continue;

                var cartProduct = new CartProductDTO
                {
                    ProductId = item.ProductId,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                    
                };
                result.Data.Add(cartProduct);
            }

            return result;
        }
    }
}
