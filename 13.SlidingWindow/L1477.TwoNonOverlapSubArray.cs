using System;

public class TwoNonOverlapSubArray {
    public TwoNonOverlapSubArray() {
        int[] arr = {2,2,4,4,4,4,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
        /*
            [0,5]6   - {2,2,4,4,4,4}
            [2,7]5   - {4,4,4,4,4}
            [6,23]17  - {4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}  
            [7,27]20  - {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}  
        */
        int count = MinSumOfLengths(arr, 20);
        Console.WriteLine(count);
    }
    public class Interval {
        public int Start;
        public int End;
        public Interval(int i, int j) { Start = i; End = j; }
    }
    
    public int MinSumOfLengths(int[] arr, int target) {
        var subArrayLenAndCount = new Dictionary<int, List<Interval>>();
        int i = 0, j = 0, currentSum = 0;
        int minLength = int.MaxValue, maxLength = int.MinValue;
        
        while(i < arr.Length && j < arr.Length) {
            if(currentSum < target)
                currentSum += arr[j++];
            else if(currentSum > target) 
                currentSum -= arr[i++];
            else {
                CountSubArray(j-i, new Interval(i, j-1));
                currentSum -= arr[i++];
            }
        }
        while(i < arr.Length) {
            if(currentSum == target)
                CountSubArray(j-i, new Interval(i, j-1));
            currentSum -= arr[i++];
        }
        
        int count = 2, lengthSum = 0;
        List<Interval> intervals = new List<Interval>();
        for(int k = minLength; k <= maxLength && count > 0; k++)
        {
            if(subArrayLenAndCount.ContainsKey(k)) {
                for(int l = 0; l < subArrayLenAndCount[k].Count && count > 0; l++) {
                    if(!IsOverLappingInterval(subArrayLenAndCount[k][l])) {
                        lengthSum += k;
                        count--;
                        intervals.Add(subArrayLenAndCount[k][l]);
                    }
                }
            }
        }
        
        return count > 0 ? -1 : lengthSum;

        bool IsOverLappingInterval(Interval currentInterval) {
            foreach(var interval in intervals) {
                if((currentInterval.Start >= interval.Start && currentInterval.Start <= interval.End)
                || (currentInterval.End >= interval.Start && currentInterval.End <= interval.End))
                    return true;
            }
            return false;
        }
        
        void CountSubArray(int length, Interval interval) {
            minLength = Math.Min(minLength, length);
            maxLength = Math.Max(maxLength, length);
            if(!subArrayLenAndCount.ContainsKey(length))
                subArrayLenAndCount.Add(length, new List<Interval>());
            subArrayLenAndCount[length].Add(interval);
        }
        
    }
}