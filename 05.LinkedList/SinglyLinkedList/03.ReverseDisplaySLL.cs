using System;

public class ReverseDisplaySLL {
    public ReverseDisplaySLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        RecursiveReverseDisplay(p);
    }
    public void RecursiveReverseDisplay(ListNode p) {
        if(p != null) {
            RecursiveReverseDisplay(p.next);
            Console.Write($"{p.val}->");
        }
    }
}