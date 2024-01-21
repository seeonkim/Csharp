using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using OOP.Domain;
using OOP.Infra;

namespace OOP.Repository {
    interface IProductRepository {
        void createProduct(string title, int price, string content, string sellerEmail);
        List<Product> findSellerProductsByEmail(string email);
        ArrayList findSellingProducts();
    }

    public class ProductRepository : BaseRepository, IProductRepository {
        private IDatabase db;

        public ProductRepository() {
            this.db = Database.Instance;
        }

        private Random random = new Random();

        public void createProduct(string title, int price, string content, string sellerEmail) {
            int productId = this.db.GetFinalId("Products.csv") + 1;
            bool isSelling = true;
            string buyerEmail = null;
            Console.WriteLine("?????");
            this.db.Write("Products.csv",
                $"{productId},{title},{price},{content},{isSelling},{sellerEmail},{buyerEmail}");
        }

        public List<Product> findSellerProductsByEmail(string email) {
            List<ProductData> productDataList = this.db.Read<ProductData>("Products.csv");
            List<Product> products = new List<Product>();
            for (int i = 0; i < productDataList.Count; i++) {
                ProductData productData = productDataList[i];
                products.Add(new Product(productData.Id, productData.Title, productData.Price, productData.Content,
                    productData.IsSelling, productData.SellerEmail, productData.BuyerEmail));
            }

            return products;
        }

        public ArrayList findSellingProducts() {
            throw new System.NotImplementedException();
        }
    }
}