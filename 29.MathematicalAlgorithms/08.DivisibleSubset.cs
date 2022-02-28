using System;
using System.Collections.Generic;

public class DivisibleSubset {
    public DivisibleSubset() {
        int[] multiSet = {1,2,3,5,7};
        var subSets = FindDivisibleSubset(multiSet, 5);
        foreach(var subSet in subSets) {
            Console.WriteLine(string.Join(",", subSet));
        }
    }
    public List<int[]> FindDivisibleSubset(int[] multiSet, int n) {
        Dictionary<int, List<int>> subSetCount = new Dictionary<int, List<int>>();
        int len = multiSet.Length;
        int[] prefixSumWithMod = new int[len];
        int prefixSum = 0;
        for(int i = 0; i < len; i++) {
            prefixSum += multiSet[i];
            prefixSumWithMod[i] = prefixSum % n;
        }

        for(int i = 0; i < len; i++) {
            if(!subSetCount.ContainsKey(prefixSumWithMod[i]))
                subSetCount.Add(prefixSumWithMod[i], new List<int>());
            subSetCount[prefixSumWithMod[i]].Add(i);
        }

        List<int[]> subSetRange = new List<int[]>();
        if(subSetCount.ContainsKey(0)) {
            subSetRange.Add(new int[] {0, subSetCount[0][0]});
            subSetCount.Remove(0);
        }
        foreach(var key in subSetCount.Keys) {
            if(subSetCount[key].Count > 1) {
                for(int i = 1; i < subSetCount[key].Count; i++) {
                    subSetRange.Add(new int[] { subSetCount[key][0]+1, subSetCount[key][i] });
                }
            }
        }

        return subSetRange;
    }
}