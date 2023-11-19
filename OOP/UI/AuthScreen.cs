using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using OOP.Domain;
using OOP.Service;

namespace OOP.UI {
    internal class AuthScreen {
        private AuthService service;

        public AuthScreen() {
            this.service = new AuthService();
        }

        public UserDto Auth() {
            Console.WriteLine("회원 가입(0) | 로그인(1): ");
            int authChoice = int.Parse(Console.ReadLine());
            Console.WriteLine(authChoice);
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
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine("유저의 타입(buyer/seller)을 입력하세요: ");
            string userType = Console.ReadLine();
            bool isSignedUp = this.service.SignUp(email, password, nickname, money, userType);
            
            return isSignedUp;
        }

        public UserDto Login() {
            Console.WriteLine("이메일을 입력하세요: ");
            string email = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력하세요: ");
            string password = Console.ReadLine();
            UserDto user = this.service.LogIn(email, password);
                
            return user;
        }
    }
}
//login 함수가 반환하는 값은 user
 //(딕셔너리 형태.. 딕셔너리 형태는 <키, 값>을 쓰라고 하는데 값으로는 여러타입의 값을 반환함..