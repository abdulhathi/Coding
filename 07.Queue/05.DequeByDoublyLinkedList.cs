using System;

public class DequeTest {
    public DequeTest() {
        var deque = new DequeByDoublyLinkedList();
        deque.EnqueueFront(10);
        deque.EnqueueFront(20);

        try {
            Console.WriteLine(deque.DequeueFront());
            Console.WriteLine(deque.DequeueFront());
            deque.EnqueueRear(30);
            Console.WriteLine(deque.DequeueFront());
            deque.EnqueueRear(40);
            deque.EnqueueRear(50);
            Console.WriteLine(deque.DequeueRear());
            Console.WriteLine(deque.DequeueRear());
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        
    }
}
public class DequeByDoublyLinkedList {
    ListNode head = null;
    ListNode tail = null;
    public DequeByDoublyLinkedList() {}
    public void EnqueueFront(int val) {
        if(tail == null) {
            head = new ListNode(val);
            tail = head;
        }
        else {
            head = new ListNode(val, head);
            head.next.prev = head;
        }
    }
    public void EnqueueRear(int val) {
        if(tail == null) {
            tail = new ListNode(val);
            head = tail;
        }
        else {
            tail.next = new ListNode(val, null, tail);
            tail = tail.next;
        }
    }
    public int DequeueFront() {
        if(head == null)
            throw new Exception("Queue is empty.");
        int val = head.val;
        head = head.next;
        if(head != null)
            head.prev = null;
        if(head == null)
            tail = null;
        return val;
    }
    public int DequeueRear() {
        if(tail == null)
            throw new Exception("Queue is empty.");
        int val = tail.val;
        tail = tail.prev;
        if(tail != null)
            tail.next = null;
        if(tail == null)
            head = null;
        return val;
    }
}