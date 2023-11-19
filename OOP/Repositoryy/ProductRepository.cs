using System.Collections;
using System.Data;

namespace OOP.Repositoryy {
    interface IProductRepository {
        string createProductId();
        void createProduct(string title, int price, string content, string sellerEmail);
        object findProductById(string productId);
        ArrayList findSellerProductsByEmail(string email);
        ArrayList findSellingProducts();
    }

    public class ProductRepository : BaseRepository, IProductRepository {
        public string createProductId() {
            throw new System.NotImplementedException();
        }

        public void createProduct(string title, int price, string content, string sellerEmail) {
            throw new System.NotImplementedException();
        }

        public object findProductById(string productId) {
            throw new System.NotImplementedException();
        }

        public ArrayList findSellerProductsByEmail(string email) {
            throw new System.NotImplementedException();
        }

        public ArrayList findSellingProducts() {
            throw new System.NotImplementedException();
        }
    }
}