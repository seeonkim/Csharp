using System;
using OOP.Domain;
using OOP.Repository;

namespace OOP.Service {
    interface IAuthService {
        bool SignUp(string email, string password, string nickname, int money, string userType);
        UserDto LogIn(string email, string password);
    }

    internal class AuthService : IAuthService {
        private readonly IUserRepository userRepository;

        public AuthService() {
            this.userRepository = new UserRepository();
        }

        public bool SignUp(string email, string password, string nickname, int money, string userType) {
            User user = this.userRepository.FindUserByEmail(email);
            if (user != null) {
                return false;
            }

            this.userRepository.CreateUser(email, password, nickname, money, userType);
            return true;
        }

        public UserDto LogIn(string email, string password) {
            User user = this.userRepository.FindUserByEmailAndPassword(email, password);
            if (user == null) {
                return null;
            }
            else {
                return user.ConvertDto() as UserDto;
            }
        }
    }
}