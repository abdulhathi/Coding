using System;

public class CreateSLLUsingInsert {
    public CreateSLLUsingInsert() {
        ListNode p = null;
        p = CreateUsingInsert(p,0,new ListNode(1));
        ListNode.Print(p); Console.WriteLine();
        p = CreateUsingInsert(p,1,new ListNode(2));
        ListNode.Print(p); Console.WriteLine();
        p = CreateUsingInsert(p,2,new ListNode(4));
        ListNode.Print(p); Console.WriteLine();
        p = CreateUsingInsert(p,2,new ListNode(3));
        ListNode.Print(p); Console.WriteLine();
        p = CreateUsingInsert(p,4,new ListNode(7));
        ListNode.Print(p); Console.WriteLine();
    }
    public ListNode CreateUsingInsert(ListNode p, int pos, ListNode newNode) {
        if(pos == 0)
            return newNode;
        ListNode first = p;
        for(int i = 0; i < pos - 1; i++)
            p = p.next;
        newNode.next = p.next;
        p.next = newNode;
        return first;
    }
}