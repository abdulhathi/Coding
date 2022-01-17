using System;

public class ImplementQueueUsingArray {
    public ImplementQueueUsingArray() {
        QueueByArray<int> queue = new QueueByArray<int>();
        try {
            for(int i = 0; i < 12; i++)
                queue.Enqueue(i);
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        try {
            for(int i = 0; i < 12; i++)
                Console.Write(queue.Dequeue()+", ");
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
public class QueueByArray<T> {
    int size = 10;
    T[] arr = null;
    int front = -1;
    int rear = -1;
    
    public QueueByArray() {
        arr = new T[size];
    }

    public void Enqueue(T val) {
        if(rear == size-1)
            throw new Exception("Queue is full");
        else 
            arr[++rear] = val;
    }

    public T Dequeue() {
        if(front == rear)
            throw new Exception("Queue is empty");
        return arr[++front];
    }
    public bool IsFull() {
        return size - 1 == rear;
    }
    public bool IsEmpty() {
        return front == rear;
    }
}