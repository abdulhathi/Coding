using System;

public class EvaluationOfPostfix {
    public EvaluationOfPostfix() {
        string postfix = InfixToPostfixAssociativity.Postfix("3*5+6/2-4");
        Console.WriteLine(postfix);
        Console.WriteLine($"Evaluation of postfix : {Evaluation(postfix)}");
    }
    public int Evaluation(string postfixExp) {
        Stack<int> stack = new Stack<int>();
        int y = 0,x = 0;
        foreach(var exp in postfixExp) {
            switch (exp) {
                case '+' :
                    y = stack.Pop();
                    x = stack.Pop();
                    stack.Push(x+y);
                    break;
                case '-' :
                    y = stack.Pop();
                    x = stack.Pop();
                    stack.Push(x-y);
                    break;
                case '*' :
                    y = stack.Pop();
                    x = stack.Pop();
                    stack.Push(x*y);
                    break;
                case '/' :
                    y = stack.Pop();
                    x = stack.Pop();
                    stack.Push(x/y);
                    break;
                default :
                    stack.Push(Convert.ToInt32(exp - '0'));
                    break;
            }
        }
        return stack.Count > 0 ? stack.Pop() : 0;
    }
}