using System;

public class InsertCDLL {
    public InsertCDLL() {
        ListNode head = CreateCDLL.Create(new int[] {6,9,2,7,8});
        ListNode result = Insert(head, Convert.ToInt32(Console.ReadLine()), 10);
        ListNode.PrintCDLL(result);
    }
    public ListNode Insert(ListNode head, int pos, int key) {
        if(pos == 0) {
            ListNode newNode = new ListNode(key, head, head.prev);
            head.prev = newNode;
            newNode.prev.next = newNode;
            head = newNode;
        }
        else {
            ListNode p = head;
            for(int i = 0; i < pos - 1; i++) {
                p = p.next;
            }   
            ListNode newNode = new ListNode(key, p.next, p);
            p.next = newNode;
            newNode.next.prev = newNode;
        }
        return head;
    }
}