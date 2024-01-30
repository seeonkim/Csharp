using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OOP.Domain;
using OOP.Infra;

namespace OOP.Repository {
    interface IProductRepository : IBaseRepository {
        void createProduct(string title, int price, string content, string sellerEmail);
        List<Product> findSellerProductsByEmail(string email);
        List<Product> findSellingProducts();
        Product findProductByProductID(string productID);
    }

    public class ProductRepository : BaseRepository, IProductRepository {
        public ProductRepository() : base("Products.csv") {
        }

        private Random random = new Random();

        public void createProduct(string title, int price, string content, string sellerEmail) {
            int productId = this.db.GetFinalId("Products.csv") + 1;
            bool isSelling = true;
            string buyerEmail = null;
            Console.WriteLine("?????");
            this.db.Append<ProductData>("Products.csv",
                new ProductData(productId.ToString(), title, price.ToString(), content, isSelling.ToString(),
                    sellerEmail, ""));
        }

        // 입력한 이메일의 유저가 판매하고 있는 상품목록
        //즉 products.csv의 줄들을 모두 돌되, 이메일 정보가 일치하는 줄만 product service에 전달한다.
        public List<Product> findSellerProductsByEmail(string email) {
            List<ProductData> productDataList = this.db.Read<ProductData>(this.fileName);
            List<Product> products = new List<Product>();
            for (int i = 0; i < productDataList.Count; i++) {
                ProductData productData = productDataList[i];
                if (productData.SellerEmail == email) {
                    products.Add(new Product(productData.Id, productData.Title, productData.Price, productData.Content,
                        productData.IsSelling, productData.SellerEmail, productData.BuyerEmail));
                }
            }

            return products;
        }

        // 판매중인 모든 상품목록
        //즉 products.csv의 줄들을 모두 돌면서 해당 내용을 product service에 전달한다.
        public List<Product> findSellingProducts() {
            List<ProductData> productDataList = this.db.Read<ProductData>("Products.csv");
            List<Product> products = new List<Product>();
            for (int i = 0; i < productDataList.Count; i++) {
                ProductData productData = productDataList[1];
                products.Add(new Product(productData.Id, productData.Title, productData.Price, productData.Content,
                    productData.IsSelling, productData.SellerEmail, productData.BuyerEmail));
            }

            return products;
        }

        public Product findProductByProductID(string productID) {
            List<ProductData> productDataList = this.db.Read<ProductData>("Products.csv");
            for (int i = 0; i < productDataList.Count; i++) {
                ProductData productData = productDataList[i];
                if (productData.Id == productID) {
                    return new Product(productData.Id, productData.Title, productData.Price, productData.Content,
                        productData.IsSelling, productData.SellerEmail, productData.BuyerEmail);
                }
            }

            return null;
        }
    }
}