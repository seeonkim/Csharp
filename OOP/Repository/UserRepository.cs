using System.Collections.Generic;
using OOP.Domain;

namespace OOP.Repository {
    interface IUserRepository : IBaseRepository {
        void CreateUser(string email, string password, string nickname, int money, string userType);
        User FindUserByEmail(string email);
        User FindUserByEmailAndPassword(string email, string password);
    }

    internal class UserRepository : BaseRepository, IUserRepository {
        public UserRepository() : base("Users.csv") {
        }

        public void CreateUser(string email, string password, string nickname, int money, string userType) {
            this.db.Append<UserData>(this.fileName, new UserData(email, password, nickname, money.ToString(), userType));
        }

        public User FindUserByEmail(string email) {
            List<UserData> rows = this.db.Read<UserData>("Users.csv");
            for (int i = 0; i < rows.Count; i++) {
                UserData userData = rows[i];
                if (userData.Email == email) {
                    return new User(userData.Email, userData.Password, userData.Nickname, userData.Money,
                        userData.UserType);
                }
            }

            return null;
        }

        public User FindUserByEmailAndPassword(string email, string password) {
            List<UserData> rows = this.db.Read<UserData>("users.csv");
            for (int i = 0; i < rows.Count; i++) {
                UserData userData = rows[i];
                if (userData.Email == email && userData.Password == password) {
                    return new User(userData.Email, userData.Password, userData.Nickname, userData.Money,
                        userData.UserType);
                }
            }

            return null;
        }
    }
}