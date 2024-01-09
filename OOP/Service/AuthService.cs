using System;
using OOP.Domain;
using OOP.Repository;

namespace OOP.Service {
    interface IAuthService {
        bool SignUp(string email, string password, string nickname, int money, string userType);
        UserDto LogIn(string email, string password);
    }

    internal class AuthService : IAuthService {
        private IUserRepository _userRepository;

        public AuthService() {
            this._userRepository = new UserRepository();
        }

        public bool SignUp(string email, string password, string nickname, int money, string userType) {
            // User user = this._userRepository.FindUserByEmail(email);
            // if (user != null) {
            // Console.WriteLine("중복된 이메일입니다. 다시 입력해주세요.");
            // return false;
            // }

            this._userRepository.CreateUser(email, password, nickname, money, userType);
            Console.WriteLine("회원가입이 완료되었습니다.");
            return true;
        }

        public UserDto LogIn(string email, string password) {
            User user = this._userRepository.FindUserByEmailAndPassword(email, password);
            if (user == null) {
                return null;
            }
            else {
                return user.ConvertDto();
            }
        }
    }
}