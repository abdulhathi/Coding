using System;

public class FindingTheMidOfSLL {
    public FindingTheMidOfSLL() {
        ListNode head = CreateSLL.Create(new int[] {8,6,3,9,10,4,2,12});
        ListNode midNode = FindingTheMid(head);
        Console.WriteLine(midNode.val);
    }
    public ListNode FindingTheMid(ListNode p) {
        ListNode head = p, q = p;
        while(q != null) {
            q = q.next;
            if(q != null)
                q = q.next;
            if(q != null)
                p = p.next;
        }
        return p;
    }
}