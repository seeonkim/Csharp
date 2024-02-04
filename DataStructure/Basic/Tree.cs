namespace DataStructure.Basic {
    // 트리

    // 용어
    // 루트 노드 / 형제 노드 / 리프 노드 / 자식 노드 / 부모 노드 / 깊이 / 레벨 / 높이 / 부분 트리

    // 종류
    // binary tree: 각 노드가 최대 2개의 자식 노드를 가질 수 있다
    // complete binary tree: 마지막 바로 직전 레벨까지 모든 노드가 다 채워지고 마지막 레벨은 왼쪽부터 차례대로 노드가 다 차있다
    // complete binary tree: 노드가 n개이면 높이 h는 O(로그n)

    // 활용
    // 1. 계층 관계를 가진 데이터를 저장할 때
    // 2. 정렬(힙 정렬) 압축(후프만 코드)을 매우 똑똑하게 처리하고 싶을 때
    // 3. 우선순위 큐(힙으로), 딕셔너리(BST), 셋(BST)와 같은 추상 자료형을 구현할 때
    // 우리는 다양한 트리 중에서 이진 트리의 구현에 집중해 본다

    // 추가, 삭제, 삽입, 검색, 순회
    public class BinaryNode<T> {
        public T data;
        public BinaryNode<T> leftChild;
        public BinaryNode<T> rightChild;

        public BinaryNode(T data) {
            this.data = data;
            this.leftChild = null;
            this.rightChild = null;
        }
    }


    public class Tree {
    }
}