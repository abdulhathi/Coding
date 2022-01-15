using System;

public class CountSLL {
    public CountSLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        Console.WriteLine($"Iterative count : {CountIterative(p)}");
        Console.WriteLine($"Recursive count : {CountRecursive(p)}");
    }
    public int CountIterative(ListNode p) {
        int c = 0;
        while(p != null) {
            c++;
            p = p.next;
        }
        return c;
    }
    public int CountRecursive(ListNode p) {
        if(p == null)
            return 0;
        else
            return CountRecursive(p.next) + 1;
    }
}