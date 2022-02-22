public class SortIntegersByTheNumberOf1Bits {
    public SortIntegersByTheNumberOf1Bits() {
        // [0,1,2,3,4,5,6,7,8]
        // [1024,512,256,128,64,32,16,8,4,2,1]
        // [10000,10000]
        int[] arr = {0,1,2,3,4,5,6,7,8}; // {1024,512,256,128,64,32,16,8,4,2,1};
        var sorted = SortByBits(arr);
        Console.WriteLine(string.Join(",", sorted));
    }
    public int[] SortByBits(int[] arr) {
        var orderedBits = new int[arr.Length];
        var countMap = new SortedDictionary<int, List<int>>();
        for(int i = 0; i < arr.Length; i++) {
            int setBitCount = CountSetBit(arr[i]);
            if(!countMap.ContainsKey(setBitCount))
                countMap.Add(setBitCount, new List<int>());       
            countMap[setBitCount].Add(arr[i]);
        }
        int j = 0;
        foreach(var key in countMap.Keys)
            foreach(var num in countMap[key].OrderBy(x=>x))
                orderedBits[j++] = num;
    
        return orderedBits;
        
        int CountSetBit(int num) {
            int count = 0;
            while(num > 0) {
                num &= num-1;
                count++;
            }
            return count;
        }
    }
}