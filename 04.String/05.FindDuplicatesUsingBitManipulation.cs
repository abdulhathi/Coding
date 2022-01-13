using System;

public class FindDuplicatesUsingBitManipulation {
    public FindDuplicatesUsingBitManipulation() {
        BitWiseOperation("findings");
    }
    public void BitWiseOperation(string str) {
        int chr = 1, result = 0;
        foreach(var c in str) {
            chr = 1;
            chr = chr << c - 97;
            if((result & chr) > 0)
                Console.WriteLine($"{c} is a duplicate char");
            else
                result = result | chr;
        }
    }
}