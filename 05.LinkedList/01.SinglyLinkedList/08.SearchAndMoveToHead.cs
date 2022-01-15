using System;

public class SearchAndMoveToHead {
    public SearchAndMoveToHead() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        var result = SearchKeyMoveToHead(p, 10);
        if(result is not null)
            ListNode.Print(result);
    }
    public ListNode SearchKeyMoveToHead(ListNode p, int key) {
        ListNode root = p;
        ListNode q = null;
        while(p != null) {
            if(p.val == key) {
                if(q == null)
                    return p;
                else {
                    q.next = p.next;
                    p.next = root;
                    return p;
                }
            }
            q = p;
            p = p.next;
        }
        return null;
    }
}