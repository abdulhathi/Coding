using System;

public class ReverseASLLBySlidingPointer {
    public ReverseASLLBySlidingPointer() {
        ListNode reversed = ReverseBySlidingPointer(CreateSLL.Create(new int[] { 3,6,2,4,5,6 }));
        ListNode.Print(reversed);
    }
    public ListNode ReverseBySlidingPointer(ListNode p) {
        ListNode r = null;
        ListNode q = null;
        while(p != null) {
            r = q;
            q = p;
            p = p.next;
            q.next = r;
        }
        return q;
    }
}