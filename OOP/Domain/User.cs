namespace OOP.Domain {
    internal class UserDto {
        public readonly string Email;
        public readonly string Nickname;
        public readonly int Money;
        public readonly string UserType;

        public UserDto(string email, string nickname, int money, string userType) {
            this.Email = email;
            this.Nickname = nickname;
            this.Money = money;
            this.UserType = userType;
        }
    }

    internal class User {
        // 인스턴스 변수
        private readonly string _email;
        private readonly string _password;
        private readonly string _nickname;
        private int _money;
        private readonly string _userType;

        // 생성자
        public User(string email, string password, string nickname, int money, string userType) {
            this._email = email;
            this._password = password;
            this._nickname = nickname;
            this._money = money;
            this._userType = userType;
        }

        // 인스턴스 메소드
        public string Email {
            get { return this._email; }
        }

        public string Password {
            get { return this._password; }
        }

        public string Nickname {
            get { return this._nickname; }
        }

        public int Money {
            get { return this._money; }
        }

        public string UserType {
            get { return this._userType; }
        }

        public UserDto ConvertDto() {
            return new UserDto(
                this._email,
                this._nickname,
                this._money,
                this._userType
            );
        }

        public bool Income(int money) {
            this._money += money;
            return true;
        }

        public bool Withdraw(int money) {
            if (this._money < money) {
                return false;
            }
            else {
                this._money -= money;
                return true;
            }
        }
    }
}