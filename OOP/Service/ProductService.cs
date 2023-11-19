using System.Collections;

namespace OOP.Service {
    interface IProductService {
        ArrayList GetMySellingProducts(string email);
        void AddSellingProduct(string title, int price, string content, string sellerEmail);
        object BuyProduct(string email, string productId);
    }

    internal class ProductService : IProductService {
        public ArrayList GetMySellingProducts(string email) {
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