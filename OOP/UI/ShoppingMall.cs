using OOP.Domain;

namespace OOP.UI {
    internal class ShoppingMall {
        private readonly IAuthScreen authScreen;
        private readonly IHomeScreen homeScreen;

        public ShoppingMall() {
            this.authScreen = new AuthScreen();
            this.homeScreen = new HomeScreen();
        }

        public void Init() {
            UserDto user = this.authScreen.Auth();
            if (user == null) {
                this.Init();
            }

            this.homeScreen.Main(user);
        }
    }
}