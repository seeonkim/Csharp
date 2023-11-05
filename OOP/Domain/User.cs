namespace OOP.Domain {
    internal class User {
        // 인스턴스 변수
        private string name;

        // 생성자
        public User(string name) {
            this.name = name;
        }

        // 메소드
        public string GetName() {
            return this.name;
        }
    }
}