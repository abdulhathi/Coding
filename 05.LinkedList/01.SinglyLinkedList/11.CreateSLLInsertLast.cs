using System;

public class CreateSLLInsertLast {
    public ListNode P;
    public ListNode Last;
    public CreateSLLInsertLast() {
        Console.WriteLine(); InsertLast(1); ListNode.Print(P); 
        Console.WriteLine(); InsertLast(2); ListNode.Print(P); 
    }
    public void InsertLast(int key) {
        if(Last == null) 
            P = Last = new ListNode(key);
        else {
            Last.next = new ListNode(key);
            Last = Last.next;
        }
    }
}