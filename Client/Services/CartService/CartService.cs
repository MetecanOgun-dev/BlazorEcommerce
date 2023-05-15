using BlazorEcommerce.Shared;
using BlazorEcommerce.Shared.Dtos;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public CartService(ILocalStorageService localStorageService, HttpClient httpClient) : this(localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                cart = new List<CartItem>();
            }

            var isSameItem = cart.Find(x => x.ProductId == cartItem.ProductId
                                        && x.ProductTypeId == cartItem.ProductTypeId);

            if(isSameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                isSameItem.Quantity++; 
            }
            
            await _localStorageService.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductDTO>> GetCartProducts()
        {
            var cartItems = await _localStorageService.GetItemAsync<List<CartProductDTO>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductDTO>>>();
            return cartProducts.Data;
        }

        public async Task RemoveProductsFromCard(int productId, int productTypeId)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == productId
                                      && x.ProductTypeId == productTypeId);

            if(cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorageService.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
           
        }

        public async Task UpdateQuantity(CartProductDTO product)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == product.ProductId
                                      && x.ProductTypeId == product.ProductTypeId);

            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorageService.SetItemAsync("cart", cart);
            }
        }
    }
}
