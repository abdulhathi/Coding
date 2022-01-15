using System;

public class CreateDLL {
    public CreateDLL() {
        ListNode head = Create(new int[] {6,9,3,7,2});
        ListNode.PrintDLL(head);
    }
    public static ListNode Create(int[] arr) {
        if(arr == null || arr.Length == 0)
            return null;
        ListNode head = new ListNode(arr[0]);
        ListNode temp = head;
        for(int i = 1; i < arr.Length; i++) {
            temp.next = new ListNode(arr[i], null, temp);
            temp = temp.next;
        }
        return head;
    }
}