using System;
using System.Collections.Generic;

public class ReverseASLLByElements {
    public ReverseASLLByElements() {
        ListNode reversed = ReverseElements(CreateSLL.Create(new int[] { 3,6,2,4,5,6 }));
        ListNode.Print(reversed);
    }
    public ListNode ReverseElements(ListNode p) {
        List<int> list = new List<int>();
        ListNode first = p;
        while(p != null) {
            list.Add(p.val);
            p = p.next;
        }
        p = first;
        for(int i = list.Count - 1; i >= 0; i--) {
            p.val = list[i];
            p = p.next;
        }
        return first;
    }
}