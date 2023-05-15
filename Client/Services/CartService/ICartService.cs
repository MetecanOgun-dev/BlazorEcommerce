using BlazorEcommerce.Shared.Dtos;

namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductDTO>> GetCartProducts();
        Task RemoveProductsFromCard(int productId, int productTypeId);
        Task UpdateQuantity(CartProductDTO product);
    }
}
