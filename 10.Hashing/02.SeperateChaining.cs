using System;

public class SeperateChaining {
    public ListNode[] chaining = null;
    public SeperateChaining() {
        chaining = new ListNode[10];
    }
    public void Insert(int key) {
        ListNode node = chaining[key % 10];
        if(node == null || key < node.val)
            chaining[key % 10] = new ListNode(key, node);
        else {
            while(node != null) {
                if(node.next != null && node.next.val > key) {
                    node.next = new ListNode(key, node.next);
                    return;
                }
                node = node.next;
            }
        }
    }
    public bool Search(int key) {
        var node = chaining[key % 10];
        while(node != null && node.val != key)
            node = node.next;
        return !(node == null);
    }
    public void Delete(int key) {
        if(chaining[key % 10] != null) {
            var node = chaining[key % 10];
            if(chaining[key % 10].val == key)
                node = node.next;
            else {
                ListNode prev = null;
                while(node != null && node.val == key) {
                    prev = node;
                    node = node.next;
                }
                prev.next = prev.next != null ? prev.next.next : prev.next;
            }
        }
    }

    public void Print(int key) {
        ListNode.Print(chaining[key % 10]);
    }
}
public class SeperateChainingTest {
    public SeperateChainingTest() {
        SeperateChaining chaining  = new SeperateChaining();
        // chaining.Insert(5);
        // chaining.Insert(25);
        // chaining.Insert(45);

        chaining.Insert(64);
        chaining.Insert(34);
        chaining.Insert(4);
        chaining.Insert(14);

        chaining.Print(5);
        Console.WriteLine();
        Console.WriteLine($"45 exist in chaining ? {chaining.Search(45)}");
        Console.WriteLine($"85 exist in chaining ? {chaining.Search(85)}");

        chaining.Print(4);
    }
}