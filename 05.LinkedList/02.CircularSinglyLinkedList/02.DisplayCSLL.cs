using System;

public class DisplayCSLL {
    ListNode head = CreateCSLL.Create(new int[] {8,3,9,6,2});
    int flag = 0;
    public DisplayCSLL() {
        Display(head);
        Console.WriteLine();
        RecursiveDisplay(head);
    }
    public void Display(ListNode p) {
        do {
            Console.Write($"{p.val}->");
            p = p.next;
        }
        while(p != head);
    }
    public void RecursiveDisplay(ListNode p) {
        if(p != head || flag == 0) {
            flag = 1;
            Console.Write($"{p.val}->");
            RecursiveDisplay(p.next);
        }
        flag = 0;
    }
}