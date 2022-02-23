using System;

public class SubsetsUsingBit {
    public SubsetsUsingBit() {
        int[] nums = {1,2,3};
        var subsets = Subsets(nums);
        Console.WriteLine();
        foreach(var subset in subsets) {
            Console.WriteLine(string.Join(",", subset));
        } 
    }
    public IList<IList<int>> Subsets(int[] nums) {
        var subSets = new List<IList<int>>();
        int bitLength = nums.Length;
        int n = (1 << nums.Length);
        for(int i = 0; i < n; i++) {
            subSets.Add(GetNums(i));
        }
        return subSets;

        List<int> GetNums(int num) {
            var combination = new List<int>();
            for(int i = 0; i < bitLength; i++) {
                if(((num >> i) & 1) > 0)
                    combination.Add(nums[i]);
            }
            return combination;
        }
    }
}