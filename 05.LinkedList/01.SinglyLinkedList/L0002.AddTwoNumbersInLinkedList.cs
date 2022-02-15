using System;

public class AddTwoNumbersInLinkedList {
    public AddTwoNumbersInLinkedList() {
        var sum = AddTwoNumbers(ListNode.Create(new int[] {2,4,9}), ListNode.Create(new int[] {5,6,4,9}));
        ListNode.Print(sum);
    }
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode result = new ListNode(0);
        ListNode temp = result;
        int reminder = 0, sum = 0;
        while(l1 != null && l2 != null) {
            sum = l1.val + l2.val + reminder;
            reminder = sum / 10;
            temp.next = new ListNode(sum % 10);
            temp = temp.next;
            l1 = l1.next;
            l2 = l2.next;
        }
        while(l1 != null) {
            sum = l1.val + reminder;
            reminder = sum / 10;
            temp.next = new ListNode(sum % 10);
            temp = temp.next;
            l1 = l1.next;
        }
        while(l2 != null) {
            sum = l2.val + reminder;
            reminder = sum / 10;
            temp.next = new ListNode(sum % 10);
            temp = temp.next;
            l2 = l2.next;
        }
        if(reminder > 0)
            temp.next = new ListNode(reminder);
        return result.next;
    }
}