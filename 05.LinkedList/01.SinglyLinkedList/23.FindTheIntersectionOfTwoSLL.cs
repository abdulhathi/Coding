using System;

public class FindTheIntersectionOfTwoSLL {
    public FindTheIntersectionOfTwoSLL() {
        ListNode p = CreateSLL.Create(new int[] {8,6,3,9,10,4,2,12});
        ListNode q = CreateSLL.Create(new int[] {20,30,40});
        //q.next.next.next = p.next.next.next.next;
        ListNode intersection = FindIntersection(p,q);
        Console.WriteLine($"{(intersection != null ? intersection.val.ToString() : "null")}");
    }
    public ListNode FindIntersection(ListNode p, ListNode q) {
        Stack<ListNode> stack1 = new Stack<ListNode>();
        Stack<ListNode> stack2 = new Stack<ListNode>();
        while(p != null) {
            stack1.Push(p);
            p = p.next;
        }
        while(q != null) {
            stack2.Push(q);
            q = q.next;
        }
        while(stack1.Count > 0 && stack2.Count > 0) {
            if(stack1.Peek() != stack2.Peek())
                return stack1.Peek().next;
            stack1.Pop();
            stack2.Pop();
        }
        return null;
    }
}