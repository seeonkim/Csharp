using System;

namespace DataStructure.Basic {
    public class Node {
        // 인스턴스 변수
        public int number;
        public Node prevNode;
        public Node nextNode;

        // 생성자 함수
        public Node(int number) {
            this.number = number;
            this.prevNode = null;
            this.nextNode = null;
        }
    }

    public class LinkedList {
        // 인스턴스 변수
        private Node headNode;
        private Node tailNode;

        // 생성자
        public LinkedList() {
            headNode = null;
            tailNode = null;
        }

        // 메소드
        public void Print() {
            Node currentNode = this.headNode;
            if (currentNode == null) {
                return;
            }

            while (true) {
                Console.WriteLine(currentNode.number);
                currentNode = currentNode.nextNode;
                if (currentNode == null) {
                    break;
                }
            }
        }

        // print 메소드는, 현재 존재하는 노드들의 넘버를 순서대로 콘솔창에 적는다
        // 언제까지? nextnode가 null일 때까지! (즉, 마지막 node 일 때 까지 프린트 한다 )

        public void Add(int number) {
            if (this.headNode == null) {
                this.headNode = new Node(number);
                this.tailNode = this.headNode;
            }
            else {
                Node newNode = new Node(number);
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

        public int? At(int index) {
            if (index < 0) {
                return null;
            }

            int i = 0;
            Node currentNode = this.headNode;
            while (i < index) {
                currentNode = currentNode.nextNode;
                if (currentNode == null) {
                    return null;
                }

                i += 1;
            }

            return currentNode.number;
        }

        // 첫번째 노드의 포인터로 두번째 데이터를 찾을 수 있다
        // 반복하자..
        public void Insert(int index, int number) {
            // 구현하세요 어디 넣을지? 데이터 들어갈 내용...
        }

        public bool Delete(int index) {
            if (index < 0) {
                return false;
            }

            Node currentNode = this.headNode;
            int i = 0;
            while (i < index) {
                currentNode = currentNode.nextNode;
                if (currentNode == null) {
                    return false;
                }

                i += 1;
            }

            if (currentNode.prevNode == null && currentNode.nextNode == null) {
                this.headNode = null;
                this.tailNode = null;
            }
            else if (currentNode.prevNode == null) {
                currentNode.nextNode.prevNode = null;
                this.headNode = currentNode.nextNode;
            }
            else if (currentNode.nextNode == null) {
                currentNode.prevNode.nextNode = null;
                this.tailNode = currentNode.prevNode;
            }
            else {
                currentNode.prevNode.nextNode = currentNode.nextNode;
                currentNode.nextNode.prevNode = currentNode.prevNode;
            }

            return true;
        }
    }
}