public class ConcatenationOfArray {
 public ConcatenationOfArray() {
     var ans = GetConcatenation(new int[] {1,3,2,1});
     Console.WriteLine(string.Join(",",ans));
 }
 public int[] GetConcatenation(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n*2];
        for(int i = 0;i < n; i++) {
            ans[i] = ans[i+n] = nums[i];
        }
        return ans;
    }
}