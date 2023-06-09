﻿using BlazorEcommerce.Shared;
using BlazorEcommerce.Shared.Dtos;
using System.Collections.Generic;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public event Action ProductsChanged;
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public async Task GetProducts(string categoryUrl)
        {
            var result = categoryUrl != null ?
             await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/api/product/category/{categoryUrl}"):
             await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("/api/product/featured");

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            if(Products.Count == 0)
            {
                Message = "No products found.";
            }

            CurrentPage = 1;
            PageCount = 0;
            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"/api/product/{id}");

            if (result != null && result.Data != null)
            {                
                return result;
            }
            return result;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;

            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"/api/product/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if(Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"/api/product/searchsuggestions/{searchText}");
            return result.Data;
        }
    }
}
