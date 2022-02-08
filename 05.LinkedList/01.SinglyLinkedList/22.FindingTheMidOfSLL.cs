using System;

public class FindingTheMidOfSLL {
    public FindingTheMidOfSLL() {
        ListNode head = CreateSLL.Create(new int[] {8,6,3});//,3,9,10,4,2,12});
        ListNode midNode = FindingTheMid(head);
        Console.WriteLine(midNode.val);
    }
    public ListNode FindingTheMid(ListNode p) {
        ListNode slowPtr = p, fastPtr = p;
        while(fastPtr != null) {
            fastPtr = fastPtr.next;
            if(fastPtr != null)
                fastPtr = fastPtr.next;
            if(fastPtr != null)
                slowPtr = slowPtr.next;
        }
        return slowPtr;
    }
}