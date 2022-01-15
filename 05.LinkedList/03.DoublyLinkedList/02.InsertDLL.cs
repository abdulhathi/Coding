using System;

public class InsertDLL {
    public InsertDLL() {
        ListNode head = CreateDLL.Create(new int[] {6,9,3,7,2});
        ListNode result = Insert(head, 0, 10);
        ListNode.PrintDLL(result);
        ListNode last = result.next.next.next.next.next;
        Console.WriteLine();
        Console.WriteLine($"{last.val}, {last.prev.val}");
        Console.WriteLine("{0}", last.next == null ? "null" : last.next.val.ToString());
    }
    public ListNode Insert(ListNode head, int pos, int key) {
        if(pos == 0) {
            head.prev = new ListNode(key, head, null);
            head = head.prev;
        }
        else {
            ListNode p = head;
            for(int i = 0; i < pos - 1; i++) {
                p = p.next;
            }
            p.next = new ListNode(key, p.next, p);
            if(p.next.next != null)
                p.next.next.prev = p.next;
        }
        return head;
    }
}