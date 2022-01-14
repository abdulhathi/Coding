using System;

public class RemoveDupsInSortedSLL {
    public RemoveDupsInSortedSLL() {
        ListNode result = RemoveDups(CreateSLL.Create(new int[] {1,2,2,3,4,5,5,5}));
        ListNode.Print(result);
    }
    public ListNode RemoveDups(ListNode p) {
        ListNode first = p;
        while(p != null && p.next != null) {
            if(p.val == p.next.val)
                p.next = p.next.next;
            else
                p = p.next;
        }
        return first;
    }
}