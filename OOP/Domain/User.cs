using System.Collections.Generic;

namespace OOP.Domain {
    internal class UserDto {
        public readonly string email;
        public readonly string nickname;
        public readonly int money;
        public readonly string userType;

        public UserDto(string email, string nickname, int money, string userType) {
            this.email = email;
            this.nickname = nickname;
            this.money = money;
            this.userType = userType;
        }
    }

    internal class User {
        // 인스턴스 변수
        private string email;
        private string password;
        private string nickname;
        private int money;
        private string userType;

        // 생성자
        public User(string email, string password, string nickname, int money, string userType) {
            this.email = email;
            this.password = password;
            this.nickname = nickname;
            this.money = money;
            this.userType = userType;
        }

        // 메소드
        public string GetEmail() {
            return this.email;
        }

        public string GetPassword() {
            return this.password;
        }

        public string GetNickname() {
            return this.nickname;
        }

        public int GetMoney() {
            return this.money;
        }

        public string GetUserType() {
            return this.userType;
        }

        public object ConvertDto() {
            return new {
                email = GetEmail(),
                nickname = GetNickname(),
                money = GetMoney(),
                userType = GetUserType()
            };
        }

        public bool Income(int money) {
            this.money += money;
            return true;
        }

        public bool Withdraw(int money) {
            if (this.money < money) {
                return false;
            }
            else {
                this.money -= money;
                return true;
            }
        }
    }
}