using System;

public class ReverseDLL {
    public ReverseDLL() {
        /*
               <- 6 <=> 9 <=> 3 <=> 7 <=> 2 ->
        */
        ListNode head = CreateDLL.Create(new int[] {6,9,3,7,2});
        ListNode.PrintDLL(Reverse(head));
    }
    public ListNode Reverse(ListNode head) {
        ListNode next = null, p = head;
        while(p != null) {
            next = p.next;
            p.next = p.prev;
            p.prev = next;
            p = p.prev;
            if(p != null && p.next == null)
                head = p;
        }
        return head;
    }
}