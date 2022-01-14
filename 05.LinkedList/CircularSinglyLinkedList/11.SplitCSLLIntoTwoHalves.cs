using System;
using System.Collections.Generic;

public class SplitCSLLIntoTwoHalves {
    public SplitCSLLIntoTwoHalves() {
       ListNode head = CreateCSLL.Create(new int[]{8,3,9,6,2});
       List<ListNode> twoHalves = SplitIntoTwoHalves(head);
       ListNode.PrintCSLL(twoHalves[0]);
       Console.WriteLine();
       ListNode.PrintCSLL(twoHalves[1]);
    }
    public List<ListNode> SplitIntoTwoHalves(ListNode head) {
        ListNode p = head;
        int count = 0;
        do {
            p = p.next;
            count++;
        }
        while(p != head);
        int firstHalve = count % 2 == 0 ? count / 2 : (count / 2) + 1;
        ListNode head1 = head, head2;
        ListNode temp = head;
        for(int i = 0; i < firstHalve - 1; i++) {
            temp = temp.next;
        }
        head2 = temp.next;
        temp.next = head1;
        ListNode temp1 = head2;
        while(temp1.next != head) 
            temp1 = temp1.next;
        temp1.next = head2;
        return new List<ListNode>() { head1, head2 };
    }
}