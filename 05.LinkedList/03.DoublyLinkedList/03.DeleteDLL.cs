using System;

public class DeleteDLL {
    public DeleteDLL() {
        ListNode head = CreateDLL.Create(new int[] {6,9,3,7,2});
        ListNode result = Delete(head, Convert.ToInt32(Console.ReadLine()));
        ListNode.Print(result);
    }
    public ListNode Delete(ListNode head, int pos) {
        if(pos == 1) {
            head = head.next;
            if(head != null)
                head.prev = null;
        }
        else {
            ListNode p = head;
            for(int i = 0; i < pos - 1; i++)
                p = p.next;
            p.prev.next = p.next;
            if(p.next != null)
                p.next.prev = p.prev;
        }
        return head;
    }
}