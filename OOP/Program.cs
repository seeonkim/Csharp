using System;
using OOP.Domain;
using OOP.UI;


namespace OOP {
    internal class Program {
        public static void Main(string[] args) {
            // 기본 데이터: 캐릭터, 문자열, 정수, 소수, 불린(참, 거짓)
            // 변수에 기본 데이터를 담아서 사용한다
            // 문장을 마무리 할 때에는 ;를 사용한다
            // 들여쓰기는 {}를 사용한다
            
            // int 정수형 데이터
            // float 소수 포한 숫자형 데이터
            // char 문자열인데 한글자
            // string 문자열 데이터 "내용"
            // bool 논리형 데이터

            char gender1 = 'W';
            string name1 = "정예현";
            int money1 = 100000;
            bool canBuyMac1 = false;

            char gender2 = 'W';
            string name2 = "김민지";
            int money2 = 1000000000;
            bool canBuyMac2 = true;

            // 문자열 포멧팅 : 달러 기호를 사용한다
            // 콘솔창에 줄을 작성한다, 즉 프린트한다
            Console.WriteLine($"{name1}은 {money1}을 가지고 있어서 맥북 에어를 구매할 수 없다");
            Console.WriteLine($"{name2}은 {money2}을 가지고 있어서 맥북 에어를 구매할 수 있다");

            // 자주 등장하는 코드는 함수로 묶어서 관리한다
            // 파라미터에도 변수의 종류를 써두어야 한다
            // 함수의 정의
            void CheckCanBuyMac(string name, int money) {
                // 조건문으로 논리적인 글을 쓴다 (조건식)
                // 돈이 200만원 넘게 있으면 맥북을 구매할 수 있다
                // 그 아래면 맥북을 구매할 수 없음
                if (money >= 2000000) {
                    Console.WriteLine($"{name}은 {money}이나 가지고 있어서 맥북 에어를 구매할 수 없다");
                }
                else {
                    Console.WriteLine($"{name}은 {money}을 가지고 있어서 맥북 에어를 구매할 수 있다");
                }
            }
            // 함수의 호출
            CheckCanBuyMac(name1, money1);
            CheckCanBuyMac(name2, money2);

            // 반복적인 코드는 반복문으로 간단하게 처리한다
            // 1부터 10까지 출력
            // 반복문1
            int n2 = 1;
            while (n2 <= 10) {
                Console.WriteLine(n2);
                n2++;
            }

            // 반복문2
            int n3 = 1;
            while (true) {
                Console.WriteLine(n3);
                if (n3 == 10) {
                    break;
                }

                n3++;
            }

            // 반복문3
            for (int n = 1; n <= 10; n++) {
                Console.WriteLine(n);
            }

            User user1 = new User("abc", "apple", "seeon", 5000, "Buyer");
            Console.WriteLine(user1.GetNickname());
            AuthScreen authScreen = new AuthScreen();
            authScreen.Auth();
        }
    }
}


