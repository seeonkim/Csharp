using System;

namespace DataStructure.Basic {
    public class Node<T> {
        // 인스턴스 변수
        public T data;
        public Node<T> prevNode;
        public Node<T> nextNode;

        // 생성자 함수
        public Node(T data) {
            this.data = data;
            this.prevNode = null;
            this.nextNode = null;
        }
    }

    public class LinkedList<T> {
        // 인스턴스 변수
        private Node<T> headNode;
        private Node<T> tailNode;

        // 생성자
        public LinkedList() {
            headNode = null;
            tailNode = null;
        }

        // 메소드
        public void Print() {
            Node<T> currentNode = this.headNode;
            if (currentNode == null) {
                return;
            }

            while (true) {
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.nextNode;
                if (currentNode == null) {
                    break;
                }
            }
        }

        // print 메소드는, 현재 존재하는 노드들의 넘버를 순서대로 콘솔창에 적는다
        // 언제까지? nextnode가 null일 때까지! (즉, 마지막 node 일 때 까지 프린트 한다 )

        public void Add(T data) {
            if (this.headNode == null) {
                this.headNode = new Node<T>(data);
                this.tailNode = this.headNode;
            }
            else {
                Node<T> newNode = new Node<T>(data);
                this.tailNode.nextNode = newNode;
                newNode.prevNode = this.tailNode;
                this.tailNode = newNode;
            }
        }

        // add 메소드는..
        // 만약 headnode가 없다면 (아무 노드도 없다면),
        // 시작노드는 새로 만든 노드가 된다. 끝 노드도 곧 시작노드가 된다.
        // 만약 기존에 노드가 존재한다면,
        // 새로운 노드를 하나 만들고 그걸 newNode라 하자
        // 기존 끝노드의 넥스트노드는 새 노드가 된다 (뒤로 이어붙이는 느낌)
        // 새로운 노드의 전 노드는 기존의 끝노드가 된다 (이어붙인 자리를 표시해주는 느낌)
        // 이제 끝 노드는 새로운 노드가 된다!

        public object At(int index) {
            if (index < 0) {
                return null;
            }

            int i = 0;
            Node<T> currentNode = this.headNode;
            while (i < index) {
                currentNode = currentNode.nextNode;
                if (currentNode == null) {
                    return null;
                }

                i += 1;
            }

            return currentNode.data;
        }

        // 첫번째 노드의 포인터로 두번째 데이터를 찾을 수 있다
        // 반복하자..
        public bool Insert(int index, T data) {
            Node<T> insertNode = new Node<T>(data);
            if (index < 0) {
                return false;
            }

            Node<T> currentNode = this.headNode;
            int i = 0;
            while (i < index) {
                currentNode = currentNode.nextNode;
                if (currentNode.prevNode == null && currentNode == null) {
                    return false;
                }

                // 인덱스 주소 범위가 아예 넘어갈 때!
                i += 1;
            }

            if (currentNode.prevNode != null && currentNode == null) {
                currentNode.prevNode.nextNode = insertNode;
                insertNode.prevNode = currentNode.prevNode.nextNode;
            }

            // 현재노드의 전 노드는 존재하는데 현재 노드는 없을 때
            // 즉, 마지막 자리에 넣고 싶을 때!
            if (currentNode.prevNode == null && currentNode.nextNode == null) {
                this.headNode = insertNode;
                this.tailNode = insertNode;
            }

            // 원래 노드가 0개 였다면?
            if (currentNode.prevNode == null) {
                currentNode.prevNode = insertNode;
                insertNode.nextNode = currentNode;
                headNode = insertNode;
            }

            // 현재 노드가 첫번째 노드라면? 맨 처음 자리에 끼워놓고 싶을 때!
            if (currentNode.nextNode == null) {
                currentNode.prevNode = insertNode;
                insertNode.nextNode = currentNode;
            }
            // 현재노드가 마지막 노드라면? 현재노드 전 자리에 끼워놓고 싶을 때
            else {
                currentNode.prevNode = insertNode;
                insertNode.nextNode = currentNode;
                currentNode.prevNode.nextNode = insertNode;
            }

            return true;
        }
        // 여기서의 현재노드 -> 그 현재노드 자리를 오른쪽으로 한칸 밀어내고
        // 새로운 number 값을 집어 넣어야 함.


        // 현재노드가 첫번째 노드일 경우 (맨 처음에 집어넣을 경우)

        // 현재노드가 마지막 노드일 경우 (맨 마지막에 이어붙이는 경우)
        // 구현하세요 어디 넣을지? 데이터 들어갈 내용...

        //delete 메소드 구현하기
        //파라미터로 지우고 싶은 인덱스 위치를 입력받음


        public bool Delete(int index) {
            if (index < 0) {
                return false;
            }

            //만약 음수를 입력한다면 FALSE 리턴한다
            Node<T> currentNode = this.headNode;
            int i = 0;
            while (i < index) {
                currentNode = currentNode.nextNode;
                if (currentNode == null) {
                    return false;
                }

                i += 1;
            }

            //인덱스 값 만큼 헤드노드에서 이동한다! 현재노드는 다음 노드로 계속 옮겨간다.
            if (currentNode.prevNode == null && currentNode.nextNode == null) {
                this.headNode = null;
                this.tailNode = null;
            }
            //지우려는 노드가 유일한 하나였다면? 앞 뒤로 아무것도 없다고 한다.
            else if (currentNode.prevNode == null) {
                currentNode.nextNode.prevNode = null;
                this.headNode = currentNode.nextNode;
            }
            //지우려고 하는 노드가 첫번째 노드였다면? 두번째 노드가 첫번째 노드라고 생각한다.
            else if (currentNode.nextNode == null) {
                currentNode.prevNode.nextNode = null;
                this.tailNode = currentNode.prevNode;
            }
            //지우려고 하는 노드가 마지막 노드였다면? 마지막에서 두번째노드가 마지막 노드라고 생각한다.
            else {
                currentNode.prevNode.nextNode = currentNode.nextNode;
                currentNode.nextNode.prevNode = currentNode.prevNode;
            }

            //나머지 경우라면 true를 리턴한다.
            return true;
        }
    }
}