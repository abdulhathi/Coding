using System;

public class InsertCSLL {
    ListNode head = CreateCSLL.Create(new int[] {8,3,9,6,2});
    public InsertCSLL() {
        ListNode.PrintCSLL(Insert(head, 0, 10));
    }
    public ListNode Insert(ListNode p, int pos, int key) {
        if(pos == 0) {
            while(p.next != head)
                p = p.next;
            p.next = new ListNode(key, head);
            head = p.next;
            return head;
        }
        for(int i = 0; i < pos - 1; i++) {
            p = p.next;
        }
        p.next = new ListNode(key, p.next);
        return head;
    }
}