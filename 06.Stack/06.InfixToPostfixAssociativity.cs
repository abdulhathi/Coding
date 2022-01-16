using System;
using System.Collections.Generic;

public class InfixToPostfixAssociativity {
    public class Precedence {
        public char Symbol;
        public int OutStack;
        public int InStack;
        public Precedence(char symbol, int outStack, int inStack) {
            this.Symbol = symbol;
            this.OutStack = outStack;
            this.InStack = inStack;
        }
    }
    public InfixToPostfixAssociativity() {
        string postfix = Postfix("((a+b)*c)-d^e^f");
        Console.WriteLine(postfix);
    }
    public static string Postfix(string expression) {
        Dictionary<char, Precedence> precedences = new Dictionary<char, Precedence>();
        precedences.Add('+', new Precedence('+', 1, 2));
        precedences.Add('-', new Precedence('-', 1, 2));
        precedences.Add('*', new Precedence('*', 3, 4));
        precedences.Add('/', new Precedence('/', 3, 4));
        precedences.Add('^', new Precedence('^', 6, 5));
        precedences.Add('(', new Precedence('(', 7, 0));
        precedences.Add(')', new Precedence(')', 0, 0));

        string postfix = "";
        Stack<char> stack = new Stack<char>();
        foreach(var exp in expression) {
            if(precedences.ContainsKey(exp)) {
                while(stack.Count > 0 && precedences[stack.Peek()].InStack >= precedences[exp].OutStack) {
                    if(stack.Peek() == '(')
                        stack.Pop();
                    else
                        postfix += stack.Pop();
                }
                if(exp != ')')
                    stack.Push(exp);
            }
            else
                postfix += exp;
        }
        while(stack.Count > 0) {
            if(stack.Peek() == '(')
                stack.Pop();
            else
                postfix += stack.Pop();
        }
        return postfix;
    }
}