using System;

public class FindDuplicatesBruteforceMethod {
    public FindDuplicatesBruteforceMethod() {
        var duplicates = FindDuplicates("findings");
        Console.WriteLine(string.Join(",", duplicates));
    }
    public List<char> FindDuplicates(string str) {
        List<char> duplicates = new List<char>();
        for(int i = 0; i < str.Length -1; i++) {
            for(int j = i + 1; j < str.Length; j++) {
                if(str[i] == str[j]) {
                    duplicates.Add(str[i]);
                }
            }
        }
        return duplicates;
    }
}