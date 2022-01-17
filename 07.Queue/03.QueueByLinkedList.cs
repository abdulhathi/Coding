using System;

public class ImplementQueueByLinkedList {
    public ImplementQueueByLinkedList() {
        QueueByLinkedList queue = new QueueByLinkedList();
        try {
            queue.Dequeue();
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }

        for(int i = 1; i < 11; i++)
            queue.Enqueue(i);

        Console.WriteLine();
        for(int i = 1; i < 6; i++)
            Console.Write(queue.Dequeue()+",");
        
        for(int i = 11; i < 16; i++)
            queue.Enqueue(i);

        Console.WriteLine();
        for(int i = 1; i < 11; i++)
            Console.Write(queue.Dequeue()+",");
    }
}

public class QueueByLinkedList {
    ListNode head = null;
    ListNode tail = null;
    public QueueByLinkedList() {

    }
    public void Enqueue(int val) {
        if(tail == null) {
            head = new ListNode(val);
            tail = head;
        }
        else {
            tail.next = new ListNode(val);
            tail = tail.next;
        }
    }
    public int Dequeue() {
        if(head == null)
            throw new Exception("Queue is Empty");
        int val = head.val;
        head = head.next;
        if(head == null)
            tail = null;
        return val;
    }
    public bool IsEmpty() {
        return head == null;
    }
}