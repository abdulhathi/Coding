using System;

public class CreateCSLL {
    public CreateCSLL() {
        ListNode.PrintCSLL(Create(new int[] {8,3,9,6,2}));
    }
    public static ListNode Create(int[] arr) {
        if(arr == null || arr.Length == 0)
            return null;
        ListNode head = new ListNode(arr[0]);
        ListNode temp = head;
        for(int i = 1; i < arr.Length; i++) {
            temp.next = new ListNode(arr[i]);
            temp = temp.next;
        }
        temp.next = head;
        return head;
    }
}