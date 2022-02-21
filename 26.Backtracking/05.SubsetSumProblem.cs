using System;
using System.Collections.Generic;

public class SubsetSumProblemByDP {
    
    public SubsetSumProblemByDP() {
        int[] input = {5,10,12,13,15,18};
        var combinations = SubsetSum_Backtracking(input, 30);
        foreach(var combination in combinations)
            Console.WriteLine(string.Join(",", combination));
    }
    public List<List<int>> SubsetSum_Backtracking(int[] input, int sum) {
        List<List<int>> result = new List<List<int>>();
        int total = 0, currSum = 0, count = 0; 
        List<int> nums = new List<int>();

        foreach(var num in input)
            total += num;

        SubsetSum(0);
        Console.WriteLine(count);
        return result;

        void SubsetSum(int i) {
            if(currSum == sum)
                Console.WriteLine(string.Join(",",nums));
            else if(i < input.Length && currSum < sum) {
                count++;
                // Including the value
                currSum += input[i];
                nums.Add(input[i]);
                SubsetSum(i+1);

                // Not including the value
                currSum -= input[i];
                nums.RemoveAt(nums.Count - 1);
                SubsetSum(i+1);
            }
        }
    }
}