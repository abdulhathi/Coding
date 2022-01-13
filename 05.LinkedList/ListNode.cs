using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
    public static void Print(ListNode p) {
        while(p != null) {
            Console.Write(p.val+"->");
            p = p.next;
        }
    }
}