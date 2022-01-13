using System;

public class SumOfAllInSLL {
    public SumOfAllInSLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        Console.WriteLine($"Iterative sum : {IterativeSum(p)}");
        Console.WriteLine($"Recursive sum : {RecursiveSum(p)}");
    }
    public int IterativeSum(ListNode p) {
        int sum = 0;
        while(p != null) {
            sum += p.val;
            p = p.next;
        }
        return sum;
    }
    public int RecursiveSum(ListNode p) {
        if(p == null)
            return 0;
        else
            return RecursiveSum(p.next) + p.val;
    }
}