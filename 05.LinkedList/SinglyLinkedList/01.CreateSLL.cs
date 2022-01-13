using System;

public class CreateSLL {
    public CreateSLL() {
        ListNode p = Create(new int[] {3,5,7,10,15});
        ListNode.Print(p);
    }
    public static ListNode Create(int[] arr) {
        ListNode p = new ListNode(arr[0]);
        ListNode first = p;
        for(int i = 1; i < arr.Length; i++) {
            p.next = new ListNode(arr[i]);
            p = p.next;
        }
        return first;
    }
}