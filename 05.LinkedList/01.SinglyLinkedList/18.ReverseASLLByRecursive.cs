using System;

public class ReverseASLLByRecursive {
    public ReverseASLLByRecursive() {
        ListNode p = CreateSLL.Create(new int[] { 3,6,2,4,5,6 });
        ListNode reversed = ReverseByRecursive(null,p);
        ListNode.Print(reversed);
    }
    public ListNode ReverseByRecursive(ListNode q, ListNode p) {
        if(p != null) {
            var reversed = ReverseByRecursive(p, p.next);
            p.next = q;
            return reversed;
        }
        else
            return q;
    }
}