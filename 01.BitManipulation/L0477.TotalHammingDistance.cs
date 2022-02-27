using System;

public class TotalHammingDistance {
    public TotalHammingDistance() {
        int totalHD = TotalHammingDistance_Method2(new int[]{4,14,2});
        Console.WriteLine(totalHD);
    }
    // Brute force apporach
    public int TotalHammingDistance_Method1(int[] nums) {
        int totalHammingDistance = 0;
        for(int i = 0; i < nums.Length; i++) {
            for(int j = i+1; j < nums.Length; j++) {
                totalHammingDistance += HammingDistance(nums[i],nums[j]);
            }
        }
        return totalHammingDistance;

        int HammingDistance(int num1, int num2) {
            int hammingDistance = 0;
            for(int i = 0; i < 32; i++) {
                if(((num1 & 1) != (num2 & 1)))
                    hammingDistance++;
                num1 >>= 1; num2 >>= 1; 
            }
            
            return hammingDistance;
        }
    }

    // Count Bit each column wise method
    public int TotalHammingDistance_Method2(int[] nums) {
        var countBits = new int[32];
        int totalHD = 0;
        foreach(var num in nums) {
            for(int i = 0; i < 32; i++) {
                countBits[i] += (num >> i) & 1;
            }
        }
        foreach(var count in countBits) {
            totalHD += count * (nums.Length-count);
        }
        return totalHD;
    }
}