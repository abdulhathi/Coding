using System;
using System.Text;

public class BasicCalculator 
{
    public class Precedence {
        public int OutStack;
        public int InStack;
        public Precedence(int outStack, int inStack) {
            this.OutStack = outStack;
            this.InStack = inStack;
        }
    }
    public BasicCalculator() {
        int result = Calculate("2-4-(8+2-6+(8+4-(1)+8-10))");
        Console.WriteLine(result);
    }
    
     public int Calculate(string s) {
        s = s.Replace(" ","");
        StringBuilder expression = new StringBuilder();
        expression.Append((char)s[0] == '-' ? '~' : (char)s[0]);
        string nums = "0123456789";
        for(int i = 1; i < s.Length; i++)
        {
            if(!nums.Contains(s[i]) && nums.Contains(s[i-1])) 
                expression.Append(",");
            if(s[i] == '-' && s[i-1] == '(')
                expression.Append('~');
            else
                expression.Append((char)s[i]);
        }
        if(nums.Contains(expression[expression.Length-1]))
            expression.Append(",");
        Console.WriteLine(expression.ToString());
        return InfixToPostfixAndEvaluate(expression.ToString());
        //Console.WriteLine(postfix);
        //return EvaluatePostfix(postfix);
    }
    public int InfixToPostfixAndEvaluate(string expression) {
        string postfix = string.Empty;
        Dictionary<char, Precedence> precedences = new Dictionary<char, Precedence>();
        precedences.Add('+', new Precedence(1,2));
        precedences.Add('-', new Precedence(1,2));
        precedences.Add('~', new Precedence(1,2));
        precedences.Add('(', new Precedence(3,0));
        precedences.Add(')', new Precedence(0,0));
        Stack<char> stack = new Stack<char>();
        Stack<int> stack1 = new Stack<int>();
        foreach(var exp in expression) {
            if(precedences.ContainsKey(exp)) {
                while(stack.Count > 0 && precedences[stack.Peek()].InStack >= precedences[exp].OutStack) {
                    if(stack.Peek() == '(') {
                        stack.Pop();
                        break;
                    }
                    else
                        postfix += stack.Pop();
                }
                if(exp != ')')
                    stack.Push(exp);
                if(exp == '+' || exp == '-') {
                    EvaluatePostfix(postfix, stack1);
                    postfix = "";
                }
            }
            else {
                postfix += exp;
            }
        }
        while(stack.Count > 0) 
            postfix += stack.Pop();
        EvaluatePostfix(postfix, stack1);
        return stack1.Count > 0 ? stack1.Pop() : 0;
    }
    public void EvaluatePostfix(string postfix, Stack<int> stack) {
        int x = 0, y = 0;
        for(int i = 0; i < postfix.Length; i++) {
            switch (postfix[i]) {
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
                case '~' :
                    stack.Push(-stack.Pop());
                    break;
                default :
                    int num = 0;
                    while(postfix[i] != ',') {
                        num *= 10;
                        num += Convert.ToInt32(postfix[i]-'0');
                        //Console.WriteLine(num);
                        i++;
                    }
                    if(postfix[i] == ',')
                        stack.Push(num);
                    break;
            }
        }
        //return stack.Count > 0 ? stack.Pop() : 0;
    }
}