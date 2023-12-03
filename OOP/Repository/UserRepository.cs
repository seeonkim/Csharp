using OOP.Domain;
using OOP.Infra;

namespace OOP.Repository {
    interface IUserRepository {
        void CreateUser(string email, string password, string nickname, int money, string userType);
        User FindUserByEmail(string email);
        User FindUserByEmailAndPassword(string email, string password);
    }

    internal class UserRepository : IUserRepository {
        private IDatabase db;

        public UserRepository() {
            this.db = Database.Instance;
        }

        public void CreateUser(string email, string password, string nickname, int money, string userType) {
            this.db.Write("users.csv", $"{email},{password},{nickname},{money},{userType}");
        }

        public User FindUserByEmail(string email) {
            throw new System.NotImplementedException();
        }

        public User FindUserByEmailAndPassword(string email, string password) {
            throw new System.NotImplementedException();
        }
    }
}