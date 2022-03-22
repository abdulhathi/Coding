public class Permutation {
    public Permutation() {
        GenerateAllPossiblePerms(3);
    }
    public void GenerateAllPossiblePerms(int n) {
        int[] nums = Enumerable.Range(1, n).Select(x=>x).ToArray();
        Console.WriteLine(string.Join(",", nums));
        var perm = new List<int>();
        var visited = new bool[n];

        BackTrack(0);


        void BackTrack(int pos) {
            if(nums.Length == pos)
                Console.WriteLine(string.Join(",", perm));
            else {
                for(int i = 0; i < n; i++) {
                    if(visited[i])
                        continue;
                    visited[i] = true;
                    perm.Add(nums[i]);
                    BackTrack(pos+1);
                    perm.Remove(nums[i]);
                    visited[i] = false;
                }
            }
        }
    }
}