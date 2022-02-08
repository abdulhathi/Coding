using System;

public class ImplementCircularQueueByArray {
    public ImplementCircularQueueByArray() {
    CircularQueueByArray<int> queue = new CircularQueueByArray<int>();
        try {
            for(int i = 1; i < 10; i++)
                queue.Enqueue(i);
            queue.Enqueue(10);
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }

        try {
        Console.WriteLine(queue.Dequeue());
        queue.Enqueue(11);
        queue.Enqueue(12);
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
        try {
            for(int i = 1; i < 12; i++)
                Console.Write(queue.Dequeue()+",");
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}

public class CircularQueueByArray<T> {

    int size = 10;
    T[] arr = null;
    int front = 0, rear = 0;
    public CircularQueueByArray() {
        arr = new T[size];
    }

    public void Enqueue(T val) {
        if((rear + 1) % size == front)
            throw new Exception("Queue is full");
        rear = (rear+1) % size;
        arr[rear] = val;
    }
    public T Dequeue() {
        if(front == rear)
            throw new Exception("Queue is empty");
        front = (front + 1) % size;
        return arr[front];
    }
    public bool IsEmpty() {
        return front == rear;
    }
    public bool IsFull() {
        return (rear + 1) % size == front;
    }
}