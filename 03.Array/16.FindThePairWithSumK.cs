using System;
using System.Collections;

public class FindThePairWithSumK {
    int[] arr = {6,3,8,10,16,7,5,2,9,14,2};
    public FindThePairWithSumK() {
        FindPairWithSumK(10);
    }
    public void FindPairWithSumK(int k) {
        Dictionary<int,int> ht = new Dictionary<int,int>();
        foreach(var num in arr) {
            if(ht.ContainsKey(k-num))
                Console.WriteLine($"Pair ({num},{k-num}) {ht[k-num]} times exist");
            if(!ht.ContainsKey(num))
                ht.Add(num,0);
            ht[num]++;
        }
    }
}