using System;

public class ImplementStackUsingLinkedList {
    public ImplementStackUsingLinkedList() {
        StackByLinkedList stack = new StackByLinkedList();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        Console.WriteLine($"Count : {stack.Count()}");
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.IsEmpty());
        Console.WriteLine($"Count : {stack.Count()}");
    }
}
public class StackByLinkedList {
    ListNode head = null;
    ListNode tail = null;
    int count = 0;
    public StackByLinkedList() {
        
    }
    public void Push(int val) {
        if(tail == null) {
            head = new ListNode(val);
            tail = head;
        }
        else {
            tail.next = new ListNode(val);
            tail = tail.next;
        }
        count++;
    }
    public int Pop() {
        if(count > 0) {
            count--;
            ListNode p = head;
            ListNode q = null;
            while(p != tail) {
                q = p;
                p = p.next;
            }
            if(q == null)
                head = tail = null;
            else {
                q.next = null;
                tail = q;
            }
            return p.val;
        }
        return default(int);
    }
    public bool IsEmpty() {
        return head == null;
    }
    public int Count() {
        return count;
    }
}
