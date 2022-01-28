using System;
using System.Collections.Generic;

public class SortedSetUnitTest {
    public SortedSetUnitTest() {
        SortedSet();
        SortedSetWithComparer();
    }
    public void SortedSet() {
        SortedSet<int> sortedSet = new SortedSet<int>();
        sortedSet.Add(1);
        sortedSet.Add(10);
        sortedSet.Add(112);
        sortedSet.Add(11232);
        Console.WriteLine("{0},{1}", sortedSet.Min, sortedSet.Max);
    }
    public void SortedSetWithComparer() {
        SortedSet<KeyValuePair<string, int>> familySet = new SortedSet<KeyValuePair<string, int>>(
            Comparer<KeyValuePair<string, int>>.Create((a,b) => {
                return a.Value.CompareTo(b.Value);
            })
        );

        familySet.Add(new KeyValuePair<string, int>("Abdul",10000));
        familySet.Add(new KeyValuePair<string, int>("Aysha",1000));
        familySet.Add(new KeyValuePair<string, int>("Afsar",100));
        familySet.Add(new KeyValuePair<string, int>("Afraz",10));
        familySet.Add(new KeyValuePair<string, int>("Amira",1));

        Console.WriteLine("{0},{1}", familySet.Min, familySet.Max);
    }
}