using System;
using System.Collections;
using System.Collections.Generic;
using OOP.Domain;
using OOP.Service;

namespace OOP.UI {
    internal class HomeScreen {
        private AuthService authService;
        private ProductService productService;
        private User user;
        private Product product;

        public void Main(UserDto user) {
            // user 딕셔너리.. 그 타입 앞에 적어줄 때
            // UserDto랑 Dictionary<string, object> 랑 머가 다름가요??
            this.user = this.user;
            //처음에 'buyer' 'seller' 쓰니까 오류 뜨길래 구글링 해보니 저헣게 하라 해서 그냥 함..
            //처음에 에러 뜬 이유를 모르겠음
            if (this.user.GetUserType() == @"buyer") {
                Console.WriteLine("구매자 메인 화면입니다");
                this.BuyerMainScreen();
            }

            if (this.user.GetUserType() == @"seller") {
                Console.WriteLine("판매자 메인 화면입니다");
                this.SellerMainScreen();
            }
        }

        public void SellerMainScreen() {
            Console.WriteLine("=====이메일 정보입니다=====");
            Console.WriteLine(this.user.GetEmail());

            Console.WriteLine("=====보유중인 상품 목록입니다=====");
            ArrayList products = this.productService.GetMySellingProducts(this.user.GetEmail());
            {
                // for 문 쓰고 싶은데 자꾸 오류 뜸... 밑에도 마찬가지!!
                // for (product in products)
                // {
                Console.WriteLine(product.GetId(), product.GetTitlle(), product.GetTitlle());
                // }
            }
            Console.WriteLine("=====계좌 잔액입니다=====");
            Console.WriteLine(this.user.GetMoney());

            Console.WriteLine("=====상품 추가 페이지 입니다=====");
            string email = this.user.GetEmail();

            Console.WriteLine("추가하고 싶은 상품의 이름을 입력하세요: ");
            string title = Console.ReadLine();

            Console.WriteLine("추가하고 싶은 상품의 가격을 입력하세요: ");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("추가하고 싶은 상품의 콘텐츠를 입력하세요: ");
            string content = Console.ReadLine();

            this.productService.AddSellingProduct(title, price, content, email);
            Console.WriteLine("상품이 추가되었습니다.");

            this.SellerMainScreen();
        }

        public void BuyerMainScreen() {
            Console.WriteLine("=====이메일 정보입니다=====");
            Console.WriteLine(this.user.GetEmail());

            Console.WriteLine("=====판매중인 상품 목록입니다=====");
            ArrayList products = this.productService.GetMySellingProducts(this.user.GetEmail());
            // for (object product in products);
            Console.WriteLine(product.GetId(), product.GetTitlle(), product.GetContent(), product.GetPrice());

            Console.WriteLine("=====계좌 잔액입니다=====");
            Console.WriteLine(this.user.GetMoney());

            Console.WriteLine("구매하고 싶은 상품 아이디를 입력하세요: ");

            string productId = Console.ReadLine();
            object boughtProduct = this.productService.BuyProduct(this.user.GetEmail(), productId);
            if (boughtProduct != null) {
                Console.WriteLine("구매가 완료되었습니다.");
            }

            this.BuyerMainScreen();
        }
    }
}