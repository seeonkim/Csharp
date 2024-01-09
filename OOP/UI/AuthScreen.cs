using System;
using OOP.Domain;
using OOP.Service;

namespace OOP.UI {
    internal interface IAuthScreen {
        UserDto Auth();
        bool SignUp();
        UserDto Login();
    }

    internal class AuthScreen : IAuthScreen {
        private readonly IAuthService _authService;

        public AuthScreen() {
            this._authService = new AuthService();
        }

        public UserDto Auth() {
            Console.WriteLine("회원 가입(0) | 로그인(1): ");
            string choice = Console.ReadLine();
            if (choice == null) {
                return null;
            }

            int authChoice = int.Parse(choice);
            if (authChoice == 0) {
                bool isSignedUp = this.SignUp();
                if (isSignedUp == false) {
                    Console.WriteLine("회원가입 실패");
                }
                else {
                    Console.WriteLine("회원가입 성공");
                }

                return this.Auth();
            }
            else {
                UserDto user = this.Login();
                if (user == null) {
                    Console.WriteLine("아이디 또는 비밀번호 오류");
                    return this.Auth();
                }
                else {
                    Console.WriteLine("로그인 성공!");
                    return user;
                }
            }
        }

        public bool SignUp() {
            Console.WriteLine("이메일을 입력하세요: ");
            string email = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력하세요: ");
            string password = Console.ReadLine();
            Console.WriteLine("유저의 이름을 입력하세요: ");
            string nickname = Console.ReadLine();
            Console.WriteLine("자산을 입력하세요: ");
            string moneyStr = Console.ReadLine();
            int money = 0;
            if (moneyStr != null) {
                money = int.Parse(moneyStr);
            }

            Console.WriteLine("유저의 타입(buyer/seller)을 입력하세요: ");
            string userType = Console.ReadLine();
            bool isSignedUp = this._authService.SignUp(email, password, nickname, money, userType);

            return isSignedUp;
        }

        public UserDto Login() {
            Console.WriteLine("이메일을 입력하세요: ");
            string email = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력하세요: ");
            string password = Console.ReadLine();
            UserDto user = this._authService.LogIn(email, password);

            return user;
        }
    }
}