using System;

public class CheckTheSLLIsSorted {
    public CheckTheSLLIsSorted() {
        bool isSorted = IsSorted(CreateSLL.Create(new int[] {3,4,5,6,7,2}));
        Console.WriteLine($"This linked list is sorted as {isSorted}");
    }
    public bool IsSorted(ListNode p) {
        while(p != null && p.next != null) {
            if(p.val > p.next.val)
                return false;
            p = p.next;
        }
        return true;
    }
}