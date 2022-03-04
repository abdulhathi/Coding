using System;

public class LinkedListCycle {
    public LinkedListCycle() {
        ListNode root = ListNode.Create(new int[] {1,2});
        HasCycle(root);
    }
    public bool HasCycle(ListNode head) {
        if(head == null)
            return false;
        ListNode slowPtr = head, fastPtr = head;
        do {
            if(slowPtr.next == null)
                return false;
            slowPtr = slowPtr.next;
            if(fastPtr.next == null || fastPtr.next.next == null)
                return false;
            fastPtr = fastPtr.next.next;
        }
        while(slowPtr != fastPtr);
        return true;
    }
}