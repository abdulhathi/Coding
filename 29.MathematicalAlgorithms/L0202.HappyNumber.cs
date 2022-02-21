/*  202. Happy Number
    Write an algorithm to determine if a number n is happy.
    
    A happy number is a number defined by the following process:

    Starting with any positive integer, replace the number by the sum of the squares of its digits.
    Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
    Those numbers for which this process ends in 1 are happy.
    Return true if n is a happy number, and false if not.

    Example 1:
        Input: n = 19
        Output: true
        Explanation:
        12 + 92 = 82
        82 + 22 = 68
        62 + 82 = 100
        12 + 02 + 02 = 1

    Example 2:
        Input: n = 2
        Output: false

    Constraints:
        1 <= n <= 231 - 1
    https://leetcode.com/problems/happy-number/
*/

public class HappyNumer {
    public HappyNumer() {
        Console.WriteLine(IsHappy(19));
        Console.WriteLine(IsHappy_Iterative(3));
    }
    /*  1. No of digits in a number is logN
        2. No of loops to find the final value 1 or repeated number is logN
        So Time Complexity is O(log(logN))
        Space complexity is O(logN) to store the values in hashset.
    */
    public bool IsHappy(int n) {
        var hashSet = new HashSet<int>();
        return CheckTheHappyNum(n);
        
        bool CheckTheHappyNum(int n) {
            int temp = n;
            n = 0;
            do {
                n += Convert.ToInt32(Math.Pow(temp % 10, 2));
                temp = temp / 10;
            }
            while(temp > 0);
            if(n == 1)
                return true;
            if(hashSet.Contains(n))
                return false;
            hashSet.Add(n);
            return CheckTheHappyNum(n);
        }
    }
    public bool IsHappy_Iterative(int n) {
        var hashSet = new HashSet<int>();
        int temp = 0;
        while(n != 1 && !hashSet.Contains(n)) {
            hashSet.Add(n);
            temp = n;
            n = 0;
            while(temp > 0) {
                n += (temp % 10) * (temp % 10);
                temp = temp / 10;
            }
        }
        return n == 1 ? true : false;
    }
}