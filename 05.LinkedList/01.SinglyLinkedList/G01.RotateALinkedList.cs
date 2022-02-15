using System;

public class RotateALinkedList {
    
    public RotateALinkedList() {
        ListNode root = CreateSLL.Create(new int[] {2, 4, 7, 8, 9});
        var head = Rotate(root, 3);
        ListNode.Print(head);
    }
    public ListNode Rotate(ListNode head, int k) {
        ListNode p = head, q = null, r = head;
        // Loop till kth element
        while(k > 0 && p != null) {
            q = p;
            p = p.next;
            k--;
        }
        // P is not null then assing the kth node as head
        if(p != null) {
            head = p;
            // kth prev node value is up to q and q is next assinged to null
            if(q != null)
                q.next = null;
            // loop till last node to assign the last next to head
            while(p.next != null)
                p = p.next;
            // last next is assinged to head
            p.next = r;
        }
        return head;
    }
}