using System;

public class LinearSearchInSLL {
    public LinearSearchInSLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        Console.WriteLine($"Recursive search : {RecursiveLinearSearch(p,15).val}");
        Console.WriteLine($"Iterative search : {IterativeLinearSearch(p,15).val}");
    }
    public ListNode RecursiveLinearSearch(ListNode p, int key) {
        if(p == null)
            return null;
        if(p.val == key)
            return p;
        return RecursiveLinearSearch(p.next, key);
    }
    public ListNode IterativeLinearSearch(ListNode p, int key) {
        while(p != null) {
            if(p.val == key)
                return p;
            p = p.next;
        }
        return null;
    }
}