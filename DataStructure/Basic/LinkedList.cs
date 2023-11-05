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
            while (true) {
                Console.WriteLine(currentNode.number);
                currentNode = currentNode.nextNode;
                if (currentNode.nextNode == null) {
                    Console.WriteLine(currentNode.number);
                    break;
                }
            }
        }

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

        public void At() {
            // 구현하세요
        }

        public void Insert() {
            // 구현하세요
        }

        public void Delete() {
        }
    }
}