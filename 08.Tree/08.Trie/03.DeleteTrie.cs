using System;

public class DeleteTrie {
    public DeleteTrie() {
        TrieNode root = new TrieNode();
        InsertTrie.Insert(new string[] {"abc","abgl","cdf","abcd","lmn"}, root);
        Delete("abgl", root, 0);
        InsertTrie.PrintTrie(root);
    }
    public bool Delete(string word, TrieNode root, int pos) {
        if(root == null) 
            return false;
        if(pos < word.Length) {
            if(root.Children.ContainsKey(word[pos])) {
                bool flag = Delete(word, root.Children[word[pos]], pos+1);
                if(flag)
                    return root.Children.Remove(word[pos]);
            }   
            else
                return false;
        }
        else if(root.IsEndOfWord)
            root.IsEndOfWord = false;
        return !root.IsEndOfWord && root.Children.Count == 0;
    }
}