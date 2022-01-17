using System;
using System.Collections.Generic;

public class SlidingWindowMaximum {
    public SlidingWindowMaximum() {
        int[] maxList = MaxSlidingWindow_ByDeque(new int[] {1,2,3,4,5}, 1);
        Console.WriteLine(string.Join(",", maxList));
    }
     public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] maxList = new int[nums.Length - (k-1)];
        var sortedSet = new SortedSet<int>();
        var slidingNums = new Dictionary<int, int>();
        for(int i = 0; i < k; i++) {
            sortedSet.Add(nums[i]);
            if(!slidingNums.ContainsKey(nums[i]))
                slidingNums.Add(nums[i],0);
            slidingNums[nums[i]]++;
        }
        maxList[0] = sortedSet.Max;
        int front = 0;
        for(int i = k, j = 1; i < nums.Length; i++, j++) {
            // Remove front
            front = nums[i-k];
            if(slidingNums[front] > 1)
                slidingNums[front]--;
            else {
                slidingNums.Remove(front);
                sortedSet.Remove(front);
            }
            //Add rear
            sortedSet.Add(nums[i]);
            if(!slidingNums.ContainsKey(nums[i]))
                slidingNums.Add(nums[i],0);
            slidingNums[nums[i]]++;
            maxList[j] = sortedSet.Max;
        }
        return maxList;
     }

    public class DoublyListNode {
        public int index;
        public int val;
        public DoublyListNode next;
        public DoublyListNode prev;
        public DoublyListNode(int index = 0, int val = 0, DoublyListNode next = null, DoublyListNode prev = null)
        {
            this.index = index;
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
    }

    DoublyListNode head = null, tail = null;
    public int[] MaxSlidingWindow_ByDeque(int[] nums, int k) {
        head = null; tail = null;
        int[] maxList = new int[nums.Length - (k-1)];
        for(int i = 0; i < nums.Length; i++) {
            DequeueFront(i, k);
            EnqueueRear(i, nums[i], k);
            //Console.WriteLine(head.val);
            if(i >= k-1)
                maxList[i - (k-1)] = head.val;
        }
        return maxList;
    }
    public void DequeueFront(int index, int k) {
        while(head != null && (index - head.index) >= k) {
            head = head.next;
            if(head != null)
                head.prev = null; 
            if(head == null)
                tail = null;
        }
    }
    public void EnqueueRear(int index, int val, int k) {
        if(tail == null) {
            tail = new DoublyListNode(index, val);
            head = tail;
        }
        else {
            while(tail != null && val > tail.val) {
                tail = tail.prev;
                if(tail != null)
                    tail.next = null;
                if(tail == null)
                    head = null;
            }
            if(tail == null) {
                tail = new DoublyListNode(index, val);
                head = tail;
            }
            else {
                tail.next = new DoublyListNode(index, val, null, tail);
                tail = tail.next;
            }
        }
    }
}