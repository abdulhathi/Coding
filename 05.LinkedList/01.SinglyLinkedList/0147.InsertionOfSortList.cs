using System;
using System.Collections.Generic;

public class InsertionOfSortList {
    public InsertionOfSortList() {
        ListNode head = CreateSLL.Create(new int[] {-1,5,3,4,0}); // {4,2,1,3});
        ListNode result = NewLinkedListMethod(head);
        ListNode.Print(result);
    }

    public ListNode ArrayInsertionSortMethod(ListNode head) {
        List<ListNode> listOfNode = new List<ListNode>();
        ListNode p = head, temp = null;
        while(p != null) {
            listOfNode.Add(p);
            p = p.next;
        }
        int i = 1, j = 0;
        while(i < listOfNode.Count) {
            j = i - 1;
            temp = listOfNode[i];
            while(j >= 0 && temp.val < listOfNode[j].val) {
                listOfNode[j+1] = listOfNode[j];
                j--;
            }
            listOfNode[j+1] = temp;
            i++;
        }
        head = listOfNode[0];
        temp = head;
        for(int k = 1; k < listOfNode.Count; k++) {
            temp.next = listOfNode[k];
            temp = temp.next;
        }
        temp.next = null;
        return head;
    }
    public ListNode NewLinkedListMethod(ListNode head) {
        ListNode dummy = new ListNode();
        ListNode dummyTemp = dummy;
        ListNode p = head , temp = p;
        while(p != null) {
            temp = p;
            p = p.next;
            while(dummyTemp.next != null && dummyTemp.next.val < temp.val) {
                dummyTemp = dummyTemp.next;
            }
            temp.next = dummyTemp.next;
            dummyTemp.next = temp;
            dummyTemp = dummy;
        }
        return dummy.next;
    }
    
}