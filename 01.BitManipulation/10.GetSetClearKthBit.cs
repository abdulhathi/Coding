using System;

public class GetSetClearKthBit {
    public GetSetClearKthBit() {
        Console.WriteLine("Get the {0} bit value is binary 1 or 0 for number {1} is {2}",3, 8, GetKthBitIsSetOrNot(8, 3));
        Console.WriteLine("Set the {0} bit value to 1 for num {1} : Result {2}", 4, 8, SetKthBit(8,4));
        Console.WriteLine("clear the {0} bit value to 0 for num {1} : Result {2}", 3, 10, ClearKthBit(10,3));
    }
    // Get the Kth bit values is binary 1 or 0
    public int GetKthBitIsSetOrNot(int num, int k) {
        return (num & (1 << k)) > 0 ? 1 : 0;
    }
    public int SetKthBit(int num, int k) {
        return (num | (1 << k));
    }
    public int ClearKthBit(int num, int k) {
        return (num & (~(1 << k)));
    }
}