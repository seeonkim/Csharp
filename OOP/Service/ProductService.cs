using System.Collections;
using System.Collections.Generic;
using OOP.Domain;

namespace OOP.Service {
    interface IProductService {
        List<ProductDto> GetMySellingProducts(string email);
        void AddSellingProduct(string title, int price, string content, string sellerEmail);
        object BuyProduct(string email, string productId);
    }

    internal class ProductService : IProductService {
        public List<ProductDto> GetMySellingProducts(string email) {
            throw new System.NotImplementedException();
        }

        public void AddSellingProduct(string title, int price, string content, string sellerEmail) {
            throw new System.NotImplementedException();
        }

        public object BuyProduct(string email, string productId) {
            throw new System.NotImplementedException();
        }
    }
}