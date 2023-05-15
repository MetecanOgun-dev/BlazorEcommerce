using BlazorEcommerce.Shared;
using BlazorEcommerce.Shared.Dtos;

namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> cartItems);
    }
}
