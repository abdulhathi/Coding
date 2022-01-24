using System;
using System.Collections.Generic;

public class TrieNode {
    public Dictionary<char, TrieNode> Children;
    public bool IsEndOfWord;
    public TrieNode() {
        Children = new Dictionary<char, TrieNode>();
    }
}