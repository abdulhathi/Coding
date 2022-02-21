using System;

public class LinearProbing {
    private int[] hashTable = null;
    private bool[] tableFlag = null;
    private int loadSize = 0;
    private int size = 20;
    public LinearProbing() {
        hashTable = new int[size];
        tableFlag = new bool[size];
    }
    private int? HashPosition(int key) {
        int pos = key%size;
        for(int i = pos; i < (pos + size/2); i++)
            if(!tableFlag[i%size])
                return i%size;
        return null;
    }
    public void Insert(int key) {
        if(loadSize < size/2) {
            int? position = HashPosition(key);
            if(position != null) {
                hashTable[position.Value] = key;
                tableFlag[position.Value] = true;
                loadSize++;
            }
        }
    }
    public int FindKey(int key) {
        int i = 0, pos = (key + i++) % size;
        while(tableFlag[pos] && hashTable[pos] != key) {
            pos = (key + i++) % size;
        }
        return tableFlag[pos] ? pos : -1;
    }   
    public int[] GetList() {
        return hashTable;
    }
    public class LinearProbeTest {
        public LinearProbeTest() {
            var linearProbing = new LinearProbing();
            linearProbing.Insert(24);
            linearProbing.Insert(34);
            linearProbing.Insert(44);
            linearProbing.Insert(54);
            linearProbing.Insert(64);
            linearProbing.Insert(75);
            linearProbing.Insert(85);
            linearProbing.Insert(95);
            linearProbing.Insert(96);
            linearProbing.Insert(106);
            linearProbing.Insert(126);

            Console.WriteLine(linearProbing.FindKey(125));
            Console.WriteLine(string.Join(",",linearProbing.GetList()));
        }
    }
}