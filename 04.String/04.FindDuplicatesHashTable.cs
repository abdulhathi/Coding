using System;

public class FindDuplicatesHashTable {
    public FindDuplicatesHashTable() {
        var dups = FindDuplicates("Findings");
        Console.WriteLine(string.Join(",",dups));
    }
    public HashSet<char> FindDuplicates(string str) {
        HashSet<char> hashSet = new HashSet<char>();
        HashSet<char> duplicates = new HashSet<char>();
        foreach(var chr in str) {
            if(hashSet.Contains(chr))
                duplicates.Add(chr);
            hashSet.Add(chr);
        }
        return duplicates;
    }
}