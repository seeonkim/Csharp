using System.Collections.Generic;
using OOP.Repositoryy;
using OOP.Domain;

namespace OOP.Service {
    interface IAuthService {
        bool SignUp(string email, string password, string nickname, int money, string userType);
        UserDto LogIn(string email, string password);
    }

    internal class AuthService : IAuthService {
        public bool SignUp(string email, string password, string nickname, int money, string userType) {
            throw new System.NotImplementedException();
        }

        public UserDto LogIn(string email, string password) {
                throw new System.NotImplementedException();
            }
        }
    }
