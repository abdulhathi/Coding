using System;

public class StaticOrGlobalVar {
    int x = 0;
    public void GlobalVarInRecursion() {
        Console.WriteLine(Fun1(5));
    }
    public int Fun1(int n) {
        if(n > 0) {
            x++;
            return Fun1(n-1) + x;
        }
        return 0;
    }
}