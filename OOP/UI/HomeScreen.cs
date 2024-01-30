using System;
using System.Collections.Generic;
using OOP.Domain;
using OOP.Service;

namespace OOP.UI {
    internal interface IHomeScreen {
        void Main(UserDto user);
    }

    internal class HomeScreen : IHomeScreen {
        private readonly IProductService _productService;
        private UserDto _user;

        public HomeScreen() {
            this._productService = new ProductService();
        }

        public void Main(UserDto user) {
            this._user = user;
            if (this._user.UserType == "buyer") {
                Console.WriteLine("구매자 메인 화면입니다");
                this.BuyerMainScreen();
            }
            else if (this._user.UserType == "seller") {
                Console.WriteLine("판매자 메인 화면입니다");
                this.SellerMainScreen();
            }
        }

        public void SellerMainScreen() {
            Console.WriteLine("=====이메일 정보입니다=====");
            Console.WriteLine(this._user.Email);

            Console.WriteLine("=====보유중인 상품 목록입니다=====");
            List<ProductDto> products = this._productService.GetMySellingProducts(this._user.Email);
            for (int i = 0; i < products.Count; i++) {
                ProductDto product = products[i];
                Console.WriteLine($"{product.id}, {product.title}, {product.price}");
            }

            Console.WriteLine("=====계좌 잔액입니다=====");
            Console.WriteLine(this._user.Money);

            Console.WriteLine("=====상품 추가 페이지 입니다=====");
            Console.WriteLine("추가하고 싶은 상품의 이름을 입력하세요: ");
            string title = Console.ReadLine();
            Console.WriteLine("추가하고 싶은 상품의 가격을 입력하세요: ");
            string priceStr = Console.ReadLine();
            int price = 0;
            if (priceStr != null) {
                price = int.Parse(priceStr);
            }

            Console.WriteLine("추가하고 싶은 상품의 콘텐츠를 입력하세요: ");
            string content = Console.ReadLine();

            this._productService.AddSellingProduct(title, price, content, this._user.Email);
            Console.WriteLine("상품이 추가되었습니다.");
            this.SellerMainScreen();
        }

        public void BuyerMainScreen() {
            Console.WriteLine("=====이메일 정보입니다=====");
            Console.WriteLine(this._user.Email);

            Console.WriteLine("=====판매중인 상품 목록입니다=====");
            List<ProductDto> products = this._productService.GetMySellingProducts(this._user.Email);
            for (int i = 0; i < products.Count; i++) {
                ProductDto product = products[i];
                Console.WriteLine(product.id, product.title, product.title);
            }

            Console.WriteLine("=====계좌 잔액입니다=====");
            Console.WriteLine(this._user.Money);

            Console.WriteLine("구매하고 싶은 상품 아이디를 입력하세요: ");
            string productId = Console.ReadLine();

            object boughtProduct = this._productService.BuyProduct(this._user.Email, productId);
            if (boughtProduct != null) {
                Console.WriteLine("구매가 완료되었습니다.");
            }

            this.BuyerMainScreen();
        }
    }
}