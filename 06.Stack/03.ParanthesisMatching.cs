using System;
using System.Collections.Generic;

public class ParanthesisMatching {
    public ParanthesisMatching() {
        bool match = IsMatching("(((a+b)*(c-d))");
        Console.WriteLine(match);
    }
    public bool IsMatching(string expression) {
        var parenKVP = new KeyValuePair<char, char>(')','(');
        Stack<char> stack = new Stack<char>();
        foreach(var exp in expression) {
            if(parenKVP.Value == exp)
                stack.Push(exp);
            else if(exp == parenKVP.Key) {
                if(stack.Count == 0)
                    return false;
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }
}