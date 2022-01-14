using System;

public class MergeTwoSLL {
    public MergeTwoSLL() {
        ListNode first = CreateSLL.Create(new int[] {2,8,10,15});
        ListNode second = CreateSLL.Create(new int[] {4,7,12,14});
        ListNode merged = Merge(first, second);
        ListNode.Print(merged);
    }
    public ListNode Merge(ListNode first, ListNode second) {
        ListNode merged = new ListNode(0);
        ListNode last = merged;
        while(first != null && second != null) {
            if(first.val < second.val) {
                last.next = first;
                first = first.next;
                last = last.next;
            }
            else {
                last.next = second;
                second = second.next;
                last = last.next;
            }
        }
        last.next = (first != null ? first : second);
        return merged.next;
    }
}