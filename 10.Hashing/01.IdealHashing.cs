using System;

public class IdealHashing {
    bool[,] hashTable = null;
    public IdealHashing(int maximumValue) {
        hashTable = new bool[maximumValue+1, 2];
    }
    public bool Search(int key) {
        if(key > hashTable.GetLength(0))
            return false;
        return hashTable[Math.Abs(key), (key < 0 ? 1 : 0)];
    }
    public void Insert(int[] input) {
        foreach(var num in input) {
            if(num > hashTable.GetLength(0))
                continue;
            if(num < 0)
                hashTable[-(num),1] = true;
            else
                hashTable[num,0] = true;
        }
    }
}
public class IdealHashingTesting
{
    public IdealHashingTesting() {
        var idealHashing = new IdealHashing(20);
        idealHashing.Insert(new int[] {2,4,5,6,-7,13,-14,17,8,9,23});
        Console.WriteLine(idealHashing.Search(25));
    }
}