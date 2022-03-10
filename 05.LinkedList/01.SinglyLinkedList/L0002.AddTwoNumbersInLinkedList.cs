using System;

public class AddTwoNumbersInLinkedList {
    public AddTwoNumbersInLinkedList() {
        var sum = AddTwoNumbers_Recursive(ListNode.Create(new int[] {9,9,9,9,9,9,9}), ListNode.Create(new int[] {9,9,9,9}));
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

    /*      2 4 3
            5 6 4
            -----
            7 0 8
   Reminder   1  
    */  
   public ListNode AddTwoNumbers_Recursive(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode();
        ListNode temp = dummy;
        AddTwoNums(l1, l2, 0);
        return dummy.next;
        
        void AddTwoNums(ListNode n1, ListNode n2, int reminder) {
            if(n1 == null && n2 == null && reminder == -1)
                return;
            else if(reminder == -1)
                reminder = 0;
            int num = (n1 != null ? n1.val : 0);
            num += (n2 != null ? n2.val : 0);
            num += reminder;
            temp.next = new ListNode(num % 10);
            reminder = num > 9 ? num / 10 : -1;
            temp = temp.next;
            AddTwoNums(n1 != null ? n1.next : null, n2 != null ? n2.next : n2, reminder);
                
        }
    }
}