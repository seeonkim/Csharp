using System.Collections;
using System.Collections.Generic;
using OOP.Domain;
using OOP.Repository;

namespace OOP.Service {
    interface IProductService {
        List<ProductDto> GetMySellingProducts(string email);
        bool AddSellingProduct(string title, int price, string content, string sellerEmail);
        object BuyProduct(string email, string productId);
    }

    internal class ProductService : IProductService {
        private readonly IProductRepository _productRepository;

        public ProductService() {
            this._productRepository = new ProductRepository();
        }

        public List<ProductDto> GetMySellingProducts(string email) {
            List<Product> products = this._productRepository.findSellerProductsByEmail(email);
            List<ProductDto> productDtos = new List<ProductDto>();
            for (int i = 0; i < products.Count; i++) {
                productDtos.Add(products[i].ConvertDTO());
            }

            return productDtos;
        }

        public bool AddSellingProduct(string title, int price, string content, string sellerEmail) {
            this._productRepository.createProduct(title, price, content, sellerEmail);
            return true;
        }

        public object BuyProduct(string email, string productId) {
            throw new System.NotImplementedException();
        }
    }
}