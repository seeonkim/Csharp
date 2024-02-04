using System;
using DataStructure.Basic;

namespace DataStructure {
    public class UserInfo {
        public int prettyScore;
        public int singScore;

        public UserInfo(int prettyScore, int singScore) {
            this.prettyScore = prettyScore;
            this.singScore = singScore;
        }

        public int PrettyScore {
            get => prettyScore;
            set => prettyScore = value;
        }

        public int SingScore {
            get => singScore;
            set => singScore = value;
        }
    }

    internal class Program {
        public static void Main(string[] args) {
            // 데이터를 효율적으로 사용하려면: 자료구조
            // 메모리 = RAM = Random Access Memory

            // 임의 접근 = 접근하는데 O(1)의 시간 복잡도가 걸린다
            // 순차 접근 = 접근하는데 O(n)의 시간 복잡도가 걸린다
            // 메모리는 임의 접근을 하기 때문에 메모리 공간의 주소를 알면 O(1)의 시간 복잡도로 접근이 가능하다

            // 1비트 = 스위치 1개 = on/off = 1/0 = true/false
            // 메모리 1칸 = 1바이트 = 8비트 = 256 가지의 정보 표현이 가능
            // 정수 = 메모리 4칸 = 4바이트 = 32비트 = 2^32 가지의 정보 표현이 가능 = (-2^31) ~ (0) ~ (2^31 - 1)

            // C++
            // 포인터 변수 = 주소값

            // C#, 자바, 파이썬, 자바스크립트, 타입스크립트
            // 주소를 저장하는 변수의 별명 = 주소값
            // 레퍼런스 변수 = 주소값

            // 기본 자료구조: 구현에 집중한다
            // 1. 배열(array)(동적 / 정적)
            // 2. 링크드리스트(싱글리 / 더블리)
            // 3. 해쉬테이블
            // 4. 트리
            // 5. 그래프

            // 추상 자료구조: 기능에 집중한다 / 기본 자료구조로 구현할 수 있다
            // 실제 프로그래밍을 할 때에는 기본 자료구조가 아니라 추상 자료형을 활용해서 생각하는게 실제 생선성에서 옳다

            // 1. 리스트: 순서가 있고 접근 탐색 삭제 삽입 연산이 가능한 추상 자료형 > 동적 배열 또는 링크드 리스트로 구현할 수 있다
            // 2. 스택: 맨 뒤 추가 / 맨 뒤 삭제 / 맨 뒤 접근: 동배와 링크리모두로 구현 가능 > 링크리가 유리한 듯?
            // 3. 큐: 맨 뒤 추가 / 맨 앞 삭제 / 맨 앞 접근: 동배와 링크리모두로 구현 가능 > 링크리가 유리한 듯?
            // 4. 순환큐 우선순위큐 힙 이진탐색트리
            

            // 링크드리스트
            // LinkedList<char> list = new LinkedList<char>();
            //
            // // 추가
            // list.Add('a');
            // list.Add('b');
            // list.Add('c');
            // list.Add('d');
            //
            // // 삽입
            // list.Insert(2, 'g');
            //
            // // 탐색
            // list.Print();
            // Console.WriteLine("-----");
            //
            // // 접근
            // Console.WriteLine(list.At(3));
            //
            // // 삭제
            // list.Delete(0);
            // list.Print();
            
            
            
            // 해쉬맵
            // HashMap<UserInfo> hashMap = new HashMap<UserInfo>();
            // hashMap.Add("세언", new UserInfo(99, 99));
            // hashMap.Add("세연", new UserInfo(10, 40));
            // hashMap.Add("세호", new UserInfo(20, 30));
            // hashMap.Add("세진", new UserInfo(30, 20));
            // hashMap.Add("세준", new UserInfo(40, 10));
            //
            // Console.WriteLine(hashMap.Get("세호").PrettyScore);
            // Console.WriteLine(hashMap.Get("세언").SingScore);
            
            // 바이너리 트리
            BinaryNode<int> node1 = new BinaryNode<int>(1);
            BinaryNode<int> node2 = new BinaryNode<int>(2);
            BinaryNode<int> node3 = new BinaryNode<int>(3);
            BinaryNode<int> node4 = new BinaryNode<int>(4);
            BinaryNode<int> node5 = new BinaryNode<int>(5);
            BinaryNode<int> node6 = new BinaryNode<int>(6);

            // 바이너리 트리
            node1.leftChild = node2;
            node1.rightChild = node3;
            node2.leftChild = node4;
            node2.rightChild = node5;
            node3.leftChild = node6;
            
        }
    }
}