using System;
public class MyLinkedList {
    ListNode head = null;

    public MyLinkedList() {
        
    }
    
    public int Get(int index) {
        ListNode p = head;
        for(int i = 0; i < index && p != null; i++) {
            p = p.next;
        }
        return p == null ? -1 : p.val;
    }
    
    public void AddAtHead(int val) {
        head = new ListNode(val, head);
    }
    
    public void AddAtTail(int val) {
        if(head == null)
            AddAtHead(val);
        else {
            ListNode p = head;
            while(p.next != null) {
                p = p.next;
            }
            p.next = new ListNode(val);
        }
    }
    
    public void AddAtIndex(int index, int val) {
        if(index == 0)
            AddAtHead(val);
        else {
            ListNode p = head;
            for(int i = 0; i < index - 1 && p != null; i++) {
                p = p.next;
            }
            if(p != null)
                p.next = new ListNode(val, p.next);
        }
    }
    
    public void DeleteAtIndex(int index) {
        if(index == 0)
            head = head.next;
        else {
            ListNode p = head;
            for(int i = 0; i < index - 1 && p != null; i++)
                p = p.next;
            if(p != null && p.next != null)
                p.next = p.next.next;
        }
    }
}
public class MyLinkedListTest {
    public MyLinkedListTest() {
        MyLinkedList myLinkedList = null;

        string[] functions = {"MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"};
        int[][] input = 
        {   new int[]{}, 
            new int[]{1},
            new int[]{3},
            new int[]{1,2},
            new int[]{1},
            new int[]{1},
            new int[]{1}
        };
        for(int i = 0; i < functions.Length; i++) {
            switch(functions[i]) {
                case "MyLinkedList" :
                    myLinkedList = new MyLinkedList();
                    Console.Write("null,");
                    break;
                case "addAtHead" :
                    myLinkedList.AddAtHead(input[i][0]);
                    Console.Write("null,");
                    break;
                case "addAtTail" :
                    myLinkedList.AddAtTail(input[i][0]);
                    Console.Write("null,");
                    break;
                case "addAtIndex" :
                    myLinkedList.AddAtIndex(input[i][0], input[i][1]);
                    Console.Write("null,");
                    break;
                case "get" :
                    Console.Write($"{myLinkedList.Get(input[i][0])},");
                    break;
                case "deleteAtIndex" :
                    myLinkedList.DeleteAtIndex(input[i][0]);
                    Console.Write("null,");
                    break;
            }
        }
    }
}
/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */