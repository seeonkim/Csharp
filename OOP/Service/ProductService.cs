using System;
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
        private readonly IUserRepository _userRepository;

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
            User buyer = this._userRepository.FindUserByEmail(email);
        
            if (buyer == null) {
                Console.WriteLine("잘못된 접근입니다");
                return null;
            }
            
            Product product = this._productRepository.findProductByProductID(productId);
            if (product == null) {
                Console.WriteLine("상품이 없습니다.");
                return null;
            }

            if (product.GetIsSelling() != true) {
                Console.WriteLine("판매중인 상태가 아닙니다");
                return null;
            }

            if (buyer.Money < product.GetPrice()) {
                Console.WriteLine("잔액이 없어요");
                return null;
            }

            User seller = this._userRepository.FindUserByEmail(product.GetSellerEmail());
            
            bool result = buyer.Withdraw(product.GetPrice());
            if (result == false) {
                Console.WriteLine("오류 발생");
                return null;
            }

            seller.Income(product.GetPrice());
            product.setSoldOut(buyer.Email);

            // this._userRepository.save();
            // this._productRepository.save();
            // this._productRepository.save();
            
            // 각 repository에 save 함수 구현하려고 했는데?
            // 파이썬에서는 base repository에 save가 있었음 >> 여기서는 각각..?
            // save 함수는 database의 update 함수를 이용함
            // update 함수를 구현하긴 했는데 애매..
            return product;
        }
    }
}