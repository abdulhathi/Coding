using System;
using System.Collections.Generic;

public class SortedSetTest {
    public SortedSetTest() {
        SortedSet<int> sortedSet = new SortedSet<int>();
        sortedSet.Add(100);
        sortedSet.Add(101);
        sortedSet.Add(102);
        sortedSet.Add(110);
        sortedSet.Add(120);

        Console.WriteLine(sortedSet.Max);

        Console.WriteLine(sortedSet.Remove(sortedSet.Max));

        var sortedSet1 = new SortedSet<(int key, int count)>();
        sortedSet1.Add((5,1));
        Console.WriteLine(sortedSet1.Contains((5,1)));
        sortedSet1.Add((5,2));
    }
}