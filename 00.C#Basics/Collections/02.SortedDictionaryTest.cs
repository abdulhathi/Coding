using System;
using System.Collections.Generic;

public class SortedDictionaryTest {
    public SortedDictionaryTest() {
        var sortedDic = new SortedDictionary<int, SortedDictionary<int, List<int>>>();

        for(int i = -3; i <= 3; i++) {
            if(!sortedDic.ContainsKey(i))
                sortedDic.Add(i, new SortedDictionary<int, List<int>>());
            for(int j = 0; j <= 4; j++) {
                if(!sortedDic[i].ContainsKey(j))
                    sortedDic[i].Add(j, new List<int>() {1,2,3,4});
            }
        }

        var result = new List<IList<int>>();

        foreach(var column in sortedDic.Values)
            foreach(var row in column.Values)
                result.Add(row);

        
    }
}