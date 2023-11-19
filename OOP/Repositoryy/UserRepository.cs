using System.Data;

namespace OOP.Repositoryy {
    interface IUserRepository {
        void CreateUser(string email, string password, string nickname, int money, string userType);
        DataRow FindUserByEmail(string email);
        DataRow FindUserByEmailAndPassword(string email, string password);
    }

    internal class UserRepository : IUserRepository {
        public void CreateUser(string email, string password, string nickname, int money, string userType) {
            throw new System.NotImplementedException();
        }

        public DataRow FindUserByEmail(string email) {
            throw new System.NotImplementedException();
        }

        public DataRow FindUserByEmailAndPassword(string email, string password) {
            throw new System.NotImplementedException();
        }
    }
}