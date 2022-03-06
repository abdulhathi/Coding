using System;

public class MinJumpsToReachEndOfTheArrayBUDP {
    public MinJumpsToReachEndOfTheArrayBUDP() {
        int[] arr = {3,4,1,1,2};
        Console.WriteLine(BottomUp_MinJumps(arr));
    }
    public int BottomUp_MinJumps(int[] arr) {
        int[] tabulation = Enumerable.Range(0, arr.Length).Select(x => int.MaxValue).ToArray();
        tabulation[arr.Length - 1] = 0;

        for(int i = arr.Length - 2; i >= 0; i--) {
            for(int j = 1; j <= arr[i]; j++) {
                if(i+j < arr.Length)
                    tabulation[i] = Math.Min(tabulation[i], tabulation[i+j] + 1);
            }
        }
        return tabulation[0];
    }
}