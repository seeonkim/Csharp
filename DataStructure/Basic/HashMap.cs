namespace DataStructure.Basic {
    // 해쉬 테이블

    // 1. 다이렉트 엑세스 테이블

    // 키 - 값의 쌍으로 데이터를 저장한다
    // 키를 일종의 숫자로 생각하면, 최대 키값을 배열의 길이로 가지는 큰 배열을 가정하고
    // 각각의 키를 인덱스로 해서 데이터를 저장하면 된다
    // 이렇게 되면 배열의 접근과 마찬가지로 O(1)의 시간안에 데이터에 접근이 가능하다
    // 이러한 구조를 다이렉트 엑세스 테이블이라고 하는데...이건 공간의 낭비가 너어무 심하다
    // (배열의 길이는 긴데, 빈 공간은 많게 됨)

    // 2. 해쉬 테이블

    // 우선 고정된 길이의 배열을 만든 다음
    // 해쉬함수 = 특정 값을 "원하는 범위의 자연수로" 바꿔주는 함수(ex: 나머지 연산 함수)
    // 해쉬함수(키) = 인덱스 로 하고
    // 배열의 해당 인덱스에 (키, 값)을 모두 저장한다
    // 해쉬함수의 조건은
    // - 한 해시 테이블의 해시 함수는 결정론적이어야 된다(해시의 결과가 다르면 원래의 값도 다르다)
    // - 결과 해시값이 치우치지 않고 고르게 나온다(충돌되는 정도가 고르게 분포되어야 한다)
    // - 빨리 계산할 수 있어야 된다
    // 해쉬 함수 예시: 나머지 연산

    // 해쉬 충돌이 일어나면
    // 1. 하나의 키에 링크드리스트를 넣어주자: 체이닝 방법

    // 접근과 탐색
    // 해시 함수 계산 O(1) => 배열 인덱스 접근 O(1) => 링크드 리스트 탐색 O(m)
    // 최악의 경우 O(n)
    // 해시 테이블을 만들 때 항상 충분히 여유롭게
    // 총 저장하는 key - value 쌍 수와 해시 테이블이 사용하는 배열의 크기를 비슷하거나 작다고 가정
    // 평균적으로 O(1)

    // 삽입
    // 해시 함수 계산 O(1) => 배열 인덱스 접근 O(1) => 링크드 리스트 탐색 O(m)
    // => 링크드리스트에 없는 경우 추가하고
    // => 링크드리스트에 있는 경우 키률 유지하고 데이터만 변경 O(1)
    // 최악의 경우 O(n), 평균적으로 O(1)

    // 삭제
    // 삽입과 동일한 시간 복잡도를 가진다


    // 2. 오픈 어드레싱 방법
    // 충돌이 일어나는 경우 둘 중 하나를 값이 없는 다른 인덱스에 저장하는 방법
    // 값이 없는 인덱스를 어떻게 찾을까?

    // 1. 선형으로 탐사해서 찾을 수 있다: 10에서 1씩 증가시키면서 체크 11, 12, 13, 14...
    // 탐색: 탐색을 하다가 비어있는 인덱스를 만났다면 해당 값은 없다는 뜻임
    // 삭제: 진짜로 지워버리면 중간에 빈칸이 생겨서 다른 값을 탐색할 때 문제가 생김 => 삭제 대신 약속된 형태로 표시를 해두자
    // 삽입: 탐색해보고 없으면 추가하면 댐
    // 대강 최악은 o(n) 평균은 o(1)//

    // 제곱탐사도 가능: 10에서 제곱수만큼 증가시키면서 체크 11, 15, 24...
    internal class HashNode<T> {
        private string key;
        private T value;

        public HashNode(string key, T value) {
            this.key = key;
            this.value = value;
        }

        public string Key {
            get { return this.key; }
        }

        public T Value {
            get { return this.value; }
        }
    }

    public class HashMap<T> where T : class {
        private int capacity;
        private LinkedList<HashNode<T>>[] list;

        public HashMap() {
            this.capacity = 7;
            this.list = new LinkedList<HashNode<T>>[this.capacity];
            for (int i = 0; i < this.list.Length; i++) {
                this.list[i] = new LinkedList<HashNode<T>>();
            }
        }

        private int Hash(string key) {
            int hashCode = key.GetHashCode();
            int result = hashCode % this.capacity;
            if (result >= 0) {
                return result;
            }
            else {
                return result + this.capacity;
            }
        }

        // 추가
        public void Add(string key, T value) {
            int hashedKey = this.Hash(key);
            this.list[hashedKey].Add(new HashNode<T>(key, value));
        }

        // 삭제

        // 삽입

        // 검색
        public T Get(string key) {
            int hashedKey = this.Hash(key);

            LinkedList<HashNode<T>> linkedList = this.list[hashedKey];
            for (int i = 0; i < linkedList.Count; i++) {
                HashNode<T> hashNode = linkedList.At(i) as HashNode<T>;
                if (key == hashNode.Key) {
                    return hashNode.Value;
                }
            }

            return null;
        }

        // 출력
    }
}