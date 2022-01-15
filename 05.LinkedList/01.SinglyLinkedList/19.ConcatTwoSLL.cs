using System;

public class ConcatTwoSLL {
    public ConcatTwoSLL() {
        ListNode p = CreateSLL.Create(new int[] {1});
        ListNode q = CreateSLL.Create(new int[] {2,4,8});
        ListNode result = Concat(p,q);
        ListNode.Print(result);
    }
    public ListNode Concat(ListNode p, ListNode q) {
        if(p == null)
            return q;
        ListNode first = p;
        while(p != null && p.next != null) {
            p = p.next;
        }
        p.next = q;
        return first;
    }
}