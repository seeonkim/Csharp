using System.Collections;
using System.Data;
using OOP.Infra;

namespace OOP.Repository {
    interface IProductRepository {
        string createProductId();
        void createProduct(string title, int price, string content, string sellerEmail);
        object findProductById(string productId);
        ArrayList findSellerProductsByEmail(string email);
        ArrayList findSellingProducts();
    }

    public class ProductRepository : BaseRepository, IProductRepository {
        private IDatabase db;

        public ProductRepository() {
            this.db = Database.Instance;
        }

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