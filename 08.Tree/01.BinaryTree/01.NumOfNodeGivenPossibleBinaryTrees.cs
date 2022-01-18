using System;

public class NumOfNodeGivenPossibleBinaryTrees
{
    public NumOfNodeGivenPossibleBinaryTrees() {
        int nodeCount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Node count is {nodeCount} then number of Possible Binary trees {Summation(nodeCount)}");
    }
    public int CatalanNumber(int n) {
        /* Forumula : (2nCn)/(n+1)
            2n = n*2 = m
            2n = m*m-1*m-2*...*n-1
            Cn = n*n-1*n-2*...*1
        */
        int m = 2*n;
        int twoN = 1, cN = 1, catNum = 0;
        for(int i = m; i > n; i--)
            twoN *= i;
        for(int i = n; i > 0; i--)
            cN *= i;
        catNum = twoN/cN;
        catNum /= n+1;
        return catNum;
    }

    Dictionary<int,int> memory = new Dictionary<int,int>();
    public int Summation(int n) {
        /*
                T(0)*T(3) + T(1)*T(2) + T(2)*T(1) + T(3)*T(0)
        */
        if(n == 0)
            return 1;
        if(n == 1)
            return 1;

        int result = 0;
        for(int i = 0, j = n-1; i < n && j >= 0; i++, j--)
        {
            if(!memory.ContainsKey(i))
                memory[i] = Summation(i);
            if(!memory.ContainsKey(j))
                memory[j] = Summation(j);
            result += memory[i]*memory[j];
        }
        return result;
    }
}