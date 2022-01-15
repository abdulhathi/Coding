using System;

public class MaxOfSLL {
    public MaxOfSLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        Console.WriteLine($"Iterative max : {IterativeMax(p)}");
        Console.WriteLine($"Recursive max : {RecursiveMax(p)}");
    }
    public int IterativeMax(ListNode p) {
        int max = int.MinValue;
        while(p != null) {
            if(p.val > max)
                max = p.val;
            p = p.next;
        }
        return max;
    }
    public int RecursiveMax(ListNode p) {
        if(p == null)
            return int.MinValue;
        int max = RecursiveMax(p.next);
        return max > p.val ? max : p.val;
    }
}