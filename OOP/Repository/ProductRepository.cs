using System.Collections;
using System.Data;
using OOP.Infra;
using System.Random;

namespace OOP.Repository {
    interface IProductRepository {
        int createProductId();
        void createProduct(string title, int price, string content, string sellerEmail);
        object findProductById(int productId);
        ArrayList findSellerProductsByEmail(string email);
        ArrayList findSellingProducts();
    }

    public class ProductRepository : BaseRepository, IProductRepository {
        private IDatabase db;

        public ProductRepository() {
            this.db = Database.Instance;
        }
        
        private Random random = new Random();
        public int createProductId()
        {
            int productId = random.Next(0, 10000);
            var product = findProductById(productId);
        
            if (product != null)
            {
                return createProductId();
            }

            return productId;
        }
        
        public void createProduct(string title, int price, string content, string sellerEmail) {
            int productId = createProductId();
            bool isSelling = true;
            string buyerEmail = null;
            this.db.Write();
        }

        public object findProductById(int productId) {
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