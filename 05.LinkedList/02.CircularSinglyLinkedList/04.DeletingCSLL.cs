using System;

public class DeletingCSLL {
    public DeletingCSLL() {
        ListNode head = CreateCSLL.Create(new int[] {3,5,7,8,9,10});
        ListNode result = Delete(head, 7);
        ListNode.PrintCSLL(result);
    }
    public ListNode Delete(ListNode head, int pos) {
        ListNode p = head;
        if(pos == 0) {
            while(p.next != head) {
                p = p.next;
            }
            p.next = head.next;
            head = head.next;
        }
        else {
            for(int i = 0; i < pos - 2; i++)
                p = p.next;
            if(p.next == head) {
                p.next = p.next.next;
                head = p.next;
            }
            else
                p.next = p.next.next;
        }
        return head;
    }
}