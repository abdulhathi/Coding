using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode prev;
    public ListNode(int val = 0, ListNode next = null, ListNode prev = null) {
        this.val = val;
        this.next = next;
        this.prev = prev;
    }
    public static ListNode Create(int[] arr) {
        if(arr.Length == 0)
            return null;
        ListNode p = new ListNode(arr[0]);
        ListNode first = p;
        for(int i = 1; i < arr.Length; i++) {
            p.next = new ListNode(arr[i]);
            p = p.next;
        }
        return first;
    }
    public static void Print(ListNode p) {
        while(p != null) {
            Console.Write(p.val+"->");
            p = p.next;
        }
    }
    public static void PrintCSLL(ListNode p) {
        ListNode head = p;
        do {
            Console.Write($"{p.val}->");
            p = p.next;
        }
        while(p != head);
    }
    public static void PrintDLL(ListNode p) {
        while(p != null) {
            Console.Write($"{p.val}<=>");
            p = p.next;
        }
    }
    public static void PrintCDLL(ListNode p) {
        ListNode head = p;
        do {
            Console.Write($"{p.val}<=>");
            p = p.next;
        }
        while(p != head);
    }
}