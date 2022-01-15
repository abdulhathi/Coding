using System;

public class InsertInSLL {
    public InsertInSLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        var result = Insert(p, 5, new ListNode(12));
        ListNode.Print(result);
    }
    public ListNode Insert(ListNode p, int pos, ListNode newNode) {
        if(pos == 0) {
            newNode.next = p;
            return newNode;
        }
        ListNode head = p;
        for(int i = 0; i < pos-1; i++) {
            p = p.next;
        }
        newNode.next = p.next;
        p.next = newNode;
        return head;
    }
}