using System;

public class SummaryRanges {
    public SummaryRanges() {
        var ranges = GetSummaryRanges(new int[] {0,2,3,4,6,8,9});
        Console.WriteLine(string.Join(",", ranges));
    }
    public IList<string> GetSummaryRanges(int[] nums) {
        List<string> ranges = new List<string>();
        if(nums.Length == 0)
            return ranges;
        
        int min = nums[0] , max = nums[0];
        string range = "" + min;
        for(int i = 1, j = min+1; i < nums.Length; i++, j++) {
            if(nums[i] > j)
            {
                range += max > min ? "->"+max : "";
                ranges.Add(range);
                min = j = nums[i];
                range = "" + min;
                continue;
            }
            max = nums[i];
        }
        range += max > min ? "->"+max : "";
        ranges.Add(range);
        return ranges;
    }
}