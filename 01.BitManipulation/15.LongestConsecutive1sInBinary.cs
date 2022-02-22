using System;

public class LongestConsecutive1sInBinary {
    public LongestConsecutive1sInBinary() {
        Console.WriteLine(LongestConsecutive1s(47));
    }
    public int LongestConsecutive1s(int num) {
        int max = 0;
        int continousMax = 0;
        while(num > 0) {
            if((num & 1) > 0)
                continousMax++;
            else
                continousMax = 0;
            max = Math.Max(max, continousMax);
            num = num >> 1;
        } 
        return max;
    }
}