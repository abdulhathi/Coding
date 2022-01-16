using System;
using System.Collections.Generic;

public class BracketsMatching {
    public BracketsMatching() {
        bool isMatch = IsBracketsMatch("{([a+b]*[c-d])/e]");
        Console.WriteLine(isMatch);
    }
    public bool IsBracketsMatch(string expression) {
        Dictionary<char, char> brackets = new Dictionary<char, char>();
        brackets.Add('}','{');
        brackets.Add(')','(');
        brackets.Add(']','[');
        Stack<char> stack = new Stack<char>();
        foreach(var exp in expression) {
            if(brackets.ContainsValue(exp))
                stack.Push(exp);
            else if(brackets.ContainsKey(exp)) {
                if(stack.Count == 0)
                    return false;
                if(brackets[exp] != stack.Peek())
                    return false;
                stack.Pop();
             }
        }
        return stack.Count == 0;
    }
}