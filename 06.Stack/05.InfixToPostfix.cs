using System;
using System.Collections.Generic;

public class InfixToPostfix {
    public InfixToPostfix() {
        string postfix = InfixToPostfixConversion("a+b*c-d/e");
        Console.WriteLine(postfix);
    }
    public string InfixToPostfixConversion(string expression) {
        Dictionary<char, int> precedence = new Dictionary<char, int>();
        precedence.Add('+',1);
        precedence.Add('-',1);
        precedence.Add('*',2);
        precedence.Add('/',2);
        Stack<char> stack = new Stack<char>();
        string postfix = "";
        foreach(var exp in expression) {
            if(precedence.ContainsKey(exp)) {
                while(stack.Count > 0 && precedence[stack.Peek()] >= precedence[exp]) {
                    postfix += stack.Pop();
                }
                stack.Push(exp);
            }
            else
                postfix += exp;
        }
        while(stack.Count > 0)
            postfix += stack.Pop();
        return postfix;
    }
}