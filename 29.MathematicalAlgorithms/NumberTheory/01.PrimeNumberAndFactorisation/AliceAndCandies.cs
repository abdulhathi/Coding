using System;

public class AliceAndCandies {
    public AliceAndCandies() {
        int possibleSets = Solve(1000000000);
        Console.WriteLine(possibleSets);
    }

    public int Solve(int n) {
        //var candySet = new HashSet<int>();
        int count = 0;
        int sum = 0;
        int i = 1, j = 1;
        while(j <= n) {
            if(sum <= n) {
                if(sum == n) {
                    //Console.WriteLine(string.Join(",", candySet));
                    count++;
                }
                // candySet.Add(j);
                sum = sum + j;
                j += 2;
            }
            else {
                // candySet.Remove(i);
                sum = sum - i;
                i += 2;
            }
        }
        if(n % 2 > 0) {
            // candySet.Clear();
            // candySet.Add(n);
            // Console.WriteLine(string.Join(",", candySet));
            count++;
        }
        return count;
    }
}