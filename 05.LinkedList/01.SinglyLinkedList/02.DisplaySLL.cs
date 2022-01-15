using System;

public class DisplaySLL {
    public DisplaySLL() {
        ListNode p = CreateSLL.Create(new int[] {3,5,7,10,15});
        RecursiveDisplay(p);
    }
    public void RecursiveDisplay(ListNode p) {
        if(p != null) {
            Console.Write($"{p.val}->");
            RecursiveDisplay(p.next);
        }
    }
}