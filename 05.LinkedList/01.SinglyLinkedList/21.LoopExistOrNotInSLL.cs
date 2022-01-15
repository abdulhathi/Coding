using System;

public class LoopExistOrNotInSLL {
    public LoopExistOrNotInSLL() {
        ListNode p = CreateSLL.Create(new int[] {8,5,4,7,3,9});
        p.next.next.next.next.next.next = p.next.next;
        // p.next.next = p;
        bool isLoopExist = CheckLoopExist(p);
        Console.WriteLine(isLoopExist);
    }
    public bool CheckLoopExist(ListNode first) {
        ListNode p = first, q = first;
        do {
            p = p.next;
            q = q.next;
            q = q != null ? q.next : q;
        }
        while(p != null && q != null && p != q);
        return p == q ? true : false;
    }
}