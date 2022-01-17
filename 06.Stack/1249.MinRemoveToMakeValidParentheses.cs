using System;
using System.Text;

public class MinRemoveToMakeValidParentheses {
    public MinRemoveToMakeValidParentheses() {
        string result = MinRemoveToMakeValid("))()((()");
        Console.WriteLine(result);
    }
    public string MinRemoveToMakeValid(string s) {
        StringBuilder sb = new StringBuilder();
        Stack<int> openParenPos = new Stack<int>();
        for(int i = 0; i < s.Length; i++) {
            if(s[i] == '(')
                openParenPos.Push(sb.Length);
            else if(s[i] == ')') {
                if(openParenPos.Count == 0)
                    continue;
                else {
                    openParenPos.Pop();
                }
            }
            sb.Append(s[i]);
        }
        while(openParenPos.Count > 0) {
            sb.Remove(openParenPos.Pop(),1);
        }
        return sb.ToString();
    }
}