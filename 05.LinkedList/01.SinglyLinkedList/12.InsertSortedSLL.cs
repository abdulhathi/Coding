using System;

public class InsertSortedSLL {
    public InsertSortedSLL() {
        //ListNode p = CreateSLL.Create(new int[] {3,4,5,6,7,8});
        ListNode p = InsertSorted(CreateSLL.Create(new int[] {3,4,5,7,8}), 10);
        Console.WriteLine(); ListNode.Print(p);
    }
    public ListNode InsertSorted(ListNode p, int key) {
        if(p == null || p.val > key) {
            var newNode = new ListNode(key);
            newNode.next = p;
            return newNode;
        }
        ListNode first = p;
        ListNode q = null;
        while(p != null && p.val < key) {
            q = p;
            p = p.next;
        }
        q.next = new ListNode(key);
        q.next.next = p;
        return first;
    }
}