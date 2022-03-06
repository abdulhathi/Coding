using System;

public class MinJumpsToReachEndOfTheArrayTDDP {
    public MinJumpsToReachEndOfTheArrayTDDP() {
        int[] arr = {1,1,1,1,2};
        Console.WriteLine(TopDown_MinJumps(arr));
    }
    // Top down recursive approach with memoization
    public int TopDown_MinJumps(int[] arr) {
        int[] memory = new int[arr.Length];
        return TopDownDP(0);

        int TopDownDP(int i) {
            if(i == arr.Length-1)
                return 0;

            if(memory[i] > 0)
                return memory[i];
            
            int jump = int.MaxValue;
            for(int j = 1; j <= arr[i]; j++) {
                if(i+j < arr.Length) {
                    if(memory[i+j] == 0)
                        memory[i+j] = TopDownDP(i+j);
                    jump = Math.Min(jump, memory[i+j]+1);
                }
            }
            return jump;
        }
    }
}