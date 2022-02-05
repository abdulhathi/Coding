using System;

public class FindMissingElemsInUnSorted {
    int[] arr = {3,7,4,9,12,6,11,2,10};

    public FindMissingElemsInUnSorted() {
        FindMissingElems();
    }
    // TimeComplexity : O(3n) => O(n)
    public void FindMissingElems() {
        int max = int.MinValue;
        foreach(var num in arr)
            if(max < num) 
                max = num;

        bool[] hashTable = new bool[max+1];
        foreach(var num in arr)
            hashTable[num] = true;
        for(int i = 0; i < hashTable.Length; i++)
            if(hashTable[i] == false)
                Console.Write(i+" ");
    }
}