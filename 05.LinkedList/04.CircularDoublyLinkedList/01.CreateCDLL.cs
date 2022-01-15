using System;

public class CreateCDLL {
    public CreateCDLL() {
        ListNode head = Create(new int[] {6,9,2,7,8});
        ListNode.PrintCDLL(head);
    }
    public static ListNode Create(int[] arr) {
        ListNode head = new ListNode(arr[0]);
        ListNode temp = head;
        for(int i = 1; i < arr.Length; i++) {
            temp.next = new ListNode(arr[i], null, temp);
            if(i < arr.Length)
                temp = temp.next;
        }
        head.prev = temp;
        temp.next = head;
        return head;
    }
}