using System;
using System.Collections.Generic;

public class SearchTrie {
    public SearchTrie() {
        TrieNode root = new TrieNode();
        InsertTrie.Insert(new string[] {"abc","abgl","cdf","abcd","lmn"}, root);
        bool prefix = SearchPrefixInTrie("abcde", root);
        Console.WriteLine($"Search Prefix of 'abcde' : {prefix}");
        bool fullWord = SearchFullWord("lmno", root);
        Console.WriteLine($"Search full word of 'lmno' : {fullWord}");
    }
    public bool SearchPrefixInTrie(string prefix, TrieNode root) {
        if(root == null)
            return false;
        foreach(var chr in prefix) {
            if(!root.Children.ContainsKey(chr))
                return false;
            root = root.Children[chr];
        }
        return true;
    }
    public bool SearchFullWord(string word, TrieNode root) {
        if(root == null)
            return false;
        foreach(var chr in word) {
            if(!root.Children.ContainsKey(chr))
                return false;
            root = root.Children[chr];
        }
        return root.IsEndOfWord;
    }
}