using System;
using System.Text;

public class GenerateParentheses {
    public GenerateParentheses() {
        var result = GenerateParenthesis2(3);
        foreach(var perm in result)
            Console.WriteLine(perm);
    }
    public IList<string> GenerateParenthesis(int n) {
        string str = "";
        for(int i = 0; i < n; i++)
            str += "()";
        return PrintPermuation(str);
    }
    public IList<string> PrintPermuation(string str) {
        bool[] visited = new bool[str.Length];
        StringBuilder perm = new StringBuilder();
        HashSet<string> result = new HashSet<string>();
        DFS(0,0);
        
        return result.ToList();

        void DFS(int pos, int openParenCount) {
            if(pos == str.Length)
                result.Add(perm.ToString());
            else {    
                for(int i = 0; i < str.Length; i++) {
                    if(visited[i])
                        continue;
                    if(str[i] == ')' && openParenCount == 0)
                        return;
                    visited[i] = true;
                    perm.Append(str[i]);
                    DFS(pos+1,(str[i] == '(' ? openParenCount+1 : openParenCount-1));
                    perm.Remove(perm.Length-1,1);
                    visited[i] = false;
                }
            }
        }
    }

    public IList<string> GenerateParenthesis2(int n) {
        List<string> combination = new List<string>();
        StringBuilder current = new StringBuilder();

        DFS(n,n);
        return combination;
        
        void DFS(int open, int close) {
            if(open == 0 && close == 0)
                combination.Add(current.ToString());
            else {
                if(open > 0) {
                    current.Append('(');
                    DFS(open-1, close);
                    current.Remove(current.Length-1,1);
                }
                if(open < close) {
                    current.Append(')');
                    DFS(open, close-1);
                    current.Remove(current.Length-1,1);
                }
            }
        }
    }
}