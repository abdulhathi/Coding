using System;
using System.Collections.Generic;

public class NumberOfGoodWaysToSplitAString {
    public NumberOfGoodWaysToSplitAString() {
        int goodSplit = NumSplits("aacaba");
        Console.WriteLine(goodSplit);
    }
    public int NumSplits(string s) {
        var leftMap = new Dictionary<char, int>();
        var rightMap = new Dictionary<char, int>();
        int goodSplitCount = 0;
        foreach(var chr in s) {
            if(!rightMap.ContainsKey(chr))
                rightMap.Add(chr, 0);
            rightMap[chr]++;
        }
        foreach(var chr in s) {
            if(!leftMap.ContainsKey(chr))
                leftMap.Add(chr, 0);
            leftMap[chr]++;
            
            if(rightMap.ContainsKey(chr)) {
                if(rightMap[chr] > 1)
                    rightMap[chr]--;
                else
                    rightMap.Remove(chr);
            }
            
            if(leftMap.Count == rightMap.Count)
                goodSplitCount++;
        }
        return goodSplitCount;
    }
}