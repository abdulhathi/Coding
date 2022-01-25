using System;

public class DeleteTrie {
    public DeleteTrie() {
        TrieNode root = new TrieNode();
        InsertTrie.Insert(new string[] {"abc","abgl","cdf","abcd","lmn"}, root);
        Console.WriteLine(); Delete("abc", root, 0); InsertTrie.PrintTrie(root);
        Console.WriteLine(); Delete("abcd", root, 0); InsertTrie.PrintTrie(root);
        Console.WriteLine(); Delete("abgl", root, 0); InsertTrie.PrintTrie(root);
        Console.WriteLine(); Delete("cdf", root, 0); InsertTrie.PrintTrie(root);
        Console.WriteLine(); Delete("lmn", root, 0); InsertTrie.PrintTrie(root);
    }
    public bool Delete(string word, TrieNode root, int pos) {
        if(root == null) 
            return false;
        if(pos >= word.Length)
            return root.IsEndOfWord;
        if(!root.Children.ContainsKey(word[pos]))
            return false;
        if(Delete(word, root.Children[word[pos]], pos+1)) {
            root.Children[word[pos]].IsEndOfWord = false;
            if(root.Children[word[pos]].Children.Count == 0) {
                root.Children.Remove(word[pos]);
                return true;
            }
        }
        return false;
    }
}