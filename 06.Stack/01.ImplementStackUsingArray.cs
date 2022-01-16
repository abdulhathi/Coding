using System;

public class ImplementStackUsingArray {
    public ImplementStackUsingArray() {
        StackByArray<int> stack = new StackByArray<int>();
        for(int i = 1; i < 12; i++)
            stack.Push(i);
        Console.WriteLine($"Count {stack.Count()}");
        Console.WriteLine();
        while(!stack.IsEmpty())
            Console.Write(stack.Pop()+" ");
        Console.WriteLine();
        Console.WriteLine($"IsEmpty : {stack.IsEmpty()}");
        for(int i = 1; i < 12; i++)
            stack.Push(i);
        Console.WriteLine();
        while(!stack.IsEmpty())
            Console.Write(stack.Pop()+" ");
    }
}
public class StackByArray<T> {
    int size = 10;
    T[] arr;
    int pos = -1;
    public StackByArray() {
        arr = new T[10];
    }
    public void Push(T val) {
        if(pos + 1 >= size) {
            size += 10;
            T[] newArr = new T[size];
            for(int i = 0; i < arr.Length; i++)
                newArr[i] = arr[i];
            arr = newArr;
        }
        arr[++pos] = val;
    }
    public T Pop() {
        return pos > -1 ? arr[pos--] : default(T);
    }
    public T Peek() {
        return arr[pos];
    }
    public bool IsEmpty() {
        return pos == -1;
    }
    public int Count() {
        return pos + 1;
    }
}