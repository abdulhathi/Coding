using System;

public class ImplementQueueByTwoStack {
    public ImplementQueueByTwoStack() {
        QueueByTwoStack<int> queue = new QueueByTwoStack<int>();
        for(int i = 1; i < 6; i++)
            queue.Enqueue(i);
        Console.WriteLine();
        for(int i = 1; i < 3; i++)
            Console.Write(queue.Dequeue()+",");
        //queue.Enqueue(6);
        try {
        for(int i = 3; i < 7; i++)
            Console.Write(queue.Dequeue()+",");
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
public class QueueByTwoStack<T> {
    Stack<T> enqueue = null;
    Stack<T> dequeue = null;
    public QueueByTwoStack() {
        enqueue = new Stack<T>();
        dequeue = new Stack<T>();
    }
    public void Enqueue(T val) {
        enqueue.Push(val);
    }
    public T Dequeue() {
        if(dequeue.Count == 0) {
            if(enqueue.Count == 0)
                throw new Exception("Queue is Empty.");
            while(enqueue.Count > 0)
                dequeue.Push(enqueue.Pop());
        }
        return dequeue.Pop();
    }
}