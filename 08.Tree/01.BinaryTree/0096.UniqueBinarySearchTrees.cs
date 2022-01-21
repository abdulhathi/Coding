using System;

public class UniqueBinarySearchTrees {
    public UniqueBinarySearchTrees() {
        int possibleBSTs = NumTrees(19);
        Console.WriteLine(possibleBSTs);
    }
    Dictionary<int,int> memory = new Dictionary<int,int>();
    public int NumTrees(int n) {
        if(n == 0 || n == 1)
            return 1;
        int result = 0;
        for(int i = 0, j = n-1; i <= n-1 && j >= 0; i++, j--) {
            if(!memory.ContainsKey(i))       
                memory.Add(i, NumTrees(i));
            if(!memory.ContainsKey(j))
                memory.Add(j, NumTrees(j));
            result += memory[i]*memory[j];
        }
        return result;
    }
}