using System;
using System.Collections.Generic;

public class Anagram {
    public Anagram() {
        bool isAnagram = IsAnagram("decimal","medicall");
        Console.WriteLine(isAnagram);
    }
    public bool IsAnagram(string str1, string str2) {
        Dictionary<char,int> dictionary = new Dictionary<char,int>();
        foreach(var chr in str1) {
            if(!dictionary.ContainsKey(chr))
                dictionary.Add(chr,0);
            dictionary[chr]++;
        }
        foreach(var chr in str2) {
            if(!dictionary.ContainsKey(chr) || dictionary[chr] == 0)
                return false;
            dictionary[chr]--;
        }
        foreach(var kvp in dictionary)
            if(kvp.Value > 0)
                return false;
        return true;
    }
}