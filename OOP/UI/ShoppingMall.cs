using OOP.Domain;

namespace OOP.UI {
    internal class ShoppingMall {
        private IAuthScreen _authScreen;
        private IHomeScreen _homeScreen;

        public ShoppingMall() {
            this._authScreen = new AuthScreen();
            this._homeScreen = new HomeScreen();
        }

        public void Init() {
            UserDto user = this._authScreen.Auth();
            this._homeScreen.Main(user);
        }
    }
}

//한 것

//도메인 객체에서 user랑 product 대충 완성 (자잘한 질문)
//UI 대충 거의 완성 (자잘한 질문)
//Service 내부 내용.. 다 만들어졌다는 가정 하에 코드 작성
//(변수의 종류를 제대로 썼을까? 헷갈린다)

//UserRepository, ProductRepository 내부 내용.. 다 만들어졌다는 내용 하에 코드 작성
//(변수의 종류를 제대로 썼을까? 헷갈린다)

//해야 하는 것

//Service 랑 Repository 내부 구체적으로 구현하기
//Base Repository (부모) 가 자식에게 상속하는 게 익숙하지 않아서 서비스 안은 그냥 리파지토리 각각 (user, product)
//냅다 썼는데 구현해야 한다..
//인프라 안에 데이터 베이스 (csv 파일 읽고 쓰는거..! C#에서는 어떻게 구현하면 좋을까요?)

// Auth service 내부 구현하는데 login에서 자꾸 에러가 나옴
// 데이터베이스도 대충 구현해보긴 했으나..
// 파일 경로 쓰는 거, Add Update 도 다시 해보아야 한다..!