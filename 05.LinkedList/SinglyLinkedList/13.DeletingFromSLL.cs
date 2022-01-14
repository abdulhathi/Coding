using System;

public class DeletingFromSLL {
    public DeletingFromSLL() {
        ListNode head = CreateSLL.Create(new int[] {4,3,6,7,8,2});
        ListNode.Print(Delete(head, 7));
    }
    public ListNode Delete(ListNode p, int pos) {
        if(pos == 0)
            return p.next;
        ListNode first = p;
        ListNode q = null;
        for(int i = 1; i <= pos; i++) {
            if(p == null)
                return first;
            q = p;
            p = p.next;
        }
        if(p != null)
            q.next = p.next;
        return first;
    }   
}