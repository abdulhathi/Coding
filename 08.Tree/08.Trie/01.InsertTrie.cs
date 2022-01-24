using System;

public class InsertTrie {
    public InsertTrie() {
        TrieNode root = new TrieNode();
        string[] words = {"abc","abgl","cdf","abcd","lmn"};
        Insert(words, root);
        PrintTrie(root);
    }
    public static TrieNode Insert(string[] words, TrieNode root) {
        foreach(var word in words)
            Insert(word, root);
        return root;
    }
    public static TrieNode Insert(string word, TrieNode root) {
        TrieNode current = root;
        foreach(var chr in word) {
            if(!current.Children.ContainsKey(chr))
                current.Children.Add(chr, new TrieNode());
            current = current.Children[chr];
        }
        current.IsEndOfWord = true;
        return root;
    }
    public static void PrintTrie(TrieNode current, string prefix = "") {
        if(current.IsEndOfWord)
            Console.Write(prefix+", ");
        foreach(var children in current.Children) {
            PrintTrie(children.Value, prefix + children.Key);
        }
    }
}