using System;

public class PolicemenCatchThieves {
    public PolicemenCatchThieves() {
        // int result = FindThievesCount(new char[] {'T', 'T', 'P', 'P', 'T', 'P'}, 2);
        // int result = FindThievesCount(new char[] {'P', 'T', 'T', 'P', 'T'}, 1);
        int result = FindThievesCount(new char[] {'P', 'T', 'P', 'T', 'T', 'P'}, 3);
        Console.WriteLine(result);
    }
    public int FindThievesCount(char[] arr, int k) {
        int maxThievesCaught = 0;
        for(int i = 0; i < arr.Length; i++) {
            if(arr[i] == 'T') {
                int count = 0;
                int m = k > i ?  0 : (i-k), n = k + i >= arr.Length ? arr.Length - 1 : k + i;
                for(;count == 0 && m < i; m++) {
                    if(arr[m] != 'P')
                        continue;
                    arr[m] = 'C';
                    count++;
                }
                for(; count == 0 && n > i; n--) {
                    if(arr[n] != 'P')
                        continue;
                    arr[n] = 'C';
                    count++;
                }
                maxThievesCaught += count;
            }
        }
        return maxThievesCaught;
    }
}